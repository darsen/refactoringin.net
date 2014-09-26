namespace RentAWheel
{
    partial class FleetMaintenance
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
            this.model = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.branch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.licensePlate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.mileage = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.tankLevel = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // model
            // 
            this.model.FormattingEnabled = true;
            this.model.Location = new System.Drawing.Point(14, 124);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(142, 21);
            this.model.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Model:";
            // 
            // branch
            // 
            this.branch.FormattingEnabled = true;
            this.branch.Location = new System.Drawing.Point(13, 76);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(142, 21);
            this.branch.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Branch:";
            // 
            // licensePlate
            // 
            this.licensePlate.Location = new System.Drawing.Point(12, 25);
            this.licensePlate.Name = "licensePlate";
            this.licensePlate.Size = new System.Drawing.Size(143, 20);
            this.licensePlate.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Vehicle License Plate:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(11, 197);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(44, 13);
            this.Label5.TabIndex = 45;
            this.Label5.Text = "Mileage";
            // 
            // mileage
            // 
            this.mileage.Location = new System.Drawing.Point(13, 213);
            this.mileage.Name = "mileage";
            this.mileage.Size = new System.Drawing.Size(141, 20);
            this.mileage.TabIndex = 44;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(11, 152);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 13);
            this.Label4.TabIndex = 43;
            this.Label4.Text = "Tank Level:";
            // 
            // tankLevel
            // 
            this.tankLevel.FormattingEnabled = true;
            this.tankLevel.Location = new System.Drawing.Point(13, 168);
            this.tankLevel.Name = "tankLevel";
            this.tankLevel.Size = new System.Drawing.Size(141, 21);
            this.tankLevel.TabIndex = 42;
            // 
            // FleetMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 309);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.mileage);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.tankLevel);
            this.Controls.Add(this.model);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.branch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.licensePlate);
            this.Controls.Add(this.label1);
            this.Name = "FleetMaintenance";
            this.Text = "Vehicles";
            this.Load += new System.EventHandler(this.FleetMaintenance_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.licensePlate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.branch, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.model, 0);
            this.Controls.SetChildIndex(this.tankLevel, 0);
            this.Controls.SetChildIndex(this.Label4, 0);
            this.Controls.SetChildIndex(this.mileage, 0);
            this.Controls.SetChildIndex(this.Label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox model;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox branch;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox licensePlate;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox mileage;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox tankLevel;
    }
}