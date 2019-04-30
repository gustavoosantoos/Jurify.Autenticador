namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class TelefoneContato
    {
        public int DDD { get; }
        public int Numero { get; }

        public TelefoneContato(int dDD, int numero)
        {
            DDD = dDD;
            Numero = numero;
        }
    }
}
