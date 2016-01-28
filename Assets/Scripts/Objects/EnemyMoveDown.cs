using UnityEngine;
using System.Collections;

public class EnemyMoveDown : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 1.0f;
    public float FireDelay = 1f;
    public GameObject basicBullet;
    float CurrentTime = 0f;
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
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
}
