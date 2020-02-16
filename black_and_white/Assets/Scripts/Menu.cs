using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayLevel(int level)
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
