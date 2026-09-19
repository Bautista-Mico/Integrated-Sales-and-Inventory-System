using System;
using System.Windows.Forms;
using Model;

namespace UI.View
{
    public partial class LandingForm : Form
    {
        private readonly User? _currentUser;

        public LandingForm()
        {
            InitializeComponent();
        }

        public LandingForm(User user) : this()
        {
            _currentUser = user;
        }
    }
}