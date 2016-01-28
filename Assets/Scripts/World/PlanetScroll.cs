using UnityEngine;
using System.Collections;

public class PlanetScroll : MonoBehaviour {

    // Use this for initialization
    public float speed = .003f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * speed, Space.World);
    }
}
