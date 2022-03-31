using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class PieceModel : MonoBehaviour
{
    public int X
    {
        get { return (int)this.transform.localPosition.x; }
    }
    public int Y
    {
        get { return (int)this.transform.localPosition.y; }
    }
    private readonly ReactiveCollection<PieceAreaType> _pieceAreaTypesRP = new ReactiveCollection<PieceAreaType>() { PieceAreaType.proj, PieceAreaType.proj, PieceAreaType.proj, PieceAreaType.proj };
    public List<PieceAreaType> pieceAreaTypes
    {
        get { return _pieceAreaTypesRP.ToList(); }
    }
    public IObservable<CollectionReplaceEvent<PieceAreaType>> pieceAreaTypesRO => _pieceAreaTypesRP.ObserveReplace();
    /// <summary>
    /// 上下左右のエリアについてAreaTypeを変更する
    /// </summary>
    /// <param name="dir">方向</param>
    /// <param name="areaType"></param>
    public void ChangePieceAreaTypes(Direction.Type dir, PieceAreaType areaType)
    {
        _pieceAreaTypesRP[(int)dir] = areaType;
    }
    [ContextMenu("Debug")]
    void Debug(){
        
    }
}
