using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BuilderLib;

namespace BuildDraw
{
    public class Draw
    {
        Bitmap Image;
        Graphics g;

        public Area Area { get; set; }

        public Draw(Area area)
        {
            Area = area;
        } 

        private void DrawHouse(House house)
        {
            g.DrawRectangle(Pens.Black, house.X - House.R, house.Y - House.R, 2 * House.R, 2 * House.R);
            g.FillRectangle(Brushes.Red, house.X - House.R, house.Y - House.R, 2 * House.R, 2 * House.R * house.ReadyVal / 1000);
            
        }

        private void DrawBuilder(Builder builder)
        {
            Brush brush = Brushes.Green;
            if (builder is RoofBuilder)
                brush = Brushes.Yellow;
            g.FillEllipse(brush, builder.X - Builder.R, builder.Y - Builder.R, 2 * Builder.R, 2 * Builder.R);
        }

        private void DrawTruck(Truck truck)
        {
            g.FillEllipse(Brushes.Blue, truck.X - Truck.R, truck.Y - Truck.R/2, 2 * Truck.R, Truck.R);
        }

        public Bitmap GetImage()
        {            
            Image = new Bitmap(Area.Width, Area.Height);
            g = Graphics.FromImage(Image);
            List<House> houses = new List<House>(Area.Houses);
            foreach (var item in houses)
            {
                DrawHouse(item);
            }
            List<Builder> builders = new List<Builder>(Area.Builders);
            builders.AddRange(Area.RoofBuilders);
            foreach (var item in builders)
            {
                DrawBuilder(item);
            }
            List<Truck> trucks = new List<Truck>(Area.Trucks);
            foreach (var item in trucks)
            {
                DrawTruck(item);
            }
            return Image;
        }

       
    }
}
