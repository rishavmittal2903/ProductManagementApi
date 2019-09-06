using ProductManagement.Entities;
using ProductManagement.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public sealed class SqlDBContext: IDBContext
    {
        private static readonly object dbLock = new object();
        private static SqlDBContext sqlDBInstance = null;
        public static SqlDBContext DBInstance
        {
            get
            {
                if (sqlDBInstance == null)
                {
                    lock (dbLock)
                    {
                        if (sqlDBInstance == null)
                        {
                            sqlDBInstance = new SqlDBContext();
                        }
                       
                    }
                }
                return sqlDBInstance;
            }
        }
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        string connection = string.Empty;
        public SqlDBContext()
        {
            connection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }
        private DataTable CreateDataTable(object o)
        {
            DataTable dt = new DataTable();

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            o.GetType().GetProperties().ToList().ForEach(f =>
            {

                f.GetValue(o, null);
                dt.Columns.Add(f.Name, f.PropertyType);
                dt.Rows[0][f.Name] = f.GetValue(o, null);


            });
            return dt;
        }
        public Task<bool> Add_Delete_Modify_User(UserDetails userDetails,int flag)
        {
            bool rowAffected = false;
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlCommand = new SqlCommand("ManageUsers", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@UserDetails", SqlDbType.Structured).Value = CreateDataTable(userDetails);
                sqlCommand.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                sqlConnection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    rowAffected = true;
                }
            }
            return Task.FromResult(rowAffected);
        }
        public Task<UserDetails> Login(UserDetails userDetails)
        {
            bool rowAffected = false;
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlCommand = new SqlCommand("Login", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@UserDetails", SqlDbType.Structured).Value = CreateDataTable(userDetails);
                sqlConnection.Open();
                using (var objDataReader = sqlCommand.ExecuteReader())
                {
                    while (objDataReader.Read())
                    {

                        userDetails= UserDetails.Fill((IDataRecord)objDataReader);
                    }
                }
                return Task.FromResult(userDetails);
            }
        }
        public Task<List<UserDetails>> GetAllUsers()
        {
            List<UserDetails> lstDetails = new List<UserDetails>();
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlCommand = new SqlCommand("select * from Credentials", sqlConnection);
                sqlConnection.Open();
                using (var objDataReader = sqlCommand.ExecuteReader())
                {
                    while (objDataReader.Read())
                    {
                        lstDetails.Add(UserDetails.Fill((IDataRecord)objDataReader));
                    }
                }
                return Task.FromResult(lstDetails);
            }
        }
        public Task<List<ProductDetails>> GetAllProducts()
        {
            List<ProductDetails> lstDetails = new List<ProductDetails>();
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlCommand = new SqlCommand("select * from ProductDetails", sqlConnection);
                sqlConnection.Open();
                using (var objDataReader = sqlCommand.ExecuteReader())
                {
                    while (objDataReader.Read())
                    {
                        lstDetails.Add(ProductDetails.Fill((IDataRecord)objDataReader));
                    }
                }
                return Task.FromResult(lstDetails);
            }
        }
        public Task<bool> Add_Delete_Modify_Products(ProductDetails productDetails, int flag)
        {
            bool rowAffected = false;
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlCommand = new SqlCommand("ManageProducts", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@ProductDetails", SqlDbType.Structured).Value = CreateDataTable(productDetails);
                sqlCommand.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    rowAffected = true;
                }
            }
            return Task.FromResult(rowAffected);
        }

        public Task<bool> CheckUserExists(string userName, string password)
        {
            bool isUserExists = false ;
            bool isPasswordRequired = false;
            string command = string.Empty;
            using (sqlConnection = new SqlConnection(connection))
            {
                
                if (string.IsNullOrEmpty(password))
                {
                    command = "select * from Credentials where emailId=@email";
                }
                else
                {
                    isPasswordRequired = true;
                    command = "select * from Credentials where emailId=@email and password=@password";
                }
                sqlCommand = new SqlCommand(command, sqlConnection);
                if (isPasswordRequired)
                {
                    sqlCommand.Parameters.Add("@password", SqlDbType.Int).Value = password;
                }
                sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = userName;
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                isUserExists = dataReader.HasRows;
            }
            return Task.FromResult(isUserExists);
        }
        public Task<bool> SendLogData(LogMetadata logMetadata)
        {
            bool isDataPosted = false;
            string command = string.Empty;
            using (sqlConnection = new SqlConnection(connection))
            {
                command = "LogMetaDataProc";
                sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@LogDetails", SqlDbType.Structured).Value = CreateDataTable(logMetadata);
                sqlConnection.Open();
                if(sqlCommand.ExecuteNonQuery()>0)
                {
                    isDataPosted = true;
                }
            }
            return Task.FromResult(isDataPosted);
        }
        public Task<string> GetPassword(string userName)
        {
            string password = string.Empty;
            string command = string.Empty;
            using (sqlConnection = new SqlConnection(connection))
            {
                command = "select password from Credentials where emailId=@email";
                sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = userName;
                sqlConnection.Open();
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        password = dataReader["password"].ToString();
                    }
                }
            }
            return Task.FromResult(password);
        }

    }
}