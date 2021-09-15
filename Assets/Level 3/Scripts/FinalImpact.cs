using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalImpact : MonoBehaviour
{
    [HideInInspector] public Animator transition;
    [HideInInspector] public GameObject Player;
    public GameObject Particles;
    private bool Triggered = false;
    public float transitionTime = 1f;

    void Start()
    {
        transition = GameObject.Find("/Canvas/Transition").GetComponent<Animator>();
        Player = GameObject.Find("CHAR");
        LoadNextLevel();
    }

    private void Update()
    {
        if (Player = null)
        {
            Debug.Log("Tried to find player again!");
            Player = GameObject.Find("CHAR");
        }
    }

    private void FixedUpdate()
    {
        GameObject go = Instantiate(Particles, Player.transform.position, Quaternion.identity) as GameObject;
        Destroy(go, 3f);
    }

    public void LoadNextLevel()
    {
        if (Triggered == false)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            //StartCoroutine(LoadLevel());
            Triggered = true;
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Transition"); // Parameter in LevelLoader animator

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }

}
