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
    public Pet pet;

    #region UI Elements
    [Header("Quick Menu")]
    public TMP_Text nameText;
    public Button editName;
    public Button menuButton;
    public GameObject changeNamePanel;
    public GameObject explore;
    public GameObject nameInput;
    public GameObject quitButton;
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
            Destroy(gameObject);
            return;
        }
    }


    private void Start()
    {
        changeNamePanel.SetActive(false);
        editName.gameObject.SetActive(false);
        explore.SetActive(false);
        quitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = pet.Hunger;
        happinessSlider.value = pet.Happiness;
        funSlider.value = pet.Fun;
        nameText.text = pet.Name;
    }

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
