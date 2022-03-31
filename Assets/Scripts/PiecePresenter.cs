using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class PiecePresenter : MonoBehaviour
{
    [SerializeField]
    private PieceModel _pieceModel=null;
    [SerializeField]
    private PieceView _pieceView=null;
    private void Start() {
        _pieceModel.pieceAreaTypesRO.Subscribe(value=>{_pieceView.SetActiveType(value.Index,value.NewValue);});
    }
}