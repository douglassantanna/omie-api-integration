namespace omie_api_integration.Shared
{
    public record Result(string Mensagem, bool Sucesso = true, object? Dados = null);
}