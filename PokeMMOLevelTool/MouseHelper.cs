using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace PokeMMOLevelTool
{
    class MouseHelper
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rectangle lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, Keys wParam, uint lParam);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, Keys wParam, uint lParam);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out Rectangle rect);

        public static Mainform mainform;
 
        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        const int WM_SETTEXT = 0x0C;
        const int WM_GETTEXT = 0x0D;
        const int WM_ACTIVATE = 0x06;
        const int WA_ACTIVE = 0x01;
        const int WA_CLICKACTIVE = 0x02;

        public static void MouseLeftClick(IntPtr hwnd, int x, int y)
        {
            PostMessage(hwnd, 0x0200, IntPtr.Zero, (IntPtr)MakeLParam(x, y));
            PostMessage(hwnd, 0x0201, IntPtr.Zero, (IntPtr)MakeLParam(x, y));
            PostMessage(hwnd, 0x0202, IntPtr.Zero, (IntPtr)MakeLParam(x, y));
        }

        public static void MouseRightClick(IntPtr hwnd, int x, int y)
        {
            PostMessage(hwnd, 0x0200, IntPtr.Zero, (IntPtr)MakeLParam(x, y));
            PostMessage(hwnd, 0x0204, IntPtr.Zero, (IntPtr)MakeLParam(x, y));
            PostMessage(hwnd, 0x0205, IntPtr.Zero, (IntPtr)MakeLParam(x, y));
        }

        public static int MakeLParam(int LoWord, int HiWord)
        {
            return (int)((HiWord << 16) | (LoWord & 0xFFFF));
        }

        public static void KeyPressRealtime(IntPtr hwnd, Keys keyCode, int time = 0, bool extended = false)
        {
            uint scanCode = MapVirtualKey((uint)keyCode, 0);
            uint lParam;
            mainform?.Log("Key Press " + keyCode.ToString() + " " + time.ToString());

            //KEY DOWN
            lParam = (0x00000001 | (scanCode << 16));
            if (extended)
            {
                lParam |= 0x01000000;
            }
            SendMessage(hwnd, 0x0100, keyCode, lParam);

            Thread.Sleep(time);

            //KEY UP
            lParam |= 0xC0000000;  // set previous key and transition states (bits 30 and 31)
            SendMessage(hwnd, 0x0101, keyCode, lParam);
        }

        public static void KeyPress(IntPtr hwnd, Keys keyCode, int time = 0, bool extended = false)
        {
            uint scanCode = MapVirtualKey((uint)keyCode, 0);
            uint lParam;
            mainform?.Log("Key Press " + keyCode.ToString() + " " + time.ToString());

            PostMessage(hwnd, WM_ACTIVATE, (IntPtr)WA_CLICKACTIVE, IntPtr.Zero);

            //KEY DOWN
            lParam = (0x00000001 | (scanCode << 16));
            if (extended)
            {
                lParam |= 0x01000000;
            }
            PostMessage(hwnd, 0x0100, keyCode, lParam);

            Thread.Sleep(time);

            //KEY UP
            lParam |= 0xC0000000;  // set previous key and transition states (bits 30 and 31)
            PostMessage(hwnd, 0x0101, keyCode, lParam);
        }

        public static void KeyDown(IntPtr hwnd, Keys keyCode, bool extended)
        {
            uint scanCode = MapVirtualKey((uint)keyCode, 0);
            uint lParam;
            PostMessage(hwnd, WM_ACTIVATE, (IntPtr)WA_CLICKACTIVE, IntPtr.Zero);
            //KEY DOWN
            lParam = (0x00000001 | (scanCode << 16));
            if (extended)
            {
                lParam |= 0x01000000;
            }
            PostMessage(hwnd, 0x0100, keyCode, lParam);
        }

        public static void KeyUp(IntPtr hwnd, Keys keyCode)
        {
            uint scanCode = MapVirtualKey((uint)keyCode, 0);
            uint lParam;
            PostMessage(hwnd, WM_ACTIVATE, (IntPtr)WA_CLICKACTIVE, IntPtr.Zero);
            //KEY DOWN
            lParam = (0x00000001 | (scanCode << 16));

            //KEY UP
            lParam |= 0xC0000000;  // set previous key and transition states (bits 30 and 31)
            PostMessage(hwnd, 0x0101, keyCode, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        public static string GetText(IntPtr hwnd)
        {
            const int buffer_size = 1024;
            StringBuilder buffer = new StringBuilder(buffer_size);
            SendMessage(hwnd, WM_GETTEXT, buffer_size, buffer);
            return buffer.ToString();
        }

        public static void SetText(IntPtr hwnd, string msg)
        {
            foreach (char c in msg)
            {
                KeyPress(hwnd, (Keys)Enum.Parse(typeof(Keys), c.ToString().ToUpper()),100);
                Thread.Sleep(50);
            }
        }

        public static bool IsOnFront(IntPtr ptr1)
        {
            IntPtr ptr2 = GetForegroundWindow();
            return ptr1 == ptr2;
        }

        public static void DoActions(IntPtr hwnd, string ActionsStr)
        {
            string[] Actions = ActionsStr.Replace(" ","").Split(';');
            foreach (string action in Actions)
            {
                if (action.Length == 0) continue;
                if (action.Contains("="))
                {
                    if (action.Length == 1)
                    {
                        Thread.Sleep(200);
                    }
                    else
                    {
                        Thread.Sleep(int.Parse(action.Replace("=", "")));
                    }
                    continue;
                }
                else if (action.Contains(","))
                {
                    string[] kt = action.Split(',');
                    KeyPress(hwnd, (Keys)Enum.Parse(typeof(Keys), kt[0]), int.Parse(kt[1]));
                }
                else
                {
                    KeyPress(hwnd, (Keys)Enum.Parse(typeof(Keys), action));
                }

            }
        }
    }
}
