using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController _gc;
    public static GameController Instance() { return _gc; }
    private void Awake()
    {
        if (_gc == null)
        {
            _gc = this;
            DontDestroyOnLoad(_gc.gameObject);
        }
    }
    #endregion

    public GameObject selected;
    [SerializeField] GameObject cursor;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        cursor.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }
}
