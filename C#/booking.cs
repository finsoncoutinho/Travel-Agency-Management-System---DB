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

public partial class booking : Form {

int temp;

public booking() 
{
InitializeComponent(); 
}

private void booking_Load_1(object sender, EventArgs e) 
{

OracleConnection conn = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
conn.Open();
OracleCommand cmd = new OracleCommand();
cmd.Connection = conn;

string query = "select * from BUS";
OracleDataAdapter sda = new OracleDataAdapter(query, conn); DataTable dt = new DataTable();
sda.Fill(dt);
OracleCommandBuilder builder = new OracleCommandBuilder(sda); var ds = new DataSet();
sda.Fill(ds);
dataGridView1.DataSource = ds.Tables[0];

}

private void button1_Click_1(object sender, EventArgs e) {

OracleConnection conn = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
conn.Open();
OracleDataAdapter ada = new OracleDataAdapter("Select AvailableSeats from BUS where trav- el_id ='" + btravelid.Text.Trim() + "' and AvailableSeats >='" + seats.Text.Trim() + "'", conn);
DataTable dt = new DataTable(); ada.Fill(dt);

if (dt.Rows.Count == 1) {

OracleConnection con = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
con.Open();
OracleCommand cmd = new OracleCommand("INSERT INTO booking(Email, travel_id, Qseats) VALUES('" + Form1.emailadd + "','" + btravelid.Text.Trim() + "','" + seats.Text.Trim() + "')",con);
cmd.Connection = con;

try {

temp = cmd.ExecuteNonQuery();
MessageBox.Show("Order Placed Successfully click Next "); 

}

catch (Oracle.DataAccess.Client.OracleException) {

if (temp <= 0) 
{
MessageBox.Show("Order Failed");
}
else 
{
MessageBox.Show("Order Placed Successfully click Next ");
}
}
con.Dispose();
} 
else
{
MessageBox.Show("Not Enough Seats");
} 
conn.Dispose();
}

private void button4_Click(object sender, EventArgs e) 
{
this.Hide();
Form1 b = new Form1();
b.Show();
MessageBox.Show("Logged Out successfully");
}

private void button5_Click(object sender, EventArgs e) 
{
this.Hide();
ManageBooking b = new ManageBooking();
b.Show();
}

private void button2_Click(object sender, EventArgs e) 
{
OracleConnection can = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
can.Open();
OracleCommand cmdd = new OracleCommand("UPDATE booking SET Price = (select Price from BUS where travel_id ='" + btravelid.Text.Trim() + "') WHERE travel_id ='" + btravelid.Text.Trim() + "' ", can);
cmdd.Connection = can;

try {

temp = cmdd.ExecuteNonQuery(); 
this.Hide();
payment b = new payment(); 
b.Show();

}
catch (Oracle.DataAccess.Client.OracleException) 
{
if (temp < 0) 
{
MessageBox.Show("Failed"); 
}
else 
{
this.Hide();
payment b = new payment(); 
b.Show();
} 
}
can.Dispose(); 
}
} 
}
