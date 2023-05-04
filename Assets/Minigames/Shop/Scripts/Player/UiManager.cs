using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI hp;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image avatar;
    public Sprite avatar1;  //100
    public Sprite avatar2;
    public Sprite avatar3;
    public Sprite avatar4;  //0

    public GameObject rKey;
    public GameObject gKey;
    public GameObject bKey;

    private static UiManager _instance;
    public static UiManager Instance
    { 
        get { return _instance; } 
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void UpdateHp(int hpAmount)
    {
        hp.text = hpAmount.ToString();
        UpdateAvatar(hpAmount);
    }

    public void UpdateArmor(int armorAmount)
    {
        armor.text = armorAmount.ToString();
    }

    public void UpdateAmmo(int ammoAmount)
    {
        ammo.text = ammoAmount.ToString();
    }
    public void UpdateAvatar(int hpAmount)
    {
        if(hpAmount >= 71)
        {
            avatar.sprite = avatar1;
        }
        if (hpAmount < 71 && hpAmount >= 41)
        {
            avatar.sprite = avatar2;
        }
        if (hpAmount < 41 && hpAmount >= 0)
        {
            avatar.sprite = avatar3;
        }
        if (hpAmount <= 0)
        {
            avatar.sprite = avatar4;
        }
    }

    public void Keys(string key)
    {
        if (key == "RED")
        {
            rKey.SetActive(true);
        }
        if (key == "GREEN")
        {
            gKey.SetActive(true);
        }
        if (key == "BLU")
        {
            bKey.SetActive(true);
        }
    }

    public void ClearKeys()
    {
        rKey.SetActive(false);
        gKey.SetActive(false);
        bKey.SetActive(false);
    }

}
