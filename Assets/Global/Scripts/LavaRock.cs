using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            this.gameObject.GetComponentInChildren<Rigidbody2D>().simulated = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
