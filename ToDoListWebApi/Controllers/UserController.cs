using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListWebApi.Context;
using ToDoListWebApi.Models.Dtos;
using ToDoListWebApi.Models.Orms;

namespace ToDoListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MyContex  db;
            public UserController() 
        { 
       db = new MyContex();
        }


        [HttpGet()]
        public IActionResult GetAll()
        {
            List<User> response = db.Users.Select(x => new User
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
            }).ToList();
            if (response.Count > 0)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
           List<UserDtoGet> response = db.Users.Select(x => new UserDtoGet
           {
               Name = x.Name,
               Email = x.Email,
           }).ToList();
            if (response.Count > 0 )
            {
                return Ok (response);
            }
            else
            {
                return BadRequest ();
            }
        }

        [HttpPost("register")]
        public IActionResult Post(UserDtoPost dtoPost)
        {
            User user = new User();
            user.Name = dtoPost.Name;
            user.Email = dtoPost.Email;
            user.Password = dtoPost.Password;
            db.Users.Add(user);
            db.SaveChanges();
            return Ok (dtoPost);
        }

        [HttpDelete("del")]
        public IActionResult Delete(int id)
        {
            User user = db.Users.FirstOrDefault(q => q.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return Ok("silindi");
            }
            else
            {
                return NotFound("Bulunamadı");
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateUser(int id, UserDtoPost dtoPost)
        {
            var result = db.Users.FirstOrDefault(q => q.Id == id);
            if (result != null)
            {
                result.Name = dtoPost.Name;
                result.Email = dtoPost.Email;
                result.Password = dtoPost.Password;
                db.SaveChanges();
                return Ok("Güncellendi");
            }
            else
            {
                return NotFound("Bulunamadı");
            }
        }




    }
}
