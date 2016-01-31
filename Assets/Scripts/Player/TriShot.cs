using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TriShot : MonoBehaviour
{

    public float speed = .5f;
    public bool right = true;
    public AudioClip explosion;
    AudioSource audio;
    private PolygonCollider2D collision;
    // Use this for initialization
    void Start()
    {

        audio = gameObject.GetComponent<AudioSource>();
        collision = GetComponent<PolygonCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.gameObject.tag == "Enemy")
        //{
        //    collision.enabled = false;
        //    gameObject.GetComponent<Renderer>().enabled = false;
        //    Destroy(gameObject, explosion.length);



        //    // Destroy(gameObject);
        //}

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(right)
        transform.Translate(Vector2.right * speed/2, Space.World);
        else
            transform.Translate(Vector2.right * -speed / 2, Space.World);

        transform.Translate(Vector2.up * speed, Space.World);
    }
}
