

namespace iSMIDIButtonMapperWinFormsDOTNET
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Button3_Red = new System.Windows.Forms.TrackBar();
            this.Button3_Green = new System.Windows.Forms.TrackBar();
            this.Button3_Blue = new System.Windows.Forms.TrackBar();
            this.Button1_Blue = new System.Windows.Forms.TrackBar();
            this.Button1_Green = new System.Windows.Forms.TrackBar();
            this.Button1_Red = new System.Windows.Forms.TrackBar();
            this.Button2_Blue = new System.Windows.Forms.TrackBar();
            this.Button2_Green = new System.Windows.Forms.TrackBar();
            this.Button2_Red = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Button3_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button3_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button3_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2_Red)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(246, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.Location = new System.Drawing.Point(150, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 72);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.Location = new System.Drawing.Point(52, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 72);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Button3_Red
            // 
            this.Button3_Red.Location = new System.Drawing.Point(256, 12);
            this.Button3_Red.Maximum = 127;
            this.Button3_Red.Name = "Button3_Red";
            this.Button3_Red.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button3_Red.Size = new System.Drawing.Size(45, 319);
            this.Button3_Red.TabIndex = 3;
            this.Button3_Red.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button3_Red.Scroll += new System.EventHandler(this.Button3_Red_Scroll);
            // 
            // Button3_Green
            // 
            this.Button3_Green.Location = new System.Drawing.Point(287, 12);
            this.Button3_Green.Maximum = 127;
            this.Button3_Green.Name = "Button3_Green";
            this.Button3_Green.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button3_Green.Size = new System.Drawing.Size(45, 319);
            this.Button3_Green.TabIndex = 4;
            this.Button3_Green.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button3_Green.Scroll += new System.EventHandler(this.Button3_Green_Scroll);
            // 
            // Button3_Blue
            // 
            this.Button3_Blue.Location = new System.Drawing.Point(317, 12);
            this.Button3_Blue.Maximum = 127;
            this.Button3_Blue.Name = "Button3_Blue";
            this.Button3_Blue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button3_Blue.Size = new System.Drawing.Size(45, 319);
            this.Button3_Blue.TabIndex = 5;
            this.Button3_Blue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button3_Blue.Value = 127;
            this.Button3_Blue.Scroll += new System.EventHandler(this.Button3_Blue_Scroll);
            // 
            // Button1_Blue
            // 
            this.Button1_Blue.Location = new System.Drawing.Point(99, 12);
            this.Button1_Blue.Maximum = 127;
            this.Button1_Blue.Name = "Button1_Blue";
            this.Button1_Blue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button1_Blue.Size = new System.Drawing.Size(45, 319);
            this.Button1_Blue.TabIndex = 8;
            this.Button1_Blue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button1_Blue.Scroll += new System.EventHandler(this.Button1_Blue_Scroll);
            // 
            // Button1_Green
            // 
            this.Button1_Green.Location = new System.Drawing.Point(69, 12);
            this.Button1_Green.Maximum = 127;
            this.Button1_Green.Name = "Button1_Green";
            this.Button1_Green.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button1_Green.Size = new System.Drawing.Size(45, 319);
            this.Button1_Green.TabIndex = 7;
            this.Button1_Green.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button1_Green.Scroll += new System.EventHandler(this.Button1_Green_Scroll);
            // 
            // Button1_Red
            // 
            this.Button1_Red.Location = new System.Drawing.Point(38, 12);
            this.Button1_Red.Maximum = 127;
            this.Button1_Red.Name = "Button1_Red";
            this.Button1_Red.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button1_Red.Size = new System.Drawing.Size(45, 319);
            this.Button1_Red.TabIndex = 6;
            this.Button1_Red.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button1_Red.Value = 127;
            this.Button1_Red.Scroll += new System.EventHandler(this.Button1_Red_Scroll);
            // 
            // Button2_Blue
            // 
            this.Button2_Blue.Location = new System.Drawing.Point(210, 12);
            this.Button2_Blue.Maximum = 127;
            this.Button2_Blue.Name = "Button2_Blue";
            this.Button2_Blue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button2_Blue.Size = new System.Drawing.Size(45, 319);
            this.Button2_Blue.TabIndex = 11;
            this.Button2_Blue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button2_Blue.Scroll += new System.EventHandler(this.Button2_Blue_Scroll);
            // 
            // Button2_Green
            // 
            this.Button2_Green.Location = new System.Drawing.Point(180, 12);
            this.Button2_Green.Maximum = 127;
            this.Button2_Green.Name = "Button2_Green";
            this.Button2_Green.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button2_Green.Size = new System.Drawing.Size(45, 319);
            this.Button2_Green.TabIndex = 10;
            this.Button2_Green.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button2_Green.Value = 127;
            this.Button2_Green.Scroll += new System.EventHandler(this.Button2_Green_Scroll);
            // 
            // Button2_Red
            // 
            this.Button2_Red.Location = new System.Drawing.Point(149, 12);
            this.Button2_Red.Maximum = 127;
            this.Button2_Red.Name = "Button2_Red";
            this.Button2_Red.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Button2_Red.Size = new System.Drawing.Size(45, 319);
            this.Button2_Red.TabIndex = 9;
            this.Button2_Red.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Button2_Red.Scroll += new System.EventHandler(this.Button2_Red_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 434);
            this.Controls.Add(this.Button2_Blue);
            this.Controls.Add(this.Button2_Green);
            this.Controls.Add(this.Button2_Red);
            this.Controls.Add(this.Button1_Blue);
            this.Controls.Add(this.Button1_Green);
            this.Controls.Add(this.Button1_Red);
            this.Controls.Add(this.Button3_Blue);
            this.Controls.Add(this.Button3_Green);
            this.Controls.Add(this.Button3_Red);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Button3_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button3_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button3_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2_Red)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar Button3_Red;
        private System.Windows.Forms.TrackBar Button3_Green;
        private System.Windows.Forms.TrackBar Button3_Blue;
        private System.Windows.Forms.TrackBar Button1_Blue;
        private System.Windows.Forms.TrackBar Button1_Green;
        private System.Windows.Forms.TrackBar Button1_Red;
        private System.Windows.Forms.TrackBar Button2_Blue;
        private System.Windows.Forms.TrackBar Button2_Green;
        private System.Windows.Forms.TrackBar Button2_Red;
    }
}


// TODO: https://www.c-sharpcorner.com/UploadFile/f9f215/how-to-minimize-your-application-to-system-tray-in-C-Sharp/

