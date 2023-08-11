using UnityEngine;
using UnityEngine.Events;

public class EnableDisableEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent enable;
    [SerializeField] private UnityEvent disable;

    private void OnEnable()
    {
        enable.Invoke();
    }

    private void OnDisable()
    {
        disable.Invoke();
    }
}