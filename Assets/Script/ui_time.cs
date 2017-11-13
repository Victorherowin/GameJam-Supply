using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_time : MonoBehaviour
{
    static public ui_time ui_t;
    public GameObject finished_canvas;
    public GameObject game_over_canvas;
    public GameObject GameCanvas;
    public int secend;
    public int score = 0;
    public int n_num = 0;
    public int h_num = 0;
    public int o_num = 0;
    private static int task_num = 1;



    public int open_time;
    public bool game_open;
    // public int game_state;//游戏状态。

    private bool set_open_time;
    public Text secend_text;
    public Text score_text;
    public Text n_num_text;
    public Text h_num_text;
    public Text o_num_text;
    public Text task_text;

    public Text FinishedTimeText;
  


    // Use this for initialization
    void Awake()
    {
        ui_t = this;
        //text = this.transform.GetComponent<Text>();
        open_time = (int)Time.time;
        game_open = false;
        set_open_time = true;
        Gui_wait_number(score, score_text);
        Gui_wait_number(n_num, n_num_text);
        Gui_wait_number(h_num, h_num_text);
        Gui_wait_number(o_num, o_num_text);
        Gui_wait_number(task_num, task_text);
    }

    // Update is called once per frame
    void Update()
    {
        if (game_open)
        {

            if (set_open_time)
            {
                set_task();//设置任务


                secend = 0;
                open_time = (int)Time.time;
                set_open_time = false;
            }
            secend = 99 - ((int)Time.time - open_time);
            if (secend == 0)
                show_game_over();
        }
        else
        {
            Gui_wait_number(secend, secend_text);
        }
        Gui_wait_number(secend, secend_text);
        Gui_wait_number(score, score_text);
        Gui_wait_number(n_num, n_num_text);
        Gui_wait_number(h_num, h_num_text);
        Gui_wait_number(o_num, o_num_text);
        Gui_wait_number(secend, FinishedTimeText);
    }

    private void set_task()//设置任务
    {

        int task_all_num = (int)((1f + task_num) * (1.2f));//要找的所有的小球数量
        n_num = Mathf.Min(10,(int)(Random.value * task_all_num));

        int h_add_0_num = task_all_num - n_num;
        h_num = Mathf.Min(10, (int)(Random.value * h_add_0_num));
        o_num = Mathf.Min(10, h_add_0_num - h_num);
        task_num++;
        Matrix.mu_ti.N_Num = n_num;
        Matrix.mu_ti.H_Num = h_num;
        Matrix.mu_ti.O_Num = o_num;
    }

    public void show_finished()
    {
        finished_canvas.SetActive(true);
        GameCanvas.SetActive(false);
        game_open = false;
        Gui_wait_number(task_num-1, task_text);
    }

    public void show_game_over()
    {
        game_over_canvas.SetActive(true);
        GameCanvas.SetActive(false);
        game_open = false;

        Animator player_ani = GameObject.Find("xiaobai_jump_4").GetComponent<Animator>();
        player_ani.SetBool("die", true);
        task_num = 1;

    }

    public void set_back_main()
    {
        task_num = 1;
    }

    public void set_retry()
    {
        task_num --;
    }

    void Gui_wait_number(int num, Text ui_text)
    {
        ui_text.text = num.ToString();
    }
}
