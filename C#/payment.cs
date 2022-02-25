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

namespace WindowsFormsApplication6 {

public partial class payment : Form 
{

public payment() 
{
InitializeComponent();
}

private void payment_Load(object sender, EventArgs e) 
{

OracleConnection conn = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
conn.Open();
OracleCommand cmd = new OracleCommand(); 
cmd.Connection = conn;

string query = "select * from booking where Email= '"+Form1.emailadd+"'"; OracleDataAdapter sda = new OracleDataAdapter(query, conn);
DataTable dt = new DataTable();
sda.Fill(dt);
OracleCommandBuilder builder = new OracleCommandBuilder(sda); 
var ds = new DataSet();
sda.Fill(ds);
dataGridView1.DataSource = ds.Tables[0];
}

private void PAY_Click(object sender, EventArgs e) 
{
this.Hide();
ManageBooking m = new ManageBooking(); 
m.Show();
MessageBox.Show("Payment Successfull");
} 
}
}
