/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;
using UnityEngine.AI;

public class AIMovementAgent : MonoBehaviour
{
    [Header("Configuration")]
    [Space(5)]
    [SerializeField] private MovementSO movementData = null;

    // Privates

    // Components
    private NavMeshAgent myController; // Char Controller
    private AICharAnimator animController;

    // Matrix
    private Vector2 inputDirection;
    private Vector3 currentMovement;

    // Values
    private float movementSpeed;

    private void Start()
    {
        myController = GetComponent<NavMeshAgent>();
        animController = GetComponent<AICharAnimator>();

        Init();
    }

    private void Update()
    {
        inputDirection = GUIController.Instance.InputDirection();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Init()
    {
        // Get
        movementSpeed = movementData.movementSpeed;

        // Set
        myController.speed = movementSpeed;
    }

    private void Movement()
    {
        if (GUIController.Instance.OnPointerDown())
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(inputDirection.x, inputDirection.y) * 180 / Mathf.PI, 0);
            SoundFXManager.Instance.PlayFootSteps(Mathf.Abs(movementSpeed * GUIController.Instance.InputDirection().magnitude));
        }

        // Example Movement
        currentMovement = transform.forward * (GUIController.Instance.OnPointerDown() ? GUIController.Instance.InputDirection().magnitude : 0f) * movementSpeed * Time.deltaTime;

        myController.Move(currentMovement);

        // Animations
        animController.SetAnimatorWithBool("Run", GUIController.Instance.OnPointerDown());
        animController.SetFloat("RunMultiplier", GUIController.Instance.InputDirection().magnitude);

    }
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */