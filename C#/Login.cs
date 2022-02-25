using System;
using System.Collections.Generic; using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client; namespace WindowsFormsApplication6 {

public partial class Form1 : Form {
public Form1() {
InitializeComponent();
 }
public static string emailadd = "";
private void button1_Click(object sender, EventArgs e) {
OracleConnection conn = new OracleConnection("Data Source=localhost;User ID=dbqp;Pass- word=dbqp123;");
conn.Open();
OracleDataAdapter ada = new OracleDataAdapter("Select email,password from consumer where email='" + email.Text.Trim() + "' and password='" + password.Text.Trim() + "'", conn);
DataTable dt = new DataTable(); ada.Fill(dt);
if (dt.Rows.Count == 1) {
emailadd = email.Text.Trim(); this.Hide();
booking b = new booking(); b.Show();
} else {
MessageBox.Show("Failed");
}
conn.Dispose(); }
private void button2_Click(object sender, EventArgs e) {
this.Hide();
signup S = new signup(); S.Show();
}
private void button3_Click(object sender, EventArgs e) {
this.Hide();

adminlogin S = new adminlogin();
S.Show(); }
private void pictureBox2_Click(object sender, EventArgs e) {
this.Hide();
adminlogin S = new adminlogin(); 
S.Show();
} }
