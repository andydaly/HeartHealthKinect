using UnityEngine;
using System.Collections;

public class SimonSaysListener : MonoBehaviour, KinectGestures.GestureListenerInterface {
	
	
	
	//public GUIText GestureInfo;
	//public GUIText WorkOutText;
	
	
	//int SquatNum = 0;
	//int JumpNum = 0;
	//float workouttime = 0.0f;
	//bool WorkoutStarted = false;
	
	private KinectManager manager;
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
		manager.DetectGesture(userId, KinectGestures.Gestures.Wave);
		manager.DetectGesture(userId, KinectGestures.Gestures.Tpose);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);
		manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
		manager.DetectGesture(userId, KinectGestures.Gestures.Psi);

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
		//string sGestureText = gesture + " detected";
		//if(GestureInfo != null)
		//{
		//	GestureInfo.guiText.text = sGestureText;
		//}
		
		if (gesture == KinectGestures.Gestures.Squat) {
			int num = 0;
			Camera.main.transform.SendMessage ("ActionPerformed",num);
		} 
		else if (gesture == KinectGestures.Gestures.Jump) {

			Camera.main.transform.SendMessage ("ActionPerformed",1);
		}
		else if (gesture == KinectGestures.Gestures.Wave) {
			Camera.main.transform.SendMessage ("ActionPerformed",2);
		}
		else if (gesture == KinectGestures.Gestures.RaiseLeftHand) {
			Camera.main.transform.SendMessage ("ActionPerformed",3);
		}
		else if (gesture == KinectGestures.Gestures.RaiseRightHand) {
			Camera.main.transform.SendMessage ("ActionPerformed",4);
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
		

	}

	//public bool ActionPerformed()
	//{
	//	return true;
	//}
	


	
	
}
