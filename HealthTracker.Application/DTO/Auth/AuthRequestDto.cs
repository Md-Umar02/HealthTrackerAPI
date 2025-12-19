using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.DTO.Auth
{
    public class AuthRequestDto
    {
        public string Email {  get; set; }
        public string Password {  get; set; }
    }
}
