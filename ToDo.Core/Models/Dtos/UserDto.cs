using System.ComponentModel.DataAnnotations;
using Todo.Core.Models.Common;

namespace Todo.Core.Models.Dtos
{
    public class UserDto : UserBase
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
