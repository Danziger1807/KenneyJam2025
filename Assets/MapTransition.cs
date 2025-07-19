using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confider;
    [SerializeField] Direction direction;
    [SerializeField] float additivePos = 1.75f;

    enum Direction {  Up, Down, Left, Right}
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
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject Player)
    {
        Vector3 newPos = Player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += additivePos;
                break;

            case Direction.Down:
                newPos.y -= additivePos;
                break;
            case Direction.Left:
                newPos.x -= additivePos;
                break;

            case Direction.Right:
                newPos.x += additivePos;
                break;

        }
        Player.transform.position = newPos;
    }

    

}
