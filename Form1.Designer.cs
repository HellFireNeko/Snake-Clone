namespace Snake
{
    public partial class Form1
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
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GameStateLabel = new System.Windows.Forms.Label();
            this.GameSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.HamilCheck = new System.Windows.Forms.CheckBox();
            this.Start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(3, 3);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(320, 320);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Canvas);
            this.panel1.Location = new System.Drawing.Point(94, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 330);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score:";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(13, 29);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.ScoreLabel.TabIndex = 3;
            this.ScoreLabel.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Game state:";
            // 
            // GameStateLabel
            // 
            this.GameStateLabel.AutoSize = true;
            this.GameStateLabel.Location = new System.Drawing.Point(16, 98);
            this.GameStateLabel.Name = "GameStateLabel";
            this.GameStateLabel.Size = new System.Drawing.Size(43, 13);
            this.GameStateLabel.TabIndex = 5;
            this.GameStateLabel.Text = "Waiting";
            // 
            // GameSpeed
            // 
            this.GameSpeed.CausesValidation = false;
            this.GameSpeed.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.GameSpeed.Location = new System.Drawing.Point(13, 197);
            this.GameSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.GameSpeed.Name = "GameSpeed";
            this.GameSpeed.Size = new System.Drawing.Size(65, 20);
            this.GameSpeed.TabIndex = 6;
            this.GameSpeed.TabStop = false;
            this.GameSpeed.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.GameSpeed.ValueChanged += new System.EventHandler(this.GameSpeed_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Game speed (ms):";
            // 
            // HamilCheck
            // 
            this.HamilCheck.AutoSize = true;
            this.HamilCheck.CausesValidation = false;
            this.HamilCheck.Location = new System.Drawing.Point(4, 224);
            this.HamilCheck.Name = "HamilCheck";
            this.HamilCheck.Size = new System.Drawing.Size(86, 17);
            this.HamilCheck.TabIndex = 8;
            this.HamilCheck.TabStop = false;
            this.HamilCheck.Text = "Enable hamil";
            this.HamilCheck.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(12, 302);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 9;
            this.Start.TabStop = false;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.StartEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(457, 337);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.HamilCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GameSpeed);
            this.Controls.Add(this.GameStateLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(32, 43);
            this.Name = "Form1";
            this.Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GameSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label GameStateLabel;
        private System.Windows.Forms.NumericUpDown GameSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox HamilCheck;
        private System.Windows.Forms.Button Start;
    }
}

