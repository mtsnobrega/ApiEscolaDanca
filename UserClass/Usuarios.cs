namespace ApiEscolaDanca.UserClass
{
    public class Usuarios
    {
        public Guid Id { get; init; } // Gerado pelo sistema
        public string UserIdFirebase { get; set; } // UID real do Firebase

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }


        public Usuarios() { }

        public Usuarios(string userfirebase, string nome, string cpf, string email, string telefone, DateTime datanasc)
        {
            Id = Guid.NewGuid();
            UserIdFirebase = userfirebase;
            Nome = nome;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
            DataNascimento = datanasc;
        }
    }
}

