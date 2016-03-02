﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace CookieClicker
{

    class Unit : GameObject
    {
        private int dps;
        Thread damage = new Thread(new ParameterizedThreadStart(Dps));

        public Unit(string imagePath, Vector2D startPosition, int dps) : base(imagePath, startPosition)
        {
            this.dps = dps;
            damage.Start(dps);
        }
        public static void Dps(object obj)
        {
            int dps = (int)obj;
            while (true)
            {

            GameWorld.BossHealth -= dps;
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
