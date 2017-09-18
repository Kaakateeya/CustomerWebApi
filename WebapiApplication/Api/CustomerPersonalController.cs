using System;
using System.Collections;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;


namespace WebapiApplication.Api
{
    public class CustomerPersonalController : ApiController
    {
        private readonly ICustomerPersonaldetails ICustomerpersonal;
        public CustomerPersonalController() : base() { this.ICustomerpersonal = new ImpCustomerPersonaldetails(); }
        public CustomerPersonalDetails getpersonalMenuDetails([FromUri]string CustID) { return this.ICustomerpersonal.getpersonalMenuDetails(CustID); }
        public ArrayList getCustomerEducationdetails([FromUri]long CustID) { return this.ICustomerpersonal.getCustomerEducationdetails(CustID); }
        public ArrayList getCustomerProfessiondetails([FromUri]long CustID) { return this.ICustomerpersonal.getUpdateProfessionDetails(CustID); }
        public ArrayList getParentDetailsDisplay([FromUri]long? CustID) { return this.ICustomerpersonal.getParentDetailsDisplay(CustID); }
        public ArrayList getCustomerpartnerpreferencesDetailsDisplay([FromUri]long? CustID) { return this.ICustomerpersonal.getCustomerpartnerpreferencesDetailsDisplay(CustID); }
        public ArrayList getsiblingsDetailsDisplay([FromUri]long? CustID) { return this.ICustomerpersonal.getsiblingsDetailsDisplay(CustID); }
        public ArrayList getAstroDetailsDisplay([FromUri]long? CustID) { return this.ICustomerpersonal.getAstroDetailsDisplay(CustID); }
        public ArrayList getPropertyDetailsDisplay([FromUri]long? CustID) { return this.ICustomerpersonal.getPropertyDetailsDisplay(CustID); }
        public ArrayList getRelativeDetailsDisplay([FromUri]long? CustID) { return this.ICustomerpersonal.getRelativeDetailsDisplay(CustID); }
        public ArrayList getReferenceViewDetailsDisplay([FromUri]long? CustID) { return this.ICustomerpersonal.getReferenceViewDetailsDisplay(CustID); }
        public ArrayList GetphotosofCustomer(string Custid, int? EmpID) { return this.ICustomerpersonal.GetphotosofCustomer(Custid, EmpID); }
        public ArrayList getCustomerPersonalMenuReviewStatus([FromUri]long? CustID) { return this.ICustomerpersonal.getCustomerPersonalMenu(CustID); }
        public string getEducationProfession_AboutYourself(string CustID, string AboutYourself, int? flag) { return this.ICustomerpersonal.getDiscribeYour(CustID, AboutYourself, flag, "[dbo].[usp_Education_Profession_AboutYourself]"); }
        public string getParents_AboutMyFamily(string CustID, string AboutYourself, int? flag) { return this.ICustomerpersonal.getDiscribeYour(CustID, AboutYourself, flag, "[dbo].[usp_Parents_AboutMyFamily]"); }
        public string getPartnerpreference_DiscribeYourPartner(string CustID, string AboutYourself, int? flag) { return this.ICustomerpersonal.getDiscribeYour(CustID, AboutYourself, flag, "[dbo].[usp_Partnerpreference_DiscribeYourPartner]"); }
        public int getNoPhotoStatus(long custid) { return this.ICustomerpersonal.getNoPhotoStatus(custid); }


    }
}