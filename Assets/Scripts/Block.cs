using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockVFX; 
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] blockState;

    //cached reference
    Level level;
    GameStatus gameStatus;

    //state variables
    [SerializeField] int timesHit = 0 ; //Serialized just for debugging.


    //Block meta
   
    private void  OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if(timesHit >= maxHits)
            {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit;
        if(blockState[spriteIndex]!=null)
        {
            GetComponent<SpriteRenderer>().sprite = blockState[spriteIndex];
        }else{
            Debug.LogError("Block Sprite is missing in "+gameObject.name+".");
        } 
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();
        Destroy(gameObject);
        TriggerSparklesVFX();
        
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockVFX,transform.position,transform.rotation);
        Destroy(sparkles,2f);
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            level.BlockDestroyed();
            Destroy(gameObject);
        }
    }
}
