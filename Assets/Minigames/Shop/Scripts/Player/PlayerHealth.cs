using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //-----------PRZENOSZENIE STATYSTYK--------------
    //private int hpLvl = 100;
    //private int armorLvl = 0;
    //-----------------------------------------------


    public int maxHp;
    private int hp;

    public int maxArmor;
    private int armor;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    public Image pickupHealthImage;
    float colorSmoothing = 6f;
    bool isTakingDamage = false;
    bool isTakingArmor = false;
    bool isGettingHealth = false;
    bool isGettingArmor = false;

    private static PlayerHealth _instance;
    public static PlayerHealth Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        //przenieœ player ze wszystkim
        //DontDestroyOnLoad(this.gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        hp = maxHp;
        //-----------PRZENOSZENIE STATYSTYK--------------
        //hpLvl = PlayerPrefs.GetInt("hp");
        //armorLvl = PlayerPrefs.GetInt("armor");
        //hp = hpLvl;
        //-----------------------------------------------

        UiManager.Instance.UpdateHp(hp);
        UiManager.Instance.UpdateArmor(armor);
    }

    internal void DamagePlayer(float damage)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

        //-----------PRZENOSZENIE STATYSTYK--------------
        //hp = hpLvl;
        //PlayerPrefs.SetInt("hp", hpLvl);
        //PlayerPrefs.SetInt("armor", armorLvl);
        //-----------------------------------------------

        //!!!!! zadaj obra¿enia
/*        if (Input.GetKeyDown(KeyCode.K))
        {
            DamagePlayer(20);
            //Debug.Log("ZADANO OBRA¯ENIA");
        }*/

        // wizualizacja obra¿eñ - zdrowie
        if (isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }
        isTakingDamage = false;

        // podnoszenie - zdrowie
        if (isGettingHealth)
        {
            pickupHealthImage.color = damageColor;
        }
        else
        {
            pickupHealthImage.color = Color.Lerp(pickupHealthImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }
        isGettingHealth = false;


    }

    public void DamagePlayer(int damage)
    {
        //jeœli gracz posiada pancerz najpierw uszkadza pancerz

        if (armor > 0)
        {
            if(armor>=damage)
            {
                isTakingArmor = true;
                armor -= damage;
            }
            else if(armor < damage)
            {
                int rDamage; //pozosta³e obra¿enia
                rDamage = damage - armor;
                armor = 0;
                isTakingArmor = true;
                isTakingDamage = true;
                hp -= rDamage;
            }
        }
        else
        {
            isTakingDamage = true;
            hp -= damage;
        }

        //sprawdzanie czy gracz jest martwy
        if (hp <= 0)
        {
            //Debug.Log("YOU DIED");
            //reset poziomu po œmierci gracza
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
            
            
            //Destroy(transform.gameObject);

        }
        UiManager.Instance.UpdateHp(hp);
        UiManager.Instance.UpdateArmor(armor);
    }

    public void GetHp(int amount, GameObject pickup) 
    {
        if(hp<maxHp)
        {
            isGettingHealth = true;
            hp += amount;
            Destroy(pickup);
        }

        if (hp > maxHp)
        {
            hp = maxHp;
        }

        UiManager.Instance.UpdateHp(hp);
    }

    public void GetArmor(int amount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            isGettingArmor = true;
            armor += amount;
            Destroy(pickup);
        }

        if(armor>maxArmor)
        {
            armor = maxArmor;
        }

        UiManager.Instance.UpdateArmor(armor);
    }
}
