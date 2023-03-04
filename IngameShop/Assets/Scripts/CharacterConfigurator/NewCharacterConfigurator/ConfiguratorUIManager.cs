using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ConfiguratorUIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    private static ConfiguratorUIManager _instance;
    public static ConfiguratorUIManager Instance { get { return _instance; } }
    [SerializeField] private GameObject ModularCharacter;

    private bool isCharRotating;
    private Vector3 mouseInitialPos;
    private Vector3 mouseOffset;
    private float mouseDragSensitivity;
    private Vector3 charRotation;

    [SerializeField] private TMP_Text HairText, ClotheText;

    [SerializeField] private Image disabledIcon;
    [SerializeField] private TMP_Text CoinText, buyButtonText;
    [SerializeField] private Button buyButton;


    private void Awake()
    {
        if(_instance!=null && _instance!= this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        isCharRotating = false;
        mouseDragSensitivity = 0.4f;
        DisableSoldIcon();
        UpdateButton();

    }

    private void Update()
    {
        if (isCharRotating)
        {
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * 0.5f;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    //Character Rotation
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        mouseInitialPos = Input.mousePosition;
        isCharRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

        isCharRotating = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Debug.Log("OnPointerMove !isCharRotating");

        if (isCharRotating)
        {
            Debug.Log("OnPointerMove isCharRotating");
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * -mouseDragSensitivity;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    //UI Elements Functionality - Gender Selection
    public void SelectMaleButton()
    {
        CharCustomiser.Instance.SelectMale();
        UpdateButton();
    }

    public void SelectFemaleButton()
    {
        CharCustomiser.Instance.SelectFemale();
        UpdateButton();
    }

    //UI Elements Functionality - Skin Colour Selection
    public void SelectBlackSkinColorButton()
    {
        CharCustomiser.Instance.ChangeSkinColorToBlack();
        UpdateButton();
    }

    public void SelectWhiteSkinColorButton()
    {
        CharCustomiser.Instance.ChangeSkinColorToWhite();
        UpdateButton();
    }

    private void UpdateHairText(int selectionNumber)
    {
        HairText.text = "Hair  " + selectionNumber;
    }
    //UI Elements Functionality - Hair Selection
    public void ClickRightHairSelectionButton()
    {
        CharCustomiser.Instance.ChangeHairRightSelection();
        int temp = CharCustomiser.Instance.hairIndex+1;
        UpdateHairText(temp);
        UpdateButton();
    }

    public void ClickLeftHairSelectionButton()
    {
        CharCustomiser.Instance.ChangeHairLeftSelection();
        int temp = CharCustomiser.Instance.hairIndex + 1;
        UpdateHairText(temp);
        UpdateButton();
    }
    private void UpdateClotheText(int selectionNumber)
    {
        ClotheText.text = "Clothe " + selectionNumber;
    }
    public void ClickRightClotheSelectionButton()
    {
        bool isSold = CharCustomiser.Instance.ChangeClothingRightSelection();
        int temp = CharCustomiser.Instance.clotheIndex + 1;
        UpdateClotheText(temp);
        if(isSold)
        {
            DisableSoldIcon();
            
        }
        else
        {
            EnableSoldIcon();
        }
        UpdateButton();
    }
    public void ClickLeftClotheSelectionButton()
    {
        bool isSold = CharCustomiser.Instance.ChangeClothingLeftSelection();

        int temp = CharCustomiser.Instance.clotheIndex + 1;
        UpdateClotheText(temp);
        UpdateDisableIcon(isSold);
        UpdateButton();

    }


    //UI Elements Functionality - Clothe Colour Selection
    public void ClickClotheColorBlackButton()
    {
        bool isSold = CharCustomiser.Instance.ChangeClotheColorToBlack();

        UpdateDisableIcon(isSold);
        UpdateButton();

    }
    public void ClickClotheColorBlueButton()
    {
        bool isSold = CharCustomiser.Instance.ChangeClotheColorToBlue();

        UpdateDisableIcon(isSold);
        UpdateButton();

    }
    public void ClickClotheColorCyanButton()
    {
        bool isSold = CharCustomiser.Instance.ChangeClotheColorToCyan();

        UpdateDisableIcon(isSold);
        UpdateButton();

    }

    /*
    public void ClickClotheColorPurpleButton()
    {
        bool isSold = CharCustomiser.Instance.ChangeClotheColorToPurple();
        int price = CharCustomiser.Instance.GetItemPrice();

        if (isSold)
        {
            DisableSoldIcon();
        }
        else
        {
            EnableSoldIcon();
        }
        UpdateButton(isSold, price);

    }
    public void ClickClotheColorWhiteButton()
    {
        bool isSold = CharCustomiser.Instance.ChangeClotheColorToWhite();
        int price = CharCustomiser.Instance.GetItemPrice();

        if (isSold)
        {
            DisableSoldIcon();
        }
        else
        {
            EnableSoldIcon();
        }
        UpdateButton(isSold, price);

    }
    //UI Elements Functionality - Hair Colour Selection
    public void ClickHairColorToBlackButton()
    {
        CharCustomiser.Instance.ChangeHairColorToBlack();
    }
    public void ClickHairColorToYellowButton()
    {
        CharCustomiser.Instance.ChangeHairColorToYellow();
    }
    public void ClickHairColorToBrownButton()
    {
        CharCustomiser.Instance.ChangeHairColorToBrown();
    }
    public void ClickHairColorToCyanButton()
    {
        CharCustomiser.Instance.ChangeHairColorToCyan();
    }
    public void ClickHairColorToPurpleButton()
    {
        CharCustomiser.Instance.ChangeHairColorToPurple();
    }
    public void ClickHairColorToRedButton()
    {
        CharCustomiser.Instance.ChangeHairColorToRed();
    }
    public void ClickHairColorToWhiteButton()
    {
        CharCustomiser.Instance.ChangeHairColorToWhite();
    }
    */
    public void DisableSoldIcon()
    {
        disabledIcon.gameObject.SetActive(false);
    }
    public void EnableSoldIcon()
    {
        disabledIcon.gameObject.SetActive(true);
    }

    public void UpdateDisableIcon(bool isSold)
    {
        if (isSold)
        {
            DisableSoldIcon();
        }
        else
        {
            EnableSoldIcon();
        }
        UpdateButton();
    }
    public void UpdateCoinText(string text)
    {
        CoinText.text = text;
    }

    public void UpdateButton()
    {
        int price = CharCustomiser.Instance.GetItemPrice();
        bool isSold = CharCustomiser.Instance.GetItemStatus();
        buyButtonText.text = "BUY  " + price.ToString();
        if (isSold)
        {
            buyButton.interactable = false;
            buyButtonText.text = "BUY";
            DisableSoldIcon();
        }
        else
        {
            buyButton.interactable = true;
            buyButtonText.text = "BUY  " + price.ToString();
            EnableSoldIcon();
        }
    }

    public void ClickBuyButton()
    {
        int price = CharCustomiser.Instance.GetItemPrice();
        int currentCoin = PlayerGameCurrency.Instance.GetCurrentCoin();

        if(price<=currentCoin)
        {
            if(!CharCustomiser.Instance.GetItemStatus())
            {
                PlayerGameCurrency.Instance.UpdatePlayerCurrency(price);
                CharCustomiser.Instance.MarkItemAsSold();
                DisableSoldIcon();
            }

        }
    }
}
