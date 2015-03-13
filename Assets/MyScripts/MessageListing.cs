using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MessageListing : MonoBehaviour {

	public GameObject MessageBlock;
	public GUIText MessageText;

	private DatabasePDetails detailsDatabase;

	private GameObject[] cubeEntries;
	private GUIText[] textEntries;
	private Vector3 FirstCubePos;
	private Vector3 LastCubePos;
	private int Count = 0;


	// Use this for initialization
	void Start () {

		detailsDatabase = new DatabasePDetails ();

		var messages = detailsDatabase.GetAllMessages(PlayerPrefs.GetString("CurrentUser"));

		cubeEntries = new GameObject[50];
		textEntries = new GUIText[50];

		//List<GameObject> cubeEntries = new List<GameObject> ();
		//List<GUIText> textEntries = new List<GUIText> ();
		Vector3 cubepos = MessageBlock.transform.localPosition;
		Vector3 textpos = MessageText.transform.localPosition;

		Count = messages.Count;
		if (Count > 0) {

			int i = 1;
			foreach (PatientMessages message in messages) {

				cubeEntries [i] = (GameObject)Instantiate (MessageBlock, cubepos, MessageBlock.transform.rotation);

				textEntries [i] = (GUIText)Instantiate (MessageText, textpos, MessageText.transform.rotation);
				cubepos.y -= (MessageBlock.transform.localScale.y * 1.25f);
				textEntries [i].guiText.text = message.MessageDate + "\n" + message.Message;
				textEntries [i].GetComponent<ObjectLabel> ().target = cubeEntries [i].transform;
				i++;
			}

				cubeEntries [Count].renderer.material.color = Color.gray;

			if (Count > 3) {
				FirstCubePos = cubeEntries [1].transform.position;
				
				LastCubePos = cubeEntries [3].transform.position;
				EndOfList ();

			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Count > 3) {
			if (Input.mousePosition.y < 15) {
				
				if (cubeEntries[Count].transform.position.y < LastCubePos.y)
				{
					for (int i = 1; i <= Count; i++) {
						
						cubeEntries[i].transform.position += transform.up*Time.deltaTime* 5.0f;
					}
					
					
					
				}
				
				
			}
			if (Input.mousePosition.y > Screen.height - 15) {
				if (cubeEntries[1].transform.position.y > FirstCubePos.y)
				{
					for (int i = 1; i <= Count; i++) {
						
						cubeEntries[i].transform.position -= transform.up*Time.deltaTime * 5.0f;
					}
					
					
				}
			}
		}
	}


	void EndOfList()
	{
		while (cubeEntries[Count].transform.position.y < LastCubePos.y) 
		{
			for (int i = 1; i <= Count; i++) {
				
				cubeEntries[i].transform.position += transform.up*Time.deltaTime* 5.0f;
			}
		}

	}

}
