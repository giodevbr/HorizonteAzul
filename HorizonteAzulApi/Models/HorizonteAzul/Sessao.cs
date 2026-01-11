namespace HorizonteAzulApi.Models.HorizonteAzul
{
    #nullable disable
    public class Sessao
    {
        public int SessaoId { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
