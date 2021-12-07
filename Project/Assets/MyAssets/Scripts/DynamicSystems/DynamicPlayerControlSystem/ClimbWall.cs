using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ClimbWall : MonoBehaviour
{
    [SerializeField] private GameObject _climbPoint;
    [SerializeField] private Transform _topWall;
    public GameObject ClimbPoint => _climbPoint;
    public Transform TopWall => _topWall;
    /*
    [MenuItem("CONTEXT/ClimbWall/Initialize GPoints")]
    private static void InitializeGPoints(MenuCommand menuCommand) {
        
        ClearGPoints(menuCommand);

        var climbWall = menuCommand.context as ClimbWall;
        if (climbWall == null)
            return;

        GameObject _prefubGPoint = Resources.Load<GameObject>("Prefubs/GPoint");
        Vector3 distanceVector = (climbWall._endTransform.position - climbWall._beginTransform.position);

        //логика расстановки точек
        int countGPoints = Mathf.RoundToInt(distanceVector.magnitude / climbWall._step);

        for(int i = 1; i < countGPoints; i++) {
            var prefab = PrefabUtility.InstantiatePrefab(_prefubGPoint, climbWall._rootGPoints) as GameObject;
            prefab.transform.position = climbWall._beginTransform.position + distanceVector.normalized * climbWall._step * i;
        }
    }

    [MenuItem("CONTEXT/ClimbWall/Clear GPoints")]
    private static void ClearGPoints(MenuCommand menuCommand) {
        var climbWall = menuCommand.context as ClimbWall;
        if (climbWall == null)
            return;

        var count = climbWall._rootGPoints.childCount;
        for (var i = count - 1; i >= 0; i--)
        {
            DestroyImmediate(climbWall._rootGPoints.GetChild(i).gameObject);
        }
    }
    */
}
