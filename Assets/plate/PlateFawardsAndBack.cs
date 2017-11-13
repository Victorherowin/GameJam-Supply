using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFawardsAndBack : MonoBehaviour {

    [SerializeField] [Range(3, 100)] public float MaxMoveDirecation;

    private bool IsUp;
    private float MoveDirecation;

    // Use this for initialization
    void Start()
    {

        IsUp = true;

        MoveDirecation = MaxMoveDirecation;


    }

    // Update is called once per frame
    void Update()
    {

        if (IsUp)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            MoveDirecation -= Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            MoveDirecation += Time.deltaTime;
        }


        if (MoveDirecation <= 0)
        {
            IsUp = false;
        }
        else if (MoveDirecation >= MaxMoveDirecation)
        {
            IsUp = true;
        }
    }
}
