namespace InheritanceAndPolymorphism
{
    partial class DisplayForm
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
            this.instantiateAsSeniorCitizen = new System.Windows.Forms.Button();
            this.instantiateAsCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // instantiateAsSeniorCitizen
            // 
            this.instantiateAsSeniorCitizen.Location = new System.Drawing.Point(8, 66);
            this.instantiateAsSeniorCitizen.Name = "instantiateAsSeniorCitizen";
            this.instantiateAsSeniorCitizen.Size = new System.Drawing.Size(276, 29);
            this.instantiateAsSeniorCitizen.TabIndex = 3;
            this.instantiateAsSeniorCitizen.Text = "Instantiate SeniorCitizen";
            this.instantiateAsSeniorCitizen.UseVisualStyleBackColor = true;
            this.instantiateAsSeniorCitizen.Click += new System.EventHandler(this.instantiateAsSeniorCitizen_Click);
            // 
            // instantiateAsCustomer
            // 
            this.instantiateAsCustomer.Location = new System.Drawing.Point(8, 19);
            this.instantiateAsCustomer.Name = "instantiateAsCustomer";
            this.instantiateAsCustomer.Size = new System.Drawing.Size(276, 29);
            this.instantiateAsCustomer.TabIndex = 2;
            this.instantiateAsCustomer.Text = "Instantiate Customer";
            this.instantiateAsCustomer.UseVisualStyleBackColor = true;
            this.instantiateAsCustomer.Click += new System.EventHandler(this.instantiateAsCustomer_Click);
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 111);
            this.Controls.Add(this.instantiateAsSeniorCitizen);
            this.Controls.Add(this.instantiateAsCustomer);
            this.Name = "DisplayForm";
            this.Text = "Display Form";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button instantiateAsSeniorCitizen;
        internal System.Windows.Forms.Button instantiateAsCustomer;
    }
}

