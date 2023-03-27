namespace Maze
{
    partial class Problem2
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Bitir = new System.Windows.Forms.Button();
            this.Basla = new System.Windows.Forms.Button();
            this.Bulutla = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Bitir);
            this.panel1.Controls.Add(this.Basla);
            this.panel1.Controls.Add(this.Bulutla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1262, 673);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(973, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 85);
            this.label1.TabIndex = 3;
            this.label1.Text = "\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bitir
            // 
            this.Bitir.AutoSize = true;
            this.Bitir.Location = new System.Drawing.Point(796, 247);
            this.Bitir.Name = "Bitir";
            this.Bitir.Size = new System.Drawing.Size(117, 52);
            this.Bitir.TabIndex = 2;
            this.Bitir.Text = "Bitir";
            this.Bitir.UseVisualStyleBackColor = true;
            this.Bitir.Click += new System.EventHandler(this.Bitir_Click);
            // 
            // Basla
            // 
            this.Basla.AutoSize = true;
            this.Basla.Location = new System.Drawing.Point(796, 178);
            this.Basla.Name = "Basla";
            this.Basla.Size = new System.Drawing.Size(117, 50);
            this.Basla.TabIndex = 1;
            this.Basla.Text = "Basla";
            this.Basla.UseVisualStyleBackColor = true;
            this.Basla.Click += new System.EventHandler(this.Basla_Click);
            // 
            // Bulutla
            // 
            this.Bulutla.AutoSize = true;
            this.Bulutla.Location = new System.Drawing.Point(796, 114);
            this.Bulutla.Name = "Bulutla";
            this.Bulutla.Size = new System.Drawing.Size(117, 49);
            this.Bulutla.TabIndex = 0;
            this.Bulutla.Text = "Bulutla";
            this.Bulutla.UseVisualStyleBackColor = true;
            this.Bulutla.Click += new System.EventHandler(this.Bulutla_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Problem2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Name = "Problem2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Problem2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Basla;
        private System.Windows.Forms.Button Bulutla;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Bitir;
        private System.Windows.Forms.Label label1;
    }
}