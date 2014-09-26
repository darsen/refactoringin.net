namespace RentAWheel
{
    partial class FrmFleetView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fleetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFromMaintenance = new System.Windows.Forms.Button();
            this.btnToMaintenance = new System.Windows.Forms.Button();
            this.btnChangeBranch = new System.Windows.Forms.Button();
            this.btnHandOver = new System.Windows.Forms.Button();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnCharge = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.dGridFleetView = new System.Windows.Forms.DataGridView();
            this.LicencePlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InOperation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DailyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeeklyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthlyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mileage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboOperational = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAvailable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridFleetView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(928, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.branchToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.modelToolStripMenuItem,
            this.fleetToolStripMenuItem});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.administrationToolStripMenuItem.Text = "Administration";
            // 
            // branchToolStripMenuItem
            // 
            this.branchToolStripMenuItem.Name = "branchToolStripMenuItem";
            this.branchToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.branchToolStripMenuItem.Text = "Branch";
            this.branchToolStripMenuItem.Click += new System.EventHandler(this.branchToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.categoriesToolStripMenuItem.Text = "Category";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // modelToolStripMenuItem
            // 
            this.modelToolStripMenuItem.Name = "modelToolStripMenuItem";
            this.modelToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.modelToolStripMenuItem.Text = "Model";
            this.modelToolStripMenuItem.Click += new System.EventHandler(this.modelToolStripMenuItem_Click);
            // 
            // fleetToolStripMenuItem
            // 
            this.fleetToolStripMenuItem.Name = "fleetToolStripMenuItem";
            this.fleetToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.fleetToolStripMenuItem.Text = "Fleet";
            this.fleetToolStripMenuItem.Click += new System.EventHandler(this.fleetToolStripMenuItem_Click);
            // 
            // btnFromMaintenance
            // 
            this.btnFromMaintenance.Location = new System.Drawing.Point(762, 383);
            this.btnFromMaintenance.Name = "btnFromMaintenance";
            this.btnFromMaintenance.Size = new System.Drawing.Size(84, 34);
            this.btnFromMaintenance.TabIndex = 27;
            this.btnFromMaintenance.Text = "From Maintenance";
            this.btnFromMaintenance.Click += new System.EventHandler(this.btnFromMaintenance_Click);
            // 
            // btnToMaintenance
            // 
            this.btnToMaintenance.Location = new System.Drawing.Point(762, 335);
            this.btnToMaintenance.Name = "btnToMaintenance";
            this.btnToMaintenance.Size = new System.Drawing.Size(84, 34);
            this.btnToMaintenance.TabIndex = 26;
            this.btnToMaintenance.Text = "To Maintenance";
            this.btnToMaintenance.Click += new System.EventHandler(this.btnToMaintenance_Click);
            // 
            // btnChangeBranch
            // 
            this.btnChangeBranch.Location = new System.Drawing.Point(762, 287);
            this.btnChangeBranch.Name = "btnChangeBranch";
            this.btnChangeBranch.Size = new System.Drawing.Size(84, 34);
            this.btnChangeBranch.TabIndex = 25;
            this.btnChangeBranch.Text = "Change branch";
            this.btnChangeBranch.Click += new System.EventHandler(this.btnChangeBranch_Click);
            // 
            // btnHandOver
            // 
            this.btnHandOver.Enabled = false;
            this.btnHandOver.Location = new System.Drawing.Point(762, 143);
            this.btnHandOver.Name = "btnHandOver";
            this.btnHandOver.Size = new System.Drawing.Size(84, 34);
            this.btnHandOver.TabIndex = 22;
            this.btnHandOver.Text = "Hand over";
            this.btnHandOver.Click += new System.EventHandler(this.btnHandOver_Click);
            // 
            // btnRent
            // 
            this.btnRent.Enabled = false;
            this.btnRent.Location = new System.Drawing.Point(762, 95);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(84, 34);
            this.btnRent.TabIndex = 21;
            this.btnRent.Text = "Rent";
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnCharge
            // 
            this.btnCharge.Enabled = false;
            this.btnCharge.Location = new System.Drawing.Point(762, 239);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size(84, 34);
            this.btnCharge.TabIndex = 24;
            this.btnCharge.Text = "Charge";
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Enabled = false;
            this.btnReceive.Location = new System.Drawing.Point(762, 191);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(84, 34);
            this.btnReceive.TabIndex = 23;
            this.btnReceive.Text = "Receive";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // dGridFleetView
            // 
            this.dGridFleetView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LicencePlate,
            this.Category,
            this.Available,
            this.InOperation,
            this.Model,
            this.Branch,
            this.DailyPrice,
            this.WeeklyPrice,
            this.MonthlyPrice,
            this.Mileage,
            this.Tank,
            this.FirstName,
            this.LastName,
            this.DocNumber,
            this.DocType});
            this.dGridFleetView.Location = new System.Drawing.Point(12, 37);
            this.dGridFleetView.Name = "dGridFleetView";
            this.dGridFleetView.RowTemplate.Height = 24;
            this.dGridFleetView.Size = new System.Drawing.Size(704, 423);
            this.dGridFleetView.TabIndex = 19;
            this.dGridFleetView.Text = "DataGridView1";
            this.dGridFleetView.SelectionChanged += new System.EventHandler(this.dGridFleetView_SelectionChanged);
            // 
            // LicencePlate
            // 
            this.LicencePlate.HeaderText = "Licence Plate";
            this.LicencePlate.Name = "LicencePlate";
            this.LicencePlate.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Available
            // 
            this.Available.HeaderText = "Available";
            this.Available.Name = "Available";
            this.Available.ReadOnly = true;
            // 
            // InOperation
            // 
            this.InOperation.HeaderText = "Operarational";
            this.InOperation.Name = "InOperation";
            this.InOperation.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // Branch
            // 
            this.Branch.HeaderText = "Branch";
            this.Branch.Name = "Branch";
            this.Branch.ReadOnly = true;
            // 
            // DailyPrice
            // 
            this.DailyPrice.HeaderText = "Daily Price";
            this.DailyPrice.Name = "DailyPrice";
            this.DailyPrice.ReadOnly = true;
            // 
            // WeeklyPrice
            // 
            this.WeeklyPrice.HeaderText = "Weekly Price";
            this.WeeklyPrice.Name = "WeeklyPrice";
            this.WeeklyPrice.ReadOnly = true;
            // 
            // MonthlyPrice
            // 
            this.MonthlyPrice.HeaderText = "Monthly Price";
            this.MonthlyPrice.Name = "MonthlyPrice";
            this.MonthlyPrice.ReadOnly = true;
            // 
            // Mileage
            // 
            this.Mileage.HeaderText = "Mileage";
            this.Mileage.Name = "Mileage";
            this.Mileage.ReadOnly = true;
            // 
            // Tank
            // 
            this.Tank.HeaderText = "Tank";
            this.Tank.Name = "Tank";
            this.Tank.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // DocNumber
            // 
            this.DocNumber.HeaderText = "DocNumber";
            this.DocNumber.Name = "DocNumber";
            this.DocNumber.ReadOnly = true;
            // 
            // DocType
            // 
            this.DocType.HeaderText = "Doc Type";
            this.DocType.Name = "DocType";
            this.DocType.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboBranch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboOperational);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboAvailable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.btnDisplay);
            this.groupBox1.Location = new System.Drawing.Point(12, 466);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 101);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle display filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Branch";
            // 
            // cboBranch
            // 
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Items.AddRange(new object[] {
            "All"});
            this.cboBranch.Location = new System.Drawing.Point(401, 52);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(121, 21);
            this.cboBranch.TabIndex = 7;
            this.cboBranch.Text = "All";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Operational";
            // 
            // cboOperational
            // 
            this.cboOperational.FormattingEnabled = true;
            this.cboOperational.Items.AddRange(new object[] {
            "All",
            "In Operation",
            "In Maintenance"});
            this.cboOperational.Location = new System.Drawing.Point(268, 52);
            this.cboOperational.Name = "cboOperational";
            this.cboOperational.Size = new System.Drawing.Size(121, 21);
            this.cboOperational.TabIndex = 5;
            this.cboOperational.Text = "All";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available";
            // 
            // cboAvailable
            // 
            this.cboAvailable.FormattingEnabled = true;
            this.cboAvailable.Items.AddRange(new object[] {
            "All",
            "Available",
            "Hand Over",
            "Rented",
            "Charge"});
            this.cboAvailable.Location = new System.Drawing.Point(132, 52);
            this.cboAvailable.Name = "cboAvailable";
            this.cboAvailable.Size = new System.Drawing.Size(121, 21);
            this.cboAvailable.TabIndex = 3;
            this.cboAvailable.Text = "All";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "All"});
            this.cboCategory.Location = new System.Drawing.Point(6, 52);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 21);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.Text = "All";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(616, 45);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(84, 34);
            this.btnDisplay.TabIndex = 0;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(810, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 49);
            this.button1.TabIndex = 28;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmFleetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 616);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFromMaintenance);
            this.Controls.Add(this.btnToMaintenance);
            this.Controls.Add(this.btnChangeBranch);
            this.Controls.Add(this.btnHandOver);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.btnCharge);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.dGridFleetView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmFleetView";
            this.Text = "Fleet View";
            this.Load += new System.EventHandler(this.FrmFleetView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridFleetView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fleetToolStripMenuItem;
        internal System.Windows.Forms.Button btnFromMaintenance;
        internal System.Windows.Forms.Button btnToMaintenance;
        internal System.Windows.Forms.Button btnChangeBranch;
        internal System.Windows.Forms.Button btnHandOver;
        internal System.Windows.Forms.Button btnRent;
        internal System.Windows.Forms.Button btnCharge;
        internal System.Windows.Forms.Button btnReceive;
        internal System.Windows.Forms.DataGridView dGridFleetView;
        internal System.Windows.Forms.DataGridViewTextBoxColumn LicencePlate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Category;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Available;
        internal System.Windows.Forms.DataGridViewTextBoxColumn InOperation;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Model;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DailyPrice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn WeeklyPrice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn MonthlyPrice;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Mileage;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Tank;
        internal System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DocNumber;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DocType;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboBranch;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cboOperational;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cboAvailable;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cboCategory;
        internal System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button button1;
    }
}

