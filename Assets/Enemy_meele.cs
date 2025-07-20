using UnityEngine;

public class Enemy_meele : MonoBehaviour
{
    public float movementSpeed = 2f;
    private Rigidbody2D rb;
    public Transform target;
    private Vector2 moveDirection;

    private float health;
    private float maxHealth = 3f;

    public float detectionRange = 5f;
    private bool playerInRange = false;

    private Vector2 patrolDirection;
    private float patrolTimer = 0f;
    public float patrolChangeInterval = 2f;

    public LayerMask obstacleMask;
    public float obstacleCheckDistance = 1f;
    public int damage = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }

        health = maxHealth;
        patrolDirection = GetRandomDirection();
    }

    void Update()
    {
        if (target)
        {
            float distance = Vector2.Distance(transform.position, target.position);
            playerInRange = distance <= detectionRange;

            if (playerInRange)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
            }
            else
            {
                Patrol();
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * movementSpeed;
    }

    private void Patrol()
    {
        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolChangeInterval || IsObstacleAhead())
        {
            patrolDirection = GetRandomDirection();
            patrolTimer = 0f;
        }

        moveDirection = patrolDirection;

        if (patrolDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(patrolDirection.y, patrolDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }

    private bool IsObstacleAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, patrolDirection, obstacleCheckDistance, obstacleMask);
        return hit.collider != null;
    }

    private Vector2 GetRandomDirection()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector2 dir = new Vector2(x, y).normalized;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, obstacleCheckDistance, obstacleMask);
            if (hit.collider == null)
            {
                return dir;
            }
        }

        return Vector2.zero;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }


}
