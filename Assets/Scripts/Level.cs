using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public Vector2 location;
	public List<Vector2> dirtLocs;
	public DirtController dirt;

	public List<Vector2> holeLocs;
	public GameObject hole;

	public Vector2 upDoorLoc;
	public Vector2 downDoorLoc;

	public GameObject floor;

	private DoorController upDoor;
	private DoorController downDoor;


	// Use this for initialization
	void Start () {
		// Set up level
		NewObjAtLocs(dirt, dirtLocs, -1.0f);
		NewObjAtLocs(hole, holeLocs, -1.0f);

		Instantiate(floor, 
			new Vector3(location.x, location.y, 0f),
			Quaternion.identity
		);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int DirtLeft() {
		return GameObject.FindGameObjectsWithTag("Dirt").Length;
	}

	void NewObjAtLocs(Object obj, List<Vector2> locs, float zPos) {
		for (int i = 0; i < locs.Count; i++) {
			Vector3 pos = new Vector3(
				locs[i].x + location.x,
				locs[i].x + location.y,
				zPos
			);

			Instantiate(obj, pos, Quaternion.identity);
		}

	}
}
