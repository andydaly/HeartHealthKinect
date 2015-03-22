using UnityEngine;
using System.Collections;

public class HeartAnimate : MonoBehaviour {

	public Texture heart1;
	public Texture heart2;


	private bool Beep = false;
	float timer = 0.0f;
	float rate = 0.0f;
	int currentrate = 0;
	// Use this for initialization
	void Start () {
		//rate = 56.0f/60.0f;
		//Debug.Log (rate);
	}
	
	// Update is called once per frame
	void Update () {

		 currentrate = Camera.main.GetComponent<HeartRateEstimation> ().GetCurrentHeartRate ();

		rate = 60.0f/currentrate;


		if (Beep)
			guiTexture.texture = heart1;
		else
			guiTexture.texture = heart2;


		timer += Time.deltaTime;

		if (timer >= rate) {
			Beep = true;
			timer = 0.0f;

		}
		if (timer >= 0.08f) {
			Beep = false;
		}
	}
}
