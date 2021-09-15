using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    private Animator animator;
    private float speedPerSec;
    private float speed;
    private Vector2 oldPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(transform);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Awake", true);
            animator.SetBool("Disturbed", true);

            Debug.Log("Jellyfish: Player");

            /*
            speedPerSec = Vector2.Distance(oldPosition, transform.position) / Time.deltaTime;
            speed = Vector2.Distance(oldPosition, transform.position);
            oldPosition = transform.position;

            print(speed);
            other.rigidbody.MovePosition(new Vector2(other.transform.position.x, other.transform.position.y + speed));
            */

            //other.collider.transform.SetParent(transform);
            //other.collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Jellyfish: Projectile");

            animator.SetBool("Awake", true);
            animator.SetBool("Disturbed", true);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Awake", true);
            animator.SetBool("Disturbed", true);

            Debug.Log("Jellyfish: Player");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        animator.SetBool("Disturbed", false);
        other.collider.transform.SetParent(null);
        //other.collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Projectile"))
        {
            animator.SetBool("Disturbed", false);
        }
            
    }

    public void FallAsleep()
    {
        animator.SetBool("Awake", false);
        animator.SetBool("Disturbed", false);
    }

    public void CheckStatus()
    {
        animator.SetBool("Disturbed", false);
    }

    public void ResetJelly()
    {
        animator.SetBool("Awake", false);
        animator.SetBool("Disturbed", false);
        animator.SetTrigger("Reset");
    }

}
