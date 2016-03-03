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
        Random position = new Random();
        bool showMsg = true;
        Graphics dc;
        GameWorld gw;
        int choosenDragon;
        int prevDragon;
        static Object thisLock = new Object();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gw.GameLoop();
            if (GameWorld.BossHealth >= 2000000000 && showMsg == true)
            {
                showMsg = false;
                MessageBox.Show("Congratulations, you beat the game");
            }
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

            if (GameWorld.BossHealth <= 0)
            {
                Random rand = new Random();

                choosenDragon = rand.Next(1, 10);
                if (prevDragon == choosenDragon)
                {
                    choosenDragon = rand.Next(1, 10);
                }


                pictureBox1.Image = Image.FromFile("Sprites/Dragon/dragon" + choosenDragon + ".png");

                pictureBox1.Refresh();
                pictureBox1.Visible = true;
                //this.PictureBox1.SizeMode = PictureBoxSizeMode.
                prevDragon = choosenDragon;

            }
 }

        public void AlternativeClick()
        {
            lock (thisLock)
            {
                if (GameWorld.BossHealth <= 0)
                {
                    Random rand = new Random();

                    choosenDragon = rand.Next(1, 10);
                    if (prevDragon == choosenDragon)
                    {
                        choosenDragon = rand.Next(1, 10);
                    }


                    pictureBox1.Image = Image.FromFile("Sprites/Dragon/dragon" + choosenDragon + ".png");

                    pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.Refresh(); });
                    pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.Visible = true; });

                    prevDragon = choosenDragon;

                }
            }
        }
        int swordmanDmg = 2;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (GameWorld.Gold >= GameWorld.SwordmanCost)
            {
                GameWorld.Gold -= GameWorld.SwordmanCost;
                GameWorld.SwordmanCost *= 2;
                Unit sword = new Swordman("Sprites/Swordman/SmAttack1.png;Sprites/Swordman/SmAttack2.png;Sprites/Swordman/SmAttack3.png;Sprites/Swordman/SmAttack4.png;Sprites/Swordman/SmAttack8.png", new Vector2D(position.Next(200, 500), 50), swordmanDmg, this);
                swordmanDmg *= 2;
                GameWorld.SwordmanCount++;
                GameWorld.toAdd.Add(sword);
            }
        }
        int archerDmg = 5;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (GameWorld.Gold >= GameWorld.ArcherCost)
            {
                GameWorld.Gold -= GameWorld.ArcherCost;
                GameWorld.ArcherCost *= 2;
                Unit archer = new Archer("Sprites/Archer/ArcAttack1.png;Sprites/Archer/ArcAttack2.png;Sprites/Archer/ArcAttack3.png;Sprites/Archer/ArcAttack4.png;Sprites/Archer/ArcAttack9.png;Sprites/Archer/ArcAttack10.png;Sprites/Archer/ArcAttack11.png;Sprites/Archer/ArcAttack12.png", new Vector2D(position.Next(200, 500), 200), archerDmg, this);
                archerDmg *= 2;
                GameWorld.ArcherCount++;
                GameWorld.toAdd.Add(archer);
            }
        }
        int knightDmg = 10;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (GameWorld.Gold >= GameWorld.KnightCost)
            {
                GameWorld.Gold -= GameWorld.KnightCost;
                GameWorld.KnightCost *= 2;
                Unit knight = new Knight("Sprites/Knight/KniAttack1.png;Sprites/Knight/KniAttack2.png;Sprites/Knight/KniAttack4.png;Sprites/Knight/KniAttack5.png", new Vector2D(position.Next(200, 425), 250), knightDmg, this);
                knightDmg *= 2;
                GameWorld.KnightCount++;
                GameWorld.toAdd.Add(knight);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (GameWorld.Gold >= GameWorld.WeaponCost)
            {
                GameWorld.Gold -= GameWorld.WeaponCost;
                GameWorld.WeaponCost *= 4;
                GameWorld.PlayerDmg *= 2;
            }
        }
    }
}
