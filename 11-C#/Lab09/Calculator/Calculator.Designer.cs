namespace Calculator
{
    partial class Calculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEquql = new Button();
            btn0 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btnDiv = new Button();
            btnMul = new Button();
            btnSub = new Button();
            btnAdd = new Button();
            txtDiplay = new TextBox();
            btnDot = new Button();
            btnRemove = new Button();
            SuspendLayout();
            // 
            // btnEquql
            // 
            btnEquql.Location = new Point(266, 363);
            btnEquql.Name = "btnEquql";
            btnEquql.Size = new Size(94, 29);
            btnEquql.TabIndex = 10;
            btnEquql.Text = "=";
            btnEquql.UseVisualStyleBackColor = true;
            btnEquql.Click += equal_click;
            // 
            // btn0
            // 
            btn0.Location = new Point(24, 363);
            btn0.Name = "btn0";
            btn0.Size = new Size(94, 29);
            btn0.TabIndex = 0;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += number_click;
            // 
            // btn3
            // 
            btn3.Location = new Point(266, 307);
            btn3.Name = "btn3";
            btn3.Size = new Size(94, 29);
            btn3.TabIndex = 3;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += number_click;
            // 
            // btn2
            // 
            btn2.Location = new Point(145, 307);
            btn2.Name = "btn2";
            btn2.Size = new Size(94, 29);
            btn2.TabIndex = 2;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += number_click;
            // 
            // btn1
            // 
            btn1.Location = new Point(24, 307);
            btn1.Name = "btn1";
            btn1.Size = new Size(94, 29);
            btn1.TabIndex = 1;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += number_click;
            // 
            // btn6
            // 
            btn6.Location = new Point(266, 258);
            btn6.Name = "btn6";
            btn6.Size = new Size(94, 29);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += number_click;
            // 
            // btn5
            // 
            btn5.Location = new Point(145, 258);
            btn5.Name = "btn5";
            btn5.Size = new Size(94, 29);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += number_click;
            // 
            // btn4
            // 
            btn4.Location = new Point(24, 258);
            btn4.Name = "btn4";
            btn4.Size = new Size(94, 29);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += number_click;
            // 
            // btn9
            // 
            btn9.Location = new Point(266, 210);
            btn9.Name = "btn9";
            btn9.Size = new Size(94, 29);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += number_click;
            // 
            // btn8
            // 
            btn8.Location = new Point(145, 210);
            btn8.Name = "btn8";
            btn8.Size = new Size(94, 29);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += number_click;
            // 
            // btn7
            // 
            btn7.BackColor = SystemColors.Control;
            btn7.Location = new Point(24, 210);
            btn7.Name = "btn7";
            btn7.Size = new Size(94, 29);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = false;
            btn7.Click += number_click;
            // 
            // btnDiv
            // 
            btnDiv.Location = new Point(399, 363);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(94, 29);
            btnDiv.TabIndex = 14;
            btnDiv.Text = "/";
            btnDiv.UseVisualStyleBackColor = true;
            btnDiv.Click += opt_click;
            // 
            // btnMul
            // 
            btnMul.Location = new Point(399, 307);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(94, 29);
            btnMul.TabIndex = 13;
            btnMul.Text = "*";
            btnMul.UseVisualStyleBackColor = true;
            btnMul.Click += opt_click;
            // 
            // btnSub
            // 
            btnSub.Location = new Point(399, 258);
            btnSub.Name = "btnSub";
            btnSub.Size = new Size(94, 29);
            btnSub.TabIndex = 12;
            btnSub.Text = "-";
            btnSub.UseVisualStyleBackColor = true;
            btnSub.Click += opt_click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(399, 210);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += opt_click;
            // 
            // txtDiplay
            // 
            txtDiplay.Dock = DockStyle.Fill;
            txtDiplay.Font = new Font("Segoe UI", 20F);
            txtDiplay.Location = new Point(0, 0);
            txtDiplay.MaximumSize = new Size(0, 50);
            txtDiplay.MaxLength = 20;
            txtDiplay.Name = "txtDiplay";
            txtDiplay.PlaceholderText = "Enter Num1";
            txtDiplay.ReadOnly = true;
            txtDiplay.Size = new Size(519, 50);
            txtDiplay.TabIndex = 15;
            // 
            // btnDot
            // 
            btnDot.Location = new Point(145, 363);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(94, 29);
            btnDot.TabIndex = 11;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = true;
            btnDot.Click += dot_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(399, 163);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 29);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "x";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 450);
            Controls.Add(btnRemove);
            Controls.Add(btnDot);
            Controls.Add(txtDiplay);
            Controls.Add(btnAdd);
            Controls.Add(btnSub);
            Controls.Add(btnMul);
            Controls.Add(btnDiv);
            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn0);
            Controls.Add(btnEquql);
            Name = "Calculator";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEquql;
        private Button btn0;
        private Button btn3;
        private Button btn2;
        private Button btn1;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btnDiv;
        private Button btnMul;
        private Button btnSub;
        private Button btnAdd;
        private TextBox txtDiplay;
        private Button btnDot;
        private Button btnRemove;
    }
}
