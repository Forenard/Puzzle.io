using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceView : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private List<PieceAreaView> _pieceAreaViews=new List<PieceAreaView>(4);
    /// <summary>
    /// 上下左右のエリアについてAreaTypeを変更する
    /// </summary>
    /// <param name="dir">方向</param>
    /// <param name="areaType"></param>
    public void SetAreaTypes(Direction.Type dir,PieceAreaType areaType){
        _pieceAreaViews[(int)dir].SetAreaType(areaType);
    }
}
