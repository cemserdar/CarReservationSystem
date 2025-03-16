using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservationSystem.Domain.Entities;
using CarReservationSystem.Domain.Repositories;

namespace CarReservationSystem.Application.Queries
{
    public class GetAllCarsQuery
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarsQuery(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<Car>> ExecuteAsync()
        {
            return await _carRepository.GetAllAsync();
        }
    }
}