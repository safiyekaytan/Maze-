namespace Maze
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.problem1_button = new System.Windows.Forms.Button();
            this.problem2_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // problem1_button
            // 
            this.problem1_button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.problem1_button.Font = new System.Drawing.Font("Palatino Linotype", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.problem1_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.problem1_button.Location = new System.Drawing.Point(250, 246);
            this.problem1_button.Name = "problem1_button";
            this.problem1_button.Size = new System.Drawing.Size(290, 110);
            this.problem1_button.TabIndex = 0;
            this.problem1_button.Text = "Problem 1\r\n";
            this.problem1_button.UseVisualStyleBackColor = false;
            this.problem1_button.Click += new System.EventHandler(this.problem1_button_Click);
            // 
            // problem2_button
            // 
            this.problem2_button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.problem2_button.Font = new System.Drawing.Font("Palatino Linotype", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.problem2_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.problem2_button.Location = new System.Drawing.Point(757, 246);
            this.problem2_button.Name = "problem2_button";
            this.problem2_button.Size = new System.Drawing.Size(290, 110);
            this.problem2_button.TabIndex = 1;
            this.problem2_button.Text = "Problem 2";
            this.problem2_button.UseVisualStyleBackColor = false;
            this.problem2_button.Click += new System.EventHandler(this.problem2_button_Click);
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.problem2_button);
            this.Controls.Add(this.problem1_button);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button problem1_button;
        private System.Windows.Forms.Button problem2_button;
    }
}

