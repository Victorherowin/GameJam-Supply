using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameBGMCtrl : MonoBehaviour {

    [SerializeField] public AudioSource bgm;

    [SerializeField] public AudioSource GameBGM;

    //private bool upFlag;

    // Use this for initialization
    void OnEnable()
    {
        bgm.Play();
        GameBGM.Stop();
    }

    void OnDisable()
    {
        bgm.Stop();
    }
}
