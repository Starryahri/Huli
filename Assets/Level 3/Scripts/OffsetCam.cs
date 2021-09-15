using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OffsetCam : MonoBehaviour
{
    public CinemachineCameraOffset VCamOffset;
    public Vector3 TargetOffset;
    public float SmoothDamp;
    private bool LookAt;
    private Vector3 Velocity = Vector3.zero;

    void Start()
    {
        VCamOffset.m_Offset = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        if (LookAt)
        {
            //VCamOffset.m_Offset = Vector3.MoveTowards(VCamOffset.m_Offset, TargetOffset, Speed/100);
            VCamOffset.m_Offset = Vector3.SmoothDamp(VCamOffset.m_Offset, TargetOffset, ref Velocity, SmoothDamp);
        }
        else
        {
            //VCamOffset.m_Offset = Vector3.MoveTowards(VCamOffset.m_Offset, Vector3.zero, Speed / 100);
            VCamOffset.m_Offset = Vector3.SmoothDamp(VCamOffset.m_Offset, Vector3.zero, ref Velocity, SmoothDamp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LookAt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LookAt = false;
        }
    }
}
