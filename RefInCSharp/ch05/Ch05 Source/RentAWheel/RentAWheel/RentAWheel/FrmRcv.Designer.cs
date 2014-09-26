namespace RentAWheel
{
    partial class FrmRcv
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.cboTank = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(423, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(423, 18);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(85, 32);
            this.btnReceive.TabIndex = 24;
            this.btnReceive.Text = "Receive";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // cboTank
            // 
            this.cboTank.FormattingEnabled = true;
            this.cboTank.Items.AddRange(new object[] {
            "Full",
            "3/4",
            "1/2",
            "1/4",
            "Empty"});
            this.cboTank.Location = new System.Drawing.Point(203, 77);
            this.cboTank.Name = "cboTank";
            this.cboTank.Size = new System.Drawing.Size(142, 21);
            this.cboTank.TabIndex = 23;
            this.cboTank.Text = "Full";
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
            // txtMileage
            // 
            this.txtMileage.Location = new System.Drawing.Point(13, 77);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(138, 20);
            this.txtMileage.TabIndex = 21;
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
            // txtLP
            // 
            this.txtLP.Location = new System.Drawing.Point(13, 25);
            this.txtLP.Name = "txtLP";
            this.txtLP.ReadOnly = true;
            this.txtLP.Size = new System.Drawing.Size(138, 20);
            this.txtLP.TabIndex = 19;
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
            // FrmRcv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 118);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.cboTank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMileage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLP);
            this.Controls.Add(this.label4);
            this.Name = "FrmRcv";
            this.Text = "Receive Vehicle";
            this.Load += new System.EventHandler(this.FrmRcv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnReceive;
        internal System.Windows.Forms.ComboBox cboTank;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtMileage;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtLP;
        internal System.Windows.Forms.Label label4;
    }
}