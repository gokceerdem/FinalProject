using System;
namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T> 
    {
        /// <summary>
        /// 4 farklı kullanım
        /// hepsi success return
        /// normalde ilk iki versiyon kullanılıyor daha çok fakat frameworklerde diğerleri de ekleniyor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
                
        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }
        //defaut : tip için defult değer
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
