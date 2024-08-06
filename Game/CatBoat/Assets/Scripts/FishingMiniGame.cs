using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FishingMiniGame : MonoBehaviour
{

    [SerializeField] Transform topPiv;
    [SerializeField] Transform bottomPiv;
    [SerializeField] Transform fish;

    [SerializeField] float timeMult = 3.0f;
    [SerializeField] float smoothMotion = 1.0f;

    [SerializeField] Transform hook;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;
    [SerializeField] float hookPullPW = 0.01f;
    [SerializeField] float hookGravityPW = 0.005f;
    [SerializeField] float hookProgressDegradationPW = 0.1f;
    [SerializeField] SpriteRenderer hookSprite;

    [SerializeField] Transform ProgressBarContainer;

    [SerializeField] float failtTime = 10.0f;

    float fishPos;
    float fishDir;
    float fishSpeed;
    float fishTime;

    float hookPos;
    float hookProgress;
    float hookPullVel;

    bool pause = false;

    private void Start()
    {
        Resize();
    }

   

    private void Update()
    {

        if (pause) { return; }

        Fish();
        Hook();
        ProgressCheck();
    }

    void Resize()
    {
        Bounds b = hookSprite.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topPiv.position, bottomPiv.position);
        ls.y = (distance / ySize * hookSize);
        hook.localScale = ls;
    }

    void Fish()
    {
        fishTime -= Time.deltaTime;

        if (fishTime < 0)
        {
            fishTime = UnityEngine.Random.value * timeMult;

            fishDir = UnityEngine.Random.value;

            Debug.Log("Changing Direction");

        }

        fishPos = Mathf.SmoothDamp(fishPos, fishDir, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPiv.position, topPiv.position, fishPos);
    }

    void Hook()
    {
        if(Input.GetMouseButton(0))
        {
            hookPullVel += hookPullPW * Time.deltaTime;
        }

        hookPullVel -= hookGravityPW * Time.deltaTime;

        hookPos += hookPullVel;

        if(hookPos - hookSize/2 <= 0f && hookPullVel < 0f)
        {
            hookPullVel = 0f;
        }

        if(hookPos + hookSize/2 >= 1f && hookPullVel > 0f)
        {
            hookPullVel = 0f;
        }

        hookPos = Mathf.Clamp(hookPos, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPiv.position,topPiv.position, hookPos);
    }

    void ProgressCheck()
    {
        Vector3 ls = ProgressBarContainer.localScale;
        ls.y = hookProgress;
        ProgressBarContainer.localScale = ls;


        float min = hookPos - hookSize / 2;
        float max = hookPos + hookSize / 2;

        if (min < fishPos && fishPos < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPW * Time.deltaTime;

            failtTime -= Time.deltaTime;
            if(failtTime <0f)
            {
                Lose();
            }

        }

        if (hookProgress >= 1f)
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    void Win()
    {
        pause = true;
        Debug.Log("You Catched Fish!");
    }

    void Lose()
    {
        pause = true;
        Debug.Log("Womp Womp, You Lost The Fish");
    }

}
