using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservationSystem.Domain.Entities;
using CarReservationSystem.Domain.Repositories;
using CarReservationSystem.Domain.Services;

namespace CarReservationSystem.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetByIdAsync(id);
        }

        public async Task AddCarAsync(Car car)
        {
            await _carRepository.AddAsync(car);
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _carRepository.UpdateAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteAsync(id);
        }

        public async Task<bool> ReserveCarAsync(int carId, string customerName, DateTime reservationDate, DateTime returnDate)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            if (car == null || !car.IsAvailable)
                return false;

            // Rezervasyon işlemi
            car.IsAvailable = false;
            await _carRepository.UpdateAsync(car);


            return true;
        }
    }
}