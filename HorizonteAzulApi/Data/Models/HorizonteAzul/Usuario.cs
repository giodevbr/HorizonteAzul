namespace HorizonteAzulApi.Data.Models.HorizonteAzul
{
    #nullable disable
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }
        public int SituacaoUsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual SituacaoUsuario SituacaoUsuario { get; set; }
    }
}
