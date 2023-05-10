using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystemMaster : MonoBehaviour
{
    public MapController map;

    private Animator mapAnim;

    private void Start()
    {
        mapAnim = map.gameObject.GetComponent<Animator>();
    }

    public void ShowWholeMap()
    {
        StartCoroutine(ShowWholeMapCor());
    }

    public void HideWholeMap()
    {
        StartCoroutine(HideWholeMapCor());
    }

    IEnumerator ShowWholeMapCor()
    {
        map.gameObject.SetActive(true);
        for (int i = 0; i < map.gameObject.transform.childCount - 1; i++)
            map.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;
        mapAnim.SetTrigger("ShowMap");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator HideWholeMapCor()
    {
        mapAnim.SetTrigger("HideMap");
        yield return new WaitForSeconds(1f);
        map.gameObject.SetActive(false);
    }

    public void SetButtonsClickable(List<Button> buttons)
    {
        foreach (Button b in buttons)
            b.interactable = true;
    }

    public void SetButtonsNotClickable(List<Button> buttons)
    {
        foreach (Button b in buttons)
            b.interactable = false;
    }

    public void SetButtonNotClickable(Button b)
    {
        b.interactable = false;
    }
}
