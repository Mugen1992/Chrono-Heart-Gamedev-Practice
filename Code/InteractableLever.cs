using UnityEngine;

public interface IInteractable {
    void Interact();
}

public class InteractableLever : MonoBehaviour, IInteractable {
    public Animator leverAnimator;
    public GameObject linkedObject; // дверь, платформа и т.п.
    public bool isOn = false;

    public void Interact() {
        isOn = !isOn;

        // Визуал рычага
        if (leverAnimator != null) {
            leverAnimator.SetBool("IsOn", isOn);
        }

        // Логика связанного объекта
        ILeverTarget target = linkedObject?.GetComponent<ILeverTarget>();
        if (target != null) {
            target.OnLeverStateChange(isOn);
        }

        Debug.Log($"[Lever] State changed to {(isOn ? "ON" : "OFF")}");
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
    }
}

// Интерфейс для объектов, реагирующих на рычаг
public interface ILeverTarget {
    void OnLeverStateChange(bool state);
}
