﻿using System;
using System.Collections;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WebapiApplication.DAL;
using WebapiApplication.UserDefinedTable;
using System.Data;


namespace WebapiApplication.Api
{
    public class CustomerSearchController : ApiController
    {
        private readonly ICustomerSearch ICustomerSearch; public CustomerSearchController() : base() { this.ICustomerSearch = new ImpCustomerSearch(); }
        public partnerInfoMl getPartnerpreferencedetails(int? CustID, int? EmpID, Int64? searchresultID) { return this.ICustomerSearch.Partnerpreferencedetails_CustomerSearch(CustID, EmpID, searchresultID); }
        public List<QuicksearchResultML> CustomerProfileIdsearch(ProfileIDSearch ProfileIDSearch) { return this.ICustomerSearch.ProfileIdsearch(ProfileIDSearch); }
        public List<generalAdvanceSearchResult> CustomerGeneralandAdvancedSearch(PrimaryInformationMl search) { return this.ICustomerSearch.GeneralandAdvancedSearch(search); }
        public List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch Search) { return this.ICustomerSearch.CustomerHomePageSearch(Search); }

        public List<generalAdvanceSearchResult> CustomerGeneralandAdvancedSavedSearch([FromBody]JObject Savesearch)
        {
            Newsavedserach Searchsaved = Savesearch["GetDetails"].ToObject<Newsavedserach>();
            PrimaryInformationMl primaryInfo = Savesearch["customerpersonaldetails"].ToObject<PrimaryInformationMl>();
            List<Newsavedserach> lstSave = new List<Newsavedserach>();
            lstSave.Add(Searchsaved);
            DataTable dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCustomerGeneralandAdvancedSavedSearch(), lstSave);
            return this.ICustomerSearch.CustomerAdvanceGeneralandSavedSearch(primaryInfo, dtTableValues);
        }

        public List<QuicksearchResultML> CustomerProfileIDSavedSearch([FromBody]JObject Savesearch)
        {
            Newsavedserach Searchsaved = Savesearch["GetDetails"].ToObject<Newsavedserach>();
            ProfileIDSearch primaryInfo = Savesearch["customerpersonaldetails"].ToObject<ProfileIDSearch>();
            List<Newsavedserach> lstSave = new List<Newsavedserach>();
            lstSave.Add(Searchsaved);
            DataTable dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCustomerGeneralandAdvancedSavedSearch(), lstSave);
            return this.ICustomerSearch.CustomerProfileIDSavedSearch(primaryInfo, dtTableValues);
        }

        public List<SearchResultSaveEditML> getSearchResultSaveEdit(Int64? Cust_ID, string SaveSearchName, int? iEditDelete) { return this.ICustomerSearch.SearchResultSaveEdit(Cust_ID, SaveSearchName, iEditDelete); }

        public List<generalAdvanceSearchResult> CustomerGeneralandAdvancedSearchWithoutLogin(PrimaryInformationMl search) { return this.ICustomerSearch.CustomerGeneralandAdvancedSearchWithoutLogin(search); }


    }
}