using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Event with Enemy")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distance = 15f;
    private Vector3 startPos;
    private bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if (moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                moveRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                moveRight = true;
                Flip();
            }
        }
    }
    void Flip()
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }
}
