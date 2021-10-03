using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUnaVez : MonoBehaviour
{
   
    public Animator anim;
    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }
    public void YaViElTutorial()
    {
        anim.SetBool("OneTime",true);
     
    }
}
