using UnityEngine;

public class ResetBox3 : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnPoint;
    public GameObject RespawnParticles;
    public Animator[] Animators;
    public Lever[] Levers;
    public PlatformMove3[] Moveables;
    public Jellyfish[] Jellyfishies;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.transform.SetParent(null);
            Player.transform.position = RespawnPoint.transform.position;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject go = Instantiate(RespawnParticles, Player.transform.position, Quaternion.identity) as GameObject;
            Destroy(go, 3f);

            foreach (Animator Animator in Animators)
            {
                Animator.SetTrigger("Reset");
            }
            foreach (Lever Lever in Levers)
            {
                Lever.DeactivateLever();
            }
            foreach (PlatformMove3 Platform in Moveables)
            {
                Platform.Reset();
            }
            if (Jellyfishies.Length > 0)
            {
                foreach (Jellyfish Jellyfish in Jellyfishies)
                {
                    Jellyfish.ResetJelly();
                }
            }
        }
    }
}
