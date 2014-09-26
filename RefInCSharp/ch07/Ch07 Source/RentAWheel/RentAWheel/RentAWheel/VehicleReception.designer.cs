namespace RentAWheel
{
    partial class VehicleReception
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
            this.cancel = new System.Windows.Forms.Button();
            this.receive = new System.Windows.Forms.Button();
            this.tank = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mileage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.licensePlate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(423, 72);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(85, 32);
            this.cancel.TabIndex = 25;
            this.cancel.Text = "Cancel";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // receive
            // 
            this.receive.Location = new System.Drawing.Point(423, 18);
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(85, 32);
            this.receive.TabIndex = 24;
            this.receive.Text = "Receive";
            this.receive.Click += new System.EventHandler(this.receive_Click);
            // 
            // tank
            // 
            this.tank.FormattingEnabled = true;
            this.tank.Items.AddRange(new object[] {
            "Full",
            "3/4",
            "1/2",
            "1/4",
            "Empty"});
            this.tank.Location = new System.Drawing.Point(203, 77);
            this.tank.Name = "tank";
            this.tank.Size = new System.Drawing.Size(142, 21);
            this.tank.TabIndex = 23;
            this.tank.Text = "Full";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tank";
            // 
            // mileage
            // 
            this.mileage.Location = new System.Drawing.Point(13, 77);
            this.mileage.Name = "mileage";
            this.mileage.Size = new System.Drawing.Size(138, 20);
            this.mileage.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mileage";
            // 
            // licensePlate
            // 
            this.licensePlate.Location = new System.Drawing.Point(13, 25);
            this.licensePlate.Name = "licensePlate";
            this.licensePlate.ReadOnly = true;
            this.licensePlate.Size = new System.Drawing.Size(138, 20);
            this.licensePlate.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Vehicle License Plate:";
            // 
            // VehicleReception
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 118);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.receive);
            this.Controls.Add(this.tank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mileage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.licensePlate);
            this.Controls.Add(this.label4);
            this.Name = "VehicleReception";
            this.Text = "Receive Vehicle";
            this.Load += new System.EventHandler(this.VehicleReception_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cancel;
        internal System.Windows.Forms.Button receive;
        internal System.Windows.Forms.ComboBox tank;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox mileage;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox licensePlate;
        internal System.Windows.Forms.Label label4;
    }
}