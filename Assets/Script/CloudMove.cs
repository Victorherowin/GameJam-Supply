using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

    [SerializeField] public float MoveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform child in transform)
        {
            child.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            if (child.transform.position.x < -200)
            {
                child.Translate(Vector3.right * 300);
            }
        }
	}
}
