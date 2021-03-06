﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeForEscape.Object;

public class WeaponManager : Singletone<WeaponManager> {

    // WeaponManager - 총알 및 기타 무기의 동기화에 관한 처리를 함
    // 네트워크 생성 요청 / 이동 / 삭제 또한 여기서 하도록
    #region Weapon Manager INFO ----------------------------------------------------------------------------

    // 게임 아이템 아웃라인 머테리얼
    [SerializeField]
    private Material m_outLineMat = null;

    public Material ITEM_OUTLINE_MAT { get { return m_outLineMat; } }

    public enum WeaponType
    {
        GUN = 0,
        RIFLE,
        ROCKET_LAUNCHER,
        SWORD,
        GRENADE,
        HEAL_PACK
    }

    public enum NetworkObjectType
    {
        NONE,
        SATELLITE,
        CAMERA_OBSERVER
    }

    // TEMP SOUND
    private SortedList<string , AudioClip> m_bulletSoundList = new SortedList<string , AudioClip>();

    private bool IsSound(string key)
    {
        return m_bulletSoundList.ContainsKey(key);
    }

    #region Weapon Gun Bullet 

    #region Bullet List Info
    // 살아있는 총알의 부모
    [SerializeField] Transform m_aliveNetworkBulletParent = null;
    // 죽어있는 총알의 부모
    [SerializeField] Transform m_deadNetworkBulletParent = null;

    // 살아있는 내 총알의 부모
    [SerializeField] Transform m_myAliveBulletParent = null;
    // 죽어있는 내 총알의 부모
    [SerializeField] Transform m_myDeadBulletParent = null;


    // 총알 리스트 / 내가 쏜 총알 리스트 [ 살아있음 ]
    [SerializeField]  private List<Bullet> m_myAlivebulletList = new List<Bullet>();
    // 총알 리스트 / 내가 쏜 총알 리스트 [ 죽어있음 ]
    [SerializeField]  private List<Bullet> m_myDeadBulletList = new List<Bullet>();
    // 네트워크 총알 리스트 [ 살아있음 ]
    [SerializeField]  private List<Bullet> m_networkAliveBulletList = new List<Bullet>();
    // 네트워크 총알 리스트 [ 죽음 - 재사용 ]
    [SerializeField]  private List<Bullet> m_networkDeadBulletList = new List<Bullet>();
    #endregion


    #endregion

    #region Weapon Grenade 
    // 수류탄에 관련된 처리는 여기서 한다.
    #endregion

    #region Table Data 
    [SerializeField] private WeaponTable m_weaponTable = null;
    [SerializeField] private NetworkObjectTable m_networkObjectTable = null;
    Dictionary<string , WeaponTableData> m_weaponDict = new Dictionary<string , WeaponTableData>();
    Dictionary<string , NetworkObjectTableData> m_networkObjectDict = new Dictionary<string , NetworkObjectTableData>();
    #endregion

    #region NetworkObject 
    // Network Object
    private Dictionary<string , NetworkObject> m_networkObjectList =
        new Dictionary<string , NetworkObject>(); ///< 네트워크 오브젝트들을 관리함
    [SerializeField]
    Transform m_networkObjectParent = null; ///< 네트워크 오브젝트가 들어갈 오브젝트의 부모
    #endregion

    #endregion

    #region Table Data Getting ------------------------------------------------------------------------------

    public void LoadTable()
    {
        for (int i = 0; i < m_weaponTable.dataArray.Length; i++)
            m_weaponDict.Add(m_weaponTable.dataArray[i].Id , m_weaponTable.dataArray[i]);

        for (int i = 0; i < m_networkObjectTable.dataArray.Length; i++)
            m_networkObjectDict.Add(m_networkObjectTable.dataArray[i].Id , m_networkObjectTable.dataArray[i]);
    }
    // 모든 무기 종류 수 반환
    public int GetTotalWeaponCount()
    {
        return m_weaponTable.dataArray.Length;
    }

    public WeaponTableData GetWeaponData(string id)
    {
        if (m_weaponDict.Count == 0)
            LoadTable();
        return m_weaponDict[id];   
    }
    
    public NetworkObjectTableData GetNetworkObjectTableData(string id)
    {
        if (m_networkObjectDict.Count == 0)
            LoadTable();
        return m_networkObjectDict[id];
    }
    #endregion


