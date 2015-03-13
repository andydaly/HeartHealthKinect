using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

public class ColourView : MonoBehaviour {

	//public GUITexture backgroundImage;
	public GameObject ImageWall;

	public GUIText debugText;
	
	public bool displaySkeletonLines = false;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
		KinectManager manager = KinectManager.Instance;
		
		if(manager && manager.IsInitialized())
		{
			//backgroundImage.renderer.material.mainTexture = manager.GetUsersClrTex();
			if(ImageWall)
			{
				Texture2D UsersClearTex = manager.GetUsersClrTex();
				//UsersClearTex = manager.ApplySkeletonToTexture(UsersClearTex);
				
				
				
				
				ImageWall.renderer.material.mainTexture = UsersClearTex;
				float pos = (Camera.main.nearClipPlane + 0.01f);
				
				ImageWall.transform.position = Camera.main.transform.position + Camera.main.transform.forward * pos;
				ImageWall.transform.LookAt (Camera.main.transform);
				ImageWall.transform.Rotate (270.0f, 180.0f, 0.0f);
				
				float h = (Mathf.Tan(Camera.main.fieldOfView*Mathf.Deg2Rad*0.5f)*pos*2f) /10.0f;
				
				ImageWall.transform.localScale = new Vector3(h*Camera.main.aspect,1.0f, h);
				
				
				
				
				
			}
			
			//int iJointIndex = (int)trackedJoint;
			
			if(manager.IsUserDetected())
			{
				//long userId = manager.GetPrimaryUserID();
				
				
			}
			
		}
	}
}
