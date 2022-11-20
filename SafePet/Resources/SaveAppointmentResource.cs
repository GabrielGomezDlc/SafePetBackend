namespace SafePetBackend.SafePet.Resources
{
    public class SaveAppointmentResource
    {
        public int PetOwnerId { get; set; }
        public string PetOwnerName { get; set; }
        public int VeterinarianId { get; set; }
        public string VeterinarianName { get; set; }
        public string? Date { get; set; }
        public string Image { get; set; }
    }
    
}

