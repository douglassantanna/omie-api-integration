namespace omie_poc.OrdemServico
{
    public class OrdemDeServicoResponse
    {
        public dynamic Message { get; private set; }

        public OrdemDeServicoResponse(dynamic message)
        {
            Message = message;
        }
    }
}