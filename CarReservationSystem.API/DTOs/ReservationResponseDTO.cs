using System;

namespace CarReservationSystem.API.DTOs
{
    public class ReservationResponseDTO
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}