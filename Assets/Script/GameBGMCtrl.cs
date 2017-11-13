using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGMCtrl : MonoBehaviour {

    [SerializeField] public AudioSource bgm;

    //private bool upFlag;

    // Use this for initialization
    void OnEnable()
    {
        bgm.Play();
    }

    void OnDisable()
    {
        bgm.Stop();
    }
}
