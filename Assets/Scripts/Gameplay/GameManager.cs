using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider funSlider;
    public GameObject pet;
    public GameObject[] petList;

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

    private void Start()
    {
        changeNamePanel.SetActive(false);
        editName.gameObject.SetActive(false);
        explore.SetActive(false);
        quitButton.SetActive(false);

        CreatePet(0);
    }

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = pet.GetComponent<Pet>().Hunger;
        happinessSlider.value = pet.GetComponent<Pet>().Happiness;
        funSlider.value = pet.GetComponent<Pet>().Fun;
        nameText.text = pet.GetComponent<Pet>().Name;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreatePet(1);
        }
    }

    public void ChangeNickname(bool b)
    {
        changeNamePanel.SetActive(!changeNamePanel.activeInHierarchy);
        
        if(b)
        {
            pet.GetComponent<Pet>().Name = nameInput.GetComponent<InputField>().text; //Connect Name to Input field object
            PlayerPrefs.SetString("name", pet.GetComponent<Pet>().Name); //Set the string name to the Pet name 
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
                pet.GetComponent<Pet>().SavePetInfo();
                QuitGame();
                break;
        }

    }

    private void CreatePet(int i)
    {
        if(pet)
        {
            Destroy(pet);
            pet = Instantiate(petList[i], Vector3.zero, Quaternion.identity) as GameObject;

        }

        if(changeNamePanel.activeInHierarchy)
        {
            changeNamePanel.SetActive(false);
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
