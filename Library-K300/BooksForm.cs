using Library_K300.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_K300
{
    public partial class BooksForm : Form
    {
        LibDB db = new LibDB();
        public BooksForm()
        {
            InitializeComponent();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            BookLoad();
            cmbAuthors.Items.AddRange(db.Authors.Select(ath => ath.AuthorName).ToArray());

        }
        public void BookLoad()
        {
            dtgBooks.DataSource = db.Books.Select(bk => new {
                bk.BookName,
                bk.Counts,
                bk.Author.AuthorName,
                bk.CreateDate
            })
            .ToList();
        }
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string bkname = txtBookName.Text;
            string count = txtCounts.Text;
            string authorname = cmbAuthors.Text;
            DateTime publishDate = dtPublishDate.Value;
            if(bkname!=string.Empty && count!=string.Empty &&
                authorname!=string.Empty && publishDate <= DateTime.Now)
            {
                int autId = db.Authors.First(ath => ath.AuthorName == authorname).Id;
                int countNum=Convert.ToInt32(count);
                Book bk = new Book();
                bk.BookName = bkname;
                bk.Counts = countNum;
                bk.AuthorId = autId;
                bk.CreateDate = publishDate;
                db.Books.Add(bk);
                db.SaveChanges();
                MessageBox.Show("Book create successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BookLoad();

            }
            else
            {
                lblError.Text = "Please all the Fill!";
                lblError.Visible = true;
            }
        }

      

        private void txtCounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar<47 || e.KeyChar > 58) && e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }
    }
}
