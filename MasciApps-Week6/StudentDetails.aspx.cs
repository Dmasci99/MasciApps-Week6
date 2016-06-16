using MasciApps_Week6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasciApps_Week6
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString.Count > 0)
            {
                this.GetStudent();
            }
        }

        /**
         * <summary>
         * 
         * </summary>
         * @method GetStudent()
         * @returns {void}
         */
        protected void GetStudent()
        {
            //populate the form with existing student record (pulling from the queryString)
            int studentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            //connect to the db with EF
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a student instance with the StudentID from the URL parameter
                Student updateStudent = (from student in db.Students
                                         where student.StudentID == studentID
                                         select student).FirstOrDefault();

                //map the student properties to the form controls
                if (updateStudent != null)
                {
                    LastNameTextBox.Text = updateStudent.LastName;
                    FirstNameTextBox.Text = updateStudent.FirstMidName;
                    EnrollmentDateTextBox.Text = updateStudent.EnrollmentDate.ToString("yyyy-MM-dd");
                    LastNameTextBox.Text = updateStudent.LastName;
                }

                //update the student
            }

        }

        protected void ContactCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Students.aspx");
        }

        protected void ContactSaveButton_Click(object sender, EventArgs e)
        {
            //use EF to connect to the Server
            using (DefaultConnection db = new DefaultConnection())
            {
                //use the student model to save a new record
                Student newStudent = new Student()
                {
                    LastName = LastNameTextBox.Text,
                    FirstMidName = FirstNameTextBox.Text,
                    EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text)
                };

                //adding the new student to the collection
                db.Students.Add(newStudent);

                //run at insert command
                db.SaveChanges();

                Response.Redirect("~/Students.aspx");
            }
        }
    }
}