namespace EverestLMS.Common.Connections
{
    public static class ConnectionSettings
    {
#pragma warning disable S1144 // Unused private types or members should be removed
        private static string LocalConnectionString = "Server=HIDEAKIUCHIDA;Database=EVERESTLMS;Integrated Security=True;";
#pragma warning restore S1144 // Unused private types or members should be removed
        private static string BelatrixConnectionString = "Server=BLX-PE-JUCHIDA; Database=EVERESTLMS; Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        public static string ConnectionString { get { return LocalConnectionString; } }
    }
}
