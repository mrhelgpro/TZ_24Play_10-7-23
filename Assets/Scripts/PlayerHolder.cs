using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour, IHolder
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _stackEffect;
    [SerializeField] private List<IHoldable> _holdableList = new List<IHoldable>();
    [SerializeField] private Transform _skinTransform;
    [SerializeField] private Transform _cubeHolderTransform;

    public void AddHoldable(IHoldable holdable)
    {
        _holdableList.Add(holdable);
        int index = _holdableList.Count;

        _animator?.Play("Jumping");
        _stackEffect?.Play();

        _skinTransform.localPosition = new Vector3(0, index, 0);

        GameManager.AmountOfPickups = _holdableList.Count;
    }

    public void RemoveHoldable(IHoldable holdable)
    {
        _holdableList.Remove(holdable);

        Debug.Log(_holdableList.Count);

        if (_holdableList.Count < 1)
        {
            GameManager.GameOver();
        }
    }

    public Transform GetParent() => _cubeHolderTransform != null ? _cubeHolderTransform : transform;
    public int GetIndex() => _holdableList.Count;
}
