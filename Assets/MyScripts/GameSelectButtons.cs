using UnityEngine;
using System.Collections;

public class GameSelectButtons : MonoBehaviour {



	public enum GameSelectType : int { Basic, SimonSays, HeartRacer, Orbs }
	
	public GameSelectType gameType = GameSelectType.Basic;

	public GUIText DetailsText;

	private Color col;
	private string DefaultText;

	void Start () {
		col  = renderer.material.color;
		DefaultText = DetailsText.text;
	}



	void OnMouseEnter() {
		renderer.material.color = new Color32(15, 71, 59, 255);
		switch (gameType) {
		case GameSelectType.Basic:
			DetailsText.text = "Basic Exercise Mode \nNo gameplay, perform \nexercises and monitor \nheart rate.";
			break;
		case GameSelectType.SimonSays:
			DetailsText.text = "Simon Says Mode \nFollow instructions \nprecisely and to \nthe clock.";
			break;
		case GameSelectType.HeartRacer:
			DetailsText.text = "Heart Racer Mode \nPerform exercises to \nget heart rate to a \ncertain point.";
			break;
		case GameSelectType.Orbs:
			DetailsText.text = "Orbs Mode \nCatch the green orbs \nand dodge the red!";
			break;

		}


	}
	
	
	
	
	void OnMouseExit() {
		renderer.material.color = col;
		DetailsText.text = DefaultText;
	}


	void OnMouseDown() {
		switch (gameType) {
		case GameSelectType.Basic:
			PlayerPrefs.SetString("GameMode","Basic");
			Application.LoadLevel("BasicWorkout");
			break;
		case GameSelectType.SimonSays:
			PlayerPrefs.SetString("GameMode","Simon Says");
			Application.LoadLevel("SimonSays");
			break;
		case GameSelectType.HeartRacer:
			PlayerPrefs.SetString("GameMode","Heart Racer");
			Application.LoadLevel("HeartRacer");
			break;
		case GameSelectType.Orbs:
			PlayerPrefs.SetString("GameMode","Orbs");
			Application.LoadLevel("OrbDodger");
			break;
			
		}
	}

}
