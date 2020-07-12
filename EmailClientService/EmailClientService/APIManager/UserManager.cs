using EmailClientRepo;
using EmailClientService.JWTTokenValidation;
using EmailClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailClientService.APIManager
{
    public class UserManager
    {
        public static LoginResponseModel Login(LoginRequestModel request)
        {
            LoginResponseModel objResponse = new LoginResponseModel();
            try
            {
                if (request != null)
                {
                    UserLogin objUser = EmailClientRepo.Repository.Login(request.UserName, request.Password);

                    if (objUser != null && objUser.ID > 0)
                    {
                        objResponse.IsSuccess = true;
                        objResponse.Token = TokenManager.GenerateToken(request.UserName);
                    }
                    else
                    {
                        objResponse.IsSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return objResponse;
        }

        public static ProfileResponseModel GetProfileByUsername(ProfileRequestModel request)
        {
            ProfileResponseModel objResponse = new ProfileResponseModel();
            try
            {
                if (request != null)
                {
                    Profile objUser = EmailClientRepo.Repository.GetProfileByUserName(request.UserName);
                    if (objUser != null && objUser.ID > 0)
                    {
                        objResponse.IsSuccess = true;
                        objResponse.FName = objUser.FName;
                        objResponse.LName = objUser.LName;
                        objUser.MName = objUser.MName;
                        objUser.Address = objUser.Address;
                    }
                    else
                    {
                        objResponse.IsSuccess = false;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return objResponse;
        }
    }
}