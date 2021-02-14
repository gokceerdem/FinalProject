using System;
namespace Business.Constants
{
    public static class Messages

    {
        //private field yazımı productAdded
        //public field yazımı ProductAdded
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi hatalı";
        public static string MaintenanceTime = "Şu anda işleminizi gerçekleştiremiyoruz";
        //internal static string ProductsListed;//product manager içinde olmayan bir alan ekleyip
                                                //generate field denilince bu oluşuyor
        public static string ProductsListed = "Ürünler listelendi";
    }
}
