using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_ai : MonoBehaviour {

    public AudioSource ChaseBGM;
    public AudioSource GameBGM;

    // Use this for initialization
    private string aim_name= "Player";
    public float vetcor_speed=4.0f;
    public float Demand_Time=3;
    private float time_open_point;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    void OnCollisionEnter(Collision collision)
    {
        
    }

    // 碰撞结束
    void OnCollisionExit(Collision collision)
    {

    }
    */
    //人离开
    private void OnTriggerExit(Collider collision)
    {
        set_gan_tan_hao(false);
        ChaseBGM.Stop();
        GameBGM.Play();
    }


    // 发现人
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals(aim_name))
        {
            time_open_point = Time.time;
        }

        ChaseBGM.Play();
        GameBGM.Stop();

    }
    // 碰撞持续中
    void OnTriggerStay(Collider collision)
    {
        if (!ui_time.ui_t.game_open) return;
        transform.parent.LookAt(collision.transform);
        if (collision.gameObject.name.Equals(aim_name))
        {
            if (Is_angre())
            {
                set_gan_tan_hao(false);
                chase(collision);//追击

            }
            else
            {
                set_gan_tan_hao(true);
            }

        }
    }






    /************************************************/
    private void set_gan_tan_hao(bool open)
    {
        this.transform.parent.Find("model_!").gameObject.SetActive(open);
    }

    private bool Is_angre()
    {
        return Time.time - time_open_point > Demand_Time;
    }

    private void chase(Collider collision)
    {
        Vector3 aim = collision.transform.position;
        Vector3 pos = this.transform.parent.position;
        Vector3 move_dir = Vector3.Normalize(aim - pos) * vetcor_speed;
       // Debug.Log(aim);
        //Debug.Log(move_dir);
        this.transform.parent.position += move_dir * Time.fixedDeltaTime;
    }
}
