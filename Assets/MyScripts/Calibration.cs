using UnityEngine;
using System.Collections;

public class Calibration : MonoBehaviour {

	//Calibration used to display if user has been detected
	// this script must be attached to the main camera

	// Requires GUIText to display Calibration string
	public GUIText CalibrationText;

	// KinectManager required to detect if user is calibrated
	private KinectManager manager;
	// Timer used to swap text to provide more information
	private float Timer = 0.0f;
	// bool used for swaping different texts
	private bool SwitchText = true;

	void Start () {

		manager = Camera.main.GetComponent<KinectManager>();
	}
	

	void Update () {
	
		// Has primary user been calibrated (detected yet)?
		if (manager.IsUserCalibrated(manager.GetPrimaryUserID()))
		{
			// if so, there is no need to display any string for calibration text
			CalibrationText.text = "";
		}
		else
		{

			// Timer swaps text every 5 seconds
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
