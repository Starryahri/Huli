using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silhouette2 : MonoBehaviour
{
    public Char_Controller2 Char;

    private void FixedUpdate()
    {
        Char.Silhouette();
    }
}
