﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections;
using WebapiApplication.DAL;
using System.Data;
using WebapiApplication.ServiceReference1;
using WebapiApplication.Common;
using System.Net.Http;

namespace WebapiApplication.Api
{

    public class StaticPagesController : ApiController
    {

        private readonly IStaticPages ISuccessStories; public StaticPagesController() : base() { this.ISuccessStories = new ImpStaticPages(); }
        public HelpMail InsertTicketInfo([FromBody]TicketCreationMl Mobj) { return this.ISuccessStories.ImpInsertTicketInfo(Mobj); }
        public ViewfullProfileML getViewFullProfileMail(string OriginalString) { return this.ISuccessStories.ViewFullProfileMail(OriginalString); }
        public List<Sucessstories> SuccessStoriesdetails([FromBody]SuccessStoryML SML) { return this.ISuccessStories.getSucessstoriesdetails(SML); }
        public List<KaakateeyaBranchesML> getKaakateeyaBranchesDetails(string dependencyName, string dependencyValue, string dependencyflagID) { return this.ISuccessStories.ImpgetKaakateeyaBranchesDetails(dependencyName, dependencyValue, dependencyflagID); }
        public List<ProfileSettings> getcustomerProfilesettings(Int64? CustID) { return this.ISuccessStories.customerProfilesettings(CustID); }
        public List<PhotoPathDisplay> GetPhotoSlideImages(string CustID) { return this.ISuccessStories.GetPhotoSlideImages(CustID); }
        public ArrayList getCustomerViewfullProfileDetails([FromUri]long? ProfileID, [FromUri]int? CustID, [FromUri]int? RelationshipID) { return this.ISuccessStories.CustomerViewfullProfileDetails(ProfileID, CustID, RelationshipID); }
        public ArrayList getExpressinterstBookmarkIgnore([FromUri]long? loggedcustid, [FromUri]long? ToCustID) { return this.ISuccessStories.GetExpressinterstBookmarkIgnore(loggedcustid, ToCustID); }
        public ArrayList getpaymentdetailsmethoddal(Int64? CustID) { return this.ISuccessStories.paymentdetailsmethoddal(CustID); }
        public ArrayList TicketDetails([FromBody]TicketDetails ticketdetails) { return this.ISuccessStories.GetTicketDetails(ticketdetails); }
        //public ArrayList getExpressIntrstfullprofile(string ToProfileID, string FromProfileID, int? EmpID) { return this.ISuccessStories.ExpressIntrstfullprofile(ToProfileID, FromProfileID, EmpID); }
        // public ArrayList getExpressIntrstfullprofile(int? tocustid, int? fromcustid, int? EmpID) { return this.ISuccessStories.ExpressIntrstfullprofile(tocustid, fromcustid, EmpID); }
        public ArrayList getExpressIntrstfullprofile(string ToProfileID, int? EmpID) { return this.ISuccessStories.ExpressIntrstfullprofile(ToProfileID, EmpID); }


        //15-09-2017

        public ArrayList getExpressIntrstfullprofilepaidandunpaid(string fromProfileID, Int64? toustid, int? EmpID) { return this.ISuccessStories.ExpressIntrstfullprofilepaidandunpaid(fromProfileID, toustid, EmpID); }

        public ArrayList getExpressinterst_bookmark_ignore_data(long? Loggedcustid, long? ToCustID) { return this.ISuccessStories.Expressinterst_bookmark_ignore_data(Loggedcustid, ToCustID); }
        public ArrayList getdisplayMissingFieldsupdate_Customerdetails(string CustID, int? i_updateflag) { return this.ISuccessStories.displayMissingFieldsupdate_Customerdetails(CustID, i_updateflag); }
        public ArrayList getCust_NotificationDetails(int? Cust_NotificationID, long? CustID, int? Startindex, int? EndIndex) { return this.ISuccessStories.Cust_NotificationDetails(Cust_NotificationID, CustID, Startindex, EndIndex); }
        public ArrayList getCheckForgotPasswordStatus(string StrCustID) { return this.ISuccessStories.CheckForgotPasswordStatus(StrCustID); }
        public ArrayList getRegisteredBranchStatus(string StrCustID) { return this.ISuccessStories.RegisteredBranchStatus(StrCustID); }

