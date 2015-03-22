using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartRateEstimation : MonoBehaviour {


	// resting heart rate
	// max heart rate
	// calculate heart rate based on age, weight
	// different exercises performed excelerate heart rate (workout listener)
	// apply pulse to beating hair rate

	public GUIText HeartrateText;
	public float TimeIntervalsForAverage = 5.0f;
	//public GUIText TargetRateText;
	//public int WorkoutLevel = 1;



	private DatabasePDetails detailsData;
	private float HeartRate = 0;
	private int CurMaxHeartRate = 0;
	private int MaxHeartRate1 = 0;
	private int MaxHeartRate2 = 0;
	private int TargetRate1Low = 0;
	private int TargetRate1High = 0;
	private int TargetRate2Low = 0;
	private int TargetRate2High = 0;
	private int TargetRate3Low = 0;
	private int TargetRate3High = 0;
	private int RestHeartRate = 0;
	private List<int> HeartRates = new List<int> ();
	private KinectManager manager;


	private float Counter = 0.0f;
	private bool CoolDown = false;
	private float CoolDownTimer = 0.0f;
	private float CoolingTimer = 0.0f;
	//private float LastActionTimer = 0.0f;
	private bool StartingWorkout = false;
	private int ActionsPerformedOrder = 0;
	private float TimeSinceLastAction = 0.0f;

	// Use this for initialization
	void Start () {
		manager = Camera.main.GetComponent<KinectManager>();
		detailsData = new DatabasePDetails ();

		var data = detailsData.GetPatient(PlayerPrefs.GetString("CurrentUser"));

		//Debug.Log("Max Heart Rate: " + GetMaximumHeartRate(25, 1) + " Resting Heart Rate: "+ GetRestingHeartRate(30, 1) + "  Heart Rate: "+GetTargetHeartRate(GetMaximumHeartRate(25, 1), 2, 1)+ " - " + GetTargetHeartRate(GetMaximumHeartRate(25, 1), 2, 3));

		//Debug.Log ("rate: " + GetMaxHeartRateHeil (22, 63));
		/*int Age = 20;
		int weight = 60;
		for (int i = 0; i <35; i++) {


			Debug.Log ("Age: " + Age + " weight: " + weight + "kg Max rate: " + GetMaximumHeartRate (Age, 3)+ " Max heil rate: " + GetMaxHeartRateHeil (Age, 63));
			Age +=3;
			weight +=2;
		}*/

		HeartRate = GetRestingHeartRate (detailsData.GetAge (PlayerPrefs.GetString ("CurrentUser")), data.FitnessLevel);
		MaxHeartRate1 = GetMaximumHeartRate (detailsData.GetAge (PlayerPrefs.GetString ("CurrentUser")), data.FitnessLevel, data.IsMale);
		MaxHeartRate2 = GetMaxHeartRateHeil (detailsData.GetAge (PlayerPrefs.GetString ("CurrentUser")), data.WeightKG, data.IsMale);
		CurMaxHeartRate = (MaxHeartRate1 + MaxHeartRate2) / 2;

		TargetRate1Low = GetTargetHeartRate (CurMaxHeartRate, 1, 1);
		TargetRate1High = GetTargetHeartRate (CurMaxHeartRate, 1, 3);
		TargetRate2Low = GetTargetHeartRate (CurMaxHeartRate, 2, 1);
		TargetRate2High = GetTargetHeartRate (CurMaxHeartRate, 2, 3);
		TargetRate3Low = GetTargetHeartRate (CurMaxHeartRate, 3, 1);
		TargetRate3High = GetTargetHeartRate (CurMaxHeartRate, 3, 3);


		RestHeartRate = GetRestingHeartRate (detailsData.GetAge (PlayerPrefs.GetString ("CurrentUser")), data.FitnessLevel);


		Counter += TimeIntervalsForAverage;
		HeartRates.Add ((int)HeartRate);

		//TargetRateText.text = "Reach between " + TargetRate1 + " - " + TargetRate2;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (HeartRate <= RestHeartRate)
			HeartRate = RestHeartRate;

		if (HeartRate > CurMaxHeartRate)
			HeartRate = CurMaxHeartRate;

		//HeartRate
		HeartrateText.text = ""+(int)HeartRate;


		if (CoolDown) {
			if (CoolingTimer > 1.0f)
			{
				HeartRate -=  0.5f;
				CoolingTimer =0.0f;
			}
			CoolingTimer += Time.deltaTime;
						
			if (HeartRate <= RestHeartRate) {
				CoolDown = false;

			}
		} 

		if (CoolDownTimer >= 2.0f) {
						CoolDown = true;
						CoolDownTimer = 2.0f;
				}

		CoolDownTimer+=Time.deltaTime;


		if (ActionsPerformedOrder >= 5)
			StartingWorkout = false;

		if (TimeSinceLastAction >= 2.5f)
			ActionsPerformedOrder = 0;

		TimeSinceLastAction +=Time.deltaTime;

		if (manager.IsUserCalibrated (manager.GetPrimaryUserID ())) {
		
			if (this.GetComponent<WorkoutListener>().WorkoutTime() > Counter)
			{
				Counter = this.GetComponent<WorkoutListener>().WorkoutTime() + TimeIntervalsForAverage;
				HeartRates.Add ((int)HeartRate);

			}

		}
		Debug.Log ("Cooling: " + CoolDown + " Time since last action: " + TimeSinceLastAction);

	}


	public int GetCurrentHeartRate()
	{
		return (int)HeartRate;
	}

	public int GetCurrentMaxHeartRate()
	{
		return CurMaxHeartRate;
	}

	public int GetCurrentRestingHeartRate()
	{
		return RestHeartRate;
	}


	public int GetAverageHeartRate()
	{
		int temp = 0;
		foreach (int HeartRate in HeartRates)
		{
			temp += HeartRate;
		}

	
		return temp / HeartRates.Count;
	}

	private int GetMaximumHeartRate (int Age, int FitnessLevel, bool IsMale) { //function for the maximum heart rate

		//http://www.stevenscreek.com/goodies/hr.shtml
		//Fitnesslevel 1 (fit), 2 (Average), 3 (Poor)

		int MaxHeartRate = 0;
		if (IsMale) {
			if (FitnessLevel == 1) {
				MaxHeartRate = 205 - Age / 2;
			} else if (FitnessLevel == 2) {
				MaxHeartRate = 220 - Age;		
			} else if (FitnessLevel == 3) {
				float num = 0.8f * Age;	
				MaxHeartRate = 214 - (int)num;
			}	
				} else {
			if (FitnessLevel == 1) {
				MaxHeartRate = 211 - Age / 2;
			} else if (FitnessLevel == 2) {
				MaxHeartRate = 226 - Age;		
			} else if (FitnessLevel == 3) {
				float num = 0.7f * Age;	
				MaxHeartRate = 209 - (int)num;
			}
				}


		return MaxHeartRate;
	}
		

	private int GetMaxHeartRateHeil (int Age, int WeightKG, bool IsMale) { // function for the target heart rater
		
		float Lbs = 0.0f;
		float TargetRate = 0.0f;

		if (IsMale) {
			Lbs = ConverKgToLb ((int)WeightKG);
			TargetRate = 211.415f - (0.5f * Age) - (0.05f * Lbs) + 4.5f;
		} 
		else {
			Lbs = ConverKgToLb ((int)WeightKG);
			TargetRate = 211.415f - (0.5f * Age) - (0.05f * Lbs);
		}
		return (int)TargetRate;
	}

	public int GetTargetHeartRate (int MaxHeartRate, int WorkoutLevel, int Threshold) { // function for the target heart rater
		
		// Zones can be numbers 1, 2 or 3 
		// Zones are dependant on Health (1), Fitness (2) or Performance (3)
		// Threshold can be numbers 1, 2 or 3
		// Threshold are bottom, middle or top thresholds

		if (WorkoutLevel < 1)
			WorkoutLevel = 1;
		else if (WorkoutLevel > 3)
			WorkoutLevel = 3;

		if (Threshold<1)
			Threshold = 1;
		else if (Threshold >3)
			Threshold = 3;

		float TargetRate = 0;


		if (WorkoutLevel == 1) {
			if (Threshold == 1)
				TargetRate = 0.5f * MaxHeartRate;
			else if (Threshold == 2)
				TargetRate = 0.575f * MaxHeartRate;
			else if (Threshold == 3)
				TargetRate = 0.65f * MaxHeartRate;
		}
		else if (WorkoutLevel == 2) {
			if (Threshold == 1)
				TargetRate = 0.65f * MaxHeartRate;
			else if (Threshold == 2)
				TargetRate = 0.725f * MaxHeartRate;
			else if (Threshold == 3)
				TargetRate = 0.80f * MaxHeartRate;
		}
		else if (WorkoutLevel == 3) {
			if (Threshold == 1)
				TargetRate = 0.80f * MaxHeartRate;
			else if (Threshold == 2)
				TargetRate = 0.875f * MaxHeartRate;
			else if (Threshold == 3)
				TargetRate = 0.95f * MaxHeartRate;
		}


			
		return (int)TargetRate;
	}





	private int GetRestingHeartRate (int Age, int FitnessLevel)
	{
		int RestingHeartRate = 0;
		// FitnessLevels 1 (Athelete/Excellent) 2 (average) 3 (Poor)

		// Average
		if (FitnessLevel == 1)
			RestingHeartRate += 52;
		else if (FitnessLevel == 2)
			RestingHeartRate += 61;
		else if (FitnessLevel == 3)
			RestingHeartRate += 74;

		if (Age < 25)
			RestingHeartRate += 4;
		else if ((Age > 25)&&(Age <= 35))
			RestingHeartRate += 5;
		else if ((Age > 35)&&(Age <= 45))
			RestingHeartRate += 5;
		else if ((Age > 45)&&(Age <= 55))
			RestingHeartRate += 7;
		else if ((Age > 55)&&(Age <= 65))
			RestingHeartRate += 6;
		else if (Age > 65)
			RestingHeartRate += 7;

		return RestingHeartRate;
	}

	void SquatPerformed()
	{
		//if last performed a seconds or two ago
		if (HeartRate <= RestHeartRate)
			StartingWorkout = true;

		if (StartingWorkout)
			HeartRate += 1.95f;
		else {

			if (HeartRate >= GetTargetHeartRate(GetCurrentMaxHeartRate(), 1, 3))
			{
				HeartRate += 0.89f;
			}
			else
			{

				if (TimeSinceLastAction <= 2.0f)
				{

					HeartRate+=3.8f;
				}
				else
				{
					HeartRate += 2.1f;
				}
			}
		}



		CoolDown = false;
		CoolDownTimer = 0.0f;
		ActionsPerformedOrder++;
		TimeSinceLastAction = 0.0f;
	}

	void JumpPerformed()
	{
		if (HeartRate <= RestHeartRate)
			StartingWorkout = true;


		if (StartingWorkout)
			HeartRate += 2.1f;
		else {

			if (HeartRate >= GetTargetHeartRate(GetCurrentMaxHeartRate(), 1, 3))
			{
				HeartRate += 0.95f;
			}
			else
			{

				if (TimeSinceLastAction <= 2.0f)
				{
					HeartRate+=4.5f;
				}
				else
				{
					HeartRate += 2.4f;
				}
			}
		}



		CoolDown = false;
		CoolDownTimer = 0.0f;
		ActionsPerformedOrder++;
		TimeSinceLastAction = 0.0f;
	}

	private static float ConverKgToLb(float kg)
	{
		return (kg * 2.20462262f);
	}
}
