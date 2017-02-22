namespace grafinho_1
{
    partial class Form1
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
            this.txtVertic = new System.Windows.Forms.TextBox();
            this.txtHoriz = new System.Windows.Forms.TextBox();
            this.btnGeraMatriz = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMenor = new System.Windows.Forms.Label();
            this.lblSomaUser = new System.Windows.Forms.Label();
            this.panelBtns = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Qtd vertical";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Qtd horizontal";
            // 
            // txtVertic
            // 
            this.txtVertic.Location = new System.Drawing.Point(81, 5);
            this.txtVertic.Name = "txtVertic";
            this.txtVertic.Size = new System.Drawing.Size(100, 20);
            this.txtVertic.TabIndex = 3;
            // 
            // txtHoriz
            // 
            this.txtHoriz.Location = new System.Drawing.Point(81, 31);
            this.txtHoriz.Name = "txtHoriz";
            this.txtHoriz.Size = new System.Drawing.Size(100, 20);
            this.txtHoriz.TabIndex = 4;
            // 
            // btnGeraMatriz
            // 
            this.btnGeraMatriz.Location = new System.Drawing.Point(187, 5);
            this.btnGeraMatriz.Name = "btnGeraMatriz";
            this.btnGeraMatriz.Size = new System.Drawing.Size(96, 46);
            this.btnGeraMatriz.TabIndex = 5;
            this.btnGeraMatriz.Text = "Gerar matriz";
            this.btnGeraMatriz.UseVisualStyleBackColor = true;
            this.btnGeraMatriz.Click += new System.EventHandler(this.btnGeraMatriz_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblMenor);
            this.panel1.Controls.Add(this.lblSomaUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGeraMatriz);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtHoriz);
            this.panel1.Controls.Add(this.txtVertic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 58);
            this.panel1.TabIndex = 0;
            // 
            // lblMenor
            // 
            this.lblMenor.AutoSize = true;
            this.lblMenor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenor.Location = new System.Drawing.Point(289, 6);
            this.lblMenor.Name = "lblMenor";
            this.lblMenor.Size = new System.Drawing.Size(166, 25);
            this.lblMenor.TabIndex = 7;
            this.lblMenor.Text = "Menor caminho:";
            // 
            // lblSomaUser
            // 
            this.lblSomaUser.AutoSize = true;
            this.lblSomaUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSomaUser.Location = new System.Drawing.Point(289, 31);
            this.lblSomaUser.Name = "lblSomaUser";
            this.lblSomaUser.Size = new System.Drawing.Size(255, 25);
            this.lblSomaUser.TabIndex = 6;
            this.lblSomaUser.Text = "Soma caminho usuário: 0";
            // 
            // panelBtns
            // 
            this.panelBtns.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBtns.Location = new System.Drawing.Point(0, 58);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(442, 672);
            this.panelBtns.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(448, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(548, 381);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(769, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 46);
            this.button1.TabIndex = 8;
            this.button1.Text = "pinta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panelBtns);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gotardo é nois";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVertic;
        private System.Windows.Forms.TextBox txtHoriz;
        private System.Windows.Forms.Button btnGeraMatriz;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBtns;
        private System.Windows.Forms.Label lblSomaUser;
        private System.Windows.Forms.Label lblMenor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}

