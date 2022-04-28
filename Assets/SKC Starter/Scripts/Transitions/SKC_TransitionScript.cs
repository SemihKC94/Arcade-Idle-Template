/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKC_TransitionScript : MonoBehaviour
{
    [Header("Transition Data")]
    [Tooltip("Select transition data")]
    public SKC_TransitionData myTransitionData;

    [Header("In Scene Object")]
    public CanvasGroup firstImage = null, secondImage = null;

    //Private valuables
    private float timeBetweenTransition,finishXpos,finishYpos,alpha, finishXpos2, finishYpos2;
    private bool hasAlpha;

    [Header("Start in Awake ?")]
    [Space(10)]
    public bool inStart;

    private void Awake()
    {
        timeBetweenTransition = myTransitionData.timeBetweenTransition; finishXpos = myTransitionData.finishXpos; finishYpos = myTransitionData.finishYpos; 
        alpha = myTransitionData.alpha; finishXpos2 = myTransitionData.finishXpos2; finishYpos2 = myTransitionData.finishYpos2; hasAlpha = myTransitionData.hasAlpha;

        if(inStart)
        {
            switch(myTransitionData.transitionType)
            {
                case SKC_TransitionData.TransitionType.oneImageTransition:
                    firstImage.gameObject.GetComponent<Image>().sprite = myTransitionData.oneImageTransition;
                    OneImageTransition();
                    break;

                case SKC_TransitionData.TransitionType.twoImageTransition:
                    firstImage.gameObject.GetComponent<Image>().sprite = myTransitionData.oneImageTransition;
                    secondImage.gameObject.GetComponent<Image>().sprite = myTransitionData.secondImageTransition;
                    TwoImageTransition();
                    break;
            }
        }
        else
        {
            switch (myTransitionData.transitionType)
            {
                case SKC_TransitionData.TransitionType.oneImageTransition:
                    firstImage.gameObject.GetComponent<Image>().sprite = myTransitionData.oneImageTransition;
                    //OneImageTransition();
                    break;

                case SKC_TransitionData.TransitionType.twoImageTransition:
                    firstImage.gameObject.GetComponent<Image>().sprite = myTransitionData.oneImageTransition;
                    secondImage.gameObject.GetComponent<Image>().sprite = myTransitionData.secondImageTransition;
                    //TwoImageTransition();
                    break;
            }
        }
    }

    public void OneImageTransition()
    {
        switch(myTransitionData.axisType)
        {
            case SKC_TransitionData.AxisType.onlyXaxis:
                if(hasAlpha) LeanTween.alphaCanvas(firstImage, alpha, 0f);
                if ((int)myTransitionData.tweenType == 0) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInSine();
                else if ((int)myTransitionData.tweenType == 1) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutSine();
                else if ((int)myTransitionData.tweenType == 2) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutSine();
                else if ((int)myTransitionData.tweenType == 3) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInCubic();
                else if ((int)myTransitionData.tweenType == 4) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutCubic();
                else if ((int)myTransitionData.tweenType == 5) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutCubic();
                else if ((int)myTransitionData.tweenType == 6) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInQuint();
                else if ((int)myTransitionData.tweenType == 7) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutQuint();
                else if ((int)myTransitionData.tweenType == 8) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutQuint();
                else if ((int)myTransitionData.tweenType == 9) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInCirc();
                else if ((int)myTransitionData.tweenType == 10) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutCirc();
                else if ((int)myTransitionData.tweenType == 11) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutCirc();
                else if ((int)myTransitionData.tweenType == 12) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInElastic();
                else if ((int)myTransitionData.tweenType == 13) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutElastic();
                else if ((int)myTransitionData.tweenType == 14) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutElastic();
                else if ((int)myTransitionData.tweenType == 15) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInQuad();
                else if ((int)myTransitionData.tweenType == 16) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutQuad();
                else if ((int)myTransitionData.tweenType == 17) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutQuad();
                else if ((int)myTransitionData.tweenType == 18) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInQuart();
                else if ((int)myTransitionData.tweenType == 19) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutQuart();
                else if ((int)myTransitionData.tweenType == 20) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutQuart();
                else if ((int)myTransitionData.tweenType == 21) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInExpo();
                else if ((int)myTransitionData.tweenType == 22) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutExpo();
                else if ((int)myTransitionData.tweenType == 23) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutExpo();
                else if ((int)myTransitionData.tweenType == 24) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInBack();
                else if ((int)myTransitionData.tweenType == 25) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutBack();
                else if ((int)myTransitionData.tweenType == 26) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutBack();
                else if ((int)myTransitionData.tweenType == 27) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInBounce();
                else if ((int)myTransitionData.tweenType == 28) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutBounce();
                else if ((int)myTransitionData.tweenType == 29) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutBounce();
                break;

            case SKC_TransitionData.AxisType.onlyYaxis:
                if (hasAlpha) LeanTween.alphaCanvas(firstImage, alpha, 0f);
                if ((int)myTransitionData.tweenType == 0) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInSine();
                else if ((int)myTransitionData.tweenType == 1) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0, finishYpos, 0f), timeBetweenTransition).setEaseOutSine();
                else if ((int)myTransitionData.tweenType == 2) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0, finishYpos, 0f), timeBetweenTransition).setEaseInOutSine();
                else if ((int)myTransitionData.tweenType == 3) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInCubic();
                else if ((int)myTransitionData.tweenType == 4) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutCubic();
                else if ((int)myTransitionData.tweenType == 5) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutCubic();
                else if ((int)myTransitionData.tweenType == 6) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInQuint();
                else if ((int)myTransitionData.tweenType == 7) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutQuint();
                else if ((int)myTransitionData.tweenType == 8) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutQuint();
                else if ((int)myTransitionData.tweenType == 9) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInCirc();
                else if ((int)myTransitionData.tweenType == 10) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutCirc();
                else if ((int)myTransitionData.tweenType == 11) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutCirc();
                else if ((int)myTransitionData.tweenType == 12) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInElastic();
                else if ((int)myTransitionData.tweenType == 13) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutElastic();
                else if ((int)myTransitionData.tweenType == 14) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutElastic();
                else if ((int)myTransitionData.tweenType == 15) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInQuad();
                else if ((int)myTransitionData.tweenType == 16) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutQuad();
                else if ((int)myTransitionData.tweenType == 17) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutQuad();
                else if ((int)myTransitionData.tweenType == 18) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInQuart();
                else if ((int)myTransitionData.tweenType == 19) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutQuart();
                else if ((int)myTransitionData.tweenType == 20) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutQuart();
                else if ((int)myTransitionData.tweenType == 21) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInExpo();
                else if ((int)myTransitionData.tweenType == 22) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutExpo();
                else if ((int)myTransitionData.tweenType == 23) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutExpo();
                else if ((int)myTransitionData.tweenType == 24) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInBack();
                else if ((int)myTransitionData.tweenType == 25) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutBack();
                else if ((int)myTransitionData.tweenType == 26) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutBack();
                else if ((int)myTransitionData.tweenType == 27) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInBounce();
                else if ((int)myTransitionData.tweenType == 28) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseOutBounce();
                else if ((int)myTransitionData.tweenType == 29) LeanTween.moveLocal(firstImage.gameObject, new Vector3(0,finishYpos, 0f), timeBetweenTransition).setEaseInOutBounce();
                break;

            case SKC_TransitionData.AxisType.twoAxis:
                if (hasAlpha) LeanTween.alphaCanvas(firstImage, alpha, 0f);
                if ((int)myTransitionData.tweenType == 0) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInSine();
                else if ((int)myTransitionData.tweenType == 1) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutSine();
                else if ((int)myTransitionData.tweenType == 2) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutSine();
                else if ((int)myTransitionData.tweenType == 3) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInCubic();
                else if ((int)myTransitionData.tweenType == 4) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutCubic();
                else if ((int)myTransitionData.tweenType == 5) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutCubic();
                else if ((int)myTransitionData.tweenType == 6) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInQuint();
                else if ((int)myTransitionData.tweenType == 7) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutQuint();
                else if ((int)myTransitionData.tweenType == 8) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutQuint();
                else if ((int)myTransitionData.tweenType == 9) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInCirc();
                else if ((int)myTransitionData.tweenType == 10) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutCirc();
                else if ((int)myTransitionData.tweenType == 11) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutCirc();
                else if ((int)myTransitionData.tweenType == 12) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInElastic();
                else if ((int)myTransitionData.tweenType == 13) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutElastic();
                else if ((int)myTransitionData.tweenType == 14) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutElastic();
                else if ((int)myTransitionData.tweenType == 15) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInQuad();
                else if ((int)myTransitionData.tweenType == 16) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutQuad();
                else if ((int)myTransitionData.tweenType == 17) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutQuad();
                else if ((int)myTransitionData.tweenType == 18) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInQuart();
                else if ((int)myTransitionData.tweenType == 19) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutQuart();
                else if ((int)myTransitionData.tweenType == 20) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutQuart();
                else if ((int)myTransitionData.tweenType == 21) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInExpo();
                else if ((int)myTransitionData.tweenType == 22) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutExpo();
                else if ((int)myTransitionData.tweenType == 23) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutExpo();
                else if ((int)myTransitionData.tweenType == 24) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInBack();
                else if ((int)myTransitionData.tweenType == 25) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutBack();
                else if ((int)myTransitionData.tweenType == 26) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutBack();
                else if ((int)myTransitionData.tweenType == 27) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInBounce();
                else if ((int)myTransitionData.tweenType == 28) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseOutBounce();
                else if ((int)myTransitionData.tweenType == 29) LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos,finishYpos, 0f), timeBetweenTransition).setEaseInOutBounce();
                break;
        }
    }

    public void TwoImageTransition()
    {
        switch (myTransitionData.axisType)
        {
            case SKC_TransitionData.AxisType.onlyXaxis:
                if (hasAlpha)
                {
                    LeanTween.alphaCanvas(firstImage, alpha, 0f);
                    LeanTween.alphaCanvas(secondImage, alpha, 0f);
                }
                if ((int)myTransitionData.tweenType == 0)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInSine();
                }
                else if ((int)myTransitionData.tweenType == 1)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutSine();
                }
                else if ((int)myTransitionData.tweenType == 2)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutSine();
                }
                else if ((int)myTransitionData.tweenType == 3)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInCubic();
                }
                else if ((int)myTransitionData.tweenType == 4)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutCubic();
                }
                else if ((int)myTransitionData.tweenType == 5)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutCubic();
                }
                else if ((int)myTransitionData.tweenType == 6)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInQuint();
                }
                else if ((int)myTransitionData.tweenType == 7)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutQuint();
                }
                else if ((int)myTransitionData.tweenType == 8)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutQuint();
                }
                else if ((int)myTransitionData.tweenType == 9)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInCirc();
                }
                else if ((int)myTransitionData.tweenType == 10)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutCirc();
                }
                else if ((int)myTransitionData.tweenType == 11)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutCirc();
                }
                else if ((int)myTransitionData.tweenType == 12)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInElastic();
                }
                else if ((int)myTransitionData.tweenType == 13)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutElastic();
                }
                else if ((int)myTransitionData.tweenType == 14)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutElastic();
                }
                else if ((int)myTransitionData.tweenType == 15)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInQuad();
                }
                else if ((int)myTransitionData.tweenType == 16)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutQuad();
                }
                else if ((int)myTransitionData.tweenType == 17)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutQuad();
                }
                else if ((int)myTransitionData.tweenType == 18)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInQuart();
                }
                else if ((int)myTransitionData.tweenType == 19)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutQuart();
                }
                else if ((int)myTransitionData.tweenType == 20)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutQuart();
                }
                else if ((int)myTransitionData.tweenType == 21)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInExpo();
                }
                else if ((int)myTransitionData.tweenType == 22)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutExpo();
                }
                else if ((int)myTransitionData.tweenType == 23)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutExpo();
                }
                else if ((int)myTransitionData.tweenType == 24)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInBack();
                }
                else if ((int)myTransitionData.tweenType == 25)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutBack();
                }
                else if ((int)myTransitionData.tweenType == 26)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutBack();
                }
                else if ((int)myTransitionData.tweenType == 27)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInBounce();
                }
                else if ((int)myTransitionData.tweenType == 28)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseOutBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseOutBounce();
                }
                else if ((int)myTransitionData.tweenType == 29)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, 0f, 0f), timeBetweenTransition).setEaseInOutBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, 0f, 0f), timeBetweenTransition).setEaseInOutBounce();
                }
                break;

            case SKC_TransitionData.AxisType.onlyYaxis:
                if (hasAlpha)
                {
                    LeanTween.alphaCanvas(firstImage, alpha, 0f);
                    LeanTween.alphaCanvas(secondImage, alpha, 0f);
                }
                if ((int)myTransitionData.tweenType == 0)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInSine();
                }
                else if ((int)myTransitionData.tweenType == 1)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutSine();
                }
                else if ((int)myTransitionData.tweenType == 2)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutSine();
                }
                else if ((int)myTransitionData.tweenType == 3)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInCubic();
                }
                else if ((int)myTransitionData.tweenType == 4)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutCubic();
                }
                else if ((int)myTransitionData.tweenType == 5)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutCubic();
                }
                else if ((int)myTransitionData.tweenType == 6)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInQuint();
                }
                else if ((int)myTransitionData.tweenType == 7)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutQuint();
                }
                else if ((int)myTransitionData.tweenType == 8)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutQuint();
                }
                else if ((int)myTransitionData.tweenType == 9)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInCirc();
                }
                else if ((int)myTransitionData.tweenType == 10)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutCirc();
                }
                else if ((int)myTransitionData.tweenType == 11)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutCirc();
                }
                else if ((int)myTransitionData.tweenType == 12)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInElastic();
                }
                else if ((int)myTransitionData.tweenType == 13)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutElastic();
                }
                else if ((int)myTransitionData.tweenType == 14)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutElastic();
                }
                else if ((int)myTransitionData.tweenType == 15)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInQuad();
                }
                else if ((int)myTransitionData.tweenType == 16)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutQuad();
                }
                else if ((int)myTransitionData.tweenType == 17)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutQuad();
                }
                else if ((int)myTransitionData.tweenType == 18)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInQuart();
                }
                else if ((int)myTransitionData.tweenType == 19)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutQuart();
                }
                else if ((int)myTransitionData.tweenType == 20)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutQuart();
                }
                else if ((int)myTransitionData.tweenType == 21)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInExpo();
                }
                else if ((int)myTransitionData.tweenType == 22)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutExpo();
                }
                else if ((int)myTransitionData.tweenType == 23)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutExpo();
                }
                else if ((int)myTransitionData.tweenType == 24)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInBack();
                }
                else if ((int)myTransitionData.tweenType == 25)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutBack();
                }
                else if ((int)myTransitionData.tweenType == 26)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutBack();
                }
                else if ((int)myTransitionData.tweenType == 27)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInBounce();
                }
                else if ((int)myTransitionData.tweenType == 28)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseOutBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseOutBounce();
                }
                else if ((int)myTransitionData.tweenType == 29)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(0f, finishYpos, 0f), timeBetweenTransition).setEaseInOutBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(0f, finishYpos2, 0f), timeBetweenTransition).setEaseInOutBounce();
                }
                break;

            case SKC_TransitionData.AxisType.twoAxis:
                if (hasAlpha)
                {
                    LeanTween.alphaCanvas(firstImage, alpha, 0f);
                    LeanTween.alphaCanvas(secondImage, alpha, 0f);
                }
                if ((int)myTransitionData.tweenType == 0)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInSine();
                }
                else if ((int)myTransitionData.tweenType == 1)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutSine();
                }
                else if ((int)myTransitionData.tweenType == 2)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutSine();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutSine();
                }
                else if ((int)myTransitionData.tweenType == 3)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInCubic();
                }
                else if ((int)myTransitionData.tweenType == 4)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutCubic();
                }
                else if ((int)myTransitionData.tweenType == 5)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutCubic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutCubic();
                }
                else if ((int)myTransitionData.tweenType == 6)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInQuint();
                }
                else if ((int)myTransitionData.tweenType == 7)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutQuint();
                }
                else if ((int)myTransitionData.tweenType == 8)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutQuint();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutQuint();
                }
                else if ((int)myTransitionData.tweenType == 9)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInCirc();
                }
                else if ((int)myTransitionData.tweenType == 10)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutCirc();
                }
                else if ((int)myTransitionData.tweenType == 11)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutCirc();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutCirc();
                }
                else if ((int)myTransitionData.tweenType == 12)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInElastic();
                }
                else if ((int)myTransitionData.tweenType == 13)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutElastic();
                }
                else if ((int)myTransitionData.tweenType == 14)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutElastic();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutElastic();
                }
                else if ((int)myTransitionData.tweenType == 15)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInQuad();
                }
                else if ((int)myTransitionData.tweenType == 16)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutQuad();
                }
                else if ((int)myTransitionData.tweenType == 17)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutQuad();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutQuad();
                }
                else if ((int)myTransitionData.tweenType == 18)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInQuart();
                }
                else if ((int)myTransitionData.tweenType == 19)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutQuart();
                }
                else if ((int)myTransitionData.tweenType == 20)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutQuart();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutQuart();
                }
                else if ((int)myTransitionData.tweenType == 21)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInExpo();
                }
                else if ((int)myTransitionData.tweenType == 22)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutExpo();
                }
                else if ((int)myTransitionData.tweenType == 23)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutExpo();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutExpo();
                }
                else if ((int)myTransitionData.tweenType == 24)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInBack();
                }
                else if ((int)myTransitionData.tweenType == 25)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutBack();
                }
                else if ((int)myTransitionData.tweenType == 26)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutBack();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutBack();
                }
                else if ((int)myTransitionData.tweenType == 27)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInBounce();
                }
                else if ((int)myTransitionData.tweenType == 28)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseOutBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseOutBounce();
                }
                else if ((int)myTransitionData.tweenType == 29)
                {
                    LeanTween.moveLocal(firstImage.gameObject, new Vector3(finishXpos, finishYpos, 0f), timeBetweenTransition).setEaseInOutBounce();
                    LeanTween.moveLocal(secondImage.gameObject, new Vector3(finishXpos2, finishYpos2, 0f), timeBetweenTransition).setEaseInOutBounce();
                }
                break;
        }
    }

}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */