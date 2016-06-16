using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasciApps_Week6.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            setActivePageLink();
        }

        /**
         * This method sets the appropriate navbar link to "active". 
         *  
         * @method setActivePageLink
         * @return void
         */
        private void setActivePageLink()
        {
            switch (Page.Title)
            {
                case "Students": students.Attributes.Add("class", "active"); break;
                case "Courses": courses.Attributes.Add("class", "active"); break;
                case "Departments": departments.Attributes.Add("class", "active"); break;
                case "Contact": contact.Attributes.Add("class", "active"); break;
            }
        }
    }
}