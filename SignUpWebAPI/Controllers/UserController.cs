using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using SignUpWebAPI.Models;

namespace SignUpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //allow cors
    [EnableCors("_myAllowSpecificOrigins")]
    public class UserController : ControllerBase
    {
        private readonly UserApiDbContext _context;

        public UserController(UserApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userModels = await _context.UserModel.AsNoTracking().ToListAsync();
            return Ok(userModels);
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> Get(int ID)
        {
            var userModels = await _context.UserModel
                .FirstOrDefaultAsync(m => m.ID == ID);
            if (userModels == null)
            {
                return NotFound();
            }

            return Ok(userModels);
        }

        [HttpGet("ByEmail/{Email}")]
        public async Task<IActionResult> Get(String Email)
        {
            var userModels = await _context.UserModel
            .FirstOrDefaultAsync(m => m.Email == Email);
            if (userModels == null)
            {
                return NotFound();
            }

            return Ok(userModels);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var users = new UserModel
                {
                    FullName = model.FullName,
                    Mobile = model.Mobile,
                    UserName = model.UserName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Address = model.Address,
                    Password = model.Password,
                };
                await _context.AddAsync(users);
                await _context.SaveChangesAsync();
                //ارسال ایمیل
                MailMessage mail = new MailMessage();
                mail.To.Add(users.Email);
                mail.From = new MailAddress("testusersignup9@Gmail.com");
                mail.Subject = "WellCome";
                string Body = "ثبت نام شما با موفقیت انجام شد";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("testusersignup9", "4060440590"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                //ارسال ایمیل
                //پر کردن آی دی برای کامل کردن مدل جهت برگشت
                model.ID = users.ID;

                return Ok(model);

            }
            else { return BadRequest("Invalid Data"); }   
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserModel user)
        {
            var usermodels = await _context.UserModel.FindAsync(user.ID);

            usermodels.FullName = user.FullName;
            usermodels.Mobile = user.Mobile;
            usermodels.UserName = user.UserName;
            usermodels.Phone = user.Phone;
            usermodels.Email = user.Email;
            usermodels.Address = user.Address;
            usermodels.Password = user.Password;
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var usermodel = await _context.UserModel.FindAsync(id);
            _context.UserModel.Remove(usermodel);
            await _context.SaveChangesAsync();
            return Ok();

        }


    }
}
