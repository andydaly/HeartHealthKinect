using UnityEngine;
using System.Collections;


public class EntriesDisplay : MonoBehaviour {
		
	// Entries display is used to display currently selected workout details


	// get guitext to display current observed workout details
	public GUIText TextDisplay;

	// get EntryBlock perfab to be used as a basis for displaying each workout
	public GameObject EntryBlock;

	// get its text which is a perfab for labeling each block
	public GUIText EntryText;
		
	private DatabasePDetails detailsDatabase;

	// Count is used to dispplay the number of workout entries
	private int Count = 0;

	// this is the current entry selected
	private int CurrentEntry = 0;

	// array of all the enties
	private GameObject[] cubeEntries;

	// array of all the guitext entries
	private GUIText[] textEntries;

		
	// these are for screen postions to scroll through entries
	private Vector3 FirstCubePos;
	private Vector3 LastCubePos;




	void Start () {
		// sets up an array of 50, this is to be altered as the workout array can most definately exceed this
		cubeEntries = new GameObject[50];
		textEntries = new GUIText[50];
			
		detailsDatabase = new DatabasePDetails ();

		//gets all workouts performed by current user logged in
		var workouts = detailsDatabase.GetAllWorkouts (PlayerPrefs.GetString ("CurrentUser"));

		Vector3 cubepos = EntryBlock.transform.localPosition;
		Vector3 textpos = EntryText.transform.localPosition;
		
		Count = workouts.Count;
		if (Count > 0) {
			
			int i = 1;
			// an entrie is created for wach workout
			foreach (PatientWorkout workout in workouts) {
				
				cubeEntries [i] = (GameObject)Instantiate (EntryBlock, cubepos, EntryBlock.transform.rotation);
				textEntries [i] = (GUIText)Instantiate (EntryText, textpos, EntryText.transform.rotation);
				cubeEntries[i].GetComponent<EntryDetails>().CubeNumber = i;
				cubepos.y -= (EntryBlock.transform.localScale.y * 1.25f);
				textEntries [i].guiText.text = "Entry: " + workout.WorkoutNumber + "\n" + workout.WorkoutDate;
				textEntries [i].GetComponent<ObjectLabel> ().target = cubeEntries [i].transform;
				i++;
			}
			
			cubeEntries [Count].renderer.material.color = Color.gray;
			
			if (Count > 3) {
				FirstCubePos = cubeEntries [1].transform.position;
				LastCubePos = cubeEntries [3].transform.position;
			}
		}
	}
		
		
	void Update () {
		if (Count > 3) {
			if (Input.mousePosition.y < 15) {
				
				if (cubeEntries[Count].transform.position.y < LastCubePos.y)
				{
					for (int i = 1; i <= Count; i++) {
						
						cubeEntries[i].transform.position += transform.up*Time.deltaTime* 5.0f;
					}
					
					
					
				}
				
				
			}
			if (Input.mousePosition.y > Screen.height - 15) {
				if (cubeEntries[1].transform.position.y > FirstCubePos.y)
				{
					for (int i = 1; i <= Count; i++) {
						
						cubeEntries[i].transform.position -= transform.up*Time.deltaTime * 5.0f;
					}
					
					
				}
			}
		}
	}
		
		
		
		
	void Refresh()
	{
		DetailsDisplay (CurrentEntry);
	}
		
		
	void DetailsDisplay(int Entry)
	{
		CurrentEntry = Entry;

		var workout = detailsDatabase.GetWorkout (PlayerPrefs.GetString("CurrentUser"), Entry);


		string TextToDisplay;
		// if doctor has written a comment
		if (workout.Comment.Length > 0)
		{
			// if string too large split it
			if (workout.Comment.Length> 35)
			{
				string Comment1 = workout.Comment.Substring(0,35);
				string Comment2 = workout.Comment.Substring(35);
				TextToDisplay = "Entry: " + workout.WorkoutNumber + "\n" + workout.WorkoutDate +  "\n" + workout.WorkoutType  + "\nWorkout Length: " + workout.WorkoutLength + "\nSquats: " + workout.SquatNum
					+ " (Seconds)" + "\nJumping Jacks: " + workout.JumpNum + "\nAverage Heart Rate: " + workout.HeartRate + "\nMax Heart Rate: " + workout.MaxHeartRate + "\n" + Comment1 + "\n" + Comment2;
			}
			else
				TextToDisplay = "Entry: " + workout.WorkoutNumber + "\n" + workout.WorkoutDate +  "\n" + workout.WorkoutType  + "\nWorkout Length: " + workout.WorkoutLength + "\nSquats: " + workout.SquatNum
					+ " (Seconds)" + "\nJumping Jacks: " + workout.JumpNum + "\nAverage Heart Rate: " + workout.HeartRate + "\nMax Heart Rate: " + workout.MaxHeartRate + "\nMedical Comment:\n" + workout.Comment;
		}
		else
		{
			TextToDisplay = "Entry: " + workout.WorkoutNumber + "\n" + workout.WorkoutDate +  "\n" + workout.WorkoutType  + "\nWorkout Length: " + workout.WorkoutLength + "\nSquats: " + workout.SquatNum
				+ " (Seconds)" + "\nJumping Jacks: " + workout.JumpNum + "\nAverage Heart Rate: " + workout.HeartRate + "\nMax Heart Rate: " + workout.MaxHeartRate;
		}
		TextDisplay.text = TextToDisplay;
	}
}