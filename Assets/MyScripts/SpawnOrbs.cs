using UnityEngine;
using System.Collections;

public class SpawnOrbs : MonoBehaviour {

	//public Transform StartSpawn; // Starting Spawn point position
	public GUIText RoundsText;
	public GUIText Announcement;
	public GameObject SpawnPoint; // Spawnpoint object, empty game object
	public GameObject Orb1; // Orb 1 gameobject
	public GameObject Orb2; // Orb 2 gameobject
	public int NumX = 10; // Number of spawn points on x
	public int NumY = 10; // Number of spawn points on y

	public float TimeIntervals = 1.0f; // Time between orb spawn
	public int RoundsUntilDifficulty = 2;
	public float BreakTimeLimit = 3.0f;
	
	KinectManager manager;
	float TimeLimit = 0.0f;
	PowerMeter meter;
	GameObject[,] SpawnPoints = new GameObject[20,20];
	GameObject[] Orbs = new GameObject[100];



	Transform StartSpawn;
	int Count = 0;

	int Orb1Count = 0;
	int Orb2Count = 0;
	int Orb1Score = 0;
	int Orb2Score = 0;
	string ScoreString;
	int CurrentRound = 1;
	float BreakTimer = 0.0f;
	bool DestroyAll = true;
	
	public void OrbAdd()
	{
		if (CurrentRound>RoundsUntilDifficulty*4)
			meter.PowerUp (5);
		else if (CurrentRound>RoundsUntilDifficulty*3)
			meter.PowerUp (7);
		else if (CurrentRound>RoundsUntilDifficulty*2)
			meter.PowerUp (10);
		else if (CurrentRound>RoundsUntilDifficulty)
			meter.PowerUp (15);
		else
			meter.PowerUp (20);


		Orb1Score++;
	}
	
	public void OrbMinus()
	{
		if (CurrentRound>RoundsUntilDifficulty*4)
			meter.PowerDown(5);
		else if (CurrentRound>RoundsUntilDifficulty*3)
			meter.PowerDown (7);
		else if (CurrentRound>RoundsUntilDifficulty*2)
			meter.PowerDown (10);
		else if (CurrentRound>RoundsUntilDifficulty)
			meter.PowerDown (15);
		else
			meter.PowerDown (20);

		Orb2Score++;
	}
	
	
	public int GetOrb1()
	{
		return Orb1Score;
	}
	
	public int GetOrb2()
	{		
		return Orb2Score;
	}
	
	public int TotalOrb1()
	{
		return Orb1Count;
	}
	
	public int TotalOrb2()
	{
		return Orb2Count;
	}
	

	
	void Start () {
	
		Announcement.text = "";
		manager = Camera.main.GetComponent<KinectManager>();
		StartSpawn = SpawnPoint.transform;
		Vector3 pos = StartSpawn.position;
		float initx = pos.x;
		for (int j = 0; j < NumY; j++) {
			
			
			for (int i = 0; i < NumX; i++) {
				pos.x += (Orb1.transform.localScale.x/2);
				SpawnPoints[i,j] = (GameObject)Instantiate (SpawnPoint, pos, SpawnPoint.transform.rotation); 
			}
			pos.y += (Orb1.transform.localScale.y/2);
			pos.x = initx;
		}
		


		meter = this.GetComponent<PowerMeter> ();
		RoundsText.text = "Round: " + CurrentRound;
		
	}
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log ("Orbs collected: " + OrbsCollected);

		
		if (manager.IsUserCalibrated(manager.GetPrimaryUserID())) {
			

			
			if (!meter.PowerFull()) {
				if (TimeLimit > TimeIntervals) {
					
					int PointX = Random.Range (0, NumX);
					int PointY = Random.Range (0, NumY);
					
					if (Count >= 100) {
						Count = 0;
					}
					
					int num = Random.Range (1, 3);
					if (num == 1) {
						Orbs [Count] = (GameObject)Instantiate (Orb2, SpawnPoints [PointX, PointY].transform.localPosition, SpawnPoints [PointX, PointY].transform.rotation);
						Orb2Count++;
					} 
					else { 
						Orbs [Count] = (GameObject)Instantiate (Orb1, SpawnPoints [PointX, PointY].transform.localPosition, SpawnPoints [PointX, PointY].transform.rotation);
						Orb1Count++;
					}
					
					Count++;
					TimeLimit = 0;
				}
				TimeLimit += Time.deltaTime;
			}
			else {
				if (DestroyAll)
				{
					for (int i = 0; i < Count; i++)
					{
						Destroy(Orbs[i]);
					}
					DestroyAll = false;
				}
				if (BreakTimer > BreakTimeLimit)
				{

					CurrentRound++;
					RoundsText.text = "Round: " + CurrentRound;
					meter.Refresh();
					BreakTimer = 0;
					Announcement.text = "";
					DestroyAll = true;
				}
				else
				{
					Announcement.text = "Round Complete";
				}

				BreakTimer += Time.deltaTime;
			}
			

		}
	} 

}
