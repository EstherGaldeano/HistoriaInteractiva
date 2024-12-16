using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    public DialogueRunner dialogueRunner;

    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    private Animator animator;

    public bool isTalking;

    public GameObject playerImg;
    public GameObject NPCImg;

    private void Awake()
    {
        dialogueRunner.AddCommandHandler("TriggerEndDialogue", TriggerEndDialogue);
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerImg.SetActive(false);
        NPCImg.SetActive(false);
    }

    public void TriggerEndDialogue()
    {
        playerImg.SetActive(false);
        NPCImg.SetActive(false);

        for (int i = 0; i < NPCImg.gameObject.transform.childCount; i++)
        {
            NPCImg.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void OnDialogueStart()
    {
        isTalking = true;

        playerImg.SetActive(true);
        NPCImg.SetActive(true);
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
