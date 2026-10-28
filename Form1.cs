using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ToDoList
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        enum enStatus { Pending = 0, Completed = 1 };
        List<ListViewItem> MyItems = new List<ListViewItem>();


        private void AddTasks(TextBox text, ComboBox comboBox)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
                return;

            if (comboBox.SelectedIndex == -1)
                return;

            ListViewItem item = new ListViewItem("");

            item.ImageIndex = comboBox.SelectedIndex;

            item.SubItems.Add(text.Text.Trim());
            item.Tag = enStatus.Pending;
            item.SubItems.Add(enStatus.Pending.ToString());
            item.SubItems.Add(txtDescription.Text.Trim());
            item.SubItems.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy"));


            listView1.Items.Add(item);
            MyItems.Add(item);

            text.Clear();
            text.Focus();

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            AddTasks(txtName, CBPriority);
        }


        private void CBPriority_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {


            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                listView1.Items.Remove(item);

                MyItems.Remove(item);
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void btnMarkCompeleted_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                item.Tag = enStatus.Completed;
                item.SubItems[2].Text = item.Tag.ToString();

            }

        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            foreach (ListViewItem item in MyItems)
            {
                if ((enStatus)item.Tag == enStatus.Pending)
                {
                    listView1.Items.Add(item);
                }
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            foreach (ListViewItem item in MyItems)
            {
                if ((enStatus)item.Tag == enStatus.Completed)
                {
                    listView1.Items.Add(item);
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            foreach (ListViewItem item in MyItems)
            {

                listView1.Items.Add(item);

            }
        }


    }
}
