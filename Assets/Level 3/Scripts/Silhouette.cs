using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silhouette : MonoBehaviour
{
    public Char_Controller Char;

    private void FixedUpdate()
    {
        Char.Silhouette();
    }
}
