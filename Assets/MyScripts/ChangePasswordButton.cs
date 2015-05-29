using UnityEngine;
using System.Collections;

public class ChangePasswordButton : MonoBehaviour {

	// Change passsword button displays a window to change the PatientAccount Password change menu
	// this script must be attacted to a gameobject to be used as a button


	// Requires other EditAccountButton, within scene these buttons are right next to one another
	// it is needed because on press of EditAccountButton edit account menu appears, and as such both windows cannot be open at once.
	public GameObject EditAccountButton;

	// used  for PasswordChange window size
	private Rect windowRect;

	// used for Errordisplay window size
	private Rect errorRect;

	// used to save default button colour
	private Color col;

	// Used for detection of active menu
	private bool ChangeActive = false;

	// PatientAccount Databsae management class
	private DatabasePAccount pAccount;

	// used to detect if error message is to be displayed
	private bool ErrorMessage = false;

	// string to display error if error is found
	private string ErrorString = "";

	// Current Password string
	private string passwordString1 = "";

	// New Password string
	private string passwordString2 = "";

	// Re-enter password string
	private string passwordString3 = "";

	void Start () {
		// Default Colour is saved
		col  = renderer.material.color;

		// Creation of Patient Database management Class
		pAccount = new DatabasePAccount ();

		// Change password window size 
		windowRect = new Rect ((Screen.width / 3)+80, (Screen.height / 3), Screen.width / 4, Screen.height / 4);

		// Error window size
		errorRect = new Rect((Screen.width / 3)+80, (Screen.height / 3)+10, Screen.width / 4, Screen.height / 5);
	}
	


	void OnMouseEnter() {
		// Colour changed to darker colour to simulate pushed in effect
		renderer.material.color = new Color32(15, 71, 59, 255);
	}

	void OnMouseExit() {
		//On exit returns to normal
		renderer.material.color = col;
	}


	void OnMouseDown() {
		// Sets ChangePassword window to either active or not active
		if (!ChangeActive)
			ChangeActive = true;
		else
			ChangeActive = false;

		// ensures that editdetails window is closed
		EditAccountButton.GetComponent<EditButton>().WindowSwitch(false);
	}


	void OnGUI() {

		// if errormessage bool active, display error message window
		if (ErrorMessage) {
			GUI.Window (2, errorRect, ErrorWindow, "Error");	
		} 
		else {
			// If bool to changepassword window active and editaccount window not active then display password window
			if ((ChangeActive) && (!EditAccountButton.GetComponent<EditButton> ().EditWindowActive ())) {
				GUI.Window (0, windowRect, PasswordWindow, "Change Password");	
			}
		}
	}

	private void PasswordWindow (int windowID)
	{
		// all label rectangles and text field rectangles positions
		Rect passRect1, passRect2, passRect3, passLbl1, passLbl2, passLbl3, btnRect;
		passLbl1 = new Rect (windowRect.width / 3, windowRect.height / 3 - 50, windowRect.width, 25);
		passRect1 = new Rect (windowRect.width / 3, windowRect.height / 3 - 30, windowRect.width / 3, 25);

		passLbl2 = new Rect (windowRect.width / 3, windowRect.height / 3 - 5, windowRect.width / 3, 25);
		passRect2 = new Rect (windowRect.width / 3, windowRect.height / 3 + 15, windowRect.width / 3, 25);

		passLbl3 = new Rect (windowRect.width / 3, windowRect.height / 3 + 35, windowRect.width / 3, 25);
		passRect3 = new Rect (windowRect.width / 3, windowRect.height / 3 + 55, windowRect.width / 3, 25);

		//button rectangle and position
		btnRect = new Rect (windowRect.width / 3, windowRect.height / 3 + 90, windowRect.width / 8, windowRect.height / 8);
		


		// Current password string
		passwordString1 = GUI.PasswordField (passRect1, passwordString1, "*" [0], 20);

		// New password string
		passwordString2 = GUI.PasswordField (passRect2, passwordString2, "*" [0], 20);

		// re-enter password string
		passwordString3 = GUI.PasswordField (passRect3, passwordString3, "*" [0], 20);

		// button press
		if (GUI.Button (btnRect, "Enter")) {

			// current password login check
			if (pAccount.CheckLogin(PlayerPrefs.GetString("CurrentUser"), passwordString1))
			{
				// both passwords must match
				if (passwordString2==passwordString3)
				{
					// change password if all fields comply
					pAccount.ChangePassword(PlayerPrefs.GetString("CurrentUser"), passwordString2);
				}
				else
				{
					// if not then display error message window and set string
					// if passwords do not match
					ErrorString = "Passwords entered do not match";
					ErrorMessage = true;
				}

			}
			else
			{
				// if current password check failure
				ErrorString = "Incorrect password";
				ErrorMessage = true;
			}
			// on button press, do not display password change window
			ChangeActive = false;
		}

		// set labels for password details
		GUI.Label (passLbl1, "Current Password:");
		GUI.Label (passLbl2, "New Password:");
		GUI.Label (passLbl3, "Confirm New Password:");


	}


	private void ErrorWindow (int windowID)
	{
		Rect btnRect, displayLbl;
		displayLbl = new Rect (windowRect.width/3-5, windowRect.height/3-30, windowRect.width/3, windowRect.height/8);
		btnRect = new Rect (windowRect.width/3+40, windowRect.height/3+30, windowRect.width/8, windowRect.height/8);
		
		
		
		GUI.backgroundColor = Color.red;

		// button to close password window
		if (GUI.Button (btnRect, "Enter")) {
			ErrorMessage = false;

		}

		// change to bigger font size
		GUIStyle style = new GUIStyle ();
		style.fontSize = 20;
		
		GUI.Label (displayLbl, ErrorString, style);
		GUI.color = Color.white;
	}

	// Used to detect if ChangePassword window is currently active
	public bool ChangePassActive()
	{
		return ChangeActive;
	}


	// Switches ChangePassword window active screen
	public void WindowSwitch(bool activeswitch)
	{
		ChangeActive = activeswitch;
	}

}
