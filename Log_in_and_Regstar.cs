using ArchifProjcet_2.Addition_pages;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArchifProjcet_2
{
    public partial class Log_in_and_Regstar : DevExpress.XtraEditors.XtraForm
    {

        DAL.Tb_Users _user;
        public Log_in_and_Regstar()
        {
            InitializeComponent();
          
        }


        #region Buttons Methods
        private void buttRegistration_Click(object sender, EventArgs e)
        {
            Registration();

        }
        private void LgoinandRegstar_Load(object sender, EventArgs e)
        {
            butVisbelPassword.BackgroundImage.Tag = "eye";
        }

        private void butCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CHeckIsValidUser();
        }
        private void butVisbelPassword_Click(object sender, EventArgs e)
        {
            if (butVisbelPassword.BackgroundImage.Tag?.ToString() == "eye")
            {
                textBoxPassword.PasswordChar = '\0';
                butVisbelPassword.BackgroundImage = Image.FromFile(@"C:\Users\User\Downloads\hide.png");
                butVisbelPassword.BackgroundImage.Tag = "hiden";
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                butVisbelPassword.BackgroundImage = Image.FromFile(@"C:\Users\User\Downloads\eye.png");
                butVisbelPassword.BackgroundImage.Tag = "eye";
            }


        }

        #endregion


        #region Process

        private DAL.Tb_Users LoadData()
        {
            _user = new DAL.Tb_Users();
            _user.UserName = TexBoxUserName.Text;
            _user.Password = textBoxPassword.Text;

            return _user;

        }
        private void  CHeckIsValidUser()
        {

            if(LoadDataOnSettings())
            {
                Main main = new Main();
                this.Hide();
                main.ShowDialog();

            }
            else
            {
                TexBoxUserName.Text = "";
                textBoxPassword.Text = "";
                MessageBox.Show("حاول مجدداً \n أحد الحقول يحمل قيمة خاطئة " , "قيمة خاطئة ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Registration()
        {
            Add_Update_User _User = new Add_Update_User();
            _User.comBoxRoleName.Visible = false;
            _User.labelRole.Visible = true;
            _User.labelRole.Text = "مستخدم ";
            _User.FillLogInForm += FillItem;
            _User.ShowDialog();

        }
        private void FillItem(string UserName , string Password)
        {
            TexBoxUserName.Text = UserName;
            textBoxPassword.Text = Password;
        }

        #endregion
          private bool LoadDataOnSettings()
        {
            DataRow row = DBL.Tb_Users.ReadByUserNameAndPassword(LoadData());
            if (row != null)
            {
                Properties.Settings.Default.UserName = row["UserName"].ToString();
                Properties.Settings.Default.Category = row["CategorName"].ToString();
                Properties.Settings.Default.FullName = row["FullName"].ToString();
                Properties.Settings.Default.RoleName = row["RoleName"].ToString();
                Properties.Settings.Default.ID = Convert.ToInt32(row["ID"]);
                Properties.Settings.Default.AddDate = (row["AddDate"]).ToString();
                //Properties.Settings.Default.TotalSize = DBL.Tb_Archive.GetTotalSizeFilesByUserID(Convert.ToInt32(row["ID"])).ToString("N2");
                return true;
            }
            else
            {
                return false;
            }
        }
 
    private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            
            if (toggleSwitch1.IsOn)
            {
                //Form Style
                this.BackColor = Color.White;
                this.ForeColor = Color.FromArgb(11, 20, 58);
                toggleSwitch1.ForeColor = Color.FromArgb(11, 20, 58);
                //Buttons Style
                butVisbelPassword.BackColor = Color.White;
                butCansel.BackColor = Color.White;
                button1.ForeColor = Color.FromArgb(11, 20, 58);
                buttRegistration.ForeColor= Color.FromArgb(11, 20, 58);
                butCansel.ForeColor = Color.FromArgb(11, 20, 58);
                //TextBox Style
                TexBoxUserName.BackColor = Color.White;
                textBoxPassword.BackColor = Color.White;
                TexBoxUserName.ForeColor = Color.FromArgb(11, 20, 58);
                textBoxPassword.ForeColor = Color.FromArgb(11, 20, 58);
                //Picture Box Style
                pictureEdit1.BackColor = Color.White;
                pictureEdit2.BackColor = Color.White;
                //Label Style
                labUserName.ForeColor = Color.FromArgb(11, 20, 58);
                labUserName.BackColor = Color.White;
                label1.BackColor = Color.White;
                label1.ForeColor = Color.FromArgb(11, 20, 58);
                label2.ForeColor = Color.FromArgb(11, 20, 58);


            }
            else
            {
                //Form Style
                this.BackColor = Color.FromArgb(11, 20, 58);
                this.ForeColor = Color.White;
                //Buttons Style
                toggleSwitch1.ForeColor = Color.White;
                button1.ForeColor = Color.White;
                buttRegistration.ForeColor = Color.White;
                butCansel.BackColor = Color.FromArgb(11, 20, 58);                
                butCansel.ForeColor = Color.White;
                butVisbelPassword.BackColor = Color.FromArgb(11, 20, 58);
                //TextBox Style
                TexBoxUserName.BackColor = Color.FromArgb(11, 20, 58);                             
                TexBoxUserName.ForeColor = Color.White;
                textBoxPassword.BackColor = Color.FromArgb(11, 20, 58);
                textBoxPassword.ForeColor = Color.White;
                //Picture Box Style
                pictureEdit1.BackColor = Color.FromArgb(11, 20, 58);
                pictureEdit2.BackColor = Color.FromArgb(11, 20, 58);
                //Label Style
                labUserName.BackColor = Color.FromArgb(11, 20, 58);
                labUserName.ForeColor = Color.White;
                label1.BackColor = Color.FromArgb(11, 20, 58);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
            }



        }

      
    }
}