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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using CCA.Util;
using System.Collections.Specialized;
using System.Xml;



namespace WebapiApplication.DAL
{
    public class PaymentDAL
    {
        public List<Paymentselect> GetPaymentDetails(long? CustID, string spName)
        {
            SqlParameter[] parm = new SqlParameter[3];
            SqlDataReader reader = null;
            List<Paymentselect> arrayList = new List<Paymentselect>();
            int? intnull = null;
            double? floatnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                parm[0] = new SqlParameter("@i_FromCustID", SqlDbType.BigInt);
                parm[0].Value = CustID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Paymentselect payment = new Paymentselect();
                        {

                            payment.MembershipName = reader["MembershipName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MembershipName")) : null;
                            payment.Emp_Membership_ID = reader["Emp_Membership_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Emp_Membership_ID")) : intnull;
                            payment.MemberShipDuration = reader["MemberShipDuration"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MemberShipDuration")) : intnull;
                            payment.Cust_MemberShip_Discount_ID = reader["Cust_MemberShip_Discount_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Cust_MemberShip_Discount_ID")) : intnull;
                            payment.DiscountAmount = reader["DiscountAmount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DiscountAmount")) : intnull;
                            payment.AllottedServicePoints = reader["AllottedServicePoints"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AllottedServicePoints")) : intnull;
                            payment.MembershipAmount = reader["MembershipAmount"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("MembershipAmount")) : floatnull;
                            payment.onlineaccess = reader["onlineaccess"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("onlineaccess")) : null;
                            payment.offlineaccess = reader["offlineaccess"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("offlineaccess")) : null;
                            payment.Ppluspath = reader["Ppluspath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Ppluspath")) : null;
                            payment.Ppath = reader["Ppath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Ppath")) : null;

                        }
                        arrayList.Add(payment);
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Paymentselect payment = new Paymentselect();
                        {

                            payment.MembershipName = reader["MembershipName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MembershipName")) : null;
                            payment.Emp_Membership_ID = reader["Emp_Membership_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Emp_Membership_ID")) : intnull;
                            payment.MemberShipDuration = reader["MemberShipDuration"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MemberShipDuration")) : intnull;
                            payment.Cust_MemberShip_Discount_ID = reader["Cust_MemberShip_Discount_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Cust_MemberShip_Discount_ID")) : intnull;
                            payment.DiscountAmount = reader["DiscountAmount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DiscountAmount")) : intnull;
                            payment.AllottedServicePoints = reader["AllottedServicePoints"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AllottedServicePoints")) : intnull;
                            payment.AccessFeature = reader["AccessFeature"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AccessFeature")) : intnull;
                            payment.MembershipAmount = reader["MembershipAmount"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("MembershipAmount")) : floatnull;
                      
                        }

                        arrayList.Add(payment);
                    }
                }
                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), CustID, "GetPaymentDetails", null);
            }

            finally
            {

                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public string CustomerPaymentStatus(long? CustomerCustID, string spName)
        {
            DataSet ds = new DataSet();
            string status = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();


            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            SqlParameter[] parm = new SqlParameter[5];
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = CustomerCustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.VarChar, 8000);
                parm[1].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                status = parm[1].Value.ToString();
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(CustomerCustID), "CustomerPaymentStatus", null);
            }
            finally
            {

                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return status;
        }

        public int InsertPaymentDetails(PaymentMasterMl Mobj, string spName)
        {
            int intStatus = 0;
            DataSet dset = new DataSet();
            SqlParameter[] parm = new SqlParameter[8];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                parm[0] = new SqlParameter("@custID", SqlDbType.BigInt);
                parm[0].Value = Mobj.intCustID;
                parm[1] = new SqlParameter("@MembershipID", SqlDbType.BigInt);
                parm[1].Value = Mobj.intMembershipID;
                parm[2] = new SqlParameter("@MembershipDiscountID", SqlDbType.BigInt);
                parm[2].Value = Mobj.DiscountID;
                parm[3] = new SqlParameter("@Points", SqlDbType.Int);
                parm[3].Value = Mobj.Points;
                parm[4] = new SqlParameter("@MembershipName", SqlDbType.VarChar, 100);
                parm[4].Value = Mobj.MembershipName;
                parm[5] = new SqlParameter("@Duration", SqlDbType.Int);
                parm[5].Value = Mobj.Duration;
                parm[6] = new SqlParameter("@Amount", SqlDbType.VarChar, 100);
                parm[6].Value = Mobj.MembershipAmount;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[7].Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[7].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(Mobj.intCustID), "InsertPaymentDetails", null);
            }
            finally
            {

                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList DgetProfilePaymentDetails(long? intProfileID, int? Isonline, int? flag, int? intMembershipID, string taxpaid)
        {
            int? intStatus = 0;
            DataSet dsPayment = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            SqlParameter[] parm = new SqlParameter[7];

            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = intProfileID;
                parm[1] = new SqlParameter("@flag", SqlDbType.Int);
                parm[1].Value = flag;
                parm[2] = new SqlParameter("@MemberShipID", SqlDbType.Int);
                parm[2].Value = intMembershipID;
                parm[3] = new SqlParameter("@Isonline", SqlDbType.Int);
                parm[3].Value = Isonline;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                parm[5] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[5].Direction = ParameterDirection.Output;
                parm[6] = new SqlParameter("@taxpaid", SqlDbType.VarChar, 1000);
                parm[6].Value = taxpaid;
                dsPayment = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "usp_Payment_getProfilePaymentDetails", parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[4].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[4].Value); }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog("usp_Payment_getProfilePaymentDetails", Convert.ToString(EX.Message), Convert.ToInt32(intProfileID), "DgetProfilePaymentDetails", null); }
            finally
            {

                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            if (dsPayment.Tables.Count == 0)
                dsPayment = null;
            return Commonclass.convertdataTableToArrayList(dsPayment);
        }

        public int CustomerInsertPaymentDetilsInfo(CustomerPaymentML Mobj, string spName)
        {
            int IntStatus = 0;
            DataSet dsPaymentDetails = new DataSet();
            int? Istatus = null;
            int? inull = null;
            List<Smtpemailsending> li = new List<Smtpemailsending>();

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            SqlDataAdapter daPaymentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dtPaymentDetails", Mobj.dtPaymentDetails);
                cmd.Parameters.AddWithValue("@Isonline", Mobj.Isonline);
                cmd.Parameters.AddWithValue("@PaysmsID", Mobj.PaysmsID);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                SqlParameter outputParamErrorLog = cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 1000);
                outputParamErrorLog.Direction = ParameterDirection.Output;
                daPaymentDetails.SelectCommand = cmd;
                daPaymentDetails.Fill(dsPaymentDetails);

                if (dsPaymentDetails != null && dsPaymentDetails.Tables.Count > 3 && dsPaymentDetails.Tables[3] != null)
                {
                    for (int i = 0; i < dsPaymentDetails.Tables[3].Rows.Count; i++)
                    {
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = dsPaymentDetails.Tables[3].Columns.Contains("profile_name") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["profile_name"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["profile_name"].ToString() : string.Empty;
                            smtp.recipients = dsPaymentDetails.Tables[3].Columns.Contains("recipients") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["recipients"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["recipients"].ToString() : string.Empty;
                            smtp.body = dsPaymentDetails.Tables[3].Columns.Contains("body") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["body"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["body"].ToString() : string.Empty;
                            smtp.subject = dsPaymentDetails.Tables[3].Columns.Contains("subject") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["subject"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["subject"].ToString() : string.Empty;
                            smtp.body_format = dsPaymentDetails.Tables[3].Columns.Contains("body_format") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["body_format"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["body_format"].ToString() : string.Empty;
                            Istatus = smtp.Status = dsPaymentDetails.Tables[3].Columns.Contains("Status") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["Status"].ToString()) ? Convert.ToInt32(dsPaymentDetails.Tables[3].Rows[i]["Status"]) : inull;
                        }
                        li.Add(smtp);
                    }
                    IntStatus = (Istatus != null && Istatus != 0) ? 1 : 0;
                    if (Mobj.PaysmsID == 1)
                    {
                        Commonclass.SendMailSmtpMethod(li, "info");
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmd.Parameters[3].Value) == 1) { IntStatus = 1; }
                    else { IntStatus = 0; }
                }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, "CustomerInsertPaymentDetilsInfo", null); }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            if (dsPaymentDetails.Tables.Count == 0) { dsPaymentDetails = null; }
            return IntStatus;

        }


        //New Payment Table Design  Test API

        public int CustomerInsertPaymentDetilsInfo_New(PaymentInsertML Mobj, string spName)
        {
            int IntStatus = 0;
            DataSet dsPaymentDetails = new DataSet();
            int? Istatus = null;
            int? inull = null;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataAdapter daPaymentDetails = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            try
            {
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dtPaymentDetails", Mobj.dtPaymentDetails);
                cmd.Parameters.AddWithValue("@PaysmsID", Mobj.PaysmsID);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                SqlParameter outputParamErrorLog = cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 1000);
                outputParamErrorLog.Direction = ParameterDirection.Output;
                daPaymentDetails.SelectCommand = cmd;
                daPaymentDetails.Fill(dsPaymentDetails);

                if (dsPaymentDetails != null && dsPaymentDetails.Tables.Count > 3 && dsPaymentDetails.Tables[3] != null)
                {
                    for (int i = 0; i < dsPaymentDetails.Tables[3].Rows.Count; i++)
                    {
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = dsPaymentDetails.Tables[3].Columns.Contains("profile_name") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["profile_name"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["profile_name"].ToString() : string.Empty;
                            smtp.recipients = dsPaymentDetails.Tables[3].Columns.Contains("recipients") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["recipients"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["recipients"].ToString() : string.Empty;
                            smtp.body = dsPaymentDetails.Tables[3].Columns.Contains("body") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["body"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["body"].ToString() : string.Empty;
                            smtp.subject = dsPaymentDetails.Tables[3].Columns.Contains("subject") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["subject"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["subject"].ToString() : string.Empty;
                            smtp.body_format = dsPaymentDetails.Tables[3].Columns.Contains("body_format") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["body_format"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["body_format"].ToString() : string.Empty;
                            Istatus = smtp.Status = dsPaymentDetails.Tables[3].Columns.Contains("Status") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["Status"].ToString()) ? Convert.ToInt32(dsPaymentDetails.Tables[3].Rows[i]["Status"]) : inull;
                        }
                        li.Add(smtp);
                    }
                    IntStatus = (Istatus != null && Istatus != 0) ? 1 : 0;
                    if (Mobj.PaysmsID == 1)
                    {
                        Commonclass.SendMailSmtpMethod(li, "info");
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmd.Parameters[3].Value) == 1) { IntStatus = 1; }
                    else { IntStatus = 0; }
                }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, "CustomerInsertPaymentDetilsInfo_New", null); }
            finally
            {

                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            if (dsPaymentDetails.Tables.Count == 0) { dsPaymentDetails = null; }
            return IntStatus;
        }

        public ArrayList ProfilePaymentDetails_Gridview(long? intProfileID, string spName)
        {
            int? intStatus = 0;
            DataSet dsPayment = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;

            SqlParameter[] parm = new SqlParameter[7];
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = intProfileID;

                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                parm[2] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[2].Direction = ParameterDirection.Output;

                dsPayment = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[1].Value); }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(intProfileID), "ProfilePaymentDetails_Gridview", null); }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            if (dsPayment.Tables.Count == 0)
                dsPayment = null;

            return Commonclass.convertdataTableToArrayList(dsPayment);

        }

        public ArrayList DgetProfilePaymentDetails_NewDesigns(long? intProfileID, string spName)
        {
            int? intStatus = 0;
            DataSet dsPayment = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;


            SqlParameter[] parm = new SqlParameter[7];
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = intProfileID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                parm[2] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[2].Direction = ParameterDirection.Output;

                dsPayment = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[1].Value); }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(intProfileID), "DgetProfilePaymentDetails_NewDesigns", null); }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            if (dsPayment.Tables.Count == 0)
                dsPayment = null;
            return Commonclass.convertdataTableToArrayList(dsPayment);
        }



        public ArrayList getCustomerPaymentPackagesDisplayDal(long? LcustID, string spName)
        {

            DataSet dsPayment = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandTimeout = 120;
            SqlParameter[] parm = new SqlParameter[1];
            try
            {
                parm[0] = new SqlParameter("@i_FromCustID", SqlDbType.BigInt);
                parm[0].Value = LcustID;

                dsPayment = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(LcustID), "DgetProfilePaymentDetails_NewDesigns", null); }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            if (dsPayment.Tables.Count == 0)
                dsPayment = null;
            return Commonclass.convertdataTableToArrayList(dsPayment);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 

        public string RSAccavenue(Rsakey Rsakey)
        {
            String message = null;

            try
            {
                string queryUrl = "https://secure.ccavenue.com/transaction/getRSAKey";

                string vParams = "";


                //for (int icount = 1; array.Count > icount; icount++)
                //{
                //    string indexname = array[icount].ToString();
                //    vParams += indexname + "=" + array[icount]+ "&";

                //}



                vParams += "merchant_id" + "=" + Commonclass.checknullornot(Rsakey.merchant_id) + "&";
                vParams += "order_id" + "=" + Commonclass.checknullornot(Rsakey.order_id) + "&";
                vParams += "currency" + "=" + Commonclass.checknullornot(Rsakey.currency) + "&";
                vParams += "amount" + "=" + Commonclass.checknullornot(Rsakey.amount) + "&";
                vParams += "redirect_url" + "=" + Commonclass.checknullornot(Rsakey.redirect_url) + "&";
                vParams += "cancel_url" + "=" + Commonclass.checknullornot(Rsakey.cancel_url) + "&";
                vParams += "language" + "=" + Commonclass.checknullornot(Rsakey.language) + "&";
                vParams += "billing_name" + "=" + Commonclass.checknullornot(Rsakey.billing_name) + "&";
                vParams += "billing_address" + "=" + Commonclass.checknullornot(Rsakey.billing_address) + "&";
                vParams += "billing_city" + "=" + Commonclass.checknullornot(Rsakey.billing_city) + "&";
                vParams += "billing_state" + "=" + Commonclass.checknullornot(Rsakey.billing_state) + "&";
                vParams += "billing_zip" + "=" + Commonclass.checknullornot(Rsakey.billing_zip) + "&";
                vParams += "billing_country" + "=" + Commonclass.checknullornot(Rsakey.billing_country) + "&";
                vParams += "billing_tel" + "=" + Commonclass.checknullornot(Rsakey.billing_tel) + "&";
                vParams += "billing_email" + "=" + Commonclass.checknullornot(Rsakey.billing_email) + "&";
                vParams += "delivery_name" + "=" + Commonclass.checknullornot(Rsakey.delivery_name) + "&";
                vParams += "delivery_addres" + "=" + Commonclass.checknullornot(Rsakey.delivery_addres) + "&";
                vParams += "delivery_city" + "=" + Commonclass.checknullornot(Rsakey.delivery_city) + "&";
                vParams += "delivery_state" + "=" + Commonclass.checknullornot(Rsakey.delivery_state) + "&";
                vParams += "delivery_zip" + "=" + Commonclass.checknullornot(Rsakey.delivery_zip) + "&";
                vParams += "delivery_country" + "=" + Commonclass.checknullornot(Rsakey.delivery_country) + "&";
                vParams += "delivery_tel" + "=" + Commonclass.checknullornot(Rsakey.delivery_tel) + "&";

                vParams += "merchant_param1" + "=" + Commonclass.checknullornot(Rsakey.merchant_param1) + "&";
                vParams += "merchant_param2" + "=" + Commonclass.checknullornot(Rsakey.merchant_param2) + "&";
                vParams += "merchant_param3" + "=" + Commonclass.checknullornot(Rsakey.merchant_param3) + "&";
                vParams += "merchant_param4" + "=" + Commonclass.checknullornot(Rsakey.merchant_param4) + "&";
                vParams += "merchant_param5" + "=" + Commonclass.checknullornot(Rsakey.merchant_param5) + "&";
                vParams += "promo_code" + "=" + Commonclass.checknullornot(Rsakey.promo_code) + "&";
                vParams += "customer_identifie" + "=" + Commonclass.checknullornot(Rsakey.customer_identifie) + "&";

                vParams += "access_code" + "=" + "AVED04CD92AO01DEOA" + "&";

                // Url Connection

                message = postPaymentRequestToGateway(queryUrl, vParams);

                //Response.Write(message);
            }
            catch (Exception exp)
            {
                Commonclass.ApplicationErrorLog("RSAccavenue", Convert.ToString(exp.Message), Convert.ToInt32(Rsakey.merchant_id), "RSAccavenue post method call", null);
            }

            return message;
        }

        private string postPaymentRequestToGateway(String queryUrl, String urlParam)
        {
            String message = "";
            try
            {
                StreamWriter myWriter = null;// it will open a http connection with provided url
                WebRequest objRequest = WebRequest.Create(queryUrl);//send data using objxmlhttp object
                objRequest.Method = "POST";
                //objRequest.ContentLength = TranRequest.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";//to set content type
                myWriter = new System.IO.StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(urlParam);//send data
                myWriter.Close();//closed the myWriter object

                // Getting Response
                System.Net.HttpWebResponse objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();//receive the responce from objxmlhttp object 
                using (System.IO.StreamReader sr = new System.IO.StreamReader(objResponse.GetResponseStream()))
                {
                    message = sr.ReadToEnd();
                }
            }
            catch (Exception exception)
            {
                Console.Write("Exception occured while connection." + exception);
            }

            return message;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="encResp"></param>
        /// <param name="workingKey"></param>
        /// <returns></returns>
        /// 

        public string getResponseHandler(string encResp, string workingKey)
        {
            // string workingKey = "";//put in the 32bit alpha numeric key in the quotes provided here
            string strResponsewirite = string.Empty;

            CCACrypto ccaCrypto = new CCACrypto();

            /// string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            string encResponse = ccaCrypto.Decrypt(encResp, workingKey);

            NameValueCollection Params = new NameValueCollection();

            string[] segments = encResponse.Split('&');

            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            for (int i = 0; i < Params.Count; i++)
            {
                if (string.IsNullOrEmpty(strResponsewirite))
                {
                    strResponsewirite = strResponsewirite + Params.Keys[i] + " = " + Params[i] + "<br>";
                }
                else
                {
                    strResponsewirite = Params.Keys[i] + " = " + Params[i] + "<br>";
                }
            }

            return strResponsewirite;

        }

        public singlePaymentPackages getcustomersinglePaymentPackagesDisplay(long? icustid, int? imembershipTypeID, string spName)
        {


            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();


            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader drReader = null;

            string TableName = string.Empty;
            int? intnull = null;
            singlePaymentPackages singlepackage = null;


            try
            {

                parm[1] = new SqlParameter("@i_FromCustID", SqlDbType.Int);
                parm[1].Value = icustid;

                parm[2] = new SqlParameter("@imembershipTypeID", SqlDbType.Int);
                parm[2].Value = imembershipTypeID;

                drReader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);


                if (drReader.HasRows)
                {
                    while (drReader.Read())
                    {
                        singlepackage = new singlePaymentPackages()
                        {
                            membershipName = drReader["MembershipName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("MembershipName")) : null,
                            membershipTypeID = drReader["MemberShipTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MemberShipTypeID")) : intnull,
                            membershipDuration = drReader["MemberShipDuration"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MemberShipDuration")) : intnull,
                            allottedServicePoints = drReader["AllottedServicePoints"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("AllottedServicePoints")) : intnull,
                            membershipAmount = drReader["MembershipAmount"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MembershipAmount")) : intnull,
                            accessFeatue = drReader["AccessFeatue"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("AccessFeatue")) : null,
                            Ppluspath = drReader["Ppluspath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Ppluspath")) : null,
                            Ppath = drReader["Ppath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Ppath")) : null

                        };
                    }
                }

                            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();

            }

            return singlepackage;

        }

        public List <singlePaymentPackages> getcustomerMultiPaymentPackagesDisplay(long? icustid, string spName)
        {


            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();


            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader drReader = null;

            string TableName = string.Empty;
            int? intnull = null;
            singlePaymentPackages singlepackage = null;

            List<singlePaymentPackages> multi = new List<singlePaymentPackages>(); 

            try
            {

                parm[1] = new SqlParameter("@i_FromCustID", SqlDbType.Int);
                parm[1].Value = icustid;

                drReader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (drReader.HasRows)
                {
                    while (drReader.Read())
                    {
                        singlepackage = new singlePaymentPackages()
                        {
                            membershipName = drReader["MembershipName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("MembershipName")) : null,
                            membershipTypeID = drReader["MemberShipTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MemberShipTypeID")) : intnull,
                            membershipDuration = drReader["MemberShipDuration"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MemberShipDuration")) : intnull,
                            allottedServicePoints = drReader["AllottedServicePoints"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("AllottedServicePoints")) : intnull,
                            membershipAmount = drReader["MembershipAmount"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MembershipAmount")) : intnull,
                            accessFeatue = drReader["AccessFeatue"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("AccessFeatue")) : null,
                            Ppluspath = drReader["Ppluspath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Ppluspath")) : null,
                            Ppath = drReader["Ppath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Ppath")) : null

                        };

                        multi.Add(singlepackage);
                    }
                }


            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();

            }

            return multi;

        }


    }
}