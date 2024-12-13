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
            dialogueRunner.StartDialogue("Nyx");
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


