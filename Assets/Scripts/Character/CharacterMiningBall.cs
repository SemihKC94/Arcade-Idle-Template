using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMiningBall : MonoBehaviour
{
    [Header("Line Renderer Config")]
    [SerializeField] private LineRenderer gatheringLine = null;
    [SerializeField] private LineRenderer drainSource = null;
    [SerializeField] private Texture[] _textures = null;
    [SerializeField] private float _fps = 30f;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform startPos2;

    // Privates
    private int animationStep;
    private float fpsCounter;
    private bool isStart = false;
    private bool changeLine = false;
    private Vector3 target;

    private void LateUpdate()
    {
        if(isStart)
        {
            if(target != null)
            {
                if(changeLine)
                {
                    if(drainSource.positionCount > 0) drainSource.positionCount = 0;
                    gatheringLine.SetPosition(1,target); 
                } 
                else 
                {
                    if(gatheringLine.positionCount > 0) gatheringLine.positionCount = 0;
                    drainSource.SetPosition(1,target);
                }

                fpsCounter += Time.deltaTime;
                if(fpsCounter >= 1f / _fps)
                {
                    animationStep++;
                    if(animationStep == _textures.Length)
                    {
                        animationStep = 0;
                    }

                    if(changeLine) gatheringLine.material.SetTexture("_MainTex",_textures[animationStep]);
                    else drainSource.material.SetTexture("_MainTex",_textures[animationStep]);

                    fpsCounter = 0;
                }
            }
        }
        else
        {
            if(gatheringLine.positionCount > 0) gatheringLine.positionCount = 0;
            if(drainSource.positionCount > 0) drainSource.positionCount = 0;
        }
    }

    public void AssingTarget(Vector3 newTarget,bool start,bool which)
    {
        isStart = start;
        changeLine = which;
        if(changeLine) 
        {
            gatheringLine.positionCount = 2;
            gatheringLine.SetPosition(0,startPos.position);
        }
        else
        {
            drainSource.positionCount = 2;
            drainSource.SetPosition(0,startPos2.position);
        }
        target = newTarget;
    }
}
