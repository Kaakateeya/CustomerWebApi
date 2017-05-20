using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WebapiApplication.ML;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using KaakateeyaDAL;
using System.Reflection;
using System.Net.Mail;
using System.Threading;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebapiApplication.UserDefinedTable;
using System.IO;
using WebapiApplication.ServiceReference1;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace WebapiApplication.DAL
{
    public class Commonclass
    {
        public static void SendMailSmtpMethod(List<Smtpemailsending> list, string fromemail)
        {
            try
            {
                string Password = string.Empty;

                string StrFromMail = ConfigurationManager.AppSettings["SendTutoringHoursFromMails"].ToString();
                string StrFromInfoMail = ConfigurationManager.AppSettings["StrFromInfoMail"].ToString();

                string StrPassword = ConfigurationManager.AppSettings["Password"].ToString();
                string StrInfoPassword = ConfigurationManager.AppSettings["infoPassword"].ToString();

                for (int i = 0; i < list.Count; i++)
                {
                    string[] toemails = list[i].recipients.Split(';');
                    MailMessage mailmessage = new MailMessage();
                    foreach (string str in toemails)
                    {
                        if (!string.IsNullOrEmpty(str) && str.Length > 0)
                        {
                            mailmessage.To.Add(str);
                        }
                    }

                    if (fromemail == "exp")
                    {
                        mailmessage.From = new MailAddress(StrFromMail);
                        Password = StrPassword;
                    }
                    else
                    {
                        mailmessage.From = new MailAddress(StrFromInfoMail);
                        Password = StrInfoPassword;
                    }

                    mailmessage.Subject = list[i].subject;
                    mailmessage.Body = list[i].body;
                    mailmessage.IsBodyHtml = true;
                    SendMail(mailmessage, Password);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("SendMailSmtpMethod", Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public static void SendMail(MailMessage message, string Password)
        {
            var thread = new Thread(() => SendMailThread(message, Password));
            thread.Start();
        }

        //private static void SendMailThread(MailMessage message, string Password)
        //{

        //    string StrMailServer = ConfigurationManager.AppSettings["MailHost"].ToString();

        //    int intPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailHostPort"].ToString());

        //    using (var server = new SmtpClient(StrMailServer.ToString(), Convert.ToInt32(intPort)))
        //    {
        //        server.EnableSsl = true;
        //        server.UseDefaultCredentials = true;
        //        server.Credentials = new System.Net.NetworkCredential((message.From).ToString(), Password);
        //        server.Send(message);
        //    }

        //}

        private static void SendMailThread(MailMessage message, string Password)
        {
            try
            {
                string StrMailServer = ConfigurationManager.AppSettings["MailHost"].ToString();

                int intPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailHostPort"].ToString());

                using (var server = new SmtpClient(StrMailServer.ToString(), Convert.ToInt32(intPort)))
                {
                    server.EnableSsl = true;
                    server.UseDefaultCredentials = true;
                    server.Credentials = new System.Net.NetworkCredential((message.From).ToString(), Password);
                    try
                    {
                        server.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public static DataTable returnListDatatable<T>(DataTable dt, List<T> items)
        {
            DataTable dtnew = dt;
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int flag = 0;
            foreach (T item in items)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                for (int i = 0; i < dtnew.Columns.Count; i++)
                {

                    for (int j = 0; j < Props.Length; j++)
                    {

                        if (dtnew.Columns[i].ColumnName == Props[j].Name)
                        {

                            dtnew.Rows[flag][dtnew.Columns[i].ColumnName] = Props[j].GetValue(item, null);
                        }
                    }
                }

                flag = +1;
            }
            return dtnew;
        }
        public static string Decrypt(string encrypted)
        {
            string Password;
            byte[] pwdhash;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            Password = "kaakateeyamatrimony";
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Password));
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;
            byte[] buff = Convert.FromBase64String(encrypted);
            string decrypted = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
            return (decrypted);
        }
        public static string Encrypt(string strProfileID)
        {
            string password;
            byte[] pwdhash;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            password = "kaakateeyamatrimony";
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(strProfileID);
            string encrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
            return (encrypted);
        }
        public static ArrayList convertdataTableToArrayList(DataSet dtSet)
        {
            ArrayList arraylist = new ArrayList();
            if (dtSet != null && dtSet.Tables.Count > 0)
            {
                for (int icount = 0; icount < dtSet.Tables.Count; icount++)
                {
                    arraylist.Add(JsonConvert.SerializeObject(dtSet.Tables[icount]));
                }
            }
            return arraylist;
        }

        public static string ViewProfileDecrypt(string inputText)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();

           // inputText = inputText.Replace(" ", "+");
            inputText = correctStringForBase64(inputText);

            byte[] encryptedData = Convert.FromBase64String(inputText);

            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);

            using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }
        }

        public static string correctStringForBase64(string _strencode)
        {
           _strencode = _strencode.Replace(" ", "+");
            string returnvalue = _strencode;
            if (_strencode.Length % 4 == 0)
            {
                returnvalue = _strencode;
            }
            else
            {
                for (int cnt = 0; cnt < 4 - (_strencode.Length % 4); cnt++)
                {
                   returnvalue = returnvalue + "=";
                }
            }
            return returnvalue;
        }

        private const string ENCRYPTION_KEY = "KMPL";
        private readonly static byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());
        public static string getEncryptedExpressIntrestString(string strActualText)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(strActualText);
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);
            using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }
        public static string ReturnEncryptLink(string type, string fromProfileID, string toprofileID)
        {
            if (!string.IsNullOrEmpty(fromProfileID) && !string.IsNullOrEmpty(toprofileID))
                return getEncryptedExpressIntrestString("FromProfileID=" + fromProfileID + "&" + "ToProfileID=" + toprofileID + "&" + "Flag=" + (type == "Accept" ? 1 : 0));
            else
                return null;
        }
        public static CustSearchMl CustomerViewProfileEncriptedText(CustSearchMl MobjViewprofile)
        {
            if (MobjViewprofile.TypeofInsert == "E")
            {
                MobjViewprofile.EncriptedText = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null), (!string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null));
                MobjViewprofile.EncryptedRejectFlagText = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null, !string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null);
                MobjViewprofile.EncriptedTextrvr = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null), (!string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null));
                MobjViewprofile.EncryptedRejectFlagTextrvr = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null, !string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null);
            }
            return MobjViewprofile;
        }
        public static string createTicketEncriptedText(string fromCustID, string TocustID) { return getEncryptedExpressIntrestString("FromProfileID=" + TocustID + "&" + "ToProfileID=" + fromCustID + "&" + "Flag=" + 1); }
        public static string GlobalImgPath = "http://d16o2fcjgzj2wp.cloudfront.net/";


        public static DataTable returndt(string commaseperate, DataTable dt, string colname, string tName)
        {
            dt = new DataTable(tName); dt.Rows.Clear(); dt.Columns.Add(colname);
            if (!string.IsNullOrEmpty(commaseperate) && commaseperate != "null")
            {
                string[] strarray = commaseperate.Split(',');
                foreach (var i in strarray) { dt.Rows.Add(i); }
            }

            return dt;
        }
        public static DataTable returndatatable(int? nullable, DataTable dt, string colname, string tName)
        {
            dt = new DataTable(tName);
            dt.Rows.Clear();
            dt.Columns.Add(colname);
            if (nullable != null)
            {
                dt.Rows.Add(nullable);
            }
            return dt;
        }
        public static void ApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type)
        {
            new StaticPagesDAL().DApplicationErrorLog(ErrorSpName, ErrorMessage, CustID, PageName, Type, "[dbo].[usp_ApplicationErrorLog]");
            SqlConnection.ClearAllPools();
        }
        public static void PaymentSMS(DataTable dt, string SendPhonenumber)
        {
            string strMobilenumber = "9392696969";
            ServiceSoapClient cc = new ServiceSoapClient();
            if (dt != null && dt.Rows.Count > 0)
            {
                strMobilenumber = !string.IsNullOrEmpty(dt.Rows[0]["CustomerMobile"].ToString()) ? dt.Rows[0]["CustomerMobile"].ToString() : "9392696969";
            }
            try
            {
                string result = cc.SendTextSMS("ykrishna", "summary$1", strMobilenumber, "Please Contact Me to know more about special Diamond Package " + SendPhonenumber, "smscntry");
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public static void ResendMobileSMS(int? iCountryID, int? iCCode, string MobileNumber, string strMobileverf)
        {
            ServiceSoapClient cc = new ServiceSoapClient();
            if (iCountryID != 1)
            {
                string strMobileOther = iCCode + MobileNumber;
                string result = cc.SendTextSMS("yrd", "01291954", strMobileOther, "Greeting from Kaakateeya.com ! Your pin Number is " + strMobileverf + " Use this PIN to verify your primary mobile", "smscntry");
            }
            else
            {
                string result1 = cc.SendTextSMS("ykrishna", "summary$1", MobileNumber, "Greeting from Kaakateeya.com ! Your pin Number is " + strMobileverf + " Use this PIN to verify your primary mobile", "smscntry");
            }

            SqlConnection.ClearAllPools();
        }

        public static string S3bucketname = ConfigurationManager.AppSettings["bucketName"];
        public static string S3PhotoPath = ConfigurationManager.AppSettings["PhotoPath"];

        public static bool S3upload(string filePath, string keyName)
        {
            //filePath = "D://KaakateeyaMainProject//Kaakateeya//Development_Kaakateeya//kaakateeyaWeb//access//Images//ProfilePics//KMPL_71668_Images//img2.jpg";
            try
            {
                TransferUtility fileTransferUtility = new
                    TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.APSouth1));

                //TransferUtility utility = new TransferUtility();
                //utility.UploadDirectory(directoryPath, bucketName);

                // 1. Upload a file, file name is used as the object key name.
                //fileTransferUtility.Upload(filePath, bucketName);
                //Console.WriteLine("Upload 1 completed");

                //// 2. Specify object key name explicitly.
                //fileTransferUtility.Upload(filePath,
                //                          bucketName, keyName);
                //Console.WriteLine("Upload 2 completed");

                //// 3. Upload data from a type of System.IO.Stream.
                //using (FileStream fileToUpload =
                //    new FileStream(filePath, FileMode.Open, FileAccess.Read))
                //{
                //    fileTransferUtility.Upload(fileToUpload,
                //                               bucketName, keyName);
                //}
                //Console.WriteLine("Upload 3 completed");

                // 4.Specify advanced settings/options.
                TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = S3bucketname,
                    FilePath = filePath,
                    StorageClass = S3StorageClass.ReducedRedundancy,
                    PartSize = 6291456, // 6 MB.
                    Key = keyName,
                    CannedACL = S3CannedACL.PublicRead
                };
                fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                fileTransferUtilityRequest.Metadata.Add("param2", "Value2");
                fileTransferUtility.Upload(fileTransferUtilityRequest);

                return true;
            }
            catch (AmazonS3Exception s3Exception)
            {
                return false;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }

        }


        public static string gethorophotoS3(string cust_id, string HoroscopeImageName)
        {

            Int64? int64null = null;

            Int64? custid = !string.IsNullOrEmpty(cust_id) ? Convert.ToInt64(cust_id) : int64null;
            string strCustDtryName = cust_id + "_HaroscopeImage";
            // string custDtryPath = !string.IsNullOrEmpty(S3PhotoPath) ? (HttpContext.Current.Server.MapPath("~\\Images\\HoroscopeImages\\")) + strCustDtryName : (HttpContext.Current.Server.MapPath("~\\access\\Images\\HoroscopeImages\\")) + strCustDtryName;

            string path = string.Empty;
            if (!string.IsNullOrEmpty(HoroscopeImageName))
            {
                string[] strextension = !string.IsNullOrEmpty(HoroscopeImageName) ? (HoroscopeImageName).Split(new string[] { "HaroscopeImage." }, StringSplitOptions.None) : null;
                string imgpath = !string.IsNullOrEmpty(S3PhotoPath) ? S3PhotoPath : "../../access/";
                path = imgpath + "Images/HoroscopeImages/" + cust_id + "_HaroscopeImage/" + cust_id + "_HaroscopeImage." + strextension[1];
            }
            else
            {
                path = !string.IsNullOrEmpty(S3PhotoPath) ? S3PhotoPath + "Images/customernoimages/Horo_no.jpg" : "../../Customer_new/images/Horo_no.jpg";
            }

            SqlConnection.ClearAllPools();
            return path;
        }


    }
}