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
        private void Form_load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(textBox1.Text);
            int end_time = Convert.ToInt32(textBox2.Text);
            int naj_time = Convert.ToInt32(textBox3.Text);
            int fishy_x = Convert.ToInt32(textBox4.Text), fishy_y = Convert.ToInt32(textBox5.Text);
            int naj_x = Convert.ToInt32(textBox6.Text), naj_y = Convert.ToInt32(textBox7.Text);
            int pop_x = Convert.ToInt32(textBox8.Text), pop_y = Convert.ToInt32(textBox9.Text);
            int place_x = Convert.ToInt32(textBox10.Text), place_y = Convert.ToInt32(textBox11.Text);
            int t_naj = 0,t_pop = 0;

            for (int i = 0; i <= count; ++i)
            {
                if (t_naj >= naj_time-23000)
                {
                    t_naj = 0;
                }
                /*Наживка*/
                    if (t_naj == 0){
                        Cursor.Position = new Point(naj_x, naj_y);
                        mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, 0, UIntPtr.Zero);
                        Thread.Sleep(100);/*дилей между событиями клика, вдруг спалят что бот*/
                        mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, 0, UIntPtr.Zero);
                        Thread.Sleep(2500);/*время на каст*/
                    }
                /*Наживка*/

                if (t_pop>=1777000)
                {
                    t_pop = 0;
                }
                /*увеличение поплавка*/
                if (t_pop == 0)
                {
                    Cursor.Position = new Point(pop_x, pop_y);
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, 0, UIntPtr.Zero);
                    Thread.Sleep(100);/*дилей между событиями клика, вдруг спалят что бот*/
                    mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, 0, UIntPtr.Zero);
                    Thread.Sleep(2000);/*время на каст*/
                }
                /*увеличение поплавка*/

                /*закидываем крючок*/
                    Cursor.Position = new Point(fishy_x, fishy_y);
                        mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, 0, UIntPtr.Zero);
                        Thread.Sleep(100);/*дилей между событиями клика, вдруг спалят что бот*/
                        mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, 0, UIntPtr.Zero);
                        Thread.Sleep(end_time);/*время ожидания*/
                    t_pop += 100+end_time;
                    t_naj += 100 + end_time;
                /*закидываем крючок*/

                /*вылавливаем*/
                int x = place_x;
                    for (int n = 0; n <= 5; ++n)
                    {
                        Cursor.Position = new Point(x,place_y);
                        mouse_event(MouseFlags.Absolute | MouseFlags.RightDown, 0, UIntPtr.Zero);
                        Thread.Sleep(100);/*дилей между событиями клика, вдруг спалят что бот*/
                        mouse_event(MouseFlags.Absolute | MouseFlags.RightUp, 0, UIntPtr.Zero);
                        x += 80;
                        Thread.Sleep(150);/*дилей между перемещением курсора*/
                        t_pop += 250;
                        t_naj += 250;
                    }
                /*вылавливаем*/
               
            }
        }

    }
}
