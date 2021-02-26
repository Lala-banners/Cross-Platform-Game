using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider funSlider;
    public GameObject pet;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = pet.GetComponent<Pet>()._hunger;
        happinessSlider.value = pet.GetComponent<Pet>()._happiness;
        funSlider.value = pet.GetComponent<Pet>()._fun;
    }
}
