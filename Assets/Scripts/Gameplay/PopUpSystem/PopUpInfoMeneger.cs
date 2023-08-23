using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopUpInfoMeneger : MonoBehaviour
{
    public GameObject PopUp;
    public List<GameObject> popUpList = new List<GameObject>();

    public void CreatePopUp(string name, int value, bool isIncreased)
    {
        if (value >= 1)
        {
            string textOnPopUP;
            GameObject newPopUP = Instantiate(PopUp, new Vector3(0f, 0f, 0f), Quaternion.identity);

            newPopUP.transform.SetParent(this.transform);
            newPopUP.transform.localScale = new Vector3(1f, 1f, 1f);
            popUpList.Add(newPopUP);

            newPopUP.transform.localPosition = new Vector3(newPopUP.transform.localPosition.x,
                newPopUP.transform.localPosition.y - (popUpList.Count - 1 * 90), newPopUP.transform.localPosition.z);

            newPopUP.GetComponent<PopUp>().amountOfPopUp = popUpList.Count;
            newPopUP.SetActive(true);

            if (isIncreased)
                textOnPopUP = new string("Wartoœæ " + name + " wzros³a o " + value);
            else
                textOnPopUP = new string("Wartoœæ " + name + " spad³a o " + value);

            newPopUP.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = textOnPopUP;
        }       
    }

    public void CreateSpecialPopUp(string txt)
    {
        string textOnPopUP;
        GameObject newPopUP = Instantiate(PopUp, new Vector3(0f, 0f, 0f), Quaternion.identity);

        newPopUP.transform.SetParent(this.transform);
        newPopUP.transform.localScale = new Vector3(1f, 1f, 1f);
        popUpList.Add(newPopUP);

        newPopUP.transform.localPosition = new Vector3(newPopUP.transform.localPosition.x,
            newPopUP.transform.localPosition.y - (popUpList.Count - 1 * 90), newPopUP.transform.localPosition.z);

        newPopUP.GetComponent<PopUp>().amountOfPopUp = popUpList.Count;
        newPopUP.SetActive(true);

        textOnPopUP = new string(txt);

        newPopUP.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = textOnPopUP;
    }
}
