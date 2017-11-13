using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class is_next : MonoBehaviour {

    public StartGame game_manager;
	// Use this for initialization
	void Start () {
		if(int.Parse(ui_time.ui_t.task_text.text)!=1)
        {
            game_manager.OnStartGame();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
