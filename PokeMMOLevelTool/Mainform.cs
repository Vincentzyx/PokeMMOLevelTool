using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.Security.Cryptography;
using System.ComponentModel.Design;

namespace PokeMMOLevelTool
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        public static bool Run = false;
        public static bool skipPC = false;
        Thread thWork;
        PMClient client = new PMClient();
        public static PMTSettings Settings = new PMTSettings();
        public static Dictionary<string, Bitmap> ImgModels = new Dictionary<string, Bitmap>();
        public static Dictionary<string, Size> ImgSizeBuffer = new Dictionary<string, Size>();
        public static Dictionary<string, Bitmap> NumSamples = new Dictionary<string, Bitmap>();
        public double latency = 1.1;
        SoundPlayer Sound = new SoundPlayer();
        Keys LeftKey = Keys.NumPad1;
        Keys RightKey = Keys.NumPad3;
        Keys UpKey = Keys.NumPad5;
        Keys DownKey = Keys.NumPad2;
        Keys AKey = Keys.A;
        Keys BKey = Keys.S;

        private void Mainform_Load(object sender, EventArgs e)
        {
            LoadImgModels();
            MouseHelper.mainform = this;
            client.Log += Log;
            client.UpdateBitmap += UpdateScreen;
        }

        public void Log(string str)
        {
            this.Invoke(new Action(() =>
            {
                richTextBox_log.AppendText(DateTime.Now + " / " + str + "\r\n");
                richTextBox_log.ScrollToCaret();
            }));
        }

        public void UpdateScreen(object sender, Bitmap bm)
        {
            pictureBox_show.Image = new Bitmap(bm);
        }

        void NotifySound()
        {
            SystemSounds.Beep.Play();
            Thread.Sleep(400);
            SystemSounds.Hand.Play();
        }

        void w_ShuangLong()
        {
            client.ClickOnImage("pm_tutuquan");
            Thread.Sleep(100);
            client.ClickOnImage("usetopc");
            Thread.Sleep(6000);
            client.KeyPress(AKey, 100);
            Thread.Sleep(1000);
            client.KeyPress(AKey, 97);
            Thread.Sleep(1000);
            client.KeyPress(AKey, 115);
            Thread.Sleep(1000);
            client.KeyPress(AKey, 111);
            Thread.Sleep(6000);
            client.KeyPress(BKey, 155);
            Thread.Sleep(2000);
            client.KeyPress(DownKey, 2500);
            Thread.Sleep(2500);

            client.KeyPress(Keys.F3);
            Thread.Sleep(100);
            client.KeyPress(LeftKey, 3146);
            Thread.Sleep(100);
            client.KeyPress(DownKey, 245);
            Thread.Sleep(100);
            client.KeyPress(LeftKey, 1063);
            Thread.Sleep(2000);
            client.KeyPress(LeftKey, 2183);
            Thread.Sleep(2000);
            client.KeyPress(LeftKey, 500);
            Thread.Sleep(100);
            client.KeyPress(DownKey, 500);
        }

        void w_LongMu()
        {
            client.ClickOnImage("pm_tutuquan");
            Thread.Sleep(100);
            client.ClickOnImage("usetopc");
            Thread.Sleep(6000);
            client.KeyPress(Keys.A, 100);
            Thread.Sleep(1000);
            client.KeyPress(Keys.A, 97);
            Thread.Sleep(1000);
            client.KeyPress(Keys.A, 115);
            Thread.Sleep(1000);
            client.KeyPress(Keys.A, 111);
            Thread.Sleep(6000);
            client.KeyPress(Keys.S, 155);
            Thread.Sleep(2000);
            client.KeyPress(Keys.NumPad2, 2500);
            Thread.Sleep(2500);

            client.KeyPress(Keys.F3);
            Thread.Sleep(100);
            client.KeyPress(LeftKey, 3220);
            Thread.Sleep(50);
            client.KeyPress(Keys.F3);
            Thread.Sleep(200);
            client.KeyPress(UpKey, 250);
        }

        void w_Xuehua()
        {
            client.ClickOnImage("pm_tutuquan");
            Thread.Sleep(100);
            client.ClickOnImage("usetopc");
            Thread.Sleep(1800);
            client.KeyPress(Keys.Z, 100);
            Thread.Sleep(5000);
            client.KeyPress(Keys.Z, 97);
            Thread.Sleep(1000);
            client.KeyPress(Keys.Z, 115);
            Thread.Sleep(1000);
            client.KeyPress(Keys.Z, 111);
            Thread.Sleep(2000);
            client.KeyPress(Keys.Z, 155);
            Thread.Sleep(5000);
            client.KeyPress(Keys.Z, 136);
            Thread.Sleep(1000);
            client.KeyPress(Keys.Down, 2176);
            Thread.Sleep(2500);

            client.KeyPress(Keys.F1);
            Thread.Sleep(300);
            client.KeyPress(Keys.Right, 1762);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 627);
            Thread.Sleep(100);
            client.KeyPress(Keys.Right, 499);
            Thread.Sleep(100);
            client.KeyPress(Keys.Up, 411);
            Thread.Sleep(100);
            client.KeyPress(Keys.Right, 1040);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 545);
            Thread.Sleep(100);
            client.KeyPress(Keys.Right, 418);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 590);
            Thread.Sleep(100);
            client.KeyPress(Keys.Left, 602);
            Thread.Sleep(100);
            client.KeyPress(Keys.Z, 140);
            Thread.Sleep(1000);
            client.KeyPress(Keys.Z, 140);
            Thread.Sleep(1500);
        }

        void w_Xuehua_DragonTower()
        {
            client.ClickOnImage("pm_tutuquan");
            Thread.Sleep(100);
            client.ClickOnImage("usetopc");
            Thread.Sleep(6000);
            client.KeyPress(AKey, 100);
            Thread.Sleep(1000);
            client.KeyPress(AKey, 97);
            Thread.Sleep(1000);
            client.KeyPress(AKey, 115);
            Thread.Sleep(1000);
            client.KeyPress(AKey, 111);
            Thread.Sleep(6000);
            client.KeyPress(BKey, 155);
            Thread.Sleep(2000);
            client.KeyPress(DownKey, 2500);
            Thread.Sleep(2500);

            client.KeyPress(Keys.F3);
            Thread.Sleep(100);
            client.KeyPress(LeftKey, 600);
            Thread.Sleep(100);
            client.KeyPress(UpKey, 3000);
            Thread.Sleep(100);
            client.KeyPress(RightKey, 500);
            Thread.Sleep(100);
            client.KeyPress(UpKey, 1000);
            Thread.Sleep(100);
            client.KeyPress(LeftKey, 300);
            Thread.Sleep(100);
            client.KeyPress(UpKey, 800);
            Thread.Sleep(3500);
            client.KeyPress(UpKey, 600);
            Thread.Sleep(100);
            client.KeyPress(RightKey, 300);
            Thread.Sleep(100);
            client.KeyPress(AKey, 111);
            Thread.Sleep(1000);
            client.KeyPress(AKey, 111);
            Thread.Sleep(4000);
        }

        void w_Mushui()
        {
            client.ClickOnImage("pm_tutuquan");
            Thread.Sleep(100);
            client.ClickOnImage("usetopc");
            Thread.Sleep(1000);
            client.KeyPress(Keys.Z, 100);
            Thread.Sleep(4000);
            client.KeyPress(Keys.Z, 100);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 97);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 115);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 111);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 155);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 136);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 136);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Down, 2000);
            Thread.Sleep(4000);
            client.KeyPress(Keys.Down, 100);
            Thread.Sleep(100);
            client.KeyPress(Keys.Left, 200);

            Thread.Sleep(300);
            client.KeyPress(Keys.Down, 200);
            Thread.Sleep(100);
            client.KeyPress(Keys.Z, 100);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 100);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 100);
            Thread.Sleep(2500);

        }

        void w_gdGuanjun()
        {
            
            client.KeyPress(Keys.Down, 400);
            Thread.Sleep(4500);
            client.ClickOnImage("pm_tutuquan");
            Thread.Sleep(100);
            client.ClickOnImage("usetopc");
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 100);
            Thread.Sleep(4000);
            client.KeyPress(Keys.Z, 97);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 115);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 111);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 155);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Z, 155);
            Thread.Sleep(1500);
            client.KeyPress(Keys.Down, 1200);
            Thread.Sleep(100);
            client.KeyPress(Keys.Left, 400);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 200);
            Thread.Sleep(4000);

            client.KeyPress(Keys.F1);
            Thread.Sleep(500);
            client.KeyPress(Keys.Down, 1228);
            Thread.Sleep(100);
            client.KeyPress(Keys.Right, 815);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 414);
            Thread.Sleep(100);
            client.KeyPress(Keys.Left, 375);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 1016);
            Thread.Sleep(100);
            client.KeyPress(Keys.Right, 510);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 443);
            Thread.Sleep(100);
            client.KeyPress(Keys.Left, 428);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 763);
            Thread.Sleep(100);
            client.KeyPress(Keys.Right, 684);
            Thread.Sleep(100);
            client.KeyPress(Keys.Down, 1531);
            Thread.Sleep(100);
            client.KeyPress(Keys.Left, 653);
            Thread.Sleep(100);
            client.KeyPress(Keys.Up, 536);
            Thread.Sleep(100);
            client.KeyPress(Keys.Right, 129);
            Thread.Sleep(100);
            client.KeyPress(Keys.Up, 765);
            Thread.Sleep(4000);
            client.KeyPress(Keys.Up);
        }

        void w_10thRoad()
        {
            client.ClickOnImage("pm_tutuquan");
            Thread.Sleep(100);
            client.ClickOnImage("usetopc");
            Thread.Sleep(6000);
            client.KeyPress(Keys.A, 100);
            Thread.Sleep(1000);
            client.KeyPress(Keys.A, 97);
            Thread.Sleep(1000);
            client.KeyPress(Keys.A, 115);
            Thread.Sleep(1000);
            client.KeyPress(Keys.A, 111);
            Thread.Sleep(6000);
            client.KeyPress(Keys.S, 155);
            Thread.Sleep(2000);
            client.KeyPress(Keys.NumPad2, 2500);
            Thread.Sleep(2500);

            client.KeyPress(Keys.F3);
            Thread.Sleep(100);
            client.KeyPress(Keys.NumPad3, 800);
            Thread.Sleep(100);
            client.KeyPress(Keys.NumPad5, 4063);
            Thread.Sleep(500);
            client.KeyPress(Keys.NumPad5, 2183);
            Thread.Sleep(2000);
            client.KeyPress(Keys.NumPad1, 600);
            Thread.Sleep(100);
            client.KeyPress(Keys.NumPad5, 800);
        }

        bool isLs = false;
        bool Pause = false;

        void CatchLS()
        {
            Thread.Sleep(2000);

            while (Run)
            {
                if (ImageHelper.FindImageFromTop(client.GetImg(), new Bitmap(ImgModels["player"]), 80).X == -1)
                {
                    Thread.Sleep(200);

                    if (ImageHelper.FindImageFromTop(client.GetImg(), new Bitmap(ImgModels["pm_huoqiushu"]), 80).X != -1)
                    {
                        if (isLs == false)
                        {
                            isLs = true;
                            this.Invoke(new Action(() =>
                            {
                                this.BackColor = Color.Red;
                                NotifySound();
                                this.TopMost = true;
                            }));
                            Pause = true;
                            
                            while (Pause)
                            {
                                Thread.Sleep(100);
                            }

                            this.Invoke(new Action(() =>
                            {
                                this.BackColor = Color.White;
                                this.TopMost = false;
                            }));
                        }
                    }
                    else
                    {
                        if (ImageHelper.FindImageFromTop(client.GetImg(), new Bitmap(ImgModels["try2catch"]), 80).X != -1)
                        {
                            client.ClickOnImage("try2run");
                        }
                    }
                }
                else
                {
                    if (isLs == true)
                    {
                        isLs = false;
                        this.Invoke(new Action(() =>
                        {
                            this.BackColor = Color.White;
                        }));
                    }
                    client.KeyPress(Keys.Left, 500);
                    client.KeyPress(Keys.Right, 500);
                }

            }
        }

        void Level()
        {
            while (Run)
            {

                var img = client.GetImg();
                //pictureBox1.Image = img;
                if (!skipPC)
                {
                    if (checkBox_useDefault.Checked)
                    {
                        if (radioButton_shuanglong10.Checked)
                            w_10thRoad();
                        if (radioButton_shuanglong9.Checked)
                            w_ShuangLong();
                        if (radioButton_dragonTower.Checked)
                            w_Xuehua_DragonTower();
                        if (radioButton_longmu.Checked)
                            w_LongMu();
                    }
                }
                else
                {
                    skipPC = false;
                }

                Thread.Sleep(1000);
                for (int i = 0; i < 6; i++)
                {

                    client.ClickOnImage("pm_tutuquan");
                    Thread.Sleep(200);
                    client.ClickOnImage("tiantianxiangqi");
                    Thread.Sleep(2000);
                    client.KeyPress(Keys.Z);
                    Thread.Sleep(4000);
                    while (ImageHelper.FindImageFromTop(client.GetImg(), new Bitmap(ImgModels["black"]), 50, (int)(img.Height * 0.5), (int)(img.Height * 0.8), (int)(img.Width * 0.7)).X != -1)
                    {
                        if (ImageHelper.FindImageFromTop(client.GetImg(), new Bitmap(ImgModels["shiny_title"]), 140).X != -1)
                        {
                            this.Invoke(new Action(() =>
                            {
                                this.BackColor = Color.Red;
                                this.TopMost = true;
                            }));
                            while (Run)
                            {
                                NotifySound();
                                Thread.Sleep(500);
                            }
                            thWork.Abort();
                            break;
                        }

                        bool r = client.ClickOnImage("fight");
                        if (r)
                        {
                            Thread.Sleep(100);
                            client.KeyPress(Keys.Space);
                            Thread.Sleep(100);
                            client.KeyPress(Keys.Space);
                        }
                        Thread.Sleep(300);
                    }
                    Thread.Sleep(2000);
                }
            }
        }

        void LoadImgModels()
        {
            for (int i = 0; i <= 9; i++)
            {
                Bitmap bm = new Bitmap(@"num\" + i.ToString() + ".png");
                Color currectWhite = Color.FromArgb(0, 0, 0, 0);
                for (int y = 0; y < bm.Height; y++)
                {
                    for (int x = 0; x < bm.Width; x++)
                    {
                        var c = bm.GetPixel(x, y);
                        if (c.R == 255 && c.G == 255 && c.B == 255)
                        {
                            bm.SetPixel(x, y, currectWhite);
                        }
                    }
                }
                NumSamples.Add(i.ToString(), bm);
            }

            foreach (var file in Directory.GetFiles("imgModels"))
            {
                if (file.EndsWith(".png"))
                {
                    string imgName = file.Split('\\').Last().Split('.')[0];
                    Bitmap tmp = new Bitmap(file);
                    ImgModels.Add(imgName, tmp);
                    ImgSizeBuffer.Add(imgName, new Size(tmp.Width, tmp.Height));
                }
            }

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Pause = false;
            Run = true;
            thWork = new Thread(new ThreadStart(Level));
            thWork.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            Run = false;
        }

        private void button_stopimm_Click(object sender, EventArgs e)
        {
            Pause = false;
            Run = false;
            thWork.Abort();
        }

        private void button_skippc_Click(object sender, EventArgs e)
        {
            Pause = false;
            Run = true;
            skipPC = true;
            thWork = new Thread(new ThreadStart(Level));
            thWork.Start();
        }

        private void timer_cancel_Tick(object sender, EventArgs e)
        {
            if (ImageHelper.FindImageFromTop(client.GetImg(), new Bitmap(ImgModels["miaomiao"])).X != -1)
            {
                client.KeyPress(Keys.X);
                Thread.Sleep(150);
                client.KeyPress(Keys.Z);
            }
        }

        private void button_continue_Click(object sender, EventArgs e)
        {
            Pause = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            client.KeyPress(Keys.Up, 2000);
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Join(" ", client.ReadPokemonInfo()));
            Debug.WriteLine(ImageHelper.FindImageFromBottomRight(client.GetImg(), new Bitmap(ImgModels["shiny"]), 100).X != -1 ? "Is shiny" : "Not shiny");
        }

        Bitmap lastBmp = null;
        private void timer_moveDetect_Tick(object sender, EventArgs e)
        {
            Bitmap img = client.GetImg();
            Graphics gdi = Graphics.FromImage(img);
            gdi.FillEllipse(Brushes.Red, (float)(img.Width * 0.55), (float)(img.Height * 0.55), 10, 10);
            pictureBox_show.Image = img;
            if (lastBmp == null)
            {
                lastBmp = img;
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            richTextBox_log.Text = string.Join(" ", client.ReadPokemonInfo());
        }
    }
}
