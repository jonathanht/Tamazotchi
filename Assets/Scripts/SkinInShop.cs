using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInShop : MonoBehaviour
{
    public SkinInfo skinInfo;

    public TextMeshProUGUI buttonText;
    public Image skinImage;
    

    public bool isSkinUnlocked;

    private void Awake() {
        skinImage.sprite = skinInfo.skinSprite;
        buttonText.text = "$" + skinInfo.skinPrice;
        IsSkinUnlocked();
        if (skinInfo.skinPrice == 0) {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
    }

    private void IsSkinUnlocked() {
        if (PlayerPrefs.GetInt(skinInfo.skinID.ToString()) == 1) {
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
    }

    public void OnButtonPress() {
        if (isSkinUnlocked) {
            FindObjectOfType<SkinManager>().EquipSkin(skinInfo);
        }
        else {
            if(FindObjectOfType<Money>().TryRemoveMoney(skinInfo.skinPrice)) {
                PlayerPrefs.SetInt(skinInfo.skinID.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
}
