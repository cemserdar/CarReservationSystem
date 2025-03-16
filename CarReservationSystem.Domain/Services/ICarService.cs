using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservationSystem.Domain.Entities;

namespace CarReservationSystem.Domain.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
        Task<bool> ReserveCarAsync(int carId, string customerName, DateTime reservationDate, DateTime returnDate);
    }
}