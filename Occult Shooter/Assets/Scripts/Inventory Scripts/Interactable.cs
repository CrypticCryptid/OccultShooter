using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact() {
        //This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }    

    void Awake() {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if(isFocus && !hasInteracted) {
            if(Input.GetButtonDown("Interact")) {
                float distance = Vector3.Distance(player.position, interactionTransform.position);
                if(distance <= radius) {
                    Interact();
                    hasInteracted = true;
                }
            }
        }
    }

    public void OnFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused() {
        isFocus = false;
        player = null;
    }

    void OnDrawGizmosSelected() {
        if(interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
