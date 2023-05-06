using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PhoneController : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI moneyText;
    public Slider hungerSlider;
    public Slider wisdomSlider;
    public Slider mindSlider;
    public Slider energySlider;

    private Animator animator;
    private bool phoneShowed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimatePhone()
    {
        if(phoneShowed == false)
            animator.SetTrigger("ShowPhone");
        else
            animator.SetTrigger("HidePhone");

        phoneShowed = !phoneShowed;
    }

    private void Update()
    {
        if (phoneShowed == true)
        {
            moneyText.text = playerData.money.ToString() + " z³";
            hungerSlider.value = playerData.hunger;
            wisdomSlider.value = playerData.winsdom;
            mindSlider.value = playerData.metalHealth;
            energySlider.value = playerData.energy;
        }
    }

}
