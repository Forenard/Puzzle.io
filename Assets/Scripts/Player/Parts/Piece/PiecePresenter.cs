using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class PiecePresenter : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private PieceModel _pieceModel=null;
    [SerializeField]
    private PieceView _pieceView=null;
    private void Awake() {
        InitSubscribe();
    }
    //購読の初期化
    private void InitSubscribe(){
        _pieceModel.AreaTypesRO.Subscribe(value=>{_pieceView.SetAreaTypes((Direction.Type)value.Index,value.NewValue);});
    }
}