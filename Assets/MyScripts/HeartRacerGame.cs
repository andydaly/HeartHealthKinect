using UnityEngine;
using System.Collections;

public class HeartRacerGame : MonoBehaviour {


	public GUIText HeartRacerText;
	//public GUITexture StopWatchImage;
	public GUIText TimerText;
	public GUIText RoundsText;
	public GUIText AdviceText;
	public float TimeLimit = 15.0f;
	public float CorrectRateLimit = 2.0f;
	public float BreakTimeLimit = 2.0f;
	public float TextChangeIntervals = 5.0f;


	private int RoundsUntilIncrease = 3;
	private KinectManager manager;
	private HeartRateEstimation heartrate;
	private int WorkoutLevel = 1;
	private int LimitRate1 = 0;
	private int LimitRate2 = 0;
	private int TargetRate1 = 0;
	private int TargetRate2 = 0;
	private int CurrentRound = 0;
	private int RoundsBarrier = 0;
	private bool RoundStarted = false;
	private bool TimerRun = false;
	private bool BreakSwitch = false;
	private float BreakTimer = 0.0f;
	private float Timer = 0.0f;
	private float CorrectTimer = 0.0f;
	private string[] HelpTexts = new string[10];
	private int Count = 0;
	private float ChangeTimer = 0.0f;
	private int ThresHoldCounter = 1;

	void Start () {
	
		manager = this.GetComponent<KinectManager> ();
		heartrate= this.GetComponent<HeartRateEstimation> ();
		TimerText.text = ""+0;
		HeartRacerText.text = "";
		RoundsText.text = "";
		StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if ((manager.IsUserCalibrated (manager.GetPrimaryUserID ()))) {
			if (RoundStarted) {
				
				StartRound ();
			}

			if (TimerRun)
			{
				if ((heartrate.GetCurrentHeartRate()>=TargetRate1) &&(heartrate.GetCurrentHeartRate()<=TargetRate2))
				{
					if (CorrectTimer > CorrectRateLimit)
					{
						RoundWin();
					}

					HeartRacerText.text = "Good! Keep Heart Rate between " + TargetRate1 + " and " + TargetRate2 +"!";

					CorrectTimer += Time.deltaTime;

				}
				else
				{
					HeartRacerText.text = "Get Heart Rate between " + TargetRate1 + " and " + TargetRate2;
				}



				if (Timer < 0.0f)
				{
					Timer = 0;
					GameLoss();
					
				}
				TimerText.text = ""+Timer.ToString("F2");
				Timer -= Time.deltaTime;

			}

			if (BreakSwitch)
			{
				
				if (BreakTimer > BreakTimeLimit)
				{
					RoundStarted = true;
					TimerRun = false;
					BreakSwitch = false;
					BreakTimer = 0.0f;
				}
				
				BreakTimer += Time.deltaTime;
			}



		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			StartGame ();
		}

		GameAdvice ();

	}


	void StartGame()
	{
		CurrentRound = 0;
		RoundStarted = true;
		TimerRun = false;
		BreakSwitch = false;
		RoundsBarrier = RoundsUntilIncrease;
	}

	void StartRound()
	{
		if (CurrentRound > RoundsBarrier) {
			if (WorkoutLevel < 3)
				WorkoutLevel++;
			RoundsBarrier += RoundsUntilIncrease;

		}




		if (CurrentRound < RoundsUntilIncrease) {
			LimitRate1 = heartrate.GetCurrentRestingHeartRate ()+7;
			//LimitRate2 = heartrate.GetTargetHeartRate (heartrate.GetCurrentMaxHeartRate(), 1, 1)-7;
			LimitRate2 = LimitRate1+27;
			Timer = TimeLimit+5;
		} 
		else {

			LimitRate1 = TargetRate2;
			LimitRate2 = heartrate.GetTargetHeartRate (heartrate.GetCurrentMaxHeartRate(),WorkoutLevel,ThresHoldCounter);
			Timer = TimeLimit;
		}

		//Debug.Log(""+LimitRate1 +"-"+LimitRate2 );

		TargetRate2 = Random.Range (LimitRate1, LimitRate2);
		TargetRate1 =  TargetRate2-5;


		HeartRacerText.text = "Get Heart Rate between " + TargetRate1 + " and " + TargetRate2;

		if (ThresHoldCounter == 3)
			ThresHoldCounter = 1;
		else {
			ThresHoldCounter++;
		}

		RoundStarted = false;
		TimerRun = true;
		BreakSwitch = false;

	}


	void RoundWin()
	{
		CurrentRound++;
		BreakTimer = 0.0f;
		CorrectTimer = 0.0f;
		HeartRacerText.text = "Excellent!";
		RoundsText.text = "Round: " + CurrentRound;
		
		RoundStarted = false;
		TimerRun = false;
		BreakSwitch = true;
	}
	
	void GameLoss()
	{
		HeartRacerText.text = "Time's Up!" + "\n\nPress Space (Spacebar) to restart"; 
		RoundStarted = false;
		TimerRun = false;
		BreakSwitch = false;
		
	}


	void GameAdvice()
	{
		
		HelpTexts[0] = "Press ESC to Exit";
		HelpTexts[1] = "Perform Squats or Jumping Jacks";
		HelpTexts[2] = "Press Space (Space Bar) to Restart";


		if (Count > 2) {
			Count = 0;
		}
		
		if (ChangeTimer > TextChangeIntervals) {
			ChangeTimer = 0.0f;
			Count++;
		}
		
		ChangeTimer += Time.deltaTime;
		AdviceText.text = HelpTexts[Count];
		
		
	}

}
