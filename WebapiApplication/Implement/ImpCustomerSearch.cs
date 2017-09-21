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
    public class ImpCustomerSearch : ICustomerSearch
    {
        public partnerInfoMl Partnerpreferencedetails_CustomerSearch(int? CustID, int? EmpID, Int64? searchresultID) { return new CustomerSearch().DgetPartnerpreferencedetails(CustID, EmpID, searchresultID, "[dbo].[usp_GetCustomerinfo_Forsearches]"); }
        public List<QuicksearchResultML> ProfileIdsearch(ProfileIDSearch ProfileIDSearch) { return new CustomerSearch().ProfileIdsearch(ProfileIDSearch, "[dbo].[usp_Customers_ProfileSearch_Profor]"); }
        public List<generalAdvanceSearchResult> GeneralandAdvancedSearch(PrimaryInformationMl search) { return new CustomerSearch().GeneralandAdvancedSearch(search, "[dbo].[usp_Customers_GeneralSearch_Perfor]"); }
        public List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch search) { return new CustomerSearch().CustomerHomePageSearch(search, "[dbo].[usp_Customers_GeneralSearch_Perfor_HomePage]"); }
        public List<generalAdvanceSearchResult> CustomerAdvanceGeneralandSavedSearch(PrimaryInformationMl primaryInfo, DataTable dtTableValues) { return new CustomerSearch().CustomerGeneralandAdvancedSavedSearch(primaryInfo, dtTableValues, "[dbo].[usp_AdvSearch_Customer]", "@dtAdvsearch", "[dbo].[usp_Customers_GeneralSearch_Perfor]"); }
        public List<QuicksearchResultML> CustomerProfileIDSavedSearch(ProfileIDSearch primaryInfo, DataTable dtTableValues) { return new CustomerSearch().CustomerProfileIDSavedSearch(primaryInfo, dtTableValues, "[dbo].[usp_ProfileIDsearch_Customer]", "@dtProfileIDsearch", "[dbo].[usp_Customers_ProfileSearch_Profor]"); }
        public List<SearchResultSaveEditML> SearchResultSaveEdit(long? Cust_ID, string SaveSearchName, int? iEditDelete) { return new CustomerSearch().SearchResultSaveEdit(Cust_ID, SaveSearchName, iEditDelete, "[dbo].[usp_SearchResultSaveEdit]"); }

        public List<generalAdvanceSearchResult> CustomerGeneralandAdvancedSearchWithoutLogin(PrimaryInformationMl search) { return new CustomerSearch().CustomerGeneralandAdvancedSearchWithoutLoginDal(search, "[dbo].[usp_Customers_GeneralSearch_BeforeLogin]"); }
    }
}