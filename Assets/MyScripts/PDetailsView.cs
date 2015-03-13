using UnityEngine;
using System.Collections;

public class PDetailsView : MonoBehaviour {


	//public GameObject DetailsBlock;
	public GUIText DetailsText;
	
	private DatabasePDetails detailsDatabase;

	// Use this for initialization
	void Start () {
		detailsDatabase = new DatabasePDetails ();

		PatientDetails patientData = detailsDatabase.GetPatient (PlayerPrefs.GetString ("CurrentUser"));

		DetailsText.text = "Your Account: \n" + patientData.Name + "\n" + patientData.DateOfBirth.Day + "/" + patientData.DateOfBirth.Month +"/" + patientData.DateOfBirth.Year 
			+ "\n" + patientData.Address + "\n" + patientData.Email + "\n" + patientData.PhoneNumber;



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
