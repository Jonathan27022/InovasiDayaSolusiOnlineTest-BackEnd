using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTestPTInovasiDayaSolusi.Models;
using OnlineTestPTInovasiDayaSolusi.Data;

namespace OnlineTestPTInovasiDayaSolusi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DbApi _context;

        public TransactionController(DbApi context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            var transactionData = await _context.Transactions.ToListAsync();
            var statusData = await _context.Statuses.ToListAsync();
            var response = new ApiResponse
            {
                data = transactionData,
                status = statusData
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTransactions", new { id = transaction.id }, transaction);
        }
    }
}
