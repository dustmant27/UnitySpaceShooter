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
    public int upgradeLevel = 0;
    public GameObject picture;    
    public bool invulnerable = false;
    public float invulTimer = 2.0f;

    AudioSource audio;
     Rigidbody2D rb;
     Vector3 respawnPoint;

     GameObject basicPlayer;
     PolygonCollider2D collision;
     GameObject gameOver;
     GameObject normalFace;
     GameObject hurtFace;
     GameObject happyFace;
    Animator animator;
    Animator thrustAnimator;
     float maxFaceTimer = 1f;
     float faceTimer = 0f;
     float respawnTimer = 0;
    bool dead = false;
    bool fireBoost = false;
    float CurrentTime = 0f;
    bool rightAnim = false;
    bool leftAnim = false;
    bool upAnim = true;
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
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        respawnPoint = gameObject.transform.position;
        basicPlayer = gameObject;
        collision = GetComponent<PolygonCollider2D>();
        foreach (Transform child in transform)
            thrustAnimator = child.GetComponent<Animator>();
        thrustAnimator.SetBool("MoveUp", upAnim);
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
            if (!rightAnim)
            {
                rightAnim = true;
            animator.SetBool("MoveRight", rightAnim);
            }
            //transform.Translate(Vector2.right * speed);
            rb.AddForce(transform.right * speed * Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
          
            if (!leftAnim)
            {
                leftAnim = true;
                animator.SetBool("MoveLeft", leftAnim);
            }
            //transform.Translate(Vector2.right * -speed);
            rb.AddForce(transform.right * speed * Input.GetAxis("Horizontal"));
        }
        else
        {
            rightAnim = false;
            animator.SetBool("MoveRight", rightAnim);
            leftAnim = false;
            animator.SetBool("MoveLeft", leftAnim);

        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!upAnim)
            {
                upAnim = true;
                thrustAnimator.SetBool("MoveUp", upAnim);
            }
            //transform.Translate(Vector2.up * speed);
            rb.AddForce(transform.up * speed * Input.GetAxis("Vertical"));
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {

            if (upAnim)
            {
                upAnim = false;
                thrustAnimator.SetBool("MoveUp", upAnim);
            }
            // transform.Translate(Vector2.up * -speed);
            rb.AddForce(transform.up * speed * Input.GetAxis("Vertical"));
        }
        else
        {

            if (!upAnim)
            {
                upAnim = true;
                thrustAnimator.SetBool("MoveUp", upAnim);
            }
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
            CurrentTime = GameData.BeamFireSpeed;
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
                default:
                    //tri shot 
                    Instantiate(triRightBullet, new Vector3(transform.position.x + .1f, transform.position.y + .25f), triRightBullet.transform.rotation);
                    Instantiate(triMidBullet, new Vector3(transform.position.x, transform.position.y + .25f), basicBullet.transform.rotation);
                    Instantiate(triLeftBullet, new Vector3(transform.position.x - .1f, transform.position.y + .25f), triLeftBullet.transform.rotation);
                    break;


            }


            //Physics2D.IgnoreCollision(doubBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            // Instantiate(basicBullet, new Vector3(transform.position.x - .2f, transform.position.y + .15f), basicBullet.transform.rotation);



        }
        if (invulTimer > 0) {
            invulTimer -= Time.deltaTime;
        } else if (invulnerable) {
            invulnerable = false;
            Color thisColor = gameObject.GetComponent<Renderer>().material.color;
            thisColor.a = 1;
            gameObject.GetComponent<Renderer>().material.color = thisColor;
        }
       
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if(coll.gameObject.tag != "Border")
        {
        if (coll.gameObject.tag != "MyBullet" && coll.gameObject.tag != "Pickup" && !invulnerable)
            {
                Destroy(coll.gameObject);
                TakeDamage();
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

            if (coll.gameObject.tag == "EnemyBullet" && !invulnerable)
            {

                Destroy(coll.gameObject);
                TakeDamage();

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

    void TakeDamage() {
        if (GameData.BeamLevel > 0)
        {
            // Invulnerability sequence
            Color thisColor = gameObject.GetComponent<Renderer>().material.color;
            thisColor.a = 0.5f;
            gameObject.GetComponent<Renderer>().material.color = thisColor;
            invulnerable = true;
            invulTimer = 3f;

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
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            gameOver.SetActive(true);
        }
    }

}
