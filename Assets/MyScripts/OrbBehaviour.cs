using UnityEngine;
using System.Collections;

public class OrbBehaviour : MonoBehaviour {

	public enum OrbType : int { Green, Red }
	
	public OrbType orbType = OrbType.Green;


	void OnTriggerEnter(Collider collider) {
		
		if (collider.gameObject.tag == "Player") 
		{
			Destroy (this.gameObject);


			switch (orbType) {
			case OrbType.Green:
				Camera.main.transform.SendMessage("OrbAdd");
				break;
			case OrbType.Red:
				Camera.main.transform.SendMessage("OrbMinus");
				break;
			}




			//Camera.main.GetComponent<PowerMeter> ().AdjustPower(10);
		}
	}
	
	
	void Update()
	{
		if (transform.position.z < -5) 
		{
			Destroy (this.gameObject);
		}
		
		transform.position -= Vector3.forward * Time.deltaTime;
	}
}
