using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO:BulletType毎に弾の挙動を変える
public class ShotGun : MonoBehaviour {
    [Header("Refalence")]
    // bullet prefab
    [SerializeField,Tooltip("BulletTypeの順番に沿って下さい")]
    private List<GameObject> _bulletPrefabs=new List<GameObject>(4);
 
    // 弾丸発射点
    [SerializeField]
    private Transform _muzzle;
    
    [Header("Parameter")]
    // 弾丸の速度
    [SerializeField]
    private float _speed = 1f;

    // 弾丸の発射間隔(50で一秒に一回、25で一秒に二回)
    [SerializeField]
    private int _maxCount = 150; 
 
    private int _count = 0;
    private BulletType _bulletType;
    private Parts _parts;

	// Use this for initialization
	void Awake () {
        _parts=this.transform.parent.parent.parent.GetComponent<Parts>();
		_bulletType=_parts.BulletType;
	}

    void FixedUpdate () {
        _count += 1;
        if (_count == _maxCount) {
            //TODO BulletTypeがwideの場合、弾生成の仕方を変える
            // 弾丸の複製
            GameObject bulletPrefab=_bulletPrefabs[(int)_bulletType];
            GameObject bulletObj = Instantiate(bulletPrefab);
 
            Vector3 direction;
 
            direction = this.gameObject.transform.up;

            var bullet =bulletObj.GetComponent<Bullet>();
            bullet.SetParams(direction,_speed);
 
            // 弾丸の位置を調整
            bulletObj.transform.position = _muzzle.position;

            _count = 0;
        }
    }
}