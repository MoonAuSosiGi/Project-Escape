﻿




// Generated by PIDL compiler.
// Do not modify this file, but modify the source .pidl file.

using System;
using System.Net;

            
using Nettention.Proud; 
namespace SpaceWar
{
	internal class Proxy:Nettention.Proud.RmiProxy
	{
public bool RequestServerConnect(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, string id)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.RequestServerConnect;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, id);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_RequestServerConnect, Common.RequestServerConnect);
}

public bool RequestServerConnect(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, string id)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.RequestServerConnect;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, id);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_RequestServerConnect, Common.RequestServerConnect);
}
public bool RequestClientJoin(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, string name, float x, float y, float z)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.RequestClientJoin;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, x);
		SP_Marshaler.Write(__msg, y);
		SP_Marshaler.Write(__msg, z);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_RequestClientJoin, Common.RequestClientJoin);
}

public bool RequestClientJoin(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, string name, float x, float y, float z)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.RequestClientJoin;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, x);
SP_Marshaler.Write(__msg, y);
SP_Marshaler.Write(__msg, z);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_RequestClientJoin, Common.RequestClientJoin);
}
public bool RequestWorldCreateItem(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.RequestWorldCreateItem;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, itemCID);
		SP_Marshaler.Write(__msg, itemID);
		SP_Marshaler.Write(__msg, pos);
		SP_Marshaler.Write(__msg, rot);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_RequestWorldCreateItem, Common.RequestWorldCreateItem);
}

public bool RequestWorldCreateItem(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.RequestWorldCreateItem;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, itemCID);
SP_Marshaler.Write(__msg, itemID);
SP_Marshaler.Write(__msg, pos);
SP_Marshaler.Write(__msg, rot);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_RequestWorldCreateItem, Common.RequestWorldCreateItem);
}
public bool RequestPlayerDamage(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, int targetHostID, string name, string weaponName, float damage)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.RequestPlayerDamage;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, targetHostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, weaponName);
		SP_Marshaler.Write(__msg, damage);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_RequestPlayerDamage, Common.RequestPlayerDamage);
}

public bool RequestPlayerDamage(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, int targetHostID, string name, string weaponName, float damage)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.RequestPlayerDamage;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, targetHostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, weaponName);
SP_Marshaler.Write(__msg, damage);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_RequestPlayerDamage, Common.RequestPlayerDamage);
}
public bool RequestPlayerUseOxy(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, string name, float useOxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.RequestPlayerUseOxy;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, useOxy);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_RequestPlayerUseOxy, Common.RequestPlayerUseOxy);
}

public bool RequestPlayerUseOxy(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, string name, float useOxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.RequestPlayerUseOxy;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, useOxy);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_RequestPlayerUseOxy, Common.RequestPlayerUseOxy);
}
public bool RequestUseOxyCharger(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, int oxyChargerIndex, float userOxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.RequestUseOxyCharger;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, oxyChargerIndex);
		SP_Marshaler.Write(__msg, userOxy);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_RequestUseOxyCharger, Common.RequestUseOxyCharger);
}

public bool RequestUseOxyCharger(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, int oxyChargerIndex, float userOxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.RequestUseOxyCharger;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, oxyChargerIndex);
SP_Marshaler.Write(__msg, userOxy);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_RequestUseOxyCharger, Common.RequestUseOxyCharger);
}
public bool RequestUseItemBox(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, int itemBoxIndex)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.RequestUseItemBox;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, itemBoxIndex);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_RequestUseItemBox, Common.RequestUseItemBox);
}

public bool RequestUseItemBox(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, int itemBoxIndex)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.RequestUseItemBox;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, itemBoxIndex);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_RequestUseItemBox, Common.RequestUseItemBox);
}
public bool NotifyLoginSuccess(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyLoginSuccess;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyLoginSuccess, Common.NotifyLoginSuccess);
}

public bool NotifyLoginSuccess(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyLoginSuccess;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyLoginSuccess, Common.NotifyLoginSuccess);
}
public bool NotifyLoginFailed(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, string reason)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyLoginFailed;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, reason);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyLoginFailed, Common.NotifyLoginFailed);
}

public bool NotifyLoginFailed(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, string reason)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyLoginFailed;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, reason);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyLoginFailed, Common.NotifyLoginFailed);
}
public bool NotifyOtherClientJoin(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, string name, float x, float y, float z)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyOtherClientJoin;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, x);
		SP_Marshaler.Write(__msg, y);
		SP_Marshaler.Write(__msg, z);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyOtherClientJoin, Common.NotifyOtherClientJoin);
}

public bool NotifyOtherClientJoin(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, string name, float x, float y, float z)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyOtherClientJoin;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, x);
SP_Marshaler.Write(__msg, y);
SP_Marshaler.Write(__msg, z);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyOtherClientJoin, Common.NotifyOtherClientJoin);
}
public bool NotifyPlayerLost(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerLost;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerLost, Common.NotifyPlayerLost);
}

