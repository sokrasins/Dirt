using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// TODO: Hacky. FIgure out a good way of transitioning through levels.
	// MVP: teleporting
	// next: animation
	// Dynamic building of levels and the spacing between them
	// benchmarks for teleporing
	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log("You're inside meeeeee");
		Vector3 pos = collision.gameObject.transform.position;
		pos.x = 8.64f;
		pos.y = -14.09f;
		collision.gameObject.transform.position = pos;
	}
}
