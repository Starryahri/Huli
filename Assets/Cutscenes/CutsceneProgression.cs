using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneProgression : MonoBehaviour
{
    public float WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        if (LevelFlags.gameComplete)
        {
            StartCoroutine(MainMenu());
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Wait
        yield return new WaitForSeconds(WaitTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator MainMenu()
    {
        // Wait
        yield return new WaitForSeconds(WaitTime);

        // Load scene
        SceneManager.LoadScene("TitleMenu");
    }
}
