using UnityEngine;
using System.Collections;

public class WorkoutListener : MonoBehaviour, KinectGestures.GestureListenerInterface {




	public GUIText WorkOutText;


	private int SquatNum = 0;
	private int JumpNum = 0;
	private float workouttime = 0.0f;
	private bool WorkoutStarted = false;

	KinectManager manager;

	void Start () {
		manager = Camera.main.GetComponent<KinectManager>();
			
	}
	



	public void UserDetected(long userId, int userIndex)
	{
		// detect these user specific gestures
		manager.DetectGesture(userId, KinectGestures.Gestures.Squat);
		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);



	}
	
	public void UserLost(long userId, int userIndex)
	{

	}
	
	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{
		// don't do anything here
	}
	
	public bool GestureCompleted (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint, Vector3 screenPos)
	{


		// squat gesture is detected
		if (gesture == KinectGestures.Gestures.Squat) {
			SquatNum++;
			Camera.main.transform.SendMessage ("SquatPerformed");
		} 
		// jump or jumping jack gesture is detected
		else if (gesture == KinectGestures.Gestures.Jump) {
			JumpNum++;
			Camera.main.transform.SendMessage ("JumpPerformed");
		}
		
		
		return true;
	}
	
	public bool GestureCancelled (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint)
	{
		// don't do anything here, just reset the gesture state
		return true;
	}



	void Update () {

		if (WorkOutText != null)
			WorkOutText.guiText.text = "Squats: " + SquatNum + "\n" + "Jumping Jacks: " + JumpNum;

		if (WorkoutStarted)
		{
			workouttime += Time.deltaTime;
		}

		// begine workout time, only if primary user calibrated
		if (manager.IsUserCalibrated (manager.GetPrimaryUserID ())) {
			WorkoutStarted = true;		
		} 
		else {
			WorkoutStarted = false;
		}

	}


	public float WorkoutTime()
	{
		return workouttime;
	}

	public int Squats()
	{
		return SquatNum;
	}
	
	public int Jumps()
	{
		return JumpNum;
	}


}
