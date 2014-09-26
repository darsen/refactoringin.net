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
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
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
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(195, 134);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(62, 31);
            this.btnReload.TabIndex = 41;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.reload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(195, 97);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 31);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.delete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(195, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 31);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.save_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(195, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(62, 31);
            this.btnNew.TabIndex = 38;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.new_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(120, 274);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 24);
            this.btnLast.TabIndex = 37;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.last_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(82, 274);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(30, 24);
            this.btnRight.TabIndex = 36;
            this.btnRight.Text = ">";
            this.btnRight.Click += new System.EventHandler(this.right_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(46, 274);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(30, 24);
            this.btnLeft.TabIndex = 35;
            this.btnLeft.Text = "<";
            this.btnLeft.Click += new System.EventHandler(this.left_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(10, 274);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 24);
            this.btnFirst.TabIndex = 34;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.first_Click);
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
            this.ClientSize = new System.Drawing.Size(277, 315);
            this.Controls.Add(this.monthlyPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.weeklyPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dailyPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label1);
            this.Name = "VehicleCategoriesMaintenance";
            this.Text = "Categories";
            this.Load += new System.EventHandler(this.VehicleCategoriesMaintenance_Load);
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
        internal System.Windows.Forms.Button btnReload;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnLast;
        internal System.Windows.Forms.Button btnRight;
        internal System.Windows.Forms.Button btnLeft;
        internal System.Windows.Forms.Button btnFirst;
        internal System.Windows.Forms.TextBox name;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox id;
        internal System.Windows.Forms.Label label1;
    }
}