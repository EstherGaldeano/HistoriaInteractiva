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
        if (is_in_talk_area && Input.GetKeyDown(KeyCode.E))
        {
            //Dragon
            if (this.gameObject.tag == "Dragon" && questDragon == false)
            {
                Debug.Log("Entra");
                dialogueRunner.StartDialogue("Nyx");
                //pte código que muestre las dos raw images con los personajes que hablan
                //Player siempre el mismo, NPC según TAG
                //Bloquear movimiento de jugador durante el díalogo    
            }
            else if (this.gameObject.tag == "Dragon" && questDragon == true)
            {
                dialogueRunner.StartDialogue("Nyx2");
            }

            //Caballero
            if (this.gameObject.tag == "Knight" && questKnight == false)
            {
                Debug.Log("Entra");
                dialogueRunner.StartDialogue("Knight1");
                //pte código que muestre las dos raw images con los personajes que hablan
                //Player siempre el mismo, NPC según TAG
                //Bloquear movimiento de jugador durante el díalogo

                defaultLibrarian = false; //Activa la nueva conversacion con la bibliotecaria
            }
            else if (this.gameObject.tag == "Knight" && questKnight == true)
            {
                dialogueRunner.StartDialogue("Knight2");
            }

            //Soldados del campamento
            if (this.gameObject.tag == "Soldier")
            {
                Debug.Log("Entra");
                dialogueRunner.StartDialogue("Soldier");
                //pte código que muestre las dos raw images con los personajes que hablan
                //Player siempre el mismo, NPC según TAG
                //Bloquear movimiento de jugador durante el díalogo
            }

            //Bibliotecaria
            //Dialogo antes de activar la quest del caballero
            if (this.gameObject.tag == "Librarian" && defaultLibrarian == true)
            {
                Debug.Log("Entra");
                dialogueRunner.StartDialogue("Librarian3");
                //pte código que muestre las dos raw images con los personajes que hablan
                //Player siempre el mismo, NPC según TAG
                //Bloquear movimiento de jugador durante el díalogo
            }

            //Dialogo despues de hablar con el caballero
            else if (this.gameObject.tag == "Librarian" && defaultLibrarian == false)
            {
                if (questLibrarian == false)
                {
                    dialogueRunner.StartDialogue("Librarian1");
                }
                else
                {
                    dialogueRunner.StartDialogue("Librarian2");
                }
            }

        }

        //ANTIGUO SCRIPT DE ESTHER
        /* if(is_in_talk_area && gameObject.tag == "Dragon" && Input.GetKeyDown(KeyCode.E)){
             Debug.Log("Entra");
             dialogueRunner.StartDialogue("Nyx");
             //pte código que muestre las dos raw images con los personajes que hablan
             //Player siempre el mismo, NPC según TAG
             //Bloquear movimiento de jugador durante el díalogo
         }*/

        

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

    //Variables estaticas para que no cambien cada vez que habla con un npc
    public static bool questKnight = false; //Quest del caballero
    public static bool questDragon = false; //Quest para el dragon
    public static bool questLibrarian = false; //Quest para la bibliotecaria
    public static bool defaultLibrarian = true; //Conversacion por defecto de la bibliotecaria antes de pasar por el caballero
}


