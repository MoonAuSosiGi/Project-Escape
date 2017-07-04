﻿



  
// Generated by PIDL compiler.
// Do not modify this file, but modify the source .pidl file.

#pragma once


#include "SpaceWar_common.h"

namespace SpaceWar
{
	class Proxy : public ::Proud::IRmiProxy
	{
	public:
	virtual bool RequestServerConnect ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const string & id) PN_SEALED; 
	virtual bool RequestServerConnect ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const string & id)   PN_SEALED;  
	virtual bool RequestClientJoin ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const string & name,  const float & x,  const float & y,  const float & z) PN_SEALED; 
	virtual bool RequestClientJoin ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const string & name,  const float & x,  const float & y,  const float & z)   PN_SEALED;  
	virtual bool RequestWorldCreateItem ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const int & itemCID,  const int & itemID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot) PN_SEALED; 
	virtual bool RequestWorldCreateItem ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const int & itemCID,  const int & itemID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot)   PN_SEALED;  
	virtual bool NotifyLoginSuccess ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID) PN_SEALED; 
	virtual bool NotifyLoginSuccess ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID)   PN_SEALED;  
	virtual bool NotifyLoginFailed ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const string & reason) PN_SEALED; 
	virtual bool NotifyLoginFailed ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const string & reason)   PN_SEALED;  
	virtual bool NotifyOtherClientJoin ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const string & name,  const float & x,  const float & y,  const float & z) PN_SEALED; 
	virtual bool NotifyOtherClientJoin ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const string & name,  const float & x,  const float & y,  const float & z)   PN_SEALED;  
	virtual bool NotifyPlayerLost ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID) PN_SEALED; 
	virtual bool NotifyPlayerLost ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID)   PN_SEALED;  
	virtual bool NotifyPlayerMove ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const string & name,  const float & curX,  const float & curY,  const float & curZ,  const float & velocityX,  const float & velocityY,  const float & velocityZ,  const float & crx,  const float & cry,  const float & crz,  const float & rx,  const float & ry,  const float & rz) PN_SEALED; 
	virtual bool NotifyPlayerMove ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const string & name,  const float & curX,  const float & curY,  const float & curZ,  const float & velocityX,  const float & velocityY,  const float & velocityZ,  const float & crx,  const float & cry,  const float & crz,  const float & rx,  const float & ry,  const float & rz)   PN_SEALED;  
	virtual bool NotifyDeleteItem ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & itemID) PN_SEALED; 
	virtual bool NotifyDeleteItem ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & itemID)   PN_SEALED;  
	virtual bool NotifyCreateItem ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const int & itemCID,  const int & itemID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot) PN_SEALED; 
	virtual bool NotifyCreateItem ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const int & itemCID,  const int & itemID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot)   PN_SEALED;  
	virtual bool NotifyPlayerEquipItem ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const int & itemCID,  const int & itemID) PN_SEALED; 
	virtual bool NotifyPlayerEquipItem ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const int & itemCID,  const int & itemID)   PN_SEALED;  
	virtual bool NotifyPlayerUnEquipItem ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const int & itemCID,  const int & itemID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot) PN_SEALED; 
	virtual bool NotifyPlayerUnEquipItem ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const int & itemCID,  const int & itemID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot)   PN_SEALED;  
	virtual bool NotifyPlayerBulletCreate ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & sendHostID,  const string & bulletType,  const string & bulletID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot) PN_SEALED; 
	virtual bool NotifyPlayerBulletCreate ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & sendHostID,  const string & bulletType,  const string & bulletID,  const Proud::Vector3 & pos,  const Proud::Vector3 & rot)   PN_SEALED;  
	virtual bool NotifyPlayerBulletMove ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & sendHostID,  const string & bulletID,  const Proud::Vector3 & pos,  const Proud::Vector3 & velocity,  const Proud::Vector3 & rot) PN_SEALED; 
	virtual bool NotifyPlayerBulletMove ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & sendHostID,  const string & bulletID,  const Proud::Vector3 & pos,  const Proud::Vector3 & velocity,  const Proud::Vector3 & rot)   PN_SEALED;  
	virtual bool NotifyPlayerAnimation ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & hostID,  const string & name,  const string & animationName,  const int & aniValue) PN_SEALED; 
	virtual bool NotifyPlayerAnimation ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & hostID,  const string & name,  const string & animationName,  const int & aniValue)   PN_SEALED;  
	virtual bool NotifyPlayerDamage ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & sendHostID,  const int & recvHostID,  const string & name,  const string & weaponName,  const float & damage) PN_SEALED; 
	virtual bool NotifyPlayerDamage ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & sendHostID,  const int & recvHostID,  const string & name,  const string & weaponName,  const float & damage)   PN_SEALED;  
	virtual bool NotifyPlayerChangeHP ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & sendHostID,  const string & name,  const float & hp) PN_SEALED; 
	virtual bool NotifyPlayerChangeHP ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & sendHostID,  const string & name,  const float & hp)   PN_SEALED;  
	virtual bool NotifyPlayerChangeOxygen ( ::Proud::HostID remote, ::Proud::RmiContext& rmiContext ,  const int & sendHostID,  const string & name,  const float & oxygen) PN_SEALED; 
	virtual bool NotifyPlayerChangeOxygen ( ::Proud::HostID *remotes, int remoteCount, ::Proud::RmiContext &rmiContext,  const int & sendHostID,  const string & name,  const float & oxygen)   PN_SEALED;  
static const PNTCHAR* RmiName_RequestServerConnect;
static const PNTCHAR* RmiName_RequestClientJoin;
static const PNTCHAR* RmiName_RequestWorldCreateItem;
static const PNTCHAR* RmiName_NotifyLoginSuccess;
static const PNTCHAR* RmiName_NotifyLoginFailed;
static const PNTCHAR* RmiName_NotifyOtherClientJoin;
static const PNTCHAR* RmiName_NotifyPlayerLost;
static const PNTCHAR* RmiName_NotifyPlayerMove;
static const PNTCHAR* RmiName_NotifyDeleteItem;
static const PNTCHAR* RmiName_NotifyCreateItem;
static const PNTCHAR* RmiName_NotifyPlayerEquipItem;
static const PNTCHAR* RmiName_NotifyPlayerUnEquipItem;
static const PNTCHAR* RmiName_NotifyPlayerBulletCreate;
static const PNTCHAR* RmiName_NotifyPlayerBulletMove;
static const PNTCHAR* RmiName_NotifyPlayerAnimation;
static const PNTCHAR* RmiName_NotifyPlayerDamage;
static const PNTCHAR* RmiName_NotifyPlayerChangeHP;
static const PNTCHAR* RmiName_NotifyPlayerChangeOxygen;
static const PNTCHAR* RmiName_First;
		Proxy()
		{
			if(m_signature != 1)
				::Proud::ShowUserMisuseError(::Proud::ProxyBadSignatureErrorText);
		}

		virtual ::Proud::RmiID* GetRmiIDList() PN_OVERRIDE { return g_RmiIDList; } 
		virtual int GetRmiIDListCount() PN_OVERRIDE { return g_RmiIDListCount; }
	};
}

