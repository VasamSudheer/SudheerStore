﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace SudheerStore.CustomFilters
{
    public class CustomAuthenticationFilter: ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Check whether the Session is Empty or not, 
            //if the session is empty, Then set the Result as HttpUnauthorizedResult 
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserID"])))
            {
                filterContext.Result = new RedirectResult("/Account/LogOn");
            }
        }
        //This method Runs after the OnAuthentication method  
        //OnAuthenticationChallenge:- This Method gets called when Authentication or Authorization is 
        //failed and also this method is called after
        //Execution of Action Method but before rendering the View

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // We are checking Result is null or Result is HttpUnauthorizedResult which is set on OnAuthentication method
            // if Result is null or Result is HttpUnauthorizedResult then we are Redirecting to the Error View
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                //filterContext.Result = new ViewResult
                //{
                //    ViewName = "/Accounts/LogOn"
                //};


            }
        }
    }
}