using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    bool is_in_talk_area = false; 
   
    public InMemoryVariableStorage inMemoryVariableStorage;

    public Timer timerScript;
    public PlayerMovement playerMovementScript;

    public Button continueButton;

    public TMP_Text happyPeopleText;

    public GameObject playerImg;
    public GameObject NPCImg;

    void Start()
    {
        if(this.gameObject.tag == "Book")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        happyPeopleText.enabled = false;

        playerImg.SetActive(false);
        NPCImg.SetActive(false);
    }

    void Update()
    {
        inMemoryVariableStorage.TryGetValue("$phaseDragon", out float phaseDragon);
        inMemoryVariableStorage.TryGetValue("$phaseKnight", out float phaseKnight);
        inMemoryVariableStorage.TryGetValue("$phaseLib", out float phaseLib);
        inMemoryVariableStorage.TryGetValue("$peopleHelped", out float peopleHelped);

        inMemoryVariableStorage.TryGetValue("$coupleHelped", out bool helpedCouple);
        inMemoryVariableStorage.TryGetValue("$clericHelped", out bool helpedCleric);
        inMemoryVariableStorage.TryGetValue("$archerHelped", out bool helpedArcher);
        inMemoryVariableStorage.TryGetValue("$elfHelped", out bool helpedElf);
        inMemoryVariableStorage.TryGetValue("$mushroomsHelped", out bool helpedMushrooms);
        inMemoryVariableStorage.TryGetValue("$bearHelped", out bool helpedBear);
        inMemoryVariableStorage.TryGetValue("$wizardHelped", out bool helpedWizard);
        inMemoryVariableStorage.TryGetValue("$woodcutterHelped", out bool helpedWoodcutter);
        inMemoryVariableStorage.TryGetValue("$manWolvesHelped", out bool helpedManWolves);
        inMemoryVariableStorage.TryGetValue("$dogHelped", out bool helpedDog);

        inMemoryVariableStorage.TryGetValue("$bookAppears", out bool bookAppears);

        dragonPhase = Mathf.FloorToInt(phaseDragon);
        knightPhase = Mathf.FloorToInt(phaseKnight);
        libPhase = Mathf.FloorToInt(phaseLib);
        peopleHelpedNumber = Mathf.FloorToInt(peopleHelped);

        coupleHelped = helpedCouple;
        clericHelped = helpedCleric;
        archerHelped = helpedArcher;
        elfHelped = helpedElf;
        mushroomsHelped = helpedMushrooms;
        bearHelped = helpedBear;
        wizardHelped = helpedWizard;
        woodcutterHelped = helpedWoodcutter;
        manWolvesHelped = helpedManWolves;
        dogHelped = helpedDog;

        bookVisible = bookAppears;

        happyPeopleText.text = "Gente contenta: " + peopleHelpedNumber.ToString() + "/3";

        if (Input.GetKeyDown(KeyCode.Space) && continueButton != null && continueButton.gameObject.activeSelf)
        {
            continueButton.onClick.Invoke();
        }

        if (bookVisible)
        {
            if(this.gameObject.tag == "Book")
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        if(libPhase == 3 || libPhase == 4)
        {
            happyPeopleText.enabled = true;
        }
        else
        {
            happyPeopleText.enabled = false;
        }

        if (dragonPhase == 5)
        {
            if(this.gameObject.tag == "Dragon")
            {
                timerScript.Victory();
            }
        }

        if (peopleHelpedNumber >= 3 && libPhase == 3)
        {
            inMemoryVariableStorage.SetValue("$phaseLib", 4f);
        }

        if(peopleHelpedNumber == 3 && !returnToLib && !playerMovementScript.isTalking)
        {
            dialogueRunner.StartDialogue("Nyx2");
            returnToLib = true;
        }

        if (is_in_talk_area & Input.GetKeyDown(KeyCode.E))
        {
            switch (this.gameObject.tag)
            {
                case "Dragon":

                    NPCImg.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                    dialogueRunner.StartDialogue(this.gameObject.tag + dragonPhase);

                    break;

                case "Knight":

                    NPCImg.gameObject.transform.GetChild(1).gameObject.SetActive(true);

                    dialogueRunner.StartDialogue(this.gameObject.tag + knightPhase);

                    break;

                case "Librarian":

                    NPCImg.gameObject.transform.GetChild(2).gameObject.SetActive(true);

                    dialogueRunner.StartDialogue(this.gameObject.tag + libPhase);

                    break;

                case "Soldier":

                    NPCImg.gameObject.transform.GetChild(3).gameObject.SetActive(true);

                    if (dragonPhase < 3)
                    {
                        dialogueRunner.StartDialogue("Soldier1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Soldier2");
                    }

                    break;

                case "Couple":

                    NPCImg.gameObject.transform.GetChild(4).gameObject.SetActive(true);

                    if (libPhase < 3 || coupleHelped)
                    {
                        dialogueRunner.StartDialogue("Couple1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Couple2");
                    }

                    break;

                case "Cleric":

                    NPCImg.gameObject.transform.GetChild(5).gameObject.SetActive(true);

                    if (libPhase < 3 || clericHelped)
                    {
                        dialogueRunner.StartDialogue("Cleric1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Cleric2");
                    }

                    break;

                case "Archer":

                    NPCImg.gameObject.transform.GetChild(6).gameObject.SetActive(true);

                    if (libPhase < 3 || archerHelped)
                    {
                        dialogueRunner.StartDialogue("Archer1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Archer2");
                    }

                    break;

                case "Elf":

                    NPCImg.gameObject.transform.GetChild(7).gameObject.SetActive(true);

                    if (libPhase < 3 || elfHelped)
                    {
                        dialogueRunner.StartDialogue("Elf1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Elf2");
                    }

                    break;

                case "Mushrooms":

                    NPCImg.gameObject.transform.GetChild(8).gameObject.SetActive(true);

                    if (libPhase < 3 || mushroomsHelped)
                    {
                        dialogueRunner.StartDialogue("Mushrooms1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Mushrooms2");
                    }

                    break;

                case "Bear":

                    NPCImg.gameObject.transform.GetChild(9).gameObject.SetActive(true);

                    if (libPhase < 3 || bearHelped)
                    {
                        dialogueRunner.StartDialogue("Bear1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Bear2");
                    }

                    break;

                case "Wizard":

                    NPCImg.gameObject.transform.GetChild(10).gameObject.SetActive(true);

                    if (libPhase < 3 || wizardHelped)
                    {
                        dialogueRunner.StartDialogue("WizardAndFairy1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("WizardAndFairy2");
                    }

                    break;

                case "Woodcutter":

                    NPCImg.gameObject.transform.GetChild(11).gameObject.SetActive(true);

                    if (libPhase < 3 || woodcutterHelped)
                    {
                        dialogueRunner.StartDialogue("Woodcutter1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Woodcutter2");
                    }

                    break;

                case "Employee":

                    NPCImg.gameObject.transform.GetChild(12).gameObject.SetActive(true);

                    if (libPhase < 3 || woodcutterHelped)
                    {
                        dialogueRunner.StartDialogue("Employee1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Employee2");
                    }

                    break;

                case "ManWolves":

                    NPCImg.gameObject.transform.GetChild(13).gameObject.SetActive(true);

                    if (libPhase < 3 || manWolvesHelped)
                    {
                        dialogueRunner.StartDialogue("ManWolves1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("ManWolves2");
                    }

                    break;

                case "Dog":

                    NPCImg.gameObject.transform.GetChild(14).gameObject.SetActive(true);

                    if (libPhase < 3 || dogHelped)
                    {
                        dialogueRunner.StartDialogue("Dog1");
                    }
                    else
                    {
                        dialogueRunner.StartDialogue("Dog2");
                    }

                    break;

                default:
                    break;
            }


        }

        //inMemoryVariableStorage.TryGetValue("$avanzarDragon1Activado", out bool avanzarDragon1Activado);

        //if (avanzarDragon1Activado)
        //{
        //    questDragonStarted = true;

        //    inMemoryVariableStorage.SetValue("$avanzarDragon1Activado", false);
        //}

        //if (is_in_talk_area && Input.GetKeyDown(KeyCode.E))
        //{
        //    //Dragon
        //    if (this.gameObject.tag == "Dragon" && questDragonStarted == false)
        //    {
        //        Debug.Log("Entra");
        //        dialogueRunner.StartDialogue("Dragon");
        //        //pte código que muestre las dos raw images con los personajes que hablan
        //        //Player siempre el mismo, NPC según TAG
        //        //Bloquear movimiento de jugador durante el díalogo               
        //    }
        //    else if (this.gameObject.tag == "Dragon" && questDragonStarted == true)
        //    {
        //        if (!questKnightCompleted)
        //        {
        //            dialogueRunner.StartDialogue("Dragon3");
        //        }
        //        else
        //        {
        //            dialogueRunner.StartDialogue("Dragon2");
        //        }
        //    }

        //    //Caballero
        //    if (this.gameObject.tag == "Knight" && questKnightStarted == false)
        //    {
        //        if (questDragonStarted)
        //        {
        //            Debug.Log("Entra");

        //            dialogueRunner.StartDialogue("Knight1");
        //        }
        //        else
        //        {
        //            dialogueRunner.StartDialogue("Knight3");
        //        }

        //        //pte código que muestre las dos raw images con los personajes que hablan
        //        //Player siempre el mismo, NPC según TAG
        //        //Bloquear movimiento de jugador durante el díalogo

        //        //defaultLibrarian = false; //Activa la nueva conversacion con la bibliotecaria
        //    }
        //    else if (this.gameObject.tag == "Knight" && questKnightStarted == true)
        //    {
        //        if (!questKnightCompleted)
        //        {
        //            dialogueRunner.StartDialogue("Knight4");
        //        }
        //        else
        //        {
        //            dialogueRunner.StartDialogue("Knight2");
        //        }
        //    }

        //    //Soldados del campamento
        //    if (this.gameObject.tag == "Soldier")
        //    {
        //        if(questDragonStarted)
        //        {
        //            Debug.Log("Entra");
        //            dialogueRunner.StartDialogue("Soldier");
        //        }
        //        else
        //        {
        //            dialogueRunner.StartDialogue("Soldier2");
        //        }

        //        //pte código que muestre las dos raw images con los personajes que hablan
        //        //Player siempre el mismo, NPC según TAG
        //        //Bloquear movimiento de jugador durante el díalogo
        //    }

        //    //Bibliotecaria
        //    //Dialogo antes de activar la quest del caballero
        //    //if (this.gameObject.tag == "Librarian" && defaultLibrarian == true)
        //    //{
        //    //    Debug.Log("Entra");
        //    //    dialogueRunner.StartDialogue("Librarian3");
        //    //    //pte código que muestre las dos raw images con los personajes que hablan
        //    //    //Player siempre el mismo, NPC según TAG
        //    //    //Bloquear movimiento de jugador durante el díalogo
        //    //}

        //    ////Dialogo despues de hablar con el caballero
        //    //else if (this.gameObject.tag == "Librarian" && defaultLibrarian == false)
        //    //{
        //    //    if (questLibrarian == false)
        //    //    {
        //    //        dialogueRunner.StartDialogue("Librarian1");
        //    //    }
        //    //    else
        //    //    {
        //    //        dialogueRunner.StartDialogue("Librarian2");
        //    //    }
        //    //}


        //    if (this.gameObject.tag == "Librarian" && !questKnightStarted)
        //    {
        //        Debug.Log("Entra");
        //        dialogueRunner.StartDialogue("Librarian3");
        //        //pte código que muestre las dos raw images con los personajes que hablan
        //        //Player siempre el mismo, NPC según TAG
        //        //Bloquear movimiento de jugador durante el díalogo
        //    }
        //    else if(this.gameObject.tag == "Librarian" && questKnightStarted)
        //    {
        //        if (!questLibrarianStarted)
        //        {
        //            dialogueRunner.StartDialogue("Librarian1");
        //        }
        //        else
        //        {
        //            dialogueRunner.StartDialogue("Librarian4");
        //        }
        //    }
        //    else if(this.gameObject.tag == "Librarian" && questLibrarianCompleted)
        //    {
        //        dialogueRunner.StartDialogue("Librarian2");
        //    }
        //}

        //ANTIGUO SCRIPT DE ESTHER
        /* if(is_in_talk_area && gameObject.tag == "Dragon" && Input.GetKeyDown(KeyCode.E)){
             Debug.Log("Entra");
             dialogueRunner.StartDialogue("Nyx");
             //pte código que muestre las dos raw images con los personajes que hablan
             //Player siempre el mismo, NPC según TAG
             //Bloquear movimiento de jugador durante el díalogo
         }*/
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            is_in_talk_area = true;
        }
        if(this.gameObject.tag == "Book")
        {
            inMemoryVariableStorage.SetValue("$phaseKnight", 4f);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            is_in_talk_area = false;
        }
    }    

    //Variables estaticas para que no cambien cada vez que habla con un npc
    //public static bool defaultLibrarian = true; //Conversacion por defecto de la bibliotecaria antes de pasar por el caballero
    //public static bool questKnightStarted = false; //Quest del caballero
    //public static bool questDragonStarted = false; //Quest para el dragon
    //public static bool questLibrarianStarted = false; //Quest para la bibliotecaria
    //public static bool questKnightCompleted = false; //Quest del caballero
    //public static bool questDragonCompleted = false; //Quest para el dragon
    //public static bool questLibrarianCompleted = false; //Quest para la bibliotecaria
    public static int dragonPhase = 1;
    public static int knightPhase = 1;
    public static int libPhase = 1;
    public static int peopleHelpedNumber = 0;

    public static bool coupleHelped = false;
    public static bool clericHelped = false;
    public static bool archerHelped = false;
    public static bool elfHelped = false;
    public static bool mushroomsHelped = false;
    public static bool bearHelped = false;
    public static bool wizardHelped = false;
    public static bool woodcutterHelped = false;
    public static bool employeeHelped = false;
    public static bool manWolvesHelped = false;
    public static bool dogHelped = false;

    public static bool bookVisible = false;
    public static bool returnToLib = false;
}


