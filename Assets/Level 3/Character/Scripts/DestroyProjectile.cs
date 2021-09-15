using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cirCol;
    [HideInInspector] public bool Falling = false;
    public GameObject Trail;
    public GameObject Hit;
    [HideInInspector] public AudioSource audioSource;
    public AudioClip ThrowSFX;
    public AudioClip HitSFX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cirCol = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();

        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(ThrowSFX, 0.7f);
    }

    private void Update()
    {
        if (!Falling && !PauseMenu.GameIsPaused)
        {
            GameObject newTrail = Instantiate(Trail, transform.position, transform.rotation);
            Destroy(newTrail, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Lever") || other.gameObject.CompareTag("Enemy"))
        {
            if (!Falling)
            {
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.PlayOneShot(HitSFX, 0.9f);

                GameObject newHit = Instantiate(Hit, transform.position, transform.rotation);
                Destroy(newHit, 4f);

                Falling = true;
                rb.velocity = Vector2.zero;
                cirCol.enabled = false;
                rb.gravityScale = 1;
                Destroy(this.gameObject, 3f);
            }
        }
    }
}
