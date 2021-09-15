using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite leverDeactive;
    private Animator Animator;
    //public Sprite leverActive;
    private float Cooldown = 0f;
    public float Recharge = 1f;


    private bool _isLeverActive = false;
    //[HideInInspector] public bool Active = false;
    //public Animator animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CheckLever();
        Debug.Log(CheckLever());
        //spriteRenderer.sprite = leverDeactive;
    }

    private void Update()
    {
        if (Cooldown > 0)
        {
            Cooldown = Cooldown - Time.deltaTime;
        }

        if (Cooldown <= 0 && _isLeverActive)
        {
            Animator.SetTrigger("Reset");
            DeactivateLever();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if (_isLeverActive == false)
            {
                Animator.SetTrigger("Toggle");
                //spriteRenderer.sprite = leverActive;
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.gravityScale = 1;
                ActivateLever();
                Cooldown = Recharge;
                //animator.SetTrigger("Start");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if (_isLeverActive == false)
            {
                Animator.SetTrigger("Toggle");
                //spriteRenderer.sprite = leverActive;
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.gravityScale = 1;
                ActivateLever();
                Cooldown = Recharge;
                //animator.SetTrigger("Start");
            }
        }
    }

            public void ActivateLever()
    {
        _isLeverActive = true;
    }

    public void DeactivateLever()
    {
        _isLeverActive = false;
    }

    public bool CheckLever()
    {
        return _isLeverActive;
    }

    public float CheckCooldown()
    {
        return Cooldown;
    }


}
