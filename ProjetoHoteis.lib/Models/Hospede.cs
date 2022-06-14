namespace ProjetoHoteis.lib.Models
{
    public class Hospede
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public Hospede(string nome, string cpf, string email, string telefone, string dataNascimento)
        {
            SetNome(nome);
            SetCpf(cpf);
            SetEmail(email);
            SetTelefone(telefone);
            SetDataNascimento(dataNascimento);
        }

        public string GetNome()
        {
            return Nome;
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public string GetCpf()
        {
            return Cpf;
        }
        public void SetCpf(string cpf)
        {
            Cpf = cpf;
        }

        public string GetEmail()
        {
            return Email;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }

        public string GetTelefone()
        {
            return Telefone;
        }
        public void SetTelefone(string telefone)
        {
            Telefone = telefone;
        }

        public DateTime GetDataNascimento()
        {
            return DataNascimento;
        }
        public void SetDataNascimento(string dataNascimento)
        {
            DataNascimento = DateTime.Parse(dataNascimento);
        }
    }
}