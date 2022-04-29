/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [Header("Configuration")]
    [Space(5)]
    [SerializeField] private MovementSO movementData = null;

    // Privates

    // Components
    private CharacterController myController; // Char Controller
    private AICharAnimator animController;

    // Matrix
    private Vector2 inputDirection;
    private Vector3 currentMovement;

    // Values
    private float movementSpeed;
    private float gravity = 9.81f;
    private float yForce;

    private void Start()
    {
        myController = GetComponent<CharacterController>();
        animController = GetComponent<AICharAnimator>();

        Init();
    }

    private void Update()
    {
        inputDirection = GUIController.Instance.InputDirection();
    }

    private void FixedUpdate()
    {
        yForce += Time.deltaTime * gravity;

        Movement();
    }

    private void Init()
    {
        movementSpeed = movementData.movementSpeed;
        gravity = movementData.gravity;
    }

    private void Movement()
    {
        if (GUIController.Instance.OnPointerDown()) transform.eulerAngles = new Vector3(0, Mathf.Atan2(inputDirection.x, inputDirection.y) * 180 / Mathf.PI, 0);

        // Example Movement
        currentMovement = transform.forward * (GUIController.Instance.OnPointerDown() ? GUIController.Instance.InputDirection().magnitude : 0f) * movementSpeed * Time.deltaTime + Vector3.down * yForce;

        myController.Move(currentMovement);
        if (myController.isGrounded)
        {
            yForce = 0;
        }

        if (myController.velocity.magnitude > 0.01f)
        {
            SoundFXManager.Instance.PlayFootSteps(Mathf.Abs(movementSpeed * GUIController.Instance.InputDirection().magnitude));
        }

        // Animations
        animController.SetAnimatorWithBool("Run", GUIController.Instance.OnPointerDown());
        animController.SetFloat("RunMultiplier", GUIController.Instance.InputDirection().magnitude);

    }
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */