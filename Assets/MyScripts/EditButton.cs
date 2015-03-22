using UnityEngine;
using System.Collections;

public class EditButton : MonoBehaviour {

	public GameObject PasswordButton;


	private Rect windowRect;
	private Color col;
	private bool EditActive = false;
	private string nameString;
	private string emailString;
	private string addressString;
	private string phoneString;
	private DatabasePDetails detailsDatabase;
	private PatientDetails patientData;


	void Start () {
		windowRect = new Rect ((Screen.width / 3)+80, (Screen.height / 3), Screen.width / 4, Screen.height / 4+30);
		col  = renderer.material.color;
		detailsDatabase = new DatabasePDetails ();
		patientData = detailsDatabase.GetPatient (PlayerPrefs.GetString ("CurrentUser"));
	}
	

	void OnMouseEnter() {
		renderer.material.color = new Color32(15, 71, 59, 255);

	}
	
	
	
	
	void OnMouseExit() {
		renderer.material.color = col;
	}

	void OnMouseDown() {
		if (!EditActive)
			EditActive = true;
		else
			EditActive = false;


		PasswordButton.GetComponent<ChangePasswordButton>().WindowSwitch(false);
	}


	void OnGUI() {
		//GUI.skin.label.fontSize = 15;
		
		if ((EditActive) && (!PasswordButton.GetComponent<ChangePasswordButton>().ChangePassActive()))  
		{
			GUI.Window (1, windowRect, EditWindow, "Edit Details");	
		} 


	}

	void EditWindow (int windowID)
	{
		Rect textRect1,  textLbl1, textRect2, textLbl2, textRect3, textLbl3,textRect4,textLbl4, btnRect;
		textLbl1 = new Rect (windowRect.width/3, windowRect.height/3-50, windowRect.width/3, 25);
		textRect1 = new Rect (windowRect.width/3, windowRect.height/3-30, windowRect.width/3, 25);
		textLbl2 = new Rect (windowRect.width/3, windowRect.height/3-10, windowRect.width/3, 25);
		textRect2 = new Rect (windowRect.width/3, windowRect.height/3+10, windowRect.width/3, 25);
		textLbl3 = new Rect (windowRect.width/3, windowRect.height/3+30, windowRect.width/3, 25);
		textRect3 = new Rect (windowRect.width/3, windowRect.height/3+50, windowRect.width/3, 25);
		textLbl4 = new Rect (windowRect.width/3, windowRect.height/3+70, windowRect.width/3, 25);
		textRect4 = new Rect (windowRect.width/3, windowRect.height/3+90, windowRect.width/3, 25);


		btnRect = new Rect (windowRect.width/3, windowRect.height/3+120, windowRect.width/8, windowRect.height/8);
		
		
		nameString = GUI.TextField (textRect1, patientData.Name, 30);
		emailString = GUI.TextField (textRect2,patientData.Email,  30);
		addressString = GUI.TextField (textRect3,patientData.Address,  30);
		phoneString = GUI.TextField (textRect4,patientData.PhoneNumber,  30);

		if (GUI.Button (btnRect, "Enter")) {
			detailsDatabase.EditName(PlayerPrefs.GetString("CurrentUser"), nameString);
			detailsDatabase.EditEmail(PlayerPrefs.GetString("CurrentUser"), emailString);
			detailsDatabase.EditAddress(PlayerPrefs.GetString("CurrentUser"), addressString);
			detailsDatabase.EditPhoneNumber(PlayerPrefs.GetString("CurrentUser"), phoneString);
			EditActive = false;
			Application.LoadLevel("AccountScene");
		}
		
		
		GUI.Label (textLbl1, "Name:");
		GUI.Label (textLbl2, "Email:");
		GUI.Label (textLbl3, "Address:");
		GUI.Label (textLbl4, "Phone Number:");
	}

	public bool EditWindowActive()
	{
		return EditActive;
	}

	public void WindowSwitch(bool activeswitch)
	{
		EditActive = activeswitch;
	}


}
