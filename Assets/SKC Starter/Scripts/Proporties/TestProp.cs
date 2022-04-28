using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProp : MonoBehaviour
{
    [SKC_ReadOnly]
    [SerializeField]
    private string textNonEditable = "You can't edit this text.";
    [SerializeField]
    private string textEditable = "But you definitely can edit this one.";

    [Space]

    [SKC_ReadOnly]
    [SerializeField]
    protected int numNonEditable = 23;
    [SerializeField]
    protected int numEditable = 12;

    [Space]

    [SKC_ReadOnly]
    public Vector2 vectorNonEditable = new Vector2(25, 13);
    public Vector2 vectorEditable = new Vector2(7, 3);

    [Space]

    [SKC_TagSelector]
    public string targetTag = "";

    [Space]

    public bool Hide;
    [SKC_ConditionalHide("Hide", true)]
    public bool nameThis;
    [SKC_ConditionalHide("Hide")]
    public bool nameThis2;
}