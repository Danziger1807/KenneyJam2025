using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Dodajemy referencj�
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        Flip(); // Obracamy sprite'a w Update
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        // Zmieniaj stan animacji w zale�no�ci od tego, czy ruch trwa
        animator.SetBool("isWalking", moveInput != Vector2.zero);
    }

    private void Flip()
    {
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false; // Patrzy w prawo
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true; // Patrzy w lewo
        }
        // Je�li moveInput.x == 0 � nie zmieniamy kierunku
    }
}
