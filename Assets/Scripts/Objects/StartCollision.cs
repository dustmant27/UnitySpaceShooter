using UnityEngine;
using System.Collections;

public class StartCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.layer == 16)
        coll.gameObject.layer = 9;
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 16)
            coll.gameObject.layer = 9;

    }
}
