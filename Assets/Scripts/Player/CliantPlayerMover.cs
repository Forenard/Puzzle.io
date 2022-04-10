using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliantPlayerMover : MonoBehaviour
{
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pd = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        Vector2 pn = pd.normalized; //正規化
        /* 回転 */
        float angle = Vector3.Angle(new Vector3(0, 1, 0), pn);
        if (pn.x > 0) angle = -angle;
        this._rb.SetRotation(angle);
        if (Input.GetMouseButton(0))
        {
            //移動
            //this._rb.MovePosition((Vector2)this.transform.position+pn* ParameterDefinition.PlayerSpeed* Time.deltaTime);
            this._rb.velocity = pn * ParameterDefinition.PlayerSpeed;
        }
        else
        {
            this._rb.velocity = new Vector3(0, 0, 0);
            this._rb.angularVelocity = 0f;
        }
    }
}