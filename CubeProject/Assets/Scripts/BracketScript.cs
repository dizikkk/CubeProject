using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketScript : MonoBehaviour {

    private WinScript WS;
    public Sprite[] Bsprites;
    public GameObject BracketOpen;

	// Use this for initialization
	void Start () {
        WS = GameObject.FindObjectOfType<WinScript>();

	}
	
	// Update is called once per frame
	void Update () {

        if (WS.BspritesId > 1)
            WS.BspritesId = 0;

        gameObject.GetComponent<SpriteRenderer>().sprite = Bsprites[WS.BspritesId];

        if(gameObject.GetComponent<SpriteRenderer>().sprite == BracketOpen.GetComponent<SpriteRenderer>().sprite)
            gameObject.GetComponent<BoxCollider>().enabled = false;
        else
            gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
