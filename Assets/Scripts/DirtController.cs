using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour {

    public Sprite sweptDirt;

    private PolygonCollider2D pc;
    private SpriteRenderer sr;
	private float zPos = -1;

	public DirtController (Vector2 position) {
		gameObject.transform.position = new Vector3(position.x, position.y, zPos);
	}

    // Use this for initialization
    void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        pc = gameObject.GetComponent<PolygonCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		sr.sortingOrder = Mathf.RoundToInt ((20.0f- gameObject.transform.position.y)*100);
	}

    public void sweep()
    {
        sr.sprite = sweptDirt;
        pc.enabled = false;
    }
}
