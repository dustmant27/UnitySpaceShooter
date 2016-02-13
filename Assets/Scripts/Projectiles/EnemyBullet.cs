using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Vector3 playervector;
    public Vector3 setPosition;
    public float step = 2f;
    bool reachedDestination = false;
    float initX;
    float initY;
    float xChange;
    float yChange;
    float newX;
    float newY;
    Vector3 moveVector;
    // Use this for initialization

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playervector = player.transform.position;
        setPosition = playervector;
        // setPosition.x += 30;
        // setPosition.y -= 50;
        //float angle = Mathf.Atan2(setPosition.y, setPosition.x) * Mathf.Rad2Deg - 90;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
        //initX = transform.position.x;
        //initY = transform.position.y;
        Vector3 diff = playervector - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        //  transform.LookAt(playervector);
    }
    void Awake()
    {
    }
    void OnCollisionEnter2D(Collision2D coll)
    {


    }

    void OnTriggerEnter2D(Collider2D coll)
    {

    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up * (step * Time.deltaTime));
        //if (transform.position == setPosition)
        //    reachedDestination = true;

        //if (!reachedDestination)
        //{
        //transform.position = Vector3.MoveTowards(transform.position, setPosition, step * Time.deltaTime);

        //}else
        //{
        //    transform.Translate(Vector3.forward * (step * Time.deltaTime));
        //}
        //transform.Translate(Vector2.down * speed, Space.World);
    }
}
