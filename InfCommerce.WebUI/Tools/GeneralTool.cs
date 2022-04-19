using InfCommerce.DAL.Entities;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace InfCommerce.WebUI.Tools
{
    public static class GeneralTool
    {
        public static string ConvertURL(string text)
        {
            return text.ToLower().Replace(" ", "-").Replace("ü", "u").Replace("ö", "o").Replace("ş", "s").Replace("ç", "c").Replace("ğ", "g").Replace("ı", "i");
        }

        public static string getMD5(string _text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(_text));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public static decimal GetCurrency(decimal price,ECurrency eCurrency)
        {
            decimal result = price;
            if (eCurrency != ECurrency.TL)
            {
                result *= getForeignCurrency(Enum.GetName(eCurrency));
            }
            return result;
        }

        public static decimal getForeignCurrency(string _currencyKOD)
        {
            decimal result = 1;
            if (_currencyKOD != "TR")
            {
                try
                {
                    XmlDocument xmldocument = new XmlDocument();
                    xmldocument.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                    result = Convert.ToDecimal(xmldocument.SelectSingleNode("Tarih_Date/Currency[@Kod='" + _currencyKOD + "']/BanknoteSelling").InnerText.Replace(".", ","));
                }
                catch { }
            }
            return result;
        }

        public static string SendMail(string mailSunucusu, int mailSunucuPortu, string mailAdresi, string mailsifresi, bool sslVarmi, string kimden, string[] kimlere, string konu, string mailIcerigi)
        {
            string rtn = "OK";
            SmtpClient smtpClient = new SmtpClient(mailSunucusu, mailSunucuPortu);
            smtpClient.Credentials = new NetworkCredential(mailAdresi, mailsifresi);
            smtpClient.EnableSsl = sslVarmi;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(kimden);
            foreach (string kim in kimlere) mailMessage.To.Add(kim);
            mailMessage.Subject = konu;
            mailMessage.Body = mailIcerigi;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
            return rtn;
        }
    }
}
