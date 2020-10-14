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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Registers a teacher for an event
        protected void btnRegisterTeacher_Click(object sender, EventArgs e)
        {

            String sqlQuery = "SELECT COUNT(1) AS Expr1 FROM EventAttendance WHERE (TeacherID = " + (ddlTeacher.SelectedIndex + 1) + ") AND (EVENTID = " + (ddrEvent.SelectedIndex + 1) + ")";

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            sqlConnection.Open();

            int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

            if (count == 0)
            {

                string connectionString;
                SqlConnection cnn;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["Lab3"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "";

                command = new SqlCommand(sql, cnn);

                cnn.Open();

                sql = "Insert into EventAttendance(EventID, TeacherId) Values(" + (ddrEvent.SelectedIndex + 1) + "," + (ddlTeacher.SelectedIndex + 1) + ")";

                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();

                sqlConnection.Close();

                lblConfirmation.Text = "Teacher's Group Successfully Registered!";
                lblConfirmation.Visible = true;

            }
            else
            {
                MessageBox.Show("This teachers group is already registered for this event!");
                lblConfirmation.Visible = false;
            }
        }

        // Registers a volunteer for an event
        protected void btnRegisterVolunteer_Click(object sender, EventArgs e)
        {

            String sqlQuery = "SELECT COUNT(1) AS PersonnelCount FROM EventPresenters WHERE(PersonnelID = " + (ddlSelectVolunteer.SelectedIndex + 1) + ")";
            String sqlQuery2 = "SELECT COUNT(1) AS PersonnelCount FROM EventPresenters WHERE(PersonnelID = " + (ddlSelectVolunteer.SelectedIndex + 1) + ") AND (EventID = " + (ddrEvent.SelectedIndex + 1) + ")";

            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            SqlCommand sqlCommand2 = new SqlCommand(sqlQuery2, sqlConnection);

            sqlConnection.Open();

            int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
            int eventCount = Convert.ToInt32(sqlCommand2.ExecuteScalar());

            // Prevents a volunteer from registering for the same event or more than 2 events
            if(count < 2 && eventCount == 0)
            {
                string connectionString;
                SqlConnection cnn;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();

                connectionString = WebConfigurationManager.ConnectionStrings["Lab3"].ToString();

                cnn = new SqlConnection(connectionString);

                String sql = "";

                command = new SqlCommand(sql, cnn);

                cnn.Open();

                sql = "Insert into EventPresenters(EventID, PersonnelID) Values(" + (ddrEvent.SelectedIndex + 1) + "," + (ddlSelectVolunteer.SelectedIndex + 1) + ")";

                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                cnn.Close();

                sqlConnection.Close();

                lblConfirmation.Text = "Event Personnel Successfully Registered!";
                lblConfirmation.Visible = true;
            }
            // Error Message if volunteer is registered for 2 events
            else if (count >= 2)
            {
                MessageBox.Show("This volunteer is already registerd for two events!");
                lblConfirmation.Visible = false;
            }
            // Error Message if the volunteer is registered for the this event already
            else
            {
                MessageBox.Show("This volunteer is already registerd for this event!");
                lblConfirmation.Visible = false;
            }

        }

        // Shows all events in the system
        protected void btnViewEvents_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT TOP(1000)[EventID] as 'Event ID',[EventName] as 'Event Name',[EventDate] " +
                "as Date,[Location] FROM [Event]";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdOptions.DataSource = dtForGridView;
            grdOptions.DataBind();

            sqlConnect.Close();
            lblConfirmation.Visible = false;

        }

        // Shows all teachers in the system
        protected void btnViewTeachers_Click(object sender, EventArgs e)
        {

            String sqlQuery = "SELECT TOP(1000)[TeacherID] as 'Teacher ID',[FirstName] +' ' + [LastName] as Name,[Email] " +
                ",[LunchTicket] as 'Lunch (1 = yes)' ,[TshirtSize] as 'Shirt Size',[TshirtColor] " +
                "as 'Shirt Color' FROM[Teacher]";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdOptions.DataSource = dtForGridView;
            grdOptions.DataBind();

            sqlConnect.Close();
            lblConfirmation.Visible = false;

        }

        // Shows all volunteers in the system
        protected void btnViewVoluneers_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT TOP (1000) [PersonnelID] as 'Personnel ID',[FirstName] + ' ' + [LastName] " +
                "as Name,[Email],[PhoneNumber] as 'Phone Number',[PersonnelType] as Type,[TshirtSize] as 'Shirt Size',[TshirtColor] as 'Shirt Color' " +
                "FROM [EventPersonnel]";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdOptions.DataSource = dtForGridView;
            grdOptions.DataBind();

            sqlConnect.Close();
            lblConfirmation.Visible = false;
        }
    }
}