using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class CliantPlayerFactory : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]
    private GameObject _cliantPlayerPrefab=null;
    [SerializeField]
    private List<GameObject> _initPartsPrefabs=null;
    void Start()
    {
        //debug
        DoDebug(1);
    }
    private void DoDebug(float intervalTime){
        var obj=CreateCliantPlayer(Vector2.zero,_initPartsPrefabs[Random.Range(0,_initPartsPrefabs.Count)]);
        CliantPlayer cplayer=obj.GetComponent<CliantPlayer>();
        Observable.Timer(System.TimeSpan.FromSeconds((double)intervalTime)).Do(_=>{
            GameObject partsObj=CreateRandomParts(true);
            cplayer.AddParts(partsObj.GetComponent<Parts>());
        }).DoOnCompleted(()=>Debug.Log("add parts")).Repeat().Subscribe().AddTo(this);
    }

    private GameObject CreateRandomParts(bool rotate){
        GameObject res= GameObject.Instantiate(_initPartsPrefabs[Random.Range(0,_initPartsPrefabs.Count)],Vector2.zero,Quaternion.identity);
        res.GetComponent<Parts>().Rotate((Direction.Type)Random.Range(0,4));
        return res;
    }

    /// <summary>
    /// CliantPlayerを生成する
    /// </summary>
    /// <param name="pos">生成位置</param>
    /// <param name="corePartsPrefab">coreとなるパーツのprefab</param>
    /// <returns>生成したCliantPlayer</returns>
    public GameObject CreateCliantPlayer(Vector2 pos,GameObject corePartsPrefab){
        GameObject res=GameObject.Instantiate(_cliantPlayerPrefab,pos,Quaternion.identity);
        CliantPlayer cplayer=res.GetComponent<CliantPlayer>();
        GameObject partsObj=GameObject.Instantiate(corePartsPrefab,Vector2.zero,Quaternion.identity);
        Parts parts=partsObj.GetComponent<Parts>();
        parts.IsCore=true;
        cplayer.AddParts(parts);
        return res;
    }
}
