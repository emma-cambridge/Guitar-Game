using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    private bool isInTriggerZone = false;
    private GameObject currentNoteObject = null;
    SpriteRenderer sr;
    Color old;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        old = sr.color;

        PlayerPrefs.SetInt("Score", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(Pressed());
        }

        if (Input.GetKeyDown(key) && isInTriggerZone)
        {
            Destroy(currentNoteObject);
            AddScore();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Note"))
        {
            isInTriggerZone = true;
            currentNoteObject = col.gameObject;
            Debug.Log("Entered zone with Note: " + currentNoteObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject == currentNoteObject)
        {
            isInTriggerZone = false;
            currentNoteObject = null;
            Debug.Log("Exited zone.");
        }
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+1);
    }

    IEnumerator Pressed()
    {
        sr.color = new Color(0,0,0);
        yield return new WaitForSeconds(0.2f);
        sr.color=old;
    }
}