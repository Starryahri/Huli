using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSFX : MonoBehaviour
{
    private bool Triggered;
    public GameObject Magic;
    public GameObject Sphere;
    public GameObject Flash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Triggered)
        {
            Triggered = true;
            GameObject go = Instantiate(Flash, transform.position, Quaternion.identity) as GameObject;
            Destroy(go, 2f);
            Magic.SetActive(false);
            Sphere.SetActive(false);
        }
     }
}
