namespace UniConnect.Argument.Argument;

public class OutputAuthenticate
{
    public string Token { get; set; }

    public OutputAuthenticate(string token)
    {
        Token = token;
    }
}
