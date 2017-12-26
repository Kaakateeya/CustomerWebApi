using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebapiApplication.ML
{
    public class CustSearchMl
    {
        public Int64? OwnerCustID { get; set; }
        public Int64? OppositCustID { get; set; }
        public Int32? PageID { get; set; }
        public string SpName { get; set; }
        public string SavedSearchName { get; set; }
        public string SavedSearchData { get; set; }
        public int SavedSearchID { get; set; }
        public string EditSavedSearch { get; set; }
        public Int64? CustID { get; set; }
        public string StrVerficationCode { get; set; }
        public int SearchFlag { get; set; }
        public int? SearchID { get; set; }
        public DataTable dtAdvanceData { get; set; }
        public DataTable dtGeneralData { get; set; }
        public DataTable dtQuickData { get; set; }
        public string StrKeywordData { get; set; }
        public string StrProfileIDData { get; set; }
        public DataTable dtIamLookingFor { get; set; }
        public Int64? BookmaredByCustID { get; set; }
        public Int64? BookmaredCustID { get; set; }
        public int BookmaredFlag { get; set; }
        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Int64? RequestedToCustID { get; set; }
        public Int64? RequestedByCustID { get; set; }
        public int? PhotoRequestedID { get; set; }
        public int PhotoRequestedCount { get; set; }
        public int Category { get; set; }
        public string StrHtmlText { get; set; }

        public Int64? ExpresedCustID { get; set; }
        public Int64? ExpressInterestedCustID { get; set; }

        public Int64? FromCustID { get; set; }
        public Int64? ToCustID { get; set; }
        public string strToCustID { get; set; }
        public Int32? MessageStatusId { get; set; }
        public Int32 SendAnyway { get; set; }
        public Int64? EmpId { get; set; }
        public Int32 ReadFlag { get; set; }
        public Int64? MessageHistoryId { get; set; }
        public Int32 Accepted { get; set; }
        public Int64? MessageLinkId { get; set; }
        public int PaidFlag { get; set; }
        public int Flag { get; set; }

        public string RecName { get; set; }
        public string RecEmail { get; set; }
        public string RecMessage { get; set; }
        public string RecMessageContent { get; set; }

        public string EncriptedText { get; set; }
        public string EncryptedFlagText { get; set; }
        public string EncryptedRejectFlagText { get; set; }

        public string EncriptedTextrvr { get; set; }

        public string EncryptedFlagTextrvr { get; set; }

        public string EncryptedRejectFlagTextrvr { get; set; }

        public string StrHtmlTextrvr { get; set; }

        public long CustIDrvr { get; set; }

        public string Totalcount { get; set; }

        public int month { get; set; }

        public DataTable dtExpressInterest { get; set; }

        public long? TargetProfileID { get; set; }

        public string strFromCustID { get; set; }

        public string strMessageComments { get; set; }

        public string strRecipientEmailIDs { get; set; }

        public string strRecipientName { get; set; }

        public int AcceptStatus { get; set; }

        public int MatchFollwupStatus { get; set; }
        public long ExpressInrestID { get; set; }
        public int? noofDays { get; set; }
        public string strtypeOfReport { get; set; }
        public string Methodname { get; set; }
        public string StrTocustIDs { get; set; }
        public int? IFromCustID { get; set; }
        public int? IToCustID { get; set; }
        public string TypeofInsert { get; set; }

        public long? Logid { get; set; }

        public string FromProfileID { get; set; }

        public string ToProfileID { get; set; }
    }
    public class ProfileStatus
    {
        public string OwnerName { get; set; }
        public long? CustID { get; set; }
        public int? statuss { get; set; }
        public string PrimaryEmail { get; set; }
    }
    public class InsertUnpaid
    {
        public string fromCustID { get; set; }
        public string ToCustID { get; set; }
        public int? Empid { get; set; }
        public string typeofAction { get; set; }
    }

    public class ViewfullProfileML
    {

        public string FromProfileID { get; set; }
        public string ToProfileID { get; set; }
        public int status { get; set; }
        public string ToCustID { get; set; }
        public string FromCustID { get; set; }
        public string PrimaryEmail { get; set; }

        public string AccRejFlag { get; set; }

        public string FromProfileName { get; set; }

        public string FromProfileLastName { get; set; }

        public int? Fromgender { get; set; }

        public int? IsConfidential { get; set; }
        public int? HighConfendential { get; set; }
        public string RegionName { get; set; }
    }
    public class UpdateExpressIntrestStatus
    {
        public long? ExpressInrestID { get; set; }
        public int? MatchFollwupStatus { get; set; }
        public int? AcceptStatus { get; set; }
        public long? CustID { get; set; }
        public int? noofDays { get; set; }
        public string spName { get; set; }
    }



    /// <summary>
    /// /create  for  mobille app  class
    /// </summary>
    /// 
    public class CustomerLandingOrderResponse
    {

        public bool? isPhoto { get; set; }
        public bool? isPaidUser { get; set; }
        public string surName { get; set; }
        public string firstName { get; set; }
        public string profileId { get; set; }
        public string photoUrl { get; set; }

        public List<subscriptionPlans> subscriptionPlans { get; set; }
        public List<notifications> notifications { get; set; }
        public rmgDetails rmgDetails { get; set; }

    }

    public class mobileActiveStatus
    {
        public string lastloginDate { get; set; }
        public string customerStatus { get; set; }
    }


    public class PhotoStatus
    {

        public bool? isPhoto { get; set; }
        public bool? isPaidUser { get; set; }
        public string surName { get; set; }
        public string firstName { get; set; }
        public string profileId { get; set; }
        public string photoUrl { get; set; }

    }
    public class subscriptionPlans
    {
        public string plan { set; get; }
        public int? planAmount { get; set; }
    }
    public class notifications
    {
        public string profileId { get; set; }
        public string photoUrl { get; set; }
        public string message { get; set; }
    }

    public class rmgDetails
    {
        public string name = string.Empty;
        public string contactInfo = string.Empty;
    }

    public class rmgDetailsdisply
    {

        //public string name { set; get; }
        //public int? customerOwnerEmpID { set; get; }
        public string customerOwnerName { set; get; }
        public string mobilenumber { set; get; }
        public string landnumber { set; get; }
        public string branchName { set; get; }
        public string email { set; get; }
        public string customerownerFullName { set; get; }

    }
    public class MobileLandingOrderDisplay
    {
        public int? totalRows { set; get; }
        public List<displayData> data { get; set; }
    }

    public class viewedByOther
    {

        public MobileLandingOrderDisplay viewedByOthers { set; get; }

        public MobileLandingOrderDisplay bookMarkedByOthers { set; get; }

        public MobileLandingOrderDisplay viewedByme { set; get; }



        public MobileLandingOrderDisplay bookMarkedByMe { set; get; }

        public MobileLandingOrderDisplay exactMatchingProfiles { set; get; }

        public MobileLandingOrderDisplay suitableProfiles { set; get; }

    }



    public class displayData
    {

        public string profileID { set; get; }
        public Int64? custID { set; get; }
        public string lastName { get; set; }
        public int? age { set; get; }
        public string religionName { get; set; }
        public string caste { get; set; }
        public string educationGroup { get; set; }
        public string profession { get; set; }
        public string location { get; set; }
        public bool? isMyBookMarked { get; set; }
        public bool? isRecentlyViewed { get; set; }
        public bool? isIgnored { get; set; }
        public bool? expressFlag { get; set; }
        public string thumbnailPhotoUrl { get; set; }
        public string fullphotoimageUrl1 { get; set; }
        public string fullphotoimageUrl2 { get; set; }
        public string fullphotoimageUrl3 { get; set; }

    }





    public class PaymentMembership
    {
        public string MembershipName { get; set; }
        public int? MemberShipTypeID { get; set; }
        public int? MemberShipDuration { get; set; }
        public int? AllottedServicePoints { get; set; }
        public int? MembershipAmount { get; set; }
        public string AccessFeatue { get; set; }
        public string Ppluspath { get; set; }
        public string Ppath { get; set; }
    }
    public class Notifications
    {
        public int? Cust_NotificationID { get; set; }
        public int? CategoryID { get; set; }
        public int? ToCust_Id { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }


        public int? Cust_ID { get; set; }
        public int? LogID { get; set; }
        public int? unpaidnotify { get; set; }
        public int? TotalRows { get; set; }
        public int? Totalpages { get; set; }
        public string ProfilePic { set; get; }
    }
    public class ProfileOwner
    {
        public long? CustomerOwnerEmpID { get; set; }
        public string CustomerOwnerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerLand { get; set; }
        public string CustomerBranch { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerOwnerFullName { get; set; }
    }


    public class LandingOrderStatus
    {
        public bool? PaidStatus { set; get; }
        public bool? Notifications { set; get; }
        public bool? ProfileOwner { set; get; }
        public bool? PhtoStatus { set; get; }
    }

    public class LandingOrderStatusResult
    {
        //PhtoStatus
        public string ProfilePic { get; set; }

        //PaymentMembership
        public string MembershipName { get; set; }
        public int? MemberShipTypeID { get; set; }
        public int? MemberShipDuration { get; set; }
        public int? AllottedServicePoints { get; set; }
        public int? MembershipAmount { get; set; }
        public string AccessFeatue { get; set; }
        public string Ppluspath { get; set; }
        public string Ppath { get; set; }

        // Notifications
        public int? Cust_NotificationID { get; set; }
        public int? CategoryID { get; set; }
        public int? ToCust_Id { get; set; }
        public string ActionType { get; set; }
        public string ActionDate { get; set; }


        public int? Cust_ID { get; set; }
        public int? LogID { get; set; }
        public int? unpaidnotify { get; set; }
        public int? TotalRows { get; set; }
        public int? Totalpages { get; set; }

        // ProfileOwner
        public long? CustomerOwnerEmpID { get; set; }
        public string CustomerOwnerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerLand { get; set; }
        public string CustomerBranch { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerOwnerFullName { get; set; }
    }
}