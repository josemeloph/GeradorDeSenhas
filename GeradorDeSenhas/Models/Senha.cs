using System.Security.Policy;
using System.Text;

namespace GeradorDeSenhas.Models
{
    public class Senha
    {
        public string Valor {  get; set; }
        public int Tamanho {  get; set; }
        public bool Maiusculas {  get; set; }
        public bool Minusculas { get; set; }
        public bool Numeros {  get; set; }
        public bool Especiais { get; set; }
        
        public string CaracteresPossiveis()
        {
            StringBuilder caracteresPossiveis = new StringBuilder();
            if (Maiusculas) caracteresPossiveis.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            if (Minusculas) caracteresPossiveis.Append("abcdefghijklmnopqrstuvwxyz");
            if (Numeros) caracteresPossiveis.Append("1234567890");
            if (Especiais) caracteresPossiveis.Append("!@#$%&*()=-+.,;?{}[]^><:");
            return caracteresPossiveis.ToString();
        }

    }
}
