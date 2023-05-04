using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class ChooseLabelController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color hoverColor;
    public Color cantChooseColorColor;

    public StoryScene scene;
    public bool isWarunekSpelniony;

    private TextMeshProUGUI textMesh;
    private ChooseController controller;
    private MainGameEvent gameEvent;
    private MainGameEvent gameEventWarunek;
    private PlayerData playerData;
    private int eventValue;
    private GameObject blocker;

    private void Awake()
    {
        isWarunekSpelniony = false;
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        blocker = GameObject.FindGameObjectWithTag("Blocker");
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.color = defaultColor;
    }

    public float GetHeight()
    {
        return textMesh.rectTransform.sizeDelta.y * textMesh.rectTransform.localScale.y;
    }

    public void Setup(ChooseScene.ChooseLabel label, ChooseController controller, float y)
    {
        scene = label.nextScene;

        if (label.gameEvent != null)
        {
            if (label.gameEvent is GameEvent)
            {
                if (label.gameEventWarunek != null)
                {
                    if (label.gameEventWarunek is GameEvent)
                    {
                        gameEventWarunek = label.gameEventWarunek as GameEvent;
                        (gameEventWarunek as GameEvent).Raise();
                    }
                    else if (label.gameEventWarunek is IntGameEvent)
                    {
                        gameEventWarunek = label.gameEventWarunek as IntGameEvent;
                        (gameEventWarunek as IntGameEvent).Raise(label.warunekEventValue);
                    }
                }
                else
                    isWarunekSpelniony = true;

                if (label.gameEvent != null)
                    gameEvent = label.gameEvent as GameEvent;
            }
            else if (label.gameEvent is IntGameEvent)
            {
                eventValue = label.eventValue;
                if (label.gameEventWarunek != null)
                {
                    if (label.gameEventWarunek is GameEvent)
                    {
                        gameEventWarunek = label.gameEventWarunek as GameEvent;
                        (gameEventWarunek as GameEvent).Raise();
                    }
                    else if (label.gameEventWarunek is IntGameEvent)
                    {
                        gameEventWarunek = label.gameEventWarunek as IntGameEvent;
                        (gameEventWarunek as IntGameEvent).Raise(label.warunekEventValue);
                    }
                }
                else
                    isWarunekSpelniony = true;

                if (label.gameEvent != null)
                    gameEvent = label.gameEvent as IntGameEvent;
            }
        }
        else
            isWarunekSpelniony = true;

        if (label.gameEvent == null)
            DisableComponents(label);

        if (isWarunekSpelniony == true)
            textMesh.text = label.text;
        else
        {
            textMesh.text = label.text + " (Brak)";
            textMesh.color = cantChooseColorColor;
        }
            
        this.controller = controller;

        Vector3 pos = textMesh.rectTransform.localPosition;
        pos.y = y;
        textMesh.rectTransform.localPosition = pos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameEvent != null && gameEvent is GameEvent && isWarunekSpelniony == true)
            (gameEvent as GameEvent).Raise();

        if (gameEvent != null && gameEvent is IntGameEvent && isWarunekSpelniony == true)
            (gameEvent as IntGameEvent).Raise(eventValue);

        if (isWarunekSpelniony == true)
        {
            if (scene == null)
                blocker.SetActive(false);
            controller.PerfomChoose(scene);
        }
            
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isWarunekSpelniony == true)
            textMesh.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isWarunekSpelniony == true)
            textMesh.color = defaultColor;
    }

    public void CheckWarunek()
    {
        if (gameEventWarunek == null)
            isWarunekSpelniony = true;
    }

    public void CheckMoneyBiggierThan(int value)
    {
        if (playerData.money >= value)
            isWarunekSpelniony = true;
        else
            isWarunekSpelniony = false;
    }

    public void CheckEnergyBiggierThan(int value)
    {
        if (playerData.energy >= value)
            isWarunekSpelniony = true;
        else
            isWarunekSpelniony = false;
    }

    public void CheckHungerBiggierThan(int value)
    {
        if (playerData.hunger >= value)
            isWarunekSpelniony = true;
        else
            isWarunekSpelniony = false;
    }

    public void CheckWinsdomBiggierThan(int value)
    {
        if (playerData.winsdom >= value)
            isWarunekSpelniony = true;
        else
            isWarunekSpelniony = false;
    }

    public void CheckMetalHealthBiggierThan(int value)
    {
        if (playerData.metalHealth >= value)
            isWarunekSpelniony = true;
        else
            isWarunekSpelniony = false;
    }

    public void IncreaseMoney(int value)
    {
        playerData.money += value;
    }

    public void IncreaseEnergy(int value)
    {
        playerData.energy += value;
    }

    public void IncreaseHunger(int value)
    {
        playerData.hunger += value;
    }

    public void IncreaseWinsdom(int value)
    {
        playerData.winsdom += value;
    }

    public void IncreaseMetalHealth(int value)
    {
        playerData.metalHealth += value;
    }

    public void DecreaseMoney(int value)
    {
        playerData.money -= value;
    }

    public void DecreaseEnergy(int value)
    {
        playerData.energy -= value;
    }

    public void DecreaseHunger(int value)
    {
        playerData.hunger -= value;
    }

    public void DecreaseWinsdom(int value)
    {
        playerData.winsdom -= value;
    }

    public void DecreaseMetalHealth(int value)
    {
        playerData.metalHealth -= value;
    }

    private void DisableComponents(ChooseScene.ChooseLabel label)
    {
        UnityIntGameEventListener[] unityEvents = this.gameObject.GetComponents<UnityIntGameEventListener>();
        for (int i = 0; i < unityEvents.Length - 1; i++)
            unityEvents[i].enabled = false;
    }
}
