using System;
using IPValidationKata;
using Xunit;
using Xunit.Sdk;

namespace IPValidationKataTest
{
    public class IpValidationTests
    {
        [Fact]
        public void Ipv4_valido_deve_possuir_quatro_octets()
        {
            var resultadoValidacao = IpValidation.is_valid_IP("111.111.111.111");
            Assert.Equal(true, resultadoValidacao);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("000")]
        [InlineData("000.000")]
        [InlineData("000.000.000")]
        [InlineData("000.000.000.000.000")]
        [InlineData("000.000.000.000.000.000")]
        public void Ipv4_invalido_tem_uma_quantidade_de_octets_diferente_de_quatro(string ipString)
        {
            var resultadoValidacao = IpValidation.is_valid_IP(ipString);
            Assert.Equal(false, resultadoValidacao);
        }

        [Theory]
        [InlineData("000.000.000,000")]
        [InlineData("000.000,000,000")]
        [InlineData("000,000,000,000")]
        [InlineData("000;000,000,000")]
        [InlineData("000;000;000,000")]
        [InlineData("000;000;000;000")]
        [InlineData("000|000;000;000")]
        [InlineData("000|000|000;000")]
        [InlineData("000|000|000|000")]
        public void Ipv4_inputado_invalido_nao_usa_ponto_como_separador(string ipString)
        {
            var resultadoValidacao = IpValidation.is_valid_IP(ipString);
            Assert.Equal(false, resultadoValidacao);
        }

        [Theory]
        [InlineData("123.0.0.132")]
        [InlineData("123.245.255.132")]
        [InlineData("240.35.213.145")]
        [InlineData("78.43.34.133")]
        [InlineData("56.91.25.46")]
        [InlineData("255.255.255.255")]
        [InlineData("184.205.123.78")]
        [InlineData("31.89.67.87")]
        [InlineData("77.88.99.100")]
        [InlineData("103.132.200.240")]
        [InlineData("76.81.23.55")]
        public void Ipv4_valido_tem_octets_com_valor_entre_zero_e_vintequatro(string ipString)
        {
            var resultadoValidacao = IpValidation.is_valid_IP(ipString);
            Assert.Equal(true, resultadoValidacao);
        }
        
        [Theory]
        [InlineData("405.2341.1234.846")]
        [InlineData("24120.32315.21213.3451")]
        [InlineData("71268.4233.31234.186133")]
        [InlineData("59176.39681.29175.45726")]
        [InlineData("253465.211155.256755.2123155")]
        [InlineData("183314.223505.112323.74568")]
        [InlineData("1131.3389.12367.812347")]
        [InlineData("12377.66688.92139.10430")]
        [InlineData("189903.113832.22342500.2113940")]
        [InlineData("71231236.812341.21233.131255")]
        public void Ipv4_invalido_tem_octets_com_valor_diferente_de_zero_e_vintequatro(string ipString)
        {
            var resultadoValidacao = IpValidation.is_valid_IP(ipString);
            Assert.Equal(false, resultadoValidacao);
        }
        
        [Theory]
        [InlineData("1.1.1.1")]
        [InlineData("2.2.2.2")]
        [InlineData("3.3.3.3")]
        [InlineData("4.4.4.4")]
        [InlineData("5.5.5.5")]
        [InlineData("6.6.6.6")]
        [InlineData("7.7.7.7")]
        [InlineData("8.8.8.8")]
        [InlineData("9.9.9.9")]
        public void Ipv4_valido_tem_octets_com_valor_de_uma_casa_decimal_nao_devem_ter_zero_na_frente(string ipString)
        {
            var resultadoValidacao = IpValidation.is_valid_IP(ipString);
            Assert.Equal(true, resultadoValidacao);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("123.245.255.-132")]
        [InlineData("123.245.255 .132")]
        [InlineData("123. 245.255.132")]
        [InlineData("aasdasdasdasdas")]
        [InlineData("aasa.asdasd.asdasdsad.asdasda")]
        [InlineData("####.####.####.####")]
        [InlineData("****.****.****.****")]
        [InlineData("@@@@.@@@@.@@@@.@@@@")]
        [InlineData("$$$$.$$$$.$$$$.$$$$")]
        [InlineData("%%%%.%%%%.%%%%.%%%%")]
        [InlineData("&&&&.&&&&.&&&&.&&&&")]
        [InlineData("++++.++++.++++.++++")]
        [InlineData("----.----.----.----")]
        [InlineData("asd1231.131asdas.ad123ad.dasd123asd")]
        public void Ipv4_invalido_tem_octets_com_valor_literal(string ipString)
        {
            var resultadoValidacao = IpValidation.is_valid_IP(ipString);
            Assert.Equal(false, resultadoValidacao);
        }
        
        [Theory]
        [InlineData("01.01.01.01")]
        [InlineData("02.02.02.02")]
        [InlineData("03.03.03.03")]
        [InlineData("04.04.04.04")]
        [InlineData("05.05.05.05")]
        [InlineData("06.06.06.06")]
        [InlineData("07.07.07.07")]
        [InlineData("08.08.08.08")]
        [InlineData("09.09.09.09")]
        public void Ipv4_invalido_tem_octets_que_comecam_com_valor_zero_na_frente(string ipString)
        {
            var resultadoValidacao = IpValidation.is_valid_IP(ipString);
            Assert.Equal(false, resultadoValidacao);
        }
    }
}