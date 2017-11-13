
using UnityEngine;
using System.Collections;

public class LookAtCameraYRotationOnly : MonoBehaviour
{
    public Camera cameraToLookAt;
    public float speed=1;
    private float time=0f;
    private bool directon =false;

    private void Start()
    {
        time = Random.value * 100 - 50;
    }

    void Update()
    {
       
     
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        if (directon)
        {
            time += speed;
        }
        else
        {
            time -= speed;
        }

        if (time >= 50)
        {
            directon = false;
            // time = 0;
        }
        if (time <= -50)
        {
            directon = true;
            //  time = 0;
        }
        float Scale = (time + 100f) / 100f;
        this.transform.localScale = new Vector3(Scale, Scale, Scale);
    }
}