using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private float _interactionRange = 2f;

    public float InteractionRange => _interactionRange;

    [SerializeField] private bool _isActive;
    public bool IsActive => _isActive;

    public abstract void Interact(GameObject gameObject);

    public void Activate() => _isActive = true;
    public void Deactivate() => _isActive = false;
}