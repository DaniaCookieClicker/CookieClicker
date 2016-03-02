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
        int choosenDragon;
        int prevDragon;
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
            //if (GameWorld.BossHealth>0)
            //{
            // pictureBox1.Image = ((Image)Properties.Resources.ResourceManager.GetObject("Sprites/Dragon/dragon1.png"));
            if (GameWorld.BossHealth<=0)
            {
                Random rand = new Random();

            choosenDragon = rand.Next(1, 10);
                if (prevDragon==choosenDragon)
                {
                    choosenDragon = rand.Next(1, 10);
                }

                
            pictureBox1.Image = Image.FromFile("Sprites/Dragon/dragon"+choosenDragon+".png");
              
                pictureBox1.Refresh();
                pictureBox1.Visible = true;
                prevDragon = choosenDragon;
               
            }
            //if (GameWorld.BossHealth > 0&&GameWorld.Level == 3)
            //{

            //    pictureBox1.Image = Image.FromFile("Sprites/Dragon/dragon2.png");
            //    pictureBox1.Refresh();
            //    pictureBox1.Visible = true;
                
            //}
           
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Unit sword = new Unit("Sprites/Swordman/SmAttack1.png;Sprites/Swordman/SmAttack2.png;Sprites/Swordman/SmAttack3.png;Sprites/Swordman/SmAttack4.png;Sprites/Swordman/SmAttack5.png;Sprites/Swordman/SmAttack6.png;Sprites/Swordman/SmAttack7.png;Sprites/Swordman/SmAttack8.png;Sprites/Swordman/SmAttack9.png;Sprites/Swordman/SmAttack10.png;Sprites/Swordman/SmAttack11.png", new Vector2D(200, 50), 2, 10);
            GameWorld.toAdd.Add(sword);
            Unit.Cost(10);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Unit archer = new Unit("Sprites/Archer/ArcAttack1.png;Sprites/Archer/ArcAttack2.png;Sprites/Archer/ArcAttack3.png;Sprites/Archer/ArcAttack4.png;Sprites/Archer/ArcAttack5.png;Sprites/Archer/ArcAttack6.png;Sprites/Archer/ArcAttack7.png;Sprites/Archer/ArcAttack8.png;Sprites/Archer/ArcAttack9.png;Sprites/Archer/ArcAttack10.png;Sprites/Archer/ArcAttack11.png;Sprites/Archer/ArcAttack12.png", new Vector2D(200, 200), 15, 40);
            GameWorld.toAdd.Add(archer);
            Unit.Cost(20);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Unit knight = new Unit("Sprites/Knight/KniAttack1.png;Sprites/Knight/KniAttack2.png;Sprites/Knight/KniAttack3.png;Sprites/Knight/KniAttack4.png;Sprites/Knight/KniAttack5.png;Sprites/Knight/KniAttack6.png;Sprites/Knight/KniAttack7.png;Sprites/Knight/KniAttack8.png;Sprites/Knight/KniAttack9.png", new Vector2D(200, 250), 15, 40);
            GameWorld.toAdd.Add(knight);
            Unit.Cost(40);
        }
    }
}
