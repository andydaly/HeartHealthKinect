using UnityEngine;
using System.Collections;

public class LoginView : MonoBehaviour {



	private DatabasePAccount patientlogin;

	private string usernameString = "";
	private string passwordString1 = "";
	private string passwordString2 = "";

	private Rect windowRect;
	private Rect errorRect;

	private bool SetPassword = false;
	private bool LoginError = false;
	private string ErrorString = "";


	void Start () {
		patientlogin = new DatabasePAccount ();
		windowRect = new Rect ((Screen.width / 3)+80, (Screen.height / 3), Screen.width / 4, Screen.height / 4);
		errorRect = new Rect((Screen.width / 3)+80, (Screen.height / 3)+10, Screen.width / 4, Screen.height / 5);

		if (PlayerPrefs.HasKey ("CurrentUser")) 
		{
			Application.LoadLevel("MenuScene");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		//GUI.skin.label.fontSize = 15;

		if (LoginError) {
			GUI.Window (1, errorRect, LoginErrorWindow, "Error");	
				} 
		else {
			if (!SetPassword)
				GUI.Window (0, windowRect, LoginWindow, "Login");
			else
				GUI.Window (0, windowRect, PasswordWindow, "Set Password");

				}

	}

	void LoginWindow (int windowID)
	{
		Rect textRect, passRect, textLbl, passLbl, btnRect;
		textRect = new Rect (windowRect.width/3, windowRect.height/3-30, windowRect.width/3, 25);
		passRect = new Rect (windowRect.width/3, windowRect.height/3+30, windowRect.width/3, 25);
		textLbl = new Rect (windowRect.width/3, windowRect.height/3-50, windowRect.width/3, 25);
		passLbl = new Rect (windowRect.width/3, windowRect.height/3+10, windowRect.width/3, 25);
		btnRect = new Rect (windowRect.width/3, windowRect.height/3+70, windowRect.width/8, windowRect.height/8);


		usernameString = GUI.TextField (textRect, usernameString, 25);
		passwordString1 = GUI.PasswordField (passRect,passwordString1, "*" [0], 20);


		if (GUI.Button (btnRect, "Login")) {
			if (patientlogin.CheckUserName(usernameString))
			{
				if (patientlogin.CheckIfConfirmed(usernameString))
				{
					if(patientlogin.CheckLogin(usernameString,passwordString1))
					{
						PlayerPrefs.DeleteAll();
						PlayerPrefs.SetString("CurrentUser", usernameString);
						Application.LoadLevel("MenuScene");
					}
					else
					{
						LoginError = true;
						ErrorString = "Login Details are Incorrect";
					}


				}
				else
				{
					SetPassword =true;

				}
			}
			else
			{
				LoginError = true;
				ErrorString = "Username Not Found";

			}
		}


		GUI.Label (textLbl, "UserName:");
		GUI.Label (passLbl, "Password:");
	}


	void PasswordWindow (int windowID)
	{
		Rect passRect1, passRect2, passLbl1, passLbl2, btnRect,detailsLbl;
		detailsLbl = new Rect (windowRect.width/3-20, windowRect.height/3-50, windowRect.width, 25);

		passRect1 = new Rect (windowRect.width/3, windowRect.height/3-10, windowRect.width/3, 25);
		passRect2 = new Rect (windowRect.width/3, windowRect.height/3+50, windowRect.width/3, 25);
		passLbl1 = new Rect (windowRect.width/3, windowRect.height/3-30, windowRect.width/3, 25);
		passLbl2 = new Rect (windowRect.width/3, windowRect.height/3+30, windowRect.width/3, 25);
		btnRect = new Rect (windowRect.width/3, windowRect.height/3+90, windowRect.width/8, windowRect.height/8);
		
		
		passwordString1 = GUI.PasswordField (passRect1, passwordString1, "*" [0], 20);
		passwordString2 = GUI.PasswordField (passRect2,passwordString2, "*" [0], 20);
		
		
		if (GUI.Button (btnRect, "Enter")) {

			if (passwordString1 == passwordString2)
			{

				patientlogin.ChangePassword(usernameString, passwordString1);
				patientlogin.AccountConfirmed(usernameString);
				PlayerPrefs.DeleteAll();
				PlayerPrefs.SetString("CurrentUser", usernameString);
				Application.LoadLevel("MenuScene");
			}
			else
			{
				LoginError = true;
				ErrorString = "Passwords do not match";
			}
		}


		GUI.Label (detailsLbl, "Set password for " + usernameString);
		GUI.Label (passLbl1, "New Password:");
		GUI.Label (passLbl2, "Confirm Password:");
		Debug.Log ("Set password for " + usernameString);
	}

	void LoginErrorWindow (int windowID)
	{
		Rect btnRect, displayLbl;
		displayLbl = new Rect (windowRect.width/3-5, windowRect.height/3-30, windowRect.width/3, windowRect.height/8);
		btnRect = new Rect (windowRect.width/3+40, windowRect.height/3+30, windowRect.width/8, windowRect.height/8);



		GUI.backgroundColor = Color.red;

		if (GUI.Button (btnRect, "Enter")) {
			LoginError = false;
			usernameString = "";
			passwordString1 = "";
			passwordString2 = "";
		}
		
		GUIStyle style = new GUIStyle ();
		style.fontSize = 20;

		GUI.Label (displayLbl, ErrorString, style);
		GUI.color = Color.white;
	}



}
