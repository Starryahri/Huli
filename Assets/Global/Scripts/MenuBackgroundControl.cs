using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundControl : MonoBehaviour
{
    public GameObject HuliBackground;
    public GameObject MaomiBackground;
    void Update()
    {
        if (LevelFlags.gameComplete == true)
        {
            MaomiBackground.SetActive(true);
            HuliBackground.SetActive(false);
        }
        else
        {
            MaomiBackground.SetActive(false);
            HuliBackground.SetActive(true);
        }
    }
}
