using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_control : MonoBehaviour {
    private Animator ani;
    // Use this for initialization
    private bool jump = false;
    void Start () {
        ani = this.transform.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        float up_down = Input.GetAxis("Vertical");
        up_down = (up_down + 1) / 2;
        ani.SetFloat("Blend", up_down);
        /*
        bool is_second_jump = this.transform.parent.GetComponent<PlayerMove>().is_second_jump;


        if (Input.GetButton("Jump") && !is_second_jump)
        {
            if(!jump)
            {
                ani.SetBool("jump", true);
                jump = true;
            }
            else
            {
                ani.SetBool("jump", false);
                //jump = false;
            }
        }
        else
        {
            jump = false;
        }
        */
    }
}
