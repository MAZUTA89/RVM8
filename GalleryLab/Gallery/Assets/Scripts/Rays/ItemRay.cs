using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemRay : RayInteraction
{
    const string c_artItemTag = "ArtItem";
    [SerializeField] GameObject InteractButton;
    [SerializeField] float InteractDistance;
    InputService _inputService;
    [Inject]
    public void Construct(InputService inputService)
    {
        _inputService = inputService;
    }
    public override void onHitRay()
    {
        if (HitObject.tag == c_artItemTag &&
            InteractDistance > _rayCastHit.distance)
        {
            InteractButton.SetActive(true);
            if (_inputService.IsInteract())
            {
                if (HitObject.TryGetComponent(out ArtItem artItem))
                {
                    artItem.Interact();
                }
            }
        }
        else
        {
            InteractButton.SetActive(false);
        }
    }

    public override void onMissRay()
    {
        InteractButton?.SetActive(false);
    }

    public override void onStart()
    {
        InteractButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CatchRay();
    }
}
