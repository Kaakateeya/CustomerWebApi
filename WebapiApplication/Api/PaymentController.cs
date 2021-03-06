﻿using System;
using System.Collections;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections.Generic;
using WebapiApplication.UserDefinedTable;
using WebapiApplication.DAL;

namespace WebapiApplication.Api
{
    public class PaymentController : ApiController
    {
        private readonly IPayment IPayment;
        public PaymentController() : base() { this.IPayment = new ImpPayment(); }
        public List<Paymentselect> GetPaymentDetails(long? CustID) { return this.IPayment.GetPaymentDetails(CustID); }
        public string getCustomerPaymentStatus(long? CustomerCustID) { return this.IPayment.CustomerPaymentStatus(CustomerCustID); }
        public int InsertPaymentDetails([FromBody]PaymentMasterMl Mobj) { return this.IPayment.InsertPaymentDetails(Mobj); }
        public ArrayList getProfilePaymentDetails(long? intProfileID, int? Isonline, int? flag, int? intMembershipID, string taxpaid) { return this.IPayment.ProfilePaymentDetails(intProfileID, Isonline, flag, intMembershipID, taxpaid); }

        public int CustomerInsertPaymentDetilsInfo([FromBody]CustomerPaymentML Mobj)
        {
            List<CustomerPaymentML> lstPayment = new List<CustomerPaymentML>();
            lstPayment.Add(Mobj);
            Mobj.dtPaymentDetails = Commonclass.returnListDatatable(PersonaldetailsUDTables.createDataTablePaymentDetails(), lstPayment);
            return this.IPayment.CustomerInsertPaymentDetilsInfo(Mobj);
        }

        public int CustomerInsertPaymentDetilsInfo_NewDesign([FromBody]PaymentInsertML Mobj)
        {
            List<PaymentInsertML> lstPayment = new List<PaymentInsertML>();
            lstPayment.Add(Mobj);
            Mobj.dtPaymentDetails = Commonclass.returnListDatatable(PersonaldetailsUDTables.createDataTablePayment_New(), lstPayment);
            return this.IPayment.CustomerInsertPaymentDetilsInfo_NewDesign(Mobj);
        }

        //new  Payment Page

        public ArrayList getProfilePaymentDetailsGridview(long? intProfileID) { return this.IPayment.ProfilePaymentDetails_Gridview(intProfileID); }
        public ArrayList getProfilePaymentDetails_NewDesigns(long? intProfileID) { return this.IPayment.DgetProfilePaymentDetails_NewDesigns(intProfileID); }

      
      

        /// <summary>
        /// 
        /// Mobile  app Payment
        /// </summary>
        /// 


        public string RSAccavenue([FromBody]Rsakey Rsakey) { return this.IPayment.RSAccavenue(Rsakey); }

        public string getResponseHandler(string encResp, string workingKey) { return this.IPayment.getResponseHandler(encResp, workingKey); }

        public ArrayList getCustomerPaymentPackagesDisplay(long? LcustID) { return this.IPayment.getCustomerPaymentPackagesDisplay(LcustID); }

        public List<singlePaymentPackages> getcustomerMultiPaymentPackagesDisplay(long? icustid) { return this.IPayment.getcustomerMultiPaymentPackagesDisplay(icustid); }

        public singlePaymentPackages getcustomersinglePaymentPackagesDisplay(long? icustid, int? membershipTypeID) { return this.IPayment.getcustomersinglePaymentPackagesDisplay(icustid, membershipTypeID); }

    }
}