    // 여기 메소드들은 NetworkManager 에서만 호출이 가능하다
    #region Network Message Recv Function ------------------------------------------------------------------
    // 생성 요청
    public void NetworkBulletCreateRequest(int hostID, string bulletID,string weaponID ,Vector3 pos,Vector3 rot)
    {
        // 생성을 할때 기존 네트워크 사망 총알리스트에서 가용한 게 있는지 확인
        // 가용한 것이라 함은 ALIVE 가  FALSE 인 총알들

        Bullet bullet = null;
        int index = -1;
        for(int i = 0; i < m_networkDeadBulletList.Count; i++)
        {
            if (!m_networkDeadBulletList[i].WEAPON_ID.Equals(weaponID) || m_networkDeadBulletList[i].IS_ALIVE == true)
                continue;

            bullet = m_networkDeadBulletList[i];
            index = i;

            Bullet bb = bullet.GetComponent<Bullet>();
            if (bb.AUDIO_SOURCE == null)
                bb.AUDIO_SOURCE = bullet.gameObject.AddComponent<AudioSource>();
            SoundSetup(bb , GetWeaponData(bb.WEAPON_ID));
            break;
        }

        // 가용한 것이 없을 경우 생성
        if (bullet == null)
        {
            GameObject prefab = CreateBullet(weaponID,false);

            if (prefab == null)
            {
                Debug.Log("ERROR 총알 prefab 이 등록되어있지 않습니다. 확인 요망  WeaponID " + weaponID + " bullet ID " + bulletID);
                return;
            }
            // 프리팹에서 사용할 Bullet Component 를 꺼냄
            bullet = prefab.GetComponent<Bullet>();

            // 네트워크 기본 셋업을 진행
            bullet.NetworkBulletEnable();
        }
        else
            m_networkDeadBulletList.RemoveAt(index);

        var renderer = bullet.BULLET_TRAIL_EFFECT.GetComponentInChildren<TrailRenderer>();
        if (renderer != null)
            renderer.Clear();
        bullet.NETWORK_ID = bulletID;

        bullet.IS_REMOTE = true;
        bullet.IS_ALIVE = true;
        
        m_networkAliveBulletList.Add(bullet);

        // 위치 변경
        
        bullet.NetworkReset(new Nettention.Proud.Vector3(pos.x , pos.y , pos.z));
        bullet.transform.localEulerAngles = rot;
        bullet.transform.parent = m_aliveNetworkBulletParent;
        bullet.gameObject.SetActive(true);

        bullet.TARGET_ID = hostID;
        // 정상 생성 되었는지 확인용

    }

    // 이동 
    public void NetworkBulletMoveRecv(string bulletID, Vector3 pos,Vector3 velo,Vector3 rot)
    {
        // 단순 이동로직
        for (int i = 0; i < m_networkAliveBulletList.Count; i++)
        {
            Bullet b = m_networkAliveBulletList[i];

            if (b.NETWORK_ID.Equals(bulletID))
            {
                b.NetworkMoveRecv(pos , velo , rot);
                return;
            }
        }
    }

    // 삭제 요청
    public void NetworkBulletRemoveRequest(string bulletID)
    {
        // 삭제 요청이 들어올 경우 Bullet의 ALIVE 를 False 로 두고 현 리스트에서
        Debug.Log("삭제 요청 " + bulletID);
        int deleteIndex = -1;
        for(int i = 0; i < m_networkAliveBulletList.Count; i ++)
        {
            Bullet b = m_networkAliveBulletList[i];
            if(b.NETWORK_ID.Equals(bulletID))
            {
                b.IS_ALIVE = false;
                deleteIndex = i;
                break;
            }
        }
        // 사망 리스트로 옮김
        if (deleteIndex != -1)
        {
            Bullet b = m_networkAliveBulletList[deleteIndex];
            b.gameObject.SetActive(false);
            m_networkDeadBulletList.Add(b);
            m_networkAliveBulletList.RemoveAt(deleteIndex);
            b.transform.parent = m_deadNetworkBulletParent;
        }

    }

    #endregion

    // 여기 메소드들은 로컬에서 호출하나 네트워크 메시지에 관련되어 있음 (당연히 무기에 관련)
    #region Network Message Request --------------------------------------------------------------------