public bool NotifyPlayerLost(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerLost;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerLost, Common.NotifyPlayerLost);
}
public bool NotifyPlayerMove(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, string name, float curX, float curY, float curZ, float velocityX, float velocityY, float velocityZ, float crx, float cry, float crz, float rx, float ry, float rz)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerMove;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, curX);
		SP_Marshaler.Write(__msg, curY);
		SP_Marshaler.Write(__msg, curZ);
		SP_Marshaler.Write(__msg, velocityX);
		SP_Marshaler.Write(__msg, velocityY);
		SP_Marshaler.Write(__msg, velocityZ);
		SP_Marshaler.Write(__msg, crx);
		SP_Marshaler.Write(__msg, cry);
		SP_Marshaler.Write(__msg, crz);
		SP_Marshaler.Write(__msg, rx);
		SP_Marshaler.Write(__msg, ry);
		SP_Marshaler.Write(__msg, rz);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerMove, Common.NotifyPlayerMove);
}

public bool NotifyPlayerMove(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, string name, float curX, float curY, float curZ, float velocityX, float velocityY, float velocityZ, float crx, float cry, float crz, float rx, float ry, float rz)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerMove;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, curX);
SP_Marshaler.Write(__msg, curY);
SP_Marshaler.Write(__msg, curZ);
SP_Marshaler.Write(__msg, velocityX);
SP_Marshaler.Write(__msg, velocityY);
SP_Marshaler.Write(__msg, velocityZ);
SP_Marshaler.Write(__msg, crx);
SP_Marshaler.Write(__msg, cry);
SP_Marshaler.Write(__msg, crz);
SP_Marshaler.Write(__msg, rx);
SP_Marshaler.Write(__msg, ry);
SP_Marshaler.Write(__msg, rz);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerMove, Common.NotifyPlayerMove);
}
public bool NotifyDeleteItem(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int itemID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyDeleteItem;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, itemID);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyDeleteItem, Common.NotifyDeleteItem);
}

public bool NotifyDeleteItem(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int itemID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyDeleteItem;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, itemID);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyDeleteItem, Common.NotifyDeleteItem);
}
public bool NotifyCreateItem(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyCreateItem;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, itemCID);
		SP_Marshaler.Write(__msg, itemID);
		SP_Marshaler.Write(__msg, pos);
		SP_Marshaler.Write(__msg, rot);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyCreateItem, Common.NotifyCreateItem);
}

public bool NotifyCreateItem(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyCreateItem;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, itemCID);
SP_Marshaler.Write(__msg, itemID);
SP_Marshaler.Write(__msg, pos);
SP_Marshaler.Write(__msg, rot);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyCreateItem, Common.NotifyCreateItem);
}
public bool NotifyStartOxyChargerState(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int oxyChargerID, float oxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyStartOxyChargerState;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, oxyChargerID);
		SP_Marshaler.Write(__msg, oxy);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyStartOxyChargerState, Common.NotifyStartOxyChargerState);
}

public bool NotifyStartOxyChargerState(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int oxyChargerID, float oxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyStartOxyChargerState;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, oxyChargerID);
SP_Marshaler.Write(__msg, oxy);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyStartOxyChargerState, Common.NotifyStartOxyChargerState);
}
public bool NotifyStartItemBoxState(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int itemBoxID, bool openState)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyStartItemBoxState;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, itemBoxID);
		SP_Marshaler.Write(__msg, openState);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyStartItemBoxState, Common.NotifyStartItemBoxState);
}

public bool NotifyStartItemBoxState(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int itemBoxID, bool openState)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyStartItemBoxState;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, itemBoxID);
SP_Marshaler.Write(__msg, openState);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyStartItemBoxState, Common.NotifyStartItemBoxState);
}
public bool NotifyPlayerEquipItem(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerEquipItem;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, itemCID);
		SP_Marshaler.Write(__msg, itemID);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerEquipItem, Common.NotifyPlayerEquipItem);
}

public bool NotifyPlayerEquipItem(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerEquipItem;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, itemCID);
SP_Marshaler.Write(__msg, itemID);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerEquipItem, Common.NotifyPlayerEquipItem);
}
public bool NotifyPlayerUnEquipItem(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerUnEquipItem;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, itemCID);
		SP_Marshaler.Write(__msg, itemID);
		SP_Marshaler.Write(__msg, pos);
		SP_Marshaler.Write(__msg, rot);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerUnEquipItem, Common.NotifyPlayerUnEquipItem);
}

