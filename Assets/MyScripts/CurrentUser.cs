using UnityEngine;
using System.Collections;

public class CurrentUser : MonoBehaviour {

	// used to display which user is currently logged in

	// get GUItext to display username
	public GUIText UsernameText;


	void Start () {
		// Display current username
		UsernameText.text = PlayerPrefs.GetString ("CurrentUser");
	}

}
