using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Required for connecting to Entity Framework db
using MasciApps_Week6.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace MasciApps_Week6
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if lading the page for the first time
            if (!IsPostBack)
            {
                //Session variables for sorting purposes
                Session["SortColumn"] = "StudentID";
                Session["SortDirection"] = "ASC";

                //Get students from Entity Framework db
                this.GetStudents();
            }
        }

        /**
         * <summary>
         * This method gets the stduent data from the db
         * </summary>
         * @method GetStudents
         * @returns {void}
         */
        protected void GetStudents()
        {
            //connect to Entity Framework
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                //create a query string to add to the LINQ Query
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //query the Students table using EF and Linq
                var Students = (from allStudents in db.Students
                                select new
                                {
                                    allStudents.StudentID,
                                    allStudents.LastName,
                                    allStudents.FirstMidName,
                                    allStudents.EnrollmentDate
                                });

                //bind the result to the gridview
                StudentsGridView.DataSource = Students.AsQueryable().OrderBy(SortString).ToList();
                StudentsGridView.DataBind();
            }

        }

        /**
         * <summary>
         * This method is used to delete a student record from the db using EF
         * </summary>         * 
         * @method StudentsGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
        protected void StudentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was selected for deletion
            int selectedRow = e.RowIndex;

            //get the selected StudentID using the grid's 
            int studentID = (int)StudentsGridView.DataKeys[selectedRow].Values["StudentID"];

            //use EF to find the selected student from the database and remove it
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                Student deletedStudent = (from studentRecords in db.Students
                                          where studentRecords.StudentID == studentID
                                          select studentRecords).FirstOrDefault();

                //remove the student record from the database
                db.Students.Remove(deletedStudent);

                //save chages to the database
                db.SaveChanges();

                //refresh the grid
                this.GetStudents();

            }

        }

        /**
         * <summary>
         * This method enables paging on our StudentsGridView
         * </summary>
         * @method StudentsGridView_PageIndexChanging
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
         */
        protected void StudentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Set the new page number
            StudentsGridView.PageIndex = e.NewPageIndex;

            //refresh the grid
            this.GetStudents();
        }

        /**
         * <summary>
         * 
         * </summary>
         * @method StudentsDropDownList_SelectedIndexChanged
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void StudentsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the new page size to the chosen option
            StudentsGridView.PageSize = Convert.ToInt32(StudentsDropDownList.SelectedValue);

            //refresh the grid
            this.GetStudents();
        }

        /**
         * <summary>
         * 
         * </summary>
         * @method StudentsGridView_Sorting
         * @param {object} sender
         * @param {GridViewSortEventArgs} e
         * @returns {void}
         */
        protected void StudentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //set the new page sort to the clicked column
            Session["SortColumn"] = e.SortExpression;

            //refresh the grid
            this.GetStudents();

            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        /**
         * <summary>
         * 
         * </summary>
         * @method StudentsGridView_RowDataBound
         * @param {object} sender
         * @param {GridViewRowEventArgs} e
         * @returns {void}
         */
        protected void StudentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) //if the row that is clicked is the header row
                {
                    LinkButton linkButton = new LinkButton();

                    for (int index = 0; index < StudentsGridView.Columns.Count; index++) //check each column for a click
                    {
                        if (StudentsGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            linkButton.Text = Session["SortDirection"].ToString() == "ASC" ?
                                " <i class='fa fa-caret-down'></i>" : " <i class='fa fa-caret-up'></i>";

                            e.Row.Cells[index].Controls.Add(linkButton); //add the new lnkButton to header cell
                        }
                    }
                }
            }
        }
    }
}