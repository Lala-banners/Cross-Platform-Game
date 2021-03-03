using UnityEngine;

namespace PetTime.Menu
{
    public class Pause : MonoBehaviour
    {
        #region UI Elements
        public static bool isPaused;
        public GameObject optionsMenu;
        #endregion

        public void Paused(GameObject panel)
        {
            isPaused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            panel.SetActive(true);
        }

        public void UnPaused()
        {
            isPaused = false;
            Time.timeScale = 1;
            gameObject.SetActive(false);
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
                    gameObject.SetActive(true);
                }
                else
                {
                    isPaused = !isPaused;
                    if (isPaused)
                    {
                        Paused(gameObject);
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