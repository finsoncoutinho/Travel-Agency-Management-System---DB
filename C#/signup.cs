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

public partial class signup : Form {

int Gender, temp; char gen;

public signup() 
{

InitializeComponent(); 

}

private void button1_Click(object sender, EventArgs e) 
{
OracleConnection con = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
con.Open();
OracleCommand cmd = new OracleCommand();
cmd.Connection = con;
// cmd. CommandText= "insert into consumers details values"textBox7.Text+"* "+ textBox12.Text+"'. '"+ textBox
// cm. CommandType = CommandType.Text;
OracleParameter Firstname = new OracleParameter(); Firstname.OracleDbType = OracleDbType.Varchar2; Firstname.Value = fname.Text;
OracleParameter Lastname = new OracleParameter();

 Lastname.OracleDbType = OracleDbType.Varchar2; Lastname.Value = lname.Text;
OracleParameter Phonenumber = new OracleParameter(); Phonenumber.OracleDbType = OracleDbType.Varchar2; Phonenumber.Value = pno.Text;
OracleParameter Email = new OracleParameter(); Email.OracleDbType = OracleDbType.Varchar2; Email.Value = semail.Text;
OracleParameter Password = new OracleParameter(); Password.OracleDbType = OracleDbType.Varchar2; Password.Value = cpassword.Text;

if (Gender == 1) 
{ gen = 'M'; } 
else
{ gen = 'F'; }

OracleParameter gender = new OracleParameter(); gender.OracleDbType = OracleDbType.Varchar2; gender.Value = gen;

if (spassword.Text != cpassword.Text)
{
cpassword.Text.Remove(0); MessageBox.Show("Password not matching");
}

 else {
// create command and set properties
cmd.CommandText = "INSERT INTO consumer VALUES (:1, :2, :3,:4,:5,:6)"; cmd.CommandType = CommandType.Text;
cmd.Parameters.Add(Firstname);
cmd.Parameters.Add(Lastname);
cmd.Parameters.Add(Phonenumber);
cmd.Parameters.Add(Email);
cmd.Parameters.Add(Password);
cmd.Parameters.Add(gender);

try {
temp = cmd.ExecuteNonQuery(); MessageBox.Show("Account created successful"); this.Hide();
booking b = new booking();
b.Show();
}

catch (Oracle.DataAccess.Client.OracleException) {
if (temp <= 0) {
MessageBox.Show("Failed"); }

else {
MessageBox.Show("Account created successful"); this.Hide();
booking b = new booking();
b.Show();
} }
}
con.Dispose(); }
private void male_CheckedChanged(object sender, EventArgs e) {
Gender = 1; }
private void button2_Click(object sender, EventArgs e) {
this.Hide();
Form1 b = new Form1(); b.Show();
}
private void female_CheckedChanged(object sender, EventArgs e) {
Gender = 0; }
} }
