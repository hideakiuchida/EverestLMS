namespace EverestLMS.Common.Connections
{
    public static class ConnectionSettings
    {
        private static string HideakiUchidaConnectionString = "Server=HIDEAKIUCHIDA;Database=EVERESTLMS;Integrated Security=True;";
        private static string AvanticaConnectionString = "Data Source=LIM-LP01542\\MSSQLSERVER01;Database=EVERESTLMS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        public static string ConnectionString { get { return HideakiUchidaConnectionString; } }
    }
}
