using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHill : Dirt {

    public int antsToSpawn = 20;

    public AntHill(Vector2 position) : base(position) {
        // Nothing!
    }

    // Use this for initialization
    new void Start() {
        base.Start();
    }

    // Update is called once per frame
    new void Update() {
        base.Update();
    }

    // Make ants!!!
    public override void SweepCallback() {
        GameObject obj;
        var parent = gameObject.transform.parent;

        for (int i=0; i<antsToSpawn; i++) {
            //obj = Instantiate<GameObject>(
            //    wall,
            //    location + wallOffset,
            //    Quaternion.identity
            //);

        }
    }
}
