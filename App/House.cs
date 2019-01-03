using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLib
{
    public class House
    {
        public event Action<House> EndBuild; //событие вызывается когда строительство закончилось 
        public event Action<House> NeedRoof; //событие вызывается когда нужны рабочие для укладки крыши 
        public event Action<House> NeedBuild; //собтие вызывается когда нужны рабочие для стройки
        public event Action<House> NeedResources; //событие вызывается когда нужна техника для ресурсов
        
        public int X { get; private set; }
        public int Y { get; private set; }
        public const int R = 25; 
        internal int state = 0; //состояние -1 - нет ресурсов, 0 - стройка, 1 - укладка крыши, 2 - закончено
        public int ReadyVal { get; internal set; }
        public int Resources { get; internal set; }

        internal House(int x, int y)
        {
            X = x;
            Y = y;
            ReadyVal = 0;
            Resources = 0;
        }

        object locker = new object();

        internal List<Builder> builders = new List<Builder>();

        internal void TimeTick()
        {
            if(ReadyVal >= 1000 && state == 1)
            {
                //готово
                state = 2;
                EndBuild.Invoke(this);
                return;
            }

            else if (ReadyVal >= 900 && state == 0)
            {
                //нужно класть крышу
                state = 1;
                NeedRoof.Invoke(this);
            }

            else if (ReadyVal < 1000 && Resources <= 0 && state!= -1)
            {
                //закончились ресурсы
                state = -1;
                NeedResources.Invoke(this);
            }

            else if (state == -1 && Resources > 0)
            {
                //появились ресурсы 
                if(ReadyVal >= 900)
                {
                    state = 1;
                    NeedRoof.Invoke(this);
                }
                else
                {
                    state = 0;
                    NeedBuild.Invoke(this);
                }
            }
        }

        internal void Build()
        {
            //строительство и синхронизация 
            lock(locker)
            {
                if(Resources > 0)
                {
                    Resources--;
                    ReadyVal++;
                }
            }
        }
    }
}
