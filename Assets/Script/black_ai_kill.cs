using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_ai_kill : MonoBehaviour {

    // Use this for initialization

    public string aim_name = "Player";


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals(aim_name))
        {
            // ui_time.ui_t.game_open = false;
            ui_time.ui_t.show_game_over();
            Debug.Log(collision.gameObject.name);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals(aim_name))
        {
            // ui_time.ui_t.game_open = false;
            ui_time.ui_t.show_game_over();
            Debug.Log(collision.gameObject.name);
        }
    }

}
