using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLanguage : MonoBehaviour
{
    [TextArea(3, 8)]
    [SerializeField] string[] texts;
    [SerializeField] Text text;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Started") == 0) {
            PlayerPrefs.SetInt("lang", 1);
            PlayerPrefs.SetInt("Started",1);
        }

        text.text = texts[PlayerPrefs.GetInt("lang")];
    }
    public void setL(int l)
    {
        PlayerPrefs.SetInt("lang", l);
        foreach(SetLanguage s in FindObjectsOfType<SetLanguage>())
        {
            s.OverwriteL();
        }
    }

    private void OnEnable()
    {
        text.text = texts[PlayerPrefs.GetInt("lang")];
    }

    public void OverwriteL()
    {
        text.text = texts[PlayerPrefs.GetInt("lang")];
    }
}
