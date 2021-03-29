using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider funSlider;
    public MasterPet pet;
    public Transform[] walkPoints;

    #region UI Elements
    [Header("Quick Menu")]
    public TMP_Text nameText;
    public Button editName;
    public Button menuButton;
    public GameObject changeNamePanel;
    public GameObject explore;
    public GameObject nameInput;
    public GameObject quitButton;
    public GameObject feed;
    #endregion

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        changeNamePanel.SetActive(false);
        editName.gameObject.SetActive(false);
        explore.SetActive(false);
        quitButton.SetActive(false);
        feed.SetActive(false);
    }

    private void Update()
    {
        hungerSlider.value = pet.Hunger;
        happinessSlider.value = pet.Happiness;
        funSlider.value = pet.Fun;
        nameText.text = pet.Name;

        int r = Random.Range(0, 1);
    }

    /// <summary>
    /// Function to set the nickname of your pet.
    /// </summary>
    /// <param name="b">Bool to check if is true then change name.</param>
    public void ChangeNickname(bool b)
    {
        changeNamePanel.SetActive(!changeNamePanel.activeInHierarchy);
        
        if(b)
        {
            pet.Name = nameInput.GetComponent<InputField>().text; //Connect Name to Input field object
            PlayerPrefs.SetString("name", pet.Name); //Set the string name to the Pet name 
        }
    }

    public void ButtonBehaviour(int i)
    {
        switch (i)
        {
            case (0):
            default:
                changeNamePanel.SetActive(!changeNamePanel.activeInHierarchy);
                break;
            case (1):
                break;
            case (2):
                break;
            case (3):
                break;
            case (4):
                pet.SavePetInfo();
                QuitGame();
                break;
        }
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
