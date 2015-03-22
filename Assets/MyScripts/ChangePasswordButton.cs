using UnityEngine;
using System.Collections;

public class ChangePasswordButton : MonoBehaviour {

	public GameObject EditAccountButton;


	private Rect windowRect;
	private Rect errorRect;
	private Color col;
	private bool ChangeActive = false;
	private DatabasePAccount pAccount;
	private bool ErrorMessage = false;
	private string ErrorString = "";

	string passwordString1 = "";
	string passwordString2 = "";
	string passwordString3 = "";

	void Start () {
		col  = renderer.material.color;
		pAccount = new DatabasePAccount ();
		windowRect = new Rect ((Screen.width / 3)+80, (Screen.height / 3), Screen.width / 4, Screen.height / 4);
		errorRect = new Rect((Screen.width / 3)+80, (Screen.height / 3)+10, Screen.width / 4, Screen.height / 5);
	}
	


	void OnMouseEnter() {

		renderer.material.color = new Color32(15, 71, 59, 255);
	}

	void OnMouseExit() {
		renderer.material.color = col;
	}


	void OnMouseDown() {
		if (!ChangeActive)
			ChangeActive = true;
		else
			ChangeActive = false;

		EditAccountButton.GetComponent<EditButton>().WindowSwitch(false);
	}


	void OnGUI() {

		if (ErrorMessage) {
			GUI.Window (2, errorRect, ErrorWindow, "Error");	
		} 
		else {
			if ((ChangeActive) && (!EditAccountButton.GetComponent<EditButton> ().EditWindowActive ())) {
				GUI.Window (0, windowRect, PasswordWindow, "Change Password");	
			}
		}
	}

	void PasswordWindow (int windowID)
	{
		Rect passRect1, passRect2, passRect3, passLbl1, passLbl2, passLbl3, btnRect;
		passLbl1 = new Rect (windowRect.width / 3, windowRect.height / 3 - 50, windowRect.width, 25);
		passRect1 = new Rect (windowRect.width / 3, windowRect.height / 3 - 30, windowRect.width / 3, 25);

		passLbl2 = new Rect (windowRect.width / 3, windowRect.height / 3 - 5, windowRect.width / 3, 25);
		passRect2 = new Rect (windowRect.width / 3, windowRect.height / 3 + 15, windowRect.width / 3, 25);

		passLbl3 = new Rect (windowRect.width / 3, windowRect.height / 3 + 35, windowRect.width / 3, 25);
		passRect3 = new Rect (windowRect.width / 3, windowRect.height / 3 + 55, windowRect.width / 3, 25);

		btnRect = new Rect (windowRect.width / 3, windowRect.height / 3 + 90, windowRect.width / 8, windowRect.height / 8);
		



		passwordString1 = GUI.PasswordField (passRect1, passwordString1, "*" [0], 20);
		passwordString2 = GUI.PasswordField (passRect2, passwordString2, "*" [0], 20);
		passwordString3 = GUI.PasswordField (passRect3, passwordString3, "*" [0], 20);
		
		if (GUI.Button (btnRect, "Enter")) {

			if (pAccount.CheckLogin(PlayerPrefs.GetString("CurrentUser"), passwordString1))
			{
				if (passwordString2==passwordString3)
				{
					pAccount.ChangePassword(PlayerPrefs.GetString("CurrentUser"), passwordString2);
				}
				else
				{
					ErrorString = "Passwords entered do not match";
					ErrorMessage = true;
				}

			}
			else
			{
				ErrorString = "Incorrect password";
				ErrorMessage = true;
			}
			ChangeActive = false;
		}

		GUI.Label (passLbl1, "Current Password:");
		GUI.Label (passLbl2, "New Password:");
		GUI.Label (passLbl3, "Confirm New Password:");


	}


	void ErrorWindow (int windowID)
	{
		Rect btnRect, displayLbl;
		displayLbl = new Rect (windowRect.width/3-5, windowRect.height/3-30, windowRect.width/3, windowRect.height/8);
		btnRect = new Rect (windowRect.width/3+40, windowRect.height/3+30, windowRect.width/8, windowRect.height/8);
		
		
		
		GUI.backgroundColor = Color.red;
		
		if (GUI.Button (btnRect, "Enter")) {
			ErrorMessage = false;

		}
		
		GUIStyle style = new GUIStyle ();
		style.fontSize = 20;
		
		GUI.Label (displayLbl, ErrorString, style);
		GUI.color = Color.white;
	}


	public bool ChangePassActive()
	{
		return ChangeActive;
	}

	public void WindowSwitch(bool activeswitch)
	{
		ChangeActive = activeswitch;
	}

}
