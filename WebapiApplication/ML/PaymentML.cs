using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebapiApplication.ML
{
    public class Paymentselect
    {
        public string MembershipName { get; set; }
        public int? Emp_Membership_ID { get; set; }
        public int? MemberShipDuration { get; set; }
        public Int64? Cust_MemberShip_Discount_ID { get; set; }
        public int? DiscountAmount { get; set; }
        public int? AllottedServicePoints { get; set; }
        public double? MembershipAmount { get; set; }
        public string onlineaccess { get; set; }
        public string offlineaccess { get; set; }
        public string Ppluspath { get; set; }
        public string Ppath { get; set; }
        public int? AccessFeature { set; get; }

    }
    public class PaymentMasterMl
    {
        public long? intCustID { get; set; }
        public long? intMembershipID { get; set; }
        public long? DiscountID { get; set; }
        public int? Points { get; set; }
        public string MembershipName { get; set; }
        public int? Duration { get; set; }
        public string MembershipAmount { get; set; }
        public int? PaysmsID { get; set; }
        public int? Isonline { get; set; }
        public DataTable dtPaymentDetails { get; set; }
    }

    public class CustomerPaymentML
    {
        public int? ProfileID { get; set; }
        public int? Genderid { get; set; }
        public int? NoofPoints { get; set; }
        public string MemberShipName { get; set; }
        public float? AgreedAmount { get; set; }
        public int? Casteid { get; set; }
        public int? MemberShipTypeID { get; set; }
        public string SettlementAmount { get; set; }
        public int? DateDuration { get; set; }
        public float ServiceTax { get; set; }
        public string Branch { get; set; }
        public string AmountPaid { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReceiptNumber { get; set; }
        public string TransactionID { get; set; }
        public string ChequeNoOrDDNo { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public string Place { get; set; }
        public string Paydescription { get; set; }
        public int? ModeOfPayment { get; set; }
        public int? EmpID { get; set; }
        public int? MembershipID { get; set; }
        public int? Cust_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? StartDate { get; set; }
        public string MemberShipDescription { get; set; }
        public string ApplicationName { get; set; }
        public string MemberShipType { get; set; }
        public string CasteName { get; set; }
        public string Gender { get; set; }
        public int? Flag { get; set; }
        public DataTable dtPaymentDetails { get; set; }
        public int? Isonline { get; set; }
        public int PaysmsID { get; set; }
    }

    public class PaymentInsertML
    {
        public int? ProfileID { get; set; }
        public int? Cust_id { get; set; }
        public int? Payment_Id { get; set; }
        public int? Renual_Type { get; set; }
        public int NoofPoints { get; set; }
        public float? AgreedAmount { get; set; }
        public string SettlementAmount { get; set; }
        public int? DateDuration { get; set; }
        public float? ServiceTax { get; set; }
        public float? ServiceTaxAmt { get; set; }
        public string AmountPaid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReceiptNumber { get; set; }
        public string TransactionID { get; set; }
        public string ChequeNoOrDDNo { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public string Place { get; set; }
        public string Paydescription { get; set; }
        public int? ModeOfPayment { get; set; }
        public int? EmpID { get; set; }

        public int? AccessFeatureID { get; set; }
        public DataTable dtPaymentDetails { get; set; }
        public int? Isonline { get; set; }
        public int PaysmsID { get; set; }
    }

    public class Rsakey
    {
        public string merchant_id { set; get; }
        public string order_id { set; get; }
        public string currency { set; get; }
        public string amount { set; get; }
        public string redirect_url { set; get; }
        public string cancel_url { set; get; }
        public string language { set; get; }
        public string billing_name { set; get; }
        public string billing_address { set; get; }
        public string billing_city { set; get; }
        public string billing_state { set; get; }
        public string billing_zip { set; get; }
        public string billing_country { set; get; }
        public string billing_tel { set; get; }
        public string billing_email { set; get; }
        public string delivery_name { set; get; }
        public string delivery_addres { set; get; }
        public string delivery_city { set; get; }
        public string delivery_state { set; get; }
        public string delivery_zip { set; get; }
        public string delivery_country { set; get; }
        public string delivery_tel { set; get; }
        public string merchant_param1 { set; get; }
        public string merchant_param2 { set; get; }
        public string merchant_param3 { set; get; }
        public string merchant_param4 { set; get; }
        public string merchant_param5 { set; get; }
        public string promo_code { set; get; }
        public string customer_identifie { set; get; }

    }

    public class singlePaymentPackages
    {
        public string membershipName { set; get; }
        public int? membershipTypeID { set; get; }
        public int? membershipDuration { set; get; }
        public int? allottedServicePoints { set; get; }
        public int? membershipAmount { set; get; }
        public string accessFeatue { set; get; }
        public string Ppluspath { set; get; }
        public string Ppath { set; get; }

    }


}
