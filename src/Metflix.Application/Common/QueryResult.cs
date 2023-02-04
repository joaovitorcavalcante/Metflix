using Metflix.Domain.Abstractions;

namespace Metflix.Application.Common
{
    public class QueryResult<TEntity> where TEntity : EntityBase
    {
        public List<TEntity> Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }

        public QueryResult(
            List<TEntity> data,
            bool status = true,
            string message = "Operação efetuada com sucesso!")
        {
            Status = status;
            Data = data;
            Message = message;
        }

        public QueryResult(
            TEntity data,
            bool status = true,
            string message = "Operação efetuada com sucesso!")
        {
            Data = new List<TEntity> { data };
            Status = status;
            Message = message;
        }
    }
}
