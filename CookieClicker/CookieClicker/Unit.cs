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
        Thread damage = new Thread(new ParameterizedThreadStart(Dps));

<<<<<<< HEAD
        public Unit(string imagePath, Vector2D startPosition, int dps) : base(imagePath, startPosition)
        {
            this.dps = dps;
            damage.Start(dps);
=======
        public Unit(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        { }
        public static void Cost(int cost)
        {
            GameWorld.Gold -= cost;
>>>>>>> 7e9304ec4524280010d8136f44a7422d81333cc8
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
