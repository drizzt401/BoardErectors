namespace BoardErectors.Domain.Entities
{
    public class Address
    {
        public string Id { get; set; }
        public string HouseNumber { get; set; }
        public string Address1 { get; set; }
        public string Locality { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}
