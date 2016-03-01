using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieClicker
{
    public partial class Form1 : Form
    {
        Graphics dc;
        GameWorld gw;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gw.GameLoop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dc == null)
            {
                dc = CreateGraphics();
            }
            gw = new GameWorld(dc, this.DisplayRectangle);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GameWorld.BossHealth -= GameWorld.PlayerDmg;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Unit knight = new Unit("Sprites/knight.png", new Vector2D(200, 150), 15, 40);
            GameWorld.toAdd.Add(knight);
            Unit.Cost(40);
        }
    }
}
