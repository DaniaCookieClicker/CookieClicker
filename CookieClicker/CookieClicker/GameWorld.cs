using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace CookieClicker
{


    class GameWorld
    {
        private static int swordmanCost = 10;
        private static int archerCost = 20;
        private static int knightCost = 40;
        private static int weaponCost = 10;
        private static int knightCount;
        private static int archerCount;
        private static int swordmanCount;
        private static int level = 1;
        private static int bossHealth = 6;
        private static int fixedHealth = 6;
        private static int playerDmg = 100;
        private static int gold = 0;
        private static List<GameObject> toRemove = new List<GameObject>();
        public static List<GameObject> toAdd = new List<GameObject>();
        private Graphics dc;
        private static List<GameObject> gameObj;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;
        private Rectangle displayRectangle;
        public static List<GameObject> GameObj
        {
            get { return gameObj; }
            set { gameObj = value; }
        }
        public static List<GameObject> ToRemove
        {
            get { return toRemove; }
            set { toRemove = value; }
        }
        #region Properties
        public static int Gold
        {
            get
            {
                return gold;
            }

            set
            {
                gold = value;
            }
        }

        public static int BossHealth
        {
            get
            {
                return bossHealth;
            }

            set
            {
                bossHealth = value;
            }
        }

        public static int PlayerDmg
        {
            get
            {
                return playerDmg;
            }

            set
            {
                playerDmg = value;
            }
        }

        public static int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public static int SwordmanCost
        {
            get
            {
                return swordmanCost;
            }

            set
            {
                swordmanCost = value;
            }
        }

        public static int ArcherCost
        {
            get
            {
                return archerCost;
            }

            set
            {
                archerCost = value;
            }
        }

        public static int KnightCost
        {
            get
            {
                return knightCost;
            }

            set
            {
                knightCost = value;
            }
        }

        public static int WeaponCost
        {
            get
            {
                return weaponCost;
            }

            set
            {
                weaponCost = value;
            }
        }

        public static int KnightCount
        {
            get
            {
                return knightCount;
            }

            set
            {
                knightCount = value;
            }
        }

        public static int ArcherCount
        {
            get
            {
                return archerCount;
            }

            set
            {
                archerCount = value;
            }
        }

        public static int SwordmanCount
        {
            get
            {
                return swordmanCount;
            }

            set
            {
                swordmanCount = value;
            }
        }
        #endregion
        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.displayRectangle = displayRectangle;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
            gameObj = new List<GameObject>();
            SetupWorld();
        }
        public void SetupWorld()
        {
            Swordman.maxdmg.Release(5);
        }
        public void GameLoop()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan deltaTime = startTime - endTime;
            int milliSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            currentFps = 1000 / milliSeconds;
            endTime = DateTime.Now;
            if (ToRemove.Count >= 1)
            {

                foreach (GameObject go in ToRemove)
                {
                    gameObj.Remove(go);
                }
            }
            ToRemove.Clear();
            gameObj.AddRange(toAdd);
            toAdd.Clear();
            if (bossHealth <= 0)
            {
                FinishedLevel();
            }
            GameDone(dc);
            UpdateAnimations(currentFps);
            Update(currentFps);
            Draw();
            
        }
        private void Update(float fps)
        {
            this.currentFps = fps;
            endTime = DateTime.Now;

            foreach (GameObject go in gameObj)
            {
                go.Update(fps);
            }


        }
        private void UpdateAnimations(float fps)
        {
            foreach (GameObject go in gameObj)
            {
                go.UpdateAnimation(fps);
            }

        }
        private void Draw()
        {
            dc.Clear(Color.White);

            foreach (GameObject go in gameObj)
            {
                go.Draw(dc);
            }

            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("Boss Health: {0}", bossHealth), f, Brushes.Black, 350, 10);
            dc.DrawString(string.Format("Gold: {0}", gold), f, Brushes.Black, 120, 10);
            dc.DrawString(string.Format("Level: {0}", Level), f, Brushes.Black, 10, 10);
            dc.DrawString(string.Format("Player Dmg: {0}", playerDmg), f, Brushes.Black, 600, 10);
            dc.DrawString(string.Format("Cost: {0} Count: {1}", swordmanCost, swordmanCount), f, Brushes.Black, 86, 50);
            dc.DrawString(string.Format("Cost: {0} Count: {1}", archerCost, archerCount), f, Brushes.Black, 86, 160);
            dc.DrawString(string.Format("Cost: {0} Count: {1}", knightCost, knightCount), f, Brushes.Black, 120, 270);
            dc.DrawString(string.Format("Cost: {0}", weaponCost), f, Brushes.Black, 120, 385);



#if DEBUG
            dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 600, 300);
#endif 
            backBuffer.Render();
        }
        private static void FinishedLevel()
        {
            gold += fixedHealth;
            fixedHealth *= 2;
            bossHealth = 0;
            Level++;
            BossHealth += fixedHealth;
        }
        private void GameDone(Graphics dc)
        {
            if (bossHealth >= 2000000000)
            {
                gameObj.Clear();
                PlayerDmg = 0;
                Gold = 0;
            }
        }
    }
}
