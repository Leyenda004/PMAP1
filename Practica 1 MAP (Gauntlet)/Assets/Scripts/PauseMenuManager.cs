using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject pauseMenu;
    PlayerMovement playerscript;
    Gun gunscript;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(resumeButton);
        playerscript = FindAnyObjectByType<PlayerMovement>();
        gunscript = playerscript.gameObject.GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            playerscript.enabled = false;
            gunscript.enabled = false;

        }
    }
    public void OpenExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        playerscript.enabled = true;
        gunscript.enabled = true;
    }

    public void OpenReset()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        playerscript.enabled = true;
        gunscript.enabled = true;
    }
    
    public void OpenResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        playerscript.enabled = true;
        gunscript.enabled = true;
    }
}
