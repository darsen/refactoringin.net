namespace RentAWheel
{
    partial class VehicleCategoriesMaintenance
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
            this.monthlyPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.weeklyPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dailyPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthlyPrice
            // 
            this.monthlyPrice.Location = new System.Drawing.Point(9, 233);
            this.monthlyPrice.Name = "monthlyPrice";
            this.monthlyPrice.Size = new System.Drawing.Size(140, 20);
            this.monthlyPrice.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Monthly Price:";
            // 
            // weeklyPrice
            // 
            this.weeklyPrice.Location = new System.Drawing.Point(9, 181);
            this.weeklyPrice.Name = "weeklyPrice";
            this.weeklyPrice.Size = new System.Drawing.Size(140, 20);
            this.weeklyPrice.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Weekly Price:";
            // 
            // dailyPrice
            // 
            this.dailyPrice.Location = new System.Drawing.Point(10, 129);
            this.dailyPrice.Name = "dailyPrice";
            this.dailyPrice.Size = new System.Drawing.Size(140, 20);
            this.dailyPrice.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Daily Price:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(11, 77);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(140, 20);
            this.name.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Category Name:";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(12, 25);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(139, 20);
            this.id.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "CategoryId:";
            // 
            // VehicleCategoriesMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 311);
            this.Controls.Add(this.monthlyPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.weeklyPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dailyPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label1);
            this.Name = "VehicleCategoriesMaintenance";
            this.Text = "Categories";
            this.Load += new System.EventHandler(this.VehicleCategoriesMaintenance_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.id, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.name, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dailyPrice, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.weeklyPrice, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.monthlyPrice, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox monthlyPrice;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox weeklyPrice;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox dailyPrice;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox name;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox id;
        internal System.Windows.Forms.Label label1;
    }
}