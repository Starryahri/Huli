using UnityEngine;

public class Player2WallCheck : MonoBehaviour
{
    public Char_Controller2 ParentPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        { 
            ParentPlayer.WallCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ParentPlayer.WallCollision = false;
    }

}