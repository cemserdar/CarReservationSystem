using System;

namespace CarReservationSystem.API.DTOs
{
    public class ReservationRequestDTO
    {
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}