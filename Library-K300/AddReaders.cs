using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Library_K300.Models;

namespace Library_K300
{
    public partial class AddReaders : Form
    {
        LibDB db = new LibDB();

        public AddReaders()
        {
            InitializeComponent();
        }

        private void AddReaders_Load(object sender, EventArgs e)
        {

        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            string firstname = txtFirstname.Text;
            string lastname = txtLastname.Text;
            string phone = txtPhone.Text;
            string faculty = cmbFaculty.Text;
            long newPhone;
            if(firstname!="" && lastname!="" && phone!="" && faculty != "")
            {
                if(long.TryParse(phone,out newPhone))
                {
                    Reader rd = new Reader();
                    rd.Firstname = firstname;
                    rd.Lastname = lastname;
                    rd.Phone = phone;
                    db.Readers.Add(rd);
                    db.SaveChanges();
                    MessageBox.Show($"{firstname} was created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Phone should be numeric charachter!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else
            {
                MessageBox.Show("Please ,all the fiel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
