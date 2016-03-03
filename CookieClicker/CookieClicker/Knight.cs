﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookieClicker
{
    class Knight : Unit
    {
        private int cost;
        private int dps;
        static Object thisLock = new Object();
        Thread damage = new Thread(new ParameterizedThreadStart(Dps));

        public Knight(string imagePath, Vector2D startPosition, int dps) : base(imagePath, startPosition)
        {
            this.dps = dps;
            damage.Start(dps);
        }
        public static void Dps(object obj)
        {
            int dps = (int)obj;
            while (true)
            {
                lock (thisLock)
                {
                GameWorld.BossHealth -= dps;

                }
                Thread.Sleep(500);
            }
        }
        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
        }

        public override void Update(float fps)
        {

            base.Update(fps);
        }
        public override void UpdateAnimation(float fps)
        {
            base.UpdateAnimation(fps);
        }
    }
}
