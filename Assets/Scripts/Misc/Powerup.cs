using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
    public PublicVariables.PowerupType type;
    public int pointValue = 50;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {

        var playerInfo = coll.gameObject.GetComponent<PlayerMovement >();
            switch (type)
            {
                case PublicVariables.PowerupType.weapon:
                    GameData.UpgradeCurrentWeapon();
                    break;
                case PublicVariables.PowerupType.speed:
                    playerInfo.FireDelay -= .02f;
                    break;
                case PublicVariables.PowerupType.points:
                    
                    GameData.AddScore(pointValue);
                    break;
            }
            Destroy(gameObject);
            }
        }

    }
