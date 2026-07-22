using UnityEngine;
using UnityEngine.InputSystem;

public class Coil : MonoBehaviour
{
    private Vector3 mousePosition;
    private float zPos = 0f;
    private int coinMultiplier;

    private void Start()
    {
        transform.localScale = new Vector3( DataManager.Instance.coilRadius,DataManager.Instance.coilRadius, DataManager.Instance.coilRadius);
        coinMultiplier = DataManager.Instance.coinMultiplier * 1;
    }
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
            SFX.Instance.PlayCoinSound();
            DataManager.Instance.yellowCoins+=coinMultiplier;
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
        else if(collision.tag =="RC")
        {
            SFX.Instance.PlayCoinSound();
            DataManager.Instance.redCoins+=coinMultiplier;
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
        else if(collision.tag == "BC")
        {
            SFX.Instance.PlayCoinSound();
            DataManager.Instance.blueCoins+=coinMultiplier;
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
        else if(collision.tag =="GC")
        {
            SFX.Instance.PlayCoinSound();
            DataManager.Instance.greenCoins+=coinMultiplier;
            Destroy (collision.gameObject);
            GameManager.Instance.UpdateUI();
        }
    }
}
