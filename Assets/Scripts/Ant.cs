using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Dirt {

	public float moveTime;
	public float moveProb;
	public float velBound;
	public float wiggleBound;

    private Rigidbody2D rb;
	private float lastMoveTime = 0;
	private Vector2 vel;

    public Ant(Vector2 position) : base(position) {
        // Nothing!
    }

    // Use this for initialization
    new void Start () {
        base.Start();

        rb = gameObject.GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
		lastMoveTime = Time.time;
		//moveTime = 0.00001f;
	}

	// Update is called once per frame
	new void Update () {
        base.Update();

		if (Random.value < moveProb) {
			vel = ChangeVel();
		}

		rb.velocity = vel + TinyMotion();

	}

	private Vector2 ChangeVel() {
		return new Vector2(
			Random.Range(-velBound, velBound),
			Random.Range(-velBound, velBound)
		);
	}

	private Vector2 TinyMotion() {
		return new Vector2(
			Random.Range(-wiggleBound, wiggleBound),
			Random.Range(-wiggleBound, wiggleBound)
		);
	}

}
