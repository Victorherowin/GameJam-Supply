using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_aim : MonoBehaviour {

    // Use this for initialization
    public GameObject aim;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(aim.transform);
    }
}
