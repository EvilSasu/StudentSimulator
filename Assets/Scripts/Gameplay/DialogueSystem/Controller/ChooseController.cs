using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseController : MonoBehaviour
{
    public ChooseLabelController label;
    public Animator animator;
    public DialogueController dialogController;

    private RectTransform rectTransform;
    private float labelHeight = -1;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoices(ChooseScene scene)
    {
        DestroyLabels();
        animator.SetTrigger("ShowChoice");
        for(int i = 0; i < scene.labels.Count; i++)
        {
            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();

            if (labelHeight == -1)
            {
                labelHeight = newLabel.GetHeight();
            }

            newLabel.Setup(scene.labels[i], this, CalculateLabelPos(i, scene.labels.Count));
        }
    }

    public void PerfomChoose(StoryScene scene)
    {
        dialogController.PlayScene(scene);
        animator.SetTrigger("HideChoice");
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
