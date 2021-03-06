﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    // Public vars
    public int level;

    public GameObject dirt;
	public List<Vector2> dirtLocs;
    public List<Vector2> holeLocs;

    // Private vars
    protected Vector2 location;

    private GameObject hole;
    private GameObject floor;
    private GameObject door;
	private GameObject chimney;

    private Vector2 upDoorOffset = new Vector2(8.83f, 2.08f);
    private Vector2 downDoorOffset = new Vector2(7.22f, 3.56f);
	private Vector2 wallOffset = new Vector2(-3.47f, 4.1f);
	private Vector2 chimneyOffset = new Vector2(-8.4f, 2.95f);

    private DoorController upDoor;
    private DoorController downDoor;

	private GameObject wall;

    // Use this for initialization
    public virtual void Configure () {

        location = GetLevelPos(level);

        // Assign resources
        hole = Resources.Load<GameObject>("Prefabs/Hole");
        floor = Resources.Load<GameObject>("Prefabs/Floor");
        door = Resources.Load<GameObject>("Prefabs/Door");
		wall = Resources.Load<GameObject>("Prefabs/Wall");
		chimney = Resources.Load<GameObject>("Prefabs/Chimney");

        // Instantiate each dirt
        var newDirt = NewObjAtLocs(dirt, dirtLocs, -1.0f);
        foreach (GameObject i in newDirt) {
            SetLevelAsParent(i);
        }

        // Instantiate each hole
		var newHole = NewObjAtLocs(hole, holeLocs, -1.0f);
        foreach (GameObject i in newHole) {
            SetLevelAsParent(i);
        }

        // Make floor
        GameObject obj = Instantiate<GameObject>(
            floor,
            location,
			Quaternion.identity
		);
        SetLevelAsParent(obj);
        obj.GetComponent<IsoRenderOrder>().SetBottom(0);

        // Make wall
        obj = Instantiate<GameObject> (
			wall,
			location + wallOffset,
			Quaternion.identity
		);
        SetLevelAsParent(obj);
        obj.GetComponent<IsoRenderOrder>().SetBottom(1);

        // Make chimney
        obj = Instantiate<GameObject> (
			chimney,
			location + chimneyOffset,
			Quaternion.identity
		);
        SetLevelAsParent(obj);
			
        // Make up door
        obj = Instantiate<GameObject>(
            door,
            location + upDoorOffset,
            Quaternion.identity
        );
        SetLevelAsParent(obj);
        upDoor = obj.GetComponent<DoorController>();
        upDoor.SetUp(true);

        // Make down door
        obj = Instantiate<GameObject>(
            door,
            location + downDoorOffset,
            Quaternion.identity
        );
        SetLevelAsParent(obj);
        downDoor = obj.GetComponent<DoorController>();
        downDoor.SetUp(false);
    }

	private List<T> NewObjAtLocs<T>(T obj, List<Vector2> locs, float zPos) where T:Object {
        List<T> objs = new List<T>();
        for (int i = 0; i < locs.Count; i++) {
            Vector3 pos = new Vector3(
                locs[i].x + location.x,
                locs[i].y + location.y,
                zPos
            );

            objs.Add(
                Instantiate<T>(obj, pos, Quaternion.identity)
            );
		}

        return objs;
	}

    public DoorController GetUpDoor() {
        return upDoor;
    }

    public DoorController GetDownDoor() {
        return downDoor;
    }

    public void LinkUpDoor(DoorController door) {
        upDoor.RegisterLink(door);
    }

    public void LinkDownDoor(DoorController door) {
        downDoor.RegisterLink(door);
    }

    public static void LinkLevels(Level lvl1, Level lvl2) {
        lvl1.LinkDownDoor(lvl2.GetUpDoor());
        lvl2.LinkUpDoor(lvl1.GetDownDoor());
    }

    public void SetRenderOrder(GameObject obj) {
        obj.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(100 * location.y) + 1;
    }

    public void SetLevelAsParent(GameObject obj) {
        obj.transform.parent = gameObject.transform;
        obj.GetComponent<IsoRenderOrder>().LevelNum = level;
    }

    public static Vector2 GetLevelPos(int levelNum) {
        return new Vector2(0f, (levelNum - 1) * -15f);
    }
}
