using System;
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
        private int cost;

        public Unit(string imagePath, Vector2D startPosition, int dps, int cost) : base (imagePath, startPosition)
        {
            this.dps = dps;
            this.cost = cost;
        }
        public static void Cost(int cost)
        {
            GameWorld.Gold -= cost;
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
