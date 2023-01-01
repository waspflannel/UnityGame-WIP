using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

public abstract class Open : MonoBehaviour
{
    public Sprite open;
    public Sprite closed;

    public SpriteRenderer sr;
    public bool isOpen;

    //private TileMap

    public abstract void Interact();

    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
    private void Start(){
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
        isOpen = false;
    }

    public void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            Interact();
        }
    }
    
    public void OnTriggerExit2D(Collider2D coll){
        if(coll.CompareTag("Player"))
            Interact();
    }
}
