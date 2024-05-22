using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollect : MonoBehaviour
{
    private int strawberryCount = 0;
    [SerializeField] private TextMeshProUGUI StrawberryText;
    [SerializeField] private AudioSource soundEffect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Strawberry"))
        {
            soundEffect.Play();
            Animator coll = collision.gameObject.GetComponent<Animator>();
            coll.SetTrigger("CollectFruit");
            //Invoke("DestroyObject", 1f);
            
            strawberryCount++;
            StrawberryText.text = "Fruit: " + strawberryCount;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);
        }
    }
    
}
