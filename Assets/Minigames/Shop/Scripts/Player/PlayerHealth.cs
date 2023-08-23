using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHp;
    private int hp;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    public Image pickupHealthImage;
    float colorSmoothing = 6f;
    bool isTakingDamage = false;
    public bool prolog = false;

    public LevelLoaderScript loader;

    private static PlayerHealth _instance;
    public static PlayerHealth Instance
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

    void Start()
    {
        hp = maxHp;
        UiManager.Instance.UpdateHp(hp);
    }

    internal void DamagePlayer(float damage)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void DamagePlayer(int damage)
    {

            isTakingDamage = true;
            hp -= damage;

        //sprawdzanie czy gracz jest martwy
        if (hp <= 0)
        {
            //Debug.Log("YOU DIED");
            //reset poziomu po œmierci gracza
            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(currentScene.buildIndex);
            
            


            if(prolog == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                loader.LoadChoosenLevel(4);
            }
            if (prolog == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                loader.LoadChoosenLevel(13);
            }


            //Destroy(transform.gameObject);

        }
        UiManager.Instance.UpdateHp(hp);
    }

}
