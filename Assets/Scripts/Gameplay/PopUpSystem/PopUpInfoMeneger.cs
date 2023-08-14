using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopUpInfoMeneger : MonoBehaviour
{
    public GameObject PopUp;
    private List<GameObject> popUpList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePopUp(string name, int value, bool isIncreased)
    {
        if(value >= 1)
        {
            string textOnPopUP;
            GameObject newPopUP = Instantiate(PopUp, new Vector3(0f, 0f, 0f), Quaternion.identity);
            newPopUP.SetActive(true);
            
            newPopUP.transform.SetParent(this.transform);
            newPopUP.transform.localScale = new Vector3(1f, 1f, 1f);
            //popUpList.Add(newPopUP);

            if (isIncreased)
                textOnPopUP = new string(name + " has increased by " + value);
            else
                textOnPopUP = new string(name + " has decreased by " + value);

            newPopUP.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = textOnPopUP;

            //StartCoroutine(AnimatePopUp(newPopUP));
        }       
    }

    private IEnumerator AnimatePopUp(GameObject newPopUP)
    {
        newPopUP.transform.position = Vector2.MoveTowards(newPopUP.transform.position, new Vector2(newPopUP.transform.position.x, 1800f), 0.5f);
        yield return new WaitForSeconds(2f);
        newPopUP.GetComponent<Animator>().SetTrigger("Hide");
    }
}
