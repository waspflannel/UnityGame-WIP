using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Interactables : MonoBehaviour
{
    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public abstract void Interact(); //abstract since it will have different interactions depending on type of object user is interacting with
    
    private void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            
            coll.GetComponent<Spikes>().Interact();
        }
    }
    
    private void OnTriggerExit2D(Collider2D coll){
        if(coll.CompareTag("Player"))
            coll.GetComponent<Spikes>().Interact();
    }
}
