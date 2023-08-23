using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public int amountOfPopUp = 0;

    private void Awake()
    {
        StartCoroutine(AnimatePopUp(amountOfPopUp));
    }

    public void StarAnimation(int amountOfPopUp)
    {
        StartCoroutine(AnimatePopUp(amountOfPopUp));
    }

    private IEnumerator AnimatePopUp(int amountOfPopUp)
    {
        yield return new WaitForSeconds(1f);
        float posToMove = 500f - 75f - ((amountOfPopUp - 1) * 80f);
        while (this.transform.localPosition.y <= posToMove)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, 
                new Vector2(this.transform.position.x, posToMove), 0.1f);
            yield return new WaitForSecondsRealtime(.01f);
        }
            
        yield return new WaitForSeconds(4f);
        this.GetComponent<Animator>().SetTrigger("Hide");
        yield return new WaitForSeconds(1f);
        transform.parent.GetComponent<PopUpInfoMeneger>().popUpList.Remove(this.gameObject);
        GameObject.Destroy(this.gameObject);
    }
}
