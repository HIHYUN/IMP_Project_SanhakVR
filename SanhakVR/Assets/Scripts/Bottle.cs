using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Grab
{
    [SerializeField]
    private bool isStand;

    [SerializeField]
    public bool isGround;

    [SerializeField]
    private bool beenRotate;

    [SerializeField]
    private bool isDone = false;

    [SerializeField]
    private Vector3 lastScalar;

    [SerializeField]
    private Vector3 firstScalar;

    [SerializeField]
    private Vector3 standRotation;

    [SerializeField]
    private float time;
    private float currenttime = 0;

    private void Start()
    {
        standRotation = transform.localRotation.eulerAngles;

        interactable.
            onSelectEntered.
            AddListener(call => {
                isGrab = true;
                beenRotate = false;

                lastScalar = Vector3.zero;
            });

        interactable.
            onSelectExited.
            AddListener(call => {
                isGrab = false;

                lastScalar = transform.forward;
                firstScalar = transform.forward;
               
                if (rotateCoroutine != null)
                    StopCoroutine(rotateCoroutine);
                rotateCoroutine = StartCoroutine(CheckHasBeenRotated());
            });
    }

    private Coroutine rotateCoroutine = null;

    private IEnumerator CheckHasBeenRotated()
    {
        while (!isGrab && !isGround)
        {
            Vector3 currentScalar = transform.forward;
            var angle = Vector3.Angle(currentScalar, lastScalar);

            if (angle > 0.01f)
            {
                lastScalar = currentScalar;

                var finalAngle = Vector3.Angle(firstScalar, lastScalar) ;
                if (finalAngle >= 100)
                    beenRotate = true;
            }
            yield return null;
        }
    }

    private void Update()
    {
        if (isDone) 
        {
            print("Clear!");
            return;
        }

        CheckIsStanding();

        if (isStand && isGround && beenRotate)
        {
            if (standingCoroutine == null)
                StartCoroutine(CheckKeepStanding());
        }
        else
        {
            if (standingCoroutine != null)
                StopCoroutine(standingCoroutine);
            standingCoroutine = null;
        }
    }

    private void CheckIsStanding()
    {
        float rotation = transform.localRotation.eulerAngles[0];
        float firstX = standRotation[0];

        var angle = Mathf.DeltaAngle(firstX, rotation);

        isStand = angle < 0.1f;
    }

    private Coroutine standingCoroutine = null;

    private IEnumerator CheckKeepStanding()
    { 
        while(time >= currenttime) 
        {
            currenttime += 1;

            yield return new WaitForSeconds(1f);
        }

        isDone = true;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.tag == "Ground")
            isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
