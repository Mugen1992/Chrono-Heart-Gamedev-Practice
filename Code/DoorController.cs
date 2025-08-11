using UnityEngine;

public class DoorController : MonoBehaviour, ILeverTarget {
    public Animator animator;
    public bool isOpen = false;

    public void OnLeverStateChange(bool state) {
        isOpen = state;
        if (animator != null) animator.SetBool("IsOpen", isOpen);
        // TODO: Toggle collider / Nav blockers here
        Debug.Log($"[Door] {(isOpen ? "OPEN" : "CLOSED")}");
    }
}
