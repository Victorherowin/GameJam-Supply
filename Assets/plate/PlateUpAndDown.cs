using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateUpAndDown : MonoBehaviour {

    [SerializeField] [Range(3, 100)]public float MaxMoveDirecation;

    private bool IsUp;
    private float MoveDirecation;

	// Use this for initialization
	void Start () {

        IsUp = true;

        MoveDirecation = MaxMoveDirecation;


	}
	
	// Update is called once per frame
	void Update () {

        if (IsUp)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            MoveDirecation -= Time.deltaTime;
        } else
        {
            transform.Translate(Vector3.back * Time.deltaTime);
            MoveDirecation += Time.deltaTime;
        }


        if (MoveDirecation <= 0)
        {
            IsUp = false;
        } else if (MoveDirecation >= MaxMoveDirecation)
        {
            IsUp = true;
        }

        
	}
}
