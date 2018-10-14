using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    private Animator playerAnimator;
    private SpriteRenderer sr;
    private bool moveLock;

    // Use this for initialization
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        rb.freezeRotation = true;

        moveLock = false;
    }

    // Update is called once per frame
    void Update() {
        Vector2 move = new Vector2(0.0f, 0.0f);

#if UNITY_STANDALONE || UNITY_WEBGL
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
#elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == 0)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                move.x = touchPos.x - gameObject.transform.position.x;
                move.y = touchPos.y - gameObject.transform.position.y;
            }
        }
#endif

        // Scale vector for speed
        move.Normalize();
        move = move * Mathf.Sqrt(speed);

        // Set velocity, walking state, and sprite orientation
        if (!moveLock) {
            rb.velocity = move;
            if (rb.velocity.magnitude > Vector2.kEpsilon) {
                playerAnimator.SetBool("walking", true);
                Vector3 lScale = gameObject.transform.localScale;
                lScale.x = Mathf.Abs(lScale.x) * Mathf.Sign(move.x);
                gameObject.transform.localScale = lScale;
            } else {
                playerAnimator.SetBool("walking", false);
            }
        } //else if (move.magnitude < Vector2.kEpsilon) {
          //  moveLock = false;
        //}
    }

	private void Ghost (bool state) {
		sr.enabled = !state;
		gameObject.GetComponent<CircleCollider2D> ().enabled = !state;
        GameObject.FindGameObjectsWithTag("Broom")[0].GetComponent<BroomController>().Ghost(state);
    }

    public void Teleport(Vector2 newLoc) {
        moveLock = true;
		Ghost (true);
        playerAnimator.SetBool("walking", false);

        Vector3 lScale = gameObject.transform.localScale;
        lScale.x = Mathf.Abs(lScale.x) * -1f;
        gameObject.transform.localScale = lScale;
        gameObject.GetComponent<IsoRenderOrder>().LevelNum = gameObject.GetComponent<IsoRenderOrder>().LevelNum + 1;

        StartCoroutine (MoveToLoc (newLoc, 0.01f));
    }

	private IEnumerator MoveToLoc(Vector2 newLoc, float waitTime) {
		var timetot = 1f;
		while (((Vector2)gameObject.transform.position-newLoc).magnitude > Vector2.kEpsilon) {
			
			var vel = (Vector3) rb.velocity;
			gameObject.transform.position = Vector3.SmoothDamp (
				gameObject.transform.position, 
				(Vector3)newLoc, 
				ref vel, 
				timetot, 
				Mathf.Infinity, 
				waitTime
			);
			rb.velocity = vel;

			yield return new WaitForSeconds (waitTime);
			timetot -= waitTime;
		}

		rb.velocity = Vector2.zero;
        Ghost(false);
        moveLock = false;
	}
}
