using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour {
    public GameObject Player;
	// Use this for initialization
	void Start () {
        Player.GetComponent<Player>().AddElement(new Element_N());
        //Player.GetComponent<Player>().AddElement(new Element_H());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
