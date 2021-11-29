using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTestLogIn
{
    public partial class Form1 : Form
    {
        private Label lb, lb2, lb3;
        private Button bt;
        private TextBox username;
        private TextBox password;
        private TableLayoutPanel tlp;
        // private string username;
        // private string password;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Log In Test";
            this.Width = 300;
            this.Height = 300;
            
            tlp = new TableLayoutPanel();
            tlp.ColumnCount = 2;
            tlp.RowCount = 4;
            tlp.Dock = DockStyle.Fill;

            lb = new Label();
            lb.Text = "Type your name and password.";
            lb.Width = 270;
            lb.Dock = DockStyle.Fill;
            tlp.SetColumnSpan(lb, 2);
            
            lb2 = new Label();
            lb2.Text = "Name: ";
            lb2.Dock = DockStyle.Fill;
            
            lb3 = new Label();
            lb3.Text = "Password: ";
            lb3.Dock = DockStyle.Fill;
            
            bt = new Button();
            bt.Text = "Login";
            bt.Dock = DockStyle.Fill;
            tlp.SetColumnSpan(bt, 2);

            username = new TextBox();
            username.Dock = DockStyle.Fill;
            password = new TextBox();
            password.Dock = DockStyle.Fill;
            
            lb.Parent = tlp;
            lb2.Parent = tlp;
            username.Parent = tlp;
            lb3.Parent = tlp;
            password.Parent = tlp;
            bt.Parent = tlp;

            tlp.Parent = this;
            
            bt.Click += new EventHandler(LoginButtonClick);
        }
        
        string constr = @"Data Source = PC\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
 
        private void LoginButtonClick(Object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
 
            string sql = "SELECT * FROM login_test WHERE [USER_NAME] = " + "'" + username.Text + "'" + " AND [PASSWORD] = " + "'" + password.Text + "'";
 
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                        int rowcount = dataTable.Rows.Count;
 
                        if(rowcount == 1)
                        {
                            MessageBox.Show("Login Succeeded!","Result",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Login Failed!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
    }
}