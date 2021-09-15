using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite leverActive;
    //public Sprite leverDeactive;
    private Animator Animator;
    [HideInInspector] public AudioSource audioSource;
    public AudioClip[] Sound;

    private bool _isLeverActive = false;
    //[HideInInspector] public bool Active = false;
    //public Animator animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        CheckLever();
        //spriteRenderer.sprite = leverDeactive;
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if (_isLeverActive == false)
            {
                spriteRenderer.sprite = leverActive;
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.gravityScale = 1;
                ActivateLever();
                Animator.SetTrigger("Toggle");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if (_isLeverActive == false)
            {
                spriteRenderer.sprite = leverActive;
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.gravityScale = 1;
                ActivateLever();
                Animator.SetTrigger("Toggle");
            }
        }
    }

    public void ActivateLever()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(Sound[Random.Range(0, Sound.Length)], 0.45f);
        _isLeverActive = true;
    }

    public void DeactivateLever()
    {
        _isLeverActive = false;
        Animator.SetTrigger("Reset");
        //spriteRenderer.sprite = leverDeactive;
    }

    public bool CheckLever()
    {
        return _isLeverActive;
    }

}
