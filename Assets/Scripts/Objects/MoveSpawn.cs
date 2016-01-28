using UnityEngine;
using System.Collections;

public class MoveSpawn : MonoBehaviour {
    float leftBoundary = -7.0f;
    float rightBoundary = 7.0f;
    Bounds test;
    bool right = true;
	// Use this for initialization
	void Start () {
        test= Camera.main.OrthographicBounds();
        if (Random.value >= .5)
            right = true;
        else
            right = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x >= test.max.x - .5f)
            right = false;
        if (transform.position.x <= test.min.x + .5f)
            right = true;

        if(right == true)
            transform.Translate(Vector2.right * .1f);
        else
            transform.Translate(Vector2.right * -.1f);
    }
}
