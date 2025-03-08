
using System.Net;

namespace Talabat.APIs.Error
{

    public class ApiErrorResponse
    {

        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiErrorResponse(HttpStatusCode statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessForReponse(statusCode);
        }

        private string? GetDefaultMessForReponse(HttpStatusCode statusCode)
        {
            var mess = string.Empty;
            switch (statusCode)
            {

                case HttpStatusCode.NotFound:
                    mess = "Not Founded";
                    break;
                case HttpStatusCode.Unauthorized:
                    mess = "Unauthorized ";
                    break;

                case HttpStatusCode.BadRequest:
                    mess = "Bad Request";
                    break;

                case HttpStatusCode.Created:
                    mess = "Resource created";
                    break;

                default:
                    mess = "Unknown status code";
                    break;


            }
            return mess;
        }


    }
}
