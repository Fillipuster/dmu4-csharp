namespace Lek05_WinForms
{
    partial class Form2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddLeft = new System.Windows.Forms.Button();
            this.txfFirstName = new System.Windows.Forms.TextBox();
            this.txfLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.btnAddRight = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAge = new System.Windows.Forms.Label();
            this.txfAge = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.52124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.47876F));
            this.tableLayoutPanel1.Controls.Add(this.txfAge, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAge, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAddLeft, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txfFirstName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txfLastName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLastName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRight, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 306);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAddLeft
            // 
            this.btnAddLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddLeft.Location = new System.Drawing.Point(118, 221);
            this.btnAddLeft.Name = "btnAddLeft";
            this.btnAddLeft.Size = new System.Drawing.Size(115, 23);
            this.btnAddLeft.TabIndex = 6;
            this.btnAddLeft.Text = "Add to left";
            this.btnAddLeft.UseVisualStyleBackColor = true;
            this.btnAddLeft.Click += new System.EventHandler(this.BtnAddLeft_Click);
            // 
            // txfFirstName
            // 
            this.txfFirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txfFirstName.Location = new System.Drawing.Point(95, 27);
            this.txfFirstName.Name = "txfFirstName";
            this.txfFirstName.Size = new System.Drawing.Size(161, 22);
            this.txfFirstName.TabIndex = 2;
            // 
            // txfLastName
            // 
            this.txfLastName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txfLastName.Location = new System.Drawing.Point(95, 104);
            this.txfLastName.Name = "txfLastName";
            this.txfLastName.Size = new System.Drawing.Size(161, 22);
            this.txfLastName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(13, 30);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(76, 17);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(13, 107);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(76, 17);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "Last Name";
            // 
            // btnAddRight
            // 
            this.btnAddRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddRight.Location = new System.Drawing.Point(118, 271);
            this.btnAddRight.Name = "btnAddRight";
            this.btnAddRight.Size = new System.Drawing.Size(115, 23);
            this.btnAddRight.TabIndex = 0;
            this.btnAddRight.Text = "Add to right";
            this.btnAddRight.UseVisualStyleBackColor = true;
            this.btnAddRight.Click += new System.EventHandler(this.BtnAddRight_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(8, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblAge
            // 
            this.lblAge.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(56, 171);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(33, 17);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Age";
            // 
            // txfAge
            // 
            this.txfAge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txfAge.Location = new System.Drawing.Point(95, 168);
            this.txfAge.Name = "txfAge";
            this.txfAge.Size = new System.Drawing.Size(161, 22);
            this.txfAge.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 306);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddRight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txfFirstName;
        private System.Windows.Forms.TextBox txfLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnAddLeft;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txfAge;
    }
}
