using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPhoneList
{
    public partial class Form1 : Form
    {
        IContactRepository Repository;

        public Form1()
        {
            InitializeComponent();
            Repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgcontact.AutoGenerateColumns = false;
            dgcontact.DataSource = Repository.SellectAll();
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            dgcontact.AutoGenerateColumns = false;
            dgcontact.DataSource = Repository.SellectAll();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            FrmAddOrEdit frmAddOrEdit =new FrmAddOrEdit();
            frmAddOrEdit.ShowDialog();
            if (frmAddOrEdit.DialogResult== DialogResult.OK)
            {
                BindGrid();
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string name = dgcontact.CurrentRow.Cells[1].Value.ToString();
            string family = dgcontact.CurrentRow.Cells[2].Value.ToString();
            string fullname = name + "  " + family;
            if (MessageBox.Show($"آیا از پاک کردن  {fullname} مطمئن هستید  ","توجه",MessageBoxButtons.YesNo,MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                int contactid =Convert.ToInt32( dgcontact.CurrentRow.Cells[0].Value.ToString());
                Repository.Delete(contactid);
                BindGrid();
            }
            else
            {
                
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgcontact.CurrentRow != null)
            {
                int contactID = int.Parse(dgcontact.CurrentRow.Cells[0].Value.ToString());
                FrmAddOrEdit frm = new FrmAddOrEdit();
                frm.ContactID = contactID;
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void txtboxsearch_TextChanged(object sender, EventArgs e)
        {
            dgcontact.DataSource = Repository.search(txtboxsearch.Text);
        }
    }
}