        public int UpdateExpressIntrestViewfullprofile([FromBody]UpdateExpressIntrestStatus Mobj) { return this.ISuccessStories.UpdateExpressIntrestViewfullprofile(Mobj); }
        public int getPhotopasswordAcceptReject(Int64? FromcustID, Int64? TocustID, Int64? Accept_Reject) { return this.ISuccessStories.PhotopasswordAcceptReject(FromcustID, TocustID, Accept_Reject); }
        public int getInsertcustomerProfilesettings(DateTime? Expirydate, int? CustID, int? iflag) { return this.ISuccessStories.InsertcustomerProfilesettings(Expirydate, CustID, iflag); }
        public int getDeletecustomerProfilesettings(Int64? ProfileID, string Narrtion) { return this.ISuccessStories.DeletecustomerProfilesettings(ProfileID, Narrtion); }
        public int getUpdatePassword(string OldPassword, string NewPassword, string ConfirmPassword, string custId) { return this.ISuccessStories.UpdatePassword(Commonclass.Encrypt(OldPassword), Commonclass.Encrypt(NewPassword), Commonclass.Encrypt(ConfirmPassword), custId); }
        public int CustomerRating_sendMail([FromBody]CustFeebBackML feedback) { return this.ISuccessStories.CustomerRating_sendMail(feedback); }
        public int getSendMail_PhotoRequest_Customer(string FromCustID, string ToCustID, int? Category) { if (Category == 467 && !string.IsNullOrEmpty(ToCustID)) { } return this.ISuccessStories.SendMail_PhotoRequest_Customer(FromCustID, ToCustID, Category); }
        public int getprofileGrade(string CustID) { return this.ISuccessStories.getprofileGrade(CustID); }
        public int SendTicketMail([FromBody]HelpMail Helpmail) { return this.ISuccessStories.ImpSendTicketMail(Helpmail); }
        public int getProfilesettingEmailMobileChange(Int64? FamilyID, string MobileEmail, int? CountryCodeID, int? imobileEmailflag) { return this.ISuccessStories.ProfilesettingEmailMobileChange(FamilyID, MobileEmail, CountryCodeID, imobileEmailflag); }
        public int getProfilesettingAllowEmailAllowSMS(Int64? CustID, int? AllowEmail, int? AllowSMS) { return this.ISuccessStories.ProfilesettingAllowEmailAllowSMS(CustID, AllowEmail, AllowSMS); }
        public int getEmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile) { return this.ISuccessStories.EmailMobilenumberexists(iflagEmailmobile, EmailMobile); }
        public int getCustomerReopenTicketStatus(int? PageID, int? ProfileID, int? TicketID) { return this.ISuccessStories.CustomerReopenTicketStatus(PageID, ProfileID, TicketID); }
        public int getForgotPassword(string Username) { return this.ISuccessStories.ForgotPassword(Username); }
        public int getConfirmUserEmail(string VerificationCode) { return this.ISuccessStories.ConfirmUserEmail(VerificationCode); }
        public int getCreateNewPassword(Int64? intCusID, string strPassword) { return this.ISuccessStories.CreateNewPassword(intCusID, Commonclass.Encrypt(strPassword)); }
        public int getResendEmailVerficationLink(long? CustID) { return this.ISuccessStories.ResendEmailVerficationLink(CustID); }
        public int MissingFieldsupdate_Customerdetails([FromBody]MissingFieldsUpdateRequest Mobj) { return this.ISuccessStories.MissingFieldsupdate_Customerdetails(Mobj); }
        public int getInsertUnpaidStatus(string fromCustID, string ToCustID, int? Empid, string typeofAction) { return this.ISuccessStories.InsertUnpaidStatus(fromCustID, ToCustID, Empid, typeofAction); }
        public int getInsertExpressViewTicket(long? FromCustID, long? ToCustID, string DecriptedText, string strtypeOfReport) { return this.ISuccessStories.InsertExpressViewTicket(FromCustID, ToCustID, Commonclass.Encrypt(DecriptedText), strtypeOfReport); }
        public int getChangePassword(string StrCustID, string Password) { return this.ISuccessStories.ChangePassword(StrCustID, Commonclass.Encrypt(Password)); }
        public void getCustomerApplicationErroLog(string ErrorMessage, long? CustID, string PageName, string Type) { Commonclass.ApplicationErrorLog(null, ErrorMessage, CustID, PageName, Type); }
        public void getUnpaidMembersOwnerNotification(int? CategoryID, int? Cust_ID, string SendPhonenumber) { DataTable dt = this.ISuccessStories.UnpaidMembersOwner_Notification(CategoryID, Cust_ID); Commonclass.PaymentSMS(dt, SendPhonenumber); }
        public void getApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type) { this.ISuccessStories.ApplicationErrorLog(ErrorSpName, ErrorMessage, CustID, PageName, Type); }
        public int getResendmobile(int? iCountryID, int? iCCode, string MobileNumber, int? CustContactNumbersID)
        {
            string VerfCode = Convert.ToString((new Random()).Next(10000, 99999).ToString()); Commonclass.ResendMobileSMS(iCountryID, iCCode, MobileNumber, VerfCode); this.ISuccessStories.EmilVerificationCode(VerfCode, 2, CustContactNumbersID, 0);
            return 1;
        }
        public string getEmilVerificationCode(string VerificationCode, int? i_EmilMobileVerification, int? CustContactNumbersID) { return this.ISuccessStories.EmilVerificationCode(VerificationCode, i_EmilMobileVerification, CustContactNumbersID, 1); }
        public string getCustomerfilldata(long? CustomerCustID) { return this.ISuccessStories.Customerfilldata(CustomerCustID); }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustID"></param>
        /// <param name="PaidStatus"></param>
        /// <param name="Startindex"></param>
        /// <param name="EndIndex"></param>
        /// <returns></returns>


        // public ArrayList getMobileAppLandingDisplay(int? CustID, int? Startindex, int? EndIndex) { return this.ISuccessStories.getMobileAppLandingDisplay(CustID, Startindex, EndIndex); }


        public CustomerLandingOrderResponse getMobileAppLandingDisplay(int? CustID)
        {
            CustomerLandingOrderResponse list = new CustomerLandingOrderResponse();
            list = this.ISuccessStories.getMobileAppLandingDisplay(CustID);
            return list;

        }

        public ArrayList UpdateCustomerEmailMobileNumber_Verification([FromBody]MobileEmailVerf Mobj)
        {

            if (Mobj.isVerified == 0 && !string.IsNullOrEmpty(Mobj.MobileNumber))
            {
                Mobj.VerificationCode = Convert.ToString((new Random()).Next(10000, 99999).ToString());
            }

            return this.ISuccessStories.UpdateCustomerEmailMobileNumber_Verification(Mobj);

        }


        public mobileActiveStatus getmobileloginStatus(int? custid) { return this.ISuccessStories.getmobileloginStatus(custid); }
        public viewedByOther getMobileLandingOrderDisplay_all(int custid) { return this.ISuccessStories.MobileLandingOrderDisplay(custid, 1, 9, "all"); }

        public viewedByOther getMobileLandingOrderDisplay(int custid, int? startIndex, int? endIndex, string type)
        {

            if (type == "all")
            {
                return this.ISuccessStories.MobileLandingOrderDisplay(custid, 1, 9, "all");
            }
            else
            {
                return this.ISuccessStories.MobileLandingOrderDisplaysingleselection(custid, startIndex, endIndex, type);
            }
        }



        //public  viewedByOther getMobileLandingOrderDisplay(long? CustID, string type) { return this.ISuccessStories.MobileLandingOrderDisplay(CustID, 1, 9, type); }

        public ArrayList getExpressIntrstfullprofilepartial(string ToProfileID, int? EmpID) { return this.ISuccessStories.ExpressIntrstfullprofilepartial(ToProfileID, EmpID); }

        public ArrayList getCustomerBindings() { return this.ISuccessStories.getCustomerBindings(); }

        public string getencryptedProfileID(string ProfileID) { return Commonclass.profileidEncrypt(ProfileID); }

        public string getdecryptedProfileID(string ProfileID) { return Commonclass.Decrypt_new(ProfileID); }


        public ArrayList getfromexpresstoexpressstatus(string Fromprofileid, string Toprofileid, int? Empid) { return ISuccessStories.fromexpresstoexpressstatus(Fromprofileid, Toprofileid, Empid); }

        public rmgDetailsdisply getrmgDetailsdisplay(int? custid) { return this.ISuccessStories.getrmgDetailsdisplay(custid); }  

        public ArrayList getfullprofileself(string ProfileID, int? EmpID) { return this.ISuccessStories.fullprofileself(ProfileID, EmpID); }

    }
}

