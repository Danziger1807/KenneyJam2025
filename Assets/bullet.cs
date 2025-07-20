using UnityEngine;

public class bullet : MonoBehaviour
{


    [SerializeField] public float speed = 20f;
    [SerializeField] public int damage = 20;
    public Rigidbody2D rb;


    void Start()
    {
        transform.Rotate(0, 0, 90);
        rb.linearVelocity = -transform.up * speed;
        Destroy(gameObject, 2);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject, 0.005f);
        }

        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject, 0.005f);
        }
    }

}

