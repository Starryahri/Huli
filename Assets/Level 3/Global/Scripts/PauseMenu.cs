using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject confirmUI;
    //public GameObject levelSelectButton;
    //public GameObject levelSelectDummy;
    public GameObject confirmMain;

    private string resume;
    private string levelSelect;
    private string mainMenu;
    private string characterSelect;

    // Update is called once per frame
    void Start()
    {
        resume = "Resume";
        levelSelect = "LevelSelect";
        mainMenu = "TitleMenu";
        characterSelect = "CharacterSelect";
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        confirmMain.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(DelayPause());
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        /*
        if (LevelFlags.gameComplete == true)
        {
            levelSelectButton.SetActive(true);
            levelSelectDummy.SetActive(false);
        }
        else
        {
            levelSelectButton.SetActive(false);
            levelSelectDummy.SetActive(true);
        }
        */

        Time.timeScale = 0f;

        GameIsPaused = true;
        Debug.Log(GameIsPaused);
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Game...");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void YesConfirm()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(mainMenu);
        Resume();
    }
    public void NoConfirm()
    {
        pauseMenuUI.SetActive(true);
        confirmMain.SetActive(false);
    }

    public void MainConfirm()
    {
        pauseMenuUI.SetActive(false);
        confirmMain.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public IEnumerator DelayPause()
    {
        yield return new WaitForSeconds(0.25f);
        GameIsPaused = false;
        Debug.Log(GameIsPaused);
    }
}
