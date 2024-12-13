using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    bool is_in_talk_area = false;
   

    void Start()
    {
        
    }

    void Update()
    {
        if(is_in_talk_area && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Entra");
            dialogueRunner.StartDialogue("Nyx");
            //pte código que muestre las dos raw images con los personajes que hablan
            //Player siempre el mismo, NPC según TAG
            //Bloquear movimiento de jugador durante el díalogo
        }
        
    
    }


    private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.tag=="Player"){
                is_in_talk_area = true;
            }
    }

    private void OnTriggerExit2D(Collider2D other) {
            if(other.gameObject.tag=="Player"){
                is_in_talk_area = false;
            }
    }
}


