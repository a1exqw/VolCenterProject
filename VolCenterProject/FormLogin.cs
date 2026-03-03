using System.Data;
using VolCenterProject.Models;

namespace VolCenterProject
{
    public partial class FormLogin : Form
    {
        public User CurrentUser { get; private set; }
        public bool isGuest { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var db = new VolCenterDbContext())
            {
                var user = db.Users
                    .Where(w => w.Email == txtLogin.Text && w.Pass == txtPassword.Text)
                    .FirstOrDefault();

                if (user != null)
                {
                    CurrentUser = user;
                    isGuest = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {

            CurrentUser = null;
            isGuest = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
