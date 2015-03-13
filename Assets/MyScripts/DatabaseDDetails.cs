using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Attributes;


    public class DoctorDetails
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string DUserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Practice { get; set; }
        public string Bio { get; set; }
        public string PhoneNumber { get; set; }

    }


    public class DatabaseDDetails
    {
        private readonly MongoHelper<DoctorDetails> doctordetails;
        private string ConnectString;
        
        
        public DatabaseDDetails()
        {
            doctordetails = new MongoHelper<DoctorDetails>();
        }
        

        public DatabaseDDetails(string connectionString)
        {
            ConnectString = connectionString;
            doctordetails = new MongoHelper<DoctorDetails>(ConnectString);
        }



        public void Create(DoctorDetails details)
        {
            DatabaseDAccount logininfo = new DatabaseDAccount(ConnectString);
            
            // Only Create if account exists in Doctor Patient Accounts collection and not already in details
            if ((logininfo.CheckUserName(details.DUserName)) && (!CheckUserName(details.DUserName)))
            {
                doctordetails.Collection.Save(details);
            }
            else
            {

            }
        }

        public DoctorDetails GetDoctor(string username)
        {
            if (CheckUserName(username))
            {
                var details = doctordetails.Collection.Find(Query.EQ("DUserName", username)).Single();
                return details;
            }
            else
            {
                return null;
            }
        }


        public void Delete(string username)
        {
            if (CheckUserName(username))
            {
                doctordetails.Collection.Remove(Query.EQ("DUserName", username));
            }

        }

        public IList<DoctorDetails> GetAllDetails()
        {
            return doctordetails.Collection.FindAll().SetSortOrder(SortBy.Descending("_id")).ToList();
            
        }

        public List<string> GetAllUsernames()
        {
            IList<DoctorDetails> templist = GetAllDetails();
            List<string> usernames = new List<string>();
            foreach (DoctorDetails temp in templist)
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


        public void EditName(string username, string doctname)
        {
            if (CheckUserName(username))
            {
                doctordetails.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("Name", doctname));
            }

        }

       

        public void EditEmail(string username, string email)
        {
            if (CheckUserName(username))
            {
                doctordetails.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("Email", email));
            }

        }


        public void EditPosition(string username, string position)
        {
            if (CheckUserName(username))
            {
                doctordetails.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("Position", position));
            }

        }

        public void EditPractice(string username, string practice)
        {
            if (CheckUserName(username))
            {
                doctordetails.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("Practice", practice));
            }

        }

        public void EditBio(string username, string biograph)
        {
            if (CheckUserName(username))
            {
                doctordetails.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("Bio", biograph));
            }

        }

        public void EditPhoneNumber(string username, string phone)
        {
            if (CheckUserName(username))
            {
                doctordetails.Collection.Update(Query.EQ("DUserName", username),
                    Update.Set("PhoneNumber", phone));
            }

        }

    }

