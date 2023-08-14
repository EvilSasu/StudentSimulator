using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
   // bool hasAnimationStarted = false;
    public int amountOfPopUp = 0;

    private void Awake()
    {
        StartCoroutine(AnimatePopUp(amountOfPopUp));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StarAnimation(int amountOfPopUp)
    {
        StartCoroutine(AnimatePopUp(amountOfPopUp));
    }

    private IEnumerator AnimatePopUp(int amountOfPopUp)
    {
        float posToMove = 500f - 75f - ((amountOfPopUp - 1) * 50f);
        while (this.transform.localPosition.y <= posToMove)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, 
                new Vector2(this.transform.position.x, posToMove), 0.1f);
            yield return new WaitForSeconds(.01f);
        }
            
        yield return new WaitForSeconds(4f);
        this.GetComponent<Animator>().SetTrigger("Hide");
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(this.gameObject);
    }
}
