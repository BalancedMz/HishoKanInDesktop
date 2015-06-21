namespace HishoKan_InDeskop
{
    partial class SettingForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("語音 / 報時");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("圖像");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Idle = new System.Windows.Forms.TextBox();
            this.checkBox_Clock = new System.Windows.Forms.CheckBox();
            this.checkBox_Idle = new System.Windows.Forms.CheckBox();
            this.checkBox_Click = new System.Windows.Forms.CheckBox();
            this.checkBox_Launch = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox_maxImgHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_maxImgWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.checkBox_useAnimation = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 374);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 117;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(152, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(262, 342);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox_Idle);
            this.tabPage1.Controls.Add(this.checkBox_Clock);
            this.tabPage1.Controls.Add(this.checkBox_Idle);
            this.tabPage1.Controls.Add(this.checkBox_Click);
            this.tabPage1.Controls.Add(this.checkBox_Launch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(254, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "間隔 ( 秒 )";
            // 
            // textBox_Idle
            // 
            this.textBox_Idle.Location = new System.Drawing.Point(103, 112);
            this.textBox_Idle.Name = "textBox_Idle";
            this.textBox_Idle.Size = new System.Drawing.Size(100, 20);
            this.textBox_Idle.TabIndex = 4;
            // 
            // checkBox_Clock
            // 
            this.checkBox_Clock.AutoSize = true;
            this.checkBox_Clock.Location = new System.Drawing.Point(6, 153);
            this.checkBox_Clock.Name = "checkBox_Clock";
            this.checkBox_Clock.Size = new System.Drawing.Size(74, 17);
            this.checkBox_Clock.TabIndex = 3;
            this.checkBox_Clock.Text = "報時語音";
            this.checkBox_Clock.UseVisualStyleBackColor = true;
            // 
            // checkBox_Idle
            // 
            this.checkBox_Idle.AutoSize = true;
            this.checkBox_Idle.Location = new System.Drawing.Point(6, 95);
            this.checkBox_Idle.Name = "checkBox_Idle";
            this.checkBox_Idle.Size = new System.Drawing.Size(74, 17);
            this.checkBox_Idle.TabIndex = 2;
            this.checkBox_Idle.Text = "閒置語音";
            this.checkBox_Idle.UseVisualStyleBackColor = true;
            // 
            // checkBox_Click
            // 
            this.checkBox_Click.AutoSize = true;
            this.checkBox_Click.Location = new System.Drawing.Point(6, 53);
            this.checkBox_Click.Name = "checkBox_Click";
            this.checkBox_Click.Size = new System.Drawing.Size(74, 17);
            this.checkBox_Click.TabIndex = 1;
            this.checkBox_Click.Text = "點擊語音";
            this.checkBox_Click.UseVisualStyleBackColor = true;
            // 
            // checkBox_Launch
            // 
            this.checkBox_Launch.AutoSize = true;
            this.checkBox_Launch.Location = new System.Drawing.Point(6, 15);
            this.checkBox_Launch.Name = "checkBox_Launch";
            this.checkBox_Launch.Size = new System.Drawing.Size(74, 17);
            this.checkBox_Launch.TabIndex = 0;
            this.checkBox_Launch.Text = "啟動語音";
            this.checkBox_Launch.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox_useAnimation);
            this.tabPage2.Controls.Add(this.textBox_maxImgHeight);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox_maxImgWidth);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(254, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox_maxImgHeight
            // 
            this.textBox_maxImgHeight.Location = new System.Drawing.Point(164, 28);
            this.textBox_maxImgHeight.Name = "textBox_maxImgHeight";
            this.textBox_maxImgHeight.Size = new System.Drawing.Size(38, 20);
            this.textBox_maxImgHeight.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "高";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "寬";
            // 
            // textBox_maxImgWidth
            // 
            this.textBox_maxImgWidth.Location = new System.Drawing.Point(43, 28);
            this.textBox_maxImgWidth.Name = "textBox_maxImgWidth";
            this.textBox_maxImgWidth.Size = new System.Drawing.Size(42, 20);
            this.textBox_maxImgWidth.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "圖片最大像素";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(364, 363);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(283, 363);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 1;
            this.btn_Confirm.Text = "確定";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // checkBox_useAnimation
            // 
            this.checkBox_useAnimation.AutoSize = true;
            this.checkBox_useAnimation.Location = new System.Drawing.Point(9, 77);
            this.checkBox_useAnimation.Name = "checkBox_useAnimation";
            this.checkBox_useAnimation.Size = new System.Drawing.Size(74, 17);
            this.checkBox_useAnimation.TabIndex = 2;
            this.checkBox_useAnimation.Text = "啟用動畫";
            this.checkBox_useAnimation.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(451, 398);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.TextBox textBox_Idle;
        private System.Windows.Forms.CheckBox checkBox_Clock;
        private System.Windows.Forms.CheckBox checkBox_Idle;
        private System.Windows.Forms.CheckBox checkBox_Click;
        private System.Windows.Forms.CheckBox checkBox_Launch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_maxImgHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_maxImgWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_useAnimation;
    }
}