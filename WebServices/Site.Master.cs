﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wsep182.services;
using wsep182.Domain;

namespace WebServices
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] != null)
            {
                User u = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);

                if (u != null && u.getState() is Admin)
                {
                    adminPanelLink.Visible = true;
                    MyStoresLink.Visible = true;
                    LoginRegisterLinks.Visible = false;
                }
                else if (u != null && u.getState() is LogedIn)
                {
                    MyStoresLink.Visible = true;
                    LoginRegisterLinks.Visible = false;
                }
            }
        }
    }
}