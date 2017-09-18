using System;
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

    public class ImpCustomerPersonaldetails : ICustomerPersonaldetails
    {

        customerPersonalDetails customerdetails = new customerPersonalDetails();
        public CustomerPersonalDetails getpersonalMenuDetails(string CustID) { return customerdetails.DgetpersonalDetailsDAL(CustID); }
        public ArrayList getCustomerEducationdetails(long? CustID) { return customerdetails.DgetUpdateEducationdetailsDAL(CustID, "[dbo].[usp_ViewCustomerEducationprofdetails]"); }
        public ArrayList getUpdateProfessionDetails(long? CustID) { return customerdetails.DgetUpdateProfessionDetailsDAL(CustID, "[dbo].[usp_ViewCustomerProfessioncustomer]"); }
        public ArrayList getParentDetailsDisplay(long? CustID) { return customerdetails.DgetParentDetailsDisplay(CustID, "[dbo].[USp_GetParentDetails]"); }
        public ArrayList getCustomerpartnerpreferencesDetailsDisplay(long? CustID) { return customerdetails.DgetCustomerpartnerpreferencesDetailsDisplay(CustID, "[dbo].[usp_Customer_PartnerDataPageload]"); }
        public ArrayList getsiblingsDetailsDisplay(long? CustID) { return customerdetails.DgetsiblingsDetailsDisplay(CustID, "[dbo].[usp_Customer_getSibilingByValue]"); }
        public ArrayList getAstroDetailsDisplay(long? CustID) { return customerdetails.DgetAstroDetailsDisplay(CustID, "[dbo].[usp_Customer_getAstroDetailsByValue]"); }
        public ArrayList getPropertyDetailsDisplay(long? CustID) { return customerdetails.DgetPropertyDetailsDisplay(CustID, "[dbo].[usp_Customer_getpropertyDetails]"); }
        public ArrayList getRelativeDetailsDisplay(long? CustID) { return customerdetails.DgetRelativeDetailsDisplay(CustID, "[dbo].[usp_Customer_ReletivesPageload]"); }
        public ArrayList getReferenceViewDetailsDisplay(long? CustID) { return customerdetails.DgetReferenceViewDetailsDisplay(CustID, "[dbo].[usp_Customer_RefrencePageload]"); }
        public ArrayList GetphotosofCustomer(string Custid, int? EmpID) { return customerdetails.DGetphotosofCustomer(Custid, EmpID, "[dbo].[Usp_GetphotosofCustomer]"); }
        public ArrayList getCustomerPersonalMenu(long? CustID) { return customerdetails.DgetAstroDetailsDisplay(CustID, "[dbo].[usp_CustomerPersonalMenu]"); }
        public string getDiscribeYour(string CustID, string AboutYourself, int? flag, string spName) { return customerdetails.DgetDiscribeYour(CustID, AboutYourself, flag, spName); }
        public int getNoPhotoStatus(long custid) { return customerdetails.getNoPhotoStatusDal(custid, "GetPhotoStatusForUpload"); }
    }

    public class ImpCustomerPersonaldetailsUpdate : ICustomerPersonaldetailsUpdate
    {

        customerPersonalDetails customerdetails = new customerPersonalDetails();
        public int getEducationdetails_Updatecustomer(UpdatePersonaldetails MobjEdudetails) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjEdudetails, "[dbo].[usp_edit_updateEducion_CustomerEdit]", "@dtEducationdetails"); }
        public int getProfessionDetails_Customer(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_Profession_CustomerEdit]", "@dtprofessiondetails"); }
        public int CustomerParentUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_ParenentFatherMother_CustomerEdit]", "@dtParentFathermother"); }
        public int CustomerContactAddressUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_ContactAddress_CustomerEdit]", "@dtParentContactAddress"); }
        public int CustomerPhysicalAttributesUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_ParentphysicalHealth_CustomerEdit]", "@dtParentPhysicalhealth"); }
        public int CustomerPartnerPreferencesUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_PartnerPreferences_CustomerEdit]", "@dtPartnerPreferences"); }
        public int CustomerSibBrotherUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_SibblingBrother_CustomerEdit]", "@dtsibBrotherdetails"); }
        public int CustomerSibSisterUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_SibblingSister_CustomerEdit]", "@dtsibSisterdetails"); }
        public int CustomerAstrodetailsUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_Astrodetails_CustomerEdit]", "@dtAstrodetails"); }
        public int CustomerPropertyUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_Customer_PropertySubmit]", "@dtPropertyCustomerEdit"); }
        public int CustomerFathersBrotherUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_FathersBrotherDetails_CustomerEdit]", "@dtFatherBrotherRel"); }
        public int CustomerFathersSisterUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_FathersSisterDetails_CustomerEdit]", "@dtFathersSisterDetails"); }
        public int CustomerMotherBrotherUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_MotherBrotherDetails_CustomerEdit]", "@dtMotherBrotherDetails"); }
        public int CustomerMotherSisterUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_MotherSisterDetails_CustomerEdit]", "@dtMotherSisterDetails"); }
        public int CustomerReferencedetailsUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_Refrencedetails_CustomerEdit]", "@dtCustomerRefdetails"); }
        public int UpdateSibblingCounts(SibblingCounts sibcount) { return customerdetails.DUpdateSibblingCounts(sibcount, "[dbo].[usp_SibblingCounts]"); }
        public ArrayList Savephotosofcustomer(UpdatePersonaldetails savePhoto) { return customerdetails.Savephotosofcustomer(savePhoto, "[dbo].[usp_Edit_Photoupload_forCustomer]"); }
        public int PhotoPassword(long? CustID, int? ipassword) { return customerdetails.PhotoPassword(CustID, ipassword, "[dbo].[usp_PhotoPassword]"); }
        public int AstroDetailsUpdateDelete(AstroUploadDelete astroupdate) { return customerdetails.AstroDetailsUpdateDelete(astroupdate, "[dbo].[usp_AstroUpload_Delete]"); }
        public HoroGeneration GenerateHoroscorpe(int? customerid, string EmpIDQueryString, int? intDay, int? intMonth, int? intYear, int? CityID) { return customerdetails.GenerateHoroscorpe(customerid, EmpIDQueryString, intDay, intMonth, intYear, CityID); }
        public int AstroGenerationS3Update(string Path, string KeyName) { return customerdetails.AstroGenerationUpdate(Path,  KeyName); }
    }
}