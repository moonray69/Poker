namespace Poker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            label2 = new Label();
            label1 = new Label();
            surnameTextBox = new TextBox();
            nameTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            passwordTextBox = new TextBox();
            phonenumberTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            nicknameTextBox = new TextBox();
            emailTextBox = new TextBox();
            label7 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(390, 280);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 9;
            label2.Text = "Surname:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(390, 203);
            label1.Name = "label1";
            label1.Size = new Size(73, 28);
            label1.TabIndex = 8;
            label1.Text = "Name:";
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(390, 312);
            surnameTextBox.Margin = new Padding(3, 4, 3, 4);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(141, 27);
            surnameTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(390, 235);
            nameTextBox.Margin = new Padding(3, 4, 3, 4);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(141, 27);
            nameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(390, 607);
            label3.Name = "label3";
            label3.Size = new Size(106, 28);
            label3.TabIndex = 13;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLight;
            label4.Location = new Point(390, 529);
            label4.Name = "label4";
            label4.Size = new Size(150, 28);
            label4.TabIndex = 12;
            label4.Text = "Phonenumber:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(390, 639);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(141, 27);
            passwordTextBox.TabIndex = 11;
            // 
            // phonenumberTextBox
            // 
            phonenumberTextBox.Location = new Point(390, 561);
            phonenumberTextBox.Margin = new Padding(3, 4, 3, 4);
            phonenumberTextBox.Name = "phonenumberTextBox";
            phonenumberTextBox.Size = new Size(141, 27);
            phonenumberTextBox.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(390, 448);
            label5.Name = "label5";
            label5.Size = new Size(112, 28);
            label5.TabIndex = 17;
            label5.Text = "Nickname:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLight;
            label6.Location = new Point(390, 371);
            label6.Name = "label6";
            label6.Size = new Size(69, 28);
            label6.TabIndex = 16;
            label6.Text = "Email:";
            // 
            // nicknameTextBox
            // 
            nicknameTextBox.Location = new Point(390, 480);
            nicknameTextBox.Margin = new Padding(3, 4, 3, 4);
            nicknameTextBox.Name = "nicknameTextBox";
            nicknameTextBox.Size = new Size(141, 27);
            nicknameTextBox.TabIndex = 15;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(390, 403);
            emailTextBox.Margin = new Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(141, 27);
            emailTextBox.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Vladimir Script", 48F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Info;
            label7.ImageAlign = ContentAlignment.TopCenter;
            label7.Location = new Point(289, 55);
            label7.Name = "label7";
            label7.Size = new Size(388, 97);
            label7.TabIndex = 18;
            label7.Text = "Registration";
            label7.TextAlign = ContentAlignment.BottomCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Vladimir Script", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Yellow;
            button1.Location = new Point(376, 697);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(175, 72);
            button1.TabIndex = 19;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 797);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(nicknameTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(passwordTextBox);
            Controls.Add(phonenumberTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(surnameTextBox);
            Controls.Add(nameTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form5";
            Text = "Form5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox surnameTextBox;
        private TextBox nameTextBox;
        private Label label3;
        private Label label4;
        private TextBox passwordTextBox;
        private TextBox phonenumberTextBox;
        private Label label5;
        private Label label6;
        private TextBox nicknameTextBox;
        private TextBox emailTextBox;
        private Label label7;
        private Button button1;
    }
}