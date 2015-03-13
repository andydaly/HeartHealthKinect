using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

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
		
	}
	
	
	
	
	void OnMouseExit() {
		renderer.material.color = col;
		
	}
	
	
	void OnMouseDown() {
		Application.LoadLevel ("MenuScene");
	}
}
