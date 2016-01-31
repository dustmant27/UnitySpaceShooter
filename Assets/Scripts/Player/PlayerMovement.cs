using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    public GameObject basicBullet;
    public GameObject doubleBullet;
    public GameObject triLeftBullet;
    public GameObject triMidBullet;
    public GameObject triRightBullet;
    public float FireDelay = .2f;
    public AudioClip pickUp;
    public AudioClip explosion;
    public AudioClip shoot;
    AudioSource audio;
    float CurrentTime = 0f;
    private Rigidbody2D rb;
    private Vector3 respawnPoint;

    private GameObject basicPlayer;
    public int upgradeLevel = 0;
    private float respawnTimer = 0;
    bool dead = false;
    bool fireBoost = false;
    private PolygonCollider2D collision;

    private GameObject gameOver;
    private GameObject normalFace;
    private GameObject hurtFace;
    private GameObject happyFace;

    private float maxFaceTimer = 1f;
    private float faceTimer = 0f;
public GameObject picture;
    void Awake()
    {

         gameOver = GameObject.Find("GameOver");
        normalFace = GameObject.Find("NormalFace");
        hurtFace = GameObject.Find("HurtFace");
        happyFace = GameObject.Find("HappyFace");
        gameOver.SetActive(false);
        normalFace.SetActive(false);
        hurtFace.SetActive(false);
        happyFace.SetActive(false);
    }
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        respawnPoint = gameObject.transform.position;
        basicPlayer = gameObject;
        collision = GetComponent<PolygonCollider2D>();
    }
    public void StartFireSpeedBoost()
    {
        if (!fireBoost)
        {

        }
    }
	void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.up * (rb.mass * Mathf.Abs(Physics.gravity.y)));


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //transform.Translate(Vector2.right * speed);
            rb.AddForce(transform.right * speed * Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {

            //transform.Translate(Vector2.right * -speed);
            rb.AddForce(transform.right * speed * Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            //transform.Translate(Vector2.up * speed);
            rb.AddForce(transform.up * speed * Input.GetAxis("Vertical"));
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {

            // transform.Translate(Vector2.up * -speed);
            rb.AddForce(transform.up * speed * Input.GetAxis("Vertical"));
        }
    }
	// Update is called once per frame
	void Update () {
        //Debug.Log(CurrentTime);
        if(CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        if(faceTimer > 0)
        {
            faceTimer -= Time.deltaTime;
        }
        else
        {
            

            normalFace.SetActive(true);
            hurtFace.SetActive(false);
            happyFace.SetActive(false);
            if (GameData.GameOver)
            {
                hurtFace.SetActive(true);
            }
        }
        if(respawnTimer > 0)
        {
            respawnTimer -= Time.deltaTime;
        }
        else if(respawnTimer <= 0 && dead)
        {
           // dead = false;
           // collision.enabled = true;
          //  gameObject.transform.position = respawnPoint;
          //  picture.GetComponent<Renderer>().enabled = true;
          //  gameObject.GetComponent<Renderer>().enabled = true;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetButton("Fire1") && CurrentTime <= 0 && !dead)
        {
            CurrentTime = FireDelay;
            audio.PlayOneShot(shoot, .15f);
            switch (GameData.BeamLevel)
            {
                case 0:
                    //single shot
                    Instantiate(basicBullet, new Vector3(transform.position.x, transform.position.y + .15f), basicBullet.transform.rotation);
                    break;
                case 1:
                    //double shot
                    GameObject doubBullet = Instantiate(doubleBullet, new Vector3(transform.position.x , transform.position.y + .48f), doubleBullet.transform.rotation) as GameObject;
                    break;
                case 2:
                    //tri shot 
                    Instantiate(triRightBullet, new Vector3(transform.position.x + .1f, transform.position.y + .25f), triRightBullet.transform.rotation);
                    Instantiate(triMidBullet, new Vector3(transform.position.x, transform.position.y + .25f), basicBullet.transform.rotation);
                    Instantiate(triLeftBullet, new Vector3(transform.position.x - .1f, transform.position.y + .25f), triLeftBullet.transform.rotation);
                    break;


            }


            //Physics2D.IgnoreCollision(doubBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            // Instantiate(basicBullet, new Vector3(transform.position.x - .2f, transform.position.y + .15f), basicBullet.transform.rotation);



        }
       
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.gameObject.tag != "Border")
        {
        if (coll.gameObject.tag != "MyBullet" && coll.gameObject.tag != "Pickup")
            {
                Destroy(coll.gameObject);
                if (GameData.BeamLevel > 0)
                {

                    normalFace.SetActive(false);
                    hurtFace.SetActive(true);
                    happyFace.SetActive(false);
                    faceTimer = maxFaceTimer;

                    audio.PlayOneShot(explosion, 0.8F);
                    GameData.BeamLevel--;
                }
                else
                {
                    audio.PlayOneShot(explosion, 0.8F);
                    dead = true;
                    collision.enabled = false;
                    // respawnTimer = 3f;
                    GameData.GameOver = true;
                    normalFace.SetActive(false);
                    hurtFace.SetActive(true);
                  //  picture.GetComponent<Renderer>().enabled = false;
                    gameObject.GetComponent<Renderer>().enabled = false;
                    gameOver.SetActive(true);
                }
            }
            if (coll.gameObject.tag == "Pickup")
            {
                //upgradeLevel++;
                //if (upgradeLevel > 2)
                //{
                //    FireDelay -= .01f;
                //}
                normalFace.SetActive(false);
                hurtFace.SetActive(false);
                happyFace.SetActive(true);
                faceTimer = maxFaceTimer;
                audio.PlayOneShot(pickUp, 0.8F);
                //Destroy(coll.gameObject);
            }

            if (coll.gameObject.tag == "EnemyBullet")
            {
                Destroy(coll.gameObject);
                if (GameData.BeamLevel > 0)
                {

                    audio.PlayOneShot(explosion, 0.8F);
                    GameData.BeamLevel--;
                }
                else
                {
  audio.PlayOneShot(explosion, 0.8F);
                dead = true;
                collision.enabled = false;
                    // respawnTimer = 3f;

                    GameData.GameOver = true;
                    normalFace.SetActive(false);
                    hurtFace.SetActive(true);
                    //picture.GetComponent<Renderer>().enabled = false;
                gameObject.GetComponent<Renderer>().enabled = false;
                    gameOver.SetActive(true);
                }
              
                

            }

        }

    }
     void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Pickup")
        {
            Destroy(coll.gameObject);
        }

    }
    void MovePlayer()
    {
      
    }

}
