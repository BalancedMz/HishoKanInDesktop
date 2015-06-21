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
    public partial class CharSelectionForm : Form
    {
        private readonly FileOrganizer fo;
        private readonly MainWindow mw;

        public CharSelectionForm(MainWindow mw , FileOrganizer fo)
        {
            InitializeComponent();
            this.fo = fo;
            this.mw = mw;
            UpdateListView();
        }

        private void UpdateListView()
        {
            Dictionary<string , string> nameAndPath = fo.GetAllChars();
            listView1.BeginUpdate();

            foreach (KeyValuePair<string , string> item in nameAndPath)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.Key;
                lvi.Tag = item.Key;
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
                mw.changeCharacter(listView1.FocusedItem.Tag.ToString());
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
