namespace ApiEscolaDanca.UserClass
{
    
    public record Add_Usuario(string UserIdFirebase, string Nome, string CPF, string Email, string Telefone, DateTime DataNascimento);

   
    public record Read_Usuario(string Nome, string Email, string Telefone, string CPF, DateTime DataNascimento);

    public record Update_Usuario(string Telefone);

}
