using UnityEngine;
using System.Collections;

public class DDetailsView : MonoBehaviour {

	//public GameObject DetailsBlock;
	public GUIText DetailsText;



	private DatabaseDtoP allocDatabase;
	private DatabaseDDetails detailsDatabase;
	private string docUserName;
	private DoctorDetails doctorData;

	// Use this for initialization
	void Start () {
		allocDatabase = new DatabaseDtoP ();
		detailsDatabase = new DatabaseDDetails ();

		docUserName = allocDatabase.GetDUserNameByPatient (PlayerPrefs.GetString ("CurrentUser"));
		doctorData = detailsDatabase.GetDoctor (docUserName);

		if (doctorData.Bio.Length >= 36) {
			string Bio1 = doctorData.Bio.Substring(0,35);
			string Bio2 = doctorData.Bio.Substring(35);
			DetailsText.text = "Your Medical Professional: \n" + doctorData.Name + " (" + doctorData.Position + ") \n" + doctorData.Practice + "\n"
				+ doctorData.Email + "\n" + doctorData.PhoneNumber + "\n" + Bio1 + "\n" + Bio2;
				} 
		else {
			DetailsText.text = "Your Medical Professional: \n" + doctorData.Name + " (" + doctorData.Position + ") \n" + doctorData.Practice + "\n"
								+ doctorData.Email + "\n" + doctorData.PhoneNumber + "\n" + doctorData.Bio;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
