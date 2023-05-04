using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool hpPack;
    public bool armorPack;
    public bool ammoPack;

    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hpPack)
            {
                other.GetComponent<PlayerHealth>().GetHp(amount, this.gameObject);
            }
            if (armorPack)
            {
                other.GetComponent<PlayerHealth>().GetArmor(amount, this.gameObject);
            }
            if (ammoPack)
            {
                other.GetComponentInChildren<Gun>().GetAmmo(amount, this.gameObject);
            }

        }
    }
}
