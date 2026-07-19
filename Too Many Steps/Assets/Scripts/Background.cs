using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float activeTime;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 moveDirection;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, activeTime);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector2.MoveTowards(transform.position, moveDirection, Mathf.Infinity) * speed * Time.fixedDeltaTime;
    }
}
