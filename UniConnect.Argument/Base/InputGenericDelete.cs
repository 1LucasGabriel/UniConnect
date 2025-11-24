using System.Text.Json.Serialization;

namespace UniConnect.Argument.Base;

public class InputGenericDelete : BaseInputDelete<InputGenericDelete>
{
    public InputGenericDelete() { }

    [JsonConstructor]
    public InputGenericDelete(int id) : base(id) { }
}