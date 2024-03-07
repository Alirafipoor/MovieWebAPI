using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Token
{
    public class CreateTokenDto
    {
        public string Token { get; set; }
        public DateTime Exp { get; set; }
    }
}
