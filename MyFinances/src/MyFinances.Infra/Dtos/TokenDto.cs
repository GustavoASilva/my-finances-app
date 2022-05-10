using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinances.Infra.Dtos
{
    public class TokenDto
    {
        public TokenDto(string accessToken, double expiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
    }
}