    // 총알 관련된 메소드 
    #region Bullet Request Message
    // 총알 생성 요청
    public void RequestBulletCreate(WeaponItem weapon ,string bulletID,string weaponID,Vector3 pos, Vector3 rot)
    {
        // 메시지도 보내고 실 생성도 하고 ( 메시지는 자신한테 안옴 )

        // 메시지 보내는 부분
        if (NetworkManager.Instance() != null)
            NetworkManager.Instance().C2SRequestBulletCreate(bulletID , weaponID , pos , rot);

        // 생성하는 부분을 넣읍시다 TODO
        Bullet bullet = null;
        int index = -1;
        //재사용 가능한게 있는지 체크
        for (int i = 0; i < m_myDeadBulletList.Count; i++)
        {
            if (!m_myDeadBulletList[i].WEAPON_ID.Equals(weaponID) || m_myDeadBulletList[i].IS_ALIVE == true)
            {
                continue;
            }
            bullet = m_myDeadBulletList[i];
            index = i;

            if (bullet.AUDIO_SOURCE == null)
                bullet.AUDIO_SOURCE = bullet.gameObject.AddComponent<AudioSource>();
            SoundSetup(bullet , GetWeaponData(bullet.WEAPON_ID));
            break;
        }

        // 재사용 로직
        if (bullet == null)
        {
            GameObject prefab = CreateBullet(weaponID);

            if (prefab == null)
            {
                Debug.Log("ERROR 총알 prefab 이 등록되어있지 않습니다. 확인 요망  Weapon ID " + weaponID + " bullet ID " + bulletID);
                return;
            }
            // 프리팹에서 사용할 Bullet Component 를 꺼냄
            bullet = prefab.GetComponent<Bullet>();
        }
        else
            m_myDeadBulletList.RemoveAt(index);
        var renderer = bullet.BULLET_TRAIL_EFFECT.GetComponentInChildren<TrailRenderer>();
        if (renderer != null)
            renderer.Clear();

        bullet.TARGET_WEAPON = weapon;
        bullet.DAMAGE = m_weaponDict[weaponID].Damage;

        // 부모 바꿈
        bullet.transform.parent = m_myAliveBulletParent;
        bullet.NETWORK_ID = bulletID;
        bullet.IS_REMOTE = false;
        bullet.IS_ALIVE = true;
        m_myAlivebulletList.Add(bullet);

        // 위치 변경
        bullet.transform.position = pos;
        bullet.transform.localEulerAngles = rot;

        bullet.BulletSetup();
        bullet.gameObject.SetActive(true);
    } 

    // 총알 삭제 요청
    public void RequestBulletRemove(Bullet b)
    {
        // 삭제 메시지도 보내고 실 삭제도 하고
        // 메시지 보내는 부분
        if(NetworkManager.Instance() != null)
          NetworkManager.Instance().C2SRequestBulletRemove(b.NETWORK_ID);

        b.IS_ALIVE = false;
        // 실 삭제하는 부분
        m_myAlivebulletList.Remove(b);
        m_myDeadBulletList.Add(b);
        b.transform.parent = m_myDeadBulletParent;
    }

    // 총알 이동 메시지 요청 ( 이친구는 P2P로 이동됨 )
    public void RequestBulletMove(string bulletID,Vector3 pos,Vector3 velo,Vector3 rot)
    {
        NetworkManager.Instance().C2SRequestBulletMove(bulletID , pos , velo , rot);
    }
    #endregion

    #region Network Object Request Message
    /**
     */
    public void NetworkObjectCreate(NetworkObjectType type , 
        string networkID , Vector3 pos , Vector3 rot)
    {
        var obj = CreateNetworkObject(type , pos);

        var network = obj.GetComponent<NetworkObject>();
        network.IS_NETWORK = false;
        network.DIR_ROT = Quaternion.Euler(rot);
        network.NETWORK_ID = networkID;
        network.NetworkEnable();
        m_networkObjectList.Add(networkID , network);

        NetworkManager.Instance().C2SRequestNetworkObjectCreate(networkID , (int)type , pos , rot);
    }

