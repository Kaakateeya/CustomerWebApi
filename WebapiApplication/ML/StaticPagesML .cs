﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{

    public class SuccessStoryML
    {
        public Int64? successid { get; set; }
        public string vc_ProfileID { get; set; }
        public int? i_RegionID { get; set; }
        public int? casteid { get; set; }
        public int? branchid { get; set; }
        public int? pagefrom { get; set; }
        public int? pageto { get; set; }

    }

    public class Sucessstories
    {
        public string GroomName { set; get; }
        public string BrideName { set; get; }
        public string GroomProfileID { set; get; }
        public string BrideProfileID { set; get; }
        public string MarriageDate { set; get; }
        public string PhotoPath { set; get; }
    }

    public class PhotoPathDisplay
    {
        public string ThumbNailPath { set; get; }
        public string FullPhotoPath { set; get; }
        public string ApplicationPhotoPath { set; get; }
    }

    public class mobileOrderDisplay
    {
        public long? custID { set; get; }
        public int? startIndex { set; get; }
        public int? endIndex { set; get; }
        public string type { set; get; }
    }

    public class MobileEmailVerf
    {
        public long? CustID { set; get; }
        public string Email { set; get; }
        public string MobileNumber { set; get; }
        public int? CountryCode { set; get; }
        public string VerificationCode { set; get; }
        public int? isVerified { set; get; }
    }
    public class ProfileSettings
    {
        public string Email { set; get; }
        public Int64? EmailCust_Family_ID { set; get; }
        public string Mobilenumber { set; get; }
        public Int64? MobileCustFamily_ID { set; get; }
        public Int64? ProfileStatusID { set; get; }
        public DateTime? InActiveFromDate { set; get; }
        public DateTime? InActiveToDate { set; get; }
        public bool? AllowEmail { set; get; }
        public bool? AllowSMS { set; get; }
        public string Password { set; get; }
    }

    public class Supporttickets
    {
        public int? Sno { get; set; }
        public string TicketID { get; set; }
        public Int64? TicketNO { get; set; }
        public string OpenedDate { get; set; }
        public string TicketStatus { get; set; }
        public string StatusDate { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
        public string Reportedby { get; set; }
        public string Email { get; set; }
        public string AssignedToEmp { get; set; }
        public string PendingWith { get; set; }
        public int? pageid { get; set; }
    }

    public class Myorders
    {
        public string RegistrationDate { get; set; }
        public string LastModifiedDate { get; set; }
        public string LoginCount { get; set; }
        public string LastLoginDate { get; set; }
        public string ProfileVistitedCount { get; set; }
        public string PaymentStatus { get; set; }
        public string ExpiryDate { get; set; }
        public string OnlineMembership { get; set; }
        public string MaxPoints { get; set; }
        public string Balancepoints { get; set; }
        public string offPaymentStatus { get; set; }
        public string offExpiryDate { get; set; }
        public string OfflineMembership { get; set; }
        public string offMaxPoints { get; set; }
        public string offBalancepoints { get; set; }
        public string paidondate { get; set; }
        public string paidoffdate { get; set; }
        public string FutureDate { get; set; }
        public string FutureExpiry { get; set; }
        public string ProfileDay { get; set; }
        public string Max_Booster_Allowed { get; set; }
        public string Booster_Used_Count { get; set; }
        public string Total_Count { get; set; }
        public string Max_AstroMatchMatch_Allowed { get; set; }
        public string AstroMatch_Used_Count { get; set; }
        public string AstroMatch_Balance { get; set; }
        public string Add_on { get; set; }
    }


    public class UpgradeMembership
    {
        public string MembershipName { get; set; }
        public int? Emp_Membership_ID { get; set; }
        public int? MemberShipDuration { get; set; }
        public Int64? Cust_MemberShip_Discount_ID { get; set; }
        public float? DiscountAmount { get; set; }
        public int? AllottedServicePoints { get; set; }
        public float? MembershipAmount { get; set; }
        public string onlineaccess { get; set; }
        public string offlineaccess { get; set; }
        public string Ppluspath { get; set; }
        public string Ppath { get; set; }

    }

    public class CustFeebBackML
    {
        private string cust_id;

        public string Cust_id { get { return cust_id; } set { cust_id = value; } }
        private string herabout;

        public string Herabout { get { return herabout; } set { herabout = value; } }
        private string improvewebsite;

        public string Improvewebsite
        {
            get { return improvewebsite; }
            set { improvewebsite = value; }
        }
        private string kaaprices;
        public string Kaaprices
        {
            get { return kaaprices; }
            set { kaaprices = value; }
        }
        private string downloadTime;

        public string DownloadTime
        {
            get { return downloadTime; }
            set { downloadTime = value; }
        }
        public string CompareSite;

        public string CompareSite1
        {
            get { return CompareSite; }
            set { CompareSite = value; }
        }
        public string FavSite;

        public string FavSite1
        {
            get { return FavSite; }
            set { FavSite = value; }
        }
        private string Searchrate;

        public string Searchrate1
        {
            get { return Searchrate; }
            set { Searchrate = value; }
        }
        private string Recommned;
        public string Recommned1
        {
            get { return Recommned; }
            set { Recommned = value; }
        }
        private string Commments;

        public string Commments1 { get { return Commments; } set { Commments = value; } }

        public string Cust_ID { get; set; }

        public string HearAbout { get; set; }

        public string ImproveWebsite { get; set; }

        public string kaaPrices { get; set; }

        public string DownLoadTime { get; set; }

        public string Comments { get; set; }

        public string Recommend { get; set; }

        public string SearchRate { get; set; }

    }
    public class Smtpemailsending
    {
        public string profile_name { get; set; }
        public string recipients { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
        public string body_format { get; set; }
        public int? Status { get; set; }
        public int Statusint { get; set; }
        public int CustID { get; set; }
    }
    public class SendServiceProfileIds
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileID { get; set; }
        public int? ProfileStatusID { get; set; }
        public long? CustID { get; set; }
        public int? GenderID { get; set; }

        public int? IsConfidential { get; set; }

        public int? HighConfendential { get; set; }

        public string RegionName { get; set; }
    }
    public class KaakateeyaBranchesML
    {
        public string BranchAddress { set; get; }
        public string PhoneNumbers { set; get; }
        public string Mobilenumber { set; get; }
        public string BranchemailID { set; get; }
        public string WorkingEndTime { set; get; }
        public int? Branch_ID { set; get; }
        public string Address { set; get; }
        public string WorkingStartTime { set; get; }
        public string Landlineareacode { set; get; }
        public string Landlinenumber { set; get; }
        public string BranchesName { set; get; }
    }

    public class TicketCreationMl
    {
        public Int64? profile { get; set; }
        public Int64? AssignedEmpID { get; set; }
        public Int64? BranchID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string subject { get; set; }
        public int? Category { get; set; }
        public string Message { get; set; }
        public int? Priority { get; set; }
        public string Image { get; set; }
        public int? CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNum { get; set; }
        public Int64? EmpID { get; set; }

    }
    public class TicketDetails
    {
        public int? PageID { get; set; }
        public Int64? CustID { get; set; }
        public int? TicketID { get; set; }
        public string ProfileID { get; set; }
        public string Complaint { get; set; }
        public int? FeedBackStatus { get; set; }
    }
    public class HelpMail
    {
        public long? iTicketID { get; set; }
        public string Ticket { get; set; }
        public Int64? Cust_ID { get; set; }
        public string TicketID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string strEmail { get; set; }
        public Int64? EmpID { get; set; }
        public Int64? EmpTicketID { get; set; }

        public int Status { get; set; }
    }


    public class ExpressinterestbookmarkGetting
    {
        public int? BookmarkFlag { get; set; }
        public int? IgnoreFlag { get; set; }
        public int? Viewedflag { get; set; }

        public int? ExpressFlag { get; set; }
        public int? Acceptflag { get; set; }
        public int? TimeFlag { get; set; }
        public int? MatchFollowUpStatus { get; set; }
        public Int64? ExpressInterstId { get; set; }
        public Int64? TicketID { get; set; }
        public string SeenStatus { get; set; }
        public string ViewTicket { get; set; }
        public string Paidstatus { get; set; }
    }
    public class cust_bindings
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

}