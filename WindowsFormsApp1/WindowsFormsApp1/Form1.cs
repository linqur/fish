using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dwData, UIntPtr dwExtraInfo);
        [Flags]
        enum MouseFlags
        {
            Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
            RightUp = 0x0010, Absolute = 0x8000
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1000; ++i)
            {
                Cursor.Position = new Point(470, 1045);
                mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, 0, UIntPtr.Zero);
                mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, 0, UIntPtr.Zero);
                Thread.Sleep(17000);
                int x = 600, y = 600;
                for (int n = 0; n <= 15; ++n)
                {
                    Cursor.Position = new Point(x, y);
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, 0, UIntPtr.Zero);
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, 0, UIntPtr.Zero);
                    x += 40;
                    Thread.Sleep(200);
                }
            }
        }
    }
}
