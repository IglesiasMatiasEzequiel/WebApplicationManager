namespace AppCommon.Functions
{
    public static class Queries
    {
        #region Queries

        public static int ObtenerUsuario = 1;

        public static string InsertarUsuario = "INSERT INTO Usuarios(Email, Nombre, Password, FechaAlta) " +
                                               "VALUES(':EMAIL@', ':NOMBRE@', ':PASSWORD@', GETDATE())";

        #endregion
    }
}