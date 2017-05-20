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
using System.IO;
using System.Web;

namespace WebapiApplication.DAL
{
    public class customerPersonalDetails
    {
        public CustomerPersonalDetails DgetpersonalDetailsDAL(string CustID)
        {
            SqlParameter[] parm = new SqlParameter[4];
            SqlDataReader reader;
            CustomerPersonalDetails MobjPersonalsML = null;

            Int64? intNull = null;
            int? iNull = null;
            DateTime? dtnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "[dbo].[Usp_getcustomerinformation]", parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {

                        MobjPersonalsML = new CustomerPersonalDetails();
                        MobjPersonalsML.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                        MobjPersonalsML.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        MobjPersonalsML.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
                        MobjPersonalsML.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
                        MobjPersonalsML.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        MobjPersonalsML.Borncountry = (reader["Borncountry"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Borncountry")) : null;
                        MobjPersonalsML.Age = (reader["Age"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : iNull;
                        MobjPersonalsML.DateofBirth = (reader["DateofBirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DateofBirth")) : null;
                        MobjPersonalsML.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : null;
                        MobjPersonalsML.SubCaste = (reader["SubCaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SubCaste")) : null;
                        MobjPersonalsML.Religion = (reader["Religion"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Religion")) : null;
                        MobjPersonalsML.Complexion = (reader["Complexion"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Complexion")) : null;
                        MobjPersonalsML.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
                        MobjPersonalsML.IsBornCountry = (reader["IsBornCountry"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsBornCountry")) : iNull;
                        MobjPersonalsML.MartialStatus = (reader["MartialStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MartialStatus")) : null;
                        MobjPersonalsML.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : iNull;
                        MobjPersonalsML.HeightInCentimeters = (reader["HeightInCentimeters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HeightInCentimeters")) : iNull;
                        MobjPersonalsML.ComplexionID = (reader["ComplexionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ComplexionID")) : iNull;
                        MobjPersonalsML.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryID")) : iNull;
                        MobjPersonalsML.DateOfBirth = (reader["DateOfBirth"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("DateOfBirth")) : dtnull;
                        MobjPersonalsML.SubCasteID = (reader["SubCasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SubCasteID")) : iNull;
                        MobjPersonalsML.CasteID = (reader["CasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : iNull;
                        MobjPersonalsML.ReligionID = (reader["ReligionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReligionID")) : iNull;
                        MobjPersonalsML.MaritalStatusID = (reader["MaritalStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MaritalStatusID")) : iNull;
                        MobjPersonalsML.Mothertongue = (reader["Mothertongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mothertongue")) : null;

                    }
                }

                reader.Close();
            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("[dbo].[Usp_getcustomerinformation]", Convert.ToString(EX.Message), Convert.ToInt64(CustID), "DgetpersonalDetailsDAL", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();

            }
            return MobjPersonalsML;

        }
        public int DCustomerPersonal_insertUpdateDetails(UpdatePersonaldetails MobjEdudetails, string strSpName, string strTableparam)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];

                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = MobjEdudetails.intCusID;
                parm[1] = new SqlParameter(strTableparam, SqlDbType.Structured);
                parm[1].Value = MobjEdudetails.dtTableValues;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[2].Value = MobjEdudetails.EmpID;
                parm[3] = new SqlParameter("@IsReViewed", SqlDbType.Int);
                parm[3].Value = MobjEdudetails.Admin;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpName, parm);
                if (string.Compare(parm[4].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[4].Value); }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpName, Convert.ToString(ex.Message), MobjEdudetails.intCusID, "DCustomerPersonal_insertUpdateDetails", null);
            }

            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public ArrayList DgetUpdateEducationdetailsDAL(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;
            bool? bnull = null;
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                parm[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parm[0].Value = intCusID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        UpdateEducationdetailsML MobjEdu = new UpdateEducationdetailsML();
                        MobjEdu.intEduID = (reader["intEduID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("intEduID")) : iNull;
                        MobjEdu.EducationCategory = (reader["EducationCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategory")) : null;
                        MobjEdu.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : null;
                        MobjEdu.EducationSpecialization = (reader["EducationSpecialization"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationSpecialization")) : null;
                        MobjEdu.EduUniversity = (reader["EduUniversity"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduUniversity")) : null;
                        MobjEdu.EduCollege = (reader["EduCollege"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduCollege")) : null;
                        MobjEdu.EduCountryIn = (reader["EduCountryIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduCountryIn")) : null;
                        MobjEdu.EduStateIn = (reader["EduStateIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduStateIn")) : null;
                        MobjEdu.EduDistrictIn = (reader["EduDistrictIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduDistrictIn")) : null;
                        MobjEdu.EduCityIn = (reader["EduCityIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduCityIn")) : null;
                        MobjEdu.EduPassOfYear = (reader["EduPassOfYear"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduPassOfYear")) : null;
                        MobjEdu.EduHighestDegree = (reader["EduHighestDegree"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EduHighestDegree")) : iNull;
                        MobjEdu.intCusID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                        MobjEdu.EducationID = (reader["EducationID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("EducationID")) : intNull;
                        MobjEdu.Educationdesc = (reader["Educationdesc"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Educationdesc")) : null;

                        MobjEdu.EducationCategoryID = (reader["EducationCategoryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationCategoryID")) : iNull;
                        MobjEdu.EducationGroupID = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationGroupID")) : iNull;
                        MobjEdu.EducationSpecializationID = (reader["EducationSpecializationID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationSpecializationID")) : iNull;
                        MobjEdu.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryID")) : iNull;
                        MobjEdu.StateID = (reader["StateID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StateID")) : iNull;
                        MobjEdu.DistrictID = (reader["DistrictID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DistrictID")) : iNull;
                        MobjEdu.CityID = (reader["CityID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CityID")) : iNull;
                        MobjEdu.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        MobjEdu.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;

                        arrayList.Add(MobjEdu);
                    }

                }
                reader.Close();
            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, "DgetUpdateEducationdetailsDAL", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DgetUpdateProfessionDetailsDAL(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;

            Int64? intNull = null;
            int? iNull = null;

            bool? bnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;
            try
            {
                parm[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parm[0].Value = intCusID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        UpdateProfessionML MobjProf = new UpdateProfessionML();
                        MobjProf.iProfID = (reader["ProfID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfID")) : iNull;
                        MobjProf.ProfessionCategory = (reader["ProfessionCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionCategory")) : null;
                        MobjProf.ProfessionGroup = (reader["ProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroup")) : null;
                        MobjProf.Professional = (reader["Professional"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Professional")) : null;
                        MobjProf.CompanyName = (reader["CompanyName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CompanyName")) : null;
                        MobjProf.CountryWorkingIn = (reader["CountryWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryWorkingIn")) : null;
                        MobjProf.StateWorkingIn = (reader["StateWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateWorkingIn")) : null;
                        MobjProf.DistrictWorkingIn = (reader["DistrictWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistrictWorkingIn")) : null;
                        MobjProf.CityWorkingIn = (reader["CityWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CityWorkingIn")) : null;
                        MobjProf.OccupationDetails = (reader["OccupationDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OccupationDetails")) : null;
                        MobjProf.Currency = (reader["Currency"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Currency")) : null;
                        MobjProf.Salary = (reader["Salary"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Salary")) : null;

                        MobjProf.ResidingSince = (reader["ResidingSince"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ResidingSince")) : null;
                        MobjProf.ArrivingDate = (reader["ArrivingDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ArrivingDate")) : null;
                        MobjProf.VisaStatus = (reader["VisaStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VisaStatus")) : null;
                        MobjProf.WorkingFromDate = (reader["WorkingFromDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("WorkingFromDate")) : null;
                        MobjProf.WorkingToDate = (reader["WorkingToDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("WorkingToDate")) : null;
                        MobjProf.VisaStatus = (reader["VisaStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VisaStatus")) : null;
                        MobjProf.profGridID = (reader["profGridID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("profGridID")) : iNull;
                        MobjProf.DepartureDate = (reader["DepartureDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DepartureDate")) : null;

                        MobjProf.ProfessionCategoryID = (reader["ProfessionCategoryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfessionCategoryID")) : iNull;
                        MobjProf.ProfessionGroupID = (reader["ProfessionGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfessionGroupID")) : iNull;
                        MobjProf.ProfessionID = (reader["ProfessionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfessionID")) : iNull;
                        MobjProf.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryID")) : iNull;
                        MobjProf.StateID = (reader["StateID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StateID")) : iNull;
                        MobjProf.DistrictID = (reader["DistrictID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DistrictID")) : iNull;
                        MobjProf.CityID = (reader["CityID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CityID")) : iNull;
                        MobjProf.SalaryCurrency = (reader["SalaryCurrency"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SalaryCurrency")) : iNull;
                        MobjProf.VisaTypeID = (reader["VisaTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("VisaTypeID")) : iNull;
                        MobjProf.Cust_Profession_ID = (reader["Cust_Profession_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Profession_ID")) : intNull;
                        MobjProf.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        MobjProf.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;

                        arrayList.Add(MobjProf);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, "DgetUpdateProfessionDetailsDAL", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DgetParentDetailsDisplay(long? intCusID, string strSpname)
        {

            DataSet dsParentdetails = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custid", intCusID);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dsParentdetails);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), intCusID, "DgetParentDetailsDisplay", null);

            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayList(dsParentdetails);
        }

        public ArrayList DgetCustomerpartnerpreferencesDetailsDisplay(long? intCusID, string strSpname)
        {

            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;

            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UpdatePartnerML MObjPartnerML = new UpdatePartnerML();
                        MObjPartnerML.Gender = (reader["Gender"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : null;
                        MObjPartnerML.AgeGap = (reader["AgeGap"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AgeGap")) : null;
                        MObjPartnerML.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
                        MObjPartnerML.Mothertongue = (reader["Mothertongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mothertongue")) : null;
                        MObjPartnerML.Religion = (reader["Religion"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Religion")) : null;
                        MObjPartnerML.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : null;
                        MObjPartnerML.Subcaste = (reader["Subcaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Subcaste")) : null;
                        MObjPartnerML.MaritalStatus = (reader["MaritalStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : null;
                        MObjPartnerML.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : null;
                        MObjPartnerML.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : null;
                        MObjPartnerML.Kujadosham = (reader["Kujadosham"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Kujadosham")) : null;
                        MObjPartnerML.intCusID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                        MObjPartnerML.StarLanguage = (reader["StarLanguage"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StarLanguage")) : null;
                        MObjPartnerML.Stars = (reader["Stars"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Stars")) : null;
                        MObjPartnerML.Diet = (reader["Diet"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Diet")) : null;
                        MObjPartnerML.CountryName = (reader["CountryName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryName")) : null;
                        MObjPartnerML.StateName = (reader["StateName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateName")) : null;
                        MObjPartnerML.EducationCategory = (reader["EducationCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategory")) : null;
                        MObjPartnerML.EducationSpecilization = (reader["EducationSpecilization"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationSpecilization")) : null;
                        MObjPartnerML.professionCategory = (reader["professionCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("professionCategory")) : null;
                        MObjPartnerML.ProfessionGroup = (reader["ProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroup")) : null;
                        MObjPartnerML.ProfessionGroupID = (reader["ProfessionGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroupID")) : null;
                        MObjPartnerML.TypeOfStar = (reader["TypeOfStar"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TypeOfStar")) : null;
                        MObjPartnerML.MotherTongueID = (reader["MotherTongueID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongueID")) : null;
                        MObjPartnerML.religionid = (reader["religionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("religionid")) : null;
                        MObjPartnerML.casteid = (reader["casteid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("casteid")) : null;
                        MObjPartnerML.subcasteid = (reader["subcasteid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subcasteid")) : null;
                        MObjPartnerML.maritalstatusid = (reader["maritalstatusid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("maritalstatusid")) : null;
                        MObjPartnerML.complexionid = (reader["complexionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("complexionid")) : null;
                        MObjPartnerML.EducationCategoryID = (reader["EducationCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategoryID")) : null;
                        MObjPartnerML.EducationGroupID = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupID")) : null;
                        MObjPartnerML.EduSpecializationID = (reader["EduSpecializationID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduSpecializationID")) : null;
                        MObjPartnerML.ProfessionCategoryID = (reader["ProfessionCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionCategoryID")) : null;
                        MObjPartnerML.diet = (reader["diet"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("diet")) : null;
                        MObjPartnerML.PreferredStars = (reader["PreferredStars"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PreferredStars")) : null;
                        MObjPartnerML.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryID")) : null;
                        MObjPartnerML.StateID = (reader["StateID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateID")) : null;
                        MObjPartnerML.Agemin = (reader["Agemin"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Agemin")) : iNull;
                        MObjPartnerML.AgeMax = (reader["AgeMax"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AgeMax")) : iNull;
                        MObjPartnerML.MinHeight = (reader["MinHeight"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MinHeight")) : null;
                        MObjPartnerML.MaxHeight = (reader["MaxHeight"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaxHeight")) : null;
                        MObjPartnerML.DistrictID = (reader["DistrictID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistrictID")) : null;
                        MObjPartnerML.LocationPrefPlace = (reader["LocationPrefPlace"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LocationPrefPlace")) : null;
                        MObjPartnerML.KujaDoshamID = (reader["KujaDoshamID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("KujaDoshamID")) : iNull;
                        MObjPartnerML.DietID = (reader["DietID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DietID")) : null;
                        MObjPartnerML.StarLanguageID = (reader["StarLanguageID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StarLanguageID")) : iNull;
                        MObjPartnerML.PartnerDescripition = (reader["PartnerDescripition"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PartnerDescripition")) : null;
                        MObjPartnerML.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : false;
                        MObjPartnerML.regionId = (reader["regionId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("regionId")) : null;
                        MObjPartnerML.branchid = (reader["branchid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("branchid")) : null;
                        MObjPartnerML.RegionName = (reader["RegionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RegionName")) : null;
                        MObjPartnerML.BranchName = (reader["BranchName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchName")) : null;
                        MObjPartnerML.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;
                        MObjPartnerML.Domicel = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Domicel")) : null;
                        arrayList.Add(MObjPartnerML);
                    }
                }

                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, "DgetCustomerpartnerpreferencesDetailsDisplay", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public ArrayList DgetsiblingsDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();

            DataSet dssibling = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@Custid", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@SibilingVaritionFlag", SqlDbType.Bit);
                parm[1].Value = 0;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                dssibling = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), intCusID, "DgetsiblingsDetailsDisplay", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dssibling);
        }

        public ArrayList DgetAstroDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            DataSet dtAstrodetails = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custid", intCusID);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dtAstrodetails);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), intCusID, "DgetAstroDetailsDisplay", null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayList(dtAstrodetails);

        }
        public ArrayList DgetPropertyDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;
            int? iNull = null;
            bool? bnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = intCusID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UpdatePropertyML mobjProperty = new UpdatePropertyML();
                        mobjProperty.PropertyDetails = (reader["PropertyDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyDetails")) : null;
                        mobjProperty.isProperty = (reader["isProperty"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("isProperty")) : null;
                        mobjProperty.PropertyType = (reader["PropertyType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyType")) : null;
                        mobjProperty.PropertyvalueType = (reader["PropertyvalueType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyvalueType")) : null;
                        mobjProperty.PropertyValue = (reader["PropertyValue"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PropertyValue")) : iNull;
                        mobjProperty.PropertyquantityType = (reader["PropertyquantityType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyquantityType")) : null;
                        mobjProperty.Propertyquantity = (reader["Propertyquantity"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Propertyquantity")) : iNull;
                        mobjProperty.ProCountry = (reader["ProCountry"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProCountry")) : iNull;
                        mobjProperty.ProState = (reader["ProState"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProState")) : iNull;
                        mobjProperty.ProDistrict = (reader["ProDistrict"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProDistrict")) : iNull;
                        mobjProperty.ProCity = (reader["ProCity"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProCity")) : iNull;
                        mobjProperty.ProShowin = (reader["ProShowin"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProShowin")) : iNull;
                        mobjProperty.PropertyID = (reader["PropertyID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PropertyID")) : iNull;
                        mobjProperty.Custpropertyid = (reader["Custpropertyid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Custpropertyid")) : iNull;
                        mobjProperty.FamilyStatus = (reader["FamilyStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FamilyStatus")) : null;

                        //backendFields
                        mobjProperty.ProperTypeID = (reader["ProperTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProperTypeID")) : iNull;
                        mobjProperty.PropertyValueCurrencyID = (reader["PropertyValueCurrencyID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PropertyValueCurrencyID")) : iNull;
                        mobjProperty.QuantityTypeID = (reader["QuantityTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("QuantityTypeID")) : iNull;
                        mobjProperty.FamilyValuesID = (reader["FamilyValuesID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FamilyValuesID")) : iNull;
                        mobjProperty.SharedPropertyID = (reader["SharedPropertyID"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("SharedPropertyID")) : bnull;
                        mobjProperty.ShowInViewProfileID = (reader["ShowInViewProfileID"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ShowInViewProfileID")) : bnull;
                        mobjProperty.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        mobjProperty.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;
                        arrayList.Add(mobjProperty);
                    }
                }

                reader.Close();
            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, "DgetPropertyDetailsDisplay", null);

            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public ArrayList DgetRelativeDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            DataSet dsRelativedetails = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@RelativeVaritionFlag", SqlDbType.Bit);
                parm[1].Value = 0;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                dsRelativedetails = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), intCusID, "DgetRelativeDetailsDisplay", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dsRelativedetails);
        }
        public ArrayList DgetReferenceViewDetailsDisplay(long? intCusID, string strSpname)
        {

            SqlParameter[] parm = new SqlParameter[5];
            ArrayList arrayList = new ArrayList();
            int? iNull = null;
            Int64? intnull = null;
            bool? bnull = null;
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@Custid", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UpdateReferenceML MobjRef = new UpdateReferenceML();
                        MobjRef.Relatioshiptype = (reader["Relatioshiptype"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Relatioshiptype")) : null;
                        MobjRef.RefrenceName = (reader["RefrenceName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceName")) : null;
                        MobjRef.RefrenceProfessionDetails = (reader["RefrenceProfessionDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionDetails")) : null;
                        MobjRef.RefrenceNativePlace = (reader["RefrenceNativePlace"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceNativePlace")) : null;
                        MobjRef.RefrenceLandNumberwithCode = (reader["RefrenceLandNumberwithCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceLandNumberwithCode")) : null;
                        MobjRef.RefrenceMobileNumberWithcode = (reader["RefrenceMobileNumberWithcode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceMobileNumberWithcode")) : null;
                        MobjRef.RefrenceEmail = (reader["RefrenceEmail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceEmail")) : null;
                        MobjRef.RefrenceNarration = (reader["RefrenceNarration"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceNarration")) : null;
                        MobjRef.RefrenceCity = (reader["RefrenceCity"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceCity")) : null;
                        MobjRef.RefenceCurrentLocation = (reader["RefenceCurrentLocation"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefenceCurrentLocation")) : null;
                        MobjRef.RefrenceProfessionCategory = (reader["RefrenceProfessionCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionCategory")) : null;
                        MobjRef.RefrenceProfessionGroup = (reader["RefrenceProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionGroup")) : null;
                        //back end filelds
                        MobjRef.ReletionShipTypeID = (reader["ReletionShipTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReletionShipTypeID")) : iNull;
                        MobjRef.RefrenceNativePlaceID = (reader["RefrenceNativePlaceID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceNativePlaceID")) : null;
                        MobjRef.RefrenceCityid = (reader["RefrenceCityID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceCityID")) : null;
                        MobjRef.RefrenceDistrictID = (reader["RefrenceDistrictID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceDistrictID")) : null;
                        MobjRef.RefrenceStateID = (reader["RefrenceStateID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceStateID")) : null;
                        MobjRef.RefrenceCountry = (reader["RefrenceCountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceCountryID")) : null;
                        MobjRef.RefrenceLandCountryId = (reader["RefrenceLandCountryId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceLandCountryId")) : null;
                        MobjRef.RefrenceAreaCode = (reader["RefrenceAreaCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceAreaCode")) : null;
                        MobjRef.RefrenceLandNumber = (reader["RefrenceLandNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceLandNumber")) : null;
                        MobjRef.RefrenceMobileCountryID = (reader["RefrenceMobileCountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceMobileCountryID")) : null;
                        MobjRef.RefrenceMobileNumberID = (reader["RefrenceMobileNumberID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceMobileNumberID")) : null;
                        MobjRef.RefrenceProfessionCategoryID = (reader["RefrenceProfessionCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionCategoryID")) : null;
                        MobjRef.RefrencePRofessionGroupID = (reader["RefrencePRofessionGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrencePRofessionGroupID")) : null;
                        MobjRef.RefrenceProessionID = (reader["RefrenceProessionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RefrenceProessionID")) : iNull;
                        MobjRef.RefrenceCust_Reference_ID = (reader["Cust_Reference_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Reference_ID")) : intnull;
                        MobjRef.RefrenceProfession = (reader["RefrenceProfession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfession")) : null;
                        MobjRef.ReferenceFirstName = (reader["ReferenceFirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReferenceFirstName")) : null;
                        MobjRef.ReferenceLastName = (reader["ReferenceLastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReferenceLastName")) : null;
                        MobjRef.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        MobjRef.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;
                        arrayList.Add(MobjRef);
                    }
                }
                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, "DgetReferenceViewDetailsDisplay", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DGetphotosofCustomer(string Custid, int? EmpIDQueryInt, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@cust_id", SqlDbType.Int);
                parm[0].Value = Custid;
                parm[1] = new SqlParameter("@Empid", SqlDbType.Int);
                parm[1].Value = EmpIDQueryInt;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhotoSectionMl ml = new PhotoSectionMl();
                        ml.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                        ml.PhotoName = (reader["PhotoName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoName")) : null;
                        ml.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                        ml.VisibleToID = (reader["VisibleToID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("VisibleToID")) : iNull;
                        ml.DisplayOrder = (reader["DisplayOrder"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DisplayOrder")) : iNull;
                        ml.UploadedByEmpID = (reader["UploadedByEmpID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("UploadedByEmpID")) : intNull;
                        ml.UploadedDate = (reader["UploadedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedDate")) : null;
                        ml.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedDate")) : null;
                        ml.IsMain = (reader["IsMain"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsMain")) : iNull;
                        ml.IsActive = (reader["IsActive"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsActive")) : iNull;
                        ml.PhotoStatus = (reader["PhotoStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoStatus")) : iNull;
                        ml.AssignedTo = (reader["AssignedTo"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AssignedTo")) : iNull;
                        ml.AssignedDate = (reader["AssignedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AssignedDate")) : null;
                        ml.IsReviewed = (reader["IsReviewed"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsReviewed")) : iNull;
                        ml.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        ml.IsThumbNailCreated = (reader["IsThumbNailCreated"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsThumbNailCreated")) : iNull;
                        ml.Cust_Photos_ID = (reader["Cust_Photos_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Photos_ID")) : intNull;
                        ml.strModifiedByEmpID = (reader["ModifiedByEmpID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedByEmpID")) : null;
                        ml.UploadedBy = (reader["UploadedBy"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedBy")) : null;
                        arrayList.Add(ml);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(Custid), "DGetphotosofCustomer", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public string DgetDiscribeYour(string CustID, string AboutYourself, int? flag, string spName)
        {
            SqlParameter[] parm = new SqlParameter[4];
            SqlDataReader reader;
            string strDesc = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@v_AboutYourself", SqlDbType.VarChar);
                parm[1].Value = AboutYourself;
                parm[2] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[2].Value = flag;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        strDesc = (reader["Describe"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Describe")) : null;
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(CustID), "DgetDiscribeYour", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return strDesc;
        }

        public int DUpdateSibblingCounts(SibblingCounts sibcount, string spName)
        {
            int iStatus = 0;
            DataSet ds = new DataSet();
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[0].Value = sibcount.CustID;
                parm[1] = new SqlParameter("@NoOfBrothers", SqlDbType.VarChar);
                parm[1].Value = sibcount.NoOfBrothers;
                parm[2] = new SqlParameter("@NoOfSisters", SqlDbType.Int);
                parm[2].Value = sibcount.NoOfSisters;
                parm[3] = new SqlParameter("@NoOfYoungerBrothers", SqlDbType.Int);
                parm[3].Value = sibcount.NoOfYoungerBrothers;
                parm[4] = new SqlParameter("@NoOfElderBrothers", SqlDbType.Int);
                parm[4].Value = sibcount.NoOfElderBrothers;
                parm[5] = new SqlParameter("@NoOfElderSisters", SqlDbType.Int);
                parm[5].Value = sibcount.NoOfElderSisters;
                parm[6] = new SqlParameter("@NoOfYoungerSisters", SqlDbType.Int);
                parm[6].Value = sibcount.NoOfYoungerSisters;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[7].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[7].Value); }

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(sibcount.CustID), "DUpdateSibblingCounts", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public ArrayList Savephotosofcustomer(UpdatePersonaldetails savePhoto, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@dtPhotoUpload", SqlDbType.Structured);
                parm[0].Value = savePhoto.dtTableValues;
                parm[1] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[1].Value = Convert.ToString(savePhoto.intCusID);
                parm[2] = new SqlParameter("@Empid", SqlDbType.VarChar);
                parm[2].Value = Convert.ToString(savePhoto.EmpID);

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhotoSectionMl ml = new PhotoSectionMl();
                        ml.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                        ml.PhotoName = (reader["PhotoName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoName")) : null;
                        ml.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                        ml.VisibleToID = (reader["VisibleToID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("VisibleToID")) : iNull;
                        ml.DisplayOrder = (reader["DisplayOrder"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DisplayOrder")) : iNull;
                        ml.UploadedByEmpID = (reader["UploadedByEmpID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("UploadedByEmpID")) : intNull;
                        ml.UploadedDate = (reader["UploadedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedDate")) : null;
                        ml.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedDate")) : null;
                        ml.IsMain = (reader["IsMain"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsMain")) : iNull;
                        ml.IsActive = (reader["IsActive"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsActive")) : iNull;
                        ml.PhotoStatus = (reader["PhotoStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoStatus")) : iNull;
                        ml.AssignedTo = (reader["AssignedTo"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AssignedTo")) : iNull;
                        ml.AssignedDate = (reader["AssignedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AssignedDate")) : null;
                        ml.IsReviewed = (reader["IsReviewed"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsReviewed")) : iNull;
                        ml.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        ml.IsThumbNailCreated = (reader["IsThumbNailCreated"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsThumbNailCreated")) : iNull;
                        ml.Cust_Photos_ID = (reader["Cust_Photos_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Photos_ID")) : intNull;
                        ml.strModifiedByEmpID = (reader["ModifiedByEmpID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedByEmpID")) : null;
                        ml.UploadedBy = (reader["UploadedBy"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedBy")) : null;
                        arrayList.Add(ml);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), savePhoto.intCusID, "Savephotosofcustomer", null);
                throw EX;
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public int PhotoPassword(long? CustID, int? ipassword, string spName)
        {
            int iStatus = 0;
            DataSet ds = new DataSet();
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[3];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@iPassword", SqlDbType.Int);
                parm[1].Value = ipassword;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[2].Value); }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), CustID, "PhotoPassword", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public int AstroDetailsUpdateDelete(AstroUploadDelete astroupdate, string spName)
        {
            int iStatus = 0;
            DataSet ds = new DataSet();
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[8];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@Cust_ID", SqlDbType.BigInt);
                parm[0].Value = astroupdate.Cust_ID;
                parm[1] = new SqlParameter("@Horopath", SqlDbType.VarChar);
                parm[1].Value = astroupdate.Horopath;
                parm[2] = new SqlParameter("@ModifiedByEmpID", SqlDbType.Int);
                parm[2].Value = astroupdate.ModifiedByEmpID;
                parm[3] = new SqlParameter("@VisibleToID", SqlDbType.Int);
                parm[3].Value = astroupdate.VisibleToID;
                parm[4] = new SqlParameter("@Empid", SqlDbType.Int);
                parm[4].Value = astroupdate.Empid;
                parm[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                parm[5].Value = astroupdate.IsActive;
                parm[6] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[6].Value = astroupdate.i_flag;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[7].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[7].Value); }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(astroupdate.Cust_ID), "AstroDetailsUpdateDelete", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public List<GenerateHoroML> GeneaterHorosupport(int? customerid, int? CityID)
        {
            SqlParameter[] param = new SqlParameter[3];
            List<GenerateHoroML> lstgeneaterhoro = new List<GenerateHoroML>();
            GenerateHoroML generateHoro = new GenerateHoroML();
            SqlDataReader reader = null;
            int? int32 = null;
            DateTime? iDateTime = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                param[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                param[0].Value = customerid;
                param[1] = new SqlParameter("@CityID", SqlDbType.Int);
                param[1].Value = CityID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "[dbo].[usp_GeneaterHorosupport]", param);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        generateHoro.CityOfBirthID = reader["CityOfBirthID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CityOfBirthID")) : int32;
                        generateHoro.TimeOfBirth = reader["TimeOfBirth"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("TimeOfBirth")) : iDateTime;
                        generateHoro.Longitude = reader["Longitude"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Longitude")) : null;
                        generateHoro.Latitude = reader["Latitude"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Latitude")) : null;
                        generateHoro.GenderID = reader["GenderID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : int32;
                        generateHoro.strName = reader["NAME"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : null;
                        generateHoro.CityName = reader["CityName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CityName")) : null;
                    }
                }
                lstgeneaterhoro.Add(generateHoro);
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("[dbo].[usp_GeneaterHorosupport]", Convert.ToString(EX.Message), Convert.ToInt32(customerid), "GeneaterHorosupport", null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return lstgeneaterhoro;
        }
        public static string PathChange = ConfigurationManager.AppSettings["PathChange"];
        public HoroGeneration GenerateHoroscorpe(int? customerid, string EmpIDQueryString, int? intDay, int? intMonth, int? intYear, int? CityID)
        {
            string accesspathhoro = "~\\access\\Images\\";
            string withouraccesspathhoro = "~\\Images\\";
            string str = null;
            List<GenerateHoroML> li = new List<GenerateHoroML>();
            int? iNULL = null;
            li = GeneaterHorosupport(customerid, CityID);
            DateTime myDate = Convert.ToDateTime((li[0].TimeOfBirth).ToString());
            string strTime = myDate.ToString("HH:mm:ss");

            HoroGeneration horogeneration = new HoroGeneration();

            if (!string.IsNullOrEmpty(li[0].Longitude) && !string.IsNullOrEmpty(li[0].Latitude))
            {
                int ilongitude = Convert.ToInt32((li[0].Longitude).Substring(4, 2));
                int ilatitude = Convert.ToInt32((li[0].Latitude).Substring(3, 2));
                if (ilongitude > 59)
                {
                    li[0].Longitude = (li[0].Longitude).Remove(4, 2).Insert(4, "59");
                }
                if (ilatitude > 59)
                {
                    li[0].Latitude = (li[0].Latitude).Remove(3, 2).Insert(3, "59");
                }
                if (customerid != 0)
                {
                    if (!string.IsNullOrEmpty(li[0].CityName))
                    {
                        string path = customerid + "_HaroscopeImage/";
                        string fullpath = GenerateHoroML.fullpath + path;
                        str = GenerateHoroML.str + customerid +
                                 "</CUSTID><SEX>" + (li[0].GenderID == 1 ? "Male" : "Female") + "</SEX><NAME>" + li[0].strName + "</NAME><DAY>"
                                 + intDay + "</DAY><MONTH>" + intMonth + "</MONTH><YEAR>" + intYear + "</YEAR><TIME24HR>"
                                 + strTime + "</TIME24HR><CORR>1</CORR><PLACE>" + li[0].CityName + "</PLACE><LONG>" + li[0].Longitude
                                 + "</LONG><LAT>" + li[0].Latitude +
                                 "</LAT><LONGDIR>E</LONGDIR><LATDIR>N</LATDIR><TZONE>05.30</TZONE><TZONEDIR>E</TZONEDIR></BIRTHDATA><OPTIONS>"
                                 + "<CHARTSTYLE>0</CHARTSTYLE><LANGUAGE>ENG</LANGUAGE><REPTYPE>LS-SP</REPTYPE><REPDMN>kaakateeya</REPDMN><HSETTINGS>"
                                 + "<AYANAMSA>1</AYANAMSA><DASASYSTEM>1</DASASYSTEM><GULIKATYPE>1</GULIKATYPE><PARYANTHARSTART>0</PARYANTHARSTART>"
                                 + "<PARYANTHAREND>25</PARYANTHAREND><FAVMARPERIOD>50</FAVMARPERIOD><BHAVABALAMETHOD>1</BHAVABALAMETHOD><ADVANCEDOPTION1>"
                                 + "0</ADVANCEDOPTION1><ADVANCEDOPTION2>0</ADVANCEDOPTION2><ADVANCEDOPTION3>0</ADVANCEDOPTION3><ADVANCEDOPTION4>0</ADVANCEDOPTION4>"
                                 + "</HSETTINGS><IMGURL>" + fullpath + "</IMGURL></OPTIONS>"
                                 + "<PARAMS>employee</PARAMS></DATA>";

                        // path = "../../Images/HoroscopeImages/" + customerid + "_HaroscopeImage/" + customerid + "_HaroscopeImage.html";
                        path = ((string.IsNullOrEmpty(EmpIDQueryString) ? "../../Images" : "../Images")) + "/HoroscopeImages/" + customerid + "_HaroscopeImage/" + customerid + "_HaroscopeImage.html";

                        if (EmpIDQueryString != null)
                        {
                            AstroUploadDelete astroupdate = new AstroUploadDelete();
                            astroupdate.Cust_ID = customerid;
                            astroupdate.Horopath = path;
                            astroupdate.ModifiedByEmpID = path.Contains("HaroscopeImage.html") ? 141 : iNULL;
                            astroupdate.VisibleToID = 1;
                            astroupdate.Empid = !string.IsNullOrEmpty(EmpIDQueryString) ? Convert.ToInt32(EmpIDQueryString) : iNULL;
                            astroupdate.IsActive = true;
                            astroupdate.i_flag = 1;
                            AstroDetailsUpdateDelete(astroupdate, "[dbo].[usp_AstroUpload_Delete]");
                        }

                        string strCustDtryName = customerid + "_HaroscopeImage";
                        string FileName = customerid + "_HaroscopeImage.html";

                        string Strpaths3 = (HttpContext.Current.Server.MapPath((string.IsNullOrEmpty(EmpIDQueryString) ? accesspathhoro : withouraccesspathhoro) + "HoroscopeImages\\")) + strCustDtryName + "\\" + FileName;

                        // string Strpaths3 = "http:\\e.kaakateeya.com\\access\\Images\\" + "HoroscopeImages\\" + strCustDtryName + "\\" + FileName;

                        //string Strpaths3 = ("http://e.kaakateeya.com/access" + "HoroscopeImages\\")) + strCustDtryName + "\\" + FileName;

                        string Strkeyname = "Images/HoroscopeImages/" + strCustDtryName + "/" + FileName;

                        // string strPath = null;
                        //if (Strpaths3.Contains("http://kaakateeya.com/"))
                        //{
                        //    strPath = Strpaths3.Replace("http://kaakateeya.com/", "http://e.kaakateeya.com/");
                        //}
                        //else
                        //{
                        //    strPath = Strpaths3;
                        //}

                        //if (!string.IsNullOrEmpty(Commonclass.GlobalImgPath))
                        //{
                        //    if (Directory.Exists(path))
                        //    {
                        //        Commonclass.S3upload(Strpaths3, Strkeyname);
                        //    }
                        //}

                        string strHoro = Strkeyname.Replace("/", "\\");
                        string strPath = "C:\\inetpub\\wwwroot\\access\\" + strHoro;
                        string strTestPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, strPath);

                        horogeneration.KeyName = Strkeyname;
                        horogeneration.Path = strPath;
                        horogeneration.AstroGeneration = str;
                        horogeneration.strTestPath = strTestPath;

                    }
                }
            }

            return horogeneration;
        }

        public int AstroGenerationUpdate(string Path, string KeyName)
        {
            int iresult = 0;

            string strHoro = KeyName.Replace("/", "\\");
            Path = PathChange + strHoro;

            //Path = "e.kaakateeya.com\\access\\Images\\HoroscopeImages\\91022_HaroscopeImage\\91022_HaroscopeImage.html";
            Path = "C:\\inetpub\\wwwroot\\access\\" + strHoro;
            // KeyName = "Images/HoroscopeImages/91022_HaroscopeImage/91022_HaroscopeImage.html";

            //Path = "C:\\91022_HaroscopeImage\\91022_HaroscopeImage.html";
            //KeyName = "D:\\9_HaroscopeImage\\91022_HaroscopeImage.html";
            //Path = System.IO.Path(KeyName);

            //  string parentDir = System.IO.Path.GetDirectoryName(Path);

            //  Path = parentDir + "\\91022_HaroscopeImage.html";
            //  Path = Server.MapPath("~/" + KeyName);

            //Path = "www.e.kaakateeya.com\\access\\Images\\HoroscopeImages\\91022_HaroscopeImage\\91022_HaroscopeImage.html";

            Path = System.IO.Path.Combine(System.Environment.CurrentDirectory, Path);

            if (!string.IsNullOrEmpty(Commonclass.GlobalImgPath))
            {
                Commonclass.S3upload(Path, KeyName);
                iresult = 1;
            }

            return iresult;

        }

    }
}