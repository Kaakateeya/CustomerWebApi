﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebapiApplication.ML;
using WebapiApplication.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.Http;
using WebapiApplication.DAL;

namespace WebapiApplication.Implement
{
    public class ImpStaticPages : IStaticPages
    {

        public HelpMail ImpInsertTicketInfo(TicketCreationMl Mobj) { return new StaticPagesDAL().DalInsertTicketInfo(Mobj, "[dbo].[usp_InsertTicketCreationInfo_Customer]"); }
        public ViewfullProfileML ViewFullProfileMail(string OriginalString) { return new StaticPagesDAL().ViewFullProfileMail(OriginalString); }
        public List<Sucessstories> getSucessstoriesdetails(SuccessStoryML SML) { return new StaticPagesDAL().GetSuccessStoriesDal(SML, "[dbo].[usp_successtoreies_cutomer]"); }
        public List<KaakateeyaBranchesML> ImpgetKaakateeyaBranchesDetails(string dependencyName, string dependencyValue, string dependencyflagID) { return new StaticPagesDAL().getKaakateeyaBranchesDetails(dependencyName, dependencyValue, dependencyflagID, "[dbo].[DropdownValues_dependency_injection]"); }
        public List<PhotoPathDisplay> GetPhotoSlideImages(string CustID) { return new StaticPagesDAL().GetPhotoSlideImages(CustID, "[dbo].[usp_PhotoSlideImages]"); }
        public List<ProfileSettings> customerProfilesettings(Int64? CustID) { return new StaticPagesDAL().customerProfilesettings(CustID, "[dbo].[usp_Profilesettings_customer]"); }
        public ArrayList CustomerViewfullProfileDetails(long? ProfileID, int? CustID, int? Relationship) { string spname = Relationship == 283 ? "[dbo].[GetViewProfile_FullDetails]" : "[dbo].[GetViewProfile_FullDetails_Partner]"; return new StaticPagesDAL().CustomerViewfullProfileDetails(ProfileID, CustID, spname); }//
        public ArrayList GetExpressinterstBookmarkIgnore(long? loggedcustid, long? ToCustID) { return new StaticPagesDAL().GetExpressinterst_bookmark_ignore_Data(loggedcustid, ToCustID, "[dbo].[usp_GetExpressinterst_bookmark_ignore_data_New]"); }
        public ArrayList paymentdetailsmethoddal(Int64? CustID) { return new StaticPagesDAL().paymentdetailsmethoddal(CustID, "[dbo].[usp_ProfilePayments_NewDesign]"); }
        public ArrayList GetTicketDetails(TicketDetails ticketdetails) { return new StaticPagesDAL().GetTicketDetailsDal(ticketdetails, "[dbo].[usp_Reports_CustomerTicketingReports]"); }
       // public ArrayList ExpressIntrstfullprofile(string ToProfileID, string FromProfileID, int? EmpID) { return new StaticPagesDAL().ExpressIntrstfullprofile(ToProfileID, FromProfileID, EmpID, "[dbo].[GetViewProfile_FullDetails_RoleWise_Customer]"); }
        //public ArrayList ExpressIntrstfullprofile(int? tocustid, int? fromcustid, int? EmpID) { return new StaticPagesDAL().ExpressIntrstfullprofile(tocustid, fromcustid, EmpID, "[dbo].[GetViewProfile_FullDetails]"); }
        public ArrayList ExpressIntrstfullprofile(string ToProfileID, int? EmpID) { return new StaticPagesDAL().ExpressIntrstfullprofile(ToProfileID, EmpID, "[dbo].[GetViewProfile_FullDetails_RoleWise]"); }
      
