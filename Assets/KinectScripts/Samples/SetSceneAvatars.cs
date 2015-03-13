using UnityEngine;
using System.Collections;

public class SetSceneAvatars : MonoBehaviour 
{

	void Start () 
	{
		KinectManager manager = KinectManager.Instance;
		
		if(manager)
		{
			// remove all users, filters and avatar controllers
			manager.ClearKinectUsers();
			manager.avatarControllers.Clear();

			// get the mono scripts. avatar controllers and gesture listeners are among them
			MonoBehaviour[] monoScripts = FindObjectsOfType(typeof(MonoBehaviour)) as MonoBehaviour[];
			
			// add available avatar controllers
			foreach(MonoBehaviour monoScript in monoScripts)
			{
				if(typeof(AvatarController).IsAssignableFrom(monoScript.GetType()))
				{
					AvatarController avatar = (AvatarController)monoScript;
					manager.avatarControllers.Add(avatar);
				}
			}

			// add available gesture listeners
			manager.gestureListeners.Clear();

			foreach(MonoBehaviour monoScript in monoScripts)
			{
				if(typeof(KinectGestures.GestureListenerInterface).IsAssignableFrom(monoScript.GetType()))
				{
					//KinectGestures.GestureListenerInterface gl = (KinectGestures.GestureListenerInterface)monoScript;
					manager.gestureListeners.Add(monoScript);
				}
			}

		}
	}
	
}
