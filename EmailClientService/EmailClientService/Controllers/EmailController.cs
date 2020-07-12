using EmailClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EmailClientService.Controllers
{
    public class EmailController : ApiController
    {
        [HttpGet]
        public FolderResponseModel GetAllEmailFolders(FolderRequestModel request)
        {
            FolderResponseModel objResponse = new FolderResponseModel();
            try { 
            if (request != null)
            {
                objResponse = APIManager.EmailManager.GetAllEmailFolders(request);
            }

            }
            catch (Exception ex)
            {
            }
            return objResponse; ;
        }


        [HttpGet]
        public List<EmailResponseModel> GetAllEmailsByFolderID(EmailRequestModel request)
        {
            List<EmailResponseModel> objResponse = new List<EmailResponseModel>();
            try { 
            if (request != null)
            {
                objResponse = APIManager.EmailManager.GetAllEmailsByFolderID(request).ToList();
            }

        }
            catch (Exception ex)
            {
            }
            return objResponse; ;
        }

        [HttpGet]
        public List<EmailResponseModel> GetAllEmails(EmailRequestModel request)
        {
            List<EmailResponseModel> lstResponse = new List<EmailResponseModel>();
            try { 
            if (request != null)
            {
                    lstResponse = APIManager.EmailManager.GetAllEmails(request);
            }

            }
            catch (Exception ex)
            {
            }
            return lstResponse; 
        }

        [HttpPost]
        public EmailAddResponseModel AddEmail(EmailAddRequestModel request)
        {
            EmailAddResponseModel objResponse = new EmailAddResponseModel();
            try { 
            if (request != null)
            {
                objResponse = APIManager.EmailManager.AddEmail(request);
            }

            }
            catch (Exception ex)
            {
            }
            return objResponse; ;
        }

        [HttpDelete]
        public EmailDeleteResponseModel DeleteEmail(EmailDeleteRequestModel request)
        {
            EmailDeleteResponseModel objResponse = new EmailDeleteResponseModel();
            try { 
            if (request != null)
            {
                objResponse = APIManager.EmailManager.DeleteEmail(request);
            }

            }
            catch (Exception ex)
            {
            }
            return objResponse; ;
        }
    }
}