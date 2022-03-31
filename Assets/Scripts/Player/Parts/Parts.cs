using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [Header("Parameter")]
    [SerializeField]
    private bool _isCore;
    [SerializeField]
    private PartsType _partsType;
    [Header("Reference")]
    [SerializeField]
    private List<PieceModel> _pieceModels=new List<PieceModel>();
    private Dictionary<(int X,int Y),PieceModel> _pieceDict=new Dictionary<(int X,int Y),PieceModel>();
    public List<PieceModel> PieceModels{
        get{return _pieceModels;}
    }
    private void Start() {
        InitPiecesAreas();
    }
    //内側のエリアをflatにし、外側のエリアをfortにする
    private void InitPiecesAreas(){
        //辞書構築
        _pieceModels.ForEach(p=>{
            _pieceDict.Add((p.X,p.Y),p);
        });
        //隣接しているやつを平らにするヨ
        _pieceModels.ForEach(piece=>{
            //Directionに沿って上下左右探索
            foreach ((int dx,int dy,Direction.Type dir) in Direction.DxDy)
            {
                int x=piece.X+dx;
                int y=piece.Y+dy;
                if(_pieceDict.ContainsKey((x,y))){
                    //隣接発見!平らにします
                    piece.ChangeAreaTypes(dir,AreaType.flat);
                }else{
                    //外側なのでfortにする
                    piece.ChangeAreaTypes(dir,AreaType.fort);
                }
            }
        });
    }
}
