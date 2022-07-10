using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public delegate void OnLevelStartHandler();
    public delegate void OnPlayerMovementAnimHandler(float value);
    
    public static event OnPlayerMovementAnimHandler OnPlayerMove;
    public static event OnLevelStartHandler OnLevelStart;

    public static PlayerMovement Instance { get; private set; }

    [HideInInspector] public bool IsGameStart = false;

    [SerializeField] public Vector2 clampValuesX = new Vector2(-8.35f, +8.35f);
    [SerializeField] float swipeSpeed, currentSpeed;
    private Vector3 mouseStartPos, PlayerStartPos;
    private Rigidbody rb;
    public bool gameState;

    [Header("Jump Attributes")]
    [SerializeField] float yJumpForce;
    [SerializeField] float zJumpForce;
    [SerializeField] float runMultiplier;
    public bool canRun = false;
   
    private void Awake()
    {
        if (Instance == null)
            Instance = this;


        rb = GetComponent<Rigidbody>();
        gameState = true;

        JumpTrigger.OnJumpMoveStart += JumpStart;
        JumpTrigger.OnJumpMoveEnd += JumpEnd;
        PlayerInput.OnBodyMove += MovePlayer;
    }
    private void Update()
    {
        CheckTheGame();
        FinalStageRun();
    }
    private void CheckTheGame()
    {
        if (Input.GetMouseButton(0))
        {
            OnLevelStart?.Invoke();
            OnPlayerMove?.Invoke(1.0f);
            IsGameStart = true;
        }
    }
    private void MovePlayer(Ray pointerPosition)
    {
        if (IsGameStart && gameState)
        {

            var plane = new Plane(Vector3.up, 0.0f);
            float distance;

            if (plane.Raycast(pointerPosition, out distance))
            {
                Vector3 mousePos = pointerPosition.GetPoint(distance);
                Vector3 desiredPos = mousePos - mouseStartPos;
                Vector3 move = PlayerStartPos + desiredPos;
                move.x = Mathf.Clamp(move.x, clampValuesX.x, clampValuesX.y);
                move.z = -7.0f;
                Vector3 player = transform.position;
                player = new Vector3(Mathf.Lerp(player.x, move.x, Time.deltaTime *swipeSpeed), player.y, player.z);
                transform.position = player;
                transform.Translate(Vector3.forward * Time.deltaTime *currentSpeed);
            }
        }
    }
  

    public void JumpStart()
    {
        rb.AddForce(0, yJumpForce, zJumpForce, ForceMode.Impulse);
        OnPlayerMove?.Invoke(0.0f);
        gameState = false;
    }
    public void JumpEnd()
    {
        OnPlayerMove?.Invoke(1.0f);
        canRun = true;
    }

    private void FinalStageRun()
    {
        if(canRun)
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime * runMultiplier);
    }





    private void OnDestroy()
    {
        JumpTrigger.OnJumpMoveStart -= JumpStart;
        JumpTrigger.OnJumpMoveEnd -= JumpEnd;
        PlayerInput.OnBodyMove -= MovePlayer;
    }
}
