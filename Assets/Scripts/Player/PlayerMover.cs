using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _model;
    [SerializeField] private float _maxOffsetUnits;

    public void MovePlayer(float percentOffsetX)
    {
        float positionX = Mathf.Clamp(percentOffsetX * _maxOffsetUnits, -_maxOffsetUnits, _maxOffsetUnits);
        _model.localPosition = new Vector3(positionX, 0, 0);
    }
}
