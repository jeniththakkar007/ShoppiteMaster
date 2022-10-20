//using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CheckFile
/// </summary>
public class CheckFile
{
	public CheckFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    string ftppath = "ftp://ftp.msonlinegroup.com/";

    string username = "msonline";
    string password = "70.9dVGlY:Que7";
    string domainname = "mycherry2.msonlinegroup.com/";

    string returnpath = "https://mycherry2.msonlinegroup.com";

    //string ftpfolderpath = domainname + "ftpfolder paramater";
    string path = "";

    //public string AyncUploadImages(AsyncFileUpload FileUpload1)
    //{

    //    string uploadFileName = "";
    //    if (FileUpload1.HasFile)
    //    {
    //        string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
    //        if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png")
    //        {
    //            uploadFileName = Guid.NewGuid().ToString() + ext;
    //        }
    //        //FTP Server URL.
    //        string ftp = ftppath;

    //        //FTP Folder name. Leave blank if you want to upload to root folder.
    //        string ftpFolder = domainname + "/DynamicImage/" + uploadFileName;

    //        byte[] fileBytes = null;

    //        //Read the FileName and convert it to Byte array.
    //        string fileName = Path.GetFileName(uploadFileName);
    //        FileUpload1.PostedFile.InputStream.Seek(0, SeekOrigin.Begin);
    //        using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
    //        {
    //            fileBytes = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
    //        }
    //        try
    //        {
    //            //Create FTP Request.
    //            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder);
    //            request.Method = WebRequestMethods.Ftp.UploadFile;

    //            //Enter FTP Server credentials.
    //            request.Credentials = new NetworkCredential(username, password);
    //            request.ContentLength = fileBytes.Length;
    //            request.UsePassive = true;
    //            request.UseBinary = true;
    //            request.ServicePoint.ConnectionLimit = fileBytes.Length;
    //            request.EnableSsl = false;
    //            using (Stream requestStream = request.GetRequestStream())
    //            {
    //                requestStream.Write(fileBytes, 0, fileBytes.Length);
    //                requestStream.Close();
    //            }
    //            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    //            path = returnpath + "/DynamicImage/" + uploadFileName;


    //            response.Close();
    //        }
    //        catch (WebException ex)
    //        {
    //            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
    //        }
    //    }

    //    return path;
    //}


    public string UploadImages(HttpPostedFile postedFile)
    {
        string uploadFileName = "";
        string ext = Path.GetExtension(postedFile.FileName).ToLower();
        if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png" || ext == ".pdf" ||
            ext == ".docx" || ext == ".pptx" || ext == ".xlsx" || ext == ".doc" || ext == ".xls" || ext == ".ppt")
        {
            uploadFileName = Guid.NewGuid().ToString() + ext;
        }
        string ftp = ftppath;
        string ftpFolder = domainname + "/DynamicImage/" + uploadFileName;
        string contentType = postedFile.ContentType;
        byte[] fileBytes = null;
        string fileName = Path.GetFileName(uploadFileName);
        postedFile.InputStream.Seek(0, SeekOrigin.Begin);
        using (var binaryReader = new BinaryReader(postedFile.InputStream))
        {
            fileBytes = binaryReader.ReadBytes(postedFile.ContentLength);
        }
        try
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.ContentLength = fileBytes.Length;
            request.UsePassive = true;
            request.UseBinary = true;
            request.ServicePoint.ConnectionLimit = fileBytes.Length;
            request.EnableSsl = false;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                requestStream.Close();
            }
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            path = returnpath + "/DynamicImage/" + uploadFileName;
            response.Close();
        }
        catch (WebException ex)
        {
            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
        }
        return path;
    }
    public string UploadImages(FileUpload FileUpload1)
    {
       
        string uploadFileName = "";
        if (FileUpload1.HasFile)
        {
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png" || ext == ".pdf" || ext == ".docx" || ext == ".pptx" || ext == ".xlsx" || ext == ".doc" || ext == ".xls" || ext == ".ppt")
            {
                uploadFileName = Guid.NewGuid().ToString() + ext;
            }
            //FTP Server URL.
            string ftp = ftppath;
 
            //FTP Folder name. Leave blank if you want to upload to root folder.
            string ftpFolder = domainname + "/DynamicImage/" + uploadFileName;
 
            byte[] fileBytes = null;
 
            //Read the FileName and convert it to Byte array.
            string fileName = Path.GetFileName(uploadFileName);
            FileUpload1.PostedFile.InputStream.Seek(0, SeekOrigin.Begin);
            using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                fileBytes = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
            }
            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder);
                request.Method = WebRequestMethods.Ftp.UploadFile;
 
                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential(username, password);
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                path = returnpath + "/DynamicImage/" + uploadFileName;

              
                response.Close();
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }
 
        return path;
    }


    public string UploadVideos(FileUpload FileUpload1)
    {

        string uploadFileName = "";
        if (FileUpload1.HasFile)
        {
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (ext == ".mp3" || ext == ".MP3")
            {
                uploadFileName = Guid.NewGuid().ToString() + ext;
            }
            //FTP Server URL.
            string ftp = ftppath;

            //FTP Folder name. Leave blank if you want to upload to root folder.
            string ftpFolder = domainname + "/DynamicImage/" + uploadFileName;

            byte[] fileBytes = null;

            //Read the FileName and convert it to Byte array.
            string fileName = Path.GetFileName(uploadFileName);
            FileUpload1.PostedFile.InputStream.Seek(0, SeekOrigin.Begin);
            using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                fileBytes = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
            }
            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential(username, password);
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                path = domainname + uploadFileName;
                response.Close();
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }

        return path;
    }


    public string UploadFiles(FileUpload FileUpload1)
    {

        string uploadFileName = "";
        if (FileUpload1.HasFile)
        {
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            if (ext == ".pdf" || ext == ".docx" || ext == ".pptx" || ext == ".xlsx" || ext == ".doc" || ext == ".xls" || ext == ".ppt")
            {
                uploadFileName = Guid.NewGuid().ToString() + ext;
            }
            //FTP Server URL.
            string ftp = ftppath;

            //FTP Folder name. Leave blank if you want to upload to root folder.
            string ftpFolder = domainname + "/DynamicImage/" + uploadFileName;

            byte[] fileBytes = null;

            //Read the FileName and convert it to Byte array.
            string fileName = Path.GetFileName(uploadFileName);
            FileUpload1.PostedFile.InputStream.Seek(0, SeekOrigin.Begin);
            using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                fileBytes = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
            }
            try
            {
                //Create FTP Request.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //Enter FTP Server credentials.
                request.Credentials = new NetworkCredential(username, password);
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                path = domainname + uploadFileName;
                response.Close();
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }

        return path;
    }



    public string checkfilesize(FileUpload FileUpload1, int imgheight, int imgwidth)
    {
        System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
        int height = img.Height;
        int width = img.Width;
        decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
        //if (size > 100)
        //{
        //    path = "File size must not exceed 100 KB.";
            
        //}
        if (height > imgheight || width > imgwidth)
        {
            path = "Height and Width must be matched selected option.";
           


        }
        else
        {

            path = "Success";
        }
        return path;
    }
}
