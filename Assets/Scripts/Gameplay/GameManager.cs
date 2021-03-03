using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider funSlider;
    public GameObject pet;

    #region UI Elements
    [Header("Quick Menu")]
    public TMP_Text nameText;
    public Button editName;
    public Button menuButton;
    #endregion

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = pet.GetComponent<Pet>().Hunger;
        happinessSlider.value = pet.GetComponent<Pet>().Happiness;
        funSlider.value = pet.GetComponent<Pet>().Fun;
        nameText.text = pet.GetComponent<Pet>().Name;
    }

    public void GoToPark()
    {
        //LOAD PARK SCENE AND SEND LION PREFAB 
    }
}
