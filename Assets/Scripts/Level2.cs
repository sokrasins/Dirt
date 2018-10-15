using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level {

    public Vector2 antHillLoc;
    public int antsToSpawn;

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

        obj.GetComponent<AntHill>().MakeAnts(antsToSpawn, gameObject);

    }

}

