using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharAnimator : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator myAnimator = null;

    public void SetAnimatorWithTrigger(string animName)
    {
        myAnimator.SetTrigger(animName);
    }

    public void SetAnimatorWithBool(string animName, bool isPlaying)
    {
        myAnimator.SetBool(animName, isPlaying);
    }

    public void SetFloat(string triggerName, float val)
    {
        myAnimator.SetFloat(triggerName, val);
    }
}
