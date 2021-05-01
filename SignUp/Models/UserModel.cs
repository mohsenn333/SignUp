using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignUp.Models
{
    public class UserModel
    {
        [Key]
        public long ID { get; set; }

        [Required (ErrorMessage = "این فیلد اجباری است")]
        [MinLength(3, ErrorMessage = "حداقل طول 3 کاراکتر می باشد")]
        [MaxLength(50,ErrorMessage = "حداکثر طول 50 کاراکتر میباشد")]
        public string FullName { get; set; }
        
        [Required (ErrorMessage = "این فیلد اجباری است")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MinLength(5, ErrorMessage = "حداقل طول 3 کاراکتر می باشد")]
        [MaxLength(20, ErrorMessage = "حداکثر طول 20 کاراکتر میباشد")]
        public string UserName { get; set; }
        public string Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "ایمیل آدرس را صحیح وارد نمایید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Address { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MinLength(5, ErrorMessage = "حداقل طول 3 کاراکتر می باشد")]
        [MaxLength(20, ErrorMessage = "حداکثر طول 20 کاراکتر میباشد")]
        public string Password { get; set; }



    }
}
