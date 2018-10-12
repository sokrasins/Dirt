using System.Collections.Generic;
using UnityEngine;

public class BroomController : MonoBehaviour
{
    private GameObject dirt;
    private Vector3 offset;

    // Use this for initialization
    void Start() {
        offset = new Vector3(0f, -.05f, 0f);
    }

    // Update is called once per frame
    void Update() {
        if (dirt != null) {
            dirt.transform.position = gameObject.transform.position + offset;
            float sign = Mathf.Sign(gameObject.transform.parent.localScale.x);
            Vector3 lScale = dirt.transform.localScale;
            lScale.x = Mathf.Abs(lScale.x) * sign;
            dirt.transform.localScale = lScale;
        }
    }

    // Called when broom touched anything
    void OnCollisionEnter2D(Collision2D col) {
		if ( dirt == null && col.gameObject.tag == "Dirt" ) {
            dirt = col.gameObject;
            dirt.GetComponent<Dirt>().Sweep();
        }
        else if (dirt != null && col.gameObject.tag == "Hole") {
            Object.Destroy(dirt);
            dirt = null;
        }
    }

    public void Ghost (bool state) {
        gameObject.GetComponent<BoxCollider2D>().enabled = !state;
        if (dirt != null) {
            dirt.GetComponent<SpriteRenderer>().enabled = !state;
        }
    }
}
