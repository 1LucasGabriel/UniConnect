namespace UniConnect.Argument;

public abstract class BaseInputDelete<TInputDelete>
    where TInputDelete : BaseInputDelete<TInputDelete>
{
    public int Id { get; init; }

    public BaseInputDelete() { }

    public BaseInputDelete(int id)
    {
        Id = id;
    }
}

public class BaseInputDelete_0 : BaseInputDelete<BaseInputDelete_0> { }