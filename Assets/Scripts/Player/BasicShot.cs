using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BasicShot : MonoBehaviour {
    
    public AudioClip explosion;
    public GameObject player;
    AudioSource audio;
    public float speed = .5f;
    private PolygonCollider2D collision;
    // Use this for initialization
    void Start () {

        audio = gameObject.GetComponent<AudioSource>();
        collision = GetComponent<PolygonCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
           audio.PlayOneShot(explosion, 1f);

            gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(coll.gameObject);
            Destroy(gameObject, explosion.length);
           // Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            collision.enabled = false;
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void FixedUpdate () {

        transform.Translate(Vector2.up * speed, Space.World);
    }
}
