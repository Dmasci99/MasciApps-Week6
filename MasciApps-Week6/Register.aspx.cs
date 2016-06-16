using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Added - required for Identity
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace MasciApps_Week6
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // create new user obeject
            var user = new IdentityUser()
            {
                UserName = UserNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };

            IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

            if (result.Succeeded)
            {
                // authenticate user and login
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication; // to manage authentications
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie); // create an Identity for user
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity); // Signin the Identity user

                // redirect to the Main Menu
                Response.Redirect("~/MainMenu.aspx");
            }
            else
            {
                // display error in the div#AlertFlash
                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }

        }
    }
}