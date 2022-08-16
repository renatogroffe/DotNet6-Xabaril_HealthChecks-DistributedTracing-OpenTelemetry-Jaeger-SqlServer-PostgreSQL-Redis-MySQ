namespace APIContagem.Data;

public class HistoricoContagem
{
    public int? Id { get; set; }
    public DateTime DataProcessamento { get; set; }
    public int ValorAtual { get; set; }
    public string? Producer { get; set; }
    public string? Kernel { get; set; }
    public string? Framework { get; set; }
    public string? Mensagem { get; set; }
}