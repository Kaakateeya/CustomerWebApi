﻿using System;
using System.Collections;
using System.Data;
using Newtonsoft.Json;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections.Generic;
using WebapiApplication.DAL;
using WebapiApplication.UserDefinedTable;
using Newtonsoft.Json.Linq;

namespace WebapiApplication.Api
{
    public class CustomerPersonalUpdateController : ApiController
    {
        private readonly ICustomerPersonaldetailsUpdate ICustomerpersonalupdate; public CustomerPersonalUpdateController() : base() { this.ICustomerpersonalupdate = new ImpCustomerPersonaldetailsUpdate(); }

        public int CustomerPersonalUpdateEducationdetail([FromBody]JObject Cedetails)
        {
            CutomerEducationdetails customerEducation = Cedetails["customerEducation"].ToObject<CutomerEducationdetails>();
            UpdatePersonaldetails customerpersonaldetails = Cedetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<CutomerEducationdetails> listEdu = new List<CutomerEducationdetails>();
            listEdu.Add(customerEducation);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.createEducationdataTable(), listEdu);
            return this.ICustomerpersonalupdate.getEducationdetails_Updatecustomer(customerpersonaldetails);
        }

        public int CustomerPersonalUpdateProfessionDetails([FromBody]JObject CProfessiondetails)
        {
            CutomerProfessiondetails customerProfession = CProfessiondetails["customerProfession"].ToObject<CutomerProfessiondetails>();
            UpdatePersonaldetails customerpersonaldetails = CProfessiondetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<CutomerProfessiondetails> lstProf = new List<CutomerProfessiondetails>();
            lstProf.Add(customerProfession);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.createDataTableprofessiondetails(), lstProf);
            return this.ICustomerpersonalupdate.getProfessionDetails_Customer(customerpersonaldetails);
        }

        public int CustomerParentUpdatedetails([FromBody]JObject CgetDetails)
        {
            TCustomerParentsDetails TCustomer = CgetDetails["GetDetails"].ToObject<TCustomerParentsDetails>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TCustomerParentsDetails> lstProf = new List<TCustomerParentsDetails>();
            lstProf.Add(TCustomer);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateParentsDetail(), lstProf);
            return this.ICustomerpersonalupdate.CustomerParentUpdatedetails(customerpersonaldetails);
        }

        public int CustomerContactAddressUpdatedetails([FromBody]JObject CgetDetails)
        {
            TCustomerContactAddress TCustomer = CgetDetails["GetDetails"].ToObject<TCustomerContactAddress>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TCustomerContactAddress> lstProf = new List<TCustomerContactAddress>();
            lstProf.Add(TCustomer);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateContactAddressdetails(), lstProf);
            return this.ICustomerpersonalupdate.CustomerContactAddressUpdatedetails(customerpersonaldetails);
        }

        public int CustomerPhysicalAttributesUpdatedetails([FromBody]JObject CgetDetails)
        {
            TCustomerPhysicalAttributes TCustomer = CgetDetails["GetDetails"].ToObject<TCustomerPhysicalAttributes>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TCustomerPhysicalAttributes> lstProf = new List<TCustomerPhysicalAttributes>();
            lstProf.Add(TCustomer);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreaPhysicalAttributedetails(), lstProf);
            return this.ICustomerpersonalupdate.CustomerPhysicalAttributesUpdatedetails(customerpersonaldetails);
        }
        public int CustomerPartnerPreferencesUpdatedetails([FromBody]JObject CgetDetails)
        {
            TCustomerPartnerPreferences TCustomer = CgetDetails["GetDetails"].ToObject<TCustomerPartnerPreferences>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TCustomerPartnerPreferences> lstProf = new List<TCustomerPartnerPreferences>();
            lstProf.Add(TCustomer);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCreatePartnerPreferences(), lstProf);
            return this.ICustomerpersonalupdate.CustomerPartnerPreferencesUpdatedetails(customerpersonaldetails);
        }
        public int CustomerSibBrotherUpdatedetails([FromBody]JObject CgetDetails)
        {
            TSibBrother SibBrother = CgetDetails["GetDetails"].ToObject<TSibBrother>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TSibBrother> lstProf = new List<TSibBrother>();
            lstProf.Add(SibBrother);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCreateDatatableBrotherDetail(), lstProf);
            return this.ICustomerpersonalupdate.CustomerSibBrotherUpdatedetails(customerpersonaldetails);
        }
        public int CustomerSibSisterUpdatedetails([FromBody]JObject CgetDetails)
        {
            TsibSister sibSister = CgetDetails["GetDetails"].ToObject<TsibSister>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TsibSister> lstProf = new List<TsibSister>();
            lstProf.Add(sibSister);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCreateDatatableSisterDetail(), lstProf);
            return this.ICustomerpersonalupdate.CustomerSibSisterUpdatedetails(customerpersonaldetails);
        }
        public int CustomerAstrodetailsUpdatedetails([FromBody]JObject CgetDetails)
        {
            TeditAstro editAstro = CgetDetails["GetDetails"].ToObject<TeditAstro>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TeditAstro> lstAstro = new List<TeditAstro>();
            lstAstro.Add(editAstro);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateAstrodetail(), lstAstro);
            return this.ICustomerpersonalupdate.CustomerAstrodetailsUpdatedetails(customerpersonaldetails);
        }
        public int CustomerPropertyUpdatedetails([FromBody]JObject CgetDetails)
        {
            TeditProperty editProperty = CgetDetails["GetDetails"].ToObject<TeditProperty>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TeditProperty> lsteditProperty = new List<TeditProperty>();
            lsteditProperty.Add(editProperty);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreatePropertydetails(), lsteditProperty);
            return this.ICustomerpersonalupdate.CustomerPropertyUpdatedetails(customerpersonaldetails);
        }
        public int CustomerFathersBrotherUpdatedetails([FromBody]JObject CgetDetails)
        {
            TeditFB editFB = CgetDetails["GetDetails"].ToObject<TeditFB>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TeditFB> lsteditFB = new List<TeditFB>();
            lsteditFB.Add(editFB);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateFathersBrotherDetail(), lsteditFB);
            return this.ICustomerpersonalupdate.CustomerFathersBrotherUpdatedetails(customerpersonaldetails);
        }
        public int CustomerFathersSisterUpdatedetails([FromBody]JObject CgetDetails)
        {
            TeditFS editFS = CgetDetails["GetDetails"].ToObject<TeditFS>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TeditFS> lsteditFS = new List<TeditFS>();
            lsteditFS.Add(editFS);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateFathersSisterDetail(), lsteditFS);
            return this.ICustomerpersonalupdate.CustomerFathersSisterUpdatedetails(customerpersonaldetails);
        }
        public int CustomerMotherBrotherUpdatedetails([FromBody]JObject CgetDetails)
        {
            TeditMB editMB = CgetDetails["GetDetails"].ToObject<TeditMB>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TeditMB> lstTeditMB = new List<TeditMB>();
            lstTeditMB.Add(editMB);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateMotherBrotherDetail(), lstTeditMB);
            return this.ICustomerpersonalupdate.CustomerMotherBrotherUpdatedetails(customerpersonaldetails);
        }
        public int CustomerMotherSisterUpdatedetails([FromBody]JObject CgetDetails)
        {
            TeditMS editMS = CgetDetails["GetDetails"].ToObject<TeditMS>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TeditMS> lsteditMS = new List<TeditMS>();
            lsteditMS.Add(editMS);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateMotherSisterDetail(), lsteditMS);
            return this.ICustomerpersonalupdate.CustomerMotherSisterUpdatedetails(customerpersonaldetails);
        }

        public int CustomerReferencedetailsUpdatedetails([FromBody]JObject CgetDetails)
        {
            TeditReference editReference = CgetDetails["GetDetails"].ToObject<TeditReference>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TeditReference> lstRef = new List<TeditReference>();
            lstRef.Add(editReference);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateDatatableReferenceDetail(), lstRef);
            return this.ICustomerpersonalupdate.CustomerReferencedetailsUpdatedetails(customerpersonaldetails);

        }
        public int UpdateSibblingCounts(SibblingCounts sibcount) { return this.ICustomerpersonalupdate.UpdateSibblingCounts(sibcount); }
        public ArrayList Savephotosofcustomer([FromBody]JObject CgetDetails)
        {
            TuploadPhoto edituploadPhoto = CgetDetails["GetDetails"].ToObject<TuploadPhoto>();
            UpdatePersonaldetails customerpersonaldetails = CgetDetails["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TuploadPhoto> lstuploadPhoto = new List<TuploadPhoto>();
            lstuploadPhoto.Add(edituploadPhoto);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtSavephotosofcustomer(), lstuploadPhoto);
            return this.ICustomerpersonalupdate.Savephotosofcustomer(customerpersonaldetails);
        }


        public int getPhotoPassword([FromUri]Int64? CustID, [FromUri]int? ipassword) { return this.ICustomerpersonalupdate.PhotoPassword(CustID, ipassword); }
        public int AstroDetailsUpdateDelete([FromBody]AstroUploadDelete astroupdate) { return this.ICustomerpersonalupdate.AstroDetailsUpdateDelete(astroupdate); }
        public HoroGeneration getGenerateHoroscorpe(int? customerid, string EmpIDQueryString, int? intDay, int? intMonth, int? intYear, int? CityID) { return this.ICustomerpersonalupdate.GenerateHoroscorpe(customerid, EmpIDQueryString, intDay, intMonth, intYear, CityID); }
        public int getAstroGenerationS3Update(string Path, string KeyName) { return this.ICustomerpersonalupdate.AstroGenerationS3Update(Path, KeyName); }



    }
}




