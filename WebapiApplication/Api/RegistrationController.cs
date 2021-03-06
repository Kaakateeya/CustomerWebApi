﻿using System;
using System.Collections;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using WebapiApplication.DAL;
using WebapiApplication.UserDefinedTable;

namespace WebapiApplication.Api
{
    public class RegistrationController : ApiController
    {
        private readonly IRegistration IRegistration;
        public RegistrationController() : base() { this.IRegistration = new ImpRegistration(); }
        public int? RegisterCustomerHomepages(PrimaryInformationMl CustomerHome) { return this.IRegistration.RegisterCustomerHomepages(CustomerHome); }
        public int? CustomerRegProfileDetails([FromBody]JObject CustomerHome)
        {
            TDetailedRegistration TCustomer = CustomerHome["GetDetails"].ToObject<TDetailedRegistration>();
            UpdatePersonaldetails customerpersonaldetails = CustomerHome["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TDetailedRegistration> lstProf = new List<TDetailedRegistration>();
            lstProf.Add(TCustomer);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCustomerRegProfileDetails(), lstProf);
            return this.IRegistration.CustomerRegProfileDetails_Myprofile(customerpersonaldetails);
        }
        public ArrayList getCustomermissindDatagetting(long? CustomerCustID) { return this.IRegistration.CustomermissindDatagetting(CustomerCustID); }

        public string getPassword(string Username) { return this.IRegistration.BgetPassword(Username); }
        public ArrayList getloginCustinformation(string Username, string Password, int? iflag) { return this.IRegistration.DGetloginCustinformation(Username, Password, iflag); }
        public int getCheckUserPwd(string Username, string Password) { return this.IRegistration.CheckUserPwd(Username, Password); }
        public int FatherMothersibDetails([FromBody]FatherMothersibDetails Mobj) { return this.IRegistration.FatherMothersibDetails(Mobj); }
    }
}