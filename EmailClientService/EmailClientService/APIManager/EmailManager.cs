using EmailClientRepo;
using EmailClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailClientService.APIManager
{
    public class EmailManager
    {


        public static FolderResponseModel GetAllEmailFolders(FolderRequestModel request)
        {
            FolderResponseModel objResponse = new FolderResponseModel();
            try
            {
                if (request != null)
                {
                    List<EmailFolderType> listEmailFolderType = EmailClientRepo.Repository.GetAllEmailFolders();
                }
            }
            catch (Exception ex)
            {
            }
            return objResponse; ;
        }



        public static List<EmailResponseModel> GetAllEmailsByFolderID(EmailRequestModel request)
        {
            List<EmailResponseModel> objResponse = new List<EmailResponseModel>();

            if (request != null)
            {
                List<EmailMessage> objEmails = EmailClientRepo.Repository.GetAllEmailsByFolderID(request.FolderId);

                if (objEmails != null)
                {
                    foreach (var response in objEmails)
                    {
                        objResponse.Add(new EmailResponseModel { Body = response.Body, EmailId = response.ID, Subject = response.Subject, UserId = response.UserId.Value });
                    }

                }
            }

            return objResponse; ;
        }


        public static List<EmailResponseModel> GetAllEmails(EmailRequestModel request)
        {
            List<EmailResponseModel> objResponse = new List<EmailResponseModel>();

            if (request != null)
            {
                List<EmailMessage> objEmails = EmailClientRepo.Repository.GetAllEmails();

                if (objEmails != null)
                {
                    foreach (var response in objEmails)
                    {
                        objResponse.Add(new EmailResponseModel { Body = response.Body, EmailId = response.ID, Subject = response.Subject, UserId = response.UserId.Value });
                    }

                }
            }

            return objResponse; ;
        }


        public static EmailAddResponseModel AddEmail(EmailAddRequestModel request)
        {
            EmailAddResponseModel objResponse = new EmailAddResponseModel();

            if (request != null)
            {
                EmailMessage dbEmailMessage = new EmailMessage();
                EmailMessage listEmails = EmailClientRepo.Repository.AddEmail(dbEmailMessage);
            }

            return objResponse; ;
        }


        public static EmailDeleteResponseModel DeleteEmail(EmailDeleteRequestModel request)
        {
            EmailDeleteResponseModel objResponse = new EmailDeleteResponseModel();

            if (request != null)
            {
                List<EmailMessage> listEmails = EmailClientRepo.Repository.GetAllEmails();
            }



            return objResponse; ;
        }
    }
}