using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace PokeMMOLevelTool
{
    class PMClient
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        public IntPtr PokeMMOClient;
        public Bitmap ScreenshotBuffer;
        public int StatusCount = 5;
        public PMTSettings Settings = Mainform.Settings;
        public delegate void LogHandler(string str);
        public event LogHandler Log;
        public event EventHandler<Bitmap> UpdateBitmap;

        public PMClient()
        {
            PokeMMOClient = FindWindow("GLFW30", null);
            GetImg();
        }

        void tewst(Action<string> l)
        {
            l("!23");
        }

        public bool CheckClient()
        {
            if ((int)PokeMMOClient != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int imgCount = 0;
        public Bitmap GetImg()
        {
            
            Bitmap tmp = ScreenshotHelper.GetWindowCapture(PokeMMOClient);
            imgCount++;
            if (imgCount > 20)
            {
                imgCount = 0;
                GC.Collect();
            }
            ScreenshotBuffer = tmp;
            UpdateBitmap?.Invoke(this, tmp);
            return tmp;
        }

     

        public void DoActions(string Actions)
        {
            MouseHelper.DoActions(PokeMMOClient, Actions);
        }

        public List<int> ReadPokemonInfo()
        {
            List<int> list = new List<int>();
            var pos = ImageHelper.FindImageFromTop(GetImg(), new Bitmap(Mainform.ImgModels["hpGeti"]), 80);
            if (pos.X == -1) { Log?.Invoke("Cannot Find HP Value!"); return list; }

            var wImg = ImageHelper.GetWhiteTextFromImage(ImageHelper.CutImage(GetImg(), new Rectangle(pos.X + 90, pos.Y, 30, 172)));
            wImg = CutImageEdge(wImg);
            int startY = 0, endY = 0;
            bool inChar = false;
            for (int i = 0; i < wImg.Height; i++)
            {
                if (!inChar)
                {
                    if (!IsBlankHorizontal(wImg, i))
                    {
                        inChar = true;
                        startY = i;
                    }
                }
                else
                {
                    if (IsBlankHorizontal(wImg, i) || i == wImg.Height - 1)
                    {
                        inChar = false;
                        if (i != wImg.Height - 1) endY = i - 1;
                        else endY = i;
                        int vNum = GetNumFromImage(ImageHelper.CutImage(wImg, new Rectangle(0, startY, wImg.Width, endY - startY + 1)));
                        list.Add(vNum);
                    }
                }
            }
            return list;
        }
        Random ran = new Random();

        int GetNumFromImage(Bitmap bm)
        {
            var img = CutImageEdge(bm);
            if (img.Height > img.Width) // One Num
            {
                var str = CompareWithSamples(img);
                return int.Parse(str);
            }
            else // Two Num
            {
                for (int i = 0; i < img.Width; i++)
                {
                    if (IsBlankVertical(img, i))
                    {
                        var n1 = CutImageEdge(ImageHelper.CutImage(img, new Rectangle(0, 0, i, img.Height)));
                        var strN1 = CompareWithSamples(n1);
                        var n2 = CutImageEdge(ImageHelper.CutImage(img, new Rectangle(i + 1, 0, img.Width - i, img.Height)));
                        var strN2 = CompareWithSamples(n2);
                        return int.Parse(strN1 + strN2);
                    }
                }
            }
            return -1;
        }

        string CompareWithSamples(Bitmap bm)
        {
            foreach (var numSample in Mainform.NumSamples)
            {
                if (CompareImageCount(bm, numSample.Value))
                    return numSample.Key;
            }
            return "";
        }

        bool CompareImage(Bitmap bm1, Bitmap bm2)
        {
            if (bm1.Width == bm2.Width && bm1.Height == bm2.Height)
            {
                for (int y = 0; y < bm1.Height; y++)
                {
                    for (int x = 0; x < bm1.Width; x++)
                    {
                        var c1 = bm1.GetPixel(x, y);
                        var c2 = bm2.GetPixel(x, y);
                        if (c1.A != c2.A || c1.R != c2.R || c1.G != c2.G || c1.B != c2.B)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        bool CompareImageCount(Bitmap bm1, Bitmap bm2, int countThreshold = 3)
        {
            if (bm1.Width == bm2.Width && bm1.Height == bm2.Height)
            {
                int count = 0;
                for (int y = 0; y < bm1.Height; y++)
                {
                    for (int x = 0; x < bm1.Width; x++)
                    {
                        var c1 = bm1.GetPixel(x, y);
                        var c2 = bm2.GetPixel(x, y);
                        if (c1.A != c2.A || c1.R != c2.R || c1.G != c2.G || c1.B != c2.B)
                        {
                            count++;
                        }
                    }
                }
                if (count <= countThreshold) return true;
                else return false;
            }
            else
            {
                int maxWidth = Math.Max(bm1.Width, bm2.Width);
                int maxHeight = Math.Max(bm1.Height, bm2.Height);
                int minWidth = Math.Min(bm1.Width, bm2.Width);
                int minHeight = Math.Min(bm1.Height, bm2.Height);
                int minCount = countThreshold + 1;
                for (int dy = minHeight - maxHeight; dy <= maxHeight - minHeight; dy++)
                {
                    for (int dx = minWidth - maxWidth; dx <= maxWidth - minWidth; dx++)
                    {
                        int count = 0;
                        for (int y = 0; y < bm1.Height; y++)
                        {
                            for (int x = 0; x < bm1.Width; x++)
                            {
                                var c1 = bm1.GetPixel(x, y);
                                if (y + dy >= 0 && y + dy < bm2.Height && x + dx >= 0 && x + dx < bm2.Width)
                                {
                                    var c2 = bm2.GetPixel(x + dx, y + dy);
                                    if (c1.A != c2.A || c1.R != c2.R || c1.G != c2.G || c1.B != c2.B)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                        if (count < minCount) minCount = count;
                    }
                }
                if (minCount <= countThreshold) return true;
                else return false;
            }

        }


        private static Bitmap CutImageEdge(Bitmap bm)
        {
            int startX = 0, startY = 0, endX = bm.Width - 1, endY = bm.Height - 1;

            // Up
            for (int i = 0; i < bm.Height; i++)
            {
                if (!IsBlankHorizontal(bm, i))
                {
                    startY = i;
                    break;
                }
            }

            // Down
            for (int i = bm.Height - 1; i >= 0; i--)
            {
                if (!IsBlankHorizontal(bm, i))
                {
                    endY = i;
                    break;
                }
            }

            // Left
            for (int i = 0; i < bm.Width; i++)
            {
                if (!IsBlankVertical(bm, i))
                {
                    startX = i;
                    break;
                }
            }

            // Right
            for (int i = bm.Width - 1; i >= 0; i--)
            {
                if (!IsBlankVertical(bm, i))
                {
                    endX = i;
                    break;
                }
            }

            return ImageHelper.CutImage(bm, new Rectangle(startX, startY, endX - startX + 1, endY - startY + 1));
        }

        private static bool IsBlankVertical(Bitmap bm, int lineX)
        {
            for (int i = 0; i < bm.Height; i++)
            {
                if (bm.GetPixel(lineX, i).A != 0) return false;
            }
            return true;
        }

        private static bool IsBlankHorizontal(Bitmap bm, int rowY)
        {
            for (int i = 0; i < bm.Width; i++)
            {
                if (bm.GetPixel(i, rowY).A != 0) return false;
            }
            return true;
        }

      
        

        public bool ModifyName(string name)
        {
            Thread.Sleep(200);
            var pos = ImageHelper.FindImageFromTop(GetImg(), Mainform.ImgModels["modifyName"]);
            if (pos.X != -1)
            {
                MouseHelper.MouseLeftClick(PokeMMOClient, (int)((pos.X + 3) / Mainform.Settings.ScreenZoomRate), (int)((pos.Y + 3) / Mainform.Settings.ScreenZoomRate - 35));
                Thread.Sleep(300);
                MouseHelper.SetText(PokeMMOClient, name);
                return true;
            }
            return false;
        }

        public bool ClickOnImage(string img)
        {
            var pos = ImageHelper.FindImageFromTop(GetImg(), new Bitmap(Mainform.ImgModels[img]), 120);
            if (pos.X != -1)
            {
                MouseHelper.MouseLeftClick(PokeMMOClient, (int)((pos.X + 3) / Mainform.Settings.ScreenZoomRate), (int)((pos.Y + 3) / Mainform.Settings.ScreenZoomRate - 35));
                Log?.Invoke(img + " Click On: " + pos.X + ", " + pos.Y);
                return true;
            }
            else
            {
                Log?.Invoke(img + " Not Found!");
            }
            return false;
        }
      

        public void OnTop()
        {
            MouseHelper.SetForegroundWindow(PokeMMOClient);
        }

        public bool IsWindowActive()
        {
            return MouseHelper.IsOnFront(PokeMMOClient);
        }

        Color GetAvgColor(Bitmap bm, int x, int y, int width = 15, int height = 15)
        {
            Color c;
            int r = 0, g = 0, b = 0;
            for (int ix = x; ix < x + width; ix++)
            {
                for (int iy = y; iy < y + height; iy++)
                {
                    c = bm.GetPixel(ix, iy);
                    r += c.R;
                    g += c.G;
                    b += c.B;
                }
            }
            int pxCount = width * height;
            return Color.FromArgb(r / pxCount, g / pxCount, b / pxCount);
        }

        int GetRGBAvg(Color c)
        {
            return (c.R + c.G + c.B) / 3;
        }

        int GetColorDiff(Color c1, Color c2)
        {
            return Math.Abs(c1.R - c2.R) + Math.Abs(c1.G - c2.G) + Math.Abs(c1.B - c2.B);
        }

        public void LMouseClick(int x, int y)
        {
            MouseHelper.MouseLeftClick(PokeMMOClient, x, y);
        }

        public enum vKeyCode
        {
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_X = 0x58,
            VK_Z = 0x5A,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_TAB = 0x9
        }

        public void KeyPress(Keys KeyCode, int time = 0)
        {
            MouseHelper.KeyPress(PokeMMOClient, KeyCode, time);
        }

        public void KeyDown(Keys KeyCode)
        {
            MouseHelper.KeyDown(PokeMMOClient, KeyCode, false);
        }

        public void KeyUp(Keys KeyCode)
        {
            MouseHelper.KeyUp(PokeMMOClient, KeyCode);
        }

        public string GetText()
        {
            return MouseHelper.GetText(PokeMMOClient);
        }
    }
}
