using Unity.VisualScripting;
using UnityEngine;

public class Enemy_meele : MonoBehaviour
{
    public float movementSpeed = 2f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
       // target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
    private void FixedUpdate()
    {
        if (target)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * movementSpeed;
        }
    }
}
