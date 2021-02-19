using System;

namespace Magia.Application.AgendamentoContext.QueryResults
{
    public class ObterSalasQueryResult
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Deletado { get; set; }
    }
}
