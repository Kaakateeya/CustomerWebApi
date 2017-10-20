using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;

namespace WebapiApplication.Api
{
    public class DBController : ApiController
    {
        private readonly IuserLogin IuserLogin; public DBController() : base() { this.IuserLogin = new ImpUserlogin(); }

        public List<userLoginML> userLogin([FromBody]CustLoginMl id) { 
            return this.IuserLogin.DGetLogininformationdetails(id);
        }
    }
}


