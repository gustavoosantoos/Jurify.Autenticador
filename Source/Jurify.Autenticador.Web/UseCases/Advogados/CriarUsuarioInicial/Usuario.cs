namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int CodigoEstado { get; set; }
        public string NumeroOAB { get; set; }
    }
}
