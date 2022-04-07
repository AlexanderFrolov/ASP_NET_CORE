namespace HomeApi.Configuration
{
    /// <summary>
    /// Адрес дома 
    /// </summary>
    public class Address
    {
        public int House { get; set; }
        public int Building { get; set; }
        public string Street { get; set; }
    }
}