using UnityEngine;

namespace PetTime.Menu
{
    public class Pause : MonoBehaviour
    {
        #region UI Elements
        public static bool isPaused;
        public GameObject pauseMenu;
        public GameObject optionsMenu;
        #endregion

        public void Paused(GameObject panel)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            panel.SetActive(true);
        }

        public void UnPaused()
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
        }

        private void Start()
        {
            UnPaused();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (optionsMenu.activeSelf)
                {
                    optionsMenu.SetActive(false);
                    pauseMenu.SetActive(true);
                }
                else
                {
                    isPaused = !isPaused;
                    if (isPaused)
                    {
                        Paused(pauseMenu);
                    }
                    else
                    {
                        UnPaused();
                    }
                }
            }

        }


    }
}