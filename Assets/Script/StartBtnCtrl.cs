using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StartBtnCtrl : MonoBehaviour {

    [SerializeField] public AudioSource bgm;
    [SerializeField] public GameObject Elements;
    [SerializeField] public GameObject Plates;
    //private bool upFlag;

    // Use this for initialization
    void OnEnable()
    {
        bgm.Play();
        Elements.SetActive(false);
        Plates.SetActive(false);
    }

    void OnDisable()
    {
        bgm.Stop();
        Elements.SetActive(true);
        Plates.SetActive(true);
    }

    private void Update()
    {
        //CanvasGroup cg = transform.GetComponent<CanvasGroup>();
        //if (cg.alpha <= 0)
        //{
        //    upFlag = true;
        //} else  if (cg.alpha >= 1) {
        //    upFlag = false;
        //}

        //if (upFlag)
        //{
        //    cg.alpha += Time.deltaTime;
        //} else
        //{
        //    cg.alpha -= Time.deltaTime;
        //}
        

    }

}
