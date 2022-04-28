/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public enum Wheel
{
    FrontRight,
    FrontLeft,
    RearRight,
    RearLeft
}
public class CounterRotationForce : MonoBehaviour
{
    [Header("Determine Wheel")]
    public Wheel whichWheel;

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Road"))
        {
            switch(whichWheel)
            {
                case Wheel.FrontRight:
                    GetComponentInParent<CarSystem>().frOnGround = true;
                    break;

                case Wheel.FrontLeft:
                    GetComponentInParent<CarSystem>().flOnGround = true;
                    break;

                case Wheel.RearRight:
                    GetComponentInParent<CarSystem>().rrOnGround = true;
                    break;

                case Wheel.RearLeft:
                    GetComponentInParent<CarSystem>().rlOnGround = true;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            switch (whichWheel)
            {
                case Wheel.FrontRight:
                    GetComponentInParent<CarSystem>().frOnGround = false;
                    break;

                case Wheel.FrontLeft:
                    GetComponentInParent<CarSystem>().flOnGround = false;
                    break;

                case Wheel.RearRight:
                    GetComponentInParent<CarSystem>().rrOnGround = false;
                    break;

                case Wheel.RearLeft:
                    GetComponentInParent<CarSystem>().rlOnGround = false;
                    break;
            }
        }
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */