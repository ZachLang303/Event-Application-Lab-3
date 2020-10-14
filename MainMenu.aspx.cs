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
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEventQuery_Click(object sender, EventArgs e)
        {
            grdSelected.Caption = "Selected Event";
            grdResults.Caption = "Registered Students/Teachers";
            grdResults2.Caption = "Registered Personnel";

            String sqlEventQuery = "SELECT EventName as Event, EventDate as 'Date & Time', Location from Event where EventID = " + +(ddlEvent.SelectedIndex + 1);

            String sqlQuery = "SELECT Student.FirstName + ' ' + Student.LastName as 'Student Name', Student.Notes as 'Student Notes', Teacher.FirstName + ' ' + Teacher.LastName " +
                "AS 'Teacher Name', Teacher.Email as Email, School.Name as School FROM Teacher Full Outer JOIN Student ON Teacher.TeacherID = Student.TeacherID FULL OUTER JOIN School " +
                "ON Teacher.SchoolID = School.SchoolID FULL OUTER JOIN EventAttendance ON Student.StudentID = EventAttendance.TeacherID FULL OUTER JOIN Event ON EventAttendance.EventID = Event.EventID " +
                "WHERE Event.EventID = " + (ddlEvent.SelectedIndex + 1);

            String sqlQuery2 = "SELECT EventPersonnel.FirstName + ' ' + EventPersonnel.LastName as 'Personnel Name', EventPersonnel.PersonnelType as Type, " +
                "EventPersonnel.Email, EventPersonnel.PhoneNumber as 'Phone Number' FROM Event INNER JOIN EventPresenters ON Event.EventID = EventPresenters.EventID " +
                "INNER JOIN EventPersonnel ON EventPresenters.PersonnelID = EventPersonnel.PersonnelID WHERE(Event.EventID = " + (ddlEvent.SelectedIndex + 1) + ")";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlDataAdapter sqlAdapter2 = new SqlDataAdapter(sqlEventQuery, sqlConnect);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);
            SqlDataAdapter sqlAdapter3 = new SqlDataAdapter(sqlQuery2, sqlConnect);

            DataTable dtForGridView2 = new DataTable();
            sqlAdapter2.Fill(dtForGridView2);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            DataTable dtForGridView3 = new DataTable();
            sqlAdapter3.Fill(dtForGridView3);

            grdResults2.DataSource = dtForGridView3;
            grdResults2.DataBind();

            grdSelected.DataSource = dtForGridView2;
            grdSelected.DataBind();

            grdResults.DataSource = dtForGridView;
            grdResults.DataBind();

            sqlConnect.Close();

            grdResults2.Visible = true;
        }

        protected void btnVolunteerQuery_Click(object sender, EventArgs e)
        {
            grdResults2.Visible = false;
            grdSelected.Caption = "Selected Personnel";
            grdResults.Caption = "Associated Events";
            grdResults2.Caption = "";

            String sqlVolunteerQuery = "SELECT FirstName + ' ' + LastName AS 'Personnel Name', PersonnelType as Type, Email, PhoneNumber as 'Phone Number' from EventPersonnel where PersonnelID = " + (ddlVolunteer.SelectedIndex + 1);

            String sqlQuery = "SELECT Event.EventName as Event, Event.EventDate as 'Date & Time', Event.Location as Location from EventPersonnel" +
                " INNER JOIN EventPresenters ON EventPersonnel.PersonnelID = EventPresenters.PersonnelID " +
                "INNER JOIN Event ON EventPresenters.EventID = Event.EventID where EventPersonnel.PersonnelID = " + (ddlVolunteer.SelectedIndex + 1);

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlDataAdapter sqlAdapter2 = new SqlDataAdapter(sqlVolunteerQuery, sqlConnect);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView2 = new DataTable();
            sqlAdapter2.Fill(dtForGridView2);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdSelected.DataSource = dtForGridView2;
            grdSelected.DataBind();

            grdResults.DataSource = dtForGridView;
            grdResults.DataBind();

            sqlConnect.Close();
        }

        protected void btnStudentQuery_Click(object sender, EventArgs e)
        {
            grdSelected.Caption = "Selected Student";
            grdResults.Caption = "Associated Events";
            grdResults2.Caption = "";

            grdResults2.Visible = false;

            String sqlStudentQuery = "SELECT Student.FirstName + ' ' + Student.LastName as 'Student Name', Student.Age, Student.Notes, " +
                "Teacher.FirstName + ' ' + Teacher.LastName as 'Teacher Name', School.Name as 'School' FROM Student INNER JOIN Teacher ON Student.TeacherID = " +
                "Teacher.TeacherID INNER JOIN School ON School.SchoolID = Teacher.SchoolID WHERE Student.StudentID = " + (ddlStudent.SelectedIndex + 1);

            String sqlQuery = "SELECT Event.EventName as Event, Event.EventDate as 'Date & Time', Event.Location FROM Event " +
                "INNER JOIN EventAttendance ON Event.EventID = EventAttendance.EventID " +
                "INNER JOIN Teacher ON EventAttendance.TeacherID = Teacher.TeacherID " +
                "INNER JOIN Student ON Teacher.TeacherID = Student.TeacherID WHERE (Student.StudentID = " + (ddlStudent.SelectedIndex + 1) + ") " +
                "ORDER BY Event.EventDate";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlDataAdapter sqlAdapter2 = new SqlDataAdapter(sqlStudentQuery, sqlConnect);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView2 = new DataTable();
            sqlAdapter2.Fill(dtForGridView2);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdSelected.DataSource = dtForGridView2;
            grdSelected.DataBind();

            grdResults.DataSource = dtForGridView;
            grdResults.DataBind();

            sqlConnect.Close();
        }

        protected void btnSelectTeacher_Click(object sender, EventArgs e)
        {
            grdSelected.Caption = "Selected Teacher";
            grdResults.Caption = "Associated Students";
            grdResults2.Caption = "";

            grdResults2.Visible = false;

            String sqlTeacherQuery = "SELECT Teacher.FirstName + ' ' + Teacher.LastName as 'Teacher Name', Teacher.Email, School.Name as School " +
                "FROM Teacher INNER JOIN School ON Teacher.SchoolID = School.SchoolID WHERE(Teacher.TeacherID = " + (ddlTeacher.SelectedIndex + 1) + ")";

            String sqlQuery = "SELECT Student.FirstName + ' ' + Student.LastName as 'Student Name', Student.Age, Student.Notes " +
                "FROM Teacher INNER JOIN Student ON Teacher.TeacherID = Student.TeacherID WHERE(Teacher.TeacherID = " + (ddlTeacher.SelectedIndex + 1)+ ")";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

            SqlDataAdapter sqlAdapter2 = new SqlDataAdapter(sqlTeacherQuery, sqlConnect);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView2 = new DataTable();
            sqlAdapter2.Fill(dtForGridView2);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdSelected.DataSource = dtForGridView2;
            grdSelected.DataBind();

            grdResults.DataSource = dtForGridView;
            grdResults.DataBind();

            sqlConnect.Close();

        }
    }
}