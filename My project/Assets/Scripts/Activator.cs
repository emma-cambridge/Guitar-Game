using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour
{
    private KeyCode key = KeyCode.F;
    private bool isInTriggerZone = false;
    private GameObject currentNoteObject = null;

    void Start()
    {
        // You can set the key here if you want: key = KeyCode.F;
    }

    void Update()
    {
        if (Input.GetKeyDown(key) && isInTriggerZone && currentNoteObject != null)
        {
            Destroy(currentNoteObject);
            
            currentNoteObject = null; 
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
}