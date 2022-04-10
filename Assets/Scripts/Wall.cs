using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //弾の種類によって消すか決める
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(TagStrings.Bullet)){
            var bullet =other.transform.GetComponent<Bullet>();
            if(bullet.BulletType==BulletType.normal||bullet.BulletType==BulletType.wide){
                bullet.DestroyThisObject();
            }
        }
    }
}
