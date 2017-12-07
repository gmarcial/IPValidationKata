using System;

namespace IPValidationKata
{
    public class IpValidation
    {
        public IpValidation()
        {   
        }
        
        public static bool is_valid_IP(string ipAddres)
        {
            return ipAddres.Split('.').Length == 4;
            
            //var ipAddresQuebradoPorOctets = ipAddres.Split('.');

            //if (ipAddresQuebradoPorOctets.Length != 4) return false;
        } 
    }
}