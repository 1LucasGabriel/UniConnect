namespace UniConnect.Argument.Argument;

public class InputAuthenticate
{
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public InputAuthenticate(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
}
