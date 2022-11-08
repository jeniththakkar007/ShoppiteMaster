using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DataLayer.Helper
{
    public class AWS_Helper
    {

        //string bucketName = "amenvato/envatoallproject";
        //string awsAccessKey = "AKI............";
        //string awsSecretKey = "+8Bo..................................";

        string bucketName = "shoppite";
        string filename = "ammamarketing";

        //Access Key ID:
        //AKIAJCYZXRDRE4KPC4TQ
        //Secret Access Key:
        //ZDN2WyruK7Q5ByJogX9hm4QA27MmbmUCDi8CA1hX

        IAmazonS3 client = new AmazonS3Client("AKIA6IUF7JEED5QSS6Z5", "IRaP1i51oge4I5g1jFFUx22TvD7VCAYBB7kBBhsH", RegionEndpoint.APSouth1);

        //IAmazonS3 client = new AmazonS3Client("AKIAJCYZXRDRE4KPC4TQ", "ZDN2WyruK7Q5ByJogX9hm4QA27MmbmUCDi8CA1hX", RegionEndpoint.USEast2);

        public string uploadfile(FileUpload FileUpload1,string uploadFileName = "")
        {

            if (string.IsNullOrEmpty(uploadFileName)) {
                uploadFileName = @"Common\files\"+ FileUpload1.FileName;
            }
            string returnfilename = "";



            if (FileUpload1.HasFile)
            {

                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                
                PutObjectRequest request = new PutObjectRequest()
                {
                    InputStream = FileUpload1.PostedFile.InputStream,
                    BucketName = bucketName,
                    ContentType = GetContentType(ext),
                    CannedACL = S3CannedACL.PublicRead,
                    Key = uploadFileName// <-- in S3 key represents a path  
                };

                PutObjectResponse response = client.PutObject(request);


                returnfilename = "https://shoppite.s3.ap-south-1.amazonaws.com/" + uploadFileName;
            }

            return returnfilename;
        }


        public string uploadfilemulti(HttpPostedFile postedFile, string uploadFileName = "")
        {

            string returnfilename = "";
            if (string.IsNullOrEmpty(uploadFileName))
            {
                uploadFileName = @"Markets/Common/files/" + postedFile.FileName;
            }
            if (postedFile.ContentLength > 0)
            {
                string ext = Path.GetExtension(postedFile.FileName).ToLower();

                PutObjectRequest request = new PutObjectRequest()
                {
                    InputStream = postedFile.InputStream,
                    BucketName = bucketName,
                    ContentType = GetContentType(ext),
                    CannedACL = S3CannedACL.PublicRead,
                    Key = uploadFileName // <-- in S3 key represents a path  
                };

                PutObjectResponse response = client.PutObject(request);


                returnfilename = "https://shoppite.s3.ap-south-1.amazonaws.com/" + uploadFileName;
            }

            return returnfilename;
        }


        public string GetContentType(string fileExtension)
        {
            string contentType = string.Empty;
            switch (fileExtension)
            {
                case ".bmp": contentType = "image/bmp"; break;
                case ".jpeg": contentType = "image/jpeg"; break;
                case ".jpg": contentType = "image/jpg"; break;
                case ".gif": contentType = "image/gif"; break;
                case ".tiff": contentType = "image/tiff"; break;
                case ".png": contentType = "image/png"; break;
                case ".plain": contentType = "text/plain"; break;
                case ".rtf": contentType = "text/rtf"; break;
                case ".msword": contentType = "application/msword"; break;
                case ".zip": contentType = "application/zip"; break;
                case ".mpeg": contentType = "audio/mpeg"; break;
                case ".pdf": contentType = "application/pdf"; break;
                case ".xgzip": contentType = "application/x-gzip"; break;
                case ".xcompressed": contentType = "application/x-compressed"; break;
            }
            return contentType;
        }

        string path = "";

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
}