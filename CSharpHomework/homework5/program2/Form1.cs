using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        double positionPer1;
        double positionPer2;
        Pen col;
        private void draw_button_Click(object sender, EventArgs e)
        {
            this.th1 = Double.Parse(textBox1.Text) * Math.PI / 180;
            this.th2 = Double.Parse(textBox2.Text) * Math.PI / 180;
            this.per1 = Double.Parse(textBox3.Text);
            this.per2 = Double.Parse(textBox4.Text);
            this.positionPer1 = Double.Parse(textBox5.Text);
            this.positionPer2 = Double.Parse(textBox6.Text);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        private void drawCayleyTree(int n,double x0,double y0,double length,double th)
        {
            if (n == 0) return;
            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            double x2 = x0 + length *positionPer1* Math.Cos(th);
            double y2 = y0 + length *positionPer1* Math.Sin(th);
            double x3 = x0 + length *positionPer2* Math.Cos(th);
            double y3 = y0 + length *positionPer2* Math.Sin(th);
            drawCayleyTree(n - 1, x2, y2, length * per1, th + th1);
            drawCayleyTree(n - 1, x3, y3, length * per2, th - th2);
        }
        private void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(col, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(listBox1.Text)
            {
                case "Red":
                    col = Pens.Red;
                    break;
                case "Yellow":
                    col = Pens.Yellow;
                    break;
                case "Blue":
                    col = Pens.Blue;
                    break;
            }
        }
    }
}
