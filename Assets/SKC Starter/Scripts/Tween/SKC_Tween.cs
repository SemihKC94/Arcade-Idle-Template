/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKC.Utils
{
    public static class SKC_Tween
    {
        public static void Tween(GameObject obj, Vector3 position,float time)
        {
            LeanTween.moveLocal(obj, position, time);
        }

        public static void TweenCurveAndLoop(GameObject obj, Vector3 position, float time,LeanTweenType easeType,bool loopPingPong ,int loopCount)
        {
			switch (easeType)
			{
				case LeanTweenType.linear:
					setEaseLinear(obj,position,time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutQuad:
					setEaseOutQuad(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInQuad:
					setEaseInQuad(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutQuad:
					setEaseInOutQuad(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInCubic:
					setEaseInCubic(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutCubic:
					setEaseOutCubic(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutCubic:
					setEaseInOutCubic(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInQuart:
					setEaseInQuart(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutQuart:
					setEaseOutQuart(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutQuart:
					setEaseInOutQuart(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInQuint:
					setEaseInQuint(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutQuint:
					setEaseOutQuint(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutQuint:
					setEaseInOutQuint(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInSine:
					setEaseInSine(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutSine:
					setEaseOutSine(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutSine:
					setEaseInOutSine(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInExpo:
					setEaseInExpo(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutExpo:
					setEaseOutExpo(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutExpo:
					setEaseInOutExpo(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInCirc:
					setEaseInCirc(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutCirc:
					setEaseOutCirc(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutCirc:
					setEaseInOutCirc(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInBounce:
					setEaseInBounce(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutBounce:
					setEaseOutBounce(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutBounce:
					setEaseInOutBounce(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInBack:
					setEaseInBack(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutBack:
					setEaseOutBack(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutBack:
					setEaseInOutBack(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInElastic:
					setEaseInElastic(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeOutElastic:
					setEaseOutElastic(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeInOutElastic:
					setEaseInOutElastic(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.punch:
					setEasePunch(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeShake:
					setEaseShake(obj, position, time, loopPingPong, loopCount); break;
				case LeanTweenType.easeSpring:
					setEaseSpring(obj, position, time, loopPingPong, loopCount); break;
				default:
					setEaseLinear(obj, position, time, loopPingPong, loopCount); break;
			}

			
        }

		static void setEaseLinear(GameObject obj, Vector3 position,float time, bool loopPingPong, int loopCount)
        {
			if(loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseLinear().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseLinear().setLoopCount(loopCount);
		}
		static void setEaseOutQuad(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutQuad().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutQuad().setLoopCount(loopCount);
		}
		static void setEaseInQuad(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInQuad().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInQuad().setLoopCount(loopCount);
		}
		static void setEaseInOutQuad(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutQuad().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutQuad().setLoopCount(loopCount);
		}
		static void setEaseInCubic(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInCubic().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInCubic().setLoopCount(loopCount);
		}
		static void setEaseOutCubic(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutCubic().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutCubic().setLoopCount(loopCount);
		}
		static void setEaseInOutCubic(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutCubic().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutCubic().setLoopCount(loopCount);
		}
		static void setEaseInQuart(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInQuart().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInQuart().setLoopCount(loopCount);
		}
		static void setEaseOutQuart(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutQuart().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutQuart().setLoopCount(loopCount);
		}
		static void setEaseInOutQuart(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutQuart().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutQuart().setLoopCount(loopCount);
		}
		static void setEaseInQuint(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInQuint().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInQuint().setLoopCount(loopCount);
		}
		static void setEaseOutQuint(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutQuint().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutQuint().setLoopCount(loopCount);
		}
		static void setEaseInOutQuint(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutQuint().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutQuint().setLoopCount(loopCount);
		}
		static void setEaseInSine(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInSine().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInSine().setLoopCount(loopCount);
		}
		static void setEaseOutSine(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutSine().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutSine().setLoopCount(loopCount);
		}
		static void setEaseInOutSine(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutSine().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutSine().setLoopCount(loopCount);
		}
		static void setEaseInExpo(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInExpo().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInExpo().setLoopCount(loopCount);
		}
		static void setEaseOutExpo(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutExpo().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutExpo().setLoopCount(loopCount);
		}
		static void setEaseInOutExpo(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutExpo().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutExpo().setLoopCount(loopCount);
		}
		static void setEaseInCirc(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInCirc().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInCirc().setLoopCount(loopCount);
		}
		static void setEaseOutCirc(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutCirc().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutCirc().setLoopCount(loopCount);
		}
		static void setEaseInOutCirc(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutCirc().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutCirc().setLoopCount(loopCount);
		}
		static void setEaseInBounce(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInBounce().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInBounce().setLoopCount(loopCount);
		}
		static void setEaseOutBounce(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutBounce().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutBounce().setLoopCount(loopCount);
		}
		static void setEaseInOutBounce(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutBounce().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutBounce().setLoopCount(loopCount);
		}
		static void setEaseInBack(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInBack().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInBack().setLoopCount(loopCount);
		}
		static void setEaseOutBack(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutBack().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutBack().setLoopCount(loopCount);
		}
		static void setEaseInOutBack(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutBack().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutBack().setLoopCount(loopCount);
		}
		static void setEaseInElastic(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInElastic().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInElastic().setLoopCount(loopCount);
		}
		static void setEaseOutElastic(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseOutElastic().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseOutElastic().setLoopCount(loopCount);
		}
		static void setEaseInOutElastic(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseInOutElastic().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseInOutElastic().setLoopCount(loopCount);
		}
		static void setEasePunch(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEasePunch().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEasePunch().setLoopCount(loopCount);
		}
		static void setEaseShake(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseShake().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseShake().setLoopCount(loopCount);
		}
		static void setEaseSpring(GameObject obj, Vector3 position, float time, bool loopPingPong, int loopCount)
		{
			if (loopPingPong) LeanTween.moveLocal(obj, position, time).setEaseSpring().setLoopPingPong();
			else LeanTween.moveLocal(obj, position, time).setEaseSpring().setLoopCount(loopCount);
		}
		
	}
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */