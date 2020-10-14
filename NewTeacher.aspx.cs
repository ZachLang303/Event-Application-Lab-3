using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Event_Application_Lab_2
{
    public partial class NewTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Clears all Information in the text boxes
        protected void btnClearInfo_Click(object sender, EventArgs e)
        {
            txtbxFirstName.Text = null;
            txtbxLastName.Text = null;
            txtbxEmail.Text = null;
            chbxLunchTicket.Checked = false;
            txtbxgradetaught.Text = null;
            listShirtColor.SelectedIndex = -1;
            listShirtSize.SelectedIndex = -1;
            ddlSchoolList.SelectedIndex = -1;

            lblConfirmation.Visible = false;
        }

        // Auto fills a teachers personal and shirt information
        // Does not auto fill a username and password. The user must enter these to be secure. 
        protected void btnPopulateFields_Click(object sender, EventArgs e)
        {
            txtbxFirstName.Text = "LeAndre";
            txtbxLastName.Text = "Sanders";
            txtbxEmail.Text = "LeAndreSanders@gmail.com";
            txtbxgradetaught.Text = "8";

            chbxLunchTicket.Checked = true;
            listShirtColor.SelectedIndex = 2;
            listShirtSize.SelectedIndex = 2;
            ddlSchoolList.SelectedIndex = 1;

            lblConfirmation.Visible = false;
        }

        // Enters a new teacher into the system and creates a new user account
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            // Tests if the teacher is already in the system
            String sqlQuery = "Select Count(1) from [Teacher] where [FirstName] = @FirstName AND [LastName] = @LastName";

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtbxFirstName.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtbxLastName.Text));

            sqlConnection.Open();

            int teacherNamecount = Convert.ToInt32(sqlCommand.ExecuteScalar());

            SqlConnection sqlConnection3 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

            // Tests if the username is available
            String sqlQuery3 = "Select Count(1) from [Person] where [Username] = @Username";

            SqlCommand sqlCommand3 = new SqlCommand(sqlQuery3, sqlConnection3);

            sqlCommand3.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtNewUsername.Text));

            sqlConnection.Close();

            sqlConnection3.Open();

            int userNameCount = Convert.ToInt32(sqlCommand3.ExecuteScalar());

            sqlConnection3.Close();

            sqlConnection.Open();


            // Checks to make sure the teacher isn't a duplicit
            if (userNameCount == 0 && teacherNamecount == 0)
            {

                string connectionString;
                SqlConnection cnn;
                SqlCommand sqlCommand2;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["Lab3"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "Insert into Teacher(FirstName,LastName,Email,LunchTicket,TshirtSize,TshirtColor, GradeTaught, SchoolID) values(@FirstName, @Lastname, @Email, ";
                sql += "@lunchTicket, @shirtsize, @shirtcolor, @gradetaught, @school)";

                sqlCommand2 = new SqlCommand(sql, cnn);

                cnn.Open();

                // Converts the lunchTicket checkbox to an integer in order to be stored in the database
                int lunchTicket = 0;

                if (chbxLunchTicket.Checked)
                {
                    lunchTicket = 1;
                }

                // Inserts the data from the new teacher page into the database
                sqlCommand2.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtbxFirstName.Text));
                sqlCommand2.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtbxLastName.Text));
                sqlCommand2.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtbxEmail.Text));
                sqlCommand2.Parameters.AddWithValue("@lunchTicket", lunchTicket);
                sqlCommand2.Parameters.AddWithValue("@shirtsize", HttpUtility.HtmlEncode(listShirtSize.Text));
                sqlCommand2.Parameters.AddWithValue("@shirtcolor", HttpUtility.HtmlEncode(txtbxEmail.Text));
                sqlCommand2.Parameters.AddWithValue("@gradetaught", HttpUtility.HtmlEncode(txtbxgradetaught.Text));
                sqlCommand2.Parameters.AddWithValue("@school", ddlSchoolList.SelectedValue);

                sqlCommand2.ExecuteNonQuery();

                sqlCommand2.Dispose();
                cnn.Close();

                sqlConnection.Close();

                lblConfirmation.Visible = true;
            }

            // If the teacher isn't in the system and the username is available inputs the data into the database
            if (teacherNamecount == 0 && userNameCount == 0)
            {
                SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                sc.Open();

                SqlCommand createUser = new SqlCommand();
                createUser.Connection = sc;
                // INSERT USER RECORD
                createUser.CommandText = "insert into[dbo].[Person] values(@FName, @LName, @Username, 'Teacher')";
                createUser.Parameters.Add(new SqlParameter("@FName", HttpUtility.HtmlEncode(txtbxFirstName.Text)));
                createUser.Parameters.Add(new SqlParameter("@LName", HttpUtility.HtmlEncode(txtbxLastName.Text)));
                createUser.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtNewUsername.Text)));
                createUser.ExecuteNonQuery();

                System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
                setPass.Connection = sc;
                // INSERT PASSWORD RECORD AND CONNECT TO USER
                setPass.CommandText = "insert into[dbo].[Pass] values((select max(userid) from person), @Username, @Password)";
                setPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtNewUsername.Text)));
                setPass.Parameters.Add(new SqlParameter("@Password", HttpUtility.HtmlEncode(PasswordHash.HashPassword(txtNewPassword.Text)))); // hash entered password
                setPass.ExecuteNonQuery();

                sc.Close();
                // Tells the user they successfully created a new user
                MessageBox.Show("Successfuly Created User! Please log in the upper left");
                Response.Redirect("MainMenu.aspx");
            }
            if (teacherNamecount != 0)
            {
                MessageBox.Show("Teacher is already in the System. Please Enter a different Teacher!");
                lblConfirmation.Visible = false;
            } else if (userNameCount != 0)
            {
                MessageBox.Show("Username is taken. Please select a new one!");
                lblConfirmation.Visible = false;
            }


            // Clears the textboxes
            txtbxFirstName.Text = null;
            txtNewUsername = null;
            txtbxLastName.Text = null;
            txtbxEmail.Text = null;
            chbxLunchTicket.Checked = false;
            txtbxgradetaught.Text = null;
            listShirtColor.SelectedIndex = -1;
            listShirtSize.SelectedIndex = -1;
            ddlSchoolList.SelectedIndex = -1;
        }
    }
}