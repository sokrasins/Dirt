using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoRenderOrder : MonoBehaviour {

    public int LevelNum {
        get { return levelNum; }
        set {
            levelNum = value;
            SetOrder();
        }
    }
    public int levelNum = 1;

    public bool updateDuringRuntime = false;

    private int levelOffset = 2500;
    private int levelSpan = 700;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (updateDuringRuntime) {
            SetOrder();
        }
    }

    void SetOrder() {
        var sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sortingOrder = Mathf.RoundToInt( (Level.GetLevelPos(levelNum).y - gameObject.transform.position.y) * 100 - levelOffset * levelNum);
    }

    public void SetBottom(int offset) {
        var sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sortingOrder = - (levelOffset * levelNum) - levelSpan + offset;
    }
}
