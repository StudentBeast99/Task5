using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLib
{
    public class Area
    {
        internal event Action TimeTickEvent;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<House> Houses { get; private set; } = new List<House>(); 
        public List<Builder> Builders { get; private set; } = new List<Builder>();
        public List<RoofBuilder> RoofBuilders { get; private set; } = new List<RoofBuilder>();
        public List<Truck> Trucks { get; private set; } = new List<Truck>();

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
        }

        

        public void AddHouse(int x, int y)
        {
            for (int i = 0; i < Houses.Count; i++)
            {
                if (Math.Abs(Houses[i].X - x) < House.R * 2 && Math.Abs(Houses[i].Y - y) < House.R * 2)
                    return;
            }
            
            
            House house = new House(x, y);
            TimeTickEvent += house.TimeTick;
            house.EndBuild += EndBuild;
            house.NeedBuild += NeedBuild;
            house.NeedRoof += NeedRoof;
            house.NeedResources += NeedResources;
            Houses.Add(house);
            NeedBuild(house);
        }

        public void AddBuilder(int x, int y)
        {
            
            Builder builder = new Builder(x, y);
            TimeTickEvent += builder.TimeTick;
            Builders.Add(builder);
            SearchJob(builder);
        }

        public void AddRoofBuilder(int x, int y)
        {
            
            RoofBuilder roofBuilder = new RoofBuilder(x, y);
            TimeTickEvent += roofBuilder.TimeTick;
            RoofBuilders.Add(roofBuilder);
            SearchJob(roofBuilder);
        }

        public void AddTruck(int x, int y)
        {
            
            Truck truck = new Truck(x, y);
            TimeTickEvent += truck.TimeTick;
            truck.ReadyAction += TruckFree;
            Trucks.Add(truck);
            TruckFree(truck);
        }

        private void SearchJob(Builder builder)
        {
            //поиск ближайшей работы для рабочего
            int state = 0;
            if (builder is RoofBuilder)
                state = 1;
            int Way = int.MaxValue;
            House house = null;
            for (int i = 0; i < Houses.Count; i++)
            {
                if(Houses[i].builders.Count < 2 && Houses[i].state == state)
                {
                    int NewWay = Math.Abs(builder.X - Houses[i].X) + Math.Abs(builder.Y - Houses[i].Y);
                    if(NewWay < Way)
                    {
                        Way = NewWay;
                        house = Houses[i];
                    }
                }
            }
            if(house!= null)
            {
                house.builders.Add(builder);
                builder.AddTarget(house);
            }
        }

        
        private void EndBuild(House house)
        {
           
            for (int i = 0; i < house.builders.Count; i++)
            {
                house.builders[i].RemoveTarget();
                SearchJob(house.builders[i]);
            }
            house.builders.Clear();
        }
        private void NeedBuild(House house)
        {
            
            for (int tt = 0; tt < 2; tt++)
            {
                int Way = int.MaxValue;
                Builder builder = null;
                for (int i = 0; i < Builders.Count; i++)
                {
                    if(Builders[i].Target == null)
                    {
                        int NewWay = Math.Abs(Builders[i].X - house.X) + Math.Abs(Builders[i].Y - house.Y);
                        if (NewWay < Way)
                        {
                            Way = NewWay;
                            builder = Builders[i];
                        }
                    }
                }
                if (builder == null)
                    return;
                house.builders.Add(builder);
                builder.AddTarget(house);
            }
        }

        private void NeedRoof(House house)
        {
            
            for (int i = 0; i < house.builders.Count; i++)
            {
                house.builders[i].RemoveTarget();
                SearchJob(house.builders[i]);
            }
            house.builders.Clear();
            for (int tt = 0; tt < 2; tt++)
            {
                int Way = int.MaxValue;
                Builder builder = null;
                for (int i = 0; i < RoofBuilders.Count; i++)
                {
                    if (RoofBuilders[i].Target == null)
                    {
                        int NewWay = Math.Abs(RoofBuilders[i].X - house.X) + Math.Abs(RoofBuilders[i].Y - house.Y);
                        if (NewWay < Way)
                        {
                            Way = NewWay;
                            builder = RoofBuilders[i];
                        }
                    }
                }
                if (builder == null)
                    return;
                house.builders.Add(builder);
                builder.AddTarget(house);
            }
        }
        Queue<House> ResourcesQueue = new Queue<House>();

        private void TruckFree(Truck truck)
        {
            
            if (ResourcesQueue.Count != 0)
                truck.Target = ResourcesQueue.Dequeue();
        }
        private void NeedResources(House house)
        {
            
            for (int i = 0; i < house.builders.Count; i++)
            {
                house.builders[i].RemoveTarget();
                SearchJob(house.builders[i]);
            }
            house.builders.Clear();
            int Way = int.MaxValue;
            Truck truck = null;
            for (int i = 0; i < Trucks.Count; i++)
            {
                if (Trucks[i].Target == null)
                {
                    int NewWay = Math.Abs(Trucks[i].X - house.X) + Math.Abs(Trucks[i].Y - house.Y);
                    if (NewWay < Way)
                    {
                        Way = NewWay;
                        truck = Trucks[i];
                    }
                }
            }
            if (truck == null)
                ResourcesQueue.Enqueue(house);
            else
            truck.Target = house;
        }

        public void TimeTick()
        {
            if (TimeTickEvent != null)
            TimeTickEvent.Invoke();
        }


    }
}
