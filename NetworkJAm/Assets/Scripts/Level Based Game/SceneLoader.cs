using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Animator anim;
    bool b = true;
    public void Reload()
    {
        Load(SceneManager.GetActiveScene().buildIndex);
    }

    public void Load(int index)
    {

        anim = GameObject.FindGameObjectWithTag("Fader").GetComponent<Animator>();
        StartCoroutine(loadLevel(index));
    }
    IEnumerator loadLevel(int i)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        if (b)
        {
            b = false;
            SceneManager.LoadScene(i);
        }
    }
}
