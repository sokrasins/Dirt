using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level {

    public Vector2 antHillLoc;

    /*
    // Use this for initialization
    void Start() {

    }
    */

    public override void Configure() {
        base.Configure();

        // Make Anthill
        GameObject antHill = Resources.Load<GameObject>("Prefabs/Anthill");

        GameObject obj = Instantiate<GameObject>(
            antHill,
            antHillLoc + location,
            Quaternion.identity
        );
        SetLevelAsParent(obj);
    }

}

