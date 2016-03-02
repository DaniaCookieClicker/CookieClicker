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
        private static int level = 1;
        private static int bossHealth = 6;
        private static int fixedHealth = 6;
        private static int playerDmg = 5;
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
            gameObj.AddRange(toAdd);
            toAdd.Clear();
            GetGold();
            Combat();
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
            dc.Clear(Color.White);

            foreach (GameObject go in gameObj)
            {
                go.Draw(dc);
            }

            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("Boss Health: {0}", bossHealth), f, Brushes.Black, 350, 10);
            dc.DrawString(string.Format("Gold: {0}", gold), f, Brushes.Black, 120, 10);
            dc.DrawString(string.Format("Level: {0}", Level), f, Brushes.Black, 10, 10);
#if DEBUG
            dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 100, 100);
#endif 
            backBuffer.Render();
        }
        private static void Combat()
        {
            if (BossHealth <= 0)
            {
                bossHealth = 0;
                Level ++;
                BossHealth += fixedHealth * Level;
            }
        }
        private static void GetGold()
        {
            if (bossHealth <= 0)
            {
                    gold += fixedHealth * Level;
            }
        }
    }
}
