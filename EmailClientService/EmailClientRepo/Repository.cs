using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClientRepo
{
    public class Repository
    {
        public static UserLogin Login(string userName, string password)
        {
            UserLogin objUser = null;
            using (var db = new EmailClientEntity())
            {
                objUser = db.UserLogins.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            }
            return objUser;
        }

        public static Profile GetProfileByUserName(string userName)
        {
            Profile objProfile = null;
            using (var db = new EmailClientEntity())
            {
                var objUser = db.UserLogins.Where(x => x.UserName == userName).FirstOrDefault();

                if (objUser != null)
                {
                    objProfile = db.Profiles.Where(x => x.UserId == objUser.ID).FirstOrDefault();
                }

            }
            return objProfile;
        }

        public static List<EmailFolderType> GetAllEmailFolders()
        {
            List<EmailFolderType> objEmailFolderType = null;
            using (var db = new EmailClientEntity())
            {
                objEmailFolderType = db.EmailFolderTypes.ToList();
            }
            return objEmailFolderType;
        }

        public static List<EmailMessage> GetAllEmailsByFolderID(long folderId)
        {
            List<EmailMessage> objEmailMessage = null;
            using (var db = new EmailClientEntity())
            {
                objEmailMessage = db.EmailMessages.Where(x => x.EmailFolderTypeID == folderId).ToList();
            }
            return objEmailMessage;
        }

        public static List<EmailMessage> GetAllEmails()
        {
            List<EmailMessage> objEmailMessage = null;
            using (var db = new EmailClientEntity())
            {
                objEmailMessage = db.EmailMessages.ToList();
            }
            return objEmailMessage;
        }

        public static EmailMessage AddEmail(EmailMessage request)
        {
            EmailMessage objEmailMessage = null;
            using (var db = new EmailClientEntity())
            {
                db.EmailMessages.Add(request);
                db.SaveChanges();
            }
            return objEmailMessage;
        }

        public static EmailMessage DeleteEmail(int emailId)
        {
            EmailMessage objEmailMessage = null;
            using (var db = new EmailClientEntity())
            {
                objEmailMessage = db.EmailMessages.Where(x => x.ID == emailId).FirstOrDefault();
                objEmailMessage.IsDeleted = true;
                db.SaveChanges();
            }
            return objEmailMessage;
        }
    }
}
