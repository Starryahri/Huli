using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSphere : MonoBehaviour
{
    public GameObject Flash;
    public GameObject Impact;
    public GameObject Player;
    public float Speed;
    public float Increment = 0.002f;
    public bool Awake = false;

    public GameObject Magic;
    public GameObject Sphere;
    public Animator transition;
    private bool Triggered = false;
    public GameObject Particles;
    public float transitionTime = 9f;

    private void Update()
    {
        if (Awake && PauseMenu.GameIsPaused == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (Triggered)
        {
        GameObject go = Instantiate(Particles, Player.transform.position, Quaternion.identity) as GameObject;
        Destroy(go, 3f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Awake = true;
            Speed += 0.002f;
            GameObject go = Instantiate(Flash, transform.position, Quaternion.identity) as GameObject;
            Destroy(go, 2f);
        }
        if (collision.tag == "Player")
        {
            if (Triggered == false)
            {
                GameObject go = Instantiate(Flash, transform.position, Quaternion.identity) as GameObject;
                Destroy(go, 2f);
                GameObject im = Instantiate(Impact, Player.transform.position, Quaternion.identity) as GameObject;
                Destroy(im, 20f);
                Magic.SetActive(false);
                Sphere.SetActive(false);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
                Triggered = true;
            }
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
