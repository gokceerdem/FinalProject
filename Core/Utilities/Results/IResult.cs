namespace Core.Utilities.Results
{
    //temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; }//get okumak için set yazmak için kullanılır
                             // get olunca sadece return değeri var
                             // ekleme işlemi için örneğin success true/false olur 
                             //message da bu dönüş için mesaj örn: ürün eklendi
        string Message { get; }
    }
}
