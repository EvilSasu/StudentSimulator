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
    private GameEvent gameEvent;
    private GameEvent gameEventWarunek;
    private PlayerData playerData;

    private void Awake()
    {
        isWarunekSpelniony = false;
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
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

        if (label.gameEventWarunek != null)
        {
            gameEventWarunek = label.gameEventWarunek;
            gameEventWarunek.Raise();
        }
        else
            isWarunekSpelniony = true;
        
        if(label.gameEvent != null)
            gameEvent = label.gameEvent;

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
        if (gameEvent != null)
            gameEvent.Raise();

        if(isWarunekSpelniony == true)
            controller.PerfomChoose(scene);
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

    private void CheckMetalHealthBiggierThan(int value)
    {
        if (playerData.metalHealth >= value)
            isWarunekSpelniony = true;
        else
            isWarunekSpelniony = false;
    }

}
