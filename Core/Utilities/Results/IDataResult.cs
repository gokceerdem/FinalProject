using System;
namespace Core.Utilities.Results
{
    //generic type return
    //mesaj içerecek, return değer içerecek
    public interface IDataResult<T> : IResult
    {
        T Data { get; }

    }
}
