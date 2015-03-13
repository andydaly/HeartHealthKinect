using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Attributes;

    public class DToPAllocation
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PUserName { get; set; }
        public string DUserName { get; set; }
        public DateTime DateAllocated { get; set; }
        

    }

    public class DatabaseDtoP
    {
        private readonly MongoHelper<DToPAllocation> dtopallocation;
        private DatabasePAccount PAccount;
        private DatabaseDAccount DAccount;
        private string ConnectString;
        
        
        public DatabaseDtoP()
        {
            dtopallocation = new MongoHelper<DToPAllocation>();
            PAccount = new DatabasePAccount();
            DAccount = new DatabaseDAccount();
        }
        
        public DatabaseDtoP(string connectionString)
        {
            ConnectString = connectionString;
            dtopallocation = new MongoHelper<DToPAllocation>(ConnectString);
            PAccount = new DatabasePAccount(ConnectString);
            DAccount = new DatabaseDAccount(ConnectString);
        }

        public void CreateByStrings(string pusername, string dusername)
        {
            if ((PAccount.CheckUserName(pusername))&&(DAccount.CheckUserName(dusername)))
            { 
            
                var record = new DToPAllocation
                {
                    PUserName = pusername,
                    DUserName = dusername,
                    DateAllocated = DateTime.Now
                };


                dtopallocation.Collection.Save(record);
            }

        }

        public void CreateByClass(DToPAllocation allocdetails)
        {
            if ((PAccount.CheckUserName(allocdetails.PUserName)) && (DAccount.CheckUserName(allocdetails.DUserName)))
            {
                dtopallocation.Collection.Save(allocdetails);
            }

        }

        public IList<DToPAllocation> GetAllAllocations()
        {
            return dtopallocation.Collection.FindAll().SetSortOrder(SortBy.Descending("DateAllocated")).ToList();

        }

        public DToPAllocation GetAllocationByPatient(string username)
        {
            if (CheckPUserName(username))
            {
                var alloc = dtopallocation.Collection.Find(Query.EQ("PUserName", username)).Single();

                return alloc;
            }
            else
            {

                return null;
            }


        }

        public IList<DToPAllocation> GetAllocationByDoctor(string username)
        {
            if (CheckDUserName(username))
            {
                var alloc = dtopallocation.Collection.Find(Query.EQ("DUserName", username)).SetSortOrder(SortBy.Descending("DateAllocated")).ToList();

                return alloc;
            }
            else
            {

                return null;
            }
            
        }

        public string GetDUserNameByPatient(string username)
        {
            if (CheckPUserName(username))
            {
                var alloc = dtopallocation.Collection.Find(Query.EQ("PUserName", username)).Single();
                return alloc.DUserName;
            }
            else
            {
                return "";
            }
        }

        public string GetPUserNameByDoctor(string username)
        {
            if (CheckDUserName(username))
            {
                var alloc = dtopallocation.Collection.Find(Query.EQ("DUserName", username)).Single();
                return alloc.PUserName;
            }
            else
            {
                return "";
            }
        }



        private List<string> GetAllPUsernames()
        {
            IList<DToPAllocation> templist = GetAllAllocations();

            List<string> usernames = new List<string>();
            foreach (DToPAllocation temp in templist)
            {
                usernames.Add(temp.PUserName);

            }
            return usernames;
        }

        private List<string> GetAllDUsernames()
        {
            IList<DToPAllocation> templist = GetAllAllocations();

            List<string> usernames = new List<string>();
            foreach (DToPAllocation temp in templist)
            {
                usernames.Add(temp.DUserName);

            }
            return usernames;
        }

        public bool CheckPUserName(string username)
        {
            List<string> userlist = GetAllPUsernames();
            if (userlist.Contains(username))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool CheckDUserName(string username)
        {

            List<string> userlist = GetAllDUsernames();
            if (userlist.Contains(username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

