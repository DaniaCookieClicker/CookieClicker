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
        private static bool one = true;
        private static bool two = false;
        private static bool three = false;
        private static bool four = false;
        private static bool five = false;
        private static bool six = false;
        private static int bossHealth = 6;
        private static int playerDmg = 10;
        private static int gold = 0;
        private static List<GameObject> toRemove = new List<GameObject>();
        public static List<GameObject> toAdd = new List<GameObject>();
        private Graphics dc;
        private static List<GameObject> gameObj;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;
        private Rectangle displayRectangle;
        private Rectangle displayRect;
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
            if (toAdd.Count >= 1)
            {
                foreach (GameObject go in toAdd)
                {
                    GameObj.Add(go);
                }
            }
            Combat();
            GetGold();
            toAdd.Clear();
            UpdateAnimations(currentFps);
            Update(currentFps);
            Draw();
        }
        private void Update(float fps)
        {
            this.currentFps = fps;
            endTime = DateTime.Now;
            
            foreach  ( GameObject go in gameObj)
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
            dc.Clear(Color.Aqua);

            foreach (GameObject go in gameObj)
            {
                go.Draw(dc);
            }

            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("Boss Health: {0}", bossHealth), f, Brushes.Black, 200, 200);
            dc.DrawString(string.Format("Gold: {0}", gold), f, Brushes.Black, 200, 216);
#if DEBUG
            dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 100, 100);
#endif 
            backBuffer.Render();
        }
        private static void Combat()
        {
            if (BossHealth <= 0 && one)
            {
                BossHealth = 12;
                two = true;
                one = false;
            }
            if (BossHealth <= 0 && two)
            {
                BossHealth = 24;
                three = true;
                two = false;
            }
            if (BossHealth <= 0 && three)
            {
                BossHealth = 48;
                four = true;
                three = false;
            }
            if (BossHealth <= 0 && four)
            {
                BossHealth = 48 * 2;
                five = true;
                four = false;
            }
            if (BossHealth <= 0 && five)
            {
                BossHealth = 48 * 4;
                six = true;
                five = false;
            }
        }
        private static void GetGold()
        {
            int level = 1;
            if (one == true)
            {
                if (level == 1)
                {
                    gold += bossHealth;
                    level = 2;
                }
            }
            if (two == true)
            {
                if (level == 2)
                {
                    gold += bossHealth;
                    level = 3;
                }
            }
            if (three == true)
            {
                if (level == 3)
                {
                    gold += bossHealth;
                    level = 4;
                }
            }
            if (four == true)
            {
                if (level == 4)
                {
                    gold += bossHealth;
                    level = 5;
                }
            }
            if (five == true)
            {
                if (level == 5)
                {
                    gold += bossHealth;
                    level = 6;
                }
            }
            if (six == true)
            {
                if (level == 6)
                {
                    gold += bossHealth;
                    level = 7;
                }
            }
        }
    }
}
