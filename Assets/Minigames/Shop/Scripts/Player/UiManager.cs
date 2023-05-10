using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI hp;
    public TextMeshProUGUI ammo;

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
    }

    public void UpdateAmmo(int ammoAmount)
    {
        ammo.text = ammoAmount.ToString();
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
