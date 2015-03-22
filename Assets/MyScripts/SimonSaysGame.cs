using UnityEngine;
using System.Collections;

public class SimonSaysGame : MonoBehaviour {

	public GUIText SimonSaysText;
	//public GUITexture StopWatchImage;
	public GUIText TimerText;
	public GUIText RoundsText;
	public GUIText AdviceText;
	public float TimeLimit = 5.0f;
	public float DifficultyDecrease = 0.50f;
	public float BreakTimeLimit = 2.0f;
	public int RoundsUntilDecrease = 3;
	public float TextChangeIntervals = 5.0f;

	private bool BreakSwitch = false;
	private int CurrentRound = 0;
	private float Timer = 0.0f;
	private float BreakTimer = 0.0f;
	private string[] Exercises = new string[7];
	private int SimonSaysNum = -1;
	private int PerformedNum = -1;

	private string[] HelpTexts = new string[10];
	private int Count = 0;
	private float ChangeTimer = 0.0f;

	private bool ExercisePerformed = false;
	private bool RoundStarted = false;
	private KinectManager manager;
	private bool TimerRun = false;
	private int DifficultyBarrier = 0;

	void Start () {

		Exercises [0] = "Do a Squat";
		Exercises [1] = "Do a Jumping Jack";
		Exercises [2] = "Wave (with both hands)";
		Exercises [3] = "Raise Your Left Hand";
		Exercises [4] = "Raise Your Right Hand";

		manager = this.GetComponent<KinectManager> ();


		StartGame ();


		TimerText.text = ""+TimeLimit.ToString("F2");
		SimonSaysText.text = "";
		RoundsText.text = "";


	}
	
	// Update is called once per frame
	void Update () {
		if ((manager.IsUserCalibrated(manager.GetPrimaryUserID())))
		{
			if (RoundStarted) {

				StartRound ();
			}


			if (TimerRun)
			{

				if (ExercisePerformed) {
					if (PerformedNum == SimonSaysNum)
					{
						RoundWin();
					}
					else
					{
						GameLoss(false);

					}
					ExercisePerformed = false;
					
				}


				if (Timer < 0.0f)
				{
					Timer = 0;
					GameLoss(true);

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

	int SimonSayExercise(int lastnumber)
	{
		int Number = Random.Range(0, 5);

		if (Number == lastnumber) {
			Number = SimonSayExercise(lastnumber);
		}
		return Number;

	}

	void StartGame()
	{
		CurrentRound = 0;
		RoundStarted = true;
		TimerRun = false;
		BreakSwitch = false;
		DifficultyBarrier = RoundsUntilDecrease;
	}

	void StartRound()
	{
		SimonSaysNum = SimonSayExercise(SimonSaysNum);
		SimonSaysText.text = "Simon Says " + Exercises[SimonSaysNum];
		Timer = TimeLimit;
		if (CurrentRound == DifficultyBarrier)
		{
			if (TimeLimit > 1.5f)
				TimeLimit -= DifficultyDecrease;
			DifficultyBarrier += RoundsUntilDecrease;
		}
		RoundStarted = false;
		TimerRun = true;
		BreakSwitch = false;
	}

	void RoundWin()
	{
		CurrentRound++;
		PerformedNum = -1;
		BreakTimer = 0.0f;
		SimonSaysText.text = "Correct!";
		RoundsText.text = "Round: " + CurrentRound;

		RoundStarted = false;
		TimerRun = false;
		BreakSwitch = true;
	}

	void GameLoss(bool OutOfTime)
	{
		if (OutOfTime) {
			SimonSaysText.text = "Time's Up!" + "\n\nPress Space (Spacebar) to restart";
		} 
		else {
			SimonSaysText.text = "Wrong, Simon did not say to\n" + Exercises [PerformedNum] + "\n\nPress Space (Spacebar) to restart";
		}
		RoundStarted = false;
		TimerRun = false;
		BreakSwitch = false;

	}
	
	void GameAdvice()
	{
		HelpTexts [0] = "Press ESC to Exit";
		HelpTexts[1] = "Press Space (Space Bar) to Restart";

		if (Count > 1) {
			Count = 0;
		}
		
		if (ChangeTimer > TextChangeIntervals) {
			ChangeTimer = 0.0f;
			Count++;
		}
		
		ChangeTimer += Time.deltaTime;
		AdviceText.text = HelpTexts[Count];
		
		
	}
	
	void ActionPerformed (int ExerciseNumber)
	{
		//TimerRun = false;
		if (TimerRun) {
			ExercisePerformed = true;
			PerformedNum = ExerciseNumber;
		}
	}





}
