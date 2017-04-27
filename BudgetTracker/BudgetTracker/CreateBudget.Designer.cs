namespace BudgetTracker
{
    partial class CreateBudget
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxTotal = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxRent = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxBills = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxFood = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxSavings = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMiscellaneous = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(73, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Allocated budget to miscellaneous : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Allocated  budget to savings : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(73, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "Allocated  budget to food : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Allocated budget to bills";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Allocated  budget to rent : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total monthly budget : ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(153, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 72);
            this.button1.TabIndex = 22;
            this.button1.Text = "Create Budget";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Please fill out the form to create your personalized budget!";
            // 
            // maskedTextBoxTotal
            // 
            this.maskedTextBoxTotal.Location = new System.Drawing.Point(332, 135);
            this.maskedTextBoxTotal.Mask = "0000000";
            this.maskedTextBoxTotal.Name = "maskedTextBoxTotal";
            this.maskedTextBoxTotal.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxTotal.TabIndex = 24;
            // 
            // maskedTextBoxRent
            // 
            this.maskedTextBoxRent.Location = new System.Drawing.Point(332, 162);
            this.maskedTextBoxRent.Mask = "0000000";
            this.maskedTextBoxRent.Name = "maskedTextBoxRent";
            this.maskedTextBoxRent.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxRent.TabIndex = 25;
            // 
            // maskedTextBoxBills
            // 
            this.maskedTextBoxBills.Location = new System.Drawing.Point(332, 189);
            this.maskedTextBoxBills.Mask = "0000000";
            this.maskedTextBoxBills.Name = "maskedTextBoxBills";
            this.maskedTextBoxBills.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxBills.TabIndex = 26;
            // 
            // maskedTextBoxFood
            // 
            this.maskedTextBoxFood.Location = new System.Drawing.Point(332, 216);
            this.maskedTextBoxFood.Mask = "0000000";
            this.maskedTextBoxFood.Name = "maskedTextBoxFood";
            this.maskedTextBoxFood.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxFood.TabIndex = 27;
            // 
            // maskedTextBoxSavings
            // 
            this.maskedTextBoxSavings.Location = new System.Drawing.Point(332, 243);
            this.maskedTextBoxSavings.Mask = "0000000";
            this.maskedTextBoxSavings.Name = "maskedTextBoxSavings";
            this.maskedTextBoxSavings.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxSavings.TabIndex = 28;
            // 
            // maskedTextBoxMiscellaneous
            // 
            this.maskedTextBoxMiscellaneous.Location = new System.Drawing.Point(332, 270);
            this.maskedTextBoxMiscellaneous.Mask = "0000000";
            this.maskedTextBoxMiscellaneous.Name = "maskedTextBoxMiscellaneous";
            this.maskedTextBoxMiscellaneous.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxMiscellaneous.TabIndex = 29;
            // 
            // CreateBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 444);
            this.Controls.Add(this.maskedTextBoxMiscellaneous);
            this.Controls.Add(this.maskedTextBoxSavings);
            this.Controls.Add(this.maskedTextBoxFood);
            this.Controls.Add(this.maskedTextBoxBills);
            this.Controls.Add(this.maskedTextBoxRent);
            this.Controls.Add(this.maskedTextBoxTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "CreateBudget";
            this.Text = "CreateBudget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxTotal;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxRent;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxBills;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxFood;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxSavings;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxMiscellaneous;
    }
}