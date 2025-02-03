using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OpenExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OpenReset()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
    public void OpenResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
