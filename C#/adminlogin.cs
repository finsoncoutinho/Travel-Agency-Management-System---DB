using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApplication6 
{
public partial class adminlogin : Form {

public adminlogin() 
{

InitializeComponent(); 

}

private void button1_Click(object sender, EventArgs e) {

OracleConnection conn = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
conn.Open();
OracleDataAdapter ada = new OracleDataAdapter("Select email,password from admin where email='" + aemail.Text.Trim() + "' and password='" + apassword.Text.Trim() + "'", conn);
DataTable dt = new DataTable(); ada.Fill(dt);

if (dt.Rows.Count == 1) 
{

this.Hide();
admin b = new admin(); b.Show();

} 

else 
{

MessageBox.Show("Failed");

}
conn.Dispose(); }
} }
