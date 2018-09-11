using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private float dimMax = 192.0f / 255.0f;

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

		//Set up levels
        foreach (Level i in levels) {
            i.Configure();
        }

        // Link doors together
        for (int i=0; i<levels.Length-1; i++) {
            Level.LinkLevels(levels[i], levels[i+1]);
        }

        levels[0].GetUpDoor().Disable();
        levels[levels.Length - 1].GetDownDoor().Disable();

		// Determine and set level dimness
		int levelMin = levels[0].level;
		int levelMax = levels[levels.Length-1].level;

		foreach (Level i in levels) {
			i.SetScrim (dimMax * (float)(i.level - levelMin) / (float)(levelMax - levelMin));
		}
    }
	
	// Update is called once per frame
	void Update () {

	}
}
