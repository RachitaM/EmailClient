using EmailClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmailClientService.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public LoginResponseModel Login(LoginRequestModel request)
        {
            LoginResponseModel objResponse = new LoginResponseModel();
            try
            {

                if (request != null)
                {
                    string error = validateLoginRequest(request);

                    if (string.IsNullOrWhiteSpace(error))
                    {
                        objResponse = APIManager.UserManager.Login(request);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return objResponse;
        }

        [HttpGet]
        public ProfileResponseModel GetProfileByUserName(ProfileRequestModel request)
        {
            ProfileResponseModel objResponse = new ProfileResponseModel();
            try
            {
                if (request != null)
                {
                    objResponse = APIManager.UserManager.GetProfileByUsername(request);
                }
            }
            catch (Exception ex)
            {
            }
            return objResponse;
        }

        public string validateLoginRequest(LoginRequestModel request)
        {
            string error = string.Empty;
            try
            {
                if (request != null)
                {
                    if (String.IsNullOrWhiteSpace(request.UserName))
                    {
                        error = "Please enter username";
                    }
                    else if (String.IsNullOrWhiteSpace(request.Password))
                    {
                        error = "Please enter password";
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return error;
        }
    }
}