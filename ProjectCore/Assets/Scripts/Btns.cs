using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btns : MonoBehaviour
{
    // Start is called before the first frame update
    public void restart()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
