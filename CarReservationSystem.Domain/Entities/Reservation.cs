using System;

namespace CarReservationSystem.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CarId { get; set; } // Hangi araç rezerve edildi?
        public string CustomerName { get; set; } // Müşteri adı
        public DateTime ReservationDate { get; set; } // Rezervasyon tarihi
        public DateTime ReturnDate { get; set; } // Araç iade tarihi
    }
}