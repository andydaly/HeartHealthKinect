using UnityEngine;
using System.Collections;

public class ExerciseAdvice : MonoBehaviour {

	public GUIText HelpText;
	public float TextChangeIntervals = 5.0f;
	public int WorkoutLevel = 1;

	string[] HelpTexts = new string[10];
	int Count = 0;
	float Timer = 0.0f;
	// Use this for initialization
	void Start () {



		if (HelpText != null) {
			HelpText.text = HelpTexts[0];

		}
	}
	
	// Update is called once per frame
	void Update () {
	
		HelpTexts[0] = "Press ESC to Exit";
		HelpTexts[1] = "Perform Squats or Jumping Jacks";
		HelpTexts[2] = "Try to accelerate your Heart Rate";

		HelpTexts[3] = "Press Space (Space Bar) to Change Current Workout Level";
		HelpTexts[4] = "Your Current Workout Level is " + WorkoutLevel;
		HelpTexts[5] = "Your Target Heart Rate is " + this.GetComponent<HeartRateEstimation> ().GetTargetHeartRate(this.GetComponent<HeartRateEstimation> ().GetCurrentMaxHeartRate(), WorkoutLevel, 1) + " - " + this.GetComponent<HeartRateEstimation> ().GetTargetHeartRate(this.GetComponent<HeartRateEstimation> ().GetCurrentMaxHeartRate(), WorkoutLevel, 3);

		if (Count > 5) {
			Count = 0;
		}

		if (Timer > TextChangeIntervals) {
			Timer = 0.0f;
			Count++;
		}

		Timer += Time.deltaTime;
		HelpText.text = HelpTexts[Count];


		if (WorkoutLevel > 3) {
			WorkoutLevel = 1;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			WorkoutLevel++;
			Count = 4;
			Timer = 0.0f;
		}



	}
}
