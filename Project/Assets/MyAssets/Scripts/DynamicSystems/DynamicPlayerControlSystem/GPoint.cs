using System;
using UnityEngine;
public class GPoint
{
    Vector3 _position;
    public Vector3 Position => _position;
    public GPoint(Vector3 position) =>
        _position = position;
}
