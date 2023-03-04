using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCustomiser : MonoBehaviour
{
    private static CharCustomiser _instance;
    public static CharCustomiser Instance { get { return _instance; } }

    private int gender; //0-female 0-male
    private int skincolor; // 0-black, 1-brown, 2-white

    [HideInInspector]public int clotheIndex, hairIndex;
    private int clotheColourIndex;
    private int hairColourIndex;
    private int weaponIndex;
    

    [SerializeField] private CharacterCustomiserSO CharSO;

    [SerializeField] private GameObject BaseHolder, HairHolder, RightArmHolder;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else _instance = this;
    }

    private void Start()
    {
        clotheIndex = 0;
        clotheColourIndex = 0;
        hairIndex = 0;
        hairColourIndex = 0;
        weaponIndex = 0;
        skincolor = 0;
        gender = 0;
    }

    private void ChangeBlackFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlackClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlueClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleCyanClothes[clotheIndex].itemMaterial;
        }/*
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemalePurpleClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleWhiteClothes[clotheIndex].itemMaterial;
        }*/
    }

    private void ChangeWhiteFemaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlackClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlueClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleCyanClothes[clotheIndex].itemMaterial;
        }/*
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemalePurpleClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleWhiteClothes[clotheIndex].itemMaterial;
        }*/
    }

    private void ChangeBlackMaleClothes(int colorIndex)
    {
        if (colorIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlueClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleCyanClothes[clotheIndex].itemMaterial;
        }/*
        else if (colorIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMalePurpleClothes[clotheIndex].itemMaterial;
        }
        else if (colorIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleWhiteClothes[clotheIndex].itemMaterial;
        }*/
    }

    private void ChangeWhiteMaleClothes(int colorIndex)
    {
        if (clotheColourIndex == 0)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlackClothes[clotheIndex].itemMaterial;
        }
        else if (clotheColourIndex == 1)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlueClothes[clotheIndex].itemMaterial;
        }
        else if (clotheColourIndex == 2)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleCyanClothes[clotheIndex].itemMaterial;
        }/*
        else if (clotheColourIndex == 3)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMalePurpleClothes[clotheIndex].itemMaterial;
        }
        else if (clotheColourIndex == 4)
        {
            BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleWhiteClothes[clotheIndex].itemMaterial;
        }*/
    }
    public void SelectFemale()
    {
        if(skincolor == 0)
        {
            if (clotheIndex >= CharSO.BlackFemaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeBlackFemaleClothes(clotheColourIndex);
        }
        else if(skincolor ==2)
        {
            if (clotheIndex >= CharSO.WhiteFemaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeWhiteFemaleClothes(clotheColourIndex);
        }
        gender = 0;
    }

    public void SelectMale()
    {
        if (skincolor == 0)
        {
            if (clotheIndex >= CharSO.BlackMaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeBlackMaleClothes(clotheColourIndex);
        }
        else if (skincolor == 2)
        {
            if (clotheIndex >= CharSO.WhiteFemaleBlackClothes.Length)
            {
                clotheIndex = 0;
            }
            ChangeWhiteMaleClothes(clotheColourIndex);
        }
        gender = 1;
    }

    public void ChangeSkinColorToBlack()
    {
        if (gender == 0)
        {
            ChangeBlackFemaleClothes(clotheColourIndex);
        }
        else if (gender == 1)
        {
            ChangeBlackMaleClothes(clotheColourIndex);
        }
        skincolor = 0;
    }

    public void ChangeSkinColorToWhite()
    {
        if (gender == 0)
        {
            ChangeWhiteFemaleClothes(clotheColourIndex);
        }
        else if (gender == 1)
        {
            ChangeWhiteMaleClothes(clotheColourIndex);
        }
        skincolor = 2;
    }

    public bool ChangeClothingRightSelection()
    {
        bool tempBool= true;
        clotheIndex++;
        if(gender==0)
        {
            if(skincolor==0)
            {
                if (clotheIndex >= CharSO.BlackFemaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);
                tempBool = CharSO.BlackFemaleBlackClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                if (clotheIndex >= CharSO.WhiteFemaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeWhiteFemaleClothes(clotheColourIndex);

            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clotheIndex >= CharSO.BlackMaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeBlackMaleClothes(clotheColourIndex);

            }
            else if (skincolor == 2)
            {
                if (clotheIndex >= CharSO.WhiteMaleBlackClothes.Length)
                {
                    clotheIndex = 0;
                }
                ChangeWhiteMaleClothes(clotheColourIndex);
            }
        }
        return tempBool;
    }

    public bool ChangeClothingLeftSelection()
    {
        bool tempBool = true;
        clotheIndex--;
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                if (clotheIndex <0)
                {
                    clotheIndex = CharSO.BlackFemaleBlackClothes.Length - 1;
                }
                ChangeBlackFemaleClothes(clotheColourIndex);
                tempBool = CharSO.BlackFemaleBlackClothes[clotheIndex].isSold;
            }
            else if (skincolor == 2)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.WhiteFemaleBlackClothes.Length - 1;
                }
                ChangeWhiteFemaleClothes(clotheColourIndex);
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.BlackMaleBlackClothes.Length - 1;
                }
                ChangeBlackMaleClothes(clotheColourIndex);
            }
            else if (skincolor == 2)
            {
                if (clotheIndex < 0)
                {
                    clotheIndex = CharSO.WhiteMaleBlackClothes.Length - 1;
                }
                ChangeWhiteMaleClothes(clotheColourIndex);
            }
        }
        return tempBool;
    }

    public void ChangeHairRightSelection()
    {
        hairIndex++;
        if (hairIndex >= CharSO.HairList.Length)
        {
            hairIndex = 0;
        }
        InstantiateHair(hairIndex);
    }
    public void ChangeHairLeftSelection()
    {
        hairIndex--;

        if (hairIndex < 0)
        {
            hairIndex = CharSO.HairList.Length-1;
        }
        InstantiateHair(hairIndex);
    }

    private void InstantiateHair(int hairIndex)
    {
        GameObject tempHair;
        if (HairHolder.transform.childCount > 0)
        {
            foreach (Transform child in HairHolder.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject != HairHolder) Destroy(child.gameObject);
            }
        }
        tempHair = Instantiate(CharSO.HairList[hairIndex], HairHolder.transform);
        tempHair.transform.parent = HairHolder.transform;
    }

    public bool ChangeClotheColorToBlack()
    {
        bool isSold = true;
        if(gender == 0)
        {
            if(skincolor==0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlackClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackFemaleBlackClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlackClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteFemaleBlackClothes[clotheIndex].isSold;

            }
        }
        else if(gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlackClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackMaleBlackClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlackClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteMaleBlackClothes[clotheIndex].isSold;

            }
        }
        clotheColourIndex = 0;
        SetSoldIcon(isSold);
        return isSold;
    }

    public bool ChangeClotheColorToBlue()
    {
        bool isSold = true;

        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleBlueClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackFemaleBlueClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleBlueClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteFemaleBlueClothes[clotheIndex].isSold;

            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleBlueClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackMaleBlueClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleBlueClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteMaleBlueClothes[clotheIndex].isSold;

            }
        }
        clotheColourIndex = 1;
        SetSoldIcon(isSold);
        return isSold;

    }

    public bool ChangeClotheColorToCyan()
    {
        bool isSold = true;

        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleCyanClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackFemaleCyanClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleCyanClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteFemaleCyanClothes[clotheIndex].isSold;

            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleCyanClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackMaleCyanClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleCyanClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteMaleCyanClothes[clotheIndex].isSold;

            }
        }
        clotheColourIndex = 2;
        SetSoldIcon(isSold);
        return isSold;

    }
    /*
    public bool ChangeClotheColorToPurple()
    {
        bool isSold = true;

        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemalePurpleClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackFemalePurpleClothes[clotheIndex].isSold;
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemalePurpleClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteFemalePurpleClothes[clotheIndex].isSold;

            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMalePurpleClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackMalePurpleClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMalePurpleClothes[clotheIndex].itemMaterial;
                isSold = CharSO.WhiteMalePurpleClothes[clotheIndex].isSold;
            }
        }
        clotheColourIndex = 3;
        SetSoldIcon(isSold);
        return isSold;


    }

    public bool ChangeClotheColorToWhite()
    {
        bool isSold = true;

        if (gender == 0)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackFemaleWhiteClothes[clotheIndex].itemMaterial;
                isSold = CharSO.BlackFemaleWhiteClothes[clotheIndex].isSold;

            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteFemaleWhiteClothes[clotheIndex].itemMaterial;
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.BlackMaleWhiteClothes[clotheIndex].itemMaterial;
            }
            else if (skincolor == 2)
            {
                BaseHolder.GetComponent<SkinnedMeshRenderer>().material = CharSO.WhiteMaleWhiteClothes[clotheIndex].itemMaterial;
            }
        }
        clotheColourIndex = 4;
        SetSoldIcon(isSold);
        return isSold;

    }*/

    public void ChangeHairColorToBlack()
    {
        hairColourIndex = 0;
        ChangeHairColour(hairColourIndex);
    }

    public void ChangeHairColorToYellow()
    {
        hairColourIndex = 1;
        ChangeHairColour(hairColourIndex);

    }
    public void ChangeHairColorToBrown()
    {
        hairColourIndex = 2;
        ChangeHairColour(hairColourIndex);

    }
    public void ChangeHairColorToCyan()
    {
        hairColourIndex = 3;
        ChangeHairColour(hairColourIndex);

    }
    public void ChangeHairColorToPurple()
    {
        hairColourIndex = 4;
        ChangeHairColour(hairColourIndex);
    }
    public void ChangeHairColorToRed()
    {
        hairColourIndex = 5;
        ChangeHairColour(hairColourIndex);
    }
    public void ChangeHairColorToWhite()
    {
        hairColourIndex = 6;
        ChangeHairColour(hairColourIndex);
    }

    private void ChangeHairColour(int colorIndex)
    {
        if(HairHolder.GetComponentInChildren<MeshRenderer>()!=null)
        {
            HairHolder.GetComponentInChildren<MeshRenderer>().material = CharSO.HairColor[colorIndex];
        }
        else
        {
            HairHolder.GetComponentInChildren<SkinnedMeshRenderer>().material = CharSO.HairColor[colorIndex];

        }
    }

    private void SetSoldIcon(bool isSold)
    {
        if (isSold)
        {
            ConfiguratorUIManager.Instance.DisableSoldIcon();
        }
        else ConfiguratorUIManager.Instance.EnableSoldIcon();
    }

    public void MarkItemAsSold()
    {
        if(gender==0)
        {
            if(skincolor ==0)
            {
                if(clotheColourIndex==0)
                {
                    CharSO.BlackFemaleBlackClothes[clotheIndex].isSold = true;
                }else if(clotheColourIndex ==1)
                {
                    CharSO.BlackFemaleBlueClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 2)
                {
                    CharSO.BlackFemaleCyanClothes[clotheIndex].isSold = true;
                }/*
                else if (clotheColourIndex == 3)
                {
                    CharSO.BlackFemalePurpleClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 4)
                {
                    CharSO.BlackFemaleWhiteClothes[clotheIndex].isSold = true;
                }*/
            }else if (skincolor == 2)
            {
                if (clotheColourIndex == 0)
                {
                    CharSO.WhiteFemaleBlackClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 1)
                {
                    CharSO.WhiteFemaleBlueClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 2)
                {
                    CharSO.WhiteFemaleCyanClothes[clotheIndex].isSold = true;
                }/*
                else if (clotheColourIndex == 3)
                {
                    CharSO.WhiteFemalePurpleClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 4)
                {
                    CharSO.WhiteFemaleWhiteClothes[clotheIndex].isSold = true;
                }*/
            }
        }
        else if(gender==1)
        {
            if (skincolor == 0)
            {
                if (clotheColourIndex == 0)
                {
                    CharSO.BlackMaleBlackClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 1)
                {
                    CharSO.BlackMaleBlueClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 2)
                {
                    CharSO.BlackMaleCyanClothes[clotheIndex].isSold = true;
                }/*
                else if (clotheColourIndex == 3)
                {
                    CharSO.BlackMalePurpleClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 4)
                {
                    CharSO.BlackMaleWhiteClothes[clotheIndex].isSold = true;
                }*/
            }
            else if (skincolor == 2)
            {
                if (clotheColourIndex == 0)
                {
                    CharSO.WhiteMaleBlackClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 1)
                {
                    CharSO.WhiteMaleBlueClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 2)
                {
                    CharSO.WhiteMaleCyanClothes[clotheIndex].isSold = true;
                }/*
                else if (clotheColourIndex == 3)
                {
                    CharSO.WhiteMalePurpleClothes[clotheIndex].isSold = true;
                }
                else if (clotheColourIndex == 4)
                {
                    CharSO.WhiteMaleWhiteClothes[clotheIndex].isSold = true;
                }*/
            }
        }
    }

    public int GetItemPrice()
    {
        int price= 0;
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                if (clotheColourIndex == 0)
                {
                    price = CharSO.BlackFemaleBlackClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 1)
                {
                    price = CharSO.BlackFemaleBlueClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 2)
                {
                    price = CharSO.BlackFemaleCyanClothes[clotheIndex].price;
                }/*
                else if (clotheColourIndex == 3)
                {
                    price = CharSO.BlackFemalePurpleClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 4)
                {
                    price = CharSO.BlackFemaleWhiteClothes[clotheIndex].price;
                }*/
            }
            else if (skincolor == 2)
            {
                if (clotheColourIndex == 0)
                {
                    price = CharSO.WhiteFemaleBlackClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 1)
                {
                    price = CharSO.WhiteFemaleBlueClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 2)
                {
                    price = CharSO.WhiteFemaleCyanClothes[clotheIndex].price;
                }/*
                else if (clotheColourIndex == 3)
                {
                    price = CharSO.WhiteFemalePurpleClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 4)
                {
                    price = CharSO.WhiteFemaleWhiteClothes[clotheIndex].price;
                }*/
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clotheColourIndex == 0)
                {
                    price = CharSO.BlackMaleBlackClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 1)
                {
                    price = CharSO.BlackMaleBlueClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 2)
                {
                    price = CharSO.BlackMaleCyanClothes[clotheIndex].price;
                }/*
                else if (clotheColourIndex == 3)
                {
                    price = CharSO.BlackMalePurpleClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 4)
                {
                    price = CharSO.BlackMaleWhiteClothes[clotheIndex].price;
                }*/
            }
            else if (skincolor == 2)
            {
                if (clotheColourIndex == 0)
                {
                    price = CharSO.WhiteMaleBlackClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 1)
                {
                    price = CharSO.WhiteMaleBlueClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 2)
                {
                    price = CharSO.WhiteMaleCyanClothes[clotheIndex].price;
                }/*
                else if (clotheColourIndex == 3)
                {
                    price = CharSO.WhiteMalePurpleClothes[clotheIndex].price;
                }
                else if (clotheColourIndex == 4)
                {
                    price = CharSO.WhiteMaleWhiteClothes[clotheIndex].price;
                }*/
            }
        }
        return price;
    }
    public bool GetItemStatus()
    {
        bool status = true;
        if (gender == 0)
        {
            if (skincolor == 0)
            {
                if (clotheColourIndex == 0)
                {
                    status = CharSO.BlackFemaleBlackClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 1)
                {
                    status = CharSO.BlackFemaleBlueClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 2)
                {
                    status = CharSO.BlackFemaleCyanClothes[clotheIndex].isSold;
                }/*
                else if (clotheColourIndex == 3)
                {
                    status = CharSO.BlackFemalePurpleClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 4)
                {
                    status = CharSO.BlackFemaleWhiteClothes[clotheIndex].isSold;
                }*/
            }
            else if (skincolor == 2)
            {
                if (clotheColourIndex == 0)
                {
                    status = CharSO.WhiteFemaleBlackClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 1)
                {
                    status = CharSO.WhiteFemaleBlueClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 2)
                {
                    status = CharSO.WhiteFemaleCyanClothes[clotheIndex].isSold;
                }/*
                else if (clotheColourIndex == 3)
                {
                    status = CharSO.WhiteFemalePurpleClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 4)
                {
                    status = CharSO.WhiteFemaleWhiteClothes[clotheIndex].isSold;
                }*/
            }
        }
        else if (gender == 1)
        {
            if (skincolor == 0)
            {
                if (clotheColourIndex == 0)
                {
                    status = CharSO.BlackMaleBlackClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 1)
                {
                    status = CharSO.BlackMaleBlueClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 2)
                {
                    status = CharSO.BlackMaleCyanClothes[clotheIndex].isSold;
                }/*
                else if (clotheColourIndex == 3)
                {
                    status = CharSO.BlackMalePurpleClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 4)
                {
                    status = CharSO.BlackMaleWhiteClothes[clotheIndex].isSold;
                }*/
            }
            else if (skincolor == 2)
            {
                if (clotheColourIndex == 0)
                {
                    status = CharSO.WhiteMaleBlackClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 1)
                {
                    status = CharSO.WhiteMaleBlueClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 2)
                {
                    status = CharSO.WhiteMaleCyanClothes[clotheIndex].isSold;
                }/*
                else if (clotheColourIndex == 3)
                {
                    status = CharSO.WhiteMalePurpleClothes[clotheIndex].isSold;
                }
                else if (clotheColourIndex == 4)
                {
                    status = CharSO.WhiteMaleWhiteClothes[clotheIndex].isSold;
                }*/
            }
        }
        return status;
    }
}
