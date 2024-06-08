namespace derleyici
{
    // Token sınıfı, bir kod parçasının türünü ve değerini temsil eder.
    public class Token
    {
        // Token türü ve değeri
        public string Tip { get; }
        public string Deger { get; }

        // Token sınıfının yapıcı metodu.
        public Token(string tip, string deger)
        {
            Tip = tip;
            Deger = deger;
        }

        // Token nesnesinin string temsilini döndüren metot.
        public override string ToString()
        {
            return $"[Tip: {Tip}, Değer: {Deger}]";
        }
    }
}
