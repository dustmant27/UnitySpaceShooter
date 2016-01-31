using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EnemyMoveDown : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 1.0f;
    public float FireDelay = 1f;
    public GameObject basicBullet;
    public float Health = 1f;
    float CurrentTime = 0f;

    AudioSource audio;
    public GameObject itemDrop;
    public float dropChance = 50;

    public AudioClip explosion;
    public int pointValue = 25;
    private PolygonCollider2D collision;
    // Use this for initialization
    void Start()
    {

        audio = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //speed += .0002f;
        if(basicBullet != null)
        {

        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        else
        {
            CurrentTime = FireDelay;
                Instantiate(basicBullet, new Vector3(transform.position.x, transform.position.y - .2f), basicBullet.transform.rotation);

            }
        }
        transform.Translate(Vector2.up * -speed, Space.World);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "MyBullet")
        {
            var damage = coll.gameObject.GetComponent<BulletDamage>();

            Destroy(coll.gameObject);
            Health -= damage.Value;
            if (Health <= 0)
            {
                audio.PlayOneShot(explosion, 1f);
                collision.enabled = false;
                Destroy(gameObject, explosion.length);
                GameData.AddScore(pointValue);
                if (itemDrop != null)
                {
                    var check = Random.Range(0F, 100.0F);

                    if (check <= dropChance)
                        Instantiate(itemDrop, new Vector3(transform.position.x, transform.position.y), itemDrop.transform.rotation);

                }
                gameObject.GetComponent<Renderer>().enabled = false;

            }
           
        }
    }
        void OnDestroy()
    {
       

    }
    public void ItemDrop()
    {
  
    }
}
