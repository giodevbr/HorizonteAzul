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
    }
}
