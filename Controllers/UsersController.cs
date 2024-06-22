using administradorUsuarios.Data;
using administradorUsuarios.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace administradorUsuarios.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
  
    public class UsersController : ControllerBase
    {
        private readonly ContextData _context;
        public UsersController(ContextData context)
        {
           _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;

        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new {id = user.Id},User);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<User>> PutUser(int id,User user)
        {
            if (id!= user.Id)
            {
             return BadRequest();

            }
            _context.Users.Entry(user).State=EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound();

            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user==null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }
    }
}