public bool NotifyPlayerUnEquipItem(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, int itemCID, int itemID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerUnEquipItem;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, itemCID);
SP_Marshaler.Write(__msg, itemID);
SP_Marshaler.Write(__msg, pos);
SP_Marshaler.Write(__msg, rot);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerUnEquipItem, Common.NotifyPlayerUnEquipItem);
}
public bool NotifyPlayerBulletCreate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, string bulletType, string bulletID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerBulletCreate;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, bulletType);
		SP_Marshaler.Write(__msg, bulletID);
		SP_Marshaler.Write(__msg, pos);
		SP_Marshaler.Write(__msg, rot);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerBulletCreate, Common.NotifyPlayerBulletCreate);
}

public bool NotifyPlayerBulletCreate(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, string bulletType, string bulletID, UnityEngine.Vector3 pos, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerBulletCreate;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, bulletType);
SP_Marshaler.Write(__msg, bulletID);
SP_Marshaler.Write(__msg, pos);
SP_Marshaler.Write(__msg, rot);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerBulletCreate, Common.NotifyPlayerBulletCreate);
}
public bool NotifyPlayerBulletMove(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, string bulletID, UnityEngine.Vector3 pos, UnityEngine.Vector3 velocity, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerBulletMove;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, bulletID);
		SP_Marshaler.Write(__msg, pos);
		SP_Marshaler.Write(__msg, velocity);
		SP_Marshaler.Write(__msg, rot);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerBulletMove, Common.NotifyPlayerBulletMove);
}

public bool NotifyPlayerBulletMove(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, string bulletID, UnityEngine.Vector3 pos, UnityEngine.Vector3 velocity, UnityEngine.Vector3 rot)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerBulletMove;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, bulletID);
SP_Marshaler.Write(__msg, pos);
SP_Marshaler.Write(__msg, velocity);
SP_Marshaler.Write(__msg, rot);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerBulletMove, Common.NotifyPlayerBulletMove);
}
public bool NotifyPlayerBulletDelete(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, string bulletID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerBulletDelete;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, bulletID);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerBulletDelete, Common.NotifyPlayerBulletDelete);
}

public bool NotifyPlayerBulletDelete(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, string bulletID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerBulletDelete;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, bulletID);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerBulletDelete, Common.NotifyPlayerBulletDelete);
}
public bool NotifyPlayerAnimation(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int hostID, string name, string animationName, int aniValue)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerAnimation;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, hostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, animationName);
		SP_Marshaler.Write(__msg, aniValue);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerAnimation, Common.NotifyPlayerAnimation);
}

public bool NotifyPlayerAnimation(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int hostID, string name, string animationName, int aniValue)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerAnimation;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, hostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, animationName);
SP_Marshaler.Write(__msg, aniValue);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerAnimation, Common.NotifyPlayerAnimation);
}
public bool NotifyPlayerChangeHP(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, string name, float hp, float prevhp, float maxhp)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerChangeHP;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, hp);
		SP_Marshaler.Write(__msg, prevhp);
		SP_Marshaler.Write(__msg, maxhp);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerChangeHP, Common.NotifyPlayerChangeHP);
}

public bool NotifyPlayerChangeHP(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, string name, float hp, float prevhp, float maxhp)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerChangeHP;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, hp);
SP_Marshaler.Write(__msg, prevhp);
SP_Marshaler.Write(__msg, maxhp);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerChangeHP, Common.NotifyPlayerChangeHP);
}
public bool NotifyPlayerChangeOxygen(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, string name, float oxygen, float prevoxy, float maxoxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyPlayerChangeOxygen;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, name);
		SP_Marshaler.Write(__msg, oxygen);
		SP_Marshaler.Write(__msg, prevoxy);
		SP_Marshaler.Write(__msg, maxoxy);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyPlayerChangeOxygen, Common.NotifyPlayerChangeOxygen);
}

public bool NotifyPlayerChangeOxygen(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, string name, float oxygen, float prevoxy, float maxoxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyPlayerChangeOxygen;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, name);
SP_Marshaler.Write(__msg, oxygen);
SP_Marshaler.Write(__msg, prevoxy);
SP_Marshaler.Write(__msg, maxoxy);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyPlayerChangeOxygen, Common.NotifyPlayerChangeOxygen);
}
public bool NotifyUseOxyCharger(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, int oxyChargerIndex, float userOxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyUseOxyCharger;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, oxyChargerIndex);
		SP_Marshaler.Write(__msg, userOxy);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyUseOxyCharger, Common.NotifyUseOxyCharger);
}

