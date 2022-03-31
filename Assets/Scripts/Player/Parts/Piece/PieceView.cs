using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceView : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private List<Area> _Areas=new List<Area>(4);
    /// <summary>
    /// 上下左右のエリアについてAreaTypeを変更する
    /// </summary>
    /// <param name="dir">方向</param>
    /// <param name="areaType"></param>
    public void SetAreaTypes(Direction.Type dir,AreaType areaType){
        _Areas[(int)dir].SetAreaType(areaType);
    }
}
