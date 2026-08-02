namespace API_DONACIONES.Dtos
{
    public class DonorWithDonationDto
    {
        public DonorDto Donor { get; set; } = null!;
        public DonationDto Donation { get; set; } = null!;
    }
}