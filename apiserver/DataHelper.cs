using System.Data;
using System.Data.SqlClient;
using HelpDeskShared;
namespace apiserver
{
   
    public static class DataHelper
    {
        private const string constr = @"Data Source=tcp:10.10.204.17,1433;Initial Catalog=WaterPlant;User ID=sa;Password=Karachi2019;";
        public static List<User> GetAllUsers()
        {
            List<User> ulist = new();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTUSERS", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ulist.Add(new User() { UserID = (int)reader["UserID"], UserName = (string)reader["UserName"], Password = (string)reader["Password"] });
            }
            cmd.Dispose();
            conn.Close();
            return ulist;
        }
        public static string InsertUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO CUSTUSERS (UserName, Password) VALUES (@UserName, @Password)", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        cmd.Parameters.AddWithValue("@Password", user.Password);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static string UpdateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("update CUSTUSERS set UserName = @UserName, Password = @Password where userId = @UserID", conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", user.UserID);
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        cmd.Parameters.AddWithValue("@Password", user.Password);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}
