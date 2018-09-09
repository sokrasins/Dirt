using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] levelObjs = GameObject.FindGameObjectsWithTag("Level");
        Level[] levels = new Level[levelObjs.Length];

        for (int i = 0; i < levelObjs.Length; ++i) {
            levels[i] = levelObjs[i].GetComponent<Level>();
        }

        Array.Sort(
            levels,
            delegate(Level x, Level y) { return x.level.CompareTo(y.level); }
        );

        foreach (Level i in levels) {
            i.Configure();
        }

        // Link doors together
        for (int i=0; i<levels.Length-1; i++) {
            Level.LinkLevels(levels[i], levels[i+1]);
        }

        levels[0].GetUpDoor().Disable();
        levels[levels.Length - 1].GetDownDoor().Disable();
    }
	
	// Update is called once per frame
	void Update () {

	}
}
