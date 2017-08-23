﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item {

    #region WeaponItem INFO
    public enum WeaponType
    {
        NONE,
        GUN,
        RIFLE,
        MELEE,
        ROCKETLAUNCHER,
        ETC_GRENADE,
        ETC_RECOVERY // 이친구 임시다 웨폰 아이템 아니다 
    }

    [SerializeField] private WeaponType m_type = WeaponType.NONE;
    [SerializeField] private Vector3 m_localSetPos = Vector3.zero;
    [SerializeField] private Vector3 m_localSetRot = Vector3.zero;
    [SerializeField] private Vector3 m_localSetScale = Vector3.zero;
    [SerializeField] private Vector3 m_sponeRotation = Vector3.zero;

    public enum AttackTiming
    {
        SCRIPT_ONLY,
        ANIMATION_ONLY
    }
    [SerializeField] private AttackTiming m_attackTiming = AttackTiming.SCRIPT_ONLY;
    public AttackTiming ATTACK_TIMING { get { return m_attackTiming; } }
    private Transform m_player = null;

    public WeaponType WEAPON_TYPE { get { return m_type; } }
    public Vector3 LOCAL_SET_POS { get { return m_localSetPos; } set { m_localSetPos = value; } }
    public Vector3 LOCAL_SET_ROT { get { return m_localSetRot; } set { m_localSetRot = value; } }
    public Vector3 LOCAL_SET_SCALE { get { return m_localSetScale; } set { m_localSetScale = value;} }
    public Vector3 SPONE_ROTATITON { get { return m_sponeRotation; } set { m_sponeRotation = value; } }

    // 무기 쿨타임
    [SerializeField] private float m_coolTime = 0.0f;

    public float COOL_TIME { get { return m_coolTime; } set { m_coolTime = value; } }

    // 원거리 무기의 경우 총알로 사용
    [SerializeField] private GameObject[] m_bullets = null;
    [SerializeField] private GameObject[] m_effects = null;

    // 근거리 전용 이펙트
    // 휘두르기 모션
    [SerializeField] private GameObject m_swordAniEffect = null;
    // 피격 모션
    [SerializeField] private GameObject m_swordHitEffect = null;
    // 다른 곳에 부딪칠 경우 
    [SerializeField] private GameObject m_swordOtherHitEffect = null;
    // 근거리 무기 애니메이션 재생중인지
    private bool m_meleeAttackAble = false;

    // 근거리 무기용 테스트 로직
    private bool m_isNetwork = false;
    public bool IS_NETWORK { get { return m_isNetwork; } set { m_isNetwork = value; } }

    private int m_currentBulletIndex = 0;

    //수류탄 전용
    private bool m_isGrenadeStart = false;


    // 총알 나가는 위치
    [SerializeField] private Transform m_firePoint = null;
    public Transform FIRE_POS { get { return m_firePoint; } set { m_firePoint = value; } }

    // 무기 발사 소리
    private AudioSource m_source = null;
    [SerializeField] private AudioClip m_weaponShootSound = null;

    //임시
    float m_recoveryKitValue = 0.0f;

    #endregion

    #region Unity Method 
    void Start()
    {
        m_source = this.GetComponent<AudioSource>();
    }
    #endregion

    #region Weapon Method
    public void SoundPlay()
    {
        if (m_weaponShootSound != null)
        {
            m_source.clip = m_weaponShootSound;
            m_source.Play();
        }
    }

    public void Attack(Transform character)
    {
        m_player = character;
        switch (m_type)
        {
            case WeaponType.GUN:
            case WeaponType.RIFLE:
                
                if(m_attackTiming == AttackTiming.SCRIPT_ONLY)
                    GunAttack(character);
                break;
            case WeaponType.ROCKETLAUNCHER:
                if (m_attackTiming == AttackTiming.SCRIPT_ONLY)
                    RocketAttack(character);
                    break;
            case WeaponType.MELEE:
                EnableMeleeColider();
                break;
            case WeaponType.ETC_GRENADE:
                GrenadeAttack();
                break;
        }
    }

  

    public void AnimationEventAttack()
    {
        switch(m_type)
        {
            case WeaponType.GUN:
            case WeaponType.RIFLE:
                GunAttack(m_player);
                break;
                
        }
    }

    public void AnimationEventAttackEnd()
    {
        switch(m_type)
        {
            case WeaponType.GUN:
            case WeaponType.RIFLE:
                break;
            case WeaponType.MELEE:
                DisableMeleeColider();
                break;
        }
    }

    #region Guns Weapon Attack
    void GunAttack(Transform character)
    {
        SoundPlay();
        m_effects[0].transform.position = m_firePoint.position;
        m_effects[0].SetActive(true);

        GameObject bullet = m_bullets[m_currentBulletIndex];
        bullet.transform.parent = null;
        bullet.transform.position = m_firePoint.position;
        bullet.transform.rotation = character.rotation;
        Bullet b = bullet.GetComponent<Bullet>();
      
        // 네트워크 총알이 아니므로
        b.IS_REMOTE = false;
        
        if (NetworkManager.Instance() != null)
        {
            // 식별 아이디
            b.NETWORK_ID = NetworkManager.Instance().m_hostID + "_" + m_itemID + "_" + m_currentBulletIndex;
            // 생성 명령
            NetworkManager.Instance().C2SRequestBulletCreate(b.NETWORK_ID , m_firePoint.position , bullet.transform.localEulerAngles,m_itemID);
        }
        bullet.SetActive(true);
        b.BulletSetup();

        if (m_currentBulletIndex == m_bullets.Length - 1)
            m_currentBulletIndex = 0;
        else
            m_currentBulletIndex++;
    }

    void RocketAttack(Transform character)
    {
        SoundPlay();
        if (m_effects[0] != null)
        {
            m_effects[0].transform.position = m_firePoint.position;
            m_effects[0].SetActive(true);
        }
        

        GameObject bullet = m_bullets[m_currentBulletIndex];
        bullet.transform.parent = null;
        bullet.transform.position = m_firePoint.position;
        bullet.transform.rotation = character.rotation;
        RocketBullet b = bullet.GetComponent<RocketBullet>();

        // 네트워크 총알이 아니므로
        b.IS_REMOTE = false;

        if (NetworkManager.Instance() != null)
        {
            // 식별 아이디
            b.NETWORK_ID = NetworkManager.Instance().m_hostID + "_" + m_itemID + "_" + m_currentBulletIndex;
            // 생성 명령
            NetworkManager.Instance().C2SRequestBulletCreate(b.NETWORK_ID , m_firePoint.position , bullet.transform.localEulerAngles , m_itemID);
        }
        bullet.SetActive(true);
        b.BulletSetup();

        if (m_currentBulletIndex == m_bullets.Length - 1)
            m_currentBulletIndex = 0;
        else
            m_currentBulletIndex++;
    }
    #endregion

    #endregion

    #region Equip Weapon Logic
    public void EquipWeapon()
    {
        this.GetComponent<SphereCollider>().enabled = false;
    }

    public void UnEquipWeapon()
    {
        this.GetComponent<SphereCollider>().enabled = true;
    }
    #endregion

    #region MELEE_ATTACK
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Weapon") && col.CompareTag("DeathZone"))
            return;
        // 애니메이션 중일 때만 
        if(m_meleeAttackAble)
        {
            Debug.Log("col " + col.tag);
            if (col.CompareTag("PlayerCharacter"))
            {
                
                // 데미지다!!
                NetworkPlayer p = col.transform.GetComponent<NetworkPlayer>();
                if(p != null && IS_NETWORK == false)
                {
                    NetworkManager.Instance().C2SRequestPlayerDamage((int)p.m_hostID , p.m_userName ,ITEM_ID.ToString() , Random.Range(10.0f , 15.0f) , transform.position);
                }
                m_swordHitEffect.transform.SetParent(m_player.transform , false);
                m_swordHitEffect.transform.position = col.transform.position;
                m_swordHitEffect.SetActive(true);
                
            }
            else if (col.CompareTag("Untagged") == false && col.CompareTag("NonSpone"))
            {
                // 먼가에 맞음!
                m_swordOtherHitEffect.SetActive(true);
            }
            else 
            {
                m_swordHitEffect.transform.SetParent(m_player.transform , false);
                m_swordHitEffect.transform.position = col.transform.position;
                m_swordHitEffect.SetActive(true);
            }
            
        }
    }

    // 공격 가능 상태
    public void EnableMeleeColider()
    {
        if (m_type == WeaponType.MELEE)
        {
            m_swordAniEffect.transform.SetParent(m_player.transform.GetChild(0) , false);
            this.GetComponent<BoxCollider>().enabled = true;
            m_meleeAttackAble = true;
            m_swordAniEffect.SetActive(true);
            SoundPlay();
            if (m_swordHitEffect.transform.parent != transform)
            {
                m_swordHitEffect.transform.SetParent(transform,false);
                m_swordHitEffect.gameObject.SetActive(false);
            }
        }
    }
    // 공격 불가 상태
    public void DisableMeleeColider()
    {
        if (m_type == WeaponType.MELEE)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            m_meleeAttackAble = false;
            m_player = null;
            m_swordAniEffect.transform.SetParent(transform , false);
            m_swordAniEffect.SetActive(false);
            
            m_swordOtherHitEffect.SetActive(false);
        }
    }

    public void SwordHitEffectEnd()
    {
        m_swordHitEffect.transform.SetParent(transform , false);
        m_swordHitEffect.SetActive(false);
    }
    #endregion

    #region ETC Weapons Attack
    void GrenadeAttack()
    {
        if (m_isGrenadeStart)
            return;

        Grenade g = this.GetComponent<Grenade>();
        g.GrenadeSetup(m_player.transform.GetChild(0).rotation);
        g.enabled = true;
        m_isGrenadeStart = true;
        if (NetworkManager.Instance() == null)
            return;

        
        g.NETWORK_ID = NetworkManager.Instance().m_hostID + "_" + m_itemID + "_" + this.GetHashCode();
        NetworkManager.Instance().RequestGrenadeCreate(g.NETWORK_ID , g.transform.position);
    }

    // 임시로직
    public void Recovery(PlayerController player)
    {
        // 여기서 게이지를 넣자

        // 다되면 힐
        GameManager.Instance().SLIDER_UI.ShowSlider();

        m_recoveryKitValue += 1f * Time.deltaTime;

        GameManager.Instance().SLIDER_UI.SliderProcess(m_recoveryKitValue);

        if(m_recoveryKitValue >= 1.0f)
        {
            player.RecoveryItemUseEnd();
            GameManager.Instance().SLIDER_UI.HideSlider();
            if (NetworkManager.Instance() != null)
                NetworkManager.Instance().RequestHpUpdate(GameManager.Instance().PLAYER.m_hp + 30.0f);
        }

    }
    public void RecoveryUp()
    {
        m_recoveryKitValue = 0.0f;
        GameManager.Instance().SLIDER_UI.Reset();
        GameManager.Instance().SLIDER_UI.HideSlider();
    }
    #endregion
}
