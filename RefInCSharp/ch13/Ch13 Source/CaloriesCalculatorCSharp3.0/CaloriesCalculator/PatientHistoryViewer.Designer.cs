namespace CaloriesCalculator
{
    partial class PatientHistoryViewer
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.txtSSNThirdPart = new System.Windows.Forms.TextBox();
            this.txtSSNSecondPart = new System.Windows.Forms.TextBox();
            this.txtSSNFirstPart = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.DataMember = "Measurements";
            this.grid.Location = new System.Drawing.Point(23, 62);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(726, 377);
            this.grid.TabIndex = 0;
            // 
            // txtSSNThirdPart
            // 
            this.txtSSNThirdPart.Location = new System.Drawing.Point(90, 25);
            this.txtSSNThirdPart.MaxLength = 4;
            this.txtSSNThirdPart.Name = "txtSSNThirdPart";
            this.txtSSNThirdPart.ReadOnly = true;
            this.txtSSNThirdPart.Size = new System.Drawing.Size(39, 20);
            this.txtSSNThirdPart.TabIndex = 7;
            // 
            // txtSSNSecondPart
            // 
            this.txtSSNSecondPart.Location = new System.Drawing.Point(60, 25);
            this.txtSSNSecondPart.MaxLength = 2;
            this.txtSSNSecondPart.Name = "txtSSNSecondPart";
            this.txtSSNSecondPart.ReadOnly = true;
            this.txtSSNSecondPart.Size = new System.Drawing.Size(24, 20);
            this.txtSSNSecondPart.TabIndex = 6;
            // 
            // txtSSNFirstPart
            // 
            this.txtSSNFirstPart.Location = new System.Drawing.Point(23, 25);
            this.txtSSNFirstPart.MaxLength = 3;
            this.txtSSNFirstPart.Name = "txtSSNFirstPart";
            this.txtSSNFirstPart.ReadOnly = true;
            this.txtSSNFirstPart.Size = new System.Drawing.Size(31, 20);
            this.txtSSNFirstPart.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "SSN";
            // 
            // PatientHistoryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 451);
            this.Controls.Add(this.txtSSNThirdPart);
            this.Controls.Add(this.txtSSNSecondPart);
            this.Controls.Add(this.txtSSNFirstPart);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.grid);
            this.Name = "PatientHistoryViewer";
            this.Text = "Patient History";
            this.Load += new System.EventHandler(this.PatientHistoryViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        public System.Windows.Forms.TextBox txtSSNThirdPart;
        public System.Windows.Forms.TextBox txtSSNSecondPart;
        public System.Windows.Forms.TextBox txtSSNFirstPart;
        private System.Windows.Forms.Label label12;

    }
}