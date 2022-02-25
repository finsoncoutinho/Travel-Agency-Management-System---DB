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

public partial class admin : Form {

int temp,x; public admin() 
{
InitializeComponent(); 
}

private void admin_Load(object sender, EventArgs e) {

OracleConnection conn = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
conn.Open();
OracleCommand cmd = new OracleCommand(); cmd.Connection = conn;
string query = "select * from BUS";
OracleDataAdapter sda = new OracleDataAdapter(query, conn); DataTable dt = new DataTable();
sda.Fill(dt);
OracleCommandBuilder builder = new OracleCommandBuilder(sda); var ds = new DataSet();
sda.Fill(ds);
dataGridView1.DataSource = ds.Tables[0];
}

private void button2_Click(object sender, EventArgs e) {
//addNewCode
OracleConnection con = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
con.Open();
OracleCommand cmd = new OracleCommand(); 
cmd.Connection = con;
// cmd. CommandText= "insert into consumers details values"textBox7.Text+"* "+ textBox12.Text+"'. '"+ textBox
// cm. CommandType = CommandType.Text;

OracleParameter travelid = new OracleParameter(); 
travelid.OracleDbType = OracleDbType.Int16;
travelid.Value = Travel_Id.Text;

OracleParameter busno = new OracleParameter();
busno.OracleDbType = OracleDbType.Varchar2; 
busno.Value = Bus_No.Text;

OracleParameter departure = new OracleParameter(); 
departure.OracleDbType = OracleDbType.Varchar2; 
departure.Value = Departure.Text;

OracleParameter arrival = new OracleParameter(); 
arrival.OracleDbType = OracleDbType.Varchar2; 
arrival.Value = Arrival.Text;

OracleParameter traveldate = new OracleParameter(); 
traveldate.OracleDbType = OracleDbType.Varchar2; 
traveldate.Value = Travel_Date.Text;

OracleParameter price = new OracleParameter();
price.OracleDbType = OracleDbType.Int16;
price.Value = Price.Text;

OracleParameter totalseats = new OracleParameter();
totalseats.OracleDbType = OracleDbType.Int16;
totalseats.Value = Total_Seats.Text;

OracleParameter bookedseats = new OracleParameter();
bookedseats.OracleDbType = OracleDbType.Int16;
bookedseats.Value = Booked_Seats.Text;

OracleParameter availableseats = new OracleParameter();
availableseats.OracleDbType = OracleDbType.Int16;
availableseats.Value = Available_Seats.Text;

// create command and set properties
cmd.CommandText = "INSERT INTO BUS VALUES (:1, :2, :3, :4, :5, :6, :7, :8, :9)"; cmd.CommandType = CommandType.Text;
cmd.Parameters.Add(travelid);
cmd.Parameters.Add(busno);
cmd.Parameters.Add(departure);
cmd.Parameters.Add(arrival);
cmd.Parameters.Add(traveldate);
cmd.Parameters.Add(price);
cmd.Parameters.Add(totalseats); 
cmd.Parameters.Add(bookedseats); 
cmd.Parameters.Add(availableseats);

try 
{

temp = cmd.ExecuteNonQuery();
this.Hide();
admin b = new admin();
b.Show();
MessageBox.Show("Bus added successfully");

}

catch (Oracle.DataAccess.Client.OracleException) {

if (temp <= 0) {
MessageBox.Show("Failed"); 
}

else 
{
this.Hide();
admin b = new admin();
b.Show();
MessageBox.Show("Bus added successfully");

} 
}
con.Dispose(); 
}

private void button3_Click(object sender, EventArgs e) {
//updateCode
OracleConnection con = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
con.Open();
OracleCommand cmd = new OracleCommand("Update BUS set BusNo='"+Bus_No.Text+ "',Departure ='" + Departure.Text + "',Arrival ='" + Arrival.Text + "',TravelDate ='" + Travel_Date.Text + "',Price ='" + Price.Text + "',TotalSeats ='" + Total_Seats.Text + "',BookedSeats ='" + Booked_Seats.Text + "',AvailableSeats ='" + Available_Seats.Text + "' where travel_id = '" + Travel_Id.Text+"'",con);

try {

temp = cmd.ExecuteNonQuery();
this.Hide();
admin b = new admin();
b.Show();
MessageBox.Show(" Bus Updated Successfull");

}
catch(Oracle.DataAccess.Client.OracleException) {

if(temp<=0)
{
MessageBox.Show("Update Failed"); 
}

else 
{
this.Hide();
admin b = new admin();
b.Show();
MessageBox.Show("Bus Updated Successfull");
} 
}
con.Close();
}

private void button4_Click(object sender, EventArgs e) {

this.Hide();
Form1 b = new Form1();
b.Show();
MessageBox.Show("Logged Out successfully");

}

private void button1_Click(object sender, EventArgs e) {

//deleteCode
OracleConnection con = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
con.Open();
OracleCommand cmd = new OracleCommand(); 
cmd.Connection = con;
string sqlDelete = "delete from BUS where travel_id = :1";

OracleCommand cmdDelete = new OracleCommand(); 
cmdDelete.CommandText = sqlDelete; 
cmdDelete.Connection = con;

OracleParameter travelid = new OracleParameter(); 
travelid.OracleDbType = OracleDbType.Int16; 
travelid.Value = Travel_Id.Text;

cmdDelete.Parameters.Add(travelid); 
cmdDelete.ExecuteNonQuery(); 
cmdDelete.Dispose();

this.Hide();
admin b = new admin();
b.Show();
MessageBox.Show("Bus deleted successfully");
} 
}
