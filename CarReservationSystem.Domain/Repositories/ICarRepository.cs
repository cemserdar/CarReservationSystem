using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservationSystem.Domain.Entities;

namespace CarReservationSystem.Domain.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
    }
}