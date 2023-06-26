using examen1.controllers;
using Examen1.controllers;

internal static class AppHelpers
{
    static database Database;
    public static database Datab
    {
        get
        {
            if (Database == null)
            {
                Database = new database();
            }
            return Database;
        }
    }
}