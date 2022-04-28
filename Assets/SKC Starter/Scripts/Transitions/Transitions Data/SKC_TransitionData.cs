/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SKC_TransitionData",menuName ="SKC_Data/Transition Data")]
public class SKC_TransitionData : ScriptableObject
{
    [HideInInspector] public enum TransitionType { oneImageTransition,twoImageTransition} //Define enum for transitiyonType
    [HideInInspector] public enum AxisType { onlyXaxis, onlyYaxis, twoAxis}
    [HideInInspector] public enum TweenType { easeInSine,easeOutSine,easeInOutSine,easeInCubic,easeOutCubic,easeInOutCubic,
    easeInQuint,easeOutQuint,easeInOutQuint,easeInCirc,easeOutCirc,easeInOutCirc,easeInElastic,easeOutElasetic,
    easeInOutElastic,easeInQuad,easeOutQuad,easeInOutQuad,easeInQuart,easeOutQuart,easeInOutQuart,easeInExpo,
    easeOutExpo,easeInOutExpo,easeInBack,easeOutBack,easeInOutBack,easeInBounce,easeOutBounce,easeInOutBounce}
    [Header("Define your transition type")]
    [HideInInspector] public TransitionType transitionType; //Determine your enum
    [Header("Select axis type")]
    [HideInInspector] public AxisType axisType;
    [Header("Select tween type")]
    [HideInInspector] public TweenType tweenType;
    [Header("Select your transition Image")]
    [HideInInspector] public Sprite oneImageTransition;
    [HideInInspector] public Sprite secondImageTransition;
    [HideInInspector] public bool hasAlpha;

    [HideInInspector] public float timeBetweenTransition,finishXpos,finishYpos,alpha, finishXpos2, finishYpos2;
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */