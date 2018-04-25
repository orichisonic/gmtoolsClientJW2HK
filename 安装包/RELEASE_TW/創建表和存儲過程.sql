if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GmTools_Log_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GmTools_Log_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_DepartAdmin_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_DepartAdmin_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_DepartRelateGame_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_DepartRelateGame_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Department_Admin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Department_Admin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Department_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Department_Delete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Department_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Department_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Department_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Department_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GAME_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GAME_Add]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GAME_Del]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GAME_Del]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GAME_Edit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GAME_Edit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GameLink_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GameLink_Add]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GmModule_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GmModule_Delete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GmModule_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GmModule_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GmModule_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GmModule_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GmNotes_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GmNotes_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_GmUserModule_Admin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_GmUserModule_Admin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Gminfo_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Gminfo_Add]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Gminfo_Del]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Gminfo_Del]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Gminfo_Edit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Gminfo_Edit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Gminfo_Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Gminfo_Select]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_PASSWD_Edit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_PASSWD_Edit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_Serverinfo_del]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_Serverinfo_del]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Gmtool_UserInfo_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Gmtool_UserInfo_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_AccountTemp_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_AccountTemp_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Banishment_Close]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Banishment_Close]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Banishment_Open]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Banishment_Open]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Banishment_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Banishment_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Banishment_QueryAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Banishment_QueryAll]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_BoardTask_OwnerQuery]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_BoardTask_OwnerQuery]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_BoardTask_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_BoardTask_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Charinfo_Edit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Charinfo_Edit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Charinfo_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Charinfo_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_EmailPWD_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_EmailPWD_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Friend_NickName_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Friend_NickName_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Friend_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Friend_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_GateWay_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_GateWay_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_GiftBox_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_GiftBox_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_GiftBox_del]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_GiftBox_del]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemData_Down]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemData_Down]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemData_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemData_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemLimit_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemLimit_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemShop_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemShop_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemShop_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemShop_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemShop_QueryG]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemShop_QueryG]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemShop_QueryM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemShop_QueryM]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemShop_Query_ALL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemShop_Query_ALL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_ItemShop_del]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_ItemShop_del]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Login_Clear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Login_Clear]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Login_Status]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Login_Status]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Login_del]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Login_del]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_M_log_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_M_log_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_M_log_QuerySum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_M_log_QuerySum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_MemberDance_Close]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_MemberDance_Close]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_MemberDance_Open]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_MemberDance_Open]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Member_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_Member_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Challenge_Del]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Challenge_Del]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Challenge_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Challenge_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Challenge_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Challenge_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Challenge_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Challenge_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Medalitem_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Medalitem_Delete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Medalitem_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Medalitem_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Medalitem_Own_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Medalitem_Own_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Medalitem_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Medalitem_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Medalitem_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Medalitem_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_MusicData_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_MusicData_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_MusicData_SingleQuery]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_MusicData_SingleQuery]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Scene_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Scene_Delete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Scene_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Scene_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Scene_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Scene_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TO2JAM_Scene_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TO2JAM_Scene_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_T_send_record_QueryRev]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_T_send_record_QueryRev]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_T_send_record_QuerySend]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_T_send_record_QuerySend]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TaskList_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TaskList_Insert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_TaskList_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_TaskList_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserConsume_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserConsume_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserConsume_QuerySum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserConsume_QuerySum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserGcash_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserGcash_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserIntegral_QuerySum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserIntegral_QuerySum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserMcash_AddG]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserMcash_AddG]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserMcash_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserMcash_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserNick_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserNick_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserOnline_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserOnline_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_UserTrade_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SDO_UserTrade_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ServerInfo_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ServerInfo_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ServerInfo_Query_ALL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ServerInfo_Query_ALL]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ServerName_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ServerName_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_Insert_gmtoolslog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_Insert_gmtoolslog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_deleteLinkDown]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_deleteLinkDown]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_linkGameIP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_linkGameIP]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BoardTasker]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BoardTasker]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Department]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Department]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeptRelateGame]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DeptRelateGame]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GAMELIST]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GAMELIST]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_Log]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_Log]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_LogTime]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_LogTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_Log_UpdateAgo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_Log_UpdateAgo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_Modules]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_Modules]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_Roles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_Roles]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_SDO_AccountTemp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_SDO_AccountTemp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_SDO_Message]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_SDO_Message]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_Serverinfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_Serverinfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GMTools_Users]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GMTools_Users]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_BoardMessage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SDO_BoardMessage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SDO_Scene]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SDO_Scene]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[T_o2jam_set_info]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[T_o2jam_set_info]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[T_sdo_item_data]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[T_sdo_item_data]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[T_sdo_item_shop]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[T_sdo_item_shop]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Temp_Text]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Temp_Text]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[remote]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[remote]
GO

CREATE TABLE [dbo].[BoardTasker] (
	[taskid] [int] IDENTITY (1, 1) NOT NULL ,
	[SendBeginTime] [datetime] NULL ,
	[SendEndTime] [datetime] NULL ,
	[Interval] [int] NULL ,
	[command] [int] NULL ,
	[status] [int] NULL ,
	[boardMessage] [varchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Department] (
	[DepartID] [int] IDENTITY (1, 1) NOT NULL ,
	[DepartName] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[Remark] [varchar] (200) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DeptRelateGame] (
	[relateID] [int] IDENTITY (1, 1) NOT NULL ,
	[gameID] [int] NULL ,
	[deptID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GAMELIST] (
	[Game_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Game_Name] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[Game_Content] [varchar] (400) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_Log] (
	[LOG_ID] [bigint] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[SP_Name] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[Game_Name] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[ServerIP] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[Real_Act] [varchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[Act_Time] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_LogTime] (
	[LOG_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[OperateUserID] [int] NOT NULL ,
	[OperateMsg] [varchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[LogTime] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_Log_UpdateAgo] (
	[LOG_ID] [bigint] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[SP_Name] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[ServerIP] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[Real_Act] [varchar] (2800) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[Act_Time] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_Modules] (
	[Module_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Game_ID] [int] NOT NULL ,
	[Module_Name] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[Module_Class] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[Module_Content] [varchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_Roles] (
	[Role_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[Module_ID] [int] NOT NULL ,
	[Game_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_SDO_AccountTemp] (
	[idx] [int] IDENTITY (1, 1) NOT NULL ,
	[GM_UserID] [int] NULL ,
	[USER_ID] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[Reason] [varchar] (800) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[Content] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[Ban_Date] [datetime] NULL ,
	[ServerIP] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_SDO_Message] (
	[Seq] [int] IDENTITY (1, 1) NOT NULL ,
	[ReceiverIndexID] [int] NOT NULL ,
	[SenderNickName] [varchar] (16) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[Title] [varchar] (40) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[Content] [varchar] (400) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[WriteDate] [smalldatetime] NULL ,
	[itemcode] [int] NOT NULL ,
	[timeslimit] [smallint] NULL ,
	[datelimit] [smalldatetime] NULL ,
	[SendReason] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[GM_User] [int] NULL ,
	[ReceiverUserID] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[ReceiverNick] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_Serverinfo] (
	[idx] [int] IDENTITY (1, 1) NOT NULL ,
	[serverip] [varchar] (30) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[city] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[gameID] [int] NOT NULL ,
	[gamename] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[gameflag] [int] NOT NULL ,
	[gamedbID] [int] NOT NULL ,
	[descinfo] [varchar] (200) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[createby] [varchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[createtime] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GMTools_Users] (
	[UserID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserName] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[User_Pwd] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[User_MAC] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[ReaLName] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[DepartID] [int] NOT NULL ,
	[User_status] [int] NOT NULL ,
	[limit] [smalldatetime] NOT NULL ,
	[onlineActive] [int] NOT NULL ,
	[SysAdmin] [tinyint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SDO_BoardMessage] (
	[boardID] [int] IDENTITY (1, 1) NOT NULL ,
	[taskid] [int] NULL ,
	[userID] [int] NULL ,
	[serverIP] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SDO_Scene] (
	[sceneID] [int] NOT NULL ,
	[sceneTag] [varchar] (400) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[T_o2jam_set_info] (
	[SetID] [int] NOT NULL ,
	[SetType] [tinyint] NOT NULL ,
	[SetLevel] [int] NOT NULL ,
	[Part0] [int] NOT NULL ,
	[timeslimit0] [int] NOT NULL ,
	[Part1] [int] NOT NULL ,
	[timeslimit1] [int] NOT NULL ,
	[Part2] [int] NOT NULL ,
	[timeslimit2] [int] NOT NULL ,
	[Part3] [int] NOT NULL ,
	[timeslimit3] [int] NOT NULL ,
	[Part4] [int] NOT NULL ,
	[timeslimit4] [int] NOT NULL ,
	[Part5] [int] NOT NULL ,
	[timeslimit5] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[T_sdo_item_data] (
	[itemcode] [int] NOT NULL ,
	[name] [nvarchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[bigtype] [smallint] NOT NULL ,
	[smalltype] [smallint] NOT NULL ,
	[minlevel] [int] NOT NULL ,
	[description] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[filename] [varchar] (260) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[T_sdo_item_shop] (
	[ProductID] [int] NOT NULL ,
	[itemcode] [int] NOT NULL ,
	[moneytype] [tinyint] NOT NULL ,
	[moneycost] [int] NOT NULL ,
	[descryption] [varchar] (50) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[timeslimit] [int] NOT NULL ,
	[dayslimit] [int] NOT NULL ,
	[levellimit] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Temp_Text] (
	[a] [int] NULL ,
	[b] [int] NULL ,
	[c] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[remote] (
	[number] [int] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BoardTasker] WITH NOCHECK ADD 
	CONSTRAINT [PK__BoardTasker__26EFBBC6] PRIMARY KEY  CLUSTERED 
	(
		[taskid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Department] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_DepartID] PRIMARY KEY  CLUSTERED 
	(
		[DepartID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DeptRelateGame] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_relateID] PRIMARY KEY  CLUSTERED 
	(
		[relateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GAMELIST] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_LOG_GameID] PRIMARY KEY  CLUSTERED 
	(
		[Game_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_Log] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_LOG_LOGID] PRIMARY KEY  CLUSTERED 
	(
		[LOG_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_LogTime] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_LOG_ID] PRIMARY KEY  CLUSTERED 
	(
		[LOG_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_Log_UpdateAgo] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_LOG_UpdateID] PRIMARY KEY  CLUSTERED 
	(
		[LOG_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_Modules] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_LOG_ModuleID] PRIMARY KEY  CLUSTERED 
	(
		[Module_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_Roles] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_LOG_RoleID] PRIMARY KEY  CLUSTERED 
	(
		[Role_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_SDO_AccountTemp] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_idx] PRIMARY KEY  CLUSTERED 
	(
		[idx]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_SDO_Message] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_Seq] PRIMARY KEY  CLUSTERED 
	(
		[Seq]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_Serverinfo] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_idx1] PRIMARY KEY  CLUSTERED 
	(
		[idx]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_Users] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_UserID] PRIMARY KEY  CLUSTERED 
	(
		[UserID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[SDO_BoardMessage] WITH NOCHECK ADD 
	CONSTRAINT [PK_SDO_BoardMessage] PRIMARY KEY  CLUSTERED 
	(
		[boardID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[SDO_Scene] WITH NOCHECK ADD 
	CONSTRAINT [UPKCL_sceneID] PRIMARY KEY  CLUSTERED 
	(
		[sceneID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GMTools_Log] ADD 
	CONSTRAINT [DF__GMTools_L__Act_T__3C69FB99] DEFAULT (getdate()) FOR [Act_Time]
GO

ALTER TABLE [dbo].[GMTools_LogTime] ADD 
	CONSTRAINT [DF__GMTools_L__LogTi__3F466844] DEFAULT (getdate()) FOR [LogTime]
GO

ALTER TABLE [dbo].[GMTools_Log_UpdateAgo] ADD 
	CONSTRAINT [DF__GMTools_L__Act_T__4222D4EF] DEFAULT (getdate()) FOR [Act_Time]
GO

ALTER TABLE [dbo].[GMTools_SDO_AccountTemp] ADD 
	CONSTRAINT [DF_GMTools_SDO_AccountTemp_Ban_Date] DEFAULT (getdate()) FOR [Ban_Date]
GO

ALTER TABLE [dbo].[GMTools_Serverinfo] ADD 
	CONSTRAINT [DF__GMTools_S__creat__4CA06362] DEFAULT (getdate()) FOR [createtime]
GO

ALTER TABLE [dbo].[GMTools_Users] ADD 
	CONSTRAINT [DF__GMTools_U__onlin__4F7CD00D] DEFAULT (0) FOR [onlineActive]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















/*********************************************************************************/
/*	SP NAME : GmTools_Log_Query					 */
/*	MOD DATE: 2006-2-15							 */
/*	EDITOR  : GMTools_Log_Query								 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 查詢GMTools_Log表,按userid和操作時間查詢                        */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE                PROC [dbo].[GmTools_Log_Query]
@Gm_UserID		int,		--用戶id
@BeginDate	DateTime,		--查詢時間段,開始日期
@EndDate	DateTime		--查詢時間段,結束日期

AS

   select  a.RealName,b.game_Name,c.city,b.Real_Act,b.Act_Time from GMTools_Users a,GMTools_Log b,GMTools_ServerInfo c where a.UserID=b.UserID and b.ServerIP =c.ServerIP and c.gamedbid=1 and b.UserID = @Gm_UserID and Act_Time >= @BeginDate and   Act_Time <= @EndDate order by Act_Time desc







--execute GmTools_Log_Query 12,'2004-1-1','2006-4-5'






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











/*********************************************************************************/
/*	SP NAME : Gmtool_DepartAdmin_Query			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : select user info		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE     PROC [dbo].Gmtool_DepartAdmin_Query
@deptID int
AS
	
	select GameID from deptRelateGame where deptID=@deptID 
		



--execute Gmtool_DepartAdmin_Query 9







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












/*********************************************************************************/
/*	SP NAME : Gmtool_DepartRelateGame_Query			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : select user info		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE      PROC [dbo].Gmtool_DepartRelateGame_Query
@UserID int
AS
      declare @sysAdmin int
        select @sysAdmin = sysAdmin from gmtools_users where userid = @UserID
        if @sysAdmin = 1
           select game_ID,game_Name from gamelist
        else
	select c.gameID,d.game_Name from department a,gmtools_users b, DeptRelateGame c,GameList d where a.departID = c.deptID and a.departID =b.departID and c.gameID=d.game_ID and b.userid=@UserID

--execute Gmtool_DepartRelateGame_Query 1







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Add			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new users			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE              PROC [dbo].[Gmtool_Department_Admin]
@Gm_OperateUserID int,
@GM_DepartID int,
@Gm_GameID	VARCHAR(500)

--@ERRNO			INT	OUTPUT
AS
   declare @ERRNO int
   declare @str varchar(50)
   declare @RECNT int
   declare @i int
        while(CHARINDEX(',',@Gm_GameID,0)>0)
begin
  --得到MODULEID的元素
  set @str = substring(@Gm_GameID,0,CHARINDEX(',',@Gm_GameID,0))
  --print @str
  --取相反的MODULEID的元素
  set @Gm_GameID=substring(@Gm_GameID,CHARINDEX(',',@Gm_GameID,0)+1,len(@Gm_GameID)-len(@str))
  --print @GM_ModuleList
--判斷表裏是否存在的MODULEID
select @RECNT =count(*) from DeptRelateGame where  deptID= convert(int,@str)
  --print @RECNT
   if(@RECNT=0)
   begin
	set NoCount ON
	--BEGIN TRAN
           
              INSERT INTO DeptRelateGame				
			(deptID,gameID)
		VALUES
			(@GM_DepartID, @str)
	
		
		IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRAN
			SELECT @ERRNO = 0
		END
		ELSE
		BEGIN
			COMMIT TRAN
			SELECT @ERRNO = 1
		END

     end --沒有這個MODULEID，就往裏面插資料
    select @i=@i+1   
	END
RETURN @ERRNO




















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













/*********************************************************************************/
/*	SP NAME : Gmtool_Department_Delete			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new users			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE                PROC [dbo].[Gmtool_Department_Delete]
@Gm_OperateUserID int,
@GM_DepartID int
--@ERRNO			INT	OUTPUT
AS
   declare @ERRNO int
	BEGIN TRAN
        delete  from Department where departID = @GM_DepartID
        
	IF (@@rowcount = 0)
	BEGIN
		ROLLBACK TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'刪除部門ID'+Convert(varchar,@GM_DepartID)+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	COMMIT TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'刪除部門ID'+Convert(varchar,@GM_DepartID)+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO






















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Add			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new users			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE                PROC [dbo].[Gmtool_Department_Insert]
@Gm_OperateUserID int,
@Gm_DeprtName	VARCHAR(50)
,@Gm_Remark varchar(400),
@Gm_GameID varchar(500)


--@ERRNO			INT	OUTPUT
AS
   declare @Gm_DeptID int
	BEGIN TRAN
        insert into Department (DepartName,Remark) values (@Gm_DeprtName,@Gm_Remark)
   set @Gm_DeptID = @@IDENTITY
  declare @ERRNO int
   declare @str varchar(50)
   declare @RECNT int
   declare @i int
   
    while(CHARINDEX(',',@Gm_GameID,0)>0)
    begin
  --得到MODULEID的元素
  set @str = substring(@Gm_GameID,0,CHARINDEX(',',@Gm_GameID,0))
  --print @str
  --取相反的MODULEID的元素
  set @Gm_GameID=substring(@Gm_GameID,CHARINDEX(',',@Gm_GameID,0)+1,len(@Gm_GameID)-len(@str))
  --print @GM_ModuleList
--判斷表裏是否存在的MODULEID
select @RECNT =count(*) from DeptRelateGame where  deptID= convert(int,@str)
  --print @RECNT
   if(@RECNT=0)
   begin
	set NoCount ON
	BEGIN TRAN
           
              INSERT INTO DeptRelateGame				
			(deptID,gameID)
		VALUES
			(@Gm_DeptID, @str)
	
		
		IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRAN
			SELECT @ERRNO = 0
		END
		ELSE
		BEGIN
			COMMIT TRAN
			SELECT @ERRNO = 1
		END

     end --沒有這個MODULEID，就往裏面插資料
    select @i=@i+1   
	END
        
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加部門'+@Gm_DeprtName+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	COMMIT TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加部門'+@Gm_DeprtName+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


















/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Add			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new users			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

--Gmtool_Department_Update 2,9,'aa','--','4,8,'
CREATE                     PROC [dbo].[Gmtool_Department_Update]
@Gm_OperateUserID int,
@GM_DepartID int,
@Gm_DepartName	VARCHAR(50),
@Gm_Remark varchar(400),
@Gm_DepartRoles varchar(400)

AS
   	declare @ERRNO int
	declare @role varchar(10)
	
	BEGIN TRAN
        update Department set DepartName=@Gm_DepartName,Remark=@Gm_Remark where departID=@GM_DepartID
	delete from DeptRelateGame where deptID = @GM_DepartID
 
	while(CHARINDEX(',',@Gm_DepartRoles,0)>0)
    	begin
	  	--得到MODULEID的元素
	  	set @role = substring(@Gm_DepartRoles,0,CHARINDEX(',',@Gm_DepartRoles,0))

	  	--取相反的MODULEID的元素
	  	set @Gm_DepartRoles=substring(@Gm_DepartRoles,CHARINDEX(',',@Gm_DepartRoles,0)+1,len(@Gm_DepartRoles)-len(@role))
	        INSERT INTO DeptRelateGame (deptID,gameID) VALUES (@GM_DepartID, @role)
     	end

--RETURN @ERRNO   

	IF (@@error <> 0)
	BEGIN
		ROLLBACK TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'修改部門'+@Gm_DepartName+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	COMMIT TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'修改部門'+@Gm_DepartName+'記錄成功')
		SELECT @ERRNO = 1
	END
print @ERRNO
RETURN @ERRNO



























GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO









/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Add			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new users			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE            PROC [dbo].[Gmtool_GAME_Add]
@Gm_OperateUserID int,
@Gm_GameName	VARCHAR(20)
,@Gm_GameContext varchar(400)

--@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare @GameID INT
set NoCount ON
	
	BEGIN TRAN
	INSERT INTO GAMELIST				--寫入用戶表資訊
		(GAME_NAME, GAME_CONTENT)
	VALUES
		(@Gm_GameName, @Gm_GameContext)

        select @GameID = Game_ID from GAMELIST where GAME_NAME=@Gm_GameName
        
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加遊戲'+@Gm_GameName+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	COMMIT TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加遊戲'+@Gm_GameName+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO


















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Del			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : khq							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : delete user		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE             PROC [dbo].[Gmtool_GAME_Del]

@Gm_GAMEID		INT
,@Gm_OperateUserID	INT
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare  @Game_ID	int
declare  @Game_Name	varchar(50)
declare  @Game_Content	varchar(400)
	select @Game_ID=Game_ID from GAMELIST where game_ID = @Gm_GameID
	select @Game_Name=Game_Name from GAMELIST where game_ID = @Gm_GameID
	select @game_content=game_content from GAMELIST where game_ID = @Gm_GameID
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_GAME_Del','Game_ID_'+convert(varchar(5),@Game_ID)+'__Game_Name_'+@Game_Name+'__game_content_'+@game_content+'備份成功')	
	
set NoCount ON
	
	BEGIN TRAN
	delete from GAMELIST		
	where	game_ID = @Gm_GAMEID
		
	IF (@@ROWCOUNT = 0)
	BEGIN
		ROLLBACK TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'刪除用戶ID'+Convert(varchar(5),@Gm_GAMEID)+'記錄失敗')	--記錄log表 
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'刪除用戶ID'+Convert(varchar(5),@Gm_GAMEID)+'記錄成功')	--記錄log表 
		SELECT @ERRNO = 1
	END
RETURN @ERRNO


--exec Gmtool_GAME_Del 7,7















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



















/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Edit			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : edit user info		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE             PROC [dbo].[Gmtool_GAME_Edit]
@Gm_OperateUserID int,
@Gm_GameID int,
@Gm_GameName	varchar(100)
,@Gm_GameContext varchar(400)
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare  @Game_Name	varchar(100)
declare  @game_content 	varchar(400)
set NoCount ON
	
	BEGIN TRAN
	select @Game_Name=Game_Name from GAMELIST where game_ID = @Gm_GameID
	select @game_content=game_content from GAMELIST where game_ID = @Gm_GameID
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_GAME_Edit','Game_Name_'+@Game_Name+'__game_content_'+@game_content+'備份成功')	
	update GAMELIST					--修改用戶表資訊
		set Game_Name = @Gm_GameName,game_content=@Gm_GameContext
	where	game_ID = @Gm_GameID
       -- print @@rowcount
	IF (@@rowcount = 0)
	BEGIN
		ROLLBACK TRAN
	insert into GMTools_LogTime (operateUserID,operateMsg) values (@Gm_OperateUserID,'修改遊戲ID'+Convert(varchar(5),@Gm_GameID)+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into GMTools_LogTime (operateUserID,operateMsg) values (@Gm_OperateUserID,'修改遊戲ID'+Convert(varchar(5),@Gm_GameID)+'的資訊成功')		--記錄log表 
	
		SELECT @ERRNO = 1
	END
RETURN @ERRNO

--exec Gmtool_GAME_Edit 1,8,'猛將1','猛將1'
















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO









/*********************************************************************************/
/*	SP NAME : Gmtool_GameLink_Add			 */
/*	MOD DATE: 2006-3-7							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new gameinfo		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
create       PROC  [Gmtool_GameLink_Add]
@Gm_ServerIP   		varchar(30),
@Gm_OperateUserID	int,
@Login_UserID 		varchar(30),
@Login_PWD		varchar(30),
@City			varchar(30),
@GameID			int,
@gameflag		int,
@gamedbID		int,
@discinfo		varchar(200)

--@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 

declare @GameIP varchar(30)

select @GameIP=serverip from GMTools_Serverinfo where serverip = @Gm_ServerIP and gamedbID = @gamedbID
if len(@GameIP) > 0
	return 0	
	EXEC sp_addlinkedserver @Gm_ServerIP,N'SQL Server'
	
	EXEC sp_addlinkedsrvlogin @Gm_ServerIP, 'false',NULL,@Login_UserID, @Login_PWD
        
	declare     @gamename		varchar(50)
	select @gamename = game_name from gamelist where game_id=@GameID
	insert into GMTools_Serverinfo 
		(serverip,city,gameID,gamename,gameflag,gamedbID,descinfo,createby)
	VALUES
		(@Gm_ServerIP,@City,@GameID,@gamename,@gameflag,@GameID,@discinfo,@Gm_OperateUserID)
	
       
	IF (@@ERROR <> 0)
	BEGIN
		

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加遊戲資料'+@gamename+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加遊戲資料'+@gamename+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO


--EXEC sp_addlinkedserver '59.39.7.53',N'SQL Server'
--EXEC sp_addlinkedsrvlogin '59.39.7.53', 'false',NULL, 'sa', 'mjhnSA?><'

--exec Gmtool_GameLink_Add '59.39.7.53',11,'sa','mjhnSA?><','上海',2,1,4,'俺測試'
--exec sp_helpserver










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
















/*********************************************************************************/
/*	SP NAME : Gmtool_GmModule_Delete			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : delete game modules		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE          PROC [dbo].[Gmtool_GmModule_Delete]
@Gm_OperateUserID INT,
@GM_ModuleID		INT
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare  @Module_ID	int
declare  @Game_ID	int
declare	 @Module_Name  	varchar(50)
declare  @Module_Class	varchar(50)
declare  @Module_Content varchar(500)
set NoCount ON
	declare @strsql varchar(500)
	BEGIN TRAN
	select @Module_ID=Module_ID from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Game_ID=Game_ID from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Module_Name=Module_Name from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Module_Class=Module_Class from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Module_Content=Module_Content from GMTools_Modules where Module_ID = @GM_ModuleID
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_GmModule_Delete','Module_ID_'+convert(varchar(10),@Module_ID)+'__Game_ID_'+convert(varchar(10),@Game_ID)+'__Module_Name_'+@Module_Name+'__Module_Class_'+@Module_Class+'__Module_Content_'+@Module_Content+'備份成功')	
	--刪除模組表資訊
	set @strsql = 'delete from GMTools_Modules	where	Module_ID = '+convert(varchar,@GM_ModuleID)		
	
	exec(@strsql)
	IF (@@error <> 0)
	BEGIN
		ROLLBACK TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'刪除模組ID'+Convert(varchar(5),@GM_ModuleID)+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'刪除模組ID'+Convert(varchar(5),@GM_ModuleID)+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO



--exec Gmtool_GmModule_Delete 1,19






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











/*********************************************************************************/
/*	SP NAME : Gmtool_GmModule_Insert			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new Modules			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE    PROC [dbo].[Gmtool_GmModule_Insert]
@Gm_OperateUserID INT,
@GM_GameID		INT
,@GM_Name		VARCHAR(50)
,@GM_Class		VARCHAR(50)
,@GM_Content		varchar(400)
--,@ERRNO		INT	OUTPUT
AS
declare  @ERRNO		INT 
set NoCount ON
	
	BEGIN TRAN
	INSERT INTO GMTools_Modules				--寫入Module表資訊
		(Game_ID, Module_Name, Module_Class,Module_Content)
	VALUES
		(@GM_GameID, @GM_Name, @GM_Class,@GM_Content)

	
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'添加模組ID'+@GM_Name+'記錄成功')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'添加模組ID'+@GM_Name+'記錄失敗')	--記錄log表 
		SELECT @ERRNO = 1
	END
RETURN @ERRNO










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












/*********************************************************************************/
/*	SP NAME : Gmtool_GmModule_Update			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : edit game modules	 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE      PROC [dbo].[Gmtool_GmModule_Update]
@Gm_OperateUserID INT,
@GM_ModuleID INT,
@GM_GameID		INT
,@GM_Name		VARCHAR(50)
,@GM_Class		VARCHAR(50)
,@GM_Content		varchar(400)
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare  @Module_ID	int
declare  @Game_ID	int
declare	 @Module_Name  	varchar(50)
declare  @Module_Class	varchar(50)
declare  @Module_Content varchar(500)
set NoCount ON
	
	BEGIN TRAN
	select @Module_ID=Module_ID from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Game_ID=Game_ID from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Module_Name=Module_Name from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Module_Class=Module_Class from GMTools_Modules where Module_ID = @GM_ModuleID
	select @Module_Content=Module_Content from GMTools_Modules where Module_ID = @GM_ModuleID
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_GmModule_Update','Module_ID_'+convert(varchar(10),@Module_ID)+'__Game_ID_'+convert(varchar(10),@Game_ID)+'__Module_Name_'+@Module_Name+'__Module_Class_'+@Module_Class+'__Module_Content_'+@Module_Content+'備份成功')	
	
	update GMTools_Modules					
		set Game_ID = @GM_GameID, Module_Name = @GM_Name,Module_Class = @GM_Class,Module_Content = @GM_Content
	where	Module_ID = @GM_ModuleID
		
	
	IF (@@rowcount= 0)
	BEGIN
		ROLLBACK TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'修改模組ID'+Convert(varchar(5),@GM_ModuleID)+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'修改模組ID'+Convert(varchar(5),@GM_ModuleID)+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO



--exec Gmtool_GmModule_Update 38,38,44,'44','44','44'




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













/*********************************************************************************/
/*	SP NAME : Gmtool_GmModule_Update			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : edit game modules	 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE       PROC [dbo].[Gmtool_GmNotes_Update]
@Gm_OperateUserID INT,
@Gm_LetterID int,
@Gm_ProcessMan varchar(20),
@GM_ProcessDate datetime,
@GM_TransmitMan	varchar(20),
@GM_IsProcess		int,
@Gm_NotesReason varchar(500)
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO			INT 
declare  @letterID		int
declare	 @letterSender		varchar(50)
declare  @letterReceiver 	varchar(50)
declare  @letterSubject		varchar(50)
declare  @letterText		varchar(2500)
declare  @sendDate		datetime
declare  @processMan		int
declare  @processDate		datetime
declare  @transmitMan		int
declare  @isProcess		int

set NoCount ON
	
	BEGIN TRAN
	select @letterID=letterID from letter_info where letterId = @Gm_LetterID
	select @letterSender=letterSender from letter_info where letterId = @Gm_LetterID
	select @letterReceiver=letterReceiver from letter_info where letterId = @Gm_LetterID
	select @letterSubject=letterSubject from letter_info where letterId = @Gm_LetterID
	select @letterText=letterText from letter_info where letterId = @Gm_LetterID
	select @sendDate=sendDate from letter_info where letterId = @Gm_LetterID
	select @processMan=processMan from letter_info where letterId = @Gm_LetterID
	select @processDate=processDate from letter_info where letterId = @Gm_LetterID
	select @transmitMan=transmitMan from letter_info where letterId = @Gm_LetterID
	select @isProcess=isProcess from letter_info where letterId = @Gm_LetterID
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_GmNotes_Update','letterID_'+convert(varchar(10),@letterID)+'__letterSender_'+@letterSender+'__letterReceiver_'+@letterReceiver+'__letterSubject_'+@letterSubject+'__letterText_'+@letterText+'__sendDate_'+convert(varchar(50),@sendDate)+'__processDate_'+convert(varchar(50),@processDate)+'__transmitMan_'+convert(varchar(10),@transmitMan)+'__isProcess_'+convert(varchar(10),@isProcess)+'備份成功')		

	update letter_info					
		set processMan = @Gm_ProcessMan, processDate = @GM_ProcessDate,transmitMan = @GM_TransmitMan,isProcess =@GM_IsProcess,reason=@Gm_NotesReason
	where	letterId = @Gm_LetterID
		
	
	IF (@@rowcount= 0)
	BEGIN
		ROLLBACK TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'郵件處理郵件'+Convert(varchar(5),@Gm_LetterID)+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'郵件處理郵件'+Convert(varchar(5),@Gm_LetterID)+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO



--exec Gmtool_GmNotes_Update 11,9,'10','2005-1-1','10',10





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





















--execute Gmtool_GmUserModule_Admin 36,'3,4,5,6,9,8,'

/*********************************************************************************/
/*	SP NAME : Gmtool_GmUserModule_Insert			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new UserModules			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE             PROC [dbo].[Gmtool_GmUserModule_Admin]
@GM_UserID		int
,@GM_ModuleList		varchar(1000)
--,@ERRNO		INT	OUTPUT
AS
declare  @ERRNO		INT 

declare  @moduleID      INT
declare  @strQuery 	varchar(5000)
declare  @CrsrVar 	Cursor


set @ERRNO = 0
--刪除已不存在的MODULEID
set @strQuery = 'delete from GMTOOLS_Roles where userid='+convert(varchar(5),@GM_UserID)+' and Module_ID not in ('+substring(@GM_ModuleList,0,len(@GM_ModuleList))+')'
execute(@strQuery)
declare @RECNT int
declare @i int
declare @pos int
set @RECNT= 0
set @i =0
set @pos =0
declare @str char(50)
declare @gameID int
while(CHARINDEX(',',@GM_ModuleList,0)>0)
begin
  --得到MODULEID的元素
  set @str = substring(@GM_ModuleList,0,CHARINDEX(',',@GM_ModuleList,0))
  --print @str
  --取相反的MODULEID的元素
  set @GM_ModuleList=substring(@GM_ModuleList,CHARINDEX(',',@GM_ModuleList,0)+1,len(@GM_ModuleList)-len(@str))
  --print @GM_ModuleList
--判斷表裏是否存在的MODULEID
select @RECNT =count(*) from GMTOOLS_Roles where Userid= convert(char,@GM_UserID) and Module_ID= @str
  --print @RECNT
   if(@RECNT=0)
   begin
	set NoCount ON
	BEGIN TRAN
           
	     select @gameID = game_id from GMTOOLS_Modules where module_id=convert(int,@str)
		print @gameID
              INSERT INTO GMTools_Roles				
			(Userid,Module_id,game_ID)
		VALUES
			(@GM_UserID, @str,@gameID)
	
		
		IF (@@ERROR <> 0)
		BEGIN
			ROLLBACK TRAN
			SELECT @ERRNO = 0
		END
		ELSE
		BEGIN
			COMMIT TRAN
			SELECT @ERRNO = 1
		END

     end --沒有這個MODULEID，就往裏面插資料
    select @i=@i+1   


/*SET @CrsrVar = Cursor Forward_Only Static For
	SELECT 
		moduleID 
	FROM
		dbo.GMTOOLS_Roles
OPEN @CrsrVar
FETCH NEXT FROM @CrsrVar
Into @moduleID
WHILE (@@FETCH_STATUS = 0)
begin

    FETCH NEXT FROM @CrsrVar Into @moduleID*/
	
END

RETURN @ERRNO



--exec Gmtool_GmUserModule_Admin 3,'50,51,'








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Add			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new users			 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE             PROC [dbo].[Gmtool_Gminfo_Add]
@Gm_OperateUserID int,
@Gm_UserName		VARCHAR(50)
,@Gm_Password		VARCHAR(50)
,@Gm_DepartID int
,@Gm_RealName VARCHAR(50)
,@Gm_LimitTime		datetime	
,@Gm_Status int,
@Gm_SysAdmin int
--@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare @UserID INT
set NoCount ON
	
	BEGIN TRAN
	INSERT INTO GMTools_Users				--寫入用戶表資訊
		(UserName, User_Pwd,RealName,DepartID,User_status,limit,SysAdmin)
	VALUES
		(@Gm_UserName, @Gm_Password,@Gm_RealName,@Gm_DepartID,@Gm_Status,@Gm_LimitTime,@Gm_SysAdmin)

        select @UserID = UserID from GMTools_Users where userName=@Gm_UserName
        
	IF (@@ERROR <> 0)
	BEGIN
		ROLLBACK TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加用戶名'+@Gm_UserName+'記錄失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	COMMIT TRAN

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'添加用戶名'+@Gm_UserName+'記錄成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO



















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Del			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : delete user		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE            PROC [dbo].[Gmtool_Gminfo_Del]

@Gm_UserID		INT
,@Gm_OperateUserID	INT
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT
declare  @UserID	int
declare	 @UserName	varchar(50)
declare  @User_Pwd	varchar(50)
declare  @User_MAC	varchar(50)
declare  @RealName	varchar(50)
declare  @DepartID	int
declare  @User_status	int
declare  @limit		smalldatetime
declare  @onlineActive  int
set NoCount ON
	
	BEGIN TRAN
	select @UserID=UserID from GMTools_Users where UserID = @Gm_UserID
	select @UserName=UserName from GMTools_Users where UserID = @Gm_UserID
	select @User_Pwd=User_Pwd from GMTools_Users where UserID = @Gm_UserID
	select @User_MAC=User_MAC from GMTools_Users where UserID = @Gm_UserID
	select @RealName=RealName from GMTools_Users where UserID =@Gm_UserID
	select @DepartID=DepartID from GMTools_Users where UserID = @Gm_UserID
	select @User_status=User_status from GMTools_Users where UserID = @Gm_UserID
	select @limit=limit from GMTools_Users where UserID = @Gm_UserID
	select @onlineActive=onlineActive from GMTools_Users where UserID = @Gm_UserID
	print @UserName
	--insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_GAME_Edit','UserID_'+convert(varchar(10),@UserID)+'__UserName_'+@UserName+'__User_MAC_'+@User_MAC+'__RealName_'+@RealName+'__User_Pwd_'+@User_Pwd+'__DepartID_'+convert(varchar(10),@DepartID)+'__User_status_'+convert(varchar(10),@User_status)+'__limit_'+convert(varchar(30),@limit)+'__onlineActive_'+convert(varchar(10),@onlineActive)+'備份成功')	
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_Gminfo_Del','UserID_'+convert(varchar(10),@UserID)+'__UserName_'+@UserName+'__User_MAC_'+@User_MAC+'__RealName_'+@RealName+'__User_Pwd_'+@User_Pwd+'__DepartID_'+convert(varchar(10),@DepartID)+'__User_status_'+convert(varchar(10),@User_status)+'__limit_'+convert(varchar(30),@limit)+'__onlineActive_'+convert(varchar(10),@onlineActive)+'備份成功')	
	delete from GMTools_Users				--刪除用戶表資訊
	where	UserID = @Gm_UserID
		
	IF (@@ROWCOUNT = 0)
	BEGIN
		ROLLBACK TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'刪除用戶ID'+Convert(varchar(5),@Gm_UserID)+'記錄失敗')	--記錄log表 
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into  GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_OperateUserID,'刪除用戶ID'+Convert(varchar(5),@Gm_UserID)+'記錄成功')	--記錄log表 
		SELECT @ERRNO = 1
	END
RETURN @ERRNO


--exec Gmtool_Gminfo_Del 21,15














GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



















/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Edit			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : edit user info		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE             PROC [dbo].[Gmtool_Gminfo_Edit]
@Gm_OperateUserID int,
@Gm_UserID		int
,@Gm_RealName varchar(100)
,@Gm_DeptID int
,@Gm_LimitTime		smalldatetime
,@Gm_Status int,
@Gm_OnlineActive int,
@Gm_SysAdmin int
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare  @realName	varchar(50)
declare  @DepartID	int
declare  @limit		smalldatetime
declare  @User_status	int
declare  @OnlineActive  int
set NoCount ON
	
	BEGIN TRAN

	select @RealName=RealName from GMTools_Users where UserID =@Gm_UserID
	select @DepartID=DepartID from GMTools_Users where UserID = @Gm_UserID
	select @User_status=User_status from GMTools_Users where UserID = @Gm_UserID
	select @limit=limit from GMTools_Users where UserID = @Gm_UserID
	select @onlineActive=onlineActive from GMTools_Users where UserID = @Gm_UserID
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_Gminfo_Edit','__RealName_'+@RealName+'__DepartID_'+convert(varchar(10),@DepartID)+'__User_status_'+convert(varchar(10),@User_status)+'__limit_'+convert(varchar(30),@limit)+'__onlineActive_'+convert(varchar(10),@onlineActive)+'備份成功')	

	update GMTools_Users					--修改用戶表資訊
		set realName=@Gm_RealName,DepartID=@Gm_DeptID, limit = @Gm_LimitTime,user_status=@Gm_Status,OnlineActive=@Gm_OnlineActive,sysAdmin=@Gm_SysAdmin
	where	UserID = @Gm_UserID

	IF (@@rowcount = 0)
	BEGIN
		ROLLBACK TRAN
	insert into GMTools_LogTime (operateUserID,operateMsg) values (@Gm_OperateUserID,'修改用戶ID'+Convert(varchar(5),@Gm_UserID)+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into GMTools_LogTime (operateUserID,operateMsg) values (@Gm_OperateUserID,'修改用戶ID'+Convert(varchar(5),@Gm_UserID)+'的資訊成功')		--記錄log表 
		SELECT @ERRNO = 1
	END
RETURN @ERRNO







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO









/*********************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Select			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : select user info		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE   PROC [dbo].[Gmtool_Gminfo_Select]
@Gm_UserID		int
AS
	
	select a.UserName,a.user_Pwd,b.Module_ID from GMTools_Users a inner join GMTools_Roles b on a.UserID = @Gm_UserID 
		
	









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO








/******************************************************************************/
/*	SP NAME : Gmtool_Gminfo_Edit			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : edit user info		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE           PROC [dbo].[Gmtool_PASSWD_Edit]
@Gm_OperateUserID int,
@Gm_UserID		int
,@Gm_Password		VARCHAR(50)
--,@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 
declare  @UserID	int
declare	 @UserName	varchar(50)
declare  @User_Pwd	varchar(50)
declare  @User_MAC	varchar(50)
declare  @RealName	varchar(50)
declare  @DepartID	int
declare  @User_status	int
declare  @limit		smalldatetime
declare  @onlineActive  int
set NoCount ON
	
	BEGIN TRAN

	select @UserID=UserID from GMTools_Users where UserID = @Gm_UserID
	select @UserName=UserName from GMTools_Users where UserID = @Gm_UserID
	select @User_Pwd=User_Pwd from GMTools_Users where UserID = @Gm_UserID
	select @User_MAC=User_MAC from GMTools_Users where UserID = @Gm_UserID
	select @RealName=RealName from GMTools_Users where UserID =@Gm_UserID
	select @DepartID=DepartID from GMTools_Users where UserID = @Gm_UserID
	select @User_status=User_status from GMTools_Users where UserID = @Gm_UserID
	select @limit=limit from GMTools_Users where UserID = @Gm_UserID
	select @onlineActive=onlineActive from GMTools_Users where UserID = @Gm_UserID
	
		
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_PASSWD_Edit','UserID_'+convert(varchar(10),@UserID)+'__UserName_'+@UserName+'__User_MAC_'+@User_MAC+'__RealName_'+@RealName+'__User_Pwd_'+@User_Pwd+'__DepartID_'+convert(varchar(10),@DepartID)+'__User_status_'+convert(varchar(10),@User_status)+'__limit_'+convert(varchar(30),@limit)+'__onlineActive_'+convert(varchar(10),@onlineActive)+'備份成功')	
	

	update GMTools_Users					--修改用戶表資訊
		set User_Pwd = @Gm_Password
	where	UserID = @Gm_UserID

	IF (@@rowcount= 0)
	BEGIN
		ROLLBACK TRAN
	insert into GMTools_LogTime (operateUserID,operateMsg) values (@Gm_OperateUserID,'修改用戶ID'+Convert(varchar(5),@Gm_UserID)+'的密碼失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		COMMIT TRAN
	insert into GMTools_LogTime (operateUserID,operateMsg) values (@Gm_OperateUserID,'修改用戶ID'+Convert(varchar(5),@Gm_UserID)+'的密碼成功')		--記錄log表 
		SELECT @ERRNO = 1
	END
RETURN @ERRNO


--exec Gmtool_PASSWD_Edit 24,24,'24'




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







CREATE   proc Gmtool_Serverinfo_del
@Gm_ServerIP 		varchar(30),
@Gm_OperateUserID 	int
as
	declare @ERRNO		int
	declare @serverip	varchar(30)
	declare @city		varchar(50)
	declare @gameID		int
	declare @gamename	varchar(50)
	declare @gameflag	int
	declare @gamedbID	int
	declare @descinfo	varchar(200)
	declare @createtime	datetime

	select @serverip=serverip from GMTools_Serverinfo where serverip=@Gm_ServerIP
	select @city=city from GMTools_Serverinfo where serverip=@Gm_ServerIP
	select @gameID=gameID from GMTools_Serverinfo where serverip=@Gm_ServerIP
	select @gamename=gamename from GMTools_Serverinfo where serverip=@Gm_ServerIP
	select @gameflag=gameflag from GMTools_Serverinfo where serverip=@Gm_ServerIP
	select @gamedbID=gamedbID from GMTools_Serverinfo where serverip=@Gm_ServerIP
	select @descinfo=descinfo from GMTools_Serverinfo where serverip=@Gm_ServerIP
	select @createtime=createtime from GMTools_Serverinfo where serverip=@Gm_ServerIP
	insert into GMTools_Log_UpdateAgo(UserID,SP_Name,Real_Act) values (@Gm_OperateUserID,'Gmtool_Serverinfo_del','serverip_'+@serverip+'__city_'+@city+'__gameID_'+convert(varchar(10),@gameID)+'__gamename_'+@gamename+'__gameflag_'+convert(varchar(5),@gameflag)+'__gamedbID_'+convert(varchar(5),@gamedbID)+'__descinfo_'+@descinfo+'__createtime'+convert(varchar(30),@createtime)+'備份成功')	
	
	delete from GMTools_Serverinfo where serverip=@Gm_ServerIP

IF (@@rowcount  = 0)
	BEGIN
		

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'刪除遊戲資料'+@Gm_ServerIP+'失敗')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	

	INSERT INTO GMTools_LogTime			--寫log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_OperateUserID,'刪除遊戲資料'+@Gm_ServerIP+'成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO

--exec Gmtool_Serverinfo_del '1',1




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













/*********************************************************************************/
/*	SP NAME : Gmtool_UserInfo_Query			 */
/*	MOD DATE: 2005-12-28							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : select user info		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE       PROC [dbo].Gmtool_UserInfo_Query
@Gm_UserID int
as
        declare @sysAdmin int
        declare @deptID int
        select @sysAdmin = sysAdmin from gmtools_users where userid = @Gm_UserID
      if @sysAdmin = 1
        select a.userID,a.userName,a.user_Pwd,a.user_mac,a.realName,a.DepartID,b.departName,a.user_Status,a.limit,a.Onlineactive,a.SysAdmin from GMTOOLS_Users a,Department b where a.departID=b.departID
     else
       begin
        select @deptID = departID from gmtools_users where userid = @Gm_UserID
        select a.userID,a.userName,a.user_Pwd,a.user_mac,a.realName,a.DepartID,b.departName,a.user_Status,a.limit,a.Onlineactive,a.SysAdmin from GMTOOLS_Users a,Department b where a.sysAdmin=0 and a.departID=b.departID and b.departID = @deptID
       end
--execute Gmtool_DepartAdmin_Query 9









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE         procedure SDO_AccountTemp_Query
@SDO_ServerIP varchar(30),
@SDO_UserID varchar(20)

as
begin
 
  select distinct a.Content,a.Ban_date,a.Reason from  GMTools_SDO_AccountTemp a,GMTools_Serverinfo b  where a.[USER_ID]=@SDO_UserID and b.serverip=@SDO_ServerIP
  
 end

--exec SDO_AccountTemp_Query '192.168.6.222','dev001'






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




















/*********************************************************************************/
/*	SP NAME : SDO_Banishment_Close		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 封存玩家帳號		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/







CREATE                        procedure SDO_Banishment_Close
@Gm_UserID int,
@SDO_ServerIP varchar(30),
@SDO_UserID varchar(20),
@SDO_Reason  varchar(800),
@SDO_BanDate int

as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)
  declare @SqlStr varchar(500)
  declare @ERRNO int
  declare @strQuery varchar(500)
  --declare @SDO_BanDate int
  --set @SDO_BanDate = 1
  set @strQuery = 'select userid  from ['+@SDO_serverIP+'].gamedb.dbo.Member where userID='''+@SDO_UserID+''''
  --print @strQuery
  execute(@strQuery)
  IF @@Rowcount < 1
        begin
   		SELECT @ERRNO = -1
        end
  else 
  begin
     --根據id取出用戶真實姓名
     select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
     --根據ip取出對應的伺服器名
     select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
     --set @SqlStr = 'insert into  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_banishment (USER_INDEX_ID,USER_ID) select id, userid from ['+@SDO_ServerIP+'].gamedb.dbo.Member where userid = '''+@SDO_UserID+''''
     set @SqlStr = 'insert into  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_banishment (USER_INDEX_ID,USER_ID,Ban_Date) select id, userid,getdate() + '+convert(varchar,@SDO_BanDate)+' from ['+@SDO_ServerIP+'].gamedb.dbo.Member where userid = '''+@SDO_UserID+''''

     print   @SqlStr
     execute(@SqlStr)
IF (@@rowcount = 0)
	BEGIN

	  insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_Banishment_Close','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器封停玩家帳號'+@SDO_UserID+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
       
		
	  insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_Banishment_Close','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器封停玩家帳號'+@SDO_UserID+'的資訊成功')	
	  insert into GMTools_SDO_AccountTemp (GM_UserID,[USER_ID],Reason,Content,ServerIP)  values (@Gm_UserID,@SDO_UserID,@SDO_Reason,'封停帳號',@SDO_ServerIP) 		
	  SELECT @ERRNO = 1
	END
  end
print @ERRNO
RETURN @ERRNO 
end

--exec SDO_Banishment_Close 12,'192.168.6.222','dev001','kkk'


















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
























/*********************************************************************************/
/*	SP NAME : SDO_Banishment_Open			 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 解封玩家帳號		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/



CREATE                        procedure SDO_Banishment_Open
@Gm_UserID int,
@SDO_ServerIP varchar(30),
@SDO_UserID varchar(20)

as
begin
  declare @SqlStr varchar(500)
  declare @ERRNO int
  declare @strQuery varchar(5000)
  declare @RealName  varchar(50)
  declare @city  varchar(50)
  --檢查該用戶是否被封存
  set @strQuery = 'select User_ID from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_banishment where USER_ID='''+@SDO_UserID+''''
  execute(@strQuery)
  --print @@rowcount
  if (@@rowcount > 0) 
  begin
	  --備份本次操作之前的資料，刪除之前的資料拼成sql語句寫入GMTools_Log_UpdateAgo表
	  set @strQuery = 'insert into GMTools_Log_UpdateAgo (UserID,SP_Name,ServerIP,Real_Act) select '+convert(varchar,@Gm_UserID)+' ,''SDO_Banishment_Open'' ,'''+rtrim(@SDO_ServerIP)+''',''insert into ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_banishment  (User_Index_ID,User_id,ban_date) values (''''''+convert(varchar,User_Index_id)+'''''',''''''+User_id +'''''',''''''+substring(convert(varchar,ban_date, 20), 1,20)+'''''')''  from ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_banishment where USER_ID='''+@SDO_UserID+''''
	  print @strQuery
	  execute(@strQuery)
  end
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  --刪除T_o2jam_banishment表內玩家該記錄，以達到解封目的
  set @SqlStr = 'delete from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_banishment where USER_ID='''+@SDO_UserID+''''
  execute(@SqlStr)
 
  --在GMTools_Log表寫入log,如果成功刪除本地記錄
  --print @@rowcount
  IF (@@rowcount=0 )
        
	BEGIN
           
	  insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Banishment_Open','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器解封玩家帳號'+@SDO_UserID+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
        else
	BEGIN
          
	  insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Banishment_Open','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器解封玩家帳號'+@SDO_UserID+'的資訊成功')	
	  delete from GMTools_SDO_AccountTemp where user_id=@SDO_UserID and serverip=@SDO_ServerIP
		SELECT @ERRNO = 1
	END

  RETURN @ERRNO
  --print @ERRNO
  
end




--select * from dbo.GMTools_Log order by act_time desc

--execute SDO_Banishment_Open 12,'61.151.249.172','lingping'











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE          procedure SDO_Banishment_Query
@SDO_ServerIP varchar(30),
@SDO_UserID varchar(20)

as
begin
  declare @SqlStr varchar(500)
  declare @ERRNO int
 
  set @SqlStr  = 'select USER_ID from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_banishment where USER_ID='''+@SDO_UserID+''''
  execute(@SqlStr)

 
end















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO









CREATE            procedure SDO_Banishment_QueryAll
@SDO_ServerIP varchar(30)

as
begin
  declare @SqlStr varchar(500)
 
  set @SqlStr  = 'select USER_INDEX_ID,USER_ID,Ban_Date from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_banishment order by Ban_Date desc'
 print @SqlStr
  execute(@SqlStr)

 
end











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





-- =============================================
-- Author:		<Author,,Name>
-- ALTER  date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SDO_BoardTask_OwnerQuery]
@sdo_taskid int
as
BEGIN
   select city from sdo_BoardMessage a,gmtools_serverinfo b where a.serverip=b.serverip and gamedbid=2 and taskid=@sdo_taskid
END


--substring(a.zoneIP,0,charindex(':',a.zoneIP))=




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO








-- =============================================
-- Author:		<Author,,Name>
-- ALTER  date: <ALTER  Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[SDO_BoardTask_Query]
as
BEGIN
	select distinct a.taskid,a.sendBeginTime,a.sendEndTime,a.Interval,a.status,boardmessage from BoardTasker a where status=0 or status=2 order by a.taskid desc
END


--substring(a.zoneIP,0,charindex(':',a.zoneIP))=





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














/*********************************************************************************/
/*	SP NAME : SDO_Charinfo_Edit			 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 修改玩家帳號資訊		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/





CREATE                procedure SDO_Charinfo_Edit
@Gm_UserID int,
@SDO_ServerIP varchar(30),
@SDO_UserID varchar(20),
@SDO_Level varchar(5),
@SDO_Experience varchar(5),
@SDO_Total varchar(5),
@SDO_Win varchar(5),
@SDO_Draw varchar(5),
@SDO_Lose varchar(5),
@SDO_MCash varchar(10),
@SDO_GCash varchar(10)

as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)
  declare @updateSql varchar(500)
  declare @ERRNO int
  declare @strQuery varchar(5000)

  set @strQuery = 'select userid  from ['+@SDO_serverIP+'].gamedb.dbo.Member where userID='''+@SDO_UserID+''''
  --print @strQuery
  execute(@strQuery)
  IF @@ROWCOUNT <> 1
        begin
   		SELECT @ERRNO = -1
        end
  else 
  begin
  -- set @SDO_Total = @SDO_Win+@SDO_Draw+@SDO_Lose
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  --備份本次操作之前的資料，修改之前的資料拼成sql語句寫入GMTools_Log_UpdateAgo表
  set @strQuery = 'insert into GMTools_Log_UpdateAgo (UserID,SP_Name,ServerIP,Real_Act) select '+convert(varchar,@Gm_UserID)+' ,''SDO_Charinfo_Edit'' ,'''+rtrim(@SDO_ServerIP)+''',''update ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_charinfo  set   level=''''''+convert(varchar,level)+'''''',Experience=''''''+convert(varchar,Experience)+'''''',Battle=''''''+convert(varchar,Battle)+'''''',Win=''''''+convert(varchar,Win)+'''''',Draw=''''''+convert(varchar,Draw)+'''''',Lose=''''''+convert(varchar,Lose)+'''''',MCASH=''''''+convert(varchar,MCASH)+'''''',GCASH=''''''+convert(varchar,GCASH)+''''''   where USERID='''''+@SDO_UserID+'''''''   from ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_charinfo where USERID='''+@SDO_UserID+''''
  print @strQuery
  execute(@strQuery)

  set @updateSql  = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_charinfo set level='''+@SDO_Level+''',Experience='''+@SDO_Experience+''',Battle='''+@SDO_Total+''',Win='''+@SDO_Win+''',Draw='''+@SDO_Draw+''',Lose='''+@SDO_Lose+''',MCASH='''+@SDO_MCash+''',GCASH='''+@SDO_GCash+''' where userid='''+@SDO_UserID+''''
  execute(@updateSql)
IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Charinfo_Edit','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器修改玩家資訊'+@SDO_UserID+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Charinfo_Edit','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器修改玩家資訊'+@SDO_UserID+'的資訊成功；本次修改資訊：level^'+@SDO_Level+'^Experience^'+@SDO_Experience+'^Battle^'+@SDO_Total+'^Win^'+@SDO_Win+'^Draw^'+@SDO_Draw+'^Lose^'+@SDO_Lose+'^MCASH^'+@SDO_MCash+'^GCASH^'+@SDO_GCash)
		SELECT @ERRNO = 1
	END
 end
RETURN @ERRNO
end

--select * from GMTools_Log_UpdateAgo order by log_id desc









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





















CREATE                 procedure SDO_Charinfo_Query
@SDO_serverIP varchar(30),
@SDO_UserID varchar(20),
@SDO_NickName varchar(50)
as
begin

declare @strQuery varchar(5000)
 if len(@SDO_UserID)>0 and len(@SDO_NickName)<=0 
   set @strQuery = 'select a.user_index_id,a.userid,a.level,a.experience,a.Battle,a.Win,a.Draw,a.Lose,a.Reputation,a.GCash,a.MCash,a.VirtualAddress,a.Age,a.City,b.sex,b.usernick,c.MAIN_CH,c.SUB_CH,case when exists(select * from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_banishment where user_index_id = a.user_index_id) then ''Lock'' else ''UnLock'' end Ban from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_charinfo a,['+@SDO_serverIP+'].gamedb.dbo.member b left join ['+@SDO_serverIP+'].gamedb.dbo.t_sdo_login c on b.userid = c.user_id where a.user_index_ID=b.ID and a.userID='''+@SDO_UserID+''''
  else if len(@SDO_NickName)>0 and len(@SDO_UserID)<=0 
    set @strQuery = 'select a.user_index_id,a.userid,a.level,a.experience,a.Battle,a.Win,a.Draw,a.Lose,a.Reputation,a.GCash,a.MCash,a.VirtualAddress,a.Age,a.City,b.sex,b.usernick,c.MAIN_CH,c.SUB_CH,case when exists(select * from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_banishment where user_index_id = a.user_index_id) then ''Lock'' else ''UnLock'' end Ban  from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_charinfo a,['+@SDO_serverIP+'].gamedb.dbo.member b left join ['+@SDO_serverIP+'].gamedb.dbo.t_sdo_login c on b.userid = c.user_id where a.user_index_ID=b.ID and b.usernick='''+@SDO_NickName+''''
  else if len(@SDO_UserID)>0  and len(@SDO_NickName)>0
   set @strQuery = 'select a.user_index_id,a.userid,a.level,a.experience,a.Battle,a.Win,a.Draw,a.Lose,a.Reputation,a.GCash,a.MCash,a.VirtualAddress,a.Age,a.City,b.sex,b.usernick,c.MAIN_CH,c.SUB_CH,case when exists(select * from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_banishment where user_index_id = a.user_index_id) then ''Lock'' else ''UnLock'' end Ban  from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_charinfo a,['+@SDO_serverIP+'].gamedb.dbo.member b left join ['+@SDO_serverIP+'].gamedb.dbo.t_sdo_login c on b.userid = c.user_id where a.user_index_ID=b.ID and a.userID='''+@SDO_UserID+''' and b.usernick='''+@SDO_NickName+''''
print @strQuery
execute(@strQuery)

end



















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO








CREATE        procedure SDO_EmailPWD_Query
@SDO_ServerIP varchar(20),
@SDO_UserID varchar(30)

as
begin
	declare @strQuery 	varchar(500)
	set @strQuery = 'select userid,passwd from ['+@SDO_ServerIP+'].gamedb.dbo.member  where userid='''+@SDO_UserID+''''
	execute(@strQuery)

end







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







--SDO_Friend_NickName_Query '127.0.0.1','twgamanet001     '


CREATE        procedure SDO_Friend_NickName_Query
@SDO_ServerIP varchar(30),
@SDO_UserID varchar(20)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select rtrim(friend_nick) from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_charinfo c,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_friend d where c.user_index_id=d.userindexid and c.userid='''+rtrim(convert(varchar,@SDO_UserID))+''''
  print(@strQuery)  
  execute(@strQuery)
  
end










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE           procedure SDO_Friend_Query
@SDO_serverIP 		varchar(30),
@SDO_UserIndexID	varchar(20)
as
begin

declare @strQuery varchar(500)


set @strQuery = 'select a.user_index_id,a.userid,a.level,a.experience,a.Battle,a.Win,a.Draw,a.Lose,a.Reputation,a.GCash,a.MCash,a.VirtualAddress,a.Age,a.City,b.friend_nick from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_charinfo a,['+@SDO_serverIP+'].gamedb.dbo.T_sdo_friend b where a.user_index_ID=b.userindexid and b.userindexid='''+@SDO_UserIndexID+''''
print @strQuery
execute(@strQuery)

end










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO









/*********************************************************************************/
/*	SP NAME : SDO_GateWay_Query			 */
/*	MOD DATE: 2007-2-6				 */
/*	EDITOR  : Andy						 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 将异常玩家踢下线*/
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/




CREATE                     procedure SDO_GateWay_Query
@SDO_ServerIP 		varchar(30),
@SDO_GateWayIP varchar(30)


as
set nocount on
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50) 
  declare @strQuery varchar(5000)
  declare @ERRNO    int	

  set @strQuery = 'select addr_IP from  ['+@SDO_ServerIP+'].gamedb.dbo.T_SDO_Login  where GATEWAY_ID='''+@SDO_GateWayIP+''''
  execute(@strQuery)

end
--select * from GMTools_Log_UpdateAgo order by log_id desc
--exec O2JAM_Login_del  12,'192.168.0.70','test06'




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
















CREATE             procedure SDO_GiftBox_Query
@SDO_ServerIP varchar(30),
@SDO_UserIndexID varchar(10)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select distinct b.name,b.bigtype,b.smalltype,a.datelimit,a.timeslimit,a.title,a.Content,a.itemCode,a.writeDate from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Message a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_data b where a.itemcode=b.itemcode and  a.ReceiverIndexID='+@SDO_userIndexID+' order by a.datelimit desc'
  execute(@strQuery)
  print(@strQuery)
end












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


















/*********************************************************************************/
/*	SP NAME : SDO_GiftBox_del			 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 刪除玩家禮物盒咚咚*/
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/




CREATE                 procedure SDO_GiftBox_del
@Gm_UserID 		int,
@SDO_ServerIP 		varchar(30),
@SDO_UserIndexID 	varchar(20),
@SDO_Itemcode 		varchar(20)
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50) 
  declare @strQuery varchar(5000)
  declare @ERRNO    int	

  set @strQuery = 'select receiverIndexID from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Message where receiverIndexID='''+@SDO_UserIndexID+'''  and itemcode='''+@SDO_Itemcode+''''
  execute(@strQuery)
  if (@@rowcount > 0) 
  begin
	  --備份本次操作之前的資料，刪除之前的資料拼成sql語句寫入GMTools_Log_UpdateAgo表
	  set @strQuery = 'insert into GMTools_Log_UpdateAgo (UserID,SP_Name,ServerIP,Real_Act) select '+convert(varchar,@Gm_UserID)+' ,''SDO_GiftBox_del'' ,'''+rtrim(@SDO_ServerIP)+''',''insert into ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_Message  (ReceiverIndexID,SenderNickName,Title,Content,itemcode,timeslimit,datelimit) values (''''''+convert(varchar,ReceiverIndexID)+'''''',''''''+SenderNickName +'''''',''''''+convert(varchar,Title)+'''''',''''''+convert(varchar,Content)+'''''',''''''+convert(varchar,itemcode)+'''''',''''''+convert(varchar,timeslimit)+'''''',''''''+convert(varchar,datelimit)+'''''')''  from ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_Message where receiverIndexID='''+@SDO_UserIndexID+''' and itemcode='''+@SDO_Itemcode+''''
	  print @strQuery
	  execute(@strQuery)
  end  
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' delete from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Message  where itemcode='''+@SDO_Itemcode+''' and receiverIndexID= '''+@SDO_UserIndexID+''''
  execute(@strQuery)


IF (@@ROWCOUNT = 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_GiftBox_del',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除玩家'+@SDO_UserIndexID+'禮物盒上的道具'+@SDO_Itemcode+'資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_GiftBox_del',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除玩家'+@SDO_UserIndexID+'禮物盒上的道具'+@SDO_Itemcode+'資訊成功')	
		SELECT @ERRNO = 1
	END
RETURN @ERRNO
end









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE           procedure SDO_ItemData_Down
@SDO_ServerIP varchar(30)

as
begin
  declare @strQuery varchar(700)
  truncate table t_sdo_item_data
  truncate table t_sdo_item_shop
  set @strQuery = 'insert into t_sdo_item_data select * from ['+@SDO_ServerIP+'].gamedb.dbo.t_sdo_item_data '
  execute(@strQuery)
  set @strQuery = 'insert into t_sdo_item_Shop select * from ['+@SDO_ServerIP+'].gamedb.dbo.t_sdo_item_Shop '
  execute(@strQuery)
end







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE      procedure SDO_ItemData_Query
@SDO_ServerIP varchar(30),
@SDO_Name varchar(20)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select itemcode,Name,minlevel from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_data  where name like '''+ '%'+ @SDO_Name+  '%'+''''
  execute(@strQuery)
  print(@strQuery)
end







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




CREATE  procedure SDO_ItemLimit_Query
@SDO_productID int
as
begin
  select dayslimit from T_sdo_item_shop where ProductID=@SDO_productID
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

























/*********************************************************************************/
/*	SP NAME : SDO_ItemShop_Insert		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 往玩家禮物盒寫道具		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                     procedure SDO_ItemShop_Insert
@Gm_UserID 		varchar(20),
@SDO_ServerIP 		varchar(30),
@SDO_UserIndexID 	varchar(20),
@SDO_Title		varchar(40),
@SDO_Content		varchar(400),
@SDO_Itemcode 		varchar(20),
@SDO_TimesLimit		varchar(8),
@SDO_DateLimit		smalldatetime
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)  
  declare @strQuery varchar(500)
  declare @sendNick varchar(30)
  declare @ERRNO    int	
  set @sendNick = '＊熱舞GM＊'
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
/*
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' insert into ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Message (ReceiverIndexID,SenderNickName,Title,Content,itemcode,timeslimit,datelimit)  values ('''+@SDO_UserIndexID+''','''+@sendNick+''','''+@SDO_Title+''','''+@SDO_Content+''','''+@SDO_Itemcode+''','''+@SDO_TimesLimit+''','''+substring(convert(varchar, @SDO_DateLimit, 20), 1,10)+''') '
  execute(@strQuery)
 
IF (@@rowcount <> 1)
*/
  if (@SDO_Itemcode = '1000001')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+1 WHERE (medal&1)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000002')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+2 WHERE (medal&2)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000003')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+4 WHERE (medal&4)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000004')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+8 WHERE (medal&8)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000005')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+16 WHERE (medal&16)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000006')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+32 WHERE (medal&32)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000007')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+64 WHERE (medal&64)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000008')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+128 WHERE (medal&128)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000009')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+256 WHERE (medal&256)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000010')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+512 WHERE (medal&512)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000011')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+1024 WHERE (medal&1024)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else if(@SDO_Itemcode = '1000012')
  begin
	set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_chhiscore SET medal = medal+2048 WHERE (medal&2048)=0 and userindexid ='+convert(varchar,@SDO_UserIndexID)
  end
  else
  begin
	set @strQuery = ' insert into ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Message (ReceiverIndexID,SenderNickName,Title,Content,itemcode,timeslimit,datelimit)  values ('''+@SDO_UserIndexID+''','''+@sendNick+''','''+@SDO_Title+''','''+@SDO_Content+''','''+@SDO_Itemcode+''','''+@SDO_TimesLimit+''','''+substring(convert(varchar, @SDO_DateLimit, 20), 1,10)+''') '
  end
  
  execute(@strQuery)
  if (@@rowcount > 0) 
  begin
	  --备份本次操作之前的数据，拼成sql语句写入GMTools_Log_UpdateAgo表
	  set @strQuery = 'insert into GMTools_Log_UpdateAgo (UserID,SP_Name,ServerIP,Real_Act) values ( '+convert(varchar,@Gm_UserID)+' ,''SDO_ItemShop_Insert'' ,'''+rtrim(@SDO_ServerIP)+''',''delete  from ['+rtrim(@SDO_ServerIP)+'].sdo.dbo.T_sdo_item where UserIndexID='+@SDO_UserIndexID+' and itemcode='+@SDO_Itemcode+''')'
	  print @strQuery
	  execute(@strQuery)
  end 
  IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_ItemShop_Insert','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加玩家'+@SDO_UserIndexID+'的道具'+@SDO_Itemcode+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_ItemShop_Insert','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加玩家'+@SDO_UserIndexID+'的道具'+@SDO_Itemcode+'的資訊成功')	
	set @strQuery = 'insert into GMTools_SDO_Message select  '''+@SDO_UserIndexID+''' as ReceiverIndexID,'''+@sendNick+''' as SenderNickName,'''+@SDO_Title+''' as Title,'''+@SDO_Content+''' as Content,getdate() as WriteDate,'''+@SDO_Itemcode+''' as itemcode,'''+@SDO_TimesLimit+''' as timeslimit,'''+substring(convert(varchar, @SDO_DateLimit, 20), 1,10)+''' as datelimit,'''+@SDO_Content+''' as SendReason,'''+@Gm_UserID+''' as GM_User,userid as ReceiverUserID,usernick as receiverNick from ['+@SDO_ServerIP+'].gamedb.dbo.member where [id]='''+@SDO_UserIndexID+''''
	print 	@strQuery
	execute(@strQuery)	
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO










CREATE       procedure SDO_ItemShop_Query
@SDO_ServerIP varchar(30),
@SDO_UserIndexID varchar(10)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select d.itemcode,d.Name,d.minlevel,c.itemposition,c.timeslimit,c.datelimit from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item c,T_sdo_item_data d where c.itemcode=d.itemcode and c.userindexid='+@SDO_userIndexID+''
  execute(@strQuery)
  print(@strQuery)
end









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE        procedure SDO_ItemShop_QueryG
@SDO_ServerIP varchar(30),
@SDO_Itemcode varchar(10)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select descryption,timeslimit,dayslimit from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_shop where itemcode = '+@SDO_Itemcode+' and moneytype =0'
  execute(@strQuery)
end












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE        procedure SDO_ItemShop_QueryM
@SDO_ServerIP varchar(30),
@SDO_Itemcode varchar(10)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select descryption,timeslimit,dayslimit from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_shop where itemcode = '+@SDO_Itemcode+' and moneytype =1'
  execute(@strQuery)
end












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













--SDO_ItemShop_Query_ALL '127.0.0.1','0','103',''



CREATE             procedure SDO_ItemShop_Query_ALL
@SDO_ServerIP varchar(30),
@SDO_BigType varchar(5),
@SDO_SmallType varchar(5),
@SDO_ItemName varchar(50)
as
begin
  declare @strQuery varchar(700)
/*
  set @strQuery = 'select distinct b.itemcode,a.name,b.timeslimit,b.dayslimit from ['+@SDO_ServerIP+'].gamedb.dbo.t_sdo_item_data a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_shop b where a.itemcode=b.itemcode and a.name is not null and bigtype='+@SDO_BigType+' and smalltype='+@SDO_SmallType
  --set @strQuery = 'select distinct itemcode,name from ['+@SDO_ServerIP+'].gamedb.dbo.t_o2jam_item_data where name is not null and bigtype='+@SDO_BigType+' and smalltype='+@SDO_SmallType
--set @strQuery = 'select top 10 * from ['+@SDO_ServerIP+'].gamedb.dbo.t_o2jam_item_data where name is not null '
  execute(@strQuery)
  print(@strQuery)
*/
  if convert(int,@SDO_BigType)=3
    set @strQuery = 'select distinct a.bigtype,a.smalltype,a.itemcode,a.name,0 as timeslimit ,0 as dayslimit from t_sdo_item_data a where  a.name is not null and bigtype='+@SDO_BigType+' and smalltype='+@SDO_SmallType
  else if convert(int,@SDO_BigType)=2
   set @strQuery = 'select distinct b.bigtype,b.smalltype,b.itemcode,b.name,0 as timeslimit,0 as dayslimit from ['+@SDO_ServerIP+'].gamedb.dbo.t_sdo_set_info a,t_sdo_item_data b where a.setid=b.itemcode and b.bigtype=2 and a.settype='+@SDO_SmallType
  else if convert(int,@SDO_BigType)=0 and convert(int,@SDO_SmallType)=0 and len(@SDO_ItemName)>0
    set @strQuery = 'select distinct a.bigtype,a.smalltype,a.itemcode,a.name,case  when b.timeslimit is null then -1 else b.timeslimit end,case when b.dayslimit is null then -1 else b.dayslimit end from t_sdo_item_data a left outer join T_sdo_item_shop b on a.itemcode=b.itemcode where Name like '''+ '%'+ @SDO_ItemName+  '%'+''' '
  else
  set @strQuery = 'select distinct a.bigtype,a.smalltype,a.itemcode,a.name,b.timeslimit,b.dayslimit from t_sdo_item_data a,T_sdo_item_shop b where a.itemcode=b.itemcode and a.name is not null and a.bigtype='+@SDO_BigType+' and a.smalltype='+@SDO_SmallType
  --set @strQuery = 'select distinct itemcode,name from ['+@SDO_ServerIP+'].sdo.dbo.T_sdo_item_data where name is not null and bigtype='+@SDO_BigType+' and smalltype='+@SDO_SmallType
  execute(@strQuery)
  print(@strQuery)

end











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











/*********************************************************************************/
/*	SP NAME : SDO_ItemShop_del			 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 刪除玩家身上咚咚*/
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/







CREATE             procedure SDO_ItemShop_del
@Gm_UserID 		int,
@SDO_ServerIP 		varchar(30),
@SDO_UserIndexID 	varchar(20),
@SDO_Itemcode 		varchar(20)
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50) 
  declare @strQuery varchar(5000)
  declare @ERRNO    int	
  set @strQuery = 'select UserIndexID from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item where UserIndexID='''+@SDO_UserIndexID+'''  and itemcode='''+@SDO_Itemcode+''''
  execute(@strQuery)
  if (@@rowcount > 0) 
  begin
	  --備份本次操作之前的資料，拼成sql語句寫入GMTools_Log_UpdateAgo表
	  set @strQuery = 'insert into GMTools_Log_UpdateAgo (UserID,SP_Name,ServerIP,Real_Act) select '+convert(varchar,@Gm_UserID)+' ,''SDO_ItemShop_del'' ,'''+rtrim(@SDO_ServerIP)+''',''insert into ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_Message  (ReceiverIndexID,SenderNickName,Title,Content,itemcode,timeslimit,datelimit) values (''''''+convert(varchar,UserIndexID)+'''''',''''勁舞團gm'''',''''勁舞團gm'''',''''勁舞團gm'''',''''''+convert(varchar,itemcode)+'''''',''''''+convert(varchar,timeslimit)+'''''',''''''+convert(varchar,datelimit)+'''''')''  from ['+rtrim(@SDO_ServerIP)+'].gamedb.dbo.T_sdo_item where UserIndexID='''+@SDO_UserIndexID+''' and itemcode='''+@SDO_Itemcode+''''
	  print @strQuery
	  execute(@strQuery)
  end  
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' delete from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item  where itemcode='''+@SDO_Itemcode+''' and UserIndexID= '''+@SDO_UserIndexID+''''
  execute(@strQuery)
  


IF (@@ROWCOUNT = 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_ItemShop_del',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除玩家'+@SDO_UserIndexID+'身上道具的'+@SDO_Itemcode+'資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_ItemShop_del',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除玩家'+@SDO_UserIndexID+'身上道具的'+@SDO_Itemcode+'資訊成功')	
		SELECT @ERRNO = 1
	END
RETURN @ERRNO
end








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO










/*********************************************************************************/
/*	SP NAME : SDO_Login_Clear			 */
/*	MOD DATE: 2007-2-6				 */
/*	EDITOR  : Andy							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 将异常玩家踢下线*/
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/




CREATE                      procedure SDO_Login_Clear
@Gm_UserID 		int,
@SDO_ServerIP 		varchar(30),
@SDO_GateWayIP varchar(30)


as
set nocount on
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50) 
  declare @strQuery varchar(5000)
  declare @ERRNO    int	

  set @strQuery = 'select User_Index_ID from  ['+@SDO_ServerIP+'].gamedb.dbo.T_SDO_Login  where GATEWAY_ID='''+@SDO_GateWayIP+''''
  print @strQuery
  execute(@strQuery) 
  --根据id取出用户真实姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根据ip取出对应的服务器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' delete  from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Login    where GateWAY_ID= '''+@SDO_GateWayIP+''''
  print @strQuery
  execute(@strQuery)


IF (@@ROWCOUNT = 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Login_Clear','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'服務器踢出異常玩家'+@SDO_GateWayIP+'失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Login_Clear','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'服務器踢出異常玩家'+@SDO_GateWayIP+'成功')	
		SELECT @ERRNO = 1
	END
RETURN @ERRNO
end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO









CREATE       procedure SDO_Login_Status
@SDO_serverip varchar(30),
@SDO_UserID varchar(20)
as
begin

declare @strQuery varchar(500)

set @strQuery = 'select user_id,main_ch,sub_ch,addr_ip,login_time,addr_ip from ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_login  where user_ID='''+@SDO_UserID+''''
print @strQuery
execute(@strQuery)

end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







--execute SDO_Login_del 1,'61.172.206.186','likoo520'


/*********************************************************************************/
/*	SP NAME : SDO_Login_del			 */
/*	MOD DATE: 2007-2-6				 */
/*	EDITOR  : Andy							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 将异常玩家踢下线*/
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/




CREATE                     procedure SDO_Login_del
@Gm_UserID 		int,
@SDO_ServerIP 		varchar(30),
@SDO_UserID 	varchar(20)

as
set nocount on
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50) 
  declare @strQuery varchar(5000)
  declare @ERRNO    int	

  set @strQuery = 'select User_Index_ID from  ['+@SDO_ServerIP+'].gamedb.dbo.T_SDO_Login  where User_ID='''+@SDO_UserID+''''
  execute(@strQuery)
    if (@@rowcount > 0)
    begin
  --if (@@rowcount > 0) 
 -- begin
	  --备份本次操作之前的数据，删除之前的数据拼成sql语句写入GMTools_Log_UpdateAgo表
	--  set @strQuery = 'insert into GMTools_Log_UpdateAgo (UserID,SP_Name,ServerIP,Real_Act) select '+convert(varchar,@Gm_UserID)+' ,''SDO_Login_del'' ,'''+rtrim(@SDO_ServerIP)+''',''insert into ['+rtrim(@SDO_ServerIP)+'].sdo.dbo.T_SDO_Login  (GateWay_ID,Main_CH,SUB_CH,User_Index_ID,User_ID,TUser_ID,Addr_IP,Login_Time,GateWay_Addr,GateWay_Port) values (''''''+convert(varchar,GateWay_ID)+'''''',''''''+convert(varchar,Main_CH)+'''''',''''''+convert(varchar,SUB_CH)+'''''',''''''+convert(varchar,User_Index_ID)+'''''',''''''+convert(varchar,User_ID)+'''''',''''''+convert(varchar,TUser_ID)+'''''',''''''+convert(varchar,Addr_IP)+'''''',''''''+convert(varchar,Login_Time)+'''''',''''''+convert(varchar,GateWay_Addr)+'''''',''''''+convert(varchar,GateWay_Port)+'''''')''  from ['+rtrim(@SDO_ServerIP)+'].O2JAM.dbo.T_SDO_Login   where User_ID='''+@SDO_UserID+''''
	 -- print @strQuery
	  --execute(@strQuery)
  --end  
  --根据id取出用户真实姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根据ip取出对应的服务器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' delete  from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Login    where User_ID= '''+@SDO_UserID+''''
  execute(@strQuery)


IF (@@ROWCOUNT = 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Login_del','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'服務器踢出異常玩家'+@SDO_UserID+'失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_Login_del','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'服務器踢出異常玩家'+@SDO_UserID+'成功')	
		SELECT @ERRNO = 1
	END
      end
    else
     set @ERRNO =-1
print @ERRNO
RETURN @ERRNO
end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












create     procedure SDO_M_log_Query
@SDO_ServerIP varchar(30),
@SDO_UserID   varchar(20),
@SDO_BeginTime     datetime,
@SDO_EndTime     datetime
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select USERID,M_DATE,M_NUM from ['+@SDO_ServerIP+'].logdb.dbo.M_log where USERID = '''+@SDO_UserID+''' and M_DATE >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+'''  and M_DATE <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''' order by M_DATE '
  execute(@strQuery)
end












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












create     procedure SDO_M_log_QuerySum
@SDO_ServerIP varchar(30),
@SDO_UserID   varchar(20),
@SDO_BeginTime     datetime,
@SDO_EndTime     datetime
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select USERID,SUM(M_NUM) as SUM_M_NUM from ['+@SDO_ServerIP+'].logdb.dbo.M_log where USERID = '''+@SDO_UserID+''' and M_DATE >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+'''  and M_DATE <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''' group by USERID '
  execute(@strQuery)
end












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE          procedure SDO_MemberDance_Close
@GM_UserID int,
@SDO_serverIP varchar(30),
@SDO_UserID varchar(20)
as
begin

declare @strQuery varchar(500)
declare @RealName varchar(50)
declare @city varchar(50)
declare @ERRNO char(1)
set @strQuery = 'Update ['+@SDO_serverIP+'].SDO.dbo.Member set ispad =0 where userID='''+@SDO_UserID+''''
print @strQuery
execute(@strQuery)
IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_MemberDance_Close','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器修不啟動玩家'+@SDO_UserID+'的跳舞毯資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_MemberDance_Close','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器不啟動玩家'+@SDO_UserID+'的跳舞毯資訊成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO

end




--execute SDO_Member_Query '192.168.0.52','dev008'









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE           procedure SDO_MemberDance_Open
@GM_UserID int,
@SDO_serverIP varchar(30),
@SDO_UserID varchar(20)
as
begin

declare @strQuery varchar(500)
declare @RealName varchar(50)
declare @city varchar(50)
declare @ERRNO varchar(1)
set @strQuery = 'Update ['+@SDO_serverIP+'].SDO.dbo.Member set ispad =1 where userID='''+@SDO_UserID+''''
print @strQuery
execute(@strQuery)
IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_MemberDance_Open','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器修啟動玩家'+@SDO_UserID+'的跳舞毯資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_MemberDance_Open','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器啟動玩家'+@SDO_UserID+'的跳舞毯資訊成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO

end




--execute SDO_Member_Query '192.168.0.52','dev008'










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE        procedure SDO_Member_Query
@SDO_serverIP varchar(30),
@SDO_UserID varchar(20)
as
begin

declare @strQuery varchar(500)

set @strQuery = 'select M.userid,M.id9you,M.usernick,M.sex,M.registdate,M.firstlogintime,M.lastlogintime,T.firstpadtime'
		+ ' from ['+@SDO_serverIP+'].gamedb.dbo.Member as M left join ['+@SDO_serverIP+'].gamedb.dbo.T_sdo_first_pad_time as T on M.userid = T.userid'
		+ ' where M.userID='''+@SDO_UserID+''''
print @strQuery
execute(@strQuery)

end









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Challenge_Del		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                          procedure SDO_TO2JAM_Challenge_Del
@Gm_UserID 		varchar(20),
@SDO_ServerIP 		varchar(30),
@SDO_SceneID 		int
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)  
  declare @strQuery varchar(500)
  declare @sendNick varchar(30)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' delete from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Challenge where ID='''+Convert(varchar,@SDO_SceneID)+''''
  execute(@strQuery)
 
IF (@@rowcount <> 1)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Challenge_Del','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除'+Convert(varchar,@SDO_SceneID)+'的場景的資訊失敗')	
	SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Challenge_Del','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除'+Convert(varchar,@SDO_SceneID)+'的場景的資訊成功')	
	print 	@strQuery	
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end













GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Challenge_Insert		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                          procedure SDO_TO2JAM_Challenge_Insert
@Gm_UserID 		varchar(20),
@SDO_ServerIP 		varchar(30),
--@SDO_SceneID 		int,
@SDO_WeekDay		int,
@SDO_MatPtHR		int,
@SDO_MatPtMin 		int,
@SDO_StPtHR		INT,
@SDO_StPtMin		INT,
@SDO_EdPtHR		INT,
@SDO_EdPtMin		INT,
@SDO_GCash		INT,
@SDO_MCash		INT,
@SDO_Sence		INT,
@SDO_MusicID1		INT,
@SDO_LV1		INT,
@SDO_MusicID2		INT,
@SDO_LV2		INT,
@SDO_MusicID3		INT,
@SDO_LV3		INT,
@SDO_MusicID4		INT,
@SDO_LV4		INT,
@SDO_MusicID5		INT,
@SDO_LV5		INT
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)  
  declare @strQuery varchar(500)
  declare @sendNick varchar(30)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' insert into ['+@SDO_ServerIP+'].gamedb.dbo.T_SDO_Challenge (WeekDay,MatPt_HR,MatPt_Min,StPt_HR,StPt_Min,EdPt_HR,EdPt_Min,GCash,MCash,Scene,MusicID1,LV1,MusicID2,LV2,MusicID3,LV3,MusicID4,LV4,MusicID5,LV5)  values ('''+Convert(varchar,@SDO_WeekDay)+''','''+Convert(varchar,@SDO_MatPtHR)+''','''+convert(varchar,@SDO_MatPtMin)+''','''+convert(varchar,@SDO_StPtHR)+''','''+convert(varchar,@SDO_StPtMin)+''','''+Convert(varchar,@SDO_EdPtHR)+''','''+convert(varchar, @SDO_EdPtMin)+''','''+convert(varchar,@SDO_GCash)+''','''+convert(varchar,@SDO_MCash)+''','''+convert(varchar,@SDO_Sence)+''','''+convert(varchar,@SDO_MusicID1)+''','''+convert(varchar,@SDO_LV1)+''','''+convert(varchar,@SDO_MusicID2)+''','''+convert(varchar,@SDO_LV2)+''','''+convert(varchar,@SDO_MusicID3)+''','''+convert(varchar,@SDO_LV3)+''','''+convert(varchar,@SDO_MusicID4)+''','''+convert(varchar,@SDO_LV4)+''','''+convert(varchar,@SDO_MusicID5)+''','''+convert(varchar,@SDO_LV5)+''') '
  execute(@strQuery)
 
IF (@@rowcount <> 1)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Challenge_Insert','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加遊戲場景'+Convert(varchar,@SDO_Sence)+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Challenge_Insert','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加遊戲的場景'+Convert(varchar,@SDO_Sence)+'的資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end


















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Challenge_Query		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 查詢遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                            procedure SDO_TO2JAM_Challenge_Query
@SDO_ServerIP 		varchar(30)
as
begin
  declare @strQuery varchar(2000)
  declare @ERRNO    int	
  set @strQuery = ' select ID, [WeekDay],MatPt_hr,MatPt_min,StPt_hr,StPt_min,EdPt_hr,EdPt_min,GCash,MCash,SceneID,SceneTag,MusicID1,Lv1,MusicID2,Lv2,MusicID3 ,Lv3,MusicID4,Lv4,MusicID5,Lv5 from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Challenge a,SDO_Scene b where a.Scene=b.SceneID order by ID desc'
  print @strQuery
  execute(@strQuery)
 
end
























GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
































/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Challenge_Update		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                            procedure SDO_TO2JAM_Challenge_Update
@Gm_UserID 		varchar(20),
@SDO_ServerIP 		varchar(30),
@SDO_SceneID 		int,
@SDO_WeekDay		varchar(40),
@SDO_MatPtHR		varchar(400),
@SDO_MatPtMin 		varchar(20),
@SDO_StPtHR		INT,
@SDO_StPtMin		INT,
@SDO_EdPtHR		INT,
@SDO_EdPtMin		INT,
@SDO_GCash		INT,
@SDO_MCash		INT,
@SDO_Sence		INT,
@SDO_MusicID1		INT,
@SDO_LV1		INT,
@SDO_MusicID2		INT,
@SDO_LV2		INT,
@SDO_MusicID3		INT,
@SDO_LV3		INT,
@SDO_MusicID4		INT,
@SDO_LV4		INT,
@SDO_MusicID5		INT,
@SDO_LV5		INT
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)  
  declare @strQuery varchar(2000)
  declare @sendNick varchar(30)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = 'Insert into GMTools_Log_UpdateAgo (UserID,SP_Name,ServerIP,Real_Act) values (@Gm_UserID,''SDO_TO2JAM_Challenge_Update'','''+@SDO_ServerIP+''',''update ['+@SDO_ServerIP+'].linshi.dbo.T_sdo_Challenge set WeekDay='''+Convert(varchar,@SDO_WeekDay)+''',MatPt_HR='''+Convert(varchar,@SDO_MatPtHR)+''',MatPt_Min='''+Convert(varchar,@SDO_MatPtMin)+''',StPt_HR='''+convert(varchar,@SDO_StPtHR)+''',StPt_Min='''+Convert(varchar,@SDO_StPtMin)+''',EdPt_HR='''+Convert(varchar,@SDO_EdPtHR)+''',EdPt_Min='''+Convert(varchar,@SDO_EdPtMin)+''',GCash='''+Convert(varchar,@SDO_GCash)+''',MCash='''+Convert(varchar,@SDO_MCash)+''',Scene='''+Convert(varchar,@SDO_Sence)+''',MusicID1='''+Convert(varchar,@SDO_MusicID1)+''',LV1='''+Convert(varchar,@SDO_LV1)+''',MusicID2='''+Convert(varchar,@SDO_MusicID2)+''',LV2='''+Convert(varchar,@SDO_LV2)+''',MusicID3='''+Convert(varchar,@SDO_MusicID3)+''',LV3='''+Convert(varchar,@SDO_LV3)+''',MusicID4='''+Convert(varchar,@SDO_MusicID4)+''',LV4='''+Convert(varchar,@SDO_LV4)+''',MusicID5='''+Convert(varchar,@SDO_MusicID5)+''',LV5='''+Convert(varchar,@SDO_LV5)+''' select [WeekDay],MatPt_hr,MatPt_min,StPt_hr,StPt_min,EdPt_hr,EdPt_min,GCash,MCash,Scene,MusicID1,Lv1,MusicID2,Lv2,MusicID3 ,Lv3,MusicID4,Lv4,MusicID5,Lv5 from  ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Challenge where ID='''+Convert(varchar,@SDO_SceneID)+''') '
  print @strQuery
  set @strQuery = ' update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_Challenge set WeekDay='''+Convert(varchar,@SDO_WeekDay)+''',MatPt_HR='''+Convert(varchar,@SDO_MatPtHR)+''',MatPt_Min='''+Convert(varchar,@SDO_MatPtMin)+''',StPt_HR='''+convert(varchar,@SDO_StPtHR)+''',StPt_Min='''+Convert(varchar,@SDO_StPtMin)+''',EdPt_HR='''+Convert(varchar,@SDO_EdPtHR)+''',EdPt_Min='''+Convert(varchar,@SDO_EdPtMin)+''',GCash='''+Convert(varchar,@SDO_GCash)+''',MCash='''+Convert(varchar,@SDO_MCash)+''',Scene='''+Convert(varchar,@SDO_Sence)+''',MusicID1='''+Convert(varchar,@SDO_MusicID1)+''',LV1='''+Convert(varchar,@SDO_LV1)+''',MusicID2='''+Convert(varchar,@SDO_MusicID2)+''',LV2='''+Convert(varchar,@SDO_LV2)+''',MusicID3='''+Convert(varchar,@SDO_MusicID3)+''',LV3='''+Convert(varchar,@SDO_LV3)+''',MusicID4='''+Convert(varchar,@SDO_MusicID4)+''',LV4='''+Convert(varchar,@SDO_LV4)+''',MusicID5='''+Convert(varchar,@SDO_MusicID5)+''',LV5='''+Convert(varchar,@SDO_LV5)+''' where ID='''+Convert(varchar,@SDO_SceneID)+''''
  execute(@strQuery)
 
IF (@@rowcount <> 1)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Challenge_Update','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器修改'+Convert(varchar,@SDO_SceneID)+'的場景的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Challenge_Update','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器修改'+Convert(varchar,@SDO_SceneID)+'的場景的資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end
























GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Challenge_Insert		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                                procedure SDO_TO2JAM_Medalitem_Delete
@Gm_UserID 		varchar(20),
@SDO_ServerIP 		varchar(30),
@SDO_ItemCode int
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)  
  declare @strQuery varchar(1000)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = ' delete from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_medalitem  where code='''+Convert(varchar,@SDO_ItemCode)+''' '
  print @strQuery
  execute(@strQuery)
 
IF (@@rowcount  = 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Medalitem_Delete','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除在場景獲得道具概率的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Medalitem_Delete','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器刪除在場景獲得道具概率資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end





























GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Challenge_Insert		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE                               procedure SDO_TO2JAM_Medalitem_Insert
@Gm_UserID 		varchar(20),
@SDO_ServerIP 		varchar(30),
@SDO_ItemCode int,
@SDO_Percent int,
@SDO_timeslimit int,
@SDO_DaysLimit int 
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)  
  declare @strQuery varchar(500)
  declare @sendNick varchar(30)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  TRUNCATE TABLE remote
  set @strQuery = 'insert into remote (number) select count(*) as number from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_medalitem where code='''+Convert(varchar,@SDO_ItemCode)+''''
  --print @strQuery
  execute(@strQuery)
    if @SDO_DaysLimit = 0
    set @SDO_DaysLimit = -1
  IF (select number from remote) <>1
     set @strQuery = ' insert into ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_medalitem (Code,perc,timeslimit,dayslimit)  values ('''+Convert(varchar,@SDO_ItemCode)+''','''+Convert(varchar,@SDO_Percent)+''','''+convert(varchar,@SDO_timeslimit)+''','''+convert(varchar,@SDO_DaysLimit)+''') '
  else
     set @strQuery = ' update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_medalitem set perc='''+Convert(varchar,@SDO_Percent)+''',timeslimit='''+convert(varchar,@SDO_timeslimit)+''',dayslimit='''+convert(varchar,@SDO_DaysLimit)+''' where code='''+Convert(varchar,@SDO_ItemCode)+''' '
  execute(@strQuery)
 print @strQuery
IF (@@rowcount <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Medalitem_Insert','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加遊戲在場景獲得道具概率'+Convert(varchar,@SDO_Percent)+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Medalitem_Insert','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加遊戲的在場景獲得道具概率'+Convert(varchar,@SDO_Percent)+'的資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




































/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Medalitem_Query		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 查詢遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                                procedure SDO_TO2JAM_Medalitem_Own_Query
@SDO_ServerIP 		varchar(30),
@SDO_Name varchar(50)
as
begin
  declare @strQuery varchar(2000)
  declare @ERRNO    int	
  set @strQuery = ' select a.code,b.name,a.perc,a.timeslimit,a.dayslimit from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_medalitem a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_data b where a.code=b.itemcode and b.Name like ''%'+@SDO_Name+'%'''
  execute(@strQuery)
 
end




























GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Medalitem_Query		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 查詢遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                                procedure SDO_TO2JAM_Medalitem_Query
@SDO_ServerIP 		varchar(30)
as
begin
  declare @strQuery varchar(2000)
  declare @ERRNO    int	
  set @strQuery = ' select a.code,b.name,a.perc,a.timeslimit,a.dayslimit from ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_medalitem a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_data b where a.code=b.itemcode'
  execute(@strQuery)
 
end




























GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



































/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Medalitem_Update		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                               procedure SDO_TO2JAM_Medalitem_Update
@Gm_UserID 		varchar(20),
@SDO_ServerIP 		varchar(30),
@SDO_ItemCode int,
@SDO_Percent int,
@SDO_timeslimit int,
@SDO_DaysLimit int 
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)  
  declare @strQuery varchar(500)
  declare @sendNick varchar(30)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
    if @SDO_DaysLimit = 0
    set @SDO_DaysLimit = -1
  set @strQuery = ' update ['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_medalitem set perc='''+Convert(varchar,@SDO_Percent)+''',timeslimit='''+convert(varchar,@SDO_timeslimit)+''',dayslimit='''+convert(varchar,@SDO_DaysLimit)+''' where code='''+Convert(varchar,@SDO_ItemCode)+''' '
  execute(@strQuery)
 
IF (@@rowcount = 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Medalitem_Update','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器更新遊戲在場景獲得道具概率'+Convert(varchar,@SDO_Percent)+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,serverIP,Real_Act) values (@Gm_UserID,'SDO_TO2JAM_Medalitem_Update','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器更新遊戲的在場景獲得道具概率'+Convert(varchar,@SDO_Percent)+'的資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end



























GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_MusicData_Query		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                       procedure SDO_TO2JAM_MusicData_Query
@SDO_ServerIP 		varchar(30)
as
begin
  declare @strQuery varchar(2000)
  declare @ERRNO    int	
  set @strQuery = ' select ID,title from ['+@SDO_ServerIP+'].gamedb.dbo.t_sdo_music_data'
  execute(@strQuery)
 
end



















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_MusicData_Query		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                      procedure SDO_TO2JAM_MusicData_SingleQuery
@SDO_ServerIP 		varchar(30),
@SDO_MusicID int
as
begin
  declare @strQuery varchar(2000)
  declare @ERRNO    int	
  set @strQuery = ' select title from ['+@SDO_ServerIP+'].gamedb.dbo.t_sdo_music_data where ID='''+convert(varchar,@SDO_MusicID)+''''
  execute(@strQuery)
 
end


















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Scene_Update		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

Create                       procedure SDO_TO2JAM_Scene_Delete
@Gm_UserID 		varchar(20),
@SDO_SceneID int

as
begin
  declare @RealName  varchar(50)
  declare @strQuery varchar(500)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID

  set @strQuery = ' delete from SDO_Scene  where SceneID='''+convert(varchar,@SDO_SceneID)+''''
  execute(@strQuery)
 
IF (@@rowcount <> 1)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,'操作員'+@RealName+'在超級舞者刪除遊戲場景的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,'操作員'+@RealName+'在超級舞者刪除遊戲的場景的資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end




















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Challenge_Insert		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

Create                       procedure SDO_TO2JAM_Scene_Insert
@Gm_UserID 		varchar(20),
@SDO_SceneID int,
@SDO_SceneTag		varchar(50)

as
begin
  declare @RealName  varchar(50)
  declare @strQuery varchar(500)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID

  set @strQuery = ' insert into  SDO_Scene (SceneID,SceneTag)  values ('''+convert(varchar,@SDO_SceneID)+''','''+@SDO_SceneTag+''') '
  execute(@strQuery)
 
IF (@@rowcount <> 1)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,'操作員'+@RealName+'在超級舞者添加場景'+@SDO_SceneTag+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,'操作員'+@RealName+'在超級舞者添加遊戲的場景'+@SDO_SceneTag+'的資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end



















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Scene_Update		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

CREATE                        procedure SDO_TO2JAM_Scene_Query
as
begin
  declare @strQuery varchar(500)
  declare @ERRNO    int	

  set @strQuery = 'select * from SDO_Scene order by sceneID'
  execute(@strQuery)
 
end

-- exec SDO_TO2JAM_Scene_Query 



















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



























/*********************************************************************************/
/*	SP NAME : SDO_TO2JAM_Scene_Update		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加遊戲的場景		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/

Create                       procedure SDO_TO2JAM_Scene_Update
@Gm_UserID 		varchar(20),
@SDO_SceneID int,
@SDO_SceneTag		varchar(50)

as
begin
  declare @RealName  varchar(50)
  declare @strQuery varchar(500)
  declare @ERRNO    int	
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID

  set @strQuery = ' update SDO_Scene set SceneTag='''+@SDO_SceneTag+''' where SceneID='''+convert(varchar,@SDO_SceneID)+''''
  execute(@strQuery)
 
IF (@@rowcount <> 1)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,'操作員'+@RealName+'在超級舞者更新場景'+@SDO_SceneTag+'的資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,'操作員'+@RealName+'在超級舞者更新遊戲的場景'+@SDO_SceneTag+'的資訊成功')	
	print 	@strQuery
	SELECT @ERRNO = 1
	END

RETURN @ERRNO
end



















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE       procedure SDO_T_send_record_QueryRev
@SDO_ServerIP varchar(30),
@SDO_RevNick   varchar(30),
@SDO_BeginTime     datetime,
@SDO_EndTime     datetime
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select a.sendtime,a.senderUserID,a.receiverNick,b.descryption,b.timeslimit,b.moneycost,c.city,c.gamename from ['+@SDO_ServerIP+'].logdb.dbo.T_send_record a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_shop b,GMTools_Serverinfo c  where a.sendtime  >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and a.sendtime  <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''' and b.moneytype=1 and a.receiverNick='''+@SDO_RevNick+'''and c.serverip='''+@SDO_ServerIP+''''
  execute(@strQuery)
end













GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














CREATE       procedure SDO_T_send_record_QuerySend
@SDO_ServerIP varchar(30),
@SDO_UserID   varchar(20),
@SDO_BeginTime     datetime,
@SDO_EndTime     datetime
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select a.sendtime,a.senderUserID,a.receiverNick,b.descryption,b.timeslimit,b.moneycost,c.city,c.gamename from ['+@SDO_ServerIP+'].logdb.dbo.T_send_record a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_shop b,GMTools_Serverinfo c where a.sendtime  >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and a.sendtime  <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''' and b.moneytype=1 and a.senderuserID='''+@SDO_UserID+''' and c.serverip='''+@SDO_ServerIP+''''
  execute(@strQuery)
end













GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






















--execute SDO_TaskList_Insert 48,'61.151.249.172,',"又一个脱衣门！又一个桃色事件！又是魔兽玩家！\n\n　　魔兽？干脆改名叫禽兽世界好啦！\n\n　　从铜须开始，桃色事件似乎就爱上了魔兽，当然，我们也不能排除魔兽爱上桃色事件的可能性，这年头，希奇事看多了，什么都有可能。\n\n　　只是，元旦都过了，奥运都近了，魔兽，该买本新日历啦！都07年啦！你Y的别再玩桃色了行不行啊！\n\n　　此处内容为转载：据传，WOW2区XX服务器女玩家“XXX”（真实姓名：暂隐），广西南宁人，与另一名男玩家在WOW中结识后成为网友并从电话、短信、QQ发展到床上，并完成了“一夜情不够，我们多夜情吧”的网络热门连载小说情节。",'2006-7-1','2006-1-1',5
CREATE              procedure [dbo].[SDO_TaskList_Insert]
@Gm_UserID 		int,
@SDO_ServerIP		varchar(500),
@SDO_BoardMessage varchar(500),
@SDO_begintime datetime,
@SDO_endTime datetime,
@SDO_interval int
as
begin
    declare @var varchar(500)
	declare @identityid int
    insert into  BoardTasker(SendBeginTime, SendEndTime ,Interval ,status,command,BoardMessage) values (@SDO_begintime,@SDO_endTime,@SDO_interval,0,0,@SDO_BoardMessage)
    set @identityid = @@IDENTITY 
    set @var = @SDO_ServerIP
    while charindex(',',@var)>0
        begin
            declare @strQuery varchar(500)
        insert into SDO_BoardMessage (taskID,serverIP,UserID)  values (@identityid,left(@var,charindex(',',@var)-1),@Gm_UserID)
	    set @var=stuff(@var,1,charindex(',',@var),'')
       end
   
    declare  @ERRNO int
   IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,@SDO_ServerIP+'添加公告'+@SDO_BoardMessage+'任务的信息失败')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_LogTime (OperateUserID,OperateMsg) values (@Gm_UserID,@SDO_ServerIP+'添加公告'+@SDO_BoardMessage+'任务的信息成功')	
		SELECT @ERRNO = 1
	END

	RETURN @ERRNO
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




















--execute SDO_TaskList_Update 1, '61.151.249.172,',1,'32132','2006-1-1','2006-1-1',30,1

CREATE              procedure [dbo].[SDO_TaskList_Update]
@Gm_UserID 		int,
@SDO_ServerIP		varchar(300),
@SDO_TaskID int,
@SDO_BoardMessage varchar(500),
@SDO_begintime datetime,
@SDO_endTime datetime,
@SDO_interval int,
@SDO_Status int
as
begin
    declare @var varchar(300)
	declare @identityid int
    if (@SDO_Status =1)
        update   BoardTasker set status = @SDO_Status,command=@SDO_Status  where taskid = @SDO_TaskID
   else
   begin
   update   BoardTasker set SendBeginTime =@SDO_begintime, SendEndTime=@SDO_endTime ,Interval=@SDO_interval ,status=@SDO_status,BoardMessage=@SDO_BoardMessage where taskid = @SDO_TaskID

    set @var = @SDO_ServerIP
     delete from SDO_BoardMessage where taskID = @SDO_TaskID
    while charindex(',',@var)>0
        begin
            declare @strQuery varchar(200)
      
        insert into SDO_BoardMessage (taskID,serverIP,UserID)  values (@SDO_TaskID,left(@var,charindex(',',@var)-1),@Gm_UserID)
	    set @var=stuff(@var,1,charindex(',',@var),'')
	    --print @err
       end
   end
    declare  @ERRNO int
   IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_TaskList_Update','超级舞者',@SDO_ServerIP,'添加公告任务的信息失败')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_TaskList_Update','超级舞者',@SDO_ServerIP,'添加公告任务的信息成功')	
		SELECT @ERRNO = 1
	END

	RETURN @ERRNO
end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO













CREATE         procedure SDO_UserConsume_Query
@SDO_ServerIP varchar(30),
@SDO_UserID  varchar(20),
@SDO_MoneyType char(1),
@SDO_BeginTime     datetime,
@SDO_EndTime     datetime

as
begin
  declare @strQuery varchar(500)
  if @SDO_MoneyType =2
  begin
     set @strQuery = 'select userID,productID,productName,moneyCost,moneyType,shoptime from ['+@SDO_ServerIP+'].logdb.dbo.t_shop_record where userID='''+@SDO_UserID+''' and shoptime >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and shoptime <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''' order by shoptime desc'
  end
  else if @SDO_MoneyType = 4
  begin
     set @strQuery = 'select userID,productID,productName,moneyCost/1000 as moneyCost,moneyType,shoptime from ['+@SDO_ServerIP+'].logdb.dbo.t_shop_record where  userID='''+@SDO_UserID+''' and moneytype='+@SDO_MoneyType+' and shoptime >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and shoptime <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''' order by shoptime desc'
  end
  else
  begin
    set @strQuery = 'select userID,productID,productName,moneyCost,moneytype,shoptime from ['+@SDO_ServerIP+'].logdb.dbo.t_shop_record where userID='''+@SDO_UserID+''' and moneytype='+@SDO_MoneyType+' and shoptime >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and shoptime <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''' order by shoptime desc'
  end
  execute(@strQuery)
  --print(@strQuery)
end

--execute SDO_UserConsume_Query '192.168.6.222','dev001','4','2001-1-2','2006-10-22'






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE           procedure SDO_UserConsume_QuerySum
@SDO_ServerIP varchar(30),
@SDO_UserID  varchar(20),
@SDO_MoneyType char(1),
@SDO_BeginTime     datetime,
@SDO_EndTime     datetime

as
begin
  declare @strQuery varchar(500)
  if @SDO_MoneyType =2
  begin
     set @strQuery = 'select sum(moneyCost) from ['+@SDO_ServerIP+'].logdb.dbo.t_shop_record where userID='''+@SDO_UserID+''' and shoptime >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and shoptime <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''''
  end
  else if @SDO_MoneyType =4
  begin
     set @strQuery = 'select sum(moneyCost/1000) from ['+@SDO_ServerIP+'].logdb.dbo.t_shop_record where  userID='''+@SDO_UserID+''' and moneytype='+@SDO_MoneyType+' and shoptime >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and shoptime <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''''
  end
  else
  begin
    set @strQuery = 'select sum(moneyCost) from ['+@SDO_ServerIP+'].logdb.dbo.t_shop_record where userID='''+@SDO_UserID+''' and moneytype='+@SDO_MoneyType+' and shoptime >='''+substring(convert(varchar, @SDO_BeginTime, 20), 1,10)+''' and shoptime <='''+substring(convert(varchar, @SDO_EndTime, 20), 1,10)+''''
  end
  execute(@strQuery)
  --print(@strQuery)
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














create       procedure SDO_UserGcash_Query
@SDO_ServerIP varchar(30),
@SDO_UserID   varchar(20)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select USERID,GCash from ['+@SDO_ServerIP+'].gamedb.dbo.UserMcash where USERID = '''+@SDO_UserID+''' '
  execute(@strQuery)
end












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












--SDO_UserIntegral_QuerySum '127.0.0.1','twgamanet001'


CREATE           procedure SDO_UserIntegral_QuerySum
@SDO_ServerIP varchar(30),
@SDO_UserID  varchar(20)

as
begin
  declare @strQuery varchar(500)

   set @strQuery = 'select sum(moneyCost/1000) from ['+@SDO_ServerIP+'].logdb.dbo.t_shop_record where  userID='''+@SDO_UserID+''' and moneytype=''4'''
   print(@strQuery)
   execute(@strQuery)
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















/*********************************************************************************/
/*	SP NAME : SDO_UserMcash_AddG		 */
/*	MOD DATE: 2006-3-30					 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : 加G幣		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/





CREATE             procedure SDO_UserMcash_AddG
@Gm_UserID	int,
@SDO_ServerIP varchar(30),
@SDO_UserID   varchar(20),
@SDO_GCash    varchar(10)
as
begin
  declare @RealName  varchar(50)
  declare @city  varchar(50)
  declare @strQuery varchar(700)
  declare @ERRNO int
  --根據id取出用戶真實姓名
  select @RealName = RealName from GMTools_Users where UserID = @Gm_UserID
  --根據ip取出對應的伺服器名
  select @city = city from GMTools_Serverinfo where serverip=rtrim(@SDO_ServerIP)
  set @strQuery = 'select userid  from ['+@SDO_serverIP+'].gamedb.dbo.Member where userID='''+@SDO_UserID+''''
  --print @strQuery
  execute(@strQuery)
   IF @@ROWCOUNT <> 1
        begin
   		SELECT @ERRNO = -1
        end
  else 
  begin
   
    set @strQuery = 'select userid  from ['+@SDO_serverIP+'].gamedb.dbo.UserMcash where userID='''+@SDO_UserID+''''
    execute(@strQuery)
   IF @@ROWCOUNT <> 1
        begin
            set @strQuery = 'insert into ['+@SDO_ServerIP+'].gamedb.dbo.UserMcash (userID,GCash) values ('''+@SDO_UserID+''','''+@SDO_GCash+''')'
	    print  @strQuery
	    execute(@strQuery)
        end
    else
    begin
	    set @strQuery = 'update ['+@SDO_ServerIP+'].gamedb.dbo.UserMcash  set GCash=GCash+'''+@SDO_GCash+''' where USERID = '''+@SDO_UserID+''' '
	    print  @strQuery
	    execute(@strQuery)
    end
end
IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_UserMcash_AddG','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加玩家'+@SDO_UserID+'G幣'+@SDO_GCash+'的操作失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_UserMcash_AddG','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器添加玩家'+@SDO_UserID+'G幣'+@SDO_GCash+'的操作成功')	
	
SELECT @ERRNO = 1
	END
 end
RETURN @ERRNO









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











create    procedure SDO_UserMcash_Query
@SDO_ServerIP varchar(30),
@SDO_UserID   varchar(20)
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select USERID,MCash,GCash from ['+@SDO_ServerIP+'].gamedb.dbo.UserMcash where USERID = '''+@SDO_UserID+''' '
  execute(@strQuery)
end











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO















CREATE           procedure SDO_UserNick_Update
@GM_UserID int,
@SDO_serverIP varchar(30),
@SDO_UserID varchar(20),
@SDO_UserNick varchar(30)
as
begin

declare @strQuery varchar(500)
declare @RealName varchar(50)
declare @city varchar(50)
declare @ERRNO char(1)
set @strQuery = 'Update ['+@SDO_serverIP+'].SDO.dbo.Member set usernick ='''+@SDO_UserNick+''' where userID='''+@SDO_UserID+''''
print @strQuery
execute(@strQuery)
IF (@@ERROR <> 0)
	BEGIN
		--ROLLBACK TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_UserNick_Update','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器更新'+@SDO_UserID+'的呢稱資訊失敗')	
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN
		--COMMIT TRAN
	insert into GMTools_Log (UserID,SP_Name,Game_Name,ServerIP,Real_Act) values (@Gm_UserID,'SDO_UserNick_Update','超級舞者',@SDO_ServerIP,'操作員'+@RealName+'在超級舞者'+@city+'伺服器更新'+@SDO_UserID+'的呢稱資訊成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO

end




--execute SDO_Member_Query '192.168.0.52','dev008'










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE  procedure SDO_UserOnline_Query
@SDO_ServerIP varchar(30),
@SDO_UserID varchar(20)
as
begin
  declare @strQuery varchar(500)
  set @strQuery = 'select * from ['+@SDO_ServerIP+'].logdb.dbo.t_login_logout_record where userID='''+@SDO_UserID+''' order by logintime desc'
  execute(@strQuery)
  print(@strQuery)
end




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






--SDO_UserTrade_Query '127.0.0.1','twgamanet003',''


CREATE                procedure SDO_UserTrade_Query
@SDO_ServerIP varchar(30),
@SDO_SenderUserID  varchar(20),
@SDO_ReceiveUserID varchar(20)
as
begin
 declare @SDO_GroupCity varchar(30)
 --declare @SDO_LogDB varchar(30)
  declare @strQuery varchar(500)
	--select @SDO_GroupCity=city from GMTools_Serverinfo where serverip=@SDO_ServerIP
	--select @SDO_LogDB=serverip from GMTools_Serverinfo where  gamedbID=1  and city=@SDO_GroupCity
  if len(@SDO_SenderUserID)>0 and len(@SDO_ReceiveUserID)<=0 
     set @strQuery = 'select distinct a.itemcode,b.name,a.senderIndexID,a.senderUserID,a.sendtime,a.receiverNick from ['+@SDO_ServerIP+'].logdb.dbo.T_send_record a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_data b where a.itemcode=b.itemcode and a.senderUserID='''+@SDO_SenderUserID+'''' 
  else if len(@SDO_ReceiveUserID)>0 and len(@SDO_SenderUserID)<=0 
    set @strQuery = ' select distinct a.itemcode,b.name,a.senderIndexID,a.senderUserID,a.sendtime,a.receiverNick from ['+@SDO_ServerIP+'].logdb.dbo.T_send_record a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_data b where a.itemcode=b.itemcode and a.receiverNick like ''%'+@SDO_ReceiveUserID+'%'''
  else if len(@SDO_ReceiveUserID)>0  and len(@SDO_SenderUserID)>0
    set @strQuery = ' select distinct a.itemcode,b.name,a.senderIndexID,a.senderUserID,a.sendtime,a.receiverNick  from ['+@SDO_ServerIP+'].logdb.dbo.T_send_record a,['+@SDO_ServerIP+'].gamedb.dbo.T_sdo_item_data b where a.itemcode=b.itemcode and a.receiverNick like ''%'+@SDO_ReceiveUserID+'%'' and a.senderUserID='''+@SDO_SenderUserID+''''
    
execute(@strQuery)
  print(@strQuery)
end









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












CREATE  procedure ServerInfo_Query
@GM_gameID int,
@GM_gameDBID int

as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select serverIP,city,gameName from GMTools_Serverinfo where gameflag = 1 and gamedbID='+convert(varchar(10),@GM_gameDBID)+' and gameID='+convert(varchar(10),@GM_gameID)
  execute(@strQuery)
  print(@strQuery)
end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO











CREATE       procedure ServerInfo_Query_ALL
as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select idx,serverIP,city,gameID,gameName,gamedbID,gameflag from GMTools_Serverinfo where gameflag=1'
  execute(@strQuery)
  print(@strQuery)
end





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO














Create  procedure ServerName_Query
@ServerIP varchar(30)

as
begin
  declare @strQuery varchar(700)
  set @strQuery = 'select city from GMTools_Serverinfo where serverIP='''+@ServerIP+''''
  execute(@strQuery)
  print(@strQuery)
end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE  procedure  sp_Insert_gmtoolslog
@sp_name varchar(50),
@Real_Act varchar(500)
as

insert into GMTOOLS_Log (userID,SP_Name,Game_Name,ServerIP,Real_Act) values (13,@sp_name,'超級樂者','60.217.224.178',@Real_Act)







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE           PROC sp_deleteLinkDown
@Gm_UserID	int,
@ServerIP   		varchar(30),
@idx 		int

--@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 


	EXEC sp_dropserver @ServerIP,'droplogins'
        
	delete from  GMTools_Serverinfo where idx = @idx
	
       
	IF (@@ERROR <> 0)
	BEGIN
		
	INSERT INTO GMTools_LogTime			--写log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_UserID,'删除服务器'+@ServerIP+'记录失败')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	

	INSERT INTO GMTools_LogTime			--写log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_UserID,'删除服务器'+@ServerIP+'记录成功')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_linkGameIP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_linkGameIP]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO












/*********************************************************************************/
/*	SP NAME : Gmtool_GameLink_Add			 */
/*	MOD DATE: 2006-3-7							 */
/*	EDITOR  : lxf							 */
/*-------------------------------------------------------------------------------*/
/*	DESC SP : ALTER  new gameinfo		 */
/*-------------------------------------------------------------------------------*/
/*	INPUT   : Not describe							 */
/*	RETURN  : Not describe							 */
/*-------------------------------------------------------------------------------*/
/*	MEMO    : 								 */
/*********************************************************************************/
CREATE           PROC sp_linkGameIP
@Gm_UserID	int,
@Game_IP   		varchar(30),
@Game_Usr 		varchar(30),
@Game_PWD		varchar(30),
@Game_City			varchar(30),
@Game_ID			int,
@game_flag		int,
@game_dbID		int

--@ERRNO			INT	OUTPUT
AS
declare  @ERRNO		INT 

declare @GameIP varchar(30)

select @GameIP=serverip from GMTools_Serverinfo where serverip = @Game_IP and gamedbID = @game_dbID
if len(@GameIP) > 0
	return 0	
	EXEC sp_addlinkedserver @Game_IP,N'SQL Server'
	
	EXEC sp_addlinkedsrvlogin @Game_IP, 'false',NULL,@Game_Usr, @Game_PWD
        
	declare     @gamename		varchar(50)
	select @gamename = game_name from gamelist where game_id=@Game_ID
	insert into GMTools_Serverinfo 
		(serverip,city,gameID,gamename,gameflag,gamedbID,createby)
	VALUES
		(@Game_IP,@Game_City,@Game_ID,@gamename,@game_flag,@game_dbID,@Gm_UserID)
	
       
	IF (@@ERROR <> 0)
	BEGIN
		

	INSERT INTO GMTools_LogTime			--写log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_UserID,'Add Game Information'+@gamename+'Record Fail')
		SELECT @ERRNO = 0
	END
	ELSE
	BEGIN

	

	INSERT INTO GMTools_LogTime			--写log表 
		(OperateUserID,OperateMsg)
	VALUES
		(@Gm_UserID,'Add Game Information'+@gamename+'Record Success')
		SELECT @ERRNO = 1
	END
RETURN @ERRNO
















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

