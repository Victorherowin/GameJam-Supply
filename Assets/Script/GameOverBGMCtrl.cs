using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBGMCtrl : MonoBehaviour {

    [SerializeField] public AudioSource bgm;
    public AudioSource ChaseBGM;

    //private bool upFlag;

    // Use this for initialization
    void OnEnable()
    {
        bgm.Play();
        ChaseBGM.Stop();
    }

    void OnDisable()
    {
        bgm.Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
