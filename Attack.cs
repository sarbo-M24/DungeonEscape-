using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool CanDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null) 
        {
           
            if (CanDamage == true) 
            {
                hit.damage();
                CanDamage = false;
                StartCoroutine(ResetDamage());
            }

           
        }
    }

    IEnumerator ResetDamage() 
    {
        yield return new WaitForSeconds(0.5f);
        CanDamage = true;
    }

   
}
