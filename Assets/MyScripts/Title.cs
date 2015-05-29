using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {



	// if title is clicked open the heart health website
	void OnMouseDown()
	{
		Application.OpenURL("http://hearthealth.azurewebsites.net/");

	}

}
