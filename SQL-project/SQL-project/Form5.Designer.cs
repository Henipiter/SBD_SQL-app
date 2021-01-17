namespace SQL_project
{
    partial class Form5
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
            this.CountCarsButton = new System.Windows.Forms.Button();
            this.CountRepairButton = new System.Windows.Forms.Button();
            this.CountCarCosts = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.CountCarEarnings = new System.Windows.Forms.Button();
            this.CountCarValue = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CountCarsButton
            // 
            this.CountCarsButton.Location = new System.Drawing.Point(84, 84);
            this.CountCarsButton.Margin = new System.Windows.Forms.Padding(4);
            this.CountCarsButton.Name = "CountCarsButton";
            this.CountCarsButton.Size = new System.Drawing.Size(168, 48);
            this.CountCarsButton.TabIndex = 0;
            this.CountCarsButton.Text = "Cars";
            this.CountCarsButton.UseVisualStyleBackColor = true;
            this.CountCarsButton.Click += new System.EventHandler(this.CountCarsButton_Click);
            // 
            // CountRepairButton
            // 
            this.CountRepairButton.Location = new System.Drawing.Point(260, 84);
            this.CountRepairButton.Margin = new System.Windows.Forms.Padding(4);
            this.CountRepairButton.Name = "CountRepairButton";
            this.CountRepairButton.Size = new System.Drawing.Size(168, 46);
            this.CountRepairButton.TabIndex = 1;
            this.CountRepairButton.Text = "Car Repairs";
            this.CountRepairButton.UseVisualStyleBackColor = true;
            this.CountRepairButton.Click += new System.EventHandler(this.CountRepairButton_Click);
            // 
            // CountCarCosts
            // 
            this.CountCarCosts.Location = new System.Drawing.Point(436, 84);
            this.CountCarCosts.Margin = new System.Windows.Forms.Padding(4);
            this.CountCarCosts.Name = "CountCarCosts";
            this.CountCarCosts.Size = new System.Drawing.Size(168, 48);
            this.CountCarCosts.TabIndex = 2;
            this.CountCarCosts.Text = "Car Costs";
            this.CountCarCosts.UseVisualStyleBackColor = true;
            this.CountCarCosts.Click += new System.EventHandler(this.CountCarCosts_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 50);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(519, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Count";
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(33, 201);
            this.ResultBox.Margin = new System.Windows.Forms.Padding(4);
            this.ResultBox.Multiline = true;
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(980, 323);
            this.ResultBox.TabIndex = 5;
            // 
            // CountCarEarnings
            // 
            this.CountCarEarnings.Location = new System.Drawing.Point(612, 84);
            this.CountCarEarnings.Margin = new System.Windows.Forms.Padding(4);
            this.CountCarEarnings.Name = "CountCarEarnings";
            this.CountCarEarnings.Size = new System.Drawing.Size(168, 48);
            this.CountCarEarnings.TabIndex = 6;
            this.CountCarEarnings.Text = "Car Earnings";
            this.CountCarEarnings.UseVisualStyleBackColor = true;
            this.CountCarEarnings.Click += new System.EventHandler(this.CountCarEarnings_Click);
            // 
            // CountCarValue
            // 
            this.CountCarValue.Location = new System.Drawing.Point(788, 84);
            this.CountCarValue.Margin = new System.Windows.Forms.Padding(4);
            this.CountCarValue.Name = "CountCarValue";
            this.CountCarValue.Size = new System.Drawing.Size(168, 48);
            this.CountCarValue.TabIndex = 7;
            this.CountCarValue.Text = "Car Value";
            this.CountCarValue.UseVisualStyleBackColor = true;
            this.CountCarValue.Click += new System.EventHandler(this.CountCarValue_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(788, 140);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(168, 48);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CountCarValue);
            this.Controls.Add(this.CountCarEarnings);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CountCarCosts);
            this.Controls.Add(this.CountRepairButton);
            this.Controls.Add(this.CountCarsButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CountCarsButton;
        private System.Windows.Forms.Button CountRepairButton;
        private System.Windows.Forms.Button CountCarCosts;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.Button CountCarEarnings;
        private System.Windows.Forms.Button CountCarValue;
        private System.Windows.Forms.Button CancelButton;
    }
}