namespace HorizonteAzulApi.Data.Models.HorizonteAzul
{
    #nullable disable
    public class Sessao
    {
        public int SessaoId { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string UsuarioIp { get; set; }
        public string ServidorIp { get; set; }
        public string Metodo { get; set; }
        public string Protocolo { get; set; }
        public string ConteudoTipo { get; set; }
        public string Plataforma { get; set; }
        public string Server { get; set; }
        public string Navegador { get; set; }
        public string NavegadorTipo { get; set; }
        public string NavegadorVersao { get; set; }
        public string NavegadorAgente { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
