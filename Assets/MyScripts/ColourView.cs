using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

public class ColourView : MonoBehaviour {

	// used to project user image onto screen for workouts

	// Plane required used to project user image
	public GameObject ImageWall;

	void Update () {
	
		// Another way to get the kinectmanager
		// can also do: KinectManager manager = Camera.main.GetComponent<KinectManager>();
		KinectManager manager = KinectManager.Instance;

		// manager must be available and initialed
		if(manager && manager.IsInitialized())
		{
			// Imagewall must be included and active
			if(ImageWall)
			{
				// create a texture and get manager users texture
				Texture2D UsersClearTex = manager.GetUsersClrTex();

				// change the texture on plane (Imagewall) to display user image
				ImageWall.renderer.material.mainTexture = UsersClearTex;

				// set position to be actually in view of camera
				float pos = (Camera.main.nearClipPlane + 0.01f);

				// set image wall position in front of camera
				ImageWall.transform.position = Camera.main.transform.position + Camera.main.transform.forward * pos;
				// ensure imageall always looks into camera
				ImageWall.transform.LookAt (Camera.main.transform);
				// rotate actually towards camera
				ImageWall.transform.Rotate (270.0f, 180.0f, 0.0f);

				// scale to fit exactly to fit into camera field of view
				float h = (Mathf.Tan(Camera.main.fieldOfView*Mathf.Deg2Rad*0.5f)*pos*2f) /10.0f;
				
				ImageWall.transform.localScale = new Vector3(h*Camera.main.aspect,1.0f, h);

			}
		}
	}
}
