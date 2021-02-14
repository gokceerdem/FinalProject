namespace Core.Utilities.Results
{
    public class Result : IResult
    {//IResult sınıfının somut kısmı
        //result bir iresult implementasyonudur
        /*
        private bool v1;
        private string v2;

        public Result(bool v1, string v2)//bu constructor otomatik oluştu
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        */
        /* ilk hali:
        public Result(bool success, string message)//bu constructor otomatik oluştu
        {
            Message = message;
            Success = success;
        }*/

        public Result(bool success, string message) : this(success)//constructor'ın base ile çalışma örneği
        {
            Message = message;
            
        }
        public Result(bool success)//bu constructor otomatik oluştu
        {
            //Message = message;
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; } //get read-only'dir read-only'ler constructor'da set edilbilir
    }
}
