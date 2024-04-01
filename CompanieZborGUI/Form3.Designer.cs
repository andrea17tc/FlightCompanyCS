namespace CompanieZborGUI
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxClientAdress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBoxTourist1 = new System.Windows.Forms.TextBox();
            this.textBoxTourist2 = new System.Windows.Forms.TextBox();
            this.textBoxTourist3 = new System.Windows.Forms.TextBox();
            this.textBoxTourist4 = new System.Windows.Forms.TextBox();
            this.textBoxTourist5 = new System.Windows.Forms.TextBox();
            this.buttonBook = new System.Windows.Forms.Button();
            this.labelNoSeatsAvailable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Tickets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client\'s Name";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(60, 93);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(223, 27);
            this.textBoxClientName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Client\'s Adress";
            // 
            // textBoxClientAdress
            // 
            this.textBoxClientAdress.Location = new System.Drawing.Point(60, 208);
            this.textBoxClientAdress.Name = "textBoxClientAdress";
            this.textBoxClientAdress.Size = new System.Drawing.Size(223, 27);
            this.textBoxClientAdress.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of Tourists";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(201, 291);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 27);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // textBoxTourist1
            // 
            this.textBoxTourist1.Location = new System.Drawing.Point(494, 93);
            this.textBoxTourist1.Name = "textBoxTourist1";
            this.textBoxTourist1.Size = new System.Drawing.Size(125, 27);
            this.textBoxTourist1.TabIndex = 9;
            // 
            // textBoxTourist2
            // 
            this.textBoxTourist2.Location = new System.Drawing.Point(494, 163);
            this.textBoxTourist2.Name = "textBoxTourist2";
            this.textBoxTourist2.Size = new System.Drawing.Size(125, 27);
            this.textBoxTourist2.TabIndex = 10;
            // 
            // textBoxTourist3
            // 
            this.textBoxTourist3.Location = new System.Drawing.Point(494, 245);
            this.textBoxTourist3.Name = "textBoxTourist3";
            this.textBoxTourist3.Size = new System.Drawing.Size(125, 27);
            this.textBoxTourist3.TabIndex = 11;
            // 
            // textBoxTourist4
            // 
            this.textBoxTourist4.Location = new System.Drawing.Point(494, 325);
            this.textBoxTourist4.Name = "textBoxTourist4";
            this.textBoxTourist4.Size = new System.Drawing.Size(125, 27);
            this.textBoxTourist4.TabIndex = 12;
            // 
            // textBoxTourist5
            // 
            this.textBoxTourist5.Location = new System.Drawing.Point(494, 398);
            this.textBoxTourist5.Name = "textBoxTourist5";
            this.textBoxTourist5.Size = new System.Drawing.Size(125, 27);
            this.textBoxTourist5.TabIndex = 13;
            // 
            // buttonBook
            // 
            this.buttonBook.Location = new System.Drawing.Point(101, 396);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(94, 29);
            this.buttonBook.TabIndex = 14;
            this.buttonBook.Text = "Book";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // labelNoSeatsAvailable
            // 
            this.labelNoSeatsAvailable.AutoSize = true;
            this.labelNoSeatsAvailable.Location = new System.Drawing.Point(60, 263);
            this.labelNoSeatsAvailable.Name = "labelNoSeatsAvailable";
            this.labelNoSeatsAvailable.Size = new System.Drawing.Size(0, 20);
            this.labelNoSeatsAvailable.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 538);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelNoSeatsAvailable);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.textBoxTourist5);
            this.Controls.Add(this.textBoxTourist4);
            this.Controls.Add(this.textBoxTourist3);
            this.Controls.Add(this.textBoxTourist2);
            this.Controls.Add(this.textBoxTourist1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxClientAdress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxClientName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxClientName;
        private Label label3;
        private TextBox textBoxClientAdress;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private TextBox textBoxTourist1;
        private TextBox textBoxTourist2;
        private TextBox textBoxTourist3;
        private TextBox textBoxTourist4;
        private TextBox textBoxTourist5;
        private Button buttonBook;
        private Label labelNoSeatsAvailable;
        private Button button1;
    }
}