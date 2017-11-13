using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    public void RestartGame()
    {
        Application.LoadLevelAsync("q01");
    }

}
