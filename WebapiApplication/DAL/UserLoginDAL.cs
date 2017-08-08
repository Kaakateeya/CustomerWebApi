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
namespace WebapiApplication.DAL
{
    public class UserLoginDAL
    {
        public List<userLoginML> DGetLogininformationdetails(CustLoginMl Mobj)
        {
            int status = 0;
            List<userLoginML> userLogin = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                SqlCommand command = new SqlCommand("Usp_CheckCustLogin_Customer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", Mobj.Username);
                command.Parameters.AddWithValue("@Password", Commonclass.Encrypt(Mobj.Password));
                command.Parameters.AddWithValue("@iflag", Mobj.iflag);
                SqlParameter outputParamStatus = command.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                SqlDataReader reader;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        userLogin = new List<userLoginML>
                    {
                        new userLoginML
                        {

                            CustID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : 0,

                            FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null,
                           
                            LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null,
                            
                            ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : null,
                            
                            CasteName = (reader["CasteName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteName")) : null,

                            CasteID = (reader["CasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : 0,

                            MotherTongueName = (reader["MotherTongueName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongueName")) : null,

                            GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0,

                            Email = (reader["Email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : null,

                            MotherTongueID = (reader["MotherTongueID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MotherTongueID")) : 0,

                            ReligionID = (reader["ReligionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReligionID")) : 0,

                            ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null,

                            VerificationCode = (reader["VerificationCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VerificationCode")) : null,

                            FamilyID = (reader["FamilyID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FamilyID")) : 0,

                            PaidStatus = (reader["PaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidStatus")) : 0,

                            PartnerCastedata = (reader["PartnerCastedata"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PartnerCastedata")) : null,

                            PhotoStatus = (reader["PhotoStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoStatus")) : 0,

                            PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0,

                            ViewProfileFlag = (reader["ViewProfileFlag"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ViewProfileFlag")) : false,

                            ResigNophotoFlgPaid = (reader["ResigNophotoFlgPaid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ResigNophotoFlgPaid")) : 0,

                            SuccessStoryFlag = (reader["SuccessStoryFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuccessStoryFlag")) : 0,

                            Emailverified = (reader["Emailverified"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Emailverified")) : 0,

                            strProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null,

                            Flag = (reader["Flag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Flag")) : 0,

                            cust_emailid = (reader["cust_emailid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_emailid")) : 0,
                            
                            email = (reader["email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : null,
                            
                            isemailverified = (reader["isemailverified"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("isemailverified")) : false,

                            cust_contant_id = (reader["cust_contant_id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_contant_id")) : 0,
                            
                            number = (reader["number"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("number")) : null,
                            
                            isnumberverifed = (reader["isnumberverifed"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("isnumberverifed")) : false,
                            
                            MObileverficationcode = (reader["MObileverficationcode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MObileverficationcode")) : null,

                            ProfilePic=(reader["ProfilePic"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfilePic")) : null
                        },
                    };
                    }
                }

                reader.Close();
                status = (int)command.Parameters["@Status"].Value;

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("Usp_CheckCustLogin_Customer", Convert.ToString(EX.Message), null, "DGetLogininformationdetails", null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return userLogin;
        }
    }
}