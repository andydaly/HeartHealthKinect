using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GameObject))]
public class EntryDetails : MonoBehaviour {
	
	public int CubeNumber = 0;
	
	void OnMouseEnter() {
		renderer.material.color = Color.red;
		Camera.main.transform.SendMessage ("DetailsDisplay", CubeNumber);
	}
	
	
	
	
	void OnMouseExit() {
		renderer.material.color = Color.white;
		//Camera.main.transform.SendMessage ("ExitDetails");
	}
}
