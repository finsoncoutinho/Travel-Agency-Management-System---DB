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

public partial class ManageBooking : Form {

public ManageBooking() 
{
InitializeComponent(); 
}

private void ManageBooking_Load(object sender, EventArgs e) {

OracleConnection conn = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
conn.Open();
OracleCommand cmd = new OracleCommand(); 
cmd.Connection = conn;

string query = "select * from booking where Email= '"+Form1.emailadd+"'";
OracleDataAdapter sda = new OracleDataAdapter(query, conn);
DataTable dt = new DataTable();
sda.Fill(dt);
OracleCommandBuilder builder = new OracleCommandBuilder(sda); 
var ds = new DataSet();
sda.Fill(ds);
dataGridView1.DataSource = ds.Tables[0];
}

private void button1_Click(object sender, EventArgs e) {

OracleConnection con = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
con.Open();
OracleCommand cmd = new OracleCommand();
cmd.Connection = con;

string sqlDelete = "delete from booking where travel_id = :1 and email= '" + Form1.emailadd + "'";

OracleCommand cmdDelete = new OracleCommand();
cmdDelete.CommandText = sqlDelete; 
cmdDelete.Connection = con;

OracleParameter travelid = new OracleParameter(); 
travelid.OracleDbType = OracleDbType.Int16; 
travelid.Value = mtravelid.Text;

cmdDelete.Parameters.Add(travelid); 
cmdDelete.ExecuteNonQuery(); 
cmdDelete.Dispose();

MessageBox.Show("Ticket canceled successfully");
this.Hide();
ManageBooking b = new ManageBooking(); 
b.Show();
}

private void button2_Click(object sender, EventArgs e) {

this.Hide();
booking b = new booking(); b.Show();
}
}
}
