﻿using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	Color col;
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
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
		Application.Quit ();
	}

}
