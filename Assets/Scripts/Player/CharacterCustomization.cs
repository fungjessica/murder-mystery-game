using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    public SpriteRenderer hairSlot;
    public SpriteRenderer clothingSlot;

    public Sprite[] hairOptions; 
    public Sprite[] clothingOptions; 

    private int currentHairIndex = 0;
    private int currentClothingIndex = 0;

    void Start()
    {
        LoadChoices();
    }

    void Update()
    {
        
    }

    public void OnHairLeftButtonPressed()
    {
        ChangeHair(-1); 
    }

    public void OnHairRightButtonPressed()
    {
        ChangeHair(1); 
    }

    public void OnClothingLeftButtonPressed()
    {
        ChangeClothing(-1); 
    }

    public void OnClothingRightButtonPressed()
    {
        ChangeClothing(1); 
    }

    void ChangeHair(int direction)
    {
        currentHairIndex = (currentHairIndex + direction + hairOptions.Length) % hairOptions.Length;
        hairSlot.sprite = hairOptions[currentHairIndex];
        SaveChoices();
    }

    void ChangeClothing(int direction)
    {
        currentClothingIndex = (currentClothingIndex + direction + clothingOptions.Length) % clothingOptions.Length;
        clothingSlot.sprite = clothingOptions[currentClothingIndex];
        SaveChoices();
    }
    private void SaveChoices()
    {
        PlayerPrefs.SetInt("HairIndex", currentHairIndex);
        PlayerPrefs.SetInt("ClothingIndex", currentClothingIndex);
        PlayerPrefs.Save();
    }
    private void LoadChoices()
    {
        currentHairIndex = PlayerPrefs.GetInt("HairIndex", 0);
        currentClothingIndex = PlayerPrefs.GetInt("ClothingIndex", 1);

        hairSlot.sprite = hairOptions[currentHairIndex];
        clothingSlot.sprite = clothingOptions[currentClothingIndex];
    }
}
