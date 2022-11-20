namespace SafePetBackend.SafePet.Resources
{
    public class AppointmentResource
    {
        public int Id { get; set; }
        public int PetOwnerId { get; set; }
        public string PetOwnerName { get; set; }
        public int VeterinarianId { get; set; }
        public string VeterinarianName { get; set; }
        public string? Date { get; set; }
        public string Image { get; set; }
    }
    
}
