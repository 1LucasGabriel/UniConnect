using UniConnect.Argument.Argument;

namespace UniConnect.Argument;

public abstract class BaseOutput<TOutput>
    where TOutput : BaseOutput<TOutput>
{
    public int Id { get; protected set; }
    public int UsuarioCriacaoId { get; protected set; }
    public OutputUsuario? UsuarioCriacao { get; protected set; }
    public DateTime DataCriacao { get; protected set; }
    public int? UsuarioAlteracaoId { get; protected set; }
    public OutputUsuario? UsuarioAlteracao { get; protected set; }
    public DateTime? DataAlteracao { get; protected set; }

    public BaseOutput() { }
}

public class BaseOutput_0 : BaseOutput<BaseOutput_0> { }