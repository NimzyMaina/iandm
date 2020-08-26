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
    public class IoUController : ControllerBase
    {
        private readonly IandMDbContext _context;

        public IoUController(IandMDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentDto model)
        {
            var iouId = Guid.NewGuid();
            var iou = new IoU
            {
                Id = iouId,
                Amount = model.Amount,
                BorrowerId = Guid.Parse(model.Borrower),
                LenderId = Guid.Parse(model.Lender),
                CreatedAt = DateTime.UtcNow,
                Status = "Open"
            };

            await _context.IoUs.AddAsync(iou);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Success = true,
                Message = "IoU created Successfully",
                Data = new
                {
                    Id = iouId
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ious = await _context.IoUs.ToListAsync();
            return Ok(ious);
        }
        
        
    }
}