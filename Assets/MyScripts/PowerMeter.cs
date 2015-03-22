using UnityEngine;
using System.Collections;

public class PowerMeter : MonoBehaviour {
	
	public Texture2D bgImage; 
	public Texture2D fgImage; 
	//public GUIText AmmoCount;
	
	int MaxPower = 100;
	float Power = 0;
	bool MeterFull = false;
	
	
	
	private float PowerMeterLength;

	// Use this for initialization
	void Start () {
		PowerMeterLength = (Screen.height /2);
		Refresh ();
	}
	
	// Update is called once per frame
	void Update () {
		AdjustPower(0);

		if (Power >= MaxPower) {
			MeterFull = true;
		}

	}
	
	
	
	void OnGUI () {
		
		
		
		GUI.BeginGroup(new Rect (20, (Screen.height /2)-(Screen.height /3), 40, (Screen.height /2)+(Screen.height /4)));
		GUI.DrawTexture(new Rect(0, 0, 40, PowerMeterLength), bgImage);
		
		// draw the filled-in part:
		GUI.BeginGroup(new Rect (0, (PowerMeterLength - (PowerMeterLength  * (Power/MaxPower))), 40, PowerMeterLength  * (Power/MaxPower)));
		GUI.DrawTexture(new Rect (0, -PowerMeterLength + (PowerMeterLength  * (Power/MaxPower)), 40, PowerMeterLength), fgImage);
		GUI.EndGroup();
		GUI.EndGroup ();
		
		
	}
	
	
	public void AdjustPower(float Amount){
		
		Power += Amount;
		if(Power > MaxPower)
			Power = MaxPower;
		if (Power < 0)
			Power = 0;
		
	}
	
	
	public float GetPowerMeter()
	{
		return Power;
	}
	
	
	public void Refresh()
	{
		Power = 0;
		MeterFull = false;

		
	}


	public void PowerUp(int Amount)
	{
		Debug.Log (Power);
		Power += Amount;

	}

	public void PowerDown(int Amount)
	{
		Power -= Amount;



	}

	public bool PowerFull()
	{
		return MeterFull;
	}

	
	
}
