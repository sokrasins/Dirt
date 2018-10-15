using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHill : Dirt {

    private List<GameObject> antList;

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
        foreach (GameObject ant in antList) {
            ant.SetActive(true);
        }
    }

    /*public List<Ant>*/ public void MakeAnts(int toSpawn, GameObject parent) {
        // Set up ants
        GameObject obj;
        GameObject ant = Resources.Load<GameObject>("Prefabs/Ant");

        antList = new List<GameObject>();

        for (int i = 0; i < toSpawn; i++) {
            obj = Instantiate<GameObject>(
                ant,
                gameObject.transform.position,
                Quaternion.identity
            );

            obj.SetActive(false);
            parent.GetComponent<Level>().SetLevelAsParent(obj);
            antList.Add(obj);
        }
    }
}
