using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [Header("Parameter")]

    [SerializeField]
    private PartsType _partsType;
    public PartsType PartsType
    {
        get { return _partsType; }
        set { _partsType = value; }
    }
    [Header("Reference")]
    [SerializeField]
    private List<PieceModel> _pieceModels = new List<PieceModel>();
    public List<PieceModel> PieceModels
    {
        get { return _pieceModels; }
    }
    private bool _isCore;
    public bool IsCore
    {
        get { return _isCore; }
        set { _isCore = value; }
    }
    private Dictionary<(int X, int Y), PieceModel> _pieceDict = new Dictionary<(int X, int Y), PieceModel>();
    public Dictionary<(int X, int Y), PieceModel> PieceDict
    {
        get { return _pieceDict; }
    }
    private void Awake()
    {
        SetUpPiecesAreas();
    }
    /// <summary>
    /// パーツを回転させる
    /// </summary>
    /// <param name="dir">回転方向</param>
    public void Rotate(Direction.Type dir)
    {
        foreach (var pieceModel in _pieceModels)
        {
            Vector2 newpos = Quaternion.Euler(0, 0, 360f - 90f * (int)dir).normalized * new Vector2(pieceModel.X, pieceModel.Y);
            //丸め誤差を避けるため、予めintに制限しておく(最もintに近い方向へ丸める)
            pieceModel.X = Mathf.FloorToInt(newpos.x + 0.5f);
            pieceModel.Y = Mathf.FloorToInt(newpos.y + 0.5f);
            pieceModel.Rotate(dir);
        }
    }
    //内側のエリアをflatにし、外側のエリアをfortにする
    private void SetUpPiecesAreas()
    {
        //辞書構築
        _pieceModels.ForEach(p =>
        {
            if (!_pieceDict.ContainsKey((p.X, p.Y)))
            {
                _pieceDict.Add((p.X, p.Y), p);
            }
        });
        //隣接しているやつを平らにするヨ
        _pieceModels.ForEach(piece =>
        {
            //Directionに沿って上下左右探索
            foreach ((int dx, int dy, Direction.Type dir) in Direction.DxDy)
            {
                int x = piece.X + dx;
                int y = piece.Y + dy;
                if (_pieceDict.ContainsKey((x, y)))
                {
                    //隣接発見!平らにします
                    piece.ChangeAreaTypes(dir, AreaType.flat);
                }
                else
                {
                    //外側なのでfortにする
                    piece.ChangeAreaTypes(dir, AreaType.fort);
                }
            }
        });
    }
}
