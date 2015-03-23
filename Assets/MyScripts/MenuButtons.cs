using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public enum ButtonType : int { Exercise, Diary, Medical, Account, Quit, Logout }
	
	public ButtonType buttonType = ButtonType.Exercise;
	
	
	
	
	public Texture MainTexture;
	public Texture BoldTexture;


	void Start () {

	}
	
	
	void OnMouseEnter() {
		
		guiTexture.texture = BoldTexture;
		
	}
	
	void OnMouseExit() {
		guiTexture.texture = MainTexture;
	}
	
	void OnMouseDown() {

		switch (buttonType) {
		case ButtonType.Exercise:
			Destroy (Camera.main.gameObject);
			Destroy(this);
			Application.LoadLevel("GameSelect");
			break;
		case ButtonType.Diary:
			Destroy (Camera.main.gameObject);
			Destroy(this);
			Application.LoadLevel("DiaryScene");
			break;
		case ButtonType.Medical:
			Destroy (Camera.main.gameObject);
			Destroy(this);
			Application.LoadLevel("MedicalScene");
			break;
		case ButtonType.Account:
			
			Destroy (Camera.main.gameObject);
			Destroy(this);
			Application.LoadLevel("AccountScene");	
			break;
		
		
		
		}

		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
