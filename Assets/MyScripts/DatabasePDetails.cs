using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Attributes;


    public class PatientWorkout
    {
        public int WorkoutNumber { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string WorkoutType { get; set; }
        public int HeartRate { get; set; }
        public int MaxHeartRate { get; set; }
        public string Comment { get; set; }
        public int SquatNum { get; set; }
        public int JumpNum { get; set; }
        public int WorkoutLength { get; set; } // seconds

    }


    public class PatientDiagnosis
    {
        public int DiagnosisNum { get; set; }
        public string Diagnosis { get; set; }
        public DateTime DiagnosisDate { get; set; }
       
    }

    public class PatientMessages
    {
        public int MessageNum { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
       
    }

    public class PatientDetails
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PUserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int FitnessLevel { get; set; }
        public string Condition { get; set; }
		public int WeightKG { get; set; }
		public bool IsMale { get; set; }
        public IList<PatientWorkout> Workouts { get; set; }
        public IList<PatientDiagnosis> Diagnosis { get; set; }
        public IList<PatientMessages> Messages { get; set; }
    }



    public class DatabasePDetails
    {
        private readonly MongoHelper<PatientDetails> patientdetails;

        private string ConnectString;

        
        public DatabasePDetails()
        {
            patientdetails = new MongoHelper<PatientDetails>();
        }
        

        public DatabasePDetails(string connectionString)
        {
            ConnectString = connectionString;
            patientdetails = new MongoHelper<PatientDetails>(ConnectString);
        }

	public void Create(PatientDetails details)
	{
		DatabasePAccount logininfo = new DatabasePAccount(ConnectString);
		
		// Only Create if account exists in Patient Accounts collection and not already in details
		if ((logininfo.CheckUserName(details.PUserName)) && (!CheckUserName(details.PUserName)))
		{
			details.Workouts = new List<PatientWorkout>();
			details.Diagnosis = new List<PatientDiagnosis>();
			details.Messages = new List<PatientMessages>();
			patientdetails.Collection.Save(details);
		}
		else
		{
			
		}
		
		
	}
	
	public void EditAllDetails(PatientDetails details)
	{
		if (CheckUserName(details.PUserName))
		{
			patientdetails.Collection.Update(
				Query.EQ("PUserName", details.PUserName),
				Update.Set("Name", details.Name)
				.Set("Email", details.Name)
				.Set("Address", details.Address)
				.Set("DateOfBirth", details.DateOfBirth)
				.Set("PhoneNumber", details.PhoneNumber)
				.Set("FitnessLevel", details.FitnessLevel)
				.Set("Condition", details.Condition)
				.Set("WeightKG", details.WeightKG)
				.Set("IsMale", details.IsMale));
		}
	}
	
	
	public PatientDetails GetPatient(string username)
	{
		if (CheckUserName(username))
		{
			var details = patientdetails.Collection.Find(Query.EQ("PUserName", username)).SetFields(Fields.Exclude("Workouts", "Diagnosis", "Messages")).Single();
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
			patientdetails.Collection.Remove(Query.EQ("PUserName", username));
		}
		
	}
	
	public IList<PatientDetails> GetAllDetails()
	{
		return patientdetails.Collection.FindAll().SetFields(Fields.Exclude("Workouts", "Diagnosis", "Messages")).SetSortOrder(SortBy.Descending("_id")).ToList();
		
	}
	
	
	
	
	public List<string> GetAllUsernames()
	{
		IList<PatientDetails> templist = GetAllDetails();
		List<string> usernames = new List<string>();
		foreach (PatientDetails temp in templist)
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
	
	
	public void AddWorkout(string username, PatientWorkout workout)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username), Update.PushWrapped("Workouts", workout));
			
		}
		
	}
	
	public IList<PatientWorkout> GetAllWorkouts(string username)
	{
		if (CheckUserName(username))
		{
			var details = patientdetails.Collection.Find(Query.EQ("PUserName", username)).SetFields(Fields.Exclude("PUserName", "Name", "Email", "Address", "DateOfBirth", "PhoneNumber", "FitnessLevel", "Condition", "WeightKG", "IsMale", "Diagnosis", "Messages")).Single();
			return details.Workouts.OrderBy(c => c.WorkoutNumber).ToList();
			
		}
		else
		{
			
			return null;
		}
		
	}
	
	
	public int GetNumberofWorkouts(string username)
	{
		if (CheckUserName(username))
		{
			IList<PatientWorkout> workouts = GetAllWorkouts(username);
			
			return workouts.Count();
		}
		else
		{
			
			return -1;
		}
		
		
	}
	
	
	public PatientWorkout GetWorkout(string username, int WorkoutNum)
	{
		if ((CheckUserName(username)) && (WorkoutNum <= GetNumberofWorkouts(username)) && (GetNumberofWorkouts(username) != -1))
		{
			IList<PatientWorkout> workoutlist = GetAllWorkouts(username);
			PatientWorkout workout = new PatientWorkout();
			foreach (PatientWorkout record in workoutlist)
			{
				if (record.WorkoutNumber == WorkoutNum)
				{
					workout = record;
					break;
				}
			}
			
			return workout;
		}
		else
		{
			
			return null;
		}
		
		
	}
	
	public void AddDiagnosis(string username, PatientDiagnosis diagnosis)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username), Update.PushWrapped("Diagnosis", diagnosis));
			
		}
		
	}
	
	public IList<PatientDiagnosis> GetAllDiagnosis(string username)
	{
		if (CheckUserName(username))
		{
			var details = patientdetails.Collection.Find(Query.EQ("PUserName", username)).SetFields(Fields.Exclude("PUserName", "Name", "Email", "Address", "DateOfBirth", "PhoneNumber", "FitnessLevel", "Condition", "WeightKG", "IsMale", "Workouts", "Messages")).Single();
			return details.Diagnosis.OrderBy(c => c.DiagnosisNum).ToList();
		}
		else
		{
			
			return null;
		}
		
	}
	
	
	public int GetNumberofDiagnosis(string username)
	{
		if (CheckUserName(username))
		{
			IList<PatientDiagnosis> diagnosislist = GetAllDiagnosis(username);
			
			return diagnosislist.Count();
		}
		else
		{
			
			return -1;
		}
		
		
	}
	
	
	public PatientDiagnosis GetDiagnosis(string username, int DiagnosisNum)
	{
		if ((CheckUserName(username)) && (DiagnosisNum <= GetNumberofDiagnosis(username)) && (GetNumberofDiagnosis(username) != -1))
		{
			IList<PatientDiagnosis> diagnosislist = GetAllDiagnosis(username);
			PatientDiagnosis diagnosis = new PatientDiagnosis();
			foreach (PatientDiagnosis record in diagnosislist)
			{
				if (record.DiagnosisNum == DiagnosisNum)
				{
					diagnosis = record;
					break;
				}
			}
			
			return diagnosis;
		}
		else
		{
			
			return null;
		}
		
		
	}
	
	public void AddMessage(string username, PatientMessages message)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username), Update.PushWrapped("Messages", message));
			
		}
		
	}
	
	public IList<PatientMessages> GetAllMessages(string username)
	{
		if (CheckUserName(username))
		{
			var details = patientdetails.Collection.Find(Query.EQ("PUserName", username)).SetFields(Fields.Exclude("PUserName", "Name", "Email", "Address", "DateOfBirth", "PhoneNumber", "FitnessLevel", "Condition", "WeightKG", "IsMale", "Workouts", "Diagnosis")).Single();
			return details.Messages.OrderBy(c => c.MessageNum).ToList();
		}
		else
		{
			
			return null;
		}
		
	}
	
	
	
	public int GetNumberofMessages(string username)
	{
		if (CheckUserName(username))
		{
			IList<PatientMessages> messagelist = GetAllMessages(username);
			
			return messagelist.Count();
		}
		else
		{
			
			return -1;
		}
		
		
	}
	
	
	public PatientMessages GetMessage(string username, int MessageNum)
	{
		if ((CheckUserName(username)) && (MessageNum <= GetNumberofMessages(username)) && (GetNumberofMessages(username) != -1))
		{
			IList<PatientMessages> messagelist = GetAllMessages(username);
			PatientMessages message = new PatientMessages();
			foreach (PatientMessages record in messagelist)
			{
				if (record.MessageNum == MessageNum)
				{
					message = record;
					break;
				}
			}
			
			return message;
		}
		else
		{
			
			return null;
		}
		
		
	}
	
	public void EditComment(string UserName, int WorkoutNum, string Comment)
	{
		
		
		if (CheckUserName(UserName))
		{
			var workouts = GetAllWorkouts(UserName);
			
			foreach (var workout in workouts)
			{
				if (workout.WorkoutNumber == WorkoutNum)
				{
					var query = Query.And(
						Query.EQ("PUserName", UserName),
						Query.EQ("Workouts.WorkoutNumber", WorkoutNum));
					
					
					patientdetails.Collection.Update(query, Update.Set("Workouts.$.Comment", Comment));
				}
			}
			
		}
		
	}
	
	public void EditName(string username, string name)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("Name", name));
		}
		
	}
	
	public void EditEmail(string username, string email)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("Email", email));
		}
		
	}
	
	
	public void EditAddress(string username, string address)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("Address", address));
		}
		
	}
	
	
	public void EditDateOfBirth(string username, DateTime dateOfBirth)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("DateOfBirth", dateOfBirth));
		}
		
	}
	
	
	public void EditPhoneNumber(string username, string phoneNumber)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("PhoneNumber", phoneNumber));
		}
		
	}
	
	public void EditFitnessLevel(string username, int fitnesslevel)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("FitnessLevel", fitnesslevel));
		}
		
	}
	
	public void EditCondition(string username, string condition)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("Condition", condition));
		}
		
	}
	
	public void EditWeightKG(string username, int weight)
	{
		if (CheckUserName(username))
		{
			patientdetails.Collection.Update(Query.EQ("PUserName", username),
			                                 Update.Set("WeightKG", weight));
		}
		
	}
	
	public int GetAge(string username)
	{
		if (CheckUserName(username))
		{
			var patient = GetPatient(username);
			DateTime now = DateTime.Now;
			int age = now.Year - patient.DateOfBirth.Year;
			if (now < patient.DateOfBirth.AddYears(age)) 
				age--;
			
			return age;
			
		}
		else
		{
			
			return -1;
		}
	}
	
	
}