using UnityEngine;

public class PitchRandomizer : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.8f, 1.2f);
    }
}
