using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookieClicker
{
    class Swordman : Unit
    {
        
        Thread damage = new Thread(new ParameterizedThreadStart(Dps));
        public static Semaphore maxdmg = new Semaphore(0, 5);
        

        public Swordman(string imagePath, Vector2D startPosition, int dps) : base(imagePath, startPosition)
        {
            damage.Start(dps);
            
        }
        public static void Dps(object obj)
        {
            int dps = (int)obj;
            
            while (true)
            {
                maxdmg.WaitOne();
                GameWorld.BossHealth -= dps;
                maxdmg.Release();
                Thread.Sleep(1000);
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
