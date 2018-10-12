using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Dirt {

    private Rigidbody2D rb;

    private float moveTime;
	private float lastMoveTime = 0;

    public Ant(Vector2 position) : base(position) {
        // Nothing!
    }

    // Use this for initialization
    new void Start () {
        base.Start();

        rb = gameObject.GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
		lastMoveTime = Time.time;
		moveTime = 0.00001f;
	}

	// Update is called once per frame
	new void Update () {
        base.Update();

		if (lastMoveTime + moveTime < Time.time) {
			rb.velocity = new Vector2(
				Random.Range(-1.0f, 1.0f),
				Random.Range(-1.0f, 1.0f)
			);
			lastMoveTime = Time.time;
		}
	}
}
