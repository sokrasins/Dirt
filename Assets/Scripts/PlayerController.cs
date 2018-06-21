using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    private Animator playerAnimator;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnimator = gameObject.GetComponent<Animator>();

        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
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
        rb.velocity = move;
        if (rb.velocity.magnitude > Vector2.kEpsilon)
        {
            playerAnimator.SetBool("walking", true);
            Vector3 lScale = gameObject.transform.localScale;
            lScale.x = Mathf.Abs(lScale.x) * Mathf.Sign(move.x);
            gameObject.transform.localScale = lScale;
        } 
        else
        {
            playerAnimator.SetBool("walking", false);
        }
    }
}
