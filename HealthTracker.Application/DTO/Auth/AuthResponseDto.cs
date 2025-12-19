using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Application.DTO.Auth
{
    public class AuthResponseDto
    {
        public string UserId { get; set; }
        public string Token {  get; set; }
        public DateTime Expiration { get; set; }
    }
}
