using UnityEngine;
using System.Collections;

public class WorkoutListener : MonoBehaviour, KinectGestures.GestureListenerInterface {



	//public GUIText GestureInfo;
	public GUIText WorkOutText;


	int SquatNum = 0;
	int JumpNum = 0;
	float workouttime = 0.0f;
	bool WorkoutStarted = false;

	KinectManager manager;
	// Use this for initialization
	void Start () {
		manager = Camera.main.GetComponent<KinectManager>();
			//KinectManager.Instance;
	}
	



	public void UserDetected(long userId, int userIndex)
	{
		// detect these user specific gestures
		 
		
		manager.DetectGesture(userId, KinectGestures.Gestures.Squat);
		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);


		//		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeDown);
		
		//if(GestureInfo != null)
		//{
		//	GestureInfo.guiText.text = "Perform Squat or JumpingJack";
		//}
	}
	
	public void UserLost(long userId, int userIndex)
	{
		//if(GestureInfo != null)
		//{
		//	GestureInfo.guiText.text = string.Empty;
		//}
	}
	
	public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectInterop.JointType joint, Vector3 screenPos)
	{
		// don't do anything here
	}
	
	public bool GestureCompleted (long userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectInterop.JointType joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		//if(GestureInfo != null)
		//{
		//	GestureInfo.guiText.text = sGestureText;
		//}
		
		if (gesture == KinectGestures.Gestures.Squat) {
			SquatNum++;
			Camera.main.transform.SendMessage ("SquatPerformed");
		} 
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
