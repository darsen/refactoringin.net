namespace RentAWheel
{
    partial class BranchMaintenance
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
            this.id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.reload = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.newBranch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(12, 25);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(143, 20);
            this.id.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Branch Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Branch Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(12, 68);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(143, 20);
            this.name.TabIndex = 2;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(128, 141);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 24);
            this.btnLast.TabIndex = 11;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.last_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(90, 141);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(30, 24);
            this.btnRight.TabIndex = 10;
            this.btnRight.Text = ">";
            this.btnRight.Click += new System.EventHandler(this.right_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(54, 141);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(30, 24);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "<";
            this.btnLeft.Click += new System.EventHandler(this.left_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(18, 141);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 24);
            this.btnFirst.TabIndex = 8;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.first_Click);
            // 
            // reload
            // 
            this.reload.Location = new System.Drawing.Point(192, 134);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(62, 31);
            this.reload.TabIndex = 15;
            this.reload.Text = "Reload";
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(192, 97);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(62, 31);
            this.delete.TabIndex = 14;
            this.delete.Text = "Delete";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(192, 60);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(62, 31);
            this.save.TabIndex = 13;
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // newBranch
            // 
            this.newBranch.Location = new System.Drawing.Point(192, 25);
            this.newBranch.Name = "newBranch";
            this.newBranch.Size = new System.Drawing.Size(62, 31);
            this.newBranch.TabIndex = 12;
            this.newBranch.Text = "New";
            this.newBranch.Click += new System.EventHandler(this.new_Click);
            // 
            // BranchMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 180);
            this.Controls.Add(this.reload);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.save);
            this.Controls.Add(this.newBranch);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id);
            this.Name = "BranchMaintenance";
            this.Text = "Branches";
            this.Load += new System.EventHandler(this.BranchMaintenance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        internal System.Windows.Forms.Button btnLast;
        internal System.Windows.Forms.Button btnRight;
        internal System.Windows.Forms.Button btnLeft;
        internal System.Windows.Forms.Button btnFirst;
        internal System.Windows.Forms.Button reload;
        internal System.Windows.Forms.Button delete;
        internal System.Windows.Forms.Button save;
        internal System.Windows.Forms.Button newBranch;
    }
}