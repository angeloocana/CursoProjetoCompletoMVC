namespace TutorialEcommerce.Domain.ValueObject
{
    public interface IMinhaInterfaceComecandoComISeguidoDeLetraMaiuscula
    {
        bool CriarMetodoComVerboEPrimeiraLetraMaiuscula(bool parametroComLetraMinuscula);
    }

    public class MinhaClasseComLetraMaiuscula : IMinhaInterfaceComecandoComISeguidoDeLetraMaiuscula
    {
        private bool _variaisPrivadasSempreComecandoComUnderlineELetraMinuscula;

        public string MinhaPropriedadeComLetraMaiuscula { get; set; }

        public bool CriarMetodoComVerboEPrimeiraLetraMaiuscula(bool parametroComLetraMinuscula)
        {
            _variaisPrivadasSempreComecandoComUnderlineELetraMinuscula = parametroComLetraMinuscula;
            var varialInternaComLetraMinuscula = _variaisPrivadasSempreComecandoComUnderlineELetraMinuscula;
            return varialInternaComLetraMinuscula;
        }
    }
}
