using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    //bool isFocus = false;
    Transform player;

    bool hasInteracted = false;
    
    bool isClose = false;

    public virtual void Interact() {
        //This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
        hasInteracted = true;
    }    

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if(!hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius) {
                isClose = true;
            } else {
                isClose = false;
            }
        }
    }

    // public void OnFocused(Transform playerTransform) {
    //     isFocus = true;
    //     player = playerTransform;
    // }

    // public void OnDefocused() {
    //     isFocus = false;
    //     player = null;
    // }

    public bool IsClose() {
        return isClose;
    }

    void OnDrawGizmosSelected() {
        if(interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
