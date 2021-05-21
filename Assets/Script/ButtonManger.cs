using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonManger : MonoBehaviour
{
    [SerializeField] private RawImage buttonImage;
    private Button btn;
    private int _itemId;
    private Sprite _buttonTexture;

    public int ItemId
    {
        set => _itemId = value;
    }
    public Sprite ButtonTexture
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Selectobject);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManger.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.2f);
        }
        else
        {
            transform.DOScale(Vector3.one, 0.2f);
        }

    }
    void Selectobject()
    { 
        DateHandler.Instance.SetFurinute(_itemId);
    }

}
