using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace WebapiApplication.Common
{

    /// <summary>
    /// Generic API reponse
    /// </summary>
    /// <typeparam name="T">Result type</typeparam>
    public interface IApiResponse<T>
    {
        /// <summary>
        /// Response Message ID 
        /// </summary>
        int MessageId { get; set; }
        /// <summary>
        /// Response Message Text 
        /// </summary>
        string MessageText { get; set; }
        /// <summary>
        /// Total number of records count (without any paging if the response is limited by paging)
        /// </summary>
        int TotalRecords { get; set; }

        /// <summary>
        /// Http Status Code for the response
        /// </summary>
        HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Actual Records (with paging and sorting applied if applicable)
        /// </summary>
        T Records { get; set; }
    }

    /// <summary>
    /// Generic API reponse for Messages
    /// </summary>    
    public interface IApiResponse
    {
        /// <summary>
        /// Response Message ID 
        /// </summary>
        int MessageId { get; set; }
        /// <summary>
        /// Response Message Text 
        /// </summary>
        string MessageText { get; set; }

        /// <summary>
        /// Http Status Code for the response
        /// </summary>
        HttpStatusCode StatusCode { get; set; }
    }


    /// <summary>
    /// Generic API response object
    /// </summary>
    /// <typeparam name="T">Result type</typeparam>
    public class ApiResponse<T> : IApiResponse<T>
    {
        /// <summary>
        /// Response Message ID 
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// Response Message Text 
        /// </summary>
        public string MessageText { get; set; }
        /// <summary>
        /// Total number of records count (without any paging if the response is limited by paging)
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Actual Records (with paging and sorting applied if applicable)
        /// </summary>
        public T Records { get; set; }

        /// <summary>
        /// Http Status Code for the response
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApiResponse()
        {
            MessageId = 0;
            MessageText = "";
            TotalRecords = 0;
        }
    }

    /// <summary>
    /// Generic API response object for messages
    /// </summary>
    public class ApiResponse : IApiResponse
    {
        /// <summary>
        /// Response Message ID 
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// Response Message Text 
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Http Status Code for the response
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApiResponse()
        {
            MessageId = 0;
            MessageText = "";
        }

        /// <summary>
        /// Used to get an example of the API Response object with test data
        /// </summary>
        /// <returns>Api Response with test data</returns>
        public static ApiResponse GetExample()
        {
            ApiResponse response = new ApiResponse()
            {
                MessageId = 200,
                MessageText = "Success Message"
            };
            return response;
        }


    }


}