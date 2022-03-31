using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceAreaView : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private GameObject _projGameObj=null;
    [SerializeField]
    private GameObject _dentGameObj=null;
    [SerializeField]
    private GameObject _flatGameObj=null;
    private Dictionary<PieceAreaType,GameObject> _gameObjDict=new Dictionary<PieceAreaType,GameObject>(3);
    private void Awake() {
        _gameObjDict[PieceAreaType.proj]=_projGameObj;
        _gameObjDict[PieceAreaType.dent]=_dentGameObj;
        _gameObjDict[PieceAreaType.flat]=_flatGameObj;
    }
    /// <summary>
    /// AreaTypeを設定する
    /// </summary>
    /// <param name="areaType"></param>
    public void SetAreaType(PieceAreaType areaType){
        foreach (var typeObjPair in _gameObjDict)
        {
            PieceAreaType type=typeObjPair.Key;
            GameObject obj=typeObjPair.Value;
            if(type==areaType){
                obj?.SetActive(true);
            }else{
                obj?.SetActive(false);
            }
        }
    }
}
