using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLib
{
    public class Builder
    {
        internal event Action BuildAction; 
        
        public int X { get; private set; }
        public int Y { get; private set; }
        public const int R = 10;
        public House Target { get; internal set; }

        public Builder(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal void TimeTick()
        {
            if (Target == null)
                return;
            if (Math.Abs(Target.X - X) < House.R && Math.Abs(Target.Y - Y) < House.R)
                Build();
            else
                Move();
        }
        
        internal void AddTarget(House house)
        {
            Target = house;
            BuildAction += house.Build;
        }

        internal void RemoveTarget()
        {
            BuildAction -= Target.Build;
            Target = null;
        }
        
        internal async void Build()
        {
            if (BuildAction != null)
                await Task.Run(BuildAction);
        }
        
        private void Move()
        {
            int Speed = 2;
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
