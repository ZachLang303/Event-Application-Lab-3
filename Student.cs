using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{

    public class Student
    {
        public int studentID;
        private String firstName;
        private String lastName;
        private int age;
        private bool lunchTicket;
        private String notes;
        public String tshirtSize;
        public String tshirtColor;
        public int teacherID;

        private static int nextStudentID = 1;

        public Student(String firstName, String lastName, int age, int lunchTicket, String notes, String tshirtSize, String tshirtColor, int teacherID)
        {
            this.studentID = nextStudentID;
            nextStudentID++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            if (lunchTicket == 1)
            {
                this.lunchTicket = true;
            }
            else
                this.lunchTicket = false;
            this.notes = notes;
            this.tshirtColor = tshirtColor;
            this.tshirtSize = tshirtSize;
            this.teacherID = teacherID;
        }

        public Student(String firstName, String lastName, int age, bool lunchTicket, String notes, String tshirtSize, String tshirtColor, int teacherID)
        {
            this.studentID = nextStudentID;
            nextStudentID++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.lunchTicket = lunchTicket;
            this.notes = notes;
            this.tshirtColor = tshirtColor;
            this.tshirtSize = tshirtSize;
            this.teacherID = teacherID;
        }

        public Student(String firstName, String lastName, int age, int lunchTicket, String tshirtSize, String tshirtColor, int teacherID)
        {
            this.studentID = nextStudentID;
            nextStudentID++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            if (lunchTicket == 1)
            {
                this.lunchTicket = true;
            }
            else
                this.lunchTicket = false;
            this.tshirtSize = tshirtSize;
            this.tshirtColor = tshirtColor;
            this.teacherID = teacherID;
        }

        // Getter and Setter Methods

        public string FirstNameProperty
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastNameProperty
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int AgeProperty
        {
            get { return age; }
            set { age = value; }
        }

        public int LunchTicketProperty
        {
            get
            {
                if (lunchTicket == true)
                {
                    return 1;
                }
                else
                    return 0;
            }
        }
        public string NotesProperty
        {
            get { return notes; }
            set { notes = value; }
        }
        public string TshirtSizeProperty
        {
            get { return tshirtSize; }
            set { tshirtSize = value; }
        }
        public string TshirtColorPropery
        {
            get { return tshirtColor; }
            set { tshirtColor = value; }
        }
        public int TeacherIDProperty
        {

            get { return teacherID; }
            set { teacherID = value; }
        }
        public bool lunchTicketProperty
        {
            get { return lunchTicket; }
            set { lunchTicket = value; }
        }
    }
}