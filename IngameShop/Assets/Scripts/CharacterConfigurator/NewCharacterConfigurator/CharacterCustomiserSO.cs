using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterCustomiserSO")]
public class CharacterCustomiserSO : ScriptableObject
{
    public CharacterCustomiseItem[] BlackFemaleBlackClothes;
    public CharacterCustomiseItem[] BlackFemaleBlueClothes;
    public CharacterCustomiseItem[] BlackFemaleCyanClothes;
    //public CharacterCustomiseItem[] BlackFemalePurpleClothes;
    //public CharacterCustomiseItem[] BlackFemaleWhiteClothes;


    public CharacterCustomiseItem[] WhiteFemaleBlackClothes;
    public CharacterCustomiseItem[] WhiteFemaleBlueClothes;
    public CharacterCustomiseItem[] WhiteFemaleCyanClothes;
    //public CharacterCustomiseItem[] WhiteFemalePurpleClothes;
    //public CharacterCustomiseItem[] WhiteFemaleWhiteClothes;

    public CharacterCustomiseItem[] BlackMaleBlackClothes;
    public CharacterCustomiseItem[] BlackMaleBlueClothes;
    public CharacterCustomiseItem[] BlackMaleCyanClothes;
    //public CharacterCustomiseItem[] BlackMalePurpleClothes;
    //public CharacterCustomiseItem[] BlackMaleWhiteClothes;

    public CharacterCustomiseItem[] WhiteMaleBlackClothes;
    public CharacterCustomiseItem[] WhiteMaleBlueClothes;
    public CharacterCustomiseItem[] WhiteMaleCyanClothes;
    //public CharacterCustomiseItem[] WhiteMalePurpleClothes;
    //public CharacterCustomiseItem[] WhiteMaleWhiteClothes;

    public GameObject[] HairList;
    public Material[] HairColor;



}
