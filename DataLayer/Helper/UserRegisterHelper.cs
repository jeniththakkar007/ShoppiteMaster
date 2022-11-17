using DataLayer.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;

public class UserRegisterHelper
{
    public string message = "";

    private Entities db = new Entities();
    private EncryptionHelper eh = new EncryptionHelper();
    private Product_Helper ph = new Product_Helper();

    public string getuserip()
    {
        string ip = "";

        string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ipAddress))
        {
            ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        ip = ipAddress;

        return ip;
    }

    public string register(string username, string password, string email)
    {
        User usernameExists = db.Users.FirstOrDefault(u => u.Username == username);

        if (usernameExists != null)
        {
            message = "Account already Exists. Please try another username.";
            return message;
        }

        User EmailExists = db.Users.FirstOrDefault(u => u.Email == email);

        if (EmailExists != null)
        {
            message = "Email already Exists. Please try another Email.";
            return message;
        }

        if (usernameExists == null && EmailExists == null)
        {
            User createUser = new User();

            createUser.Username = username;
            createUser.Password = eh.Encrypt(password);
            createUser.Email = email;
            createUser.CreatedDate = DateTime.Now;

            db.Users.Add(createUser);
            db.SaveChanges();

            if (createUser != null)
            {
                message = "Success";
            }
        }

        return message;
    }

    public void changepassword(string username, string password)
    {
        string ps = this.eh.Encrypt(password);
        User us = db.Users.FirstOrDefault(u => u.Username == username);

        us.Password = ps;
        db.SaveChanges();
    }

    public string login(string username, string password, bool rememberme,bool isAdmin = false)
    {
        var orgid = ph.GetOrgID();
        string ps = this.eh.Encrypt(password);
        User userValidate = new User();
        if (!isAdmin)
        {
            userValidate = db.Users.FirstOrDefault(u => u.Username == username && u.Password == ps && u.OrgId == orgid);
        }
        else
        {
            userValidate = db.Users.FirstOrDefault(u => u.Username == username && u.Password == ps);
        }

        if (userValidate != null)
        {
            UserActivation userActivationCheck = db.UserActivations.FirstOrDefault(u => u.UserId == userValidate.UserId);

            if (userActivationCheck != null)
            {
                message = "User is locked out.";
                return message;
            }
            else

            {
                message = "Success";
                userValidate.LastLoginDate = DateTime.Now;
                db.SaveChanges();
                FormsAuthentication.RedirectFromLoginPage(username, rememberme);
            }
        }
        else

        {
            message = "Username and/or password is incorrect.";
            return message;
        }

        return message;
    }

    public void userlockout(string username)
    {
        User us = db.Users.FirstOrDefault(u => u.Username == username);

        int id = 0;
        if (us != null)
        {
            id = us.UserId;

            UserActivation ua = db.UserActivations.FirstOrDefault(u => u.UserId == us.UserId);

            if (ua != null)
            {
                db.UserActivations.Remove(ua);
                db.SaveChanges();

                Users_Profile up = db.Users_Profile.FirstOrDefault(u => u.UserName == username);
                up.Status = "Active";
                db.SaveChanges();
            }
            else
            {
                UserActivation uainser = new UserActivation();

                uainser.UserId = id;
                uainser.ActivationCode = Guid.NewGuid();
                db.UserActivations.Add(uainser);
                db.SaveChanges();

                Users_Profile up = db.Users_Profile.FirstOrDefault(u => u.UserName == username);
                up.Status = "InActive";
                db.SaveChanges();
            }
        }
    }
}