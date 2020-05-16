using AdlerLing.AccountService.Core.Enums;
using System;
using System.Collections.Generic;

namespace AdlerLing.AccountService.Core.Transfering
{
    public class Result
    {
        public Result()
        {
            ErrorMessages = new List<ErrorCodeEnum>();
        }

        public Result(IList<ErrorCodeEnum> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public IList<ErrorCodeEnum> ErrorMessages { get; set; }
        public Exception Exception { get; set; }
        public ResultStatusEnum Status { get; set; }

        public static Result CreateFailure(ErrorCodeEnum errorCode, Exception exception = null)
        {
            return new Result(new List<ErrorCodeEnum>() { errorCode })
            {
                Status = ResultStatusEnum.Failure,
                Exception = exception
            };
        }

        public static Result<T> CreateFailure<T>(ErrorCodeEnum errorCode, Exception exception = null)
        {
            return new Result<T>(new List<ErrorCodeEnum>() { errorCode })
            {
                Status = ResultStatusEnum.Failure,
                Exception = exception
            };
        }

        public static Result CreateFailure(Exception exception = null, IList<ErrorCodeEnum> errorMessages = null)
        {
            if(errorMessages != null)
            {
                return new Result(errorMessages)
                {
                    Status = ResultStatusEnum.Failure
                };
            }

            return new Result { Status = ResultStatusEnum.Failure, Exception = exception };
        }

        public static Result<T> CreateFailure<T>(Exception exception = null, IList<ErrorCodeEnum> errorMessages = null)
        {
            if (errorMessages != null)
            {
                return new Result<T>(errorMessages)
                {
                    Status = ResultStatusEnum.Failure
                };
            }

            return new Result<T> { Status = ResultStatusEnum.Failure, Exception = exception };
        }

        public static Result CreateSuccess(object value = null)
        {
            return new Result { Status = ResultStatusEnum.Success};
        }

        public static Result<T> CreateSuccess<T>(T data)
        {
            return new Result<T> { Status = ResultStatusEnum.Success, Data = data };
        }
    }
}
