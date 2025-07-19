using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confider;

    private void Awake()
    {
        confider = FindAnyObjectByType<CinemachineConfiner2D>();
        // confider = FindObjectOfType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confider.BoundingShape2D = mapBoundry;
        }
    }


}
