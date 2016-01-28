using UnityEngine;
using System.Collections;

public class MoveDown : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 1.0f;
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.up * -speed, Space.World );
    }
}
