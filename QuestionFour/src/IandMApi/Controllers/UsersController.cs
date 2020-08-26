using System;
using System.Threading.Tasks;
using IandMApi.Data;
using IandMApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IandMApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IandMDbContext _context;

        public UsersController(IandMDbContext context)
        {
            _context = context;
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto model)
        {
            await Task.CompletedTask;
            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Name = model.Name,
                Phone = model.Phone
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return Ok(new
            {
                Success = true,
                Message = "User created Successfully",
                Data = new
                {
                    Id = userId
                }
            });
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await  _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Single(Guid id)
        {
            var user = await _context.Users
                .Include(i => i.IoUs)
                .Include( i => i.UoMes)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));

            if (user is null)
            {
                return BadRequest(new {Success = false, Message = "Unable to find user"});
            }
            return Ok(user);
        }
        
    }
}