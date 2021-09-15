using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Char_Controller2 : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] private float RunSpeed = 50f;
    [SerializeField] private float JumpForce = 100f;
    private float HorizontalMove = 0f;
    private float Horizontal = 0f;
    [HideInInspector] public bool FacingRight = true;
    [HideInInspector] public bool IsJumping = false;
    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool WallCollision = false;
    [SerializeField] private Animator animator;
    private SpriteRenderer SpriteRenderer;

    private float fadeStart = 0;
    private float fadeTime = 0.95f;
    private Color objectColor = Color.white;
    private Color fadeColor = Color.black;

    [HideInInspector] public AudioSource audioSource;
    public AudioClip[] WalkHard;
    public AudioClip[] WalkSoft;
    public AudioClip[] WalkWet;
    public AudioClip JumpSFX;
    public AudioClip[] LandSFX;
    public float HardFall = 0.8f;

    private float Airtime = 0f;
    private int FloorType = 0;

    private bool MovementEnabled = true;
    private Vector2 mouse;

    [HideInInspector] public bool DoubleJump = false;
    private float DoubleTrail = 0f;
    public GameObject DoubleJumpPoof;
    public GameObject DoubleJumpTrail;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        animator.SetBool("Grounded", IsGrounded);

        //Jump input
        if (Input.GetButtonDown("Jump") && MovementEnabled)
        {
            IsJumping = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            IsJumping = false;
        }

        //Walk input
        Horizontal = Input.GetAxisRaw("Horizontal");

    }



    void FixedUpdate()
    {
        if (DoubleTrail > 0)
        {
            DoubleTrail -= Time.fixedDeltaTime;
            GameObject JumpTrail = Instantiate(DoubleJumpTrail, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
            Destroy(JumpTrail, 3f);
        }


        //Horizontal movement
        if (WallCollision == true)
        {
            HorizontalMove = 0;
        }

        if (WallCollision == false)
        {
            HorizontalMove = Horizontal * RunSpeed * Time.fixedDeltaTime;
        }



        // Running movement
        if (MovementEnabled)
        {
            rigidbody2d.velocity = new Vector2(HorizontalMove, rigidbody2d.velocity.y);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        // Flipping the player to face the direction of movement
        if (MovementEnabled)
        {
            if (Horizontal > 0 && !FacingRight)
            {
                Flip();
            }
            else if (Horizontal < 0 && FacingRight)
            {
                Flip();
            }
        }

        // Jumping
        if (IsJumping == true && IsGrounded == true)
        {
            Jump();
            rigidbody2d.velocity = new Vector2(0, JumpForce * Time.fixedDeltaTime);
            IsJumping = false;
        }

        if (IsJumping == true && IsGrounded == false && DoubleJump == false)
        {
            DoDouble();
            Jump();
            rigidbody2d.velocity = new Vector2(0, JumpForce * 1.2f * Time.fixedDeltaTime);
            DoubleJump = true;
            GameObject JumpPoof = Instantiate(DoubleJumpPoof, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.identity);
            Destroy(JumpPoof, 3f);
            DoubleTrail = 0.35f;
            animator.SetTrigger("Double");
        }

        if (IsGrounded == false)
        {
            Airtime += Time.deltaTime;
        }

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing
        FacingRight = !FacingRight;

        // Multiply the player's x scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Silhouette()
    {
        if (fadeStart < fadeTime)
        {
            fadeStart += Time.deltaTime * 0.085f;

            SpriteRenderer.color = Color.Lerp(objectColor, fadeColor, fadeStart);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.sharedMaterial == null)
        {
            FloorType = 0;
        }
        else if (collision.collider.sharedMaterial.name == "Ground_Hard")
        {
            FloorType = 1;
        }
        else if (collision.collider.sharedMaterial.name == "Ground_Soft")
        {
            FloorType = 2;
        }
        else if (collision.collider.sharedMaterial.name == "Ground_Wet")
        {
            FloorType = 3;
        }

    }


    public void TailState(int i)
    {
        animator.SetInteger("Tail", i);
    }

    public void Step()
    {
        if (FloorType <= 1)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(WalkHard[Random.Range(0, WalkHard.Length)], 0.2f);
        }
        else if (FloorType == 2)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(WalkSoft[Random.Range(0, WalkSoft.Length)], 0.2f);
        }
        else if (FloorType == 3)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(WalkWet[Random.Range(0, WalkWet.Length)], 0.2f);
        }

    }

    public void Jump()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(JumpSFX, 0.35f);
    }

    public void Land()
    {
        if (Airtime >= HardFall)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(LandSFX[2], 0.5f);
            Airtime = 0;
        }
        else
        {
            if (FloorType <= 1)
            {
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.PlayOneShot(LandSFX[0], 0.5f);
            }
            else
            {
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.PlayOneShot(LandSFX[1], 0.5f);
            }
            Airtime = 0;
        }
    }

    public void MoveLock()
    {
        MovementEnabled = false;
        animator.SetBool("Throwing", true);
    }

    public void MoveUnlock()
    {
        MovementEnabled = true;
        animator.SetBool("Throwing", false);
    }

    public void Throw()
    {
        //Check mouse side
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mouse.x < playerScreenPoint.x)
        {
            //Mouse is to the left side of the player
            if (FacingRight)
            {
                Flip();
            }
        }
        else
        {
            //Mouse is to the right side of the player
            if (!FacingRight)
            {
                Flip();
            }
        }

        animator.SetTrigger("Throw");
    }

    public void DoDouble()
    {
        animator.SetBool("Doubled", true);
    }

    public void UnDouble()
    {
        animator.SetBool("Doubled", false);
    }

}
