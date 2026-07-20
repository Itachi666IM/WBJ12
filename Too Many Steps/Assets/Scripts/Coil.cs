using UnityEngine;
using UnityEngine.InputSystem;

public class Coil : MonoBehaviour
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
        if(collision.tag =="YC")
        {
            DataManager.Instance.yellowCoins++;
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
        else if(collision.tag =="RC")
        {
            DataManager.Instance.redCoins++;
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
        else if(collision.tag == "BC")
        {
            DataManager.Instance.blueCoins++;
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
        else if(collision.tag =="GC")
        {
            DataManager.Instance.greenCoins++;
            Destroy (collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
    }
}
