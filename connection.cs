
using MySql.Data.MySqlClient;

namespace Econtact.econtactclasses
{
    internal class connection
    {
        string conString =
            "Server=localhost;Port=3308;Database=EContactDB;Uid=root;Pwd=1234;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(conString);
        }
    }
}
