using UnityEngine;
using UnityEditor;

namespace PetTime.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame(int sceneIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }

        public void QuitGame()
        {
            Debug.Log("Quitting Game");
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
    }
}
