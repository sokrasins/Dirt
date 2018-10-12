using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntDirtController : MonoBehaviour {

	public Sprite sweptDirt;
	private float moveTime;

	private PolygonCollider2D pc;
	private SpriteRenderer sr;
	private float zPos = -1;

	private float lastMoveTime = 0;
	private Rigidbody2D rb;

	public AntDirtController (Vector2 position) {
		gameObject.transform.position = new Vector3(position.x, position.y, zPos);
	}

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
		pc = gameObject.GetComponent<PolygonCollider2D>();
		rb = gameObject.GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
		lastMoveTime = Time.time;
		moveTime = 0.00001f;
	}

	// Update is called once per frame
	void Update () {
		sr.sortingOrder = Mathf.RoundToInt ((20.0f- gameObject.transform.position.y)*100);

		if (lastMoveTime + moveTime < Time.time) {
			rb.velocity = new Vector2(
				Random.Range(-1.0f, 1.0f),
				Random.Range(-1.0f, 1.0f)
			);
			lastMoveTime = Time.time;
		}
	}

	public void sweep()
	{
		sr.sprite = sweptDirt;
		pc.enabled = false;
	}
}
