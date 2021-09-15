using UnityEngine;

public class KillBox : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnPoint;
    public GameObject RespawnParticles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("WHAMO");
            Player.transform.position = RespawnPoint.transform.position;
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject go = Instantiate(RespawnParticles, Player.transform.position, Quaternion.identity) as GameObject;
            Destroy(go, 3f);
        }
    }
}
