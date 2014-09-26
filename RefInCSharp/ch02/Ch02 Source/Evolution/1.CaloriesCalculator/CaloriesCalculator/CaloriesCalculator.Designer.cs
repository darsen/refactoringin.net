namespace CaloriesCalculator
{
    partial class CaloriesCalculator
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInches = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtFeet = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "ft";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(300, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "cal";
            // 
            // txtCalories
            // 
            this.txtCalories.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCalories.Location = new System.Drawing.Point(180, 181);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.ReadOnly = true;
            this.txtCalories.Size = new System.Drawing.Size(120, 20);
            this.txtCalories.TabIndex = 11;
            this.txtCalories.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(180, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recommended Daily Amount:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Weight";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Height";
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.Checked = true;
            this.rbtnFemale.Location = new System.Drawing.Point(69, 16);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(104, 24);
            this.rbtnFemale.TabIndex = 6;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Female";
            // 
            // rbtnMale
            // 
            this.rbtnMale.Location = new System.Drawing.Point(8, 16);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(104, 24);
            this.rbtnMale.TabIndex = 1;
            this.rbtnMale.Text = "Male";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtInches);
            this.groupBox1.Controls.Add(this.btnCalculate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Label8);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCalories);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbtnFemale);
            this.groupBox1.Controls.Add(this.rbtnMale);
            this.groupBox1.Controls.Add(this.txtFeet);
            this.groupBox1.Controls.Add(this.txtWeight);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 224);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "in";
            // 
            // txtInches
            // 
            this.txtInches.Location = new System.Drawing.Point(80, 72);
            this.txtInches.Name = "txtInches";
            this.txtInches.Size = new System.Drawing.Size(44, 20);
            this.txtInches.TabIndex = 13;
            this.txtInches.Text = "1";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(181, 69);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(119, 23);
            this.btnCalculate.TabIndex = 12;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(128, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "years";
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(8, 168);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(120, 16);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Age";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(8, 184);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(120, 20);
            this.txtAge.TabIndex = 9;
            this.txtAge.Text = "12";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(128, 136);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(24, 23);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "lbs";
            // 
            // txtFeet
            // 
            this.txtFeet.Location = new System.Drawing.Point(8, 72);
            this.txtFeet.Name = "txtFeet";
            this.txtFeet.Size = new System.Drawing.Size(44, 20);
            this.txtFeet.TabIndex = 7;
            this.txtFeet.Text = "5";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(8, 128);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(120, 20);
            this.txtWeight.TabIndex = 8;
            this.txtWeight.Text = "110";
            // 
            // CaloriesCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 250);
            this.Controls.Add(this.groupBox1);
            this.Name = "CaloriesCalculator";
            this.Text = "Calories Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtCalories;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RadioButton rbtnFemale;
        internal System.Windows.Forms.RadioButton rbtnMale;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtInches;
        internal System.Windows.Forms.Button btnCalculate;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtFeet;
        internal System.Windows.Forms.TextBox txtWeight;
    }
}

