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
    public class CustomerSearch
    {
        public partnerInfoMl DgetPartnerpreferencedetails(int? CustID, int? EmpID, Int64? searchresultID, string spName)
        {
            List<partnerInfoMl> ds = new List<partnerInfoMl>();
            partnerInfoMl Mobjresult = new partnerInfoMl();
            SqlDataReader reader = null;
            SqlParameter[] parm = new SqlParameter[5];
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@cust_Id", SqlDbType.Int);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@empid ", SqlDbType.Int);
                parm[1].Value = EmpID;
                parm[2] = new SqlParameter("@searchresultID", SqlDbType.BigInt);
                parm[2].Value = searchresultID;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();

                    var sqlCommand = con.CreateCommand();
                    sqlCommand.CommandTimeout = 120;

                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        if (searchresultID == null)
                        {
                            while (reader.Read())
                            {
                                Mobjresult.intCusID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                                Mobjresult.intGender = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNull;
                                Mobjresult.Agefrom = (reader["AgeMax"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("AgeMax"))).ToString() : null;
                                Mobjresult.Ageto = (reader["AgeMin"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("AgeMin"))).ToString() : null;
                                Mobjresult.Heightfrom = (reader["MaxHeight"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("MaxHeight"))).ToString() : null;
                                Mobjresult.Heightto = (reader["MinHeight"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("MinHeight"))).ToString() : null;
                                Mobjresult.Maritalstatus = (reader["maritalstatusid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("maritalstatusid")) : null;
                                Mobjresult.Religion = (reader["religionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("religionid")) : string.Empty;
                                Mobjresult.MotherTongue = (reader["MotherTongueID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongueID")) : string.Empty;
                                Mobjresult.Caste = (reader["casteid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("casteid")) : string.Empty;
                                Mobjresult.Complexion = (reader["complexionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("complexionid")) : string.Empty;
                                Mobjresult.bodytype = (reader["BodyTypeID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BodyTypeID")) : string.Empty;
                                Mobjresult.PhysicalStatusstring = (reader["physicalstatusid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("physicalstatusid")) : string.Empty;
                                Mobjresult.Educationcategory = (reader["EducationCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategoryID")) : string.Empty;
                                Mobjresult.Education = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupID")) : string.Empty;
                                Mobjresult.Professiongroup = (reader["ProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroup")) : string.Empty;
                                Mobjresult.Country = (reader["CountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryID")) : string.Empty;
                                Mobjresult.State = (reader["StateID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateID")) : string.Empty;
                                Mobjresult.Stars = (reader["StarLanguageID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StarLanguageID")) : string.Empty;
                                Mobjresult.Stars = (reader["PreferredStars"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PreferredStars")) : string.Empty;
                                Mobjresult.iManglinkKujaDosham = (reader["KujaDosham"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("KujaDosham")) : iNull;
                                Mobjresult.CasteText = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : string.Empty;
                            }
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Mobjresult.intCusID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : intNull;
                                Mobjresult.intGender = (reader["LookingforID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("LookingforID")) : iNull;
                                Mobjresult.Agefrom = (reader["ToAgeID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ToAgeID"))) : string.Empty;
                                Mobjresult.Ageto = (reader["FromAgeID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("FromAgeID"))) : string.Empty;
                                Mobjresult.Heightfrom = (reader["ToHeightID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ToHeightID"))) : string.Empty;
                                Mobjresult.Heightto = (reader["FromHeightID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("FromHeightID"))) : string.Empty;
                                Mobjresult.Maritalstatus = (reader["MaritalstatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalstatusID")) : null;
                                Mobjresult.Religion = (reader["ReligionID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionID")) : string.Empty;
                                Mobjresult.MotherTongue = (reader["MothertongueID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MothertongueID")) : string.Empty;
                                Mobjresult.Caste = (reader["CasteID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteID")) : string.Empty;
                                Mobjresult.Complexion = (reader["ComplexionId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ComplexionId")) : string.Empty;
                                Mobjresult.PhysicalStatusstring = (reader["PhysicalstatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhysicalstatusID")) : string.Empty;
                                Mobjresult.Educationcategory = (reader["EducationcategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationcategoryID")) : string.Empty;
                                Mobjresult.Education = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupID")) : string.Empty;
                                Mobjresult.Professiongroup = (reader["ProfessiongroupId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessiongroupId")) : string.Empty;
                                Mobjresult.Country = (reader["CountyWorkingInID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountyWorkingInID")) : string.Empty;
                                Mobjresult.State = (reader["StateWorkingInID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateWorkingInID")) : string.Empty;
                                Mobjresult.iStarID = (reader["StarId"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StarId")) : iNull;
                                Mobjresult.iStarLanguage = (reader["StarlanguageID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StarlanguageID")) : iNull;
                                Mobjresult.iManglinkKujaDosham = (reader["ManglikKujaDoshamID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ManglikKujaDoshamID")) : iNull;
                                Mobjresult.CasteText = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : string.Empty;
                                Mobjresult.Visastatus = (reader["VisastatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VisastatusID")) : string.Empty;
                                Mobjresult.iAnnualincome = (reader["Annualincome"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Annualincome")) : iNull;
                                Mobjresult.iFromSal = (reader["FromSal"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromSal")) : intNull;
                                Mobjresult.iToSal = (reader["Tosal"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Tosal")) : intNull;
                                Mobjresult.iDiet = (reader["DietID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DietID")) : iNull;
                                Mobjresult.i_Registrationdays = (reader["Registrationdays"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Registrationdays")) : iNull;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(CustID), "DgetPartnerpreferencedetails", null);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return Mobjresult;
        }
        public List<generalAdvanceSearchResult> GeneralandAdvancedSearch(PrimaryInformationMl search, string spName)
        {
            List<generalAdvanceSearchResult> listSearch = new List<generalAdvanceSearchResult>();
            SqlDataReader reader;
            SqlParameter[] parm = new SqlParameter[30];
            Int64? intNull = null;
            int? iNull = null;
            string strNP = "Not specified";
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@i_CustId", SqlDbType.Int);
                parm[0].Value = search.intCusID;
                parm[1] = new SqlParameter("@i_GenderId", SqlDbType.Int);
                parm[1].Value = search.intGender;
                parm[2] = new SqlParameter("@i_FromAge", SqlDbType.Int);
                parm[2].Value = search.FromAge;
                parm[3] = new SqlParameter("@i_ToAge", SqlDbType.Int);
                parm[3].Value = search.ToAge;
                parm[4] = new SqlParameter("@i_FromHeight", SqlDbType.Int);
                parm[4].Value = search.iFromHeight;
                parm[5] = new SqlParameter("@i_ToHeight", SqlDbType.Int);
                parm[5].Value = search.iToHeight;
                parm[6] = new SqlParameter("@i_ReligionId", SqlDbType.Int);
                parm[6].Value = search.intReligionID;
                parm[7] = new SqlParameter("@tbl_Caste", SqlDbType.Structured);
                parm[7].Value = Commonclass.returndt(search.Caste, search.dtCateIDs, "Caste", "CastIDs2");
                parm[8] = new SqlParameter("@tbl_Country", SqlDbType.Structured);
                parm[8].Value = Commonclass.returndt(search.Country, search.dtCountrylivingin, "Countrylivingin", "CountrylivinginIDs4");
                parm[9] = new SqlParameter("@tbl_Education", SqlDbType.Structured);
                parm[9].Value = Commonclass.returndt(search.Education, search.dtEducationGroup, "EducationGroup", "EducationGroupIDs8");
                parm[10] = new SqlParameter("@tbl_ProfessionGroup", SqlDbType.Structured);
                parm[10].Value = Commonclass.returndt(search.Professiongroup, search.dtProfessionGroup, "ProfessionGroup", "ProfessionGroupIDs09");
                parm[11] = new SqlParameter("@tbl_MotherTongue", SqlDbType.Structured);
                parm[11].Value = Commonclass.returndt(search.MotherTongue, search.dtMothertongue, "Mothertongue", "MothertongueIDs1");
                parm[12] = new SqlParameter("@i_Photoflag", SqlDbType.Int);
                parm[12].Value = search.intPhotoCount;
                parm[13] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[13].Value = search.StartIndex;
                parm[14] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[14].Value = search.EndIndex;
                parm[15] = new SqlParameter("@i_Registrationdays", SqlDbType.Int);
                parm[15].Value = search.i_Registrationdays;
                parm[16] = new SqlParameter("@tbl_MaritalStatus", SqlDbType.Structured);
                parm[16].Value = Commonclass.returndt(search.Maritalstatus, search.dtMaritalstatus, "Maritalstatus", "MaritalstatusIDs0");
                parm[17] = new SqlParameter("@i_PhysicalStatus", SqlDbType.Int);
                parm[17].Value = search.iPhysicalstatus;
                parm[18] = new SqlParameter("@tbl_Complexion", SqlDbType.Structured);
                parm[18].Value = Commonclass.returndt(search.Complexion, search.dtComplexion, "Complexion", "ComplexionIDs3");
                parm[19] = new SqlParameter("@tbl_EducationCategory", SqlDbType.Structured);
                parm[19].Value = Commonclass.returndt(search.Educationcategory, search.dtEduactionCat, "Educationcategory", "EducationcategoryIDs7");
                parm[20] = new SqlParameter("@tbl_LivingState", SqlDbType.Structured);
                parm[20].Value = Commonclass.returndt(search.State, search.dtStateLivingIn, "Statelivingin", "StatelivinginIDs5");
                parm[21] = new SqlParameter("@tbl_VisaStatus", SqlDbType.Structured);
                parm[21].Value = Commonclass.returndt(search.Visastatus, search.dtVisaStatus, "VisaStatus", "VisaStatusIDs6");
                parm[22] = new SqlParameter("@i_FromAnualIncome", SqlDbType.BigInt);
                parm[22].Value = search.iFromSal;
                parm[23] = new SqlParameter("@i_ToAnualIncome", SqlDbType.BigInt);
                parm[23].Value = search.iToSal;
                parm[24] = new SqlParameter("@tbl_StarLanguage", SqlDbType.Structured);
                parm[24].Value = Commonclass.returndatatable(search.iStarLanguage, search.dtStarLang, "StarLanguageIDs", "StarLanguageIDs11");
                parm[25] = new SqlParameter("@tbl_Star", SqlDbType.Structured);
                parm[25].Value = Commonclass.returndt(search.Stars, search.dtStar, "Star", "Stars");
                parm[26] = new SqlParameter("@b_isManglik", SqlDbType.Bit);
                parm[26].Value = search.iManglinkKujaDosham;
                parm[27] = new SqlParameter("@i_IsDiet", SqlDbType.Int);
                parm[27].Value = search.iDiet;
                parm[28] = new SqlParameter("@i_SalaryIncurrency", SqlDbType.Int);
                parm[28].Value = search.iAnnualincome;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    var sqlCommand = con.CreateCommand();
                    sqlCommand.CommandTimeout = 120;

                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            generalAdvanceSearchResult Mobjresult = new generalAdvanceSearchResult();
                            {
                                Mobjresult.intCusID = (reader["Cust_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                                Mobjresult.NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : strNP;
                                Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                                Mobjresult.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : strNP;
                                Mobjresult.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : strNP;
                                Mobjresult.ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : strNP;
                                Mobjresult.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : strNP;
                                Mobjresult.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : strNP;
                                Mobjresult.Location = (reader["Location"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : strNP;
                                Mobjresult.Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : strNP;
                                Mobjresult.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : strNP;
                                Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : 0;
                                Mobjresult.TotalPages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : 0;
                                Mobjresult.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                                Mobjresult.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0;
                                Mobjresult.placeofbirth = (reader["placeofbirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
                                Mobjresult.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0;
                                Mobjresult.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                                Mobjresult.MaritualStatus = (reader["MaritualStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : strNP;
                                Mobjresult.MaritalStatusId = (reader["MaritalStatusId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatusId")) : null;
                                Mobjresult.IsPaidMember = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
                                Mobjresult.mybookmarked = (reader["mybookmarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("mybookmarked")) : iNull;
                                Mobjresult.ExpressFlag = (reader["ExpressFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : iNull;
                                Mobjresult.ignode = (reader["ignode"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ignode")) : iNull;
                                Mobjresult.LogId = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.LogID = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.Photo = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : string.Empty;
                                Mobjresult.Photofullpath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : string.Empty;
                                Mobjresult.DistName = (reader["DistName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistName")) : string.Empty;
                                Mobjresult.strFirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : string.Empty;

                            }

                            listSearch.Add(Mobjresult);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), search.intCusID, "GeneralandAdvancedSearch", null);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSearch;
        }

        public List<QuicksearchResultML> ProfileIdsearch(ProfileIDSearch ProfileIDSearch, string spName)
        {
            List<QuicksearchResultML> listSearch = new List<QuicksearchResultML>();
            SqlDataReader reader = null;
            SqlParameter[] parm = new SqlParameter[10];
            Int64? intNull = null;
            int? iNull = null;
            string strNP = "Not specified";
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@i_PCustId", SqlDbType.Int);
                parm[0].Value = ProfileIDSearch.intCusID;
                parm[1] = new SqlParameter("@i_GenderId", SqlDbType.Int);
                parm[1].Value = ProfileIDSearch.intGender;
                parm[2] = new SqlParameter("@vc_LastName", SqlDbType.VarChar);
                parm[2].Value = ProfileIDSearch.strLastName;
                parm[3] = new SqlParameter("@vc_FirstName ", SqlDbType.VarChar);
                parm[3].Value = ProfileIDSearch.strFirstName;
                parm[4] = new SqlParameter("@vc_ProfileId", SqlDbType.VarChar);
                parm[4].Value = ProfileIDSearch.strProfileID;
                parm[5] = new SqlParameter("@i_CasteId", SqlDbType.VarChar);
                parm[5].Value = ProfileIDSearch.intCasteID;
                parm[6] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[6].Value = ProfileIDSearch.StartIndex;
                parm[7] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[7].Value = ProfileIDSearch.EndIndex;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();

                    var sqlCommand = con.CreateCommand();
                    sqlCommand.CommandTimeout = 120;

                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            QuicksearchResultML Mobjresult = new QuicksearchResultML();
                            {
                                Mobjresult.intCusID = (reader["Cust_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                                Mobjresult.NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : strNP;
                                Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                                Mobjresult.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : strNP;
                                Mobjresult.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : strNP;
                                Mobjresult.ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : strNP;
                                Mobjresult.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : strNP;
                                Mobjresult.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : strNP;
                                Mobjresult.Location = (reader["Location"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : strNP;
                                Mobjresult.Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : strNP;
                                Mobjresult.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : strNP;
                                Mobjresult.PhoneNumber = (reader["PhoneNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhoneNumber")) : strNP;
                                Mobjresult.Email = (reader["Email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : strNP;
                                Mobjresult.IsprofileMarked = (reader["IsprofileMarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsprofileMarked")) : 0;
                                Mobjresult.HoroscopeImage = (reader["HoroscopeImage"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroscopeImage")) : strNP;
                                Mobjresult.IsExpressIntrestMarked = (reader["IsExpressIntrestMarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsExpressIntrestMarked")) : 0;
                                Mobjresult.IsIntrested = (reader["IsIntrested"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsIntrested")) : 0;
                                Mobjresult.IsMessage = (reader["IsMessage"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsMessage")) : 0;
                                Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : 0;
                                Mobjresult.TotalPages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : 0;
                                Mobjresult.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                                Mobjresult.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0;
                                Mobjresult.placeofbirth = (reader["placeofbirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
                                Mobjresult.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0;
                                Mobjresult.iCasteID = (reader["iCasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCasteID")) : iNull;
                                Mobjresult.iStarID = (reader["iStarID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStarID")) : iNull;
                                Mobjresult.iCountryID = (reader["iCountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCountryID")) : iNull;
                                Mobjresult.iReligionID = (reader["iReligionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iReligionID")) : iNull;
                                Mobjresult.iProfessionID = (reader["iProfessionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iProfessionID")) : iNull;
                                Mobjresult.iProfessionGroupID = (reader["iProfessionGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iProfessionGroupID")) : iNull;
                                Mobjresult.iEducationGroupID = (reader["iEducationGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iEducationGroupID")) : iNull;
                                Mobjresult.iHeightInCentimeters = (reader["iHeightInCentimeters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iHeightInCentimeters")) : iNull;
                                Mobjresult.iStarLanguageID = (reader["iStarLanguageID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStarLanguageID")) : iNull;
                                Mobjresult.iCityID = (reader["iCityID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCityID")) : iNull;
                                Mobjresult.iStateID = (reader["iStateID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStateID")) : iNull;
                                Mobjresult.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                                Mobjresult.MaritualStatus = (reader["MaritualStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : strNP;
                                Mobjresult.MaritalStatusId = (reader["MaritalStatusId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatusId")) : null;
                                Mobjresult.IsPaidMember = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
                                Mobjresult.NoOfProfiles = (reader["NoOfProfiles"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfProfiles")) : iNull;
                                Mobjresult.mybookmarked = (reader["mybookmarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("mybookmarked")) : iNull;
                                Mobjresult.ExpressFlag = (reader["ExpressFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : iNull;
                                Mobjresult.ignode = (reader["ignode"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ignode")) : iNull;
                                Mobjresult.LogId = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.LogID = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.Photo = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : string.Empty;
                                Mobjresult.Photofullpath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : string.Empty;
                                Mobjresult.DistName = (reader["DistName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistName")) : string.Empty;
                            }

                            listSearch.Add(Mobjresult);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, "ProfileIdsearch", null);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSearch;
        }

        public int CustomerAdvanceGeneralProfileIDsearchSave(DataTable dataTable, long? intCusID, int? iupdateFlag, string spName, string strParam)
        {
            int intStatus = 0;
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;
            try
            {

                parm[0] = new SqlParameter(strParam, SqlDbType.Structured);
                parm[0].Value = dataTable;
                parm[1] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[1].Value = intCusID;
                parm[2] = new SqlParameter("@flage", SqlDbType.Int);
                parm[2].Value = iupdateFlag;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[3].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), null, "CustomerAdvanceGeneralProfileIDsearchSave", null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }
        public List<generalAdvanceSearchResult> CustomerGeneralandAdvancedSavedSearch(PrimaryInformationMl primaryInfo, DataTable dtTableValues, string SavedSearchSp, string saveParam, string searchSp)
        {
            int iResult = CustomerAdvanceGeneralProfileIDsearchSave(dtTableValues, primaryInfo.intCusID, primaryInfo.iupdateFlag, SavedSearchSp, saveParam);
            return GeneralandAdvancedSearch(primaryInfo, searchSp);
        }
        public List<QuicksearchResultML> CustomerProfileIDSavedSearch(ProfileIDSearch profileIDsearch, DataTable dtTableValues, string SavedSearchSp, string saveParam, string searchSp)
        {
            int iResult = CustomerAdvanceGeneralProfileIDsearchSave(dtTableValues, profileIDsearch.intCusID, profileIDsearch.iupdateFlag, SavedSearchSp, saveParam);
            return ProfileIdsearch(profileIDsearch, searchSp);
        }
        public List<SearchResultSaveEditML> SearchResultSaveEdit(long? Cust_ID, string SaveSearchName, int? iEditDelete, string spName)
        {
            List<SearchResultSaveEditML> listSaveEdit = new List<SearchResultSaveEditML>();
            SqlDataReader reader = null;
            SqlParameter[] parm = new SqlParameter[5];
            Int64? intNull = null;
            SqlConnection con = null;
            string strNP = "Not specified";
            try
            {
                parm[0] = new SqlParameter("@Cust_ID", SqlDbType.Int);
                parm[0].Value = Cust_ID;
                parm[1] = new SqlParameter("@SaveSearchName", SqlDbType.VarChar);
                parm[1].Value = SaveSearchName;
                parm[2] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[2].Value = iEditDelete;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();

                    var sqlCommand = con.CreateCommand();
                    sqlCommand.CommandTimeout = 120;

                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SearchResultSaveEditML Mobjresult = new SearchResultSaveEditML();
                            {
                                Mobjresult.SearchResult_ID = (reader["SearchResult_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("SearchResult_ID")) : intNull;
                                Mobjresult.CustID = (reader["CustID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustID")) : strNP;
                                Mobjresult.SearchpageID = (reader["SearchpageID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SearchpageID")) : null;
                                Mobjresult.CustSavedSearchName = (reader["CustSavedSearchName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustSavedSearchName")) : strNP;
                                Mobjresult.SaveSearchPageName = (reader["SaveSearchPageName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SaveSearchPageName")) : strNP;
                            }

                            listSaveEdit.Add(Mobjresult);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, "SearchResultSaveEdit", null);
            }
            finally
            {

                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSaveEdit;
        }

        public List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch search, string spName)
        {
            List<QuicksearchResultML> listSearch = new List<QuicksearchResultML>();
            SqlDataReader reader;
            SqlParameter[] parm = new SqlParameter[30];
            Int64? intNull = null;
            int? iNull = null;
            string strNP = "Not specified";
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@i_CustId", SqlDbType.Int);
                parm[0].Value = search.CustId;
                parm[1] = new SqlParameter("@i_GenderId", SqlDbType.Int);
                parm[1].Value = search.GenderId;
                parm[2] = new SqlParameter("@i_FromAge", SqlDbType.Int);
                parm[2].Value = search.FromAge;
                parm[3] = new SqlParameter("@i_ToAge", SqlDbType.Int);
                parm[3].Value = search.ToAge;
                parm[4] = new SqlParameter("@i_FromHeight", SqlDbType.Int);
                parm[4].Value = search.FromHeight;
                parm[5] = new SqlParameter("@i_ToHeight", SqlDbType.Int);
                parm[5].Value = search.ToHeight;
                parm[6] = new SqlParameter("@tbl_Caste", SqlDbType.VarChar, 8000);
                parm[6].Value = search.Caste;
                parm[7] = new SqlParameter("@tbl_Country", SqlDbType.Int);
                parm[7].Value = search.Country;
                parm[8] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[8].Value = search.StartIndex;
                parm[9] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[9].Value = search.EndIndex;
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();

                    var sqlCommand = con.CreateCommand();
                    sqlCommand.CommandTimeout = 120;

                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            QuicksearchResultML Mobjresult = new QuicksearchResultML();
                            {
                                Mobjresult.intCusID = (reader["Cust_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                                Mobjresult.NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : strNP;
                                Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                                Mobjresult.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : strNP;
                                Mobjresult.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : strNP;
                                Mobjresult.ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : strNP;
                                Mobjresult.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : strNP;
                                Mobjresult.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : strNP;
                                Mobjresult.Location = (reader["Location"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : strNP;
                                Mobjresult.Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : strNP;
                                Mobjresult.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : strNP;
                                Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : 0;
                                Mobjresult.TotalPages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : 0;
                                Mobjresult.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                                Mobjresult.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0;
                                Mobjresult.placeofbirth = (reader["placeofbirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
                                Mobjresult.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0;
                                Mobjresult.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                                Mobjresult.MaritualStatus = (reader["MaritualStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : strNP;
                                Mobjresult.MaritalStatusId = (reader["MaritalStatusId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatusId")) : null;
                                Mobjresult.IsPaidMember = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
                                Mobjresult.mybookmarked = (reader["mybookmarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("mybookmarked")) : iNull;
                                Mobjresult.ExpressFlag = (reader["ExpressFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : iNull;
                                Mobjresult.ignode = (reader["ignode"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ignode")) : iNull;
                                Mobjresult.LogId = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.LogID = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.Photo = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : string.Empty;
                                Mobjresult.Photofullpath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : string.Empty;
                            }

                            listSearch.Add(Mobjresult);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), search.CustId, "CustomerHomePageSearch", null);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSearch;
        }

        public List<generalAdvanceSearchResult> CustomerGeneralandAdvancedSearchWithoutLoginDal(PrimaryInformationMl search, string spName)
        {
            List<generalAdvanceSearchResult> listSearch = new List<generalAdvanceSearchResult>();
            SqlDataReader reader;
            SqlParameter[] parm = new SqlParameter[30];
            Int64? intNull = null;
            int? iNull = null;
            string strNP = "Not specified";
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@i_CustId", SqlDbType.Int);
                parm[0].Value = search.intCusID;
                parm[1] = new SqlParameter("@i_GenderId", SqlDbType.Int);
                parm[1].Value = search.intGender;
                parm[2] = new SqlParameter("@i_FromAge", SqlDbType.Int);
                parm[2].Value = search.FromAge;
                parm[3] = new SqlParameter("@i_ToAge", SqlDbType.Int);
                parm[3].Value = search.ToAge;
                parm[4] = new SqlParameter("@i_FromHeight", SqlDbType.Int);
                parm[4].Value = search.iFromHeight;
                parm[5] = new SqlParameter("@i_ToHeight", SqlDbType.Int);
                parm[5].Value = search.iToHeight;
                parm[6] = new SqlParameter("@i_ReligionId", SqlDbType.Int);
                parm[6].Value = search.intReligionID;
                parm[7] = new SqlParameter("@tbl_Caste", SqlDbType.Structured);
                parm[7].Value = Commonclass.returndt(search.Caste, search.dtCateIDs, "Caste", "CastIDs2");
                parm[8] = new SqlParameter("@tbl_Country", SqlDbType.Structured);
                parm[8].Value = Commonclass.returndt(search.Country, search.dtCountrylivingin, "Countrylivingin", "CountrylivinginIDs4");
                parm[9] = new SqlParameter("@tbl_Education", SqlDbType.Structured);
                parm[9].Value = Commonclass.returndt(search.Education, search.dtEducationGroup, "EducationGroup", "EducationGroupIDs8");
                parm[10] = new SqlParameter("@tbl_ProfessionGroup", SqlDbType.Structured);
                parm[10].Value = Commonclass.returndt(search.Professiongroup, search.dtProfessionGroup, "ProfessionGroup", "ProfessionGroupIDs09");
                parm[11] = new SqlParameter("@tbl_MotherTongue", SqlDbType.Structured);
                parm[11].Value = Commonclass.returndt(search.MotherTongue, search.dtMothertongue, "Mothertongue", "MothertongueIDs1");
                parm[12] = new SqlParameter("@i_Photoflag", SqlDbType.Int);
                parm[12].Value = search.intPhotoCount;
                parm[13] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[13].Value = search.StartIndex;
                parm[14] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[14].Value = search.EndIndex;
                parm[15] = new SqlParameter("@i_Registrationdays", SqlDbType.Int);
                parm[15].Value = search.i_Registrationdays;
                parm[16] = new SqlParameter("@tbl_MaritalStatus", SqlDbType.Structured);
                parm[16].Value = Commonclass.returndt(search.Maritalstatus, search.dtMaritalstatus, "Maritalstatus", "MaritalstatusIDs0");
                parm[17] = new SqlParameter("@i_PhysicalStatus", SqlDbType.Int);
                parm[17].Value = search.iPhysicalstatus;
                parm[18] = new SqlParameter("@tbl_Complexion", SqlDbType.Structured);
                parm[18].Value = Commonclass.returndt(search.Complexion, search.dtComplexion, "Complexion", "ComplexionIDs3");
                parm[19] = new SqlParameter("@tbl_EducationCategory", SqlDbType.Structured);
                parm[19].Value = Commonclass.returndt(search.Educationcategory, search.dtEduactionCat, "Educationcategory", "EducationcategoryIDs7");
                parm[20] = new SqlParameter("@tbl_LivingState", SqlDbType.Structured);
                parm[20].Value = Commonclass.returndt(search.State, search.dtStateLivingIn, "Statelivingin", "StatelivinginIDs5");
                parm[21] = new SqlParameter("@tbl_VisaStatus", SqlDbType.Structured);
                parm[21].Value = Commonclass.returndt(search.Visastatus, search.dtVisaStatus, "VisaStatus", "VisaStatusIDs6");
                parm[22] = new SqlParameter("@i_FromAnualIncome", SqlDbType.BigInt);
                parm[22].Value = search.iFromSal;
                parm[23] = new SqlParameter("@i_ToAnualIncome", SqlDbType.BigInt);
                parm[23].Value = search.iToSal;
                parm[24] = new SqlParameter("@tbl_StarLanguage", SqlDbType.Structured);
                parm[24].Value = Commonclass.returndatatable(search.iStarLanguage, search.dtStarLang, "StarLanguageIDs", "StarLanguageIDs11");
                parm[25] = new SqlParameter("@tbl_Star", SqlDbType.Structured);
                parm[25].Value = Commonclass.returndt(search.Stars, search.dtStar, "Star", "Stars");
                parm[26] = new SqlParameter("@b_isManglik", SqlDbType.Bit);
                parm[26].Value = search.iManglinkKujaDosham;
                parm[27] = new SqlParameter("@i_IsDiet", SqlDbType.Int);
                parm[27].Value = search.iDiet;
                parm[28] = new SqlParameter("@i_SalaryIncurrency", SqlDbType.Int);
                parm[28].Value = search.iAnnualincome;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    var sqlCommand = con.CreateCommand();
                    sqlCommand.CommandTimeout = 120;

                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            generalAdvanceSearchResult Mobjresult = new generalAdvanceSearchResult();
                            {
                                Mobjresult.intCusID = (reader["Cust_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                                Mobjresult.NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : strNP;
                                Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                                Mobjresult.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : strNP;
                                Mobjresult.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : strNP;
                                Mobjresult.ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : strNP;
                                Mobjresult.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : strNP;
                                Mobjresult.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : strNP;
                                Mobjresult.Location = (reader["Location"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : strNP;
                                Mobjresult.Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : strNP;
                                Mobjresult.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : strNP;
                                Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : 0;
                                Mobjresult.TotalPages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : 0;
                                Mobjresult.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                                Mobjresult.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0;
                                Mobjresult.placeofbirth = (reader["placeofbirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
                                Mobjresult.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0;
                                Mobjresult.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                                Mobjresult.MaritualStatus = (reader["MaritualStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : strNP;
                                Mobjresult.MaritalStatusId = (reader["MaritalStatusId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatusId")) : null;
                                Mobjresult.IsPaidMember = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
                                Mobjresult.mybookmarked = (reader["mybookmarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("mybookmarked")) : iNull;
                                Mobjresult.ExpressFlag = (reader["ExpressFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : iNull;
                                Mobjresult.ignode = (reader["ignode"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ignode")) : iNull;
                                Mobjresult.LogId = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.LogID = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.Photo = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : string.Empty;
                                Mobjresult.Photofullpath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : string.Empty;
                                Mobjresult.DistName = (reader["DistName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistName")) : string.Empty;
                                Mobjresult.strFirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : string.Empty;

                            }

                            listSearch.Add(Mobjresult);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), search.intCusID, "GeneralandAdvancedSearch", null);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSearch;
        }
    }
}