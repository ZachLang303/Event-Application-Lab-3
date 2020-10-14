using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;

namespace Lab3
{
    public partial class NewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            String sqlQuery = "Select Count(1) from [Student] where [FirstName] = @FirstName AND [LastName] = @LastName";

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtbxFirstName.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtbxLastName.Text));

            sqlConnection.Open();

            int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

            // Checks to make sure the student isn't a duplicit
            if (count == 0) {
            
                string connectionString;
                SqlConnection cnn;
                SqlCommand sqlCommand2;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["Lab3"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "Insert into [Student] (FirstName, LastName, Age, LunchTicket, Notes, TeacherID, TshirtSize, TshirtColor) values(@FirstName, @LastName, @Age, @LunchTicket, @Notes, @Teacher, @TshirtSize, @TshirtColor)";

                sqlCommand2 = new SqlCommand(sql, cnn);

                cnn.Open();


                // Inserts the data from the new student page into the database

                sqlCommand2.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtbxFirstName.Text));
                sqlCommand2.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtbxLastName.Text));
                sqlCommand2.Parameters.AddWithValue("@Age", HttpUtility.HtmlEncode(txtbxAge.Text));
                
                // Converts the lunchTicket checkbox to an integer in order to be stored in the database
                int lunchTicket = 0;
                if (chbxLunchTicket.Checked == true)
                {
                    lunchTicket = 1;
                }
                sqlCommand2.Parameters.AddWithValue("@LunchTicket", lunchTicket);
                sqlCommand2.Parameters.AddWithValue("@Teacher", ddlTeacherList.SelectedIndex + 1);
                sqlCommand2.Parameters.AddWithValue("@TshirtSize", listShirtSize.SelectedValue);
                sqlCommand2.Parameters.AddWithValue("@TshirtColor", listShirtColor.SelectedValue);
                sqlCommand2.Parameters.AddWithValue("@Notes", HttpUtility.HtmlEncode(txtbxNotes.Text));

                sqlCommand2.ExecuteNonQuery();

                sqlCommand2.Dispose();
                cnn.Close();

                sqlConnection.Close();

                lblConfirmation.Visible = true;
            } 
            // Shows an error message if the student is already in the system
            else
            {
                MessageBox.Show("Student is already in the System. Please Enter a different Student!");
                lblConfirmation.Visible = false;
            }

            // Clears the textboxes
            txtbxFirstName.Text = null;
            txtbxLastName.Text = null;
            txtbxAge.Text = null;
            chbxLunchTicket.Checked = false;
            txtbxNotes.Text = null;
            listShirtColor.SelectedIndex = -1;
            listShirtSize.SelectedIndex = -1;
            ddlTeacherList.SelectedIndex = -1;

        }

        // Clears the fields
        protected void btnClearInfo_Click(object sender, EventArgs e)
        {
            txtbxFirstName.Text = null;
            txtbxLastName.Text = null;
            txtbxAge.Text = null;
            chbxLunchTicket.Checked = false;
            txtbxNotes.Text = null;
            listShirtColor.SelectedIndex = -1;
            listShirtSize.SelectedIndex = -1;
            ddlTeacherList.SelectedIndex = -1;

            lblConfirmation.Visible = false;
        }

        // Populates the fields automatically
        protected void btnPopulateFields_Click(object sender, EventArgs e)
        {
            txtbxFirstName.Text = "Nico";
            txtbxLastName.Text = "Ferrara";
            txtbxAge.Text = "21";
            txtbxNotes.Text = "Only eats butter";
            chbxLunchTicket.Checked = true;
            listShirtColor.SelectedIndex = 2;
            listShirtSize.SelectedIndex = 2;
            ddlTeacherList.SelectedIndex = 1;

            lblConfirmation.Visible = false;
        }
    }
}