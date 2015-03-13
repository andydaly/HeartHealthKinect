using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DataManagement : MonoBehaviour {


	public GUIText UserText;
	public string Username = "JLynam"; 
	//DatabasePDetails pdetailsdata;
	//PatientDetails patietndet;

	bool pressed = false;
	// Use this for initialization
	void Start () {

		//pdetailsdata = new DatabasePDetails();


		//patietndet = pdetailsdata.GetPatient (Username);


		//UserText.guiText.text = patietndet.Name;




		//IList<PatientDetails> list1 = pdetailsdata.GetAllDetails();
		/*foreach (PatientDetails details in list1)
		{
			Debug.Log("User: " + details.PUserName + "\nName: " + details.Name + "\nAddress: " + details.Address);
			//Console.WriteLine("User: " + details.PUserName + "\nName: " + details.Name + "\nAddress: " + details.Address);
		}*/

		//DatabasePWorkout pworkoutdata = new DatabasePWorkout();
		//pworkoutdata.Create(Record3);
		/*IList<PatientWorkout> list2 = pworkoutdata.GetAllWorkouts();
		foreach(PatientWorkout workout in list2)
		{
			Debug.Log("User: " + workout.PUserName + "\nWorkout Date: " + workout.WorkoutDate);
			//Console.WriteLine("\nUser: " + workout.PUserName + "\nWorkout Date: " + workout.WorkoutDate);
		}*/
	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.GetKeyUp(KeyCode.Space)) {
		//	pressed = false;


		//if ((!pressed) && (Input.GetKey (KeyCode.Space))) {
		//if (Input.GetKey(KeyCode.Space)) {
		/*var Workout = new PatientWorkout
				{
					
					
					//PUserName = "JLynam",
					WorkoutNumber = pdetailsdata.GetNumberofWorkouts(Username)+1,
					WorkoutDate = DateTime.Now,
					WorkoutType = "Normal",
					HeartRate = 0,
					MaxHeartRate = 0,
					Comment = "",
					SquatNum = this.GetComponent<WorkoutListener>().Squats(),
					JumpNum = this.GetComponent<WorkoutListener>().JumpingJacks(),
					WorkoutLength = (int)this.GetComponent<WorkoutListener>().WorkoutTime()
					//SquatNum = 1,
					//JumpNum = 1,
					//WorkoutLength = 11
				};
				//pdetailsdata.AddWorkout(Username, Workout);
				Debug.Log ("should work");
				pressed = true;*/
			
		//}



		}

	}

