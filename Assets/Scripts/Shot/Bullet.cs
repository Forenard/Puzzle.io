using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:BulletType毎に弾の挙動を変える
public class Bullet : MonoBehaviour {
    [SerializeField]
    private BulletType _bulletType;
    private Vector2 _direction=Vector2.zero;
    private float _speed=0f;
    private Vector2 _firstPosition;

    public BulletType BulletType { get => _bulletType; set => _bulletType = value; }

    private void Start() {
        _firstPosition=this.transform.position;
    }
    public void SetParams(Vector2 dir,float speed){
        _direction=dir;
        _speed=speed;
    }
    private void Update() {
        this.transform.Translate(_direction*_speed*Time.deltaTime);
        CheckMaxDistance();
    }
    //距離制限を掛ける
    private void CheckMaxDistance(){
        float dist=((Vector2)this.transform.position-_firstPosition).magnitude;
        if(dist>ParameterDefinition.BulletMaxDistance){
            DestroyThisObject();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(_bulletType==BulletType.bound){
            //TODO BulletTypeがboundの場合、何かに当たった際にdirectionを反転させる
        }
    }
    public void DestroyThisObject(){
        Destroy(this.gameObject);
    }
}