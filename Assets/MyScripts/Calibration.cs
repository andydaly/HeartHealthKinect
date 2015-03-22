using UnityEngine;
using System.Collections;

public class Calibration : MonoBehaviour {

	public GUIText CalibrationText;

	private KinectManager manager;
	private float Timer = 0.0f;
	private bool SwitchText = true;

	void Start () {
	
		manager = Camera.main.GetComponent<KinectManager>();
		//CalibrationText.transform.position = new Vector3 (Screen.width, Screen.height, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (manager.IsUserCalibrated(manager.GetPrimaryUserID()))
		{
			CalibrationText.text = "";
		}
		else
		{

			if (Timer > 5.0f)
			{
				Timer = 0.0f;
				SwitchText = !SwitchText;
			}

			Timer += Time.deltaTime;



			if (SwitchText)
				CalibrationText.text = "Awaiting User Calibration";
			else
				CalibrationText.text = "Position whole body in view of kinect";

		}

	}
}
