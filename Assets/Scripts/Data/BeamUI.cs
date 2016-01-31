using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeamUI : MonoBehaviour {
    Image beamImg;
    public GameObject level1;
    public GameObject level2;
	// Use this for initialization
	void Start ()
    {
        beamImg = GetComponent<Image>();

    }
	
	// Update is called once per frame
	void FixedUpdate() {
	switch (GameData.BeamLevel)
        {
            case 0:
                level1.SetActive(false);
                level2.SetActive(false);
                break;

            case 1:
                level1.SetActive(true);
                level2.SetActive(false);

                break;

            case 2:
                level1.SetActive(false);
                level2.SetActive(true);

                break;
        }
	}
}
