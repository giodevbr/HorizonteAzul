namespace HorizonteAzulApi.Resources
{
    public class StringResources
    {
        public static string FormatarResource(string principal, params object[] args)
        {
            return string.Format(principal, args);
        }

        public static string FormatarResourceToLower(string principal, params string[] args)
        {
            if (args == null)
                return principal;

            return FormatarResource(principal, args.Select(x => x.ToLower()).ToArray());
        }

        public const string HorizonteAzulConnection = "HorizonteAzulConnection";
        public const string JwtKeyNaoConfigurado = "Jwt:Key não está configurado";

        public const string NenhumRegistroEncontrado = "Nenhum Registro Encontrado.";
        public const string EmailOuSenhaInvalidos = "Email ou senha inválidos.";
        public const string UsuarioNaoEstaAtivo = "O Usuário não está ativo, contate o administrador do sistema.";
    }
}
