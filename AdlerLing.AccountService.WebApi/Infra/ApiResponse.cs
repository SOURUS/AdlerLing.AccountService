using System.Collections.Generic;
using System.Net;

namespace AdlerLing.AccountService.WebApi.Infra
{
    public class ApiResponse 
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>();
        }

        public ApiResponse(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public IList<string> ErrorMessages { get; set; }
        public int StatusCode { get; set; }
        public object Result { get; set; }


        public static ApiResponse CreateFailure(HttpStatusCode statusCode, string errorMessage)
        {
            return new ApiResponse(new List<string>() { errorMessage })
            {
                StatusCode = (int)statusCode
            };
        }

        public static ApiResponse CreateFailure(HttpStatusCode statusCode, IList<string> errorMessages)
        {
            if (errorMessages != null)
            {
                return new ApiResponse(errorMessages)
                {
                    StatusCode = (int)statusCode
                };
            }

            return new ApiResponse { StatusCode = (int)statusCode };
        }

        public static ApiResponse CreateSuccess(HttpStatusCode statusCode, object result)
        {
            return new ApiResponse { 
                Result = result,
                StatusCode = (int)statusCode
            };
        }
    }
}
