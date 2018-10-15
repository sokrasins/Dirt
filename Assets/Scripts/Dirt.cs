using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dirt : MonoBehaviour {

    protected PolygonCollider2D pc;
    protected SpriteRenderer sr;
    private float zPos = -1;

    [SerializeField]
    public Sprite Swept {
        get { return swept; }
        set { swept = value; }
    }
    public Sprite swept;

    public Dirt(Vector2 position) {
        gameObject.transform.position = new Vector3(position.x, position.y, zPos);
    }

    // Use this for initialization
    public void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        pc = gameObject.GetComponent<PolygonCollider2D>();
    }
	
	// Update is called once per frame
	public void Update () {
        
    }

    public void Sweep() {
        sr.sprite = swept;
        pc.enabled = false;
        gameObject.GetComponent<Transform>().localScale = new Vector3(0.15f, 0.15f, 0.15f);
        SweepCallback();
    }

    public virtual void SweepCallback() { ; }
}
