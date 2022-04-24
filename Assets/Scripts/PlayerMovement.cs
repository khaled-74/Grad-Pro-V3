using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isSprinting => Input.GetKey(sprintKey);
    private bool shouldCrouch => Input.GetKey(crouchKey) && !duringCrouchingAnimation && controller.isGrounded;

    [SerializeField] private AudioSource startAudioSource = default;
    [SerializeField] private AudioClip[] s1Clip = default;

    [Header("Functional Options")]
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canCrouch = true;
    [SerializeField] private bool canHeadBob = true;
    [SerializeField] private bool useFootsteps = true;
    [SerializeField] private bool canZoom = true;

    [Header("Controls")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode zoomKey = KeyCode.Mouse1;

    [Header("Movement Parameters")]
    [SerializeField] public float speed = 6f;
    [SerializeField] public float sprint = 18.0f;
    [SerializeField] public float crouchSpeed = 3f;

    [Header("Jumping Parameters")]
    [SerializeField] public float gravity = -9.18f;
    [SerializeField] public float jumpHeight = 3f;
    [SerializeField] private AudioSource jumpAudioSource = default;
    [SerializeField] private AudioClip[] v1Clip = default;
    public Transform groundCheck;
    public float groundDistance = 0.4f;//radius of the sphere
    public LayerMask groundMask;//to control wat objects the sphere should check for

    [Header("Crouching Parameters")]
    [SerializeField] private float crouchHeight = 1f;
    [SerializeField] private float standingHeight = 3.8f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchCenter = new Vector3(0, 1f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool isCrouching;
    private bool duringCrouchingAnimation;

    [Header("Headbob parameters")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    [SerializeField] private float sprintBobSpeed = 18f;
    [SerializeField] private float sprintBobAmount = 0.1f;
    [SerializeField] private float crouchBobSpeed = 8f;
    [SerializeField] private float crouchBobAmount = 0.025f;
    private float defaultYPos = 0;
    private float timer;

    [Header("Zoom parameters")]
    [SerializeField] private float timeToZoom = 0.3f;
    [SerializeField] private float zoomFOV = 30f;
    private float defaultFOV;
    private Coroutine zoomRoutine;

    [Header("Footsteps parameters")]
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private float crouchStepMultiplier = 1.5f;
    [SerializeField] private float sprintStepMultiplier = 0.6f;
    [SerializeField] private AudioSource footstepsAudioSource = default;
    [SerializeField] private AudioClip[] woodClips = default;//the floor of the room
    [SerializeField] private AudioClip[] dirtClips = default;//before the grave
    [SerializeField] private AudioClip[] stoneClips = default;//in the grave
    [SerializeField] private AudioClip[] marbleClips = default;
    [SerializeField] private AudioClip[] carpetClips = default;
    private float footstepTimer = 0;
    private float GetCurrentOffset => isCrouching ? baseStepSpeed * crouchStepMultiplier : isSprinting ? baseStepSpeed * sprintStepMultiplier : baseStepSpeed;

    private Camera playerCamera;
    private CharacterController controller;

    private Vector3 moveDirection;
    private Vector3 move;
    Vector3 velocity;
    bool isGrounded;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        controller = GetComponent<CharacterController>();
        defaultYPos = playerCamera.transform.localPosition.y;
        defaultFOV = playerCamera.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        startAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            HandleMovement();

            if (canJump)
                HandleJump();

            if (canCrouch)
                HandleCrouch();

            if (canHeadBob)
                HandleHeadBob();

            if (canZoom)
                HandleZoom();

            if (useFootsteps)
                HandleFootsteps();
        }
    }
    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //to walk based on the way the player is facing
        move = transform.right * x + transform.forward * z;

        //so moving dagonally isnt faster than normal
        if (move.magnitude > 1)
        {
            move /= move.magnitude;
        }
        //try
        float movementType = (isCrouching ? crouchSpeed : isSprinting ? sprint : speed);
        moveDirection = move * movementType * Time.deltaTime;
        controller.Move(moveDirection);
    }
    private void HandleJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    } 
    private void HandleCrouch()
    {
        if (shouldCrouch)
            StartCoroutine(CrouchStand());
    }
    private void HandleHeadBob()
    {
        if (!controller.isGrounded) return;

        if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : isSprinting ? sprintBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : isSprinting ? sprintBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z);
        }
    }
    private void HandleZoom()
    {
        if (Input.GetKeyDown(zoomKey))
        {
            if(zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }

            zoomRoutine = StartCoroutine(ToggleZoom(true));
        }

        if (Input.GetKeyUp(zoomKey))
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }

            zoomRoutine = StartCoroutine(ToggleZoom(false));
        }
    }
    private void HandleFootsteps()
    {
        if (!controller.isGrounded) return;
        
        if (move == Vector3.zero) return;

        footstepTimer -= Time.deltaTime;

        if(footstepTimer <= 0)
        {
            if(Physics.Raycast(playerCamera.transform.position, Vector3.down, out RaycastHit hit, 3))
            {
                switch (hit.collider.tag)
                {
                    case "Footsteps/Stone":
                        footstepsAudioSource.PlayOneShot(stoneClips[Random.Range(0, stoneClips.Length - 1)]);
                        break;
                        
                    case "Footsteps/Dirt":
                        footstepsAudioSource.PlayOneShot(dirtClips[Random.Range(0, dirtClips.Length - 1)]);
                        break;

                    case "Footsteps/Wood":
                        footstepsAudioSource.PlayOneShot(woodClips[Random.Range(0, woodClips.Length - 1)]);
                        break;

                    case "Footsteps/Marble":
                        footstepsAudioSource.PlayOneShot(marbleClips[Random.Range(0, marbleClips.Length - 1)]);
                        break;

                    case "Footsteps/Carpet":
                        footstepsAudioSource.PlayOneShot(carpetClips[Random.Range(0, carpetClips.Length - 1)]);
                        break;

                    default://whatever default we want comment if not needed
                        footstepsAudioSource.PlayOneShot(dirtClips[Random.Range(0, dirtClips.Length - 1)]);
                        break;
                }
            }
            footstepTimer = GetCurrentOffset;
        }
    }
    private IEnumerator CrouchStand()
    {
        if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f))
            yield break;

        duringCrouchingAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        float currentHeight = controller.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchCenter;
        Vector3 currentCenter = controller.center;

        while(timeElapsed < timeToCrouch)
        {
            controller.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch);
            controller.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        controller.height = targetHeight;
        controller.center = targetCenter;

        isCrouching = !isCrouching;

        duringCrouchingAnimation = false;
    }
    private IEnumerator ToggleZoom(bool isEnter)
    {
        float targetFOV = isEnter ? zoomFOV : defaultFOV;
        float startingFOV = playerCamera.fieldOfView;
        float timeElapsed = 0;

        while(timeElapsed < timeToZoom)
        {
            playerCamera.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapsed / timeToZoom);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        playerCamera.fieldOfView = targetFOV;
        zoomRoutine = null;
    }
}
