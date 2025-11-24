using UniConnect.Argument;

namespace UniConnect.Domain.Interface.Service;

public interface IBaseService<TInputCreate, TInputUpdate, TInputDelete, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputDelete : BaseInputDelete<TInputDelete>
        where TOutput : BaseOutput<TOutput>
{
    List<TOutput>? GetAll();
    TOutput? Get(int id);
    int Create(TInputCreate? inputCreate);
    List<int>? CreateMultiple(List<TInputCreate>? listInputCreate);
    int Update(TInputUpdate? inputUpdate);
    List<int>? UpdateMultiple(List<TInputUpdate>? listInputUpdate);
    bool Delete(TInputDelete? inputDelete);
    bool DeleteMultiple(List<TInputDelete>? listInputDelete);
}