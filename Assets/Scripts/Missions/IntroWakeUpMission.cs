using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class IntroWakeUpMission : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private CameraController _camController;
    [SerializeField] private Transform _head;

    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private AnimationClip _wakeUpClip;
    [SerializeField] private DialogueSequence _dialogues;
    [SerializeField] private InteractableBathtub _bathtub;

    public WaitForSeconds _waitForSeconds2 = new(2f);

    public IEnumerator Start()
    {
        DayManager.Instance.SetPlayerActive(false);
        _camController.enabled = false;

        if (DebugManager.SkipAnimations)
        {
            _playableDirector.time = _playableDirector.duration - 2;
            _playableDirector.Evaluate();
        }

        _playableDirector.Play();
        yield return new WaitUntil(() => _playableDirector.state != PlayState.Playing);

        _camController.enabled = true;
        DayManager.Instance.SetPlayerActive(true);

        StartCoroutine(DialogueManager.Instance.PlaySequence(_dialogues));

        yield return _waitForSeconds2;
        _bathtub.Activate();
    }
}