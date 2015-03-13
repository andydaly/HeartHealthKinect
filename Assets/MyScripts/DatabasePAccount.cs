using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Attributes;



    public class PatientLogin
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PUserName { get; set; }
        public string Password { get; set; }
		public bool IsConfirmed { get; set; }
	}



    public class DatabasePAccount
    {

        private readonly MongoHelper<PatientLogin> patientlogin;
        private string ConnectString;

        
        public DatabasePAccount()
        {
            patientlogin = new MongoHelper<PatientLogin>();
            
        }
        

        public DatabasePAccount(string connectionString)
        {
            ConnectString = connectionString;
            patientlogin = new MongoHelper<PatientLogin>(ConnectString);

        }


        public void CreateLogin(PatientLogin logins)
        {
            if (!CheckUserName(logins.PUserName))
            {
                patientlogin.Collection.Save(logins);
            }
            
        }

        public void CreateFullAccount(PatientLogin logins, PatientDetails details)
        {
            
            if ((!CheckUserName(logins.PUserName)) && (logins.PUserName.Equals(details.PUserName)))
            {
                
                patientlogin.Collection.Save(logins);
                DatabasePDetails savedetails = new DatabasePDetails(ConnectString);
                savedetails.Create(details);

            }
            else
            {
                //Error
            }
        }



        public void Delete(string username)
        {
            if (CheckUserName(username))
            {
                patientlogin.Collection.Remove(Query.EQ("PUserName", username));
            }
        }

        public void ChangePassword(string username, string password)
        {
            if (CheckUserName(username))
            {
                patientlogin.Collection.Update(
                    Query.EQ("PUserName", username),
                    Update.Set("Password", password));
            }

        }

        public void ChangePasswordByClass(PatientLogin logindetails)
        {
            if (CheckUserName(logindetails.PUserName))
            {
                patientlogin.Collection.Update(
                    Query.EQ("PUserName", logindetails.PUserName),
                    Update.Set("Password", logindetails.Password));
            }

        }



        private List<string> GetAllUsernames()
        {
            IList<PatientLogin> templist = patientlogin.Collection.FindAll().ToList();
            
            List<string> usernames = new List<string>();
            foreach (PatientLogin temp in templist)
            {
                usernames.Add(temp.PUserName);

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


        public bool CheckLogin(string username, string password)
        {
            if (CheckUserName(username))
            {
                var data = patientlogin.Collection.Find(Query.EQ("PUserName", username)).Single();

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


        public bool CheckLoginWthClass(PatientLogin loginattempt)
        {

            if (CheckUserName(loginattempt.PUserName))
            {
                var data = patientlogin.Collection.Find(Query.EQ("PUserName", loginattempt.PUserName)).Single();
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
        

        
	public bool CheckIfConfirmed(string username)
	{
		if (CheckUserName (username)) {
			var data = patientlogin.Collection.Find(Query.EQ("PUserName", username)).Single();
			return data.IsConfirmed;
		} 
		else 
		{

			
			return false;
		}
	}

	public void AccountConfirmed(string username)
	{
		if (CheckUserName (username)) {
			patientlogin.Collection.Update (Query.EQ ("PUserName", username), Update.Set ("IsConfirmed", true));
		} 
		else 
		{

		}
		
	}
	
}