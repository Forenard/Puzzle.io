using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceView : MonoBehaviour
{
    [SerializeField]
    private List<PieceAreaView> pieceAreaViews=new List<PieceAreaView>(4);
    
    public void SetActiveType(int ind,PieceAreaType areaType){
        pieceAreaViews[ind].SetActiveType(areaType);
    }
}
