using UnityEngine;
using UnityEngine.InputSystem;

public class StoryCoil : MonoBehaviour
{
    private Vector3 mousePosition;
    private float zPos = 0f;

    private void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = zPos;
        transform.position = worldPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "YC")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "RC")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "BC")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "GC")
        {
            Destroy(collision.gameObject);
        }
    }
}
