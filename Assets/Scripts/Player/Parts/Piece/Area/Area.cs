using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private GameObject _projGameObj=null;
    [SerializeField]
    private GameObject _dentGameObj=null;
    [SerializeField]
    private GameObject _flatGameObj=null;
    [SerializeField]
    private GameObject _fortGameObj=null;
    private Dictionary<AreaType,GameObject> _gameObjDict=new Dictionary<AreaType,GameObject>(3);
    private void Awake() {
        _gameObjDict[AreaType.proj]=_projGameObj;
        _gameObjDict[AreaType.dent]=_dentGameObj;
        _gameObjDict[AreaType.flat]=_flatGameObj;
        _gameObjDict[AreaType.fort]=_fortGameObj;
    }
    /// <summary>
    /// AreaTypeを設定する
    /// </summary>
    /// <param name="areaType"></param>
    public void SetAreaType(AreaType areaType){
        foreach (var typeObjPair in _gameObjDict)
        {
            AreaType type=typeObjPair.Key;
            GameObject obj=typeObjPair.Value;
            if(type==areaType){
                obj?.SetActive(true);
            }else{
                obj?.SetActive(false);
            }
        }
    }
}
