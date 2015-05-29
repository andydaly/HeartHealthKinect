using UnityEngine;
using System.Collections;

public class HeartAnimate : MonoBehaviour {

	public Texture heart1;
	public Texture heart2;


	private bool Beep = false;
	private float timer = 0.0f;
	private float rate = 0.0f;
	private int currentrate = 0;


	void Update () {
		// gets current heart rate
		currentrate = Camera.main.GetComponent<HeartRateEstimation> ().GetCurrentHeartRate ();

		// to simulate heart beating, 60 is divided by current heart rate as heart rate measured in beats per minute
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
