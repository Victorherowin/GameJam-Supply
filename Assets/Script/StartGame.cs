using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    [SerializeField] public GameObject StartCameraObj;
    [SerializeField] public GameObject FreeLookCameraObj;

    [SerializeField] public GameObject StartPlayerObj;
    [SerializeField] public GameObject GamePlayerObj;

    [SerializeField] public GameObject StartUI;
    [SerializeField] public GameObject GameUI;

    [SerializeField] public AudioSource btnPressSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartGame()
    {

        btnPressSound.Play();

        StartCameraObj.SetActive(false);
        FreeLookCameraObj.SetActive(true);

        StartPlayerObj.SetActive(false);
        //StartCameraObj.SetActiveRecursively(false);
        GamePlayerObj.SetActive(true);

        StartUI.SetActive(false);
        GameUI.SetActive(true);

        ui_time.ui_t.game_open=true;

    }

}
