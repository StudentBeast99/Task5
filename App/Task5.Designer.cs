namespace App
{
    partial class Task5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Output = new System.Windows.Forms.PictureBox();
            this.HouseBtn = new System.Windows.Forms.RadioButton();
            this.BuilderBtn = new System.Windows.Forms.RadioButton();
            this.TruckBtn = new System.Windows.Forms.RadioButton();
            this.roofBuilderBtn = new System.Windows.Forms.RadioButton();
            this.UpdPicter = new System.Windows.Forms.Timer(this.components);
            this.TimeTick = new System.Windows.Forms.Timer(this.components);
            this.ClearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Output)).BeginInit();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(13, 13);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(644, 425);
            this.Output.TabIndex = 0;
            this.Output.TabStop = false;
            this.Output.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Output_MouseDown);
            // 
            // HouseBtn
            // 
            this.HouseBtn.AutoSize = true;
            this.HouseBtn.Checked = true;
            this.HouseBtn.Location = new System.Drawing.Point(664, 13);
            this.HouseBtn.Name = "HouseBtn";
            this.HouseBtn.Size = new System.Drawing.Size(56, 17);
            this.HouseBtn.TabIndex = 1;
            this.HouseBtn.TabStop = true;
            this.HouseBtn.Text = "House";
            this.HouseBtn.UseVisualStyleBackColor = true;
            // 
            // BuilderBtn
            // 
            this.BuilderBtn.AutoSize = true;
            this.BuilderBtn.Location = new System.Drawing.Point(664, 36);
            this.BuilderBtn.Name = "BuilderBtn";
            this.BuilderBtn.Size = new System.Drawing.Size(57, 17);
            this.BuilderBtn.TabIndex = 2;
            this.BuilderBtn.Text = "Builder";
            this.BuilderBtn.UseVisualStyleBackColor = true;
            // 
            // TruckBtn
            // 
            this.TruckBtn.AutoSize = true;
            this.TruckBtn.Location = new System.Drawing.Point(664, 82);
            this.TruckBtn.Name = "TruckBtn";
            this.TruckBtn.Size = new System.Drawing.Size(53, 17);
            this.TruckBtn.TabIndex = 4;
            this.TruckBtn.Text = "Truck";
            this.TruckBtn.UseVisualStyleBackColor = true;
            // 
            // roofBuilderBtn
            // 
            this.roofBuilderBtn.AutoSize = true;
            this.roofBuilderBtn.Location = new System.Drawing.Point(664, 59);
            this.roofBuilderBtn.Name = "roofBuilderBtn";
            this.roofBuilderBtn.Size = new System.Drawing.Size(83, 17);
            this.roofBuilderBtn.TabIndex = 3;
            this.roofBuilderBtn.Text = "Roof Builder";
            this.roofBuilderBtn.UseVisualStyleBackColor = true;
            // 
            // UpdPicter
            // 
            this.UpdPicter.Interval = 10;
            this.UpdPicter.Tick += new System.EventHandler(this.UpdPicter_Tick);
            // 
            // TimeTick
            // 
            this.TimeTick.Interval = 10;
            this.TimeTick.Tick += new System.EventHandler(this.TimeTick_Tick);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(664, 106);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn.TabIndex = 5;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // Task5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.TruckBtn);
            this.Controls.Add(this.roofBuilderBtn);
            this.Controls.Add(this.BuilderBtn);
            this.Controls.Add(this.HouseBtn);
            this.Controls.Add(this.Output);
            this.Name = "Task5";
            this.Text = "Task5";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Output)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Output;
        private System.Windows.Forms.RadioButton HouseBtn;
        private System.Windows.Forms.RadioButton BuilderBtn;
        private System.Windows.Forms.RadioButton TruckBtn;
        private System.Windows.Forms.RadioButton roofBuilderBtn;
        private System.Windows.Forms.Timer UpdPicter;
        private System.Windows.Forms.Timer TimeTick;
        private System.Windows.Forms.Button ClearBtn;
    }
}

