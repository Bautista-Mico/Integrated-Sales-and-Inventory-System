using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BusinessLogic.Controller;

namespace UI.View
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController;
        private const string USERNAME_PLACEHOLDER = "Username / Email";
        private const string PASSWORD_PLACEHOLDER = "Password";

        public LoginForm()
        {
            InitializeComponent();
            _userController = new UserController();

            // Load the image resource from project properties
            picLogo.Image = Integrated_Sales_and_Inventory_System.Properties.Resources.logo;
            MakePictureBoxCircular();
        }

        private void MakePictureBoxCircular()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picLogo.Width, picLogo.Height);
            picLogo.Region = new Region(path);
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == USERNAME_PLACEHOLDER)
            {
                txtUsername.Text = string.Empty;
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = USERNAME_PLACEHOLDER;
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == PASSWORD_PLACEHOLDER)
            {
                txtPassword.Text = string.Empty;
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = PASSWORD_PLACEHOLDER;
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string username = txtUsername.Text == USERNAME_PLACEHOLDER ? string.Empty : txtUsername.Text.Trim();
            string password = txtPassword.Text == PASSWORD_PLACEHOLDER ? string.Empty : txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                lblError.Text = "Please enter your username or email.";
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter your password.";
                txtPassword.Focus();
                return;
            }

            var result = _userController.Login(username, password);

            if (result.IsSuccess)
            {
                LandingForm landing = new LandingForm(result.User);
                landing.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = result.Message;
            }
        }
    }
}