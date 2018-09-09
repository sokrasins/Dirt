using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    private SpriteRenderer sr;
    private Vector2 spawnOffset;
    private DoorController link;

    void Awake() {
        sr = gameObject.GetComponent<SpriteRenderer>();
        spawnOffset = new Vector2(-0.7f, -1.27f);
    }

    // Use this for initialization
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.GetComponent<PlayerController>().Teleport(link.TeleportLoc());
    }

    public void SetUp(bool dir) {
        if (dir) {
            sr.sprite = Resources.Load<Sprite>("Sprites/upwardDoor");
        } else {
            sr.sprite = Resources.Load<Sprite>("Sprites/downwardDoor");
        }
    }

    public void RegisterLink(DoorController door) {
        link = door;
    }

    public Vector3 TeleportLoc() {
        return gameObject.transform.position + (Vector3)spawnOffset;
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
}
