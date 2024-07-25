using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _model;
    [SerializeField] private float _maxOffsetUnits;
    [SerializeField] private float _horizontalSpeed;

    public void MovePlayer(float percentOffsetX)
    {
        _model.localPosition += new Vector3(percentOffsetX * Time.deltaTime * _horizontalSpeed, 0, 0);
        float positionX = Mathf.Clamp(_model.localPosition.x, -_maxOffsetUnits, _maxOffsetUnits);
        _model.localPosition = new Vector3(positionX, 0, 0);
    }

    public void Reset()
    {
        _model.localPosition = Vector3.zero;
    }
}
