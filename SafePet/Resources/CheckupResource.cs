namespace SafePetBackend.SafePet.Resources {
    public class CheckupResource
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Date { get; set; }
        public string Observation { get; set; }
        public string Prescription { get; set; }
    }
}