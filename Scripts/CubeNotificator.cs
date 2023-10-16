using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeNotificator : MonoBehaviour
{

    public delegate void Message();
    public delegate void Points(int score, GameObject sphere);
    public event Message OnColissionWithAny = delegate { };
    public event Message OnColissionWithGroup1 = delegate { };
    public event Points  OnAddScoreGroup1 = delegate { };
    public event Points  OnAddScoreGroup2 = delegate { };
    public event Message OnColissionWithCylinder = delegate { };

    void OnCollisionEnter(Collision other) {
        GameObject target = other.collider.gameObject;
        switch (target.tag)
        {
            case "group1":        OnColissionWithGroup1(); OnAddScoreGroup1(5, target); break;
            case "group2":        OnAddScoreGroup2(10, target); OnColissionWithAny(); break;
            case "blue_cylinder": OnColissionWithCylinder(); break;
            default:              OnColissionWithAny(); break;
        }
    }

}
