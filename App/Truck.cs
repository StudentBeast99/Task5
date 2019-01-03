using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLib
{
    public class Truck
    {
        
        internal event Action<Truck> ReadyAction; 
        
        public int X { get; private set; }
        public int Y { get; private set; }
        public const int R = 15;
        
        public House Target { get; internal set; }

        public Truck(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal void TimeTick()
        {
            if (Target == null)
                return;
            if (Math.Abs(Target.X - X) < House.R && Math.Abs(Target.Y - Y) < House.R)
            {             
                
                Target.Resources += 100;
                Target = null;
                ReadyAction.Invoke(this);
            }
            else
                Move();
        }
        
        private void Move()
        {
            int Speed = 3;
            if (X <= Target.X - House.R)
            {
                X += Speed;
                return;
            }
            if (X >= Target.X + House.R)
            {
                X -= Speed;
                return;
            }
            if (Y <= Target.Y - House.R)
            {
                Y += Speed;
                return;
            }
            if (Y >= Target.Y + House.R)
            {
                Y -= Speed;
                return;
            }
        }

        
    }
}
