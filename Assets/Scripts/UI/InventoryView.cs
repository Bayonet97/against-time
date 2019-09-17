using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    public Image WoodImage;
    public Text WoodText;
    public Image AxeImage;
    public Image WheelbarrowImage;
    public Image KeyImage;

    [SerializeField] private Character _character;
    private CharacterInventory _characterInventory;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        WoodImage.gameObject.SetActive(false);
        AxeImage.gameObject.SetActive(false);
        WheelbarrowImage.gameObject.SetActive(false);
        KeyImage.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CharacterInventory.OnInventoryChanged += UpdateInventory;
    }

    private void OnDestroy()
    {
        CharacterInventory.OnInventoryChanged -= UpdateInventory;
    }


    void UpdateInventory()
    {
        if (_characterInventory == null)
            _characterInventory = _character.gameObject.GetComponent<CharacterInventory>();
        if (this.gameObject.activeSelf == false)
            this.gameObject.SetActive(true);
        UpdateWoodAmount(_characterInventory.WoodAmount);
        if (_characterInventory.HasAxe && AxeImage.gameObject.activeSelf == false)
            UpdateAxeImage();
        if (_characterInventory.HasWheelbarrow && WheelbarrowImage.gameObject.activeSelf == false)
            UpdateWheelbarrowImage();
        if (_characterInventory.HasKey && KeyImage.gameObject.activeSelf == false)
            UpdateKeyImage();
    }
    private void UpdateWoodAmount(int newWoodValue)
    {
        WoodText.text = newWoodValue.ToString();
        WoodImage.gameObject.SetActive(true);
    }
    private void UpdateAxeImage()
    {
        AxeImage.gameObject.SetActive(true);
    }
    private void UpdateWheelbarrowImage()
    {
        WheelbarrowImage.gameObject.SetActive(true);
    }
    private void UpdateKeyImage()
    {
        KeyImage.gameObject.SetActive(true);
    }
}
