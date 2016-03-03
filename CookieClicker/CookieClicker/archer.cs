using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookieClicker
{
    class Archer : Unit
    {
        private static Form1 myForm;

        static Mutex handleDamage = new Mutex();
        Thread damage = new Thread(new ParameterizedThreadStart(Dps));
        public Archer(string imagePath, Vector2D startPosition, int dps, Form1 newForm) : base(imagePath, startPosition)
        {
            damage.Start(dps);
            myForm = newForm;

        }

        public static void Dps(object obj)
        {
            int dps = (int)obj;
            while (true)
            {
                handleDamage.WaitOne();
                GameWorld.BossHealth -= dps;
                myForm.AlternativeClick();
                handleDamage.ReleaseMutex();
                Thread.Sleep(1500);

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
