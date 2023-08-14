using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopUpInfoMeneger : MonoBehaviour
{
    public GameObject PopUp;
    private List<GameObject> popUpList = new List<GameObject>();

    public void CreatePopUp(string name, int value, bool isIncreased)
    {
        if (value >= 1)
        {
            string textOnPopUP;
            GameObject newPopUP = Instantiate(PopUp, new Vector3(0f, 0f, 0f), Quaternion.identity);
            
            newPopUP.transform.SetParent(this.transform);
            newPopUP.transform.localScale = new Vector3(1f, 1f, 1f);
            popUpList.Add(newPopUP);
            newPopUP.GetComponent<PopUp>().amountOfPopUp = popUpList.Count;
            newPopUP.SetActive(true);

            if (isIncreased)
                textOnPopUP = new string(name + " has increased by " + value);
            else
                textOnPopUP = new string(name + " has decreased by " + value);

            newPopUP.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = textOnPopUP;
        }       
    }   
}
