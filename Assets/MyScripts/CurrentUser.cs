using UnityEngine;
using System.Collections;

public class CurrentUser : MonoBehaviour {

	public GUIText UsernameText;

	// Use this for initialization
	void Start () {
		UsernameText.text = PlayerPrefs.GetString ("CurrentUser");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