    /**
     * @brief   네트워크 오브젝트 생성 요청 ( 네트워크 )
     * @param   type 생성할 오브젝트 타입
     * @param   networkID 네트워크 식별 아이디 
     * @param   pos 어디에 생성할 것인지에 대한 위치 정보
     * @param   rot 회전값
     */
     public void RequestNetworkObjectCreate(int targetHostID,NetworkObjectType type,string networkID,Vector3 pos,Vector3 rot)
    {
        Debug.Log("Network 생성! " + networkID);
        var obj = CreateNetworkObject(type,pos);

        obj.transform.localEulerAngles = rot;

        var network = obj.GetComponent<NetworkObject>();
        network.CREATE_HOST_ID = targetHostID;
        network.IS_NETWORK = true;
        network.DIR_ROT = Quaternion.Euler(rot);
        network.IS_NETWORK_MOVING = true;
        network.NETWORK_ID = networkID;
        network.NetworkEnable();
        m_networkObjectList.Add(networkID , network);
    }

    /**
     * @brief   네트워크 오브젝트 삭제 요청
     * @param   삭제 요청할 networkID
     */
    public void RequestNetworkObjectRemove(string networkID)
    {
        if (IsNetworkObject(networkID) == false)
            return;
        var obj = m_networkObjectList[networkID];

        GameObject.Destroy(obj.gameObject);
        m_networkObjectList.Remove(networkID);

        NetworkManager.Instance().C2sRequestNetworkObjectDelete(networkID);
    }

    /**
     * @brief   네트워크 오브젝트의 속도 동기화를 위한 이동 정보 전송
     * @param   networkID 네트워크 식별 아이디
     * @param   pos 현재 좌표
     * @param   velo 속도
     * @param   rot 현재 회전 정보
     */
     public void RequestNetworkObjectMove(string networkID,Vector3 pos,Vector3 velo, Vector3 rot)
    {
        if (IsNetworkObject(networkID) == false)
            return;
        m_networkObjectList[networkID].NetworkMoveRecv(pos , velo , rot);
    }
 
    #endregion

    #endregion

    #region Util Method -------------------------------------------------------------------------------------------------

    // 랜덤으로 무기 ID 뽑기
    public string GetRandomWeaponID()
    {
        return m_weaponTable.dataArray[Random.Range(0 , m_weaponTable.dataArray.Length)].Id;
    }

