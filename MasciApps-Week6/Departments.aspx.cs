using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

//Added
using MasciApps_Week6.Models;

namespace MasciApps_Week6
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "DepartmentID";
                Session["SortDirection"] = "ASC";

                this.GetDepartments();
            }
        }

        /**
         * <summary>
         * This method retrieves Departments from our db using EF
         * </summary>
         * @method GetDepartments()
         * @returns {void}
         */
        protected void GetDepartments()
        {

            using (DefaultConnection db = new DefaultConnection())
            {
                //query all departments from our ContosoModel
                var departments = (from allDepartments in db.Departments
                                   select new
                                   {
                                       allDepartments.DepartmentID,
                                       allDepartments.Name,
                                       allDepartments.Budget
                                   });
                string sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();
                //bind the results to the gridview
                DepartmentsGridView.DataSource = departments.AsQueryable().OrderBy(sortString).ToList();
                DepartmentsGridView.DataBind();

            }

        }

        /**
         * <summary>
         * 
         * </summary>
         * @method DepartmentsGridView_RowDataBound
         * @param {object} sender
         * @param {GridViewRowEventArgs} e
         * @returns {void}
         */
        protected void DepartmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) //if the row that is clicked is the header row
                {
                    LinkButton linkButton = new LinkButton();

                    for (int index = 0; index < DepartmentsGridView.Columns.Count; index++) //check each column for a click
                    {
                        if (DepartmentsGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            linkButton.Text = Session["SortDirection"].ToString() == "ASC" ?
                                " <i class='fa fa-caret-down'></i>" : " <i class='fa fa-caret-up'></i>";

                            e.Row.Cells[index].Controls.Add(linkButton); //add the new lnkButton to header cell
                        }
                    }
                }
            }
        }

        /**
         * <summary>
         * 
         * </summary>
         * @method DepartmentsGridView_Sorting
         * @param {object} sender
         * @param {GridViewSortEventArgs} e
         * @returns {void}
         */
        protected void DepartmentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            Session["SortColumn"] = e.SortExpression;//set sort column to clicked column header
            this.GetDepartments();//refresh grid
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";//toggle sort direction
        }

        /**
         * <summary>
         * 
         * </summary>
         * @method DepartmentsGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int deptID = Convert.ToInt32(DepartmentsGridView.DataKeys[e.RowIndex].Values["DepartmentID"]);
            using (DefaultConnection db = new DefaultConnection())
            {
                var deptToDelete = (from dept in db.Departments
                                    where dept.DepartmentID == deptID
                                    select dept).FirstOrDefault();

                db.Departments.Remove(deptToDelete);//remove dept from db
                db.SaveChanges();//save db
                this.GetDepartments();//refresh grid
            }
        }
    }
}