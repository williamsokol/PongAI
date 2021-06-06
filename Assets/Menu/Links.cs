using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Links : MonoBehaviour
{
    // Start is called before the first frame update
    public void GitHub()
    {
        Application.OpenURL("https://github.com/williamsokol/williamsokol.github.io");
    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
