using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    private Transform player;
    private bool hasInteracted = false;
    private bool isClose = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
        hasInteracted = true;
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
    }

    void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            isClose = distance <= radius;
        }
    }

    public bool IsClose()
    {
        return isClose;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
