using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class _GameManager : MonoBehaviour
{
    public static _GameManager instance = null;

    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider funSlider;
    public MasterPet pet;
    public Transform[] walkPoints;
    public int clickCount;

    #region UI Elements
    [Header("Quick Menu")]
    public TMP_Text nameText;
    public Button editName;
    public Button menuButton;
    public GameObject changeNamePanel;
    public GameObject nameInput;
    public GameObject explore;
    public GameObject quitButton;
    public GameObject feed;
    public GameObject call;
    public GameObject playFetch;
    public AudioSource whistleAudio;
    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        //Set all icons in the quick menu to false
        changeNamePanel.SetActive(false);
        editName.gameObject.SetActive(false);
        explore.SetActive(false);
        quitButton.SetActive(false);
        feed.SetActive(false);
        call.SetActive(false);
        playFetch.SetActive(false);
    }

    private void Update()
    {
        hungerSlider.value = pet.Hunger;
        happinessSlider.value = pet.Happiness;
        funSlider.value = pet.Fun;
        nameText.text = pet.Name;

        if(Input.GetKeyDown(KeyCode.I))
        {
            changeNamePanel.SetActive(true);
            editName.enabled = true;
        }
    }

    /// <summary>
    /// Function to set the nickname of your pet.
    /// </summary>
    /// <param name="b">Bool to check if is true then change name.</param>
    public void ChangeNickname(bool b)
    {
        if(b)
        {
            pet.Name = nameInput.GetComponent<InputField>().text; //Connect Name to Input field object
            PlayerPrefs.SetString("name", pet.Name); //Set the string name to the Pet name 
        }
    }

    /// <summary>
    /// Call pet with a whistle.
    /// </summary>
    public void Call()
    {
        //whistleAudio.Play();
        //Move pet to original starting position
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
