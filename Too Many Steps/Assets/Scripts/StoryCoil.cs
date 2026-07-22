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
            SFX.Instance.PlayCoinSound();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "RC")
        {
            SFX.Instance.PlayCoinSound();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "BC")
        {
            SFX.Instance.PlayCoinSound();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "GC")
        {
            SFX.Instance.PlayCoinSound();
            Destroy(collision.gameObject);
        }
    }
}
