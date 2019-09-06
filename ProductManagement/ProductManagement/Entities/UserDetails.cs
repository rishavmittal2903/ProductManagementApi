using System;
using System.Data;

namespace ProductManagement.Entities
{
    public class UserDetails
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailId { get; set; }
        public string mobileNumber { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
        public int userType { get; set; }

        public static UserDetails Fill(IDataRecord record)
        {
            UserDetails userDetail = new UserDetails()
            {
                firstName = record["firstName"].ToString(),
                lastName = record["lastName"].ToString(),
                emailId = record["emailId"].ToString(),
                mobileNumber = (record["mobileNumber"]).ToString(),
                gender = record["gender"].ToString(),
                password = record["password"].ToString(),
                userType = Convert.ToInt32(record["userType"])
            };

            return userDetail;
        }
        
    }
}