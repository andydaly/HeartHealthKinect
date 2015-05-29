using UnityEngine;
using System.Collections;

public class EditButton : MonoBehaviour {

	// edit button allows users to edit account details

	// Requires other PasswordButton, within scene these buttons are right next to one another
	// it is needed because on press of PasswordButton password change menu appears, and as such both windows cannot be open at once.
	public GameObject PasswordButton;

	// used  for EditDetails window size
	private Rect windowRect;

	// used to save default button colour
	private Color col;

	// Used for detection of active menu
	private bool EditActive = false;

	// string to edit user name
	private string nameString;

	// string to edit email
	private string emailString;

	// string to edit address
	private string addressString;

	// string to edit phone number
	private string phoneString;

	// PatientDetails Databsae management class
	private DatabasePDetails detailsDatabase;

	// used to retrieve patient account information
	private PatientDetails patientData;


	void Start () {
		// Edit account window size 
		windowRect = new Rect ((Screen.width / 3)+80, (Screen.height / 3), Screen.width / 4, Screen.height / 4+30);

		// Default Colour is saved
		col  = renderer.material.color;

		// Creation of Patient Database management Class
		detailsDatabase = new DatabasePDetails ();

		// get current patient account details
		patientData = detailsDatabase.GetPatient (PlayerPrefs.GetString ("CurrentUser"));
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
		// set edit details window to either active or not
		if (!EditActive)
			EditActive = true;
		else
			EditActive = false;

		// ensures that editdetails window is closed
		PasswordButton.GetComponent<ChangePasswordButton>().WindowSwitch(false);
	}


	void OnGUI() {

		// If bool to edit details window active and change password window not active then display password window
		if ((EditActive) && (!PasswordButton.GetComponent<ChangePasswordButton>().ChangePassActive()))  
		{
			GUI.Window (1, windowRect, EditWindow, "Edit Details");	
		} 


	}

	void EditWindow (int windowID)
	{
		// all label rectangles and text field rectangles positions
		Rect textRect1,  textLbl1, textRect2, textLbl2, textRect3, textLbl3,textRect4,textLbl4, btnRect;
		textLbl1 = new Rect (windowRect.width/3, windowRect.height/3-50, windowRect.width/3, 25);
		textRect1 = new Rect (windowRect.width/3, windowRect.height/3-30, windowRect.width/3, 25);
		textLbl2 = new Rect (windowRect.width/3, windowRect.height/3-10, windowRect.width/3, 25);
		textRect2 = new Rect (windowRect.width/3, windowRect.height/3+10, windowRect.width/3, 25);
		textLbl3 = new Rect (windowRect.width/3, windowRect.height/3+30, windowRect.width/3, 25);
		textRect3 = new Rect (windowRect.width/3, windowRect.height/3+50, windowRect.width/3, 25);
		textLbl4 = new Rect (windowRect.width/3, windowRect.height/3+70, windowRect.width/3, 25);
		textRect4 = new Rect (windowRect.width/3, windowRect.height/3+90, windowRect.width/3, 25);

		//button rectangle and position
		btnRect = new Rect (windowRect.width/3, windowRect.height/3+120, windowRect.width/8, windowRect.height/8);
		
		// get edited name string, also displays current name as default value
		nameString = GUI.TextField (textRect1, patientData.Name, 30);

		// get edited email string, also displays current email as default value
		emailString = GUI.TextField (textRect2,patientData.Email,  30);

		// get edited address string, also displays current address as default value
		addressString = GUI.TextField (textRect3,patientData.Address,  30);

		// get edited phone number string, also displays current phone number as default value
		phoneString = GUI.TextField (textRect4,patientData.PhoneNumber,  30);

		// button press
		if (GUI.Button (btnRect, "Enter")) {
			// database management class edits name
			detailsDatabase.EditName(PlayerPrefs.GetString("CurrentUser"), nameString);

			// database management class edits email
			detailsDatabase.EditEmail(PlayerPrefs.GetString("CurrentUser"), emailString);

			// database management class edits address
			detailsDatabase.EditAddress(PlayerPrefs.GetString("CurrentUser"), addressString);

			// database management class edits phone number
			detailsDatabase.EditPhoneNumber(PlayerPrefs.GetString("CurrentUser"), phoneString);
			EditActive = false;
			// refreshes accountscene to load new changes to account details
			Application.LoadLevel("AccountScene");
		}
		
		// set labels for edit account fields
		GUI.Label (textLbl1, "Name:");
		GUI.Label (textLbl2, "Email:");
		GUI.Label (textLbl3, "Address:");
		GUI.Label (textLbl4, "Phone Number:");
	}

	// Used to detect if Edit window is currently active
	public bool EditWindowActive()
	{
		return EditActive;
	}

	// Switches Edit window active screen
	public void WindowSwitch(bool activeswitch)
	{
		EditActive = activeswitch;
	}


}
