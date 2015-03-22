using UnityEngine;
using System;
using System.Collections;

public class GameExit : MonoBehaviour {

	public bool CaptureData = false;

	bool WorkoutStarted = false;
	KinectManager manager;
	DatabasePDetails detailsdata;


	void Start () {
		manager = Camera.main.GetComponent<KinectManager>();
		detailsdata = new DatabasePDetails ();
	}
	

	void Update () {

		if (manager.IsUserCalibrated(manager.GetPrimaryUserID()))
		{
			WorkoutStarted = true;
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			if ((CaptureData) && (WorkoutStarted))
			{
				PatientWorkout workout = new PatientWorkout
				{
					WorkoutNumber = detailsdata.GetNumberofWorkouts(PlayerPrefs.GetString("CurrentUser"))+1,
					WorkoutDate = DateTime.Now,
					WorkoutType = PlayerPrefs.GetString("GameMode"),
					HeartRate = this.GetComponent<HeartRateEstimation>().GetAverageHeartRate(),
					MaxHeartRate = this.GetComponent<HeartRateEstimation>().GetCurrentMaxHeartRate(),
					Comment = "",
					SquatNum = this.GetComponent<WorkoutListener>().Squats(),
					JumpNum = this.GetComponent<WorkoutListener>().Jumps(),
					WorkoutLength = (int)this.GetComponent<WorkoutListener>().WorkoutTime()

				};

				detailsdata.AddWorkout(PlayerPrefs.GetString("CurrentUser"), workout);
			}

			PlayerPrefs.DeleteKey("GameMode");
			Destroy (Camera.main.gameObject);
			Destroy(this);
			Application.LoadLevel("MenuScene");
		}
	}
}
