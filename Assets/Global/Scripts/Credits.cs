using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnMenu();
        }
    }

    public void ReturnMenu()
    {
        StartCoroutine(LoadLevel("TitleMenu"));
    }

    IEnumerator LoadLevel(string levelIndex)
    {
        // Play animation
        transition.SetTrigger("Transition"); // Parameter in LevelLoader animator

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
