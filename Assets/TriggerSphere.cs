using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSphere : MonoBehaviour
{
    public FinalSphere finalSphere;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finalSphere.Awake = true;
            Destroy(gameObject);
        }
    }
}
