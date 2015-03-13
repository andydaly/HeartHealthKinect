using UnityEngine;
using System.Collections;

public class LogoutButton : MonoBehaviour {

	//Material mat;
	Color col;
	// Use this for initialization
	void Start () {
		col  = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseEnter() {
		renderer.material.color = new Color32(15, 71, 59, 255);;
		//Camera.main.transform.SendMessage ("DetailsDisplay", CubeNumber);
	}
	
	
	
	
	void OnMouseExit() {
		renderer.material.color = col;
			//color = new Color(54.0f, 146.0f, 115.0f, 1.0f);
		//Camera.main.transform.SendMessage ("ExitDetails");
	}


	void OnMouseDown() {
		PlayerPrefs.DeleteAll();
		Application.LoadLevel ("LoginScene");
	}


}
