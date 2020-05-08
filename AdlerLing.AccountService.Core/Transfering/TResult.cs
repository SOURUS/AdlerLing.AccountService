using AdlerLing.AccountService.Core.Enums;
using System.Collections.Generic;

namespace AdlerLing.AccountService.Core.Transfering
{
    public class Result<T>: Result
    {
        public Result() { }

        public Result(IList<ErrorCodeEnum> errorMessages) : base(errorMessages) { }

        public T Data { get; set; }

        public static Result<T> CreateSuccess(T value)
        {
            return new Result<T> { Status = ResultStatusEnum.Success, Data = value };
        }
    }
}
