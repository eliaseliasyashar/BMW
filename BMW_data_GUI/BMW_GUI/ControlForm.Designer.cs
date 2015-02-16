namespace BMW_GUI
{
    partial class ControlForm
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
            this.button_submit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_Type = new System.Windows.Forms.ListBox();
            this.DataTimer = new System.Windows.Forms.Timer(this.components);
            this.EmoUpdate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_boredom = new System.Windows.Forms.TextBox();
            this.textBox_frustration = new System.Windows.Forms.TextBox();
            this.textBox_ShortExcitement = new System.Windows.Forms.TextBox();
            this.textBox_longExcitement = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.textBox_freq = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_alpha = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Beta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_submit
            // 
            this.button_submit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_submit.Location = new System.Drawing.Point(231, 10);
            this.button_submit.Margin = new System.Windows.Forms.Padding(4);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(112, 31);
            this.button_submit.TabIndex = 20;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(28, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Choose Type";
            // 
            // listBox_Type
            // 
            this.listBox_Type.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_Type.FormattingEnabled = true;
            this.listBox_Type.ItemHeight = 16;
            this.listBox_Type.Items.AddRange(new object[] {
            "SSVEP",
            "Mental Task"});
            this.listBox_Type.Location = new System.Drawing.Point(28, 29);
            this.listBox_Type.Name = "listBox_Type";
            this.listBox_Type.Size = new System.Drawing.Size(103, 52);
            this.listBox_Type.TabIndex = 18;
            // 
            // DataTimer
            // 
            this.DataTimer.Interval = 50;
            this.DataTimer.Tick += new System.EventHandler(this.DataTimer_Tick);
            // 
            // EmoUpdate
            // 
            this.EmoUpdate.Interval = 1000;
            this.EmoUpdate.Tick += new System.EventHandler(this.EmoUpdate_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Boredom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Frustration";
            // 
            // textBox_boredom
            // 
            this.textBox_boredom.Location = new System.Drawing.Point(120, 115);
            this.textBox_boredom.Name = "textBox_boredom";
            this.textBox_boredom.Size = new System.Drawing.Size(100, 22);
            this.textBox_boredom.TabIndex = 23;
            // 
            // textBox_frustration
            // 
            this.textBox_frustration.Location = new System.Drawing.Point(120, 153);
            this.textBox_frustration.Name = "textBox_frustration";
            this.textBox_frustration.Size = new System.Drawing.Size(100, 22);
            this.textBox_frustration.TabIndex = 24;
            // 
            // textBox_ShortExcitement
            // 
            this.textBox_ShortExcitement.Location = new System.Drawing.Point(370, 153);
            this.textBox_ShortExcitement.Name = "textBox_ShortExcitement";
            this.textBox_ShortExcitement.Size = new System.Drawing.Size(100, 22);
            this.textBox_ShortExcitement.TabIndex = 28;
            // 
            // textBox_longExcitement
            // 
            this.textBox_longExcitement.Location = new System.Drawing.Point(370, 115);
            this.textBox_longExcitement.Name = "textBox_longExcitement";
            this.textBox_longExcitement.Size = new System.Drawing.Size(100, 22);
            this.textBox_longExcitement.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "Short-Term Excitemenet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "Long-Term Excitement";
            // 
            // button_stop
            // 
            this.button_stop.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_stop.Location = new System.Drawing.Point(231, 50);
            this.button_stop.Margin = new System.Windows.Forms.Padding(4);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(112, 31);
            this.button_stop.TabIndex = 29;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // textBox_freq
            // 
            this.textBox_freq.Location = new System.Drawing.Point(120, 195);
            this.textBox_freq.Name = "textBox_freq";
            this.textBox_freq.Size = new System.Drawing.Size(100, 22);
            this.textBox_freq.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "Dominant Freq";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "FreqCount";
            // 
            // textBox_alpha
            // 
            this.textBox_alpha.Location = new System.Drawing.Point(120, 231);
            this.textBox_alpha.Name = "textBox_alpha";
            this.textBox_alpha.Size = new System.Drawing.Size(100, 22);
            this.textBox_alpha.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 12);
            this.label8.TabIndex = 33;
            this.label8.Text = "Alpha";
            // 
            // textBox_Beta
            // 
            this.textBox_Beta.Location = new System.Drawing.Point(344, 231);
            this.textBox_Beta.Name = "textBox_Beta";
            this.textBox_Beta.Size = new System.Drawing.Size(100, 22);
            this.textBox_Beta.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(253, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "Beta";
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 273);
            this.Controls.Add(this.textBox_Beta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_alpha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_freq);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.textBox_ShortExcitement);
            this.Controls.Add(this.textBox_longExcitement);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_frustration);
            this.Controls.Add(this.textBox_boredom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_Type);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_Type;
        private System.Windows.Forms.Timer DataTimer;
        private System.Windows.Forms.Timer EmoUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_boredom;
        private System.Windows.Forms.TextBox textBox_frustration;
        private System.Windows.Forms.TextBox textBox_ShortExcitement;
        private System.Windows.Forms.TextBox textBox_longExcitement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.TextBox textBox_freq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_alpha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Beta;
        private System.Windows.Forms.Label label9;
    }
}