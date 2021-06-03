using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
public class HandGrabbing : OVRGrabber
{
    private OVRHand hand;
    private float pinchThreshHold = 0.7f;

    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
    }

    public override void Update()
    {
        base.Update();
        CheckPinchIndex();
    }

    private void CheckPinchIndex()
    {
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        if (m_grabbedObj && pinchStrength > pinchThreshHold && m_grabCandidates.Count > 0)
        {
            GrabBegin();
        }

        else if (m_grabbedObj && pinchStrength <= pinchThreshHold)
        {
            GrabEnd();
        }
    }
}
