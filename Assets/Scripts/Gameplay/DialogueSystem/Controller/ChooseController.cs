using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseController : MonoBehaviour
{
    public ChooseLabelController label;
    private Animator animator;
    public DialogueController dialogController;
    public GameObject choiceBlocker;

    private RectTransform rectTransform;
    private float labelHeight = -1;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
    }


    public void SetupChoices(ChooseScene scene)
    {
        DestroyLabels();
        animator.SetTrigger("ShowChoice");

        for (int i = 0; i < scene.labels.Count; i++)
        {
            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();

            if (labelHeight == -1)
            {
                labelHeight = newLabel.GetHeight();
            }

            newLabel.Setup(scene.labels[i], this, CalculateLabelPos(i, scene.labels.Count));
        }
        Vector2 size = rectTransform.sizeDelta;
        size.y = (scene.labels.Count + 2) * labelHeight;
        rectTransform.sizeDelta = size;
    }

    public void PerfomChoose(StoryScene scene)
    {
        choiceBlocker.SetActive(true);
        animator.SetTrigger("HideChoice");
        dialogController.PlayScene(scene);
    }

    public void SetDisable()
    {
        this.gameObject.SetActive(false);
    }

    private void DestroyLabels()
    {
        foreach(Transform childTrans in transform)
        {
            Destroy(childTrans.gameObject);
        }
    }

    private float CalculateLabelPos(int labelIndex, int labelCount)
    {
        if(labelCount %2 == 0)
        {
            if(labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex - 1) + labelHeight / 2;
            }
            else
            {
                return -1 * (labelHeight * (labelIndex - labelCount / 2) + labelHeight / 2);
            }    
        }
        else
        {
            if (labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex);
            }
            else if (labelIndex > labelCount / 2)
            {
                return -1 * (labelHeight * (labelIndex - labelCount / 2));
            }
            else
                return 0;
        }
    }
}
