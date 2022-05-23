using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarAppBackend.Models;
using CarAppBackend.DTOs;
using AutoMapper;

namespace CarAppBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDealershipContext _context;
        private readonly IMapper mapper;

        public CarController(CarDealershipContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            var cars = await _context.Cars.ToListAsync();
            var carDTOs = mapper.Map<IEnumerable<CarDTO>>(cars);
            return Ok(carDTOs);
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCar(int id)
        {
          if (_context.Cars == null)
          {
              return NotFound();
          }
            var car = await _context.Cars.FindAsync(id);          
            if (car == null)
            {
                return NotFound();
            }
            var carDTO = mapper.Map<CarDTO>(car);
            return carDTO;
        }

        // PUT: api/Car/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, CarUpdateDTO carUpdateDTO)
        {
            if (id != carUpdateDTO.Id)
            {
                return BadRequest();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            mapper.Map(carUpdateDTO, car);
            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Car
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarDTO>> PostCar(CarUpdateDTO carDTO)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'CarDealershipContext.Cars'  is null.");
            }
            var car = mapper.Map<Car>(carDTO);
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
