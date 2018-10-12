using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : Dirt {

    public List<Sprite> slices;

    public Pizza (Vector2 position) : base(position) {
        // Nothing!
    }

    // Use this for initialization
    new void Start () {
        base.Start();
        sr.sprite = slices[Random.Range(0, slices.Count)];
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}
}
