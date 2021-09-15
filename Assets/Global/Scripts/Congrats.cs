using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    public void Start()
    {
        LevelFlags.gameComplete = true;
    }

    public void LoadMaomi() {
        SceneManager.LoadScene("Credits");
    }
}
