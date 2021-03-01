using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider funSlider;
    public GameObject pet;

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = pet.GetComponent<Pet>().Hunger;
        happinessSlider.value = pet.GetComponent<Pet>().Happiness;
        funSlider.value = pet.GetComponent<Pet>().Fun;
    }

    public void GoToPark()
    {
        //LOAD PARK SCENE AND SEND LION PREFAB 
    }
}
