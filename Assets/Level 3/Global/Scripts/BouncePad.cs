using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    //public GameObject player;
    private Vector2 direction;
    public float platformLaunchForce;
    private Animator animator;
    private BoxCollider2D Collider2D;
    // Start is called before the first frame update
    // Update is called once per frame
    [HideInInspector] public AudioSource audioSource;
    public AudioClip[] Sound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Collider2D = GetComponent<BoxCollider2D>();
        Collider2D.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        direction = transform.TransformDirection(Vector2.up * platformLaunchForce);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Fox go bounce :D");
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * platformLaunchForce;
            animator.SetTrigger("Bounce");
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(Sound[Random.Range(0, Sound.Length)], 0.9f);
        }
    }

    public void ActivatePad()
    {
        Collider2D.enabled = true;
    }

    public void DeactivePad()
    {
        Collider2D.enabled = false;
    }
}
