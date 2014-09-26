namespace RentAWheel
{
    partial class VehicleChangeBranch
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
            this.currentBranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.changeBranch = new System.Windows.Forms.Button();
            this.branch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.licensePlate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentBranch
            // 
            this.currentBranch.Location = new System.Drawing.Point(200, 25);
            this.currentBranch.Name = "currentBranch";
            this.currentBranch.ReadOnly = true;
            this.currentBranch.Size = new System.Drawing.Size(138, 20);
            this.currentBranch.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Current Branch:";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(380, 79);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(85, 32);
            this.cancel.TabIndex = 33;
            this.cancel.Text = "Cancel";
            // 
            // changeBranch
            // 
            this.changeBranch.Location = new System.Drawing.Point(380, 25);
            this.changeBranch.Name = "changeBranch";
            this.changeBranch.Size = new System.Drawing.Size(85, 38);
            this.changeBranch.TabIndex = 32;
            this.changeBranch.Text = "Change Branch";
            this.changeBranch.Click += new System.EventHandler(this.changeBranch_Click);
            // 
            // branch
            // 
            this.branch.FormattingEnabled = true;
            this.branch.Location = new System.Drawing.Point(13, 88);
            this.branch.Name = "branch";
            this.branch.Size = new System.Drawing.Size(142, 21);
            this.branch.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "New Branch:";
            // 
            // licensePlate
            // 
            this.licensePlate.Location = new System.Drawing.Point(13, 25);
            this.licensePlate.Name = "licensePlate";
            this.licensePlate.ReadOnly = true;
            this.licensePlate.Size = new System.Drawing.Size(138, 20);
            this.licensePlate.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Vehicle License Plate:";
            // 
            // VehicleChangeBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 126);
            this.Controls.Add(this.currentBranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.changeBranch);
            this.Controls.Add(this.branch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.licensePlate);
            this.Controls.Add(this.label4);
            this.Name = "VehicleChangeBranch";
            this.Text = "Change Branch";            
            this.Shown += new System.EventHandler(this.VehicleChangeBranch_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox currentBranch;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button cancel;
        internal System.Windows.Forms.Button changeBranch;
        internal System.Windows.Forms.ComboBox branch;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox licensePlate;
        internal System.Windows.Forms.Label label4;
    }
}