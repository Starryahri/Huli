using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public Char_Controller ParentPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            ParentPlayer.IsGrounded = true;
            ParentPlayer.IsJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            ParentPlayer.IsGrounded = false;
        }
    }

}
