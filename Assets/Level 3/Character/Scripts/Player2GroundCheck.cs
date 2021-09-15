using UnityEngine;

public class Player2GroundCheck : MonoBehaviour
{
    public Char_Controller2 ParentPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            ParentPlayer.IsGrounded = true;
            ParentPlayer.IsJumping = false;
            ParentPlayer.DoubleJump = false;
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