        public ArrayList Expressinterst_bookmark_ignore_data(long? Loggedcustid, long? ToCustID) { return new StaticPagesDAL().Expressinterst_bookmark_ignore_data(Loggedcustid, ToCustID, "[dbo].[usp_GetExpressinterst_bookmark_ignore_data_New]"); }
        public ArrayList Cust_NotificationDetails(int? Cust_NotificationID, long? CustID, int? Startindex, int? EndIndex) { return new StaticPagesDAL().Cust_NotificationDetails(Cust_NotificationID, CustID, Startindex, EndIndex, "[dbo].[usp_Cust_NotificationDetails]"); }
        public ArrayList displayMissingFieldsupdate_Customerdetails(string CustID, int? i_updateflag) { return new StaticPagesDAL().displayMissingFieldsupdate_Customerdetails(CustID, i_updateflag, "[dbo].[usp_Customer_Missingfields]"); }
        public int InsertcustomerProfilesettings(DateTime? Expirydate, int? CustID, int? iflag) { return new StaticPagesDAL().InsertcustomerProfilesettings(Expirydate, CustID, iflag, "[dbo].[USP_Inserthideprofile]"); }
        public int DeletecustomerProfilesettings(Int64? ProfileID, string Narrtion) { return new StaticPagesDAL().DeletecustomerProfilesettings(ProfileID, Narrtion, "usp_ProfileSettingsDeleted"); }
        public int UpdatePassword(string OldPassword, string NewPassword, string ConfirmPassword, string custId) { return new StaticPagesDAL().UpdatePasswordDal(OldPassword, NewPassword, ConfirmPassword, custId, "[dbo].[USP_UpdatePasswordDetails]"); }
        public int ImpSendTicketMail(HelpMail Mobj) { return new StaticPagesDAL().SendTicketMailDal(Mobj, "[dbo].[usp_Ticket_SendEmail]"); }
        public int CustomerRating_sendMail(CustFeebBackML CRM) { return new StaticPagesDAL().DCustomerRating_sendMail(CRM, "[dbo].[Usp_CustFeedback]"); }
        public int SendMail_PhotoRequest_Customer(string FromCustID, string ToCustID, int? Category) { return new StaticPagesDAL().SendMail_PhotoRequest_Customer(FromCustID, ToCustID, Category, "[dbo].[usp_CustMailsend_Photoupload_Customer]"); }
        public int getprofileGrade(string CustID) { return new StaticPagesDAL().DprofileGrade(CustID, "[dbo].[usp_profileGrade]"); }
        public int PhotopasswordAcceptReject(Int64? FromcustID, Int64? TocustID, Int64? Accept_Reject) { return new StaticPagesDAL().PhotopasswordAcceptReject(FromcustID, TocustID, Accept_Reject, "[dbo].[usp_PhotopasswordAcceptReject]"); }
        public int ProfilesettingEmailMobileChange(Int64? FamilyID, string MobileEmail, int? CountryCodeID, int? imobileEmailflag) { return new StaticPagesDAL().ProfilesettingEmailMobileChange(FamilyID, MobileEmail, CountryCodeID, imobileEmailflag, "[dbo].[usp_ProfilesettingEmailMobileChange]"); }
        public int ProfilesettingAllowEmailAllowSMS(long? CustID, int? AllowEmail, int? AllowSMS) { return new StaticPagesDAL().ProfilesettingAllowEmailAllowSMS(CustID, AllowEmail, AllowSMS, "[dbo].[usp_AllowEmailAllowSMS]"); }
        public int EmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile) { return new StaticPagesDAL().EmailMobilenumberexists(iflagEmailmobile, EmailMobile, "[dbo].[usp_EmailMobilenumberexists]"); }
        public int CustomerReopenTicketStatus(int? PageID, int? ProfileID, int? TicketID) { return new StaticPagesDAL().CustomerReopenTicketStatus(PageID, ProfileID, TicketID, "[dbo].[usp_Reports_CustomerTicketingReports]"); }
        public int ForgotPassword(string Username) { return new StaticPagesDAL().ForgotPassword(Username, "[dbo].[Usp_CustResetForgotPassword]"); }
        public int ConfirmUserEmail(string VerificationCode) { return new StaticPagesDAL().ConfirmUserEmail(VerificationCode, "[dbo].[usp_reg_ConfirmUserEmail]"); }
        public int CreateNewPassword(Int64? intCusID, string strPassword) { return new StaticPagesDAL().CreateNewPassword(intCusID, strPassword, "[dbo].[usp_CreateNewPassword]"); }
        public int ResendEmailVerficationLink(long? CustID) { return new StaticPagesDAL().ResendEmailVerficationLink(CustID, "[dbo].[Usp_ResendEmailVerficationLink]"); }
        public int MissingFieldsupdate_Customerdetails(MissingFieldsUpdateRequest Mobj) { return new StaticPagesDAL().MissingFieldsupdate_Customerdetails(Mobj, "[dbo].[usp_Customer_Missingfields]"); }
        public int InsertUnpaidStatus(string fromCustID, string ToCustID, int? Empid, string typeofAction) { return new StaticPagesDAL().InsertUnpaidStatus(fromCustID, ToCustID, Empid, typeofAction, "[dbo].[usp_insert_MarketingTicketHistory]"); }
        public int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string DecriptedText, string strtypeOfReport) { return new StaticPagesDAL().InsertExpressViewTicket(FromCustID, ToCustID, Commonclass.Encrypt(DecriptedText), strtypeOfReport, "[dbo].[Usp_InsertExpressViewTicket_new]"); }
        public int UpdateExpressIntrestViewfullprofile(UpdateExpressIntrestStatus Mobj) { return new StaticPagesDAL().UpdateExpressIntrestViewfullprofile(Mobj, "[dbo].[Usp_UpdateExpressIntrestStatus_new]"); }
        public string Customerfilldata(long? CustomerCustID) { return new StaticPagesDAL().Customerfilldata(CustomerCustID, "[dbo].[usp_CustomermissindDatagetting_Load]"); }
        public string EmilVerificationCode(string VerificationCode, int? i_EmilMobileVerification, int? CustContactNumbersID, int? IsVerified) { return new StaticPagesDAL().EmilVerificationCode(VerificationCode, "[dbo].[usp_EmilVerificationCode]", i_EmilMobileVerification, CustContactNumbersID, IsVerified); }
        public void ApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type) { Commonclass.ApplicationErrorLog(ErrorSpName, ErrorMessage, CustID, PageName, Type); }
        public DataTable UnpaidMembersOwner_Notification(int? CategoryID, int? Cust_ID) { return new StaticPagesDAL().UnpaidMembersOwner_Notification(CategoryID, Cust_ID, "[dbo].[Udf_UnpaidMembersOwner_Notification]"); }
        public ArrayList CheckForgotPasswordStatus(string StrCustID) { return new StaticPagesDAL().CheckForgotPasswordStatus(StrCustID, "[dbo].[Usp_CustCheckForgotPasswordStatus]"); }
        public ArrayList RegisteredBranchStatus(string StrCustID) { return new StaticPagesDAL().RegisteredBranchStatus(StrCustID, "[dbo].[Usp_RegisteredBranchStatus]"); }
        public int ChangePassword(string StrCustID, string Password) { return new StaticPagesDAL().ChangePassword(StrCustID, Password, "[dbo].[Usp_CustChangePassword]"); }

        //public ArrayList getMobileAppLandingDisplay(int? CustID, int? Startindex, int? EndIndex) { return new StaticPagesDAL().getMobileAppLandingDisplay(CustID, Startindex, EndIndex, "[dbo].[usp_LandingPage_MobileApp]"); }

        public CustomerLandingOrderResponse getMobileAppLandingDisplay(int? CustID) { return new StaticPagesDAL().getMobileAppLandingDisplay(CustID ,"[dbo].[usp_HeaderLandingPage_MobileApp1]"); }

        public mobileActiveStatus getmobileloginStatus(int? custid) { return new StaticPagesDAL().getmobileloginStatus(custid, "[dbo].[usp_mobileloginStatus]"); }

        public ArrayList UpdateCustomerEmailMobileNumber_Verification(MobileEmailVerf Mobj) { return new StaticPagesDAL().UpdateCustomerEmailMobileNumber_Verification(Mobj, "[dbo].[usp_EmailmobileUpdate_MobileApp]"); }

        public viewedByOther MobileLandingOrderDisplay(long? CustID, int? Startindex, int? EndIndex, string type) { 

            return new StaticPagesDAL().MobileLandingOrderDisplay(CustID, Startindex, EndIndex, type, "[dbo].[usp_LandingOrder_MobileApp]"); 

        }

        
        public viewedByOther MobileLandingOrderDisplaysingleselection(long? CustID, int? Startindex, int? EndIndex, string type) { return new StaticPagesDAL().MobileLandingOrderDisplaysingle(CustID, Startindex, EndIndex, type, "[dbo].[usp_LandingOrderSingledisplay_MobileApp]"); }
        
        public ArrayList ExpressIntrstfullprofilepartial(string ToProfileID, int? EmpID) { return new StaticPagesDAL().ExpressIntrstfullprofilepartial(ToProfileID, EmpID, "[dbo].[GetViewProfile_FullDetails_Partial]"); }

        public ArrayList getCustomerBindings() { return new StaticPagesDAL().getCustomerBindingsDal("[dbo].[usp_customerbindings]"); }

        public ArrayList ExpressIntrstfullprofilepaidandunpaid(string fromProfileID, long? toustid, int? EmpID) { return new StaticPagesDAL().ExpressIntrstfullprofilepaidandunpaid(fromProfileID, toustid, EmpID, "[dbo].[GetViewProfile_FullDetails_RoleWise_PaidUnPaid]"); }
        
        public ArrayList fromexpresstoexpressstatus(string Fromprofileid, string Toprofileid, int? Empid) { return new StaticPagesDAL().fromexpresstoexpressstatus(Fromprofileid, Toprofileid, Empid, "[dbo].[usp_GetExpressInterestStatus]"); }

        public rmgDetailsdisply getrmgDetailsdisplay(int? custid) { return new StaticPagesDAL().getrmgDetailsdisplay(custid, "[dbo].[usp_rmdetails_MobileApp]"); }

        public ArrayList fullprofileself(string ProfileID, int? EmpID) { return new StaticPagesDAL().fullprofileself(ProfileID, EmpID, "[dbo].[GetViewProfile_CustomerNewViewAdminFullDetails_Cust_AJS]"); }
    
    }
}
