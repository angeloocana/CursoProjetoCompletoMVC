using TutorialEcommerce.Helpers;

namespace TutorialEcommerce.Domain.ValueObject
{
    public class Telefone
    {
        public const int NumeroMaxLength = 20;
        public string Numero { get; private set; }

        public const int DDDMaxLength = 3;
        public string DDD { get; private set; }

        protected Telefone()
        {

        }

        public Telefone(string ddd, string numero)
        {
            SetTelefone(numero);
            SetDDD(ddd);
        }

        private void SetTelefone(string numero)
        {
            if (string.IsNullOrEmpty(numero))
                numero = "";
            else
                Guard.StringLength("Telefone", numero, NumeroMaxLength);
            Numero = numero;
        }

        private void SetDDD(string ddd)
        {
            if (string.IsNullOrEmpty(ddd))
                ddd = "";
            else
                Guard.StringLength("DDD", ddd, DDDMaxLength);
            DDD = ddd;
        }
        
        public string GetTelefoneCompleto()
        {
            return DDD + Numero;
        }
    }
}
