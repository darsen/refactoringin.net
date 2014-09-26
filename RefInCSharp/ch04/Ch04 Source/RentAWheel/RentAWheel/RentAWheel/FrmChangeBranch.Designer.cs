namespace RentAWheel
{
    partial class FrmChangeBranch
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
            this.txtCurrentBranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChangeBranch = new System.Windows.Forms.Button();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCurrentBranch
            // 
            this.txtCurrentBranch.Location = new System.Drawing.Point(200, 25);
            this.txtCurrentBranch.Name = "txtCurrentBranch";
            this.txtCurrentBranch.ReadOnly = true;
            this.txtCurrentBranch.Size = new System.Drawing.Size(138, 20);
            this.txtCurrentBranch.TabIndex = 35;
            this.txtCurrentBranch.TextChanged += new System.EventHandler(this.TxtCurrentBranch_TextChanged);
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
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChangeBranch
            // 
            this.btnChangeBranch.Location = new System.Drawing.Point(380, 25);
            this.btnChangeBranch.Name = "btnChangeBranch";
            this.btnChangeBranch.Size = new System.Drawing.Size(85, 32);
            this.btnChangeBranch.TabIndex = 32;
            this.btnChangeBranch.Text = "Change Branch";
            this.btnChangeBranch.Click += new System.EventHandler(this.btnChangeBranch_Click);
            // 
            // cboBranch
            // 
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(13, 88);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(142, 21);
            this.cboBranch.TabIndex = 31;
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
            // txtLP
            // 
            this.txtLP.Location = new System.Drawing.Point(13, 25);
            this.txtLP.Name = "txtLP";
            this.txtLP.ReadOnly = true;
            this.txtLP.Size = new System.Drawing.Size(138, 20);
            this.txtLP.TabIndex = 29;
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
            // FrmChangeBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 126);
            this.Controls.Add(this.txtCurrentBranch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangeBranch);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLP);
            this.Controls.Add(this.label4);
            this.Name = "FrmChangeBranch";
            this.Text = "Change Branch";
            this.Load += new System.EventHandler(this.FrmChangeBranch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCurrentBranch;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnChangeBranch;
        internal System.Windows.Forms.ComboBox cboBranch;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtLP;
        internal System.Windows.Forms.Label label4;
    }
}