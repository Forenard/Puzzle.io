using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CliantPlayer : MonoBehaviour
{
    private List<Parts> _partsCollection=new List<Parts>();
    private Dictionary<(int X,int Y),PieceModel> _pieceDict=new Dictionary<(int X,int Y),PieceModel>();
    private HashSet<(int X,int Y)> _pieceAroundDict=new HashSet<(int X,int Y)>();
    private List<PieceModel> _pieceModels{
        get{return _pieceDict.Values.ToList();}
    }

    /// <summary>
    /// パーツを設置する
    /// </summary>
    /// <param name="parts">パーツ</param>
    public void AddParts(Parts parts){
        _partsCollection.Add(parts);
        (int offX,int offY)=GetPutPartsPos(parts);
        parts.transform.SetParent(this.transform);
        parts.transform.localPosition=new Vector3(offX,offY,0);
        parts.transform.localRotation=Quaternion.identity;
        UpdateDicts(parts,offX,offY);
        SetUpPiecesAreas(parts,offX,offY);
    }
    //パーツがおける場所を返す
    private (int X,int Y) GetPutPartsPos(Parts parts){
        List<(int X,int Y)> aroundPoses=_pieceAroundDict.ToList().OrderBy(_=>Random.value).ToList();
        if(_pieceAroundDict.Count==0){
            return (0,0);
        }
        foreach ((int ax,int ay) in aroundPoses)
        {
            foreach (var p in parts.PieceModels)
            {
                int offX=ax-p.X;
                int offY=ay-p.Y;
                bool flag=false;
                foreach (var piece in parts.PieceModels)
                {
                    int x=piece.X+offX;
                    int y=piece.Y+offY;
                    if(_pieceDict.ContainsKey((x,y))){
                        flag=false;
                        break;
                    }else if(_pieceAroundDict.Contains((x,y))){
                        flag=true;
                    }
                }
                if(flag){
                    return (offX,offY);
                }
            }
        }
        Debug.LogError("Cant Put Prts WTF");
        return (0,0);
    }
    //ピースとその周辺の辞書情報を更新する
    private void UpdateDicts(Parts parts,int offX,int offY){
        //_pieceDictの構築
        parts.PieceModels.ForEach(piece=>{
            _pieceDict.Add((piece.X+offX,piece.Y+offY),piece);
        });
        //_pieceAroundDictの構築
        parts.PieceModels.ForEach(piece=>{
            foreach ((int dx,int dy,Direction.Type _) in Direction.DxDy)
            {
                int x=piece.X+offX+dx;
                int y=piece.Y+offY+dy;
                if(!_pieceDict.ContainsKey((x,y))){
                    if(!_pieceAroundDict.Contains((x,y))){
                        _pieceAroundDict.Add((x,y));
                    }
                }
            }
        });
    }
    //piecesについて内側のエリアをdentにし、外側のエリアをfortにする
    private void SetUpPiecesAreas(Parts parts,int offX,int offY){
        //隣接しているやつを平らにするヨ
        parts.PieceModels.ForEach(piece=>{
            //Directionに沿って上下左右探索
            foreach ((int dx,int dy,Direction.Type dir) in Direction.DxDy)
            {
                int x=piece.X+offX+dx;
                int y=piece.Y+offY+dy;
                if(_pieceDict.ContainsKey((x,y))){
                    //隣接発見!確率で凹凸を決めます!
                    if(Random.value<0.5f){
                        piece.ChangeAreaTypes(dir,AreaType.dent);
                        _pieceDict[(x,y)].ChangeAreaTypes(Direction.Invert(dir),AreaType.proj);
                    }else{
                        piece.ChangeAreaTypes(dir,AreaType.proj);
                        _pieceDict[(x,y)].ChangeAreaTypes(Direction.Invert(dir),AreaType.dent);
                    }
                }else{
                    //外側なのでfortにする
                    piece.ChangeAreaTypes(dir,AreaType.fort);
                }
            }
        });
    }
}
