using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour {
    public static Matrix mu_ti;
    public int N_Num;
    public int H_Num;
    public int O_Num;
    private int N_Current_Num=0;
    private int H_Current_Num=0;
    private int O_Current_Num=0;
    private Element m_current_element;

    public AudioSource MutiAbsorb;

	// Use this for initialization
	void Start () {
        mu_ti = this;

    }
	
	// Update is called once per frame
	void Update () {
        ui_time.ui_t.h_num = H_Num - H_Current_Num;
        ui_time.ui_t.o_num = O_Num - O_Current_Num;
        ui_time.ui_t.n_num = N_Num - N_Current_Num;
        ui_time.ui_t.score = H_Current_Num * 100 + O_Current_Num * 100 + N_Current_Num * 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            var obj = other.GetComponent<Player>();
            var ele = obj.Element;
            if (ele == null) return;
            if(ele is Element_H || ele is Element_O||ele is Element_N)
            {
                if (ele is Element_H)
                {
                    if (H_Num <= H_Current_Num) return;
                    H_Current_Num++;
                }
                if (ele is Element_O)
                {
                    if (O_Num <= O_Current_Num) return;
                    O_Current_Num++;
                }
                if (ele is Element_N)
                {
                    if (N_Num <= N_Current_Num) return;
                    N_Current_Num++;
                }
                m_current_element = ele;
                other.GetComponent<Player>().ParticleEffect.gameObject.SetActive(false);
                other.GetComponent<Player>().Element = null;
                Destroy(ele.gameObject);

                MutiAbsorb.Play();

                if (H_Num == H_Current_Num && O_Num == O_Current_Num && N_Num == N_Current_Num)
                    ui_time.ui_t.show_finished();
            }

        }
    }
}
