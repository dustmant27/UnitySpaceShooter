using UnityEngine;
using System.Collections;

public class BulletBorder : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.transform.tag == "MyBullet" || coll.transform.tag == "EnemyBullet")
        Destroy(coll.gameObject);

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "MyBullet" || coll.transform.tag == "EnemyBullet")
            Destroy(coll.gameObject);


    }
}
