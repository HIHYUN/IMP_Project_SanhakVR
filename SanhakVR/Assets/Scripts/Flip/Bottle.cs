using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Grab, IPuzzle
{
    [SerializeField]
    private Stage stage;

    [SerializeField]
    private bool isStand;

    [SerializeField]
    public bool isGround;

    [SerializeField]
    private bool beenRotate;

    [SerializeField]
    private bool isDone = false;

    [SerializeField]
    private Vector3 lastVector;

    [SerializeField]
    private Vector3 firstVector;

    [SerializeField]
    private Vector3 standRotation;

    [SerializeField]
    private float time;
    private float currenttime = 0;

    [SerializeField]
    private bool isSolved = false;
    private void Start()
    {
        stage = StageController.Instance.activeStage;

        stage.addPuzzle(this);
        standRotation = transform.localRotation.eulerAngles;

        interactable.
            onSelectEntered.
            AddListener(call => {
                isGrab = true;
                beenRotate = false;

                lastVector = Vector3.zero;
            });

        interactable.
            onSelectExited.
            AddListener(call => {
                isGrab = false;

                lastVector = transform.forward;
                firstVector = transform.forward;
               
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
            Vector3 currentVector = transform.forward;
            var angle = Vector3.Angle(currentVector, lastVector);

            if (angle > 0.01f)
            {
                lastVector = currentVector;

                var finalAngle = Vector3.Angle(firstVector, lastVector) ;
                if (finalAngle >= 100)
                    beenRotate = true;
            }
            yield return null;
        }
    }

    private void Update()
    {
        if (isSolved) return;

        if (isDone) 
        {
            isSolved = true;
            enabled = true;
            return;
        }

        CheckIsStanding();
        CheckSolved();
    }

    public void CheckSolved()
    {
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

    public bool IsSolved()
    {
        return isSolved;
    }
}
