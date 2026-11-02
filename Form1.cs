
using System;
using System.Data;
using System.Windows.Forms;
using Econtact.econtactclasses;

namespace e_contact
{
    public partial class Form1 : Form
    {
        contactclass c = new contactclass();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        // DISPLAY CONTACTS
        private void LoadData()
        {
            dataGridView1.DataSource = c.select();
        }

        // CLEAR ALL FIELDS
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            richTextBox1.Clear();

            comboBox1.SelectedIndex = -1;

            LoadData();
        }

        // B1 - ADD CONTACT
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" ||
                textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Please enter First Name and Last Name");
                return;
            }

            c.FirstName = textBox2.Text.Trim();
            c.LastName = textBox3.Text.Trim();
            c.ContactNo = textBox4.Text.Trim();
            c.Address = richTextBox1.Text.Trim();
            c.Gender = comboBox1.Text;

            if (c.insert(c))
            {
                MessageBox.Show("Contact Added Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Contact Adding Failed");
            }
        }

        // B2 - UPDATE CONTACT
        private void button2_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(textBox1.Text, out id))
            {
                MessageBox.Show("Please enter a valid Contact ID");
                return;
            }

            c.ContactID = id;
            c.FirstName = textBox2.Text.Trim();
            c.LastName = textBox3.Text.Trim();
            c.ContactNo = textBox4.Text.Trim();
            c.Address = richTextBox1.Text.Trim();
            c.Gender = comboBox1.Text;

            if (c.Update(c))
            {
                MessageBox.Show("Contact Updated Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Contact Not Found or Update Failed");
            }
        }

        // B3 - DELETE CONTACT
        private void button3_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(textBox1.Text, out id))
            {
                MessageBox.Show("Please enter a valid Contact ID");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this contact?",
                "Delete Contact",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                c.ContactID = id;

                if (c.Delete(c))
                {
                    MessageBox.Show("Contact Deleted Successfully");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Contact Not Found");
                }
            }
        }

        // B4 - CLEAR
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        // SEARCH WITHOUT B5
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox5.Text.Trim();

            if (keyword == "")
            {
                LoadData();
            }
            else
            {
                DataTable dt = c.Search(keyword);
                dataGridView1.DataSource = dt;
            }
        }

        // SELECT DATAGRIDVIEW ROW
        private void dataGridView1_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ContactID"].Value.ToString();
                textBox2.Text = row.Cells["FirstName"].Value.ToString();
                textBox3.Text = row.Cells["LastName"].Value.ToString();
                textBox4.Text = row.Cells["ContactNo"].Value.ToString();

                richTextBox1.Text = row.Cells["Address"].Value.ToString();

                comboBox1.Text = row.Cells["Gender"].Value.ToString();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
