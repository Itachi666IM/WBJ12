using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private string[] dialogues;
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] Transform[] stepsArray;
    private string currentString;
    private int index = 0;

    private void Awake()
    {
        dialogueText.text = " ";
        currentString = dialogues[index];

        nextButton.onClick.AddListener(() =>
        {
            nextButton.gameObject.SetActive(false);
            NextSentence();
        });

        playAgainButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            DataManager.Instance.ResetAllData();
            SceneManager.LoadScene("Menu");
        });

        exitButton.onClick.AddListener(() =>
        {
            SFX.Instance.PlayClickSound();
            Application.Quit();
        });
    }

    private IEnumerator DisplayStringWordByWord()
    {
        foreach (char c in currentString)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        nextButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(typingSpeed);
    }

    private void Start()
    {
        StartCoroutine(DisplayStringWordByWord());
    }

    private void NextSentence()
    {
        dialogueText.text = "";
        if (index < dialogues.Length - 1)
        {
            index++;
            SFX.Instance.PlayJumpSound();
            playerSprite.transform.position = stepsArray[index].position;
            currentString = dialogues[index];
            StartCoroutine(DisplayStringWordByWord());
        }
        else
        {
            nextButton.gameObject.SetActive(false);
            playAgainButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }
    }
}
