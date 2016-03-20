using System;
using System.Web.Http;
//using System.Web.Mvc;
using UrlMini.Models;

namespace UrlMini.Controllers
{
    public class CodecController : ApiController
    {
        public DecodeResponse Get(string id)
        {
            DecodeResponse response = new DecodeResponse(DataAccess.RetrieveUrl(id));
            
            return response;
        }

        
        public EncodeResponse Post(EncodeRequest request)
        {
            EncodeResponse response = new EncodeResponse();
                        
            try
            {
                DataAccess.InsertUrl(request.Url);
                int returnCode = DataAccess.GetMostRecentRecordId();

                response.Code = UrlMinimizer.Encode(returnCode);
                response.Status = "Success";
            }
            catch (Exception e)
            {
                if (e.Message.Contains("expects the parameter '@Url'"))
                {
                    response.Status = "The Parameters did not include a value for Url";
                }
                else {
                    response.Status = e.Message;
                }
            }

            return response;

        }
    }
}
