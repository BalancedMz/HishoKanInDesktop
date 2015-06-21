/*  Copyright (C) 2015 BalancedMz

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HishoKan_InDeskop
{
    public partial class SettingForm : Form
    {
        private readonly MainWindow mw;

        public SettingForm(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;


            checkBox_Launch.Checked = Parameter.isLaunchVoiceEnabled;
            checkBox_Click.Checked = Parameter.isClickVoiceEnabled;
            checkBox_Idle.Checked = Parameter.isIdleVoiceEnabled;
            textBox_Idle.Text = (Parameter.idleInterval/1000).ToString();
            checkBox_Clock.Checked = Parameter.isClockVoiceEnabled;

            textBox_maxImgHeight.Text = Parameter.maxImgHeight.ToString();
            textBox_maxImgWidth.Text = Parameter.maxImgWidth.ToString();

            checkBox_useAnimation.Checked = Parameter.useAnimation;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            mw.configClickVoice(checkBox_Click.Checked);
            mw.configClockVoice(checkBox_Clock.Checked);
            mw.configIdleVoice(checkBox_Idle.Checked, Convert.ToInt32(textBox_Idle.Text));
            mw.configLaunchVoice(checkBox_Launch.Checked);


            double w = Convert.ToDouble(textBox_maxImgWidth.Text);
            double h = Convert.ToDouble(textBox_maxImgHeight.Text);
            if (Parameter.maxImgWidth != w || Parameter.maxImgHeight != h)
            {
                Parameter.maxImgWidth = Convert.ToDouble(textBox_maxImgWidth.Text);
                Parameter.maxImgHeight = Convert.ToDouble(textBox_maxImgHeight.Text);
                mw.ReloadImage();
            }

            if (Parameter.useAnimation != checkBox_useAnimation.Checked)
            {
                Parameter.useAnimation = checkBox_useAnimation.Checked;
                mw.ReloadImage();
            }

            this.Dispose();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                tabControl1.SelectedIndex = listView1.FocusedItem.Index;
        }
    }
}
