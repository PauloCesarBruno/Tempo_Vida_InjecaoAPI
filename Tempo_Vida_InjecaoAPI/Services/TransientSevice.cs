using Tempo_Vida_InjecaoAPI.Interfaces;

namespace Tempo_Vida_InjecaoAPI.Services;

public class TransientSevice : ITransientService
{
    public Guid OperationId { get; } = Guid.NewGuid();
}
