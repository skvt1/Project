using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DialogueScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    public  Animator animator;
    [SerializeField]
    private Image npcImg;
    [SerializeField]
    private Image imger;
    private bool npcB = true;
    [SerializeField]
    private Image playerImg;
    private bool playerB = false;
    [SerializeField]
    private float speechSpeed = 0.02f;
    private Queue<string> sentences;
    [SerializeField]
    public List<Sprite> images;
    string imgnamer;
    // Start is called before the first frame update
    void Start()
    {
        npcImg.gameObject.SetActive(true);
        playerImg.gameObject.SetActive(false);
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        npcImg.gameObject.SetActive(true);
        playerImg.gameObject.SetActive(false);
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNext();
    }
    public void SetImage(string _name)
    {
        Debug.Log(_name);
            imgnamer = _name;
            npcImg.sprite = images.Find(obj => obj.name == imgnamer+"S1");

    }
    public void DisplayNext()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        if (sentence[0] == '#')
        {
            sentence = sentence.Substring(1);
            npcB = !npcB;
            playerB = !playerB;
            playerImg.gameObject.SetActive(playerB);
            npcImg.gameObject.SetActive(npcB);

        }
        

            dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(Typer(sentence));
        
        

    }
    IEnumerator Typer (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(speechSpeed);
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
