using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int numDirt;
    public DirtController dirt;
    public EdgeCollider2D ecBg;
    public PolygonCollider2D pcHole;
    public GameObject player;
	//public DoorController door;

	private 

	// Use this for initialization
	void Start () {
        SetupLevel(numDirt);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetGame();
        }

		/*
		if (DirtLeft () == 0) {
			
		}
		*/
	}

    void ResetGame() {        
        GameObject[] leftoverDirt;
        leftoverDirt = GameObject.FindGameObjectsWithTag("Dirt");

        foreach (GameObject dirt in leftoverDirt)
        {
            Destroy(dirt);
        }

        player.transform.position = new Vector3(0.0f, 0.0f, -1.0f);

        SetupLevel(numDirt);
    }

    void SetupLevel(int dirtPiles)
    {
        for (int i = 0; i < numDirt; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-ecBg.bounds.extents.x, ecBg.bounds.extents.x) * 0.5f,
                Random.Range(-ecBg.bounds.extents.y, ecBg.bounds.extents.y) * 0.5f,
                0.0f
            );

            if (ecBg.bounds.Contains(pos))
            {
                pos.z = -1.0f;
                if (!pcHole.bounds.Contains(pos))
                {
                    Instantiate(dirt, pos, Quaternion.identity);
                }
            }
        }
    }

	int DirtLeft() {
		return GameObject.FindGameObjectsWithTag("Dirt").Length;
	}
}
