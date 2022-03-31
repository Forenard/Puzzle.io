using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class PieceModel : MonoBehaviour
{
    private readonly ReactiveCollection<PieceAreaType> _pieceAreaTypesRP = new ReactiveCollection<PieceAreaType>() { PieceAreaType.proj, PieceAreaType.proj, PieceAreaType.proj, PieceAreaType.proj };
    public List<PieceAreaType> pieceAreaTypes
    {
        get { return _pieceAreaTypesRP.ToList(); }
    }
    public IObservable<CollectionReplaceEvent<PieceAreaType>> pieceAreaTypesRO => _pieceAreaTypesRP.ObserveReplace();
    public void ChangePieceAreaTypes(int ind, PieceAreaType areaType)
    {
        _pieceAreaTypesRP[ind] = areaType;
    }
}
