using System.Collections;
using UnityEngine;

public class IntroWakeUpMission : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private CameraController _camController;
    [SerializeField] private Transform _head;

    [SerializeField] private Animator _introAnimator;
    [SerializeField] private AnimationClip _wakeUpClip;
    [SerializeField] private DialogueSequence _dialogues;
    [SerializeField] private InteractableBathtub _bathtub;

    public WaitForSeconds _waitForSeconds2 = new(2f);

    public IEnumerator Start()
    {
        DayManager.Instance.SetPlayerActive(false);
        _camController.enabled = false;

        _introAnimator.Play("WakeUp");
        yield return new WaitForSeconds(_wakeUpClip.length * 0.5f); // ----- '0.5' FOR DEBUG ONLY -----

        StartCoroutine(DialogueManager.Instance.PlaySequence(_dialogues));

        _camController.enabled = true;
        DayManager.Instance.SetPlayerActive(true);

        yield return _waitForSeconds2;
        _bathtub.Activate();
    }
}