using System;
using System.Text.RegularExpressions;
using TutorialEcommerce.Helpers;

namespace TutorialEcommerce.Domain.ValueObject
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public string Endereco { get; private set; }

        //Construtor do EntityFramework
        protected Email()
        {

        }

        public Email(string endereco)
        {
            Guard.ForNullOrEmptyDefaultMessage(endereco, "E-mail");
            Guard.StringLength("E-mail", endereco, EnderecoMaxLength);

            if(IsValid(endereco) == false)
                throw new Exception("E-mail inválido");

            Endereco = endereco;
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
