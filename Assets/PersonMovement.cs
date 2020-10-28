using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    public AnimationClip otherAimClip;
    private Animator _animator;
    private AnimatorOverrideController _overrideController;
    private AnimatorOverrideController _cache;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("running", Input.GetKey(KeyCode.W));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("rolling");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _animator.SetTrigger("tossing");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("attacking");
        }

        if (otherAimClip != null && Input.GetKeyDown(KeyCode.Q))
        {
            _overrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);

            _cache = _overrideController;

            _overrideController["mixamo.com"] = otherAimClip;

            _animator.runtimeAnimatorController = _overrideController;
        }
    }


}
