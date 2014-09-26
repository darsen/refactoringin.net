namespace RentAWheel
{
    partial class VehicleRental
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
            this.documentType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.licensePlate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.rent = new System.Windows.Forms.Button();
            this.documentNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // documentType
            // 
            this.documentType.Location = new System.Drawing.Point(13, 77);
            this.documentType.Name = "documentType";
            this.documentType.Size = new System.Drawing.Size(138, 20);
            this.documentType.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Document Type:";
            // 
            // licensePlate
            // 
            this.licensePlate.Location = new System.Drawing.Point(13, 25);
            this.licensePlate.Name = "licensePlate";
            this.licensePlate.ReadOnly = true;
            this.licensePlate.Size = new System.Drawing.Size(138, 20);
            this.licensePlate.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Vehicle License Plate:";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(378, 124);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(85, 32);
            this.cancel.TabIndex = 19;
            this.cancel.Text = "Cancel";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // rent
            // 
            this.rent.Location = new System.Drawing.Point(378, 70);
            this.rent.Name = "rent";
            this.rent.Size = new System.Drawing.Size(85, 32);
            this.rent.TabIndex = 17;
            this.rent.Text = "Rent";
            this.rent.Click += new System.EventHandler(this.rent_Click);
            // 
            // documentNumber
            // 
            this.documentNumber.Location = new System.Drawing.Point(195, 77);
            this.documentNumber.Name = "documentNumber";
            this.documentNumber.Size = new System.Drawing.Size(138, 20);
            this.documentNumber.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Document Nº:";
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(195, 131);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(138, 20);
            this.lastName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Last Name";
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(13, 131);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(138, 20);
            this.firstName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "First Name";
            // 
            // VehicleRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 171);
            this.Controls.Add(this.documentType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.licensePlate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.rent);
            this.Controls.Add(this.documentNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.label1);
            this.Name = "VehicleRental";
            this.Text = "Rent Vehicle";
            this.Load += new System.EventHandler(this.VehicleRental_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox documentType;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox licensePlate;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button cancel;
        internal System.Windows.Forms.Button rent;
        internal System.Windows.Forms.TextBox documentNumber;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox lastName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox firstName;
        internal System.Windows.Forms.Label label1;
    }
}