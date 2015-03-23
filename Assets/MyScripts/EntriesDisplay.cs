using UnityEngine;
using System.Collections;


public class EntriesDisplay : MonoBehaviour {
		
		
	//public GameObject CubeDisplay;
	public GUIText TextDisplay;
		
	public GameObject EntryBlock;
	public GUIText EntryText;
		
	private DatabasePDetails detailsDatabase;
		
	private int Count = 0;
		//int point = 0;
	private int CurrentEntry = 0;
	private GameObject[] cubeEntries;
	private GUIText[] textEntries;
	private GUIText Details;
		
		
		
		
	Vector3 FirstCubePos;
	Vector3 LastCubePos;



		// Use this for initialization
	void Start () {
		cubeEntries = new GameObject[50];
		textEntries = new GUIText[50];
			
		detailsDatabase = new DatabasePDetails ();
		
		var workouts = detailsDatabase.GetAllWorkouts (PlayerPrefs.GetString ("CurrentUser"));

		Vector3 cubepos = EntryBlock.transform.localPosition;
		Vector3 textpos = EntryText.transform.localPosition;
		
		Count = workouts.Count;
		if (Count > 0) {
			
			int i = 1;
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
		
		// Update is called once per frame
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
		if (workout.Comment != "")
		{
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