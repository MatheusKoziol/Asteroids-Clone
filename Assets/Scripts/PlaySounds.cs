using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySounds : MonoBehaviour
{

    public bool mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(mainMenu)
        {
            AudioManager.Instance.Play("MainTheme");
        }
    }

    public void PlaySound(string name)
    {
        AudioManager.Instance.Play(name);
    }

    public void PauseSound(string name)
    {
        AudioManager.Instance.Pause(name);
    }

    public void StopSound(string name)
    {
        AudioManager.Instance.Stop(name);
    }


}
