using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ShotGun : MonoBehaviour {
 
    // bullet prefab
    public GameObject bullet;
 
    // 弾丸発射点
    public Transform muzzle;
 
    // 弾丸の速度
    public float speed = 1000;

    // 弾丸の発射間隔(50で一秒に一回、25で一秒に二回)
    public int maxCount = 150; 
 
    int count = 0;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
    /*
	void Update () {
        // z キーが押された時
        if (Input.GetKeyDown(KeyCode.Z)){
            
            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;
 
            Vector3 force;
 
            force = this.gameObject.transform.up * speed;
 
            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody2D>().AddForce(force);
 
            // 弾丸の位置を調整
            bullets.transform.position = muzzle.position;
        }
    }
    */

    void FixedUpdate () {
        count += 1;
        if (count == maxCount) {
            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;
 
            Vector3 force;
 
            force = this.gameObject.transform.up * speed;
 
            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody2D>().AddForce(force);
 
            // 弾丸の位置を調整
            bullets.transform.position = muzzle.position;

            count = 0;
        }
    }
}