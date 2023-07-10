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
    public partial class FrmAddOrEdit : Form
    {
        public int ContactID = 0;
        IContactRepository Repository;
        public FrmAddOrEdit()
        {
            InitializeComponent();
            Repository = new ContactRepository();
        }
        bool ValidateInput()
        {
            if (txtname.Text=="")
            {
                MessageBox.Show("لظفا نام را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtfamily.Text == "")
            {
                MessageBox.Show("لظفا فامیلی را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لظفا موبایل را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لظفا سن را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtAddress.Text == "")
            {
                MessageBox.Show("لظفا آدرس را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void FrmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (ContactID==0)
            {
                this.Text = "افزودن شخص";
            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = Repository.SellectRow(ContactID);
                int age =Convert.ToInt32( dt.Rows[0][4].ToString());
                txtname.Text = dt.Rows[0][1].ToString();
                txtfamily.Text = dt.Rows[0][2].ToString();
                txtMobile.Text = dt.Rows[0][3].ToString();
                txtAge.Value = age;
                txtEmail.Text = dt.Rows[0][5].ToString();
                txtAddress.Text = dt.Rows[0][6].ToString();
                btnsubmit.Text = "ویرایش";
            }
            
            
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
           // if (ContactID == 0)
            //{
                if (ValidateInput())
                {
                    bool insucces;
                    if (ContactID==0)
                    {
                        insucces= Repository.Add(txtname.Text, txtfamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);
                    }
                    else
                    {
                        insucces = Repository.Update(ContactID, txtname.Text, txtfamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);
                    }
                    if (insucces == true)
                    {
                        MessageBox.Show("عملیات با موفقیت انجام شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("عملیات با موفقیت انجام نشد.", "نا موفق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
           // }
            //if (ContactID != 0)
            //{
            //    if (ValidateInput())
            //    {
            //        bool insucces = Repository.Update( ContactID,txtname.Text, txtfamily.Text, (int)txtAge.Value, txtMobile.Text, txtEmail.Text, txtAddress.Text);
            //        if (insucces==true)
            //        {
            //            MessageBox.Show("عملیات با موفقیت انجام شد.", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DialogResult = DialogResult.OK;

            //        }
            //        else
            //        {
            //            MessageBox.Show("عملیات با موفقیت انجام نشد.", "نا موفق", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //    }
            //}
        }
    }
}
