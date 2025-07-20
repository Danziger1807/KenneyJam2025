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

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Enemy")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if ( enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject, 0.05f);
        }
    }

}
