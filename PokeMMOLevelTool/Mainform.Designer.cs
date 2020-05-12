namespace PokeMMOLevelTool
{
    partial class Mainform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_skippc = new System.Windows.Forms.Button();
            this.timer_cancel = new System.Windows.Forms.Timer(this.components);
            this.button_stopimm = new System.Windows.Forms.Button();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.radioButton_longmu = new System.Windows.Forms.RadioButton();
            this.button_test = new System.Windows.Forms.Button();
            this.pictureBox_show = new System.Windows.Forms.PictureBox();
            this.timer_moveDetect = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_dragonTower = new System.Windows.Forms.RadioButton();
            this.radioButton_shuanglong9 = new System.Windows.Forms.RadioButton();
            this.radioButton_shuanglong10 = new System.Windows.Forms.RadioButton();
            this.checkBox_useDefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_show)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(183, 24);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(97, 37);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "开始";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(183, 110);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(97, 37);
            this.button_stop.TabIndex = 1;
            this.button_stop.Text = "停止后续";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_skippc
            // 
            this.button_skippc.Location = new System.Drawing.Point(183, 67);
            this.button_skippc.Name = "button_skippc";
            this.button_skippc.Size = new System.Drawing.Size(97, 37);
            this.button_skippc.TabIndex = 4;
            this.button_skippc.Text = "省略路途";
            this.button_skippc.UseVisualStyleBackColor = true;
            this.button_skippc.Click += new System.EventHandler(this.button_skippc_Click);
            // 
            // timer_cancel
            // 
            this.timer_cancel.Interval = 500;
            this.timer_cancel.Tick += new System.EventHandler(this.timer_cancel_Tick);
            // 
            // button_stopimm
            // 
            this.button_stopimm.BackColor = System.Drawing.SystemColors.Control;
            this.button_stopimm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_stopimm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_stopimm.Location = new System.Drawing.Point(183, 196);
            this.button_stopimm.Name = "button_stopimm";
            this.button_stopimm.Size = new System.Drawing.Size(97, 47);
            this.button_stopimm.TabIndex = 3;
            this.button_stopimm.Text = "立即终止";
            this.button_stopimm.UseVisualStyleBackColor = false;
            this.button_stopimm.Click += new System.EventHandler(this.button_stopimm_Click);
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(12, 271);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.ReadOnly = true;
            this.richTextBox_log.Size = new System.Drawing.Size(640, 230);
            this.richTextBox_log.TabIndex = 6;
            this.richTextBox_log.Text = "";
            // 
            // radioButton_longmu
            // 
            this.radioButton_longmu.AutoSize = true;
            this.radioButton_longmu.Checked = true;
            this.radioButton_longmu.Location = new System.Drawing.Point(19, 30);
            this.radioButton_longmu.Name = "radioButton_longmu";
            this.radioButton_longmu.Size = new System.Drawing.Size(96, 19);
            this.radioButton_longmu.TabIndex = 7;
            this.radioButton_longmu.TabStop = true;
            this.radioButton_longmu.Text = "笼目 火马";
            this.radioButton_longmu.UseVisualStyleBackColor = true;
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(183, 153);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(97, 37);
            this.button_test.TabIndex = 8;
            this.button_test.Text = "测试";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // pictureBox_show
            // 
            this.pictureBox_show.Location = new System.Drawing.Point(297, 24);
            this.pictureBox_show.Name = "pictureBox_show";
            this.pictureBox_show.Size = new System.Drawing.Size(355, 218);
            this.pictureBox_show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_show.TabIndex = 9;
            this.pictureBox_show.TabStop = false;
            // 
            // timer_moveDetect
            // 
            this.timer_moveDetect.Interval = 10;
            this.timer_moveDetect.Tick += new System.EventHandler(this.timer_moveDetect_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_useDefault);
            this.groupBox1.Controls.Add(this.radioButton_shuanglong10);
            this.groupBox1.Controls.Add(this.radioButton_shuanglong9);
            this.groupBox1.Controls.Add(this.radioButton_dragonTower);
            this.groupBox1.Controls.Add(this.radioButton_longmu);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 243);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路径选择";
            // 
            // radioButton_dragonTower
            // 
            this.radioButton_dragonTower.AutoSize = true;
            this.radioButton_dragonTower.Location = new System.Drawing.Point(19, 55);
            this.radioButton_dragonTower.Name = "radioButton_dragonTower";
            this.radioButton_dragonTower.Size = new System.Drawing.Size(111, 19);
            this.radioButton_dragonTower.TabIndex = 8;
            this.radioButton_dragonTower.Text = "龙螺旋 鲈鱼";
            this.radioButton_dragonTower.UseVisualStyleBackColor = true;
            // 
            // radioButton_shuanglong9
            // 
            this.radioButton_shuanglong9.AutoSize = true;
            this.radioButton_shuanglong9.Location = new System.Drawing.Point(19, 80);
            this.radioButton_shuanglong9.Name = "radioButton_shuanglong9";
            this.radioButton_shuanglong9.Size = new System.Drawing.Size(111, 19);
            this.radioButton_shuanglong9.TabIndex = 9;
            this.radioButton_shuanglong9.Text = "双龙 细胞卵";
            this.radioButton_shuanglong9.UseVisualStyleBackColor = true;
            // 
            // radioButton_shuanglong10
            // 
            this.radioButton_shuanglong10.AutoSize = true;
            this.radioButton_shuanglong10.Location = new System.Drawing.Point(19, 105);
            this.radioButton_shuanglong10.Name = "radioButton_shuanglong10";
            this.radioButton_shuanglong10.Size = new System.Drawing.Size(111, 19);
            this.radioButton_shuanglong10.TabIndex = 10;
            this.radioButton_shuanglong10.Text = "双龙 爆炸牛";
            this.radioButton_shuanglong10.UseVisualStyleBackColor = true;
            // 
            // checkBox_useDefault
            // 
            this.checkBox_useDefault.AutoSize = true;
            this.checkBox_useDefault.Checked = true;
            this.checkBox_useDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_useDefault.Location = new System.Drawing.Point(19, 211);
            this.checkBox_useDefault.Name = "checkBox_useDefault";
            this.checkBox_useDefault.Size = new System.Drawing.Size(119, 19);
            this.checkBox_useDefault.TabIndex = 11;
            this.checkBox_useDefault.Text = "使用预制路径";
            this.checkBox_useDefault.UseVisualStyleBackColor = true;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 513);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox_show);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.richTextBox_log);
            this.Controls.Add(this.button_skippc);
            this.Controls.Add(this.button_stopimm);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.Text = "Pokemmo Level Tool";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_show)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_skippc;
        private System.Windows.Forms.Timer timer_cancel;
        private System.Windows.Forms.Button button_stopimm;
        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.RadioButton radioButton_longmu;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.PictureBox pictureBox_show;
        private System.Windows.Forms.Timer timer_moveDetect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_useDefault;
        private System.Windows.Forms.RadioButton radioButton_shuanglong10;
        private System.Windows.Forms.RadioButton radioButton_shuanglong9;
        private System.Windows.Forms.RadioButton radioButton_dragonTower;
    }
}

