using UnityEngine;
using System.Collections;

public class GridGenerator : MonoBehaviour {

	// used for generation of nice grid background within menu screens

	public GameObject Tile;
	public int GridWidth = 10;
	public int GridHeight = 10;


	// Use this for initialization
	void Start () {

		InitGrid ();
		RandGrid ();
	}

	void InitGrid()
	{
		Vector3 pos = Tile.transform.localPosition;
		float initx = pos.x;
		for (int j = 0; j < GridHeight; j++) {
			
			
			for (int i = 0; i < GridWidth; i++) {
				pos.x += Tile.transform.localScale.x;
				Instantiate (Tile, pos, Tile.transform.rotation); 
			}
			pos.y -= Tile.transform.localScale.y;
			pos.x = initx;
		}
	}

	void RandGrid()
	{
		Vector3 pos = Tile.transform.localPosition;
		float initx = pos.x;
		pos.z -= Tile.transform.localScale.z;
		for (int j = 0; j < GridHeight; j++) {
			
			
			for (int i = 0; i < GridWidth; i++) {
				pos.x += Tile.transform.localScale.x;
				int num = Random.Range(1,4);
				if (num == 1)
				Instantiate (Tile, pos, Tile.transform.rotation); 
			}
			pos.y -= Tile.transform.localScale.y;
			pos.x = initx;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
