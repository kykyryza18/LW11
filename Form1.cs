using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB11
{
    public partial class Form1 : Form
    {
        private SolidBrush brush = new SolidBrush(Color.Blue);
        private int x = 0, y = 0, d = 60, namside = 0;
        private int w, h;
        private int[,] side = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        private void Form1_Resize(object sender, EventArgs e)
        {
            w = ClientSize.Width;
            h = ClientSize.Height;
            if (namside == 1) x = w - d;
            if (namside == 2) y = h - d;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(brush, x, y, d, d);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            w = ClientSize.Width;
            h = ClientSize.Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += side[namside, 0];
            y += side[namside, 1];
            if (x == 0 && y == 0) namside = 0;
            if (x == w - d && y == 0) namside = 1;
            if (x == w - d && y == h - d) namside = 2;
            if (x == 0 && y == h - d) namside = 3;
            Invalidate();
        }
    }
}
