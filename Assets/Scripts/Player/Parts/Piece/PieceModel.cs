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
        get { return Mathf.FloorToInt(this.transform.localPosition.x+0.5f);}
        set {
            Vector2 newpos=new Vector2(value,this.transform.localPosition.y);
            this.transform.localPosition=newpos;
        }
    }
    public int Y
    {
        get { return Mathf.FloorToInt(this.transform.localPosition.y+0.5f); }
        set {
            Vector2 newpos=new Vector2(this.transform.localPosition.x,value);
            this.transform.localPosition=newpos;
        }
    }
    private readonly ReactiveCollection<AreaType> _AreaTypesRP = new ReactiveCollection<AreaType>() { AreaType.proj, AreaType.proj, AreaType.proj, AreaType.proj };
    public List<AreaType> AreaTypes
    {
        get { return _AreaTypesRP.ToList(); }
    }
    private Parts _parts=null;
    private void Awake() {
        _parts=this.transform.parent.GetComponent<Parts>();
    }
    public IObservable<CollectionReplaceEvent<AreaType>> AreaTypesRO => _AreaTypesRP.ObserveReplace();
    /// <summary>
    /// 上下左右のエリアについてAreaTypeを変更する
    /// </summary>
    /// <param name="dir">方向</param>
    /// <param name="areaType"></param>
    public void ChangeAreaTypes(Direction.Type dir, AreaType areaType)
    {
        //内部でない場合に限る
        if(!(_AreaTypesRP[(int)dir]==AreaType.flat)){
            _AreaTypesRP[(int)dir] = areaType;
        }
    }
    /// <summary>
    /// パーツを回転させる
    /// </summary>
    /// <param name="dir">回転方向</param>
    public void Rotate(Direction.Type dir){
        var areatypes=_AreaTypesRP.ToList();
        for (int i = 0; i < 4; i++)
        {
            _AreaTypesRP[i]=areatypes[(i-(int)dir+4)%4];
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag(TagStrings.Bullet)){
            //弾が当たった！
            AttakedByBullet();
        }
    }
    //弾と衝突した際に呼ばれる
    private void AttakedByBullet(){

    }
}
