using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomController : MonoBehaviour
{
    private GameObject dirt;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dirt != null)
        {
            dirt.transform.position = gameObject.transform.position;
            float sign = Mathf.Sign(gameObject.transform.parent.localScale.x);
            Vector3 lScale = dirt.transform.localScale;
            lScale.x = Mathf.Abs(lScale.x) * sign;
            dirt.transform.localScale = lScale;
        }
    }

    // Called when broom touched anything
    void OnCollisionEnter2D(Collision2D col)
    {
        if ( dirt == null && col.gameObject.tag == "Dirt" )
        {
            dirt = col.gameObject;
            dirt.GetComponent<DirtController>().sweep();
        }
        else if (dirt != null && col.gameObject.name == "Hole")
        {
            Object.Destroy(dirt);
            dirt = null;
        }
    }
}
