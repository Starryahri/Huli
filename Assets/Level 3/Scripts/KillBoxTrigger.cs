using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxTrigger : MonoBehaviour
{
    public BoxCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        Collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collider.enabled = true;
            Destroy(gameObject);
        }
    }
}
