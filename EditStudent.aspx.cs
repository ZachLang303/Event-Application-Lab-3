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
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // Searches for a Student in the System
        protected void btnSearchStudent_Click(object sender, EventArgs e)
        {
            // Ensures the search textboxes are not empty
            if (txtFirstName.Text == "" || txtLastName.Text == "")
            {
                tblSearchFeedback.Visible = true;

            }
            else
            {
                // Checks to see if the student is in the system
                String sqlQuery = "Select Count(1) from [Student] where [FirstName] = @FirstName AND [LastName] = @LastName";
                String sqlStudentID = "Select [StudentID] from [Student] where [FirstName] = @FirstName AND [LastName] = @LastName";

                SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlCommand sqlCommand2 = new SqlCommand(sqlStudentID, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
                sqlCommand2.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sqlCommand2.Parameters.AddWithValue("@LastName", txtLastName.Text);

                sqlConnection.Open();

                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                String studFirstName = "";
                String studLastName = "";

                // If the student is in the system brings the user to the edit student table
                if (count == 1)
                {
                    string studentID = sqlCommand2.ExecuteScalar().ToString();
                    Session["studentID"] = studentID;
                    sqlConnection.Close();

                    tblStudentSearch.Visible = false;
                    tblEditStudent.Visible = true;
                    tblSearchFeedback.Visible = false;

                    String sqlEditStudent = "Select FirstName, LastName, Age, LunchTicket, Notes, TeacherID, TshirtSize, TshirtColor from Student where StudentID = ('" + studentID + "')";
                    SqlCommand sqlCommand3 = new SqlCommand(sqlEditStudent, sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader queryResults = sqlCommand3.ExecuteReader();

                    // Fills the textboxes in the edit student table with the students current information
                    while (queryResults.Read() == true)
                    {

                        Student selectedStudent = new Student(queryResults["FirstName"].ToString(),
                            queryResults["LastName"].ToString(),
                            Int32.Parse(queryResults["Age"].ToString()),
                            Int32.Parse(queryResults["LunchTicket"].ToString()),
                            queryResults["Notes"].ToString(),
                            queryResults["TshirtSize"].ToString(),
                            queryResults["TshirtColor"].ToString(),
                            Int32.Parse(queryResults["TeacherID"].ToString()));

                        txtbxFirstName.Text = selectedStudent.FirstNameProperty;
                        txtbxLastName.Text = selectedStudent.LastNameProperty;
                        txtbxAge.Text = selectedStudent.AgeProperty.ToString();
                        txtbxNotes.Text = selectedStudent.NotesProperty;

                        studFirstName = selectedStudent.FirstNameProperty;
                        studLastName = selectedStudent.LastNameProperty;

                        if (selectedStudent.LunchTicketProperty == 1)
                        {
                            chbxLunchTicket.Checked = true;
                        }
                        else
                        {
                            chbxLunchTicket.Checked = false;
                        }
                        listShirtColor.SelectedValue = selectedStudent.TshirtColorPropery;
                        listShirtSize.SelectedValue = selectedStudent.TshirtSizeProperty;

                        String sqlteacherName = "SELECT Teacher.FirstName + ' ' + Teacher.LastName as teacherName " +
                            "FROM Student INNER JOIN Teacher ON Student.TeacherID = Teacher.TeacherID WHERE (Student.StudentID = " + studentID + ")";
                        SqlCommand sqlCommand4 = new SqlCommand(sqlteacherName, sqlConnect);
                        sqlConnect.Open();

                        string teacherName = sqlCommand4.ExecuteScalar().ToString();
                        ddlTeacherList.SelectedValue = teacherName;

                        sqlConnect.Close();
                    }

                    tblSelectedStudent.Visible = true;
                    lblSelectedStudent.Text = "You are Currently Editing " + studFirstName + " " + studLastName + "'s Information";

                }
                // If the student is not in the system returns an error message
                else
                {
                    tblSearchFeedback.Visible = true;
                }

                sqlConnection.Close();

            }
        }

        // Brings the user back to the edit student search page
        protected void btnChangeStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditStudent.aspx");

        }

        // Updates a students information
        protected void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            String studentID = Session["studentID"].ToString();
            String sqlUpdate = "UPDATE Student SET [FirstName] = @FirstName, [LastName] = @LastName, [Age] = @Age, [Notes] = @Notes, " +
                "[LunchTicket] = @LunchTicket, [TeacherID] = @Teacher, [TshirtSize] = @TshirtSize, [TshirtColor] = @TshirtColor " +
                "WHERE StudentID = ('" + studentID + "')";
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());
            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtbxFirstName.Text));
            sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtbxLastName.Text));
            sqlCommand.Parameters.AddWithValue("@Age", HttpUtility.HtmlEncode(txtbxAge.Text));

            int lunchTicket = 0;
            if (chbxLunchTicket.Checked == true)
            {
                lunchTicket = 1;
            }
            sqlCommand.Parameters.AddWithValue("@LunchTicket", lunchTicket);
            sqlCommand.Parameters.AddWithValue("@Teacher", ddlTeacherList.SelectedIndex + 1);
            sqlCommand.Parameters.AddWithValue("@TshirtSize", listShirtSize.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@TshirtColor", listShirtColor.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@Notes", HttpUtility.HtmlEncode(txtbxNotes.Text));

            sqlConnection.Open();

            adapter.UpdateCommand = sqlCommand;
            adapter.UpdateCommand.ExecuteNonQuery();

            sqlCommand.Dispose();

            sqlConnection.Close();

            Session["studentID"] = null;

            Response.Redirect("EditStudent.aspx");

        }
    }
}