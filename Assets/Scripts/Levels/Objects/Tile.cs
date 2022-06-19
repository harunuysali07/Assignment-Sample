using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isActive = false;
    private Material tileMaterial;
    private Collider tileCollider;
    private TileLevel tileLevel;
    private Sequence seq;

    private void Awake()
    {
        tileMaterial = GetComponentInChildren<Renderer>().material;
        tileCollider = GetComponentInChildren<Collider>();
    }

    private void Start()
    {
        tileLevel = LevelManager.Instance.currentLevel as TileLevel;
        tileLevel.tiles.Add(this);

        GameController.Instance.OnLevelStart += OnLevelStart;
        GameController.Instance.OnLevelEnd += OnLevelEnd;
    }

    private void OnLevelEnd(bool _)
    {
        enabled = false;
        seq.Kill();
    }

    private void OnLevelStart()
    {
        transform.DOScale(Vector3.one * .95f, 0.5f);
        isActive = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            isActive = false;

            seq = DOTween.Sequence();
            seq.Append(tileMaterial.DOColor(Color.white, 0.4f).SetLoops(4, LoopType.Yoyo));
            seq.Append(transform.DOScale(Vector3.zero, .15f).SetEase(Ease.OutBack));
            seq.OnComplete(() =>
            {
                tileLevel.tiles.Remove(this);
                Destroy(gameObject);
            });
        }
    }

    private void OnDestroy()
    {
        GameController.Instance.OnLevelStart -= OnLevelStart;
        GameController.Instance.OnLevelEnd -= OnLevelEnd;
    }
}
