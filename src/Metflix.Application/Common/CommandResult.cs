using Metflix.Domain.Abstractions;

namespace Metflix.Application.Common
{
    public class CommandResult<TEntity> where TEntity : EntityBase
    {
        public TEntity Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }

        public CommandResult(
            TEntity data, 
            bool status = true, 
            string message = "Operação efetuada com sucesso!")
        {
            Status = status;
            Data = data;
            Message = message;
        }
    }
}
