using System;
using UnityEngine;

public class SwipeControl : Control
{
    // private Vector3 _startMousePosition;
    //
    // protected override void Update()
    // {
    //     if (Input.GetMouseButtonDown(0)) _startMousePosition = GetPositionInGameBoard(Input.mousePosition);
    //
    //     base.Update();

    // }

    // protected override void GetTargetPosition(Vector3 position)
    // {
        // var defaultPosition = _player.transform.position;
        // var postionInGameBoard = GetPositionInGameBoard(position);
        // var dir = GetDirection(postionInGameBoard);
        // var sensitivity = GetSensitivity(postionInGameBoard);
        
        // return defaultPosition + dir * sensitivity;

    // }

    // private Vector3 GetDirection(Vector3 target)
    // {
    //     if (target == Vector3.zero) return Vector3.zero;
    //     
    //     return Math.Abs(_startMousePosition.x - target.x) > 0.01f ? 
    //         new Vector3((_startMousePosition.x - target.x) * Math.Abs(_startMousePosition.x - target.x) / -1, 0, 0).normalized : Vector3.zero;
    //     
    // }
    //
    // private float GetSensitivity(Vector3 target)
    // {
    //     return Math.Abs(_startMousePosition.x - target.x) > 1f ? 1f : Math.Abs(_startMousePosition.x - target.x) / 2f;
    //     
    // }

}
