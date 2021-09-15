using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UI;

public class TitleMenu : MonoBehaviour
{
    public string newGame;
    public string levelSelect;
    public string levelSelectMaomi;
    public GameObject levelSelectButton;
    public GameObject levelSelectDummy;
    public GameObject extrasButton;
    public GameObject extrasDummy;
    public string credits;
    public string extras;
    public string theatre;
    public string level1Select;
    public string level2Select;
    public string level3Select;
    public string level4Select;
    public string level01Select;
    public string level02Select;
    public string level03Select;
    public string level04Select;
    // public string level4Select;
    public string characterSelect;
    public Animator transition;
    public float transitionTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        newGame = "Cutscene01";
        level1Select = "Level1 (Tutorial)";
        level2Select = "Level2 (Cave)";
        level3Select = "Level3 (Island)";
        level4Select = "Level4 (Sky)";
        level01Select = "Level1_2 (Tutorial)";
        level02Select = "Level2_2 (Cave)";
        level03Select = "Level3_2 (Island)";
        level04Select = "Level4_2 (Sky)";
        levelSelect = "LevelSelectHuli";
        levelSelectMaomi = "LevelSelectMaomi";
        credits = "Credits";
        extras = "Extras";
        theatre = "ViewCutscenes";
        characterSelect = "CharacterSelect";
        if (LevelFlags.gameComplete == true)
        {
            levelSelectButton.SetActive(true);
            levelSelectDummy.SetActive(false);
            extrasButton.SetActive(true);
            extrasDummy.SetActive(false);
        }
        else
        {
            levelSelectButton.SetActive(false);
            levelSelectDummy.SetActive(true);
            extrasButton.SetActive(false);
            extrasDummy.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Space)) 
        {
            levelSelectButton.interactable = true;
        } */
        if (Input.GetKeyDown(KeyCode.End))
        {
            LevelFlags.gameComplete = !LevelFlags.gameComplete;
            levelSelectButton.SetActive(true);
            levelSelectDummy.SetActive(false);
            extrasButton.SetActive(true);
            extrasDummy.SetActive(false);
        }
    }

    public void NewGame()
    {
        Time.timeScale = 1.0f;
        PauseMenu.GameIsPaused = false;
        //SceneManager.LoadScene(newGameScene);
        StartCoroutine(LoadLevel(newGame));
    }

    public void CharacterSelect()
    {
        Time.timeScale = 1.0f;
        //SceneManager.LoadScene(characterSelect);
        StartCoroutine(LoadLevel(characterSelect));
    }

    public void LevelSelect()
    {
        Time.timeScale = 1.0f;
        //SceneManager.LoadScene(levelSelect);
        StartCoroutine(LoadLevel(levelSelect));

    }
    public void LevelSelectMao()
    {
        //SceneManager.LoadScene(levelSelectMaomi);
        StartCoroutine(LoadLevel(levelSelectMaomi));
        print("Maomi");
    }

    public void Credits()
    {
        //SceneManager.LoadScene(credits);
        StartCoroutine(LoadLevel(credits));
    }
    public void Extras()
    {
        //SceneManager.LoadScene(extras);
        StartCoroutine(LoadLevel(extras));
    }

    // Extras Menu
    public void ViewCutscenes()
    {
        //SceneManager.LoadScene(theatre);
        StartCoroutine(LoadLevel(theatre));
    }

    public void WatchPrologue()
    {
        StartCoroutine(LoadLevel("Cutscene01"));
    }

    public void WatchEpilogue()
    {
        StartCoroutine(LoadLevel("Cutscene02"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level1Select()
    {
        //SceneManager.LoadScene(newGameScene);
        StartCoroutine(LoadLevel(level1Select));
    }
    public void Level2Select()
    {
        //SceneManager.LoadScene(level2Select);
        StartCoroutine(LoadLevel(level2Select));
    }
    public void Level3Select()
    {
        //SceneManager.LoadScene(level3Select);
        StartCoroutine(LoadLevel(level3Select));
    }
    public void Level4Select()
    {
        //SceneManager.LoadScene(level4Select);
        StartCoroutine(LoadLevel(level4Select));
    }

    public void Level01Select()
    {
        //SceneManager.LoadScene(newGameScene);
        StartCoroutine(LoadLevel(level01Select));
    }
    public void Level02Select()
    {
        //SceneManager.LoadScene(level2Select);
        StartCoroutine(LoadLevel(level02Select));
    }
    public void Level03Select()
    {
        //SceneManager.LoadScene(level3Select);
        StartCoroutine(LoadLevel(level03Select));
    }
    public void Level04Select()
    {
        //SceneManager.LoadScene(level4Select);
        StartCoroutine(LoadLevel(level04Select));
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
