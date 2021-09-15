using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove3 : MonoBehaviour
{
    public Lever[] Levers;
    public Button[] Buttons;
    private int LeverState;
    private bool Triggered;
    private Animator animator;
    private bool ButtonArmed = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Triggered == false)
        {
            //LEVERS
            if (Levers.Length > 0)
            {
                LeverState = 0;

                foreach (Lever Lever in Levers)
                {
                    if (Lever.CheckLever() == true)
                    {
                        LeverState++;
                    }
                }

                if (LeverState == Levers.Length)
                {
                    Debug.Log("Animation Triggered");
                    animator.SetTrigger("Start");
                    Triggered = true;
                }
            }
            
            //BUTTONS
            if (Buttons.Length > 0 )
            {
                foreach (Button Button in Buttons)
                {
                    if (!ButtonArmed)
                    {
                        if (Button.CheckLever() == true)
                        {
                            animator.SetTrigger("Start");
                            ButtonArmed = true;
                        }
                    }
                    else if (Button.CheckCooldown() <= 0)
                    {
                        ButtonArmed = false;
                    }
                }
            }
            else
            {
                //Debug.Log("No buttons in level.");
            }
        }
    }

    public void Reset()
    {
        Triggered = false;
    }
}
