using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailClientService.Models
{
    #region RequestModels

    public class ResponseBase
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ProfileRequestModel
    {
        public string UserName { get; set; }

    }

    public class FolderRequestModel
    {

    }

    public class EmailRequestModel
    {
        public int FolderId { get; set; }
    }

    public class EmailDeleteRequestModel
    {
        public long EmailId { get; set; }
    }

    public class EmailAddRequestModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public int FolderId { get; set; }
        public string EmailTo { get; set; }
    }
    #endregion

    #region ResponseModels
    public class LoginResponseModel : ResponseBase
    {
        public string Error { get; set; }
        public string Token { get; set; }
    }

    public class ProfileResponseModel : ResponseBase
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string ProfileId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
    }

    public class FolderResponseModel : ResponseBase
    {
        public string FolderName { get; set; }
        public string FolderDescription { get; set; }
    }

    public class EmailResponseModel : ResponseBase
    {
        public long UserId { get; set; }
        public long EmailFolderId { get; set; }
        public long EmailFolderName { get; set; }
        public long EmailId { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public List<string> Receipients { get; set; }
    }
    public class EmailDeleteResponseModel : ResponseBase
    {

    }
    public class EmailAddResponseModel : ResponseBase
    {

    }
    #endregion
}