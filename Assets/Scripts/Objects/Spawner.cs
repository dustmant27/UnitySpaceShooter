using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    public float timerMax = 300;
    private float timer = 0;
    public float SpawnChance = 2;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
           var check = Random.Range(0F, 10.0F);
            if(check <= SpawnChance)
            {

                Instantiate(enemy, transform.position, enemy.transform.rotation);
            }
            timer = timerMax;
        }
	}
}
