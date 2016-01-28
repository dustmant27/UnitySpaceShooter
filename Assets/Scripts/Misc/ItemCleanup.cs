using UnityEngine;
using System.Collections;

public class ItemCleanup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
            Destroy(coll.gameObject);
        

    }
}