    // 총알 만들기
    public GameObject CreateBullet(string weaponID,bool isME = true)
    {
        WeaponTableData data = GetWeaponData(weaponID);
        if (string.IsNullOrEmpty(data.Bulletpath))
        {
            Debug.Log("ERROR Bullet Path 가 제대로 들어가있지 않음");
            return null;
        }
        
        GameObject bullet = new GameObject("Bullet");
        bullet.tag = "Bullet";
        // 총알 생성 후 bullet 밑에 자식으로 붙임
        GameObject trail = (GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Bulletpath)) as GameObject);
        trail.transform.parent = bullet.transform;
        trail.SetActive(true);

        #region Bullet Hit Effect 
        // 이것들은 필요시 활성화 됨
        // 없을 수 있으니 먼저 체크
        GameObject hit = null;
        GameObject otherHit = null;
        if (string.IsNullOrEmpty(data.Basehiteffect) == false)
            hit = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Basehiteffect)) as GameObject;
        if(string.IsNullOrEmpty(data.Otherhiteffect) == false)
            otherHit = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Otherhiteffect)) as GameObject;

        if (hit != null)
        {
            hit.SetActive(false);
            hit.transform.parent = bullet.transform;
        }
        if (otherHit != null)
        {
            otherHit.SetActive(false);
            otherHit.transform.parent = bullet.transform;
        }

     
        #endregion

        #region Bullet Collider Attach
        SphereCollider col = bullet.AddComponent<SphereCollider>();
        col.isTrigger = true;
        col.radius = data.Bulletcolliderradius;
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.isKinematic = true;

        #endregion
        // 타입 비교 후 스크립트 넣기
        switch ((WeaponType)data.Type)
        {
            case WeaponType.GUN:
            case WeaponType.RIFLE:
                {
                    // 기본 총기들은 비슷함
                    Bullet b = bullet.AddComponent<Bullet>();
                    b.SPEED = data.Bulletspeed;
                    b.BULLET_HIT_EFFECT = hit;
                    b.BULLET_OTHER_HIT_EFFECT = otherHit;
                    b.BULLET_TRAIL_EFFECT = trail;
                    b.WEAPON_ID = weaponID;
                }
                break;
            case WeaponType.ROCKET_LAUNCHER:
                {
                    RocketBullet r = bullet.AddComponent<RocketBullet>();
                    r.SPEED = data.Bulletspeed;
                    r.BULLET_HIT_EFFECT = hit;
                    r.BULLET_OTHER_HIT_EFFECT = otherHit;
                    r.BULLET_TRAIL_EFFECT = trail;
                    r.GRAVITY_POWER = data.Launchergravity;
                    r.WEAPON_ID = weaponID;

                    //if(isME)
                    {
                        WeaponItem item = GameManager.Instance().PLAYER.m_player.CURRENT_WEAPON;
                        // 폭발 콜라이더 넣기 // 자기 자신도 휘말림(임시)
                        if (r.BULLET_HIT_EFFECT != null)
                        {
                            col = r.BULLET_HIT_EFFECT.AddComponent<SphereCollider>();
                            col.isTrigger = true;
                            col.radius = data.Boomeffectcolliderradius;
                            col.center = new Vector3(data.Boomeffectcollidercenter_x ,
                                data.Boomeffectcollidercenter_y ,
                                data.Boomeffectcollidercenter_z);
                            var explosion = r.BULLET_HIT_EFFECT.AddComponent<RocketBulletExplosion>();
                            explosion.tag = "Bullet_Explosion";
                        }
                        
                        if(r.BULLET_OTHER_HIT_EFFECT != null)
                        {
                            col = r.BULLET_OTHER_HIT_EFFECT.AddComponent<SphereCollider>();
                            col.radius = data.Boomeffectcolliderradius;
                            var explosion = r.BULLET_HIT_EFFECT.AddComponent<RocketBulletExplosion>();
                            explosion.tag = "Bullet_Explosion";
                        }
                        
                        col.isTrigger = true;
                    }
                    
                }
                break;
            case WeaponType.SWORD:
                break;
        }

        // TODO
        // 이부분에서 사운드 지정
        //사운드
        Bullet bb = bullet.GetComponent<Bullet>();
        if(bb.AUDIO_SOURCE == null)
            bb.AUDIO_SOURCE = bullet.AddComponent<AudioSource>();
        SoundSetup(bb , data);

        //
        var destroy = bullet.transform.GetComponentInChildren<Bullet_DestroyTime>();
        if (destroy != null)
            destroy.TARGET_BULLET = bullet.GetComponentInChildren<Bullet>();
        else
            Debug.LogError("Bullet DestryTime is null");
        return bullet;
    }

    void SoundSetup(Bullet bb, WeaponTableData data)
    {
      
        bb.AUDIO_SOURCE.playOnAwake = false;
        bb.AUDIO_SOURCE.loop = false;
        bb.AUDIO_SOURCE.spatialBlend = 1.0f;
        bb.AUDIO_SOURCE.rolloffMode = AudioRolloffMode.Linear;
        bb.AUDIO_SOURCE.minDistance = 1.0f;
        bb.AUDIO_SOURCE.maxDistance = 70.0f;
        if (bb.HIT_MAIN != null)
            return;
        if (!string.IsNullOrEmpty(data.Otherhitsound))
        {
            string[] temp = data.Otherhitsound.Split(',');
            if (!IsSound(data.Hitsound))
            {
                bb.HIT_MAIN = Resources.Load("Sound/Weapons/" + data.Hitsound) as AudioClip;
                m_bulletSoundList.Add(data.Hitsound , bb.HIT_MAIN);
            }
            else
            {
                bb.HIT_MAIN = m_bulletSoundList[data.Hitsound];
            }

            if (!IsSound(temp[0]))
            {
                bb.HIT_LAND = Resources.Load("Sound/Weapons/" + temp[0]) as AudioClip;
                m_bulletSoundList.Add(temp[0] , bb.HIT_LAND);
            }
            else
            {
                bb.HIT_LAND = m_bulletSoundList[temp[0]];
            }
            if (!IsSound(temp[1]))
            {
                bb.HIT_SPACESHIP = Resources.Load("Sound/Weapons/" + temp[1]) as AudioClip;
                m_bulletSoundList.Add(temp[1] , bb.HIT_SPACESHIP);
            }
            else
            {
                bb.HIT_SPACESHIP = m_bulletSoundList[temp[1]];
            }
            if (!IsSound(temp[2]))
            {
                bb.HIT_SHELTER = Resources.Load("Sound/Weapons/" + temp[2]) as AudioClip;
                m_bulletSoundList.Add(temp[2] , bb.HIT_SHELTER);
            }
            else
            {
                bb.HIT_SHELTER = m_bulletSoundList[temp[2]];
            }
        }
    }

    // 무기 만들기
    public GameObject CreateWeapon(string id)
    {
        WeaponTableData data = GetWeaponData(id);
        GameObject weapon = GameObject.Instantiate(Resources.Load("Art/Resource/Item/Weapon/" + data.Prefabpath)) as GameObject;
        
        // 힐팩
        if(data.Type == 5)
        {
            HealPackItem heal = weapon.AddComponent<HealPackItem>();
            heal.Setup(id);
            return weapon;            
        }

        // 공통구간
        WeaponItem item = null;
        switch ((WeaponType)data.Type)
        {
            case WeaponType.GUN:
            case WeaponType.RIFLE:
            case WeaponType.ROCKET_LAUNCHER:
            case WeaponType.SWORD:
                item = weapon.AddComponent<WeaponItem>();
                break;
            case WeaponType.GRENADE:
                item = weapon.AddComponent<Grenade>();
                break;
        }

        // 아이디 등록
        item.ITEM_ID = id;
        // 무게 등록
        item.ITEM_WEIGHT = data.Weight;
        // 이름 등록 
        item.ITEM_NAME = data.Name_kr;
        //데미지
        item.DAMAGE = data.Damage;
        // 장착 포지션
        item.LOCAL_SET_POS = new Vector3(data.Equippos_x , data.Equippos_y , data.Equippos_z);
        // 장착 회전
        item.LOCAL_SET_ROT = new Vector3(data.Equiprot_x , data.Equiprot_y , data.Equiprot_z);
        // 장착 스케일
        item.LOCAL_SET_SCALE = new Vector3(data.Equipscale_x , data.Equipscale_y , data.Equipscale_z);
        // 스폰 각도
        item.SPONE_ROTATITON = new Vector3(data.Sponerot_x , data.Sponerot_y , data.Sponerot_z);
        // 쿨타임
        item.COOL_TIME = data.Cooltime;
        // 어택 타이밍
        item.ATTACK_TIMING = (WeaponItem.AttackTiming)data.Attacktiming;
        // 콜라이더 삽입
        SphereCollider col = weapon.AddComponent<SphereCollider>();
        col.isTrigger = true;
        col.radius = data.Weapongetcolliderradius;

        if((WeaponType)data.Type == WeaponType.GUN || (WeaponType)data.Type == WeaponType.RIFLE || (WeaponType)data.Type == WeaponType.ROCKET_LAUNCHER)
        {
            // AMMO
            item.AMMO = data.Bulletcount;
            // 파이어 포인트 삽입
            GameObject firePoint = new GameObject("firePoint");
            firePoint.transform.position = new Vector3(data.Firepoint_x , data.Firepoint_y , data.Firepoint_z);
            firePoint.transform.SetParent(weapon.transform , true);
            item.FIRE_POS = firePoint.transform;
            #region Shot Effect Create
            GameObject shotEffect = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Shoteffectpath)) as GameObject;
            shotEffect.transform.parent = weapon.transform;
            shotEffect.gameObject.SetActive(false);
            item.SHOT_EFFECT = shotEffect;
            #endregion
        }
        else if((WeaponType)data.Type == WeaponType.GRENADE)
        {
            #region Grenade Setup

            Grenade grenade = item as Grenade;

            // 수류탄의 실제 콜라이더
            SphereCollider grenadeCollider = weapon.AddComponent<SphereCollider>();
            grenadeCollider.isTrigger = true;
            grenadeCollider.radius = data.Bulletcolliderradius;
            grenadeCollider.enabled = false;

            GameObject baseHit = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Basehiteffect)) as GameObject;
            baseHit.transform.parent = item.transform;
            baseHit.SetActive(false);
            GrenadeExplosion exp = baseHit.AddComponent<GrenadeExplosion>();
            exp.TARGET_GRENADE = grenade;
            
            SphereCollider hitCol = baseHit.AddComponent<SphereCollider>();
            hitCol.isTrigger = true;
            hitCol.enabled = false;
            hitCol.radius = data.Boomeffectcolliderradius;

            GameObject otherHit = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Otherhiteffect)) as GameObject;
            otherHit.transform.parent = item.transform;
            exp = otherHit.AddComponent<GrenadeExplosion>();
            exp.TARGET_GRENADE = grenade;
            otherHit.SetActive(false);

            hitCol = otherHit.AddComponent<SphereCollider>();
            hitCol.isTrigger = true;
            hitCol.enabled = false;
            hitCol.radius = data.Boomeffectcolliderradius;

            grenade.GRAVITY_POWER = data.Launchergravity;
            grenade.GRENADE_SPEED = data.Bulletspeed;
            grenade.GRENADE_BASE_HIT = baseHit;
            grenade.GRENADE_OTHER_HIT = otherHit;
            #endregion
        }

        weapon.tag = "Weapon";
      
        
        switch ((WeaponType)data.Type)
        {
            case WeaponType.GUN:             item.ITEM_TYPE = Item.ItemType.GUN;   break;
            case WeaponType.RIFLE:           item.ITEM_TYPE = Item.ItemType.RIFLE;  break;
            case WeaponType.ROCKET_LAUNCHER: item.ITEM_TYPE = Item.ItemType.ROCKETLAUNCHER; break;
            case WeaponType.SWORD:
                {
                    #region Sword Setup
                    item.ITEM_TYPE = Item.ItemType.MELEE;
                    BoxCollider boxCol = weapon.AddComponent<BoxCollider>();
                    boxCol.isTrigger = true;
                    boxCol.center = new Vector3(data.Swordcollider_center_x , data.Swordcollider_center_y , data.Swordcollider_center_z);
                    boxCol.size = new Vector3(data.Swordcollider_x , data.Swordcollider_y , data.Swordcollider_z);

                    string[] check = data.Shoteffectpath.Split(',');

                    if (check.Length > 1)
                    {
                        for(int i = 0; i < check.Length; i++)
                        {
                            GameObject shotEffect = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + check[0])) as GameObject;
                            shotEffect.transform.parent = item.transform;
                            item.SWORD_ANIMATOR_LIST.Add(shotEffect.GetComponent<Animator>());
                            shotEffect.SetActive(false);

                            // plane 에 넣어야함 // shotEffect - AllPosition - Rotation - plane
                            Transform plane = shotEffect.transform.GetChild(0).GetChild(1).GetChild(0);

                            BoxCollider hitCol = plane.gameObject.AddComponent<BoxCollider>();
                            hitCol.isTrigger = true;
                            hitCol.center = new Vector3(data.Swordcollider_center_x , data.Swordcollider_center_y , data.Swordcollider_center_z);
                            hitCol.size = new Vector3(data.Swordcollider_x , data.Swordcollider_y , data.Swordcollider_z);

                            SwordCollider sc = plane.gameObject.AddComponent<SwordCollider>();
                            sc.TARGET_SWORD = item;
                            sc.BASE_HIT_EFFECT = data.Basehiteffect;
                            sc.OTHER_HIT_EFFECT = data.Otherhiteffect;
                        }
                    }
                    else
                    {
                        GameObject shotEffect = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Shoteffectpath)) as GameObject;
                        shotEffect.transform.parent = item.transform;
                        item.SWORD_ANIMATOR_LIST.Add(shotEffect.GetComponent<Animator>());
                        shotEffect.SetActive(false);

                        // plane 에 넣어야함 // shotEffect - AllPosition - Rotation - plane
                        Transform plane = shotEffect.transform.GetChild(0).GetChild(1).GetChild(0);

                        BoxCollider hitCol = plane.gameObject.AddComponent<BoxCollider>();
                        hitCol.isTrigger = true;
                        hitCol.center = new Vector3(data.Swordcollider_center_x , data.Swordcollider_center_y , data.Swordcollider_center_z);
                        hitCol.size = new Vector3(data.Swordcollider_x , data.Swordcollider_y , data.Swordcollider_z);

                        SwordCollider sc = plane.gameObject.AddComponent<SwordCollider>();
                        sc.TARGET_SWORD = item;
                        sc.BASE_HIT_EFFECT = data.Basehiteffect;
                        sc.OTHER_HIT_EFFECT = data.Otherhiteffect;
                    }

                    

                    #endregion

                }
                break;
            case WeaponType.GRENADE:        item.ITEM_TYPE = Item.ItemType.ETC_GRENADE; break;
        }

        WeaponItem w = item.GetComponent<WeaponItem>();

        w.AUDIO_SOURCE = w.gameObject.AddComponent<AudioSource>();
        w.AUDIO_SOURCE.playOnAwake = false;
        w.AUDIO_SOURCE.loop = false;
        w.AUDIO_SOURCE.spatialBlend = 1.0f;
        if ((WeaponType)data.Type == WeaponType.GRENADE)
        {
            w.AUDIO_SOURCE.rolloffMode = AudioRolloffMode.Linear;
            w.AUDIO_SOURCE.minDistance = 1.0f;
            w.AUDIO_SOURCE.maxDistance = 70.0f;
        }
        else
        {
            w.AUDIO_SOURCE.rolloffMode = AudioRolloffMode.Logarithmic;
            w.AUDIO_SOURCE.minDistance = 1.0f;
            w.AUDIO_SOURCE.maxDistance = 10.0f;
        }

        if(!IsSound(data.Usesound))
        {
            Object o = Resources.Load("Sound/Weapons/" + data.Usesound);

            Debug.Log("NULL + " + (o == null) + " Sound/Weapons/" + data.Usesound + ".wav");
            w.SHOT_SOUND = o as AudioClip;
            m_bulletSoundList.Add(data.Usesound , w.SHOT_SOUND);
        }
        else
        {
            w.SHOT_SOUND = m_bulletSoundList[data.Usesound];
        }

        if (!IsSound(data.Hitsound) && (WeaponType)data.Type == WeaponType.GRENADE)
        {
         
            var o = Resources.Load("Sound/Weapons/" + data.Hitsound);
           
            (w as Grenade).HIT_SOUND = o as AudioClip;
            m_bulletSoundList.Add(data.Hitsound , (w as Grenade).HIT_SOUND);
        }
        else if ((WeaponType)data.Type == WeaponType.GRENADE)
        {
            (w as Grenade).HIT_SOUND = m_bulletSoundList[data.Hitsound];
        }


        return weapon;
    }

    /**
     * @brief   네트워크 연동을 해야하는 오브젝트를 만든다.
     * @
     */
    GameObject CreateNetworkObject(NetworkObjectType type,Vector3 pos)
    {
        GameObject obj = null;
        string id = null;
        NetworkObjectTableData data = null;

        switch (type)
        {
            case NetworkObjectType.SATELLITE: id = "Sattllite";  break;
            default:
                break;
        }
        data = GetNetworkObjectTableData(id);

        if (data == null)
            return null;

        obj = GameObject.Instantiate(Resources.Load("Art/Resource/Effect/" + data.Prefabpath)) as GameObject;
        obj.transform.parent = m_networkObjectParent;
        obj.transform.position = pos;

        return obj;
    }
    /**
    * @brief   네트워크 오브젝트가 리스트 안에 있는지 검사
    * @param   검사할 네트워크 오브젝트
    * @return  true 시 리스트 내에 있음
    */
    public bool IsNetworkObject(string id)
    {
        return m_networkObjectList.ContainsKey(id);
    }

    /**
     * @brief   옵저버 카메라를 등록한다. 
     */
    public void AddObserverCamera(int hostID,NetworkObject obj)
    {
        obj.NETWORK_ID = "CAMERA_" + hostID;
        obj.OBJ_TYPE = NetworkObjectType.CAMERA_OBSERVER;
        obj.IS_NETWORK = false;
        obj.NetworkEnable();
        m_networkObjectList.Add(obj.NETWORK_ID , obj);
    }

    /**
     */
     public void ChangeObserverCamera(int targetID,NetworkObject camera)
    {
        string prevID = camera.NETWORK_ID;
        camera.NETWORK_ID = "CAMERA_" + targetID;
        camera.IS_NETWORK = true;
        m_networkObjectList.Remove(prevID);
        m_networkObjectList.Add(camera.NETWORK_ID , camera);
    }
    #endregion
}
