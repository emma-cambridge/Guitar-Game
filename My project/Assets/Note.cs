using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private GameObject currentNoteObject = null;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        rb.linearVelocity=new Vector2(0,-4);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
