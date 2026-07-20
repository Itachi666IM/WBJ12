using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button skipButton;
    [SerializeField] private Button playButton;
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
            //Play SFX
        });

        skipButton.onClick.AddListener(() =>
        {
            //Play SFX
            SceneManager.LoadScene("Game");
        });

        playButton.onClick.AddListener(() =>
        {
            //Play SFX
            SceneManager.LoadScene("Game");
        });
    }

    private IEnumerator DisplayStringWordByWord()
    {
        foreach(char c in currentString)
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
        if(index < dialogues.Length-1)
        {
            index++;
            playerSprite.transform.position = stepsArray[index].position;
            currentString = dialogues[index];
            StartCoroutine(DisplayStringWordByWord());
        }
        else
        {
            nextButton.gameObject.SetActive(false);
            skipButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
        }
    }
}
