using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewPasswordColumnExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = new List<UserModel>() {
                new UserModel(){ UserName = "user1",Password=  "user@1"},
                new UserModel(){ UserName = "user2",Password=  "user@2"},
            };
            this.userModelBindingSource.DataSource = list;
        }
    }
}
