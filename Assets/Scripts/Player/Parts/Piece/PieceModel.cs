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
    private readonly ReactiveCollection<AreaType> _AreaTypesRP = new ReactiveCollection<AreaType>() { AreaType.proj, AreaType.proj, AreaType.proj, AreaType.proj };
    public List<AreaType> AreaTypes
    {
        get { return _AreaTypesRP.ToList(); }
    }
    public IObservable<CollectionReplaceEvent<AreaType>> AreaTypesRO => _AreaTypesRP.ObserveReplace();
    /// <summary>
    /// 上下左右のエリアについてAreaTypeを変更する
    /// </summary>
    /// <param name="dir">方向</param>
    /// <param name="areaType"></param>
    public void ChangeAreaTypes(Direction.Type dir, AreaType areaType)
    {
        _AreaTypesRP[(int)dir] = areaType;
    }
    [ContextMenu("Debug")]
    void Debug(){
        
    }
}
