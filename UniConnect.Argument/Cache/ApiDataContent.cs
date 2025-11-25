namespace UniConnect.Argument.Cache;

public class ApiDataContent
{
    public int UserId { get; private set; }

    public ApiDataContent(int userId)
    {
        UserId = userId;
    }
}
