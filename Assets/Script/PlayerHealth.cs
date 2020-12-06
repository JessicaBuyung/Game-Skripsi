using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    
    public Slider healthBar;
    
    [SerializeField]
    GameObject DeathUI;

    Animator anim;

    public float maxHealth = 10;
    public float curHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        healthBar.value = maxHealth;
        curHealth = healthBar.value;
    }

   private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obj")
        {
            Destroy(col.gameObject);
            healthBar.value -=1;
            curHealth = healthBar.value;
        }
    }
    void Update()
    {
        if(curHealth <= 0)
        {
            //play death animation
            anim.SetBool("isDead", true);

            //stop all playr movement
            GetComponent<PlayerMove>().enabled = false;
            
            //enables the death UI
            DeathUI.gameObject.SetActive(true);
        }

      
    }

   

}
