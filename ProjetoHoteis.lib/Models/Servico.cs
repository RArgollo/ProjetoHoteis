namespace ProjetoHoteis.lib.Models
{
    public class Servico
    {
        public string Nome { get; set; }

        public Servico(string nome)
        {
            SetNome(nome);
        }

        public string GetNome()
        {
            return Nome;
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}