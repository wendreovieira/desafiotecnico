namespace DesafioTecnico.ApiTaxaJuros.Helper
{
    public static class ApiRoutes
    {
        public const string Base = "http://localhost:5202";
        public const string BaseDocker = "http://host.docker.internal:5202";

        public static class TaxaJuros
        {
            public const string Get = Base + "/taxajuros";
            public const string GetDocker = BaseDocker + "/taxajuros";
        }
    }
}
