using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    private Animator animator;

    private bool isTalking;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnDialogueStart()
    {
        isTalking = true;
    }

    public void OnDialogueEnd()
    {
        isTalking = false;
    }


    void Update()
    {
        rigidBody.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(!isTalking)
        {
            animator.SetBool("IsWalking", true);

            if (context.canceled)
            {
                animator.SetBool("IsWalking", false);
                animator.SetFloat("LastInputX", moveInput.x);
                animator.SetFloat("LastInputY", moveInput.y);
            }


            moveInput = context.ReadValue<Vector2>();
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
        }        
    }
}
