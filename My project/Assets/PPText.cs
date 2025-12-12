using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class PPText : MonoBehaviour
{
    
    public string Name;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text=PlayerPrefs.GetInt(Name)+"";
    }
}
