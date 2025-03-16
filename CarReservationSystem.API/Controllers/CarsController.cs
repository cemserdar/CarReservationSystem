using System.Collections.Generic;
using System.Threading.Tasks;
using CarReservationSystem.API.DTOs;
using CarReservationSystem.Domain.Entities;
using CarReservationSystem.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarReservationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            var carDTOs = new List<CarDTO>();

            foreach (var car in cars)
            {
                carDTOs.Add(new CarDTO
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Year = car.Year,
                    IsAvailable = car.IsAvailable
                });
            }

            return Ok(carDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();

            var carDTO = new CarDTO
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                IsAvailable = car.IsAvailable
            };

            return Ok(carDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddCar([FromBody] CarDTO carDTO)
        {
            var car = new Car
            {
                Make = carDTO.Make,
                Model = carDTO.Model,
                Year = carDTO.Year,
                IsAvailable = carDTO.IsAvailable
            };

            await _carService.AddCarAsync(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, carDTO);
        }

        [HttpPost("{id}/reserve")]
        public async Task<ActionResult> ReserveCar(int id, [FromBody] ReservationRequestDTO reservationRequestDTO)
        {
            var success = await _carService.ReserveCarAsync(
                id,
                reservationRequestDTO.CustomerName,
                reservationRequestDTO.ReservationDate,
                reservationRequestDTO.ReturnDate
            );

            if (!success)
                return BadRequest("Araç müsait değil veya bulunamadı.");

            return Ok();
        }
    }
}