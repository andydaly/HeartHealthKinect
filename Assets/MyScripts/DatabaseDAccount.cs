using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Attributes;



    public class DoctorLogin
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string DUserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsConfirmed { get; set; }
        public string ConfirmationToken { get; set; }
        public DateTime LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public DateTime PasswordChangedDate { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime PasswordVerificationTokenExpirationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }




    public class DatabaseDAccount
    {

        private readonly MongoHelper<DoctorLogin> doctorlogin;
        private string ConnectString;

        
        public DatabaseDAccount()
        {
            doctorlogin = new MongoHelper<DoctorLogin>();

        }
        
        public DatabaseDAccount(string connectionString)
        {
            ConnectString = connectionString;
            doctorlogin = new MongoHelper<DoctorLogin>(connectionString);
        }


        public void CreateLogin(DoctorLogin logins)
        {
            
            if (!CheckUserName(logins.DUserName))
            {
                doctorlogin.Collection.Save(logins);
            }
        }

      
        public void CreateFullAccount(DoctorLogin logins, DoctorDetails details)
        {
            if ((!CheckUserName(logins.DUserName)) && (logins.DUserName.Equals(details.DUserName)))
            {

                doctorlogin.Collection.Save(logins);
                DatabaseDDetails savedetails = new DatabaseDDetails(ConnectString);
                savedetails.Create(details);

            }
            else
            {
                //Error
            }
        }



        public void Edit(DoctorLogin logindetails)
        {
            //broken
            if (CheckUserName(logindetails.DUserName))
            { 
            /*doctorlogin.Collection.Update(Query.EQ("DUserName", logindetails.DUserName),
                Update.Set("Password", logindetails.Password)
                .Set("IsConfirmed", logindetails.IsConfirmed)
                .Set("ConfirmationToken",logindetails.ConfirmationToken)
                .Set("LastPasswordFailureDate", logindetails.LastPasswordFailureDate)
                .Set("PasswordFailuresSinceLastSuccess", logindetails.PasswordFailuresSinceLastSuccess)
                .Set("PasswordChangedDate", logindetails.PasswordChangedDate)
                .Set("PasswordVerificationToken", logindetails.PasswordVerificationToken)
                .Set("PasswordVerificationTokenExpirationDate", logindetails.PasswordVerificationTokenExpirationDate)
                .Set("LastLoginDate", logindetails.LastLoginDate));*/
                doctorlogin.Collection.Save(logindetails);
                    //Update(Query.EQ("DUserName", logindetails.DUserName),
            }
           
        }


        public void Delete(string username)
        {
            if (CheckUserName(username))
            {
                doctorlogin.Collection.Remove(Query.EQ("DUserName", username));
            }
        }


        public void EditPasswordVerificationTokenExpirationDate(string username, DateTime newdate)
        {
            if (CheckUserName(username))
            {
                doctorlogin.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("PasswordVerificationTokenExpirationDate", newdate));
            }

        }


        public void EditLastLoginDate(string username, DateTime newdate)
        {
            if (CheckUserName(username))
            {
                doctorlogin.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("LastLoginDate", newdate));
            }

        }



        public void EditLastPasswordFailureDate(string username, DateTime newdate)
        {
            if (CheckUserName(username))
            {
                doctorlogin.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("LastPasswordFailureDate", newdate));
            }

        }

        public void EditPasswordFailuresSinceLastSuccess(string username, int failurenum)
        {
            if (CheckUserName(username))
            {
                doctorlogin.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("PasswordFailuresSinceLastSuccess", failurenum));
            }

        }





        public void ChangePassword(string username, string password)
        {
            if (CheckUserName(username))
            {
                doctorlogin.Collection.Update(
                    Query.EQ("DUserName", username),
                    Update.Set("Password", password));
            }

        }

        public void ChangePasswordByClass(DoctorLogin logindetails)
        {
            if (CheckUserName(logindetails.DUserName))
            {
                doctorlogin.Collection.Update(
                    Query.EQ("DUserName", logindetails.DUserName),
                    Update.Set("Password", logindetails.Password));
            }

        }


        private List<string> GetAllUsernames()
        {
            IList<DoctorLogin> templist = doctorlogin.Collection.FindAll().ToList();

            List<string> usernames = new List<string>();
            foreach (DoctorLogin temp in templist)
            {
                usernames.Add(temp.DUserName);

            }
            return usernames;
        }


        public bool CheckUserName(string username)
        {
            List<string> userlist = GetAllUsernames();
            if (userlist.Contains(username))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public DoctorLogin GetLogin(string username)
        {
            if (CheckUserName(username))
            {
                var details = doctorlogin.Collection.Find(Query.EQ("DUserName", username)).Single();
                return details;
            }
            else
            {
                return null;
            }
        }

        public bool CheckLogin(string username, string password)
        {
            if (CheckUserName(username))
            {
                var data = doctorlogin.Collection.Find(Query.EQ("DUserName", username)).Single();

                if (data.Password.Equals(password))
                {
                    return true;
                }
                else
                {
                    //Incorrect Password
                    return false;
                }
            }
            else
            {
                // No UserName
                return false;
            }
        }


        public bool CheckLoginWthClass(DoctorLogin loginattempt)
        {

            if (CheckUserName(loginattempt.DUserName))
            {
                var data = doctorlogin.Collection.Find(Query.EQ("DUserName", loginattempt.DUserName)).Single();
                if (data.Password.Equals(loginattempt.Password))
                {
                    return true;
                }
                else
                {
                    //Incorrect Password
                    return false;
                }
            }
            else
            {
                // No UserName
                return false;
            }
        }
    }


