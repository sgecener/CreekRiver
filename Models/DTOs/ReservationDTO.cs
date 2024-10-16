namespace CreekRiver.Models.DTOs;

public class ReservationDTO {
    public int Id { get; set; }
    public int CampsiteId { get; set; }
    public Campsite Campsite { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckoutDate { get; set; }
}