﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EnemyShot : MonoBehaviour
{

    public AudioClip explosion;
    public GameObject player;
    AudioSource audio;
    public float speed = .5f;
    // Use this for initialization
    void Start()
    {

        audio = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    { 
    //    if (coll.gameObject.tag == "Player")
    //    {
    //        audio.PlayOneShot(explosion, 1f);

    //        gameObject.GetComponent<Renderer>().enabled = false;
    //        Destroy(coll.gameObject);
    //        Destroy(gameObject, explosion.length);
    //        // Destroy(gameObject);
    //    }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Destroy(coll.gameObject);
            //Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(Vector2.down * speed, Space.World);
    }
}
