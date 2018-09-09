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
        } else if (move.magnitude < Vector2.kEpsilon) {
            moveLock = false;
        }

        sr.sortingOrder = Mathf.RoundToInt((20.0f - gameObject.transform.position.y) * 100);
    }

    public void Teleport(Vector2 newLoc) {
        moveLock = true;

        gameObject.transform.position = newLoc;
        rb.velocity = Vector2.zero;

        Vector3 lScale = gameObject.transform.localScale;
        lScale.x = Mathf.Abs(lScale.x) * -1f;
        gameObject.transform.localScale = lScale;
    }
}
