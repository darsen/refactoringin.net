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
            this.reload = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.newVehicle = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.licensePlate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // reload
            // 
            this.reload.Location = new System.Drawing.Point(195, 134);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(62, 31);
            this.reload.TabIndex = 37;
            this.reload.Text = "Reload";
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(195, 97);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(62, 31);
            this.delete.TabIndex = 36;
            this.delete.Text = "Delete";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(195, 60);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(62, 31);
            this.save.TabIndex = 35;
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // newVehicle
            // 
            this.newVehicle.Location = new System.Drawing.Point(195, 25);
            this.newVehicle.Name = "newVehicle";
            this.newVehicle.Size = new System.Drawing.Size(62, 31);
            this.newVehicle.TabIndex = 34;
            this.newVehicle.Text = "New";
            this.newVehicle.Click += new System.EventHandler(this.new_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(124, 167);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 24);
            this.btnLast.TabIndex = 33;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.last_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(86, 167);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(30, 24);
            this.btnRight.TabIndex = 32;
            this.btnRight.Text = ">";
            this.btnRight.Click += new System.EventHandler(this.right_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(50, 167);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(30, 24);
            this.btnLeft.TabIndex = 31;
            this.btnLeft.Text = "<";
            this.btnLeft.Click += new System.EventHandler(this.left_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(14, 167);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 24);
            this.btnFirst.TabIndex = 30;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.first_Click);
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
            // FleetMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 212);
            this.Controls.Add(this.model);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.branch);
            this.Controls.Add(this.reload);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.save);
            this.Controls.Add(this.newVehicle);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.licensePlate);
            this.Controls.Add(this.label1);
            this.Name = "FleetMaintenance";
            this.Text = "Vehicles";
            this.Load += new System.EventHandler(this.FleetMaintenance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox model;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox branch;
        internal System.Windows.Forms.Button reload;
        internal System.Windows.Forms.Button delete;
        internal System.Windows.Forms.Button save;
        internal System.Windows.Forms.Button newVehicle;
        internal System.Windows.Forms.Button btnLast;
        internal System.Windows.Forms.Button btnRight;
        internal System.Windows.Forms.Button btnLeft;
        internal System.Windows.Forms.Button btnFirst;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox licensePlate;
        internal System.Windows.Forms.Label label1;
    }
}