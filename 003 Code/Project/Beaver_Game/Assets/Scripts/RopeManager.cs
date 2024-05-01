using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeManager : MonoBehaviour
{
    public GameObject ropePrefab;
    public Button throwRopeButton;

    public void ThrowRopeLineLeftRightChange()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
    }

    public void OnClickThrowRopeButton()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void Start()
    {
        throwRopeButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (this.transform.GetChild(0).gameObject.activeSelf)
        {
            
            Vector3 rot = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position + Vector3.forward * 10;

            float angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0, 0, angle);


            if (Input.GetMouseButtonDown(0))
            {
                GameObject newRope = Instantiate(ropePrefab);
                newRope.transform.position = this.transform.position + rot.normalized * 1.5f;   // 1.5�� �ڱ� �ڽſ��� ���� �ʰ� �Ϸ���
                newRope.GetComponent<RopeCollision>().SetDirection(rot.normalized);

                Debug.Log(rot);
                transform.GetChild(0).gameObject.SetActive(false);
            }
            
        }
    }
}