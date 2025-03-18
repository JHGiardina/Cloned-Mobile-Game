using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player_IA inputActions;
    private Vector2 moveInput;
    public float moveSpeed;

    void Awake()
    {
        inputActions = new Player_IA();
    }

    private void OnEnable() 
    {
        
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(move);
        Debug.Log("Move vector: " + move);
    }
}
