using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Event_Application_Lab_2;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Lab2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                login.Visible = false;
                logout.Visible = true;
                lblLoggedInUser.Text = "Current User: " + Session["Username"].ToString();
            }
        }

        // Logs the user into the system
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int count = 0;

            // Checks the simple credentials table for a username and password
            // This is used for so non-teachers can still login to the system
            if (count == 0)
            {
                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "JeremyEzellLab3";
                sqlCommand.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                sqlConnection.Open();

                SqlDataReader loginResults = sqlCommand.ExecuteReader();
                if (loginResults.Read())
                {
                    count++;
                }
                sqlConnection.Close();
            }

            // If non non-teacher account is found checks the AUTH database for a teacher login
            if (count == 0)
            {
                // connect to database to retrieve stored password string
                try
                {

                    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                    sc.Open();
                    System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
                    findPass.Connection = sc;
                    // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
                    findPass.CommandText = "select PasswordHash from Pass where Username = @Username";
                    findPass.Parameters.Add(new SqlParameter("@Username", HttpUtility.HtmlEncode(txtUsername.Text)));

                    SqlDataReader reader = findPass.ExecuteReader(); // create a reader

                    if (reader.HasRows) // if the username exists, it will continue
                    {
                        while (reader.Read()) // this will read the single record that matches the entered username
                        {
                            string storedHash = reader["PasswordHash"].ToString(); // store the database password into this variable

                            if (PasswordHash.ValidatePassword(txtPassword.Text, storedHash)) // if the entered password matches what is stored, it will show success
                            {
                                count = 1;
                                btnLogin.Enabled = false;
                                txtUsername.Enabled = false;
                                txtPassword.Enabled = false;
                            }
                        }
                    }

                    sc.Close();
                }
                catch
                {
                    lblLoginFeedback.Text = "Database Error.";
                }

            }

            // Checks to make sure the username and password are valid
            if (count == 1)
            {
                Session["Username"] = txtUsername.Text;
                login.Visible = false;
                logout.Visible = true;
                lblLoggedInUser.Text = "Current User: " + Session["Username"].ToString();
            }
            else
            {
                lblLoginFeedback.Text = "Incorrect Username and/or Password! Please try again!";
            }
        }

        protected void lnkCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("createUser.aspx", false);
        }

        // logs the user out of the system
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            logout.Visible = false;
            login.Visible = true;
            Response.Redirect("MainMenu.aspx");
        }

        // Brings the to the main menu
        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");

        }

        // Brings the user to the Register Event page
        protected void btnRegisterEvent_Click(object sender, EventArgs e)
        {
            // Checks to make sure the user is logged into the system
            if (Session["UserName"] == null)
            {
                lblLoginFeedback.Text = "Please log in to access this feature!";
            }
            else
            {
                Response.Redirect("RegisterEvent.aspx");
            }
        }

        // Brings the user to the Add Student Page
        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Checks to make sure the user is logged into the system
            if (Session["UserName"] == null)
            {
                lblLoginFeedback.Text = "Please log in to access this feature!";
            }
            else
            {
                Response.Redirect("NewStudent.aspx");
            }

        }

        // Brings the User to the Edit Student Page
        protected void btnEditStudent_Click(object sender, EventArgs e)
        {
            // Checks to make sure the user is logged into the system
            if (Session["UserName"] == null)
            {
                lblLoginFeedback.Text = "Please log in to access this feature!";
            }
            else
            {
                Response.Redirect("EditStudent.aspx");
            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e) { 
            Response.Redirect("AddNewUserNavigation.aspx");
        } 
    }
}