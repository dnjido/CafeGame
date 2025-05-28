using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCSay : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _point;
    [SerializeField] private string _message;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NPCNavigate>().CompleteEvent += Say;
    }

    // Update is called once per frame
    public void Say()
    {
        GameObject go = Instantiate(_prefab, _point.position, _point.rotation);
        go.GetComponent<TMP_Text>().text = _message;
        go.transform.DOMoveY(go.transform.position.y + 1, 2f).OnComplete(() => { Destroy(go); });
    }
}
