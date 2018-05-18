using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Models;
using user.Models;

namespace user.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly userContext _context;

        

        public UsersController(userContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User.Models.User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = _context.Users.SingleOrDefault(m => m.Id == id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUsers([FromRoute] int id, [FromBody] User.Models.User users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUsers([FromBody] User.Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var _user = _context.Users.SingleOrDefault(m => m.UserName == user.UserName);

            if (user != null)
            {
                if (_user == null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                else
                {
                    if (_user.UserName == user.UserName)
                    {
                        return BadRequest("UserName already exists");
                    }
                }
            }
            else
            {
                return BadRequest("Post body invalid");
            }

        
         




            return CreatedAtAction("GetUsers", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = _context.Users.SingleOrDefault(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            _context.SaveChanges();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}