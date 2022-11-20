namespace SafePetBackend.SafePet.Resources
{
    public class ReviewResource
    {
        public int Id { get; set; }
        public int PetOwnerId { get; set; }
        public string PetOwnerName { get; set; }
        public int VeterinarianId { get; set; }
        public string VeterinarianName { get; set; }
  
        public int Stars { get; set; }
        public string Comment { get; set; }
    }
    
}

