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
            showLinks();
            setActivePageLink();
        }

        /**
         * <summary>
         * This method sets the appropriate navbar link to "active". 
         * </summary>
         * @method setActivePageLink
         * @returns {void}
         */
        private void setActivePageLink()
        {
            switch (Page.Title)
            {
                case "Main Menu": mainMenu.Attributes.Add("class", "active"); break;
                case "Students": students.Attributes.Add("class", "active"); break;
                case "Courses": courses.Attributes.Add("class", "active"); break;
                case "Departments": departments.Attributes.Add("class", "active"); break;
                case "Contact": contact.Attributes.Add("class", "active"); break;
                case "Login": login.Attributes.Add("class", "active"); break;
                case "Register": register.Attributes.Add("class", "active"); break;
            }
        }

        /**
         * <summary>
         * This method determines what Links to show in our Header: dependant on User Authorization.
         * </summary>
         * @method showLinks
         * @returns {void}
         */ 
        private void showLinks()
        {
            
        }
    }
}