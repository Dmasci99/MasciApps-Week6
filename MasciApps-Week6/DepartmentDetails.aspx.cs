using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Added
using MasciApps_Week6.Models;

namespace MasciApps_Week6
{
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString.Count > 0)
            {
                this.GetDepartment();
            }
        }
        /**
         * <summary>
         * This method gets the department based on the QueryString and populates the form.
         * </summary>
         * @method GetStudent
         * @returns {void}
         */
        protected void GetDepartment()
        {
            int deptID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                //select dept from db
                var deptToGet = (from dept in db.Departments
                                 where dept.DepartmentID == deptID
                                 select dept).FirstOrDefault();
                if (deptToGet != null)//populate form controls
                {
                    NameTextBox.Text = deptToGet.Name;
                    BudgetTextBox.Text = Convert.ToString(deptToGet.Budget);
                }
            }
        }

        /**
         * <summary>
         * This method saves the new Department record to the db OR updates exising record.
         * </summary>
         * @method DepartmentSaveButton_Click
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void DepartmentSaveButton_Click(object sender, EventArgs e)
        {
            using (DefaultConnectionEF db = new DefaultConnectionEF())
            {
                Department newDept = new Department();
                int deptID = -1;

                if (Request.QueryString.Count > 0)
                {
                    deptID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                    newDept = (from dept in db.Departments
                               where dept.DepartmentID == deptID
                               select dept).FirstOrDefault();
                }
                newDept.Name = NameTextBox.Text;
                newDept.Budget = Convert.ToDecimal(BudgetTextBox.Text);

                if (deptID == -1)
                    db.Departments.Add(newDept);//add new dept to db
                                                //otherwise update existing

                db.SaveChanges();//save db - also updates and inserts
                Response.Redirect("~/Departments.aspx");//redirect                
            }
        }

        /**
         * <summary>
         * This method redirects the user to the Departments.aspx page when clicking the cancel button.
         * </summary>
         * @method DepartmentCancelButton_Click
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void DepartmentCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Departments.aspx");
        }
    }
}