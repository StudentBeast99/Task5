using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuilderLib;
using BuildDraw;

namespace App
{
    public partial class Task5 : Form
    {
        public Task5()
        {
            InitializeComponent();
        }

        Draw Draw;
        Area Area;

        private void MainForm_Load(object sender, EventArgs e)
        {
            Area = new Area(Output.Width, Output.Height);
            Draw = new Draw(Area);
            UpdPicter.Start();
            TimeTick.Start();
        }

        private void UpdPicter_Tick(object sender, EventArgs e)
        {
            Output.Image = Draw.GetImage();
        }

        private void TimeTick_Tick(object sender, EventArgs e)
        {
            Area.TimeTick();
        }

        private void Output_MouseDown(object sender, MouseEventArgs e)
        {
            if(HouseBtn.Checked)
                Area.AddHouse(e.X, e.Y);
            if(BuilderBtn.Checked)
                Area.AddBuilder(e.X, e.Y);
            if(roofBuilderBtn.Checked)
                Area.AddRoofBuilder(e.X, e.Y);
            if (TruckBtn.Checked)
                Area.AddTruck(e.X, e.Y);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Area = new Area(Output.Width, Output.Height);
            Draw = new Draw(Area);
        }
    }
}
