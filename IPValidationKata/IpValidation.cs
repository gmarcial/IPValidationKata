using System;
using System.Linq;

namespace IPValidationKata
{
    public static class IpValidation
    {
        public static bool is_valid_IP(string ipAddres)
        {
            var ipAddresQuebradoPorOctets = ipAddres.Split('.');

            if (ipAddresQuebradoPorOctets.Length != 4) return false;

            var resultadoValidadeOctets = ipAddresQuebradoPorOctets.Select(octetEmString =>
            {
                if (octetEmString.StartsWith(' ')) return false;
                if (octetEmString.EndsWith(' ')) return false;
                if (octetEmString.StartsWith('0')) return false;

                if (!int.TryParse(octetEmString, out var octetEmDecimal)) return false;

                return octetEmDecimal > 0 && octetEmDecimal <= 255;
            }).Count(resultadoOctet => resultadoOctet.Equals(true));
            
            return resultadoValidadeOctets == 4;
        }
    }
}