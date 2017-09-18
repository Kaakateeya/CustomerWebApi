using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebapiApplication.ML;
using System.Collections;
using System.Data;

namespace WebapiApplication.Interfaces
{
    public interface IActivePatientCondition { List<ActivePatientConditionReport> DisplayMovieList();    }
    public interface IIActivePatientCondition { List<ActivePatientReport> GetCodeSetPrograms();    }
    public interface IuserLogin { List<userLoginML> DGetLogininformationdetails(CustLoginMl Mobj);    }
    public interface IDashboardRequest
    {
        DashboardClass GetLandingCountsBal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string DashboardType);
        DashboardClass GetPartnerProfilesBal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string DashboardType);
        List<PartnerProfilesLatest> ExpressInterestSelectBal(DashboardRequest dreq);
        List<DashboardRequestChats> CustometExpressIntrestDashBoardchats(long? CustID, int? Status, int iStartIndex, int iEndIndex);
        List<TicketHistoryinfoResponse> GetTicketinformationDal(long? Ticketid, char Type);
        List<CommunicationHistry> GetCustometMessagesCount(CommunicationHistoryReq Mobj);
        int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string EncriptedText, string strtypeOfReport);
        int InsertCustomerExpressinterest(int? fromcustid, int? tocustid, long? logID, string interstTYpe, int? empid);

        PersonalInfo getcustDashboardPersonalInfo(int custid);
        LandingPartnerMenu getcustDashboardCounts(int custid);

        DashboardClass custDashboardPartnerProfiles(int id, string TypeOfReport, int pagefrom, int pageto, string DashboardType);
    }

    public interface IEmailMobileVerf { VerifiedContactInformationML DgetMobileEmailVerification(long? CustID); }
    public interface ICustSearchService { int CustomerServiceDal(CustSearchMl MobjViewprofile);  }
    public interface IPayment
    {
        List<Paymentselect> GetPaymentDetails(long? CustID);
        string CustomerPaymentStatus(long? CustomerCustID);
        int InsertPaymentDetails(PaymentMasterMl Mobj);
        ArrayList ProfilePaymentDetails(long? intProfileID, int? Isonline, int? flag, int? intMembershipID, string taxpaid);
        int CustomerInsertPaymentDetilsInfo(CustomerPaymentML Mobj);

        int CustomerInsertPaymentDetilsInfo_NewDesign(PaymentInsertML Mobj);
        ArrayList ProfilePaymentDetails_Gridview(long? intProfileID);
        ArrayList DgetProfilePaymentDetails_NewDesigns(long? intProfileID);

        ArrayList getCustomerPaymentPackagesDisplay(long? LcustID);
    }
    public interface ICustomerSearch
    {
        partnerInfoMl Partnerpreferencedetails_CustomerSearch(int? CustID, int? EmpID, Int64? searchresultID);
        List<QuicksearchResultML> ProfileIdsearch(ProfileIDSearch ProfileIDSearch);
        List<generalAdvanceSearchResult> GeneralandAdvancedSearch(PrimaryInformationMl search);
        List<generalAdvanceSearchResult> CustomerAdvanceGeneralandSavedSearch(PrimaryInformationMl primaryInfo, DataTable dtTableValues);
        List<QuicksearchResultML> CustomerProfileIDSavedSearch(ProfileIDSearch primaryInfo, DataTable dtTableValues);
        List<SearchResultSaveEditML> SearchResultSaveEdit(long? Cust_ID, string SaveSearchName, int? iEditDelete);
        List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch search);
    }
    public interface ICustomerPersonaldetails
    {
        CustomerPersonalDetails getpersonalMenuDetails(string CustID);
        ArrayList getCustomerEducationdetails(long? CustID);
        ArrayList getUpdateProfessionDetails(long? CustID);
        ArrayList getParentDetailsDisplay(long? CustID);
        ArrayList getCustomerpartnerpreferencesDetailsDisplay(long? CustID);
        ArrayList getsiblingsDetailsDisplay(long? CustID);
        ArrayList getAstroDetailsDisplay(long? CustID);
        ArrayList getPropertyDetailsDisplay(long? CustID);
        ArrayList getRelativeDetailsDisplay(long? CustID);
        ArrayList getReferenceViewDetailsDisplay(long? CustID);
        ArrayList GetphotosofCustomer(string Custid, int? EmpID);
        ArrayList getCustomerPersonalMenu(long? CustID);
        string getDiscribeYour(string CustID, string AboutYourself, int? flag, string spName);
        int getNoPhotoStatus(long custid);
    }
    public interface ICustomerPersonaldetailsUpdate
    {

        int getEducationdetails_Updatecustomer(UpdatePersonaldetails MobjEdudetails);
        int getProfessionDetails_Customer(UpdatePersonaldetails MobjProf);
        int CustomerParentUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerContactAddressUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerPhysicalAttributesUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerPartnerPreferencesUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerSibBrotherUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerSibSisterUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerAstrodetailsUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerPropertyUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerFathersBrotherUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerFathersSisterUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerMotherBrotherUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerMotherSisterUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerReferencedetailsUpdatedetails(UpdatePersonaldetails MobjProf);
        int UpdateSibblingCounts(SibblingCounts sibcount);
        ArrayList Savephotosofcustomer(UpdatePersonaldetails updatePic);
        int PhotoPassword(long? CustID, int? ipassword);
        int AstroDetailsUpdateDelete(AstroUploadDelete astroupdate);
        HoroGeneration GenerateHoroscorpe(int? customerid, string EmpIDQueryString, int? intDay, int? intMonth, int? intYear, int? CityID);
        int AstroGenerationS3Update(string Path, string KeyName);

    }
    public interface IStaticPages
    {

        List<Sucessstories> getSucessstoriesdetails(SuccessStoryML SML);
        int CustomerRating_sendMail(CustFeebBackML Mobj);
        List<KaakateeyaBranchesML> ImpgetKaakateeyaBranchesDetails(string dependencyName, string dependencyValue, string dependencyflagID);
        int ImpSendTicketMail(HelpMail Mobj);
        HelpMail ImpInsertTicketInfo(TicketCreationMl Mobj);
        ArrayList CustomerViewfullProfileDetails(long? ProfileID, int? CustID, int? RelationshipID);
        ArrayList GetExpressinterstBookmarkIgnore(long? loggedcustid, long? ToCustID);
        int SendMail_PhotoRequest_Customer(string FromCustID, string ToCustID, int? Category);
        int getprofileGrade(string CustID);
        List<PhotoPathDisplay> GetPhotoSlideImages(string CustID);
        int PhotopasswordAcceptReject(Int64? FromcustID, Int64? TocustID, Int64? Accept_Reject);
        List<ProfileSettings> customerProfilesettings(Int64? CustID);
        int InsertcustomerProfilesettings(DateTime? Expirydate, int? CustID, int? iflag);
        int DeletecustomerProfilesettings(Int64? ProfileID, string Narrtion);
        int UpdatePassword(string OldPassword, string NewPassword, string ConfirmPassword, string custId);
        int ProfilesettingEmailMobileChange(Int64? FamilyID, string MobileEmail, int? CountryCodeID, int? imobileEmailflag);
        int ProfilesettingAllowEmailAllowSMS(long? CustID, int? AllowEmail, int? AllowSMS);
        int EmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile);
        void ApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type);
        ArrayList paymentdetailsmethoddal(Int64? CustID);
        ArrayList GetTicketDetails(TicketDetails ticketdetails);
        int CustomerReopenTicketStatus(int? PageID, int? ProfileID, int? TicketID);
        int ForgotPassword(string Username);
        int ConfirmUserEmail(string VerificationCode);
        int CreateNewPassword(Int64? intCusID, string strPassword);
        string EmilVerificationCode(string VerificationCode, int? i_EmilMobileVerification, int? CustContactNumbersID, int? IsVerified);
        DataTable UnpaidMembersOwner_Notification(int? CategoryID, int? Cust_ID);
        int ResendEmailVerficationLink(long? CustID);
        int MissingFieldsupdate_Customerdetails(MissingFieldsUpdateRequest Mobj);
        ArrayList displayMissingFieldsupdate_Customerdetails(string CustID, int? i_updateflag);
        string Customerfilldata(long? CustomerCustID);
        int InsertUnpaidStatus(string fromCustID, string ToCustID, int? Empid, string typeofAction);
        int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string p, string strtypeOfReport);
        ViewfullProfileML ViewFullProfileMail(string OriginalString);
        //ArrayList ExpressIntrstfullprofile(string ToProfileID, string FromProfileID, int? EmpID);
       // ArrayList ExpressIntrstfullprofile(int? tocustid, int? fromcustid, int? EmpID);
        ArrayList ExpressIntrstfullprofile(string ToProfileID, int? EmpID);
        ArrayList Expressinterst_bookmark_ignore_data(long? Loggedcustid, long? ToCustID);
        int UpdateExpressIntrestViewfullprofile(UpdateExpressIntrestStatus Mobj);
        ArrayList Cust_NotificationDetails(int? Cust_NotificationID, long? CustID, int? Startindex, int? EndIndex);
        ArrayList CheckForgotPasswordStatus(string StrCustID);
        int ChangePassword(string StrCustID, string Password);
        ArrayList RegisteredBranchStatus(string StrCustID);


        ArrayList getMobileAppLandingDisplay(int? CustID, int? Startindex, int? EndIndex);

        ArrayList UpdateCustomerEmailMobileNumber_Verification(MobileEmailVerf Mobj);

        ArrayList MobileLandingOrderDisplay(long? CustID, int? Startindex, int? EndIndex);



        ArrayList ExpressIntrstfullprofilepartial(string ToProfileID, int? EmpID);

        ArrayList getCustomerBindings();
        ArrayList ExpressIntrstfullprofilepaidandunpaid(string fromProfileID, long? toustid, int? EmpID);
    }

    public interface IDependency
    {
        List<CountryDependency> getCountryDependency(string dependencyName, string dependencyValue, string spname);
        List<CountryDependency> getCountryDependencyCountryCode(string dependencyName, string dependencyValue, string spname);
        List<CountryDependency> getDropdown_filling_values(string strDropdownname);
        List<CountryDependency> ImpgetDropdownValues_dependency_injection(string dependencyName, string dependencyValue, string dependencyflagID);

    }
    public interface IRegistration
    {
        int? RegisterCustomerHomepages(PrimaryInformationMl Mobj);
        int CustomerRegProfileDetails_Myprofile(UpdatePersonaldetails Mobj);
        ArrayList CustomermissindDatagetting(long? CustomerCustID);

        string BgetPassword(string Username);
        ArrayList DGetloginCustinformation(string Username, string Password, int? iflag);
        int CheckUserPwd(string Username, string Password);
        int FatherMothersibDetails(FatherMothersibDetails Mobj);
    }
    public interface IMobileAppDev
    {
        ArrayList getMobileAppLandingDisplay(int? CustID, int? PaidStatus, int? Startindex, int? EndIndex);
        ArrayList UpdateCustomerEmailMobileNumber_Verification(MobileEmailVerf Mobj);
        ArrayList MobileLandingOrderDisplay(long? CustID, int? Startindex, int? EndIndex);
    }
}

