using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb.linearVelocity = transform.right * speed;  
    }

    // Update is called once per frame
   
}