public bool NotifyUseOxyCharger(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, int oxyChargerIndex, float userOxy)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyUseOxyCharger;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, oxyChargerIndex);
SP_Marshaler.Write(__msg, userOxy);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyUseOxyCharger, Common.NotifyUseOxyCharger);
}
public bool NotifyUseItemBox(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int sendHostID, int itemBoxIndex, int itemID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.NotifyUseItemBox;
		__msg.Write(__msgid);
		SP_Marshaler.Write(__msg, sendHostID);
		SP_Marshaler.Write(__msg, itemBoxIndex);
		SP_Marshaler.Write(__msg, itemID);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_NotifyUseItemBox, Common.NotifyUseItemBox);
}

public bool NotifyUseItemBox(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int sendHostID, int itemBoxIndex, int itemID)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.NotifyUseItemBox;
__msg.Write(__msgid);
SP_Marshaler.Write(__msg, sendHostID);
SP_Marshaler.Write(__msg, itemBoxIndex);
SP_Marshaler.Write(__msg, itemID);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_NotifyUseItemBox, Common.NotifyUseItemBox);
}
#if USE_RMI_NAME_STRING
// RMI name declaration.
// It is the unique pointer that indicates RMI name such as RMI profiler.
const string RmiName_RequestServerConnect="RequestServerConnect";
const string RmiName_RequestClientJoin="RequestClientJoin";
const string RmiName_RequestWorldCreateItem="RequestWorldCreateItem";
const string RmiName_RequestPlayerDamage="RequestPlayerDamage";
const string RmiName_RequestPlayerUseOxy="RequestPlayerUseOxy";
const string RmiName_RequestUseOxyCharger="RequestUseOxyCharger";
const string RmiName_RequestUseItemBox="RequestUseItemBox";
const string RmiName_NotifyLoginSuccess="NotifyLoginSuccess";
const string RmiName_NotifyLoginFailed="NotifyLoginFailed";
const string RmiName_NotifyOtherClientJoin="NotifyOtherClientJoin";
const string RmiName_NotifyPlayerLost="NotifyPlayerLost";
const string RmiName_NotifyPlayerMove="NotifyPlayerMove";
const string RmiName_NotifyDeleteItem="NotifyDeleteItem";
const string RmiName_NotifyCreateItem="NotifyCreateItem";
const string RmiName_NotifyStartOxyChargerState="NotifyStartOxyChargerState";
const string RmiName_NotifyStartItemBoxState="NotifyStartItemBoxState";
const string RmiName_NotifyPlayerEquipItem="NotifyPlayerEquipItem";
const string RmiName_NotifyPlayerUnEquipItem="NotifyPlayerUnEquipItem";
const string RmiName_NotifyPlayerBulletCreate="NotifyPlayerBulletCreate";
const string RmiName_NotifyPlayerBulletMove="NotifyPlayerBulletMove";
const string RmiName_NotifyPlayerBulletDelete="NotifyPlayerBulletDelete";
const string RmiName_NotifyPlayerAnimation="NotifyPlayerAnimation";
const string RmiName_NotifyPlayerChangeHP="NotifyPlayerChangeHP";
const string RmiName_NotifyPlayerChangeOxygen="NotifyPlayerChangeOxygen";
const string RmiName_NotifyUseOxyCharger="NotifyUseOxyCharger";
const string RmiName_NotifyUseItemBox="NotifyUseItemBox";
       
const string RmiName_First = RmiName_RequestServerConnect;
#else
// RMI name declaration.
// It is the unique pointer that indicates RMI name such as RMI profiler.
const string RmiName_RequestServerConnect="";
const string RmiName_RequestClientJoin="";
const string RmiName_RequestWorldCreateItem="";
const string RmiName_RequestPlayerDamage="";
const string RmiName_RequestPlayerUseOxy="";
const string RmiName_RequestUseOxyCharger="";
const string RmiName_RequestUseItemBox="";
const string RmiName_NotifyLoginSuccess="";
const string RmiName_NotifyLoginFailed="";
const string RmiName_NotifyOtherClientJoin="";
const string RmiName_NotifyPlayerLost="";
const string RmiName_NotifyPlayerMove="";
const string RmiName_NotifyDeleteItem="";
const string RmiName_NotifyCreateItem="";
const string RmiName_NotifyStartOxyChargerState="";
const string RmiName_NotifyStartItemBoxState="";
const string RmiName_NotifyPlayerEquipItem="";
const string RmiName_NotifyPlayerUnEquipItem="";
const string RmiName_NotifyPlayerBulletCreate="";
const string RmiName_NotifyPlayerBulletMove="";
const string RmiName_NotifyPlayerBulletDelete="";
const string RmiName_NotifyPlayerAnimation="";
const string RmiName_NotifyPlayerChangeHP="";
const string RmiName_NotifyPlayerChangeOxygen="";
const string RmiName_NotifyUseOxyCharger="";
const string RmiName_NotifyUseItemBox="";
       
const string RmiName_First = "";
#endif
		public override Nettention.Proud.RmiID[] GetRmiIDList() { return Common.RmiIDList; } 
	}
}

