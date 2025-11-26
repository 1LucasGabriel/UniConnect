using System.Text.Json.Serialization;

namespace UniConnect.Argument;

public abstract class BaseInputUpdate<TInputUpdate>
    where TInputUpdate : BaseInputUpdate<TInputUpdate>
{
    public int Id { get; private set; }

    public BaseInputUpdate() { }

    [JsonConstructor]
    public BaseInputUpdate(int id)
    {
        Id = id;
    }
}

public class BaseInputUpdate_0 : BaseInputUpdate<BaseInputUpdate_0>
{
    public BaseInputUpdate_0(int id) : base(id) { }
}