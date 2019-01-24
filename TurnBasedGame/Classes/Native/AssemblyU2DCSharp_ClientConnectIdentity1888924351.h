#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"

// ServerManager
struct ServerManager_t3491151942;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ClientConnectIdentity
struct  ClientConnectIdentity_t1888924351  : public NetworkBehaviour_t3873055601
{
public:
	// ServerManager ClientConnectIdentity::ServerManager
	ServerManager_t3491151942 * ___ServerManager_8;

public:
	inline static int32_t get_offset_of_ServerManager_8() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351, ___ServerManager_8)); }
	inline ServerManager_t3491151942 * get_ServerManager_8() const { return ___ServerManager_8; }
	inline ServerManager_t3491151942 ** get_address_of_ServerManager_8() { return &___ServerManager_8; }
	inline void set_ServerManager_8(ServerManager_t3491151942 * value)
	{
		___ServerManager_8 = value;
		Il2CppCodeGenWriteBarrier(&___ServerManager_8, value);
	}
};

struct ClientConnectIdentity_t1888924351_StaticFields
{
public:
	// System.Int32 ClientConnectIdentity::kCmdCmdLoginAccountDevice
	int32_t ___kCmdCmdLoginAccountDevice_9;
	// System.Int32 ClientConnectIdentity::kCmdCmdLoginAccountEmail
	int32_t ___kCmdCmdLoginAccountEmail_10;
	// System.Int32 ClientConnectIdentity::kCmdCmdLoginAccountFacebook
	int32_t ___kCmdCmdLoginAccountFacebook_11;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetLoginSuccess
	int32_t ___kTargetRpcTargetLoginSuccess_12;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetLoginEmailError
	int32_t ___kTargetRpcTargetLoginEmailError_13;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetLoginError
	int32_t ___kTargetRpcTargetLoginError_14;
	// System.Int32 ClientConnectIdentity::kCmdCmdRegisterEmailAccount
	int32_t ___kCmdCmdRegisterEmailAccount_15;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetRegisterError
	int32_t ___kTargetRpcTargetRegisterError_16;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetRegisterSuccess
	int32_t ___kTargetRpcTargetRegisterSuccess_17;
	// System.Int32 ClientConnectIdentity::kCmdCmdLogOut
	int32_t ___kCmdCmdLogOut_18;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetLogout
	int32_t ___kTargetRpcTargetLogout_19;
	// System.Int32 ClientConnectIdentity::kCmdCmdHumanChangeEmail
	int32_t ___kCmdCmdHumanChangeEmail_20;
	// System.Int32 ClientConnectIdentity::kCmdCmdHumanChangePhoneNumber
	int32_t ___kCmdCmdHumanChangePhoneNumber_21;
	// System.Int32 ClientConnectIdentity::kCmdCmdHumanChangeStatus
	int32_t ___kCmdCmdHumanChangeStatus_22;
	// System.Int32 ClientConnectIdentity::kCmdCmdHumanChangeBirthday
	int32_t ___kCmdCmdHumanChangeBirthday_23;
	// System.Int32 ClientConnectIdentity::kCmdCmdHumanChangeSex
	int32_t ___kCmdCmdHumanChangeSex_24;
	// System.Int32 ClientConnectIdentity::kCmdCmdAccountAdminChangeCustomName
	int32_t ___kCmdCmdAccountAdminChangeCustomName_25;
	// System.Int32 ClientConnectIdentity::kCmdCmdAccountAdminChangeAvatarUrl
	int32_t ___kCmdCmdAccountAdminChangeAvatarUrl_26;
	// System.Int32 ClientConnectIdentity::kCmdCmdAccountDeviceChangeCustomName
	int32_t ___kCmdCmdAccountDeviceChangeCustomName_27;
	// System.Int32 ClientConnectIdentity::kCmdCmdAccountDeviceChangeAvatarUrl
	int32_t ___kCmdCmdAccountDeviceChangeAvatarUrl_28;
	// System.Int32 ClientConnectIdentity::kCmdCmdAccountEmailChangePassword
	int32_t ___kCmdCmdAccountEmailChangePassword_29;
	// System.Int32 ClientConnectIdentity::kCmdCmdAccountEmailChangeCustomName
	int32_t ___kCmdCmdAccountEmailChangeCustomName_30;
	// System.Int32 ClientConnectIdentity::kCmdCmdAccountEmailChangeAvatarUrl
	int32_t ___kCmdCmdAccountEmailChangeAvatarUrl_31;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoomJoinRoom
	int32_t ___kCmdCmdRoomJoinRoom_32;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetJoinRoomError
	int32_t ___kTargetRpcTargetJoinRoomError_33;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoomChangeName
	int32_t ___kCmdCmdRoomChangeName_34;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoomChangeAllowHint
	int32_t ___kCmdCmdRoomChangeAllowHint_35;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoomStateNormalNormalFreeze
	int32_t ___kCmdCmdRoomStateNormalNormalFreeze_36;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoomStateNormalFreezeUnFreeze
	int32_t ___kCmdCmdRoomStateNormalFreezeUnFreeze_37;
	// System.Int32 ClientConnectIdentity::kCmdCmdUserChangeRole
	int32_t ___kCmdCmdUserChangeRole_38;
	// System.Int32 ClientConnectIdentity::kCmdCmdUserMakeRoom
	int32_t ___kCmdCmdUserMakeRoom_39;
	// System.Int32 ClientConnectIdentity::kCmdCmdUserMakeFriendRequest
	int32_t ___kCmdCmdUserMakeFriendRequest_40;
	// System.Int32 ClientConnectIdentity::kCmdCmdBanNormalBan
	int32_t ___kCmdCmdBanNormalBan_41;
	// System.Int32 ClientConnectIdentity::kCmdCmdBanBanUnBan
	int32_t ___kCmdCmdBanBanUnBan_42;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetSendMessage
	int32_t ___kTargetRpcTargetSendMessage_43;
	// System.Int32 ClientConnectIdentity::kTargetRpcTargetSendDestroyIdentity
	int32_t ___kTargetRpcTargetSendDestroyIdentity_44;
	// System.Int32 ClientConnectIdentity::kCmdCmdUndoRedoNoneAskLastTurn
	int32_t ___kCmdCmdUndoRedoNoneAskLastTurn_45;
	// System.Int32 ClientConnectIdentity::kCmdCmdUndoRedoNoneAskLastYourTurn
	int32_t ___kCmdCmdUndoRedoNoneAskLastYourTurn_46;
	// System.Int32 ClientConnectIdentity::kCmdCmdUndoRedoAskAnswer
	int32_t ___kCmdCmdUndoRedoAskAnswer_47;
	// System.Int32 ClientConnectIdentity::kCmdCmdPlayerLeaveRoom
	int32_t ___kCmdCmdPlayerLeaveRoom_48;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoomUserKick
	int32_t ___kCmdCmdRoomUserKick_49;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoomUserUnKick
	int32_t ___kCmdCmdRoomUserUnKick_50;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestDrawStateNoneMakeRequest
	int32_t ___kCmdCmdRequestDrawStateNoneMakeRequest_51;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestDrawStateAskAnswer
	int32_t ___kCmdCmdRequestDrawStateAskAnswer_52;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestDrawStateAcceptAnswer
	int32_t ___kCmdCmdRequestDrawStateAcceptAnswer_53;
	// System.Int32 ClientConnectIdentity::kCmdCmdGameFactoryChangeGameDataFactoryType
	int32_t ___kCmdCmdGameFactoryChangeGameDataFactoryType_54;
	// System.Int32 ClientConnectIdentity::kCmdCmdPostureGameDataFactoryChangeGameData
	int32_t ___kCmdCmdPostureGameDataFactoryChangeGameData_55;
	// System.Int32 ClientConnectIdentity::kCmdCmdPostureGameDataFactoryChangeType
	int32_t ___kCmdCmdPostureGameDataFactoryChangeType_56;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultGameDataFactoryChangeType
	int32_t ___kCmdCmdDefaultGameDataFactoryChangeType_57;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultGameDataFactoryChangeUseRule
	int32_t ___kCmdCmdDefaultGameDataFactoryChangeUseRule_58;
	// System.Int32 ClientConnectIdentity::kCmdCmdPostureGameDataFactoryChangeUseRule
	int32_t ___kCmdCmdPostureGameDataFactoryChangeUseRule_59;
	// System.Int32 ClientConnectIdentity::kCmdCmdGamePlayerSurrender
	int32_t ___kCmdCmdGamePlayerSurrender_60;
	// System.Int32 ClientConnectIdentity::kCmdCmdPlayNormalPause
	int32_t ___kCmdCmdPlayNormalPause_61;
	// System.Int32 ClientConnectIdentity::kCmdCmdPlayPauseUnPause
	int32_t ___kCmdCmdPlayPauseUnPause_62;
	// System.Int32 ClientConnectIdentity::kCmdCmdGamePlayerStateSurrenderMakeRequestCancel
	int32_t ___kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63;
	// System.Int32 ClientConnectIdentity::kCmdCmdGamePlayerStateSurrenderCancelRequestCancel
	int32_t ___kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64;
	// System.Int32 ClientConnectIdentity::kCmdCmdGamePlayerStateSurrenderAnswer
	int32_t ___kCmdCmdGamePlayerStateSurrenderAnswer_65;
	// System.Int32 ClientConnectIdentity::kCmdCmdHistoryAddHumanConnection
	int32_t ___kCmdCmdHistoryAddHumanConnection_66;
	// System.Int32 ClientConnectIdentity::kCmdCmdHistoryRemoveHumanConnection
	int32_t ___kCmdCmdHistoryRemoveHumanConnection_67;
	// System.Int32 ClientConnectIdentity::kCmdCmdFriendStateNoneMakeFriend
	int32_t ___kCmdCmdFriendStateNoneMakeFriend_68;
	// System.Int32 ClientConnectIdentity::kCmdCmdFriendStateNoneBan
	int32_t ___kCmdCmdFriendStateNoneBan_69;
	// System.Int32 ClientConnectIdentity::kCmdCmdFriendStateRequestAccept
	int32_t ___kCmdCmdFriendStateRequestAccept_70;
	// System.Int32 ClientConnectIdentity::kCmdCmdFriendStateRequestRefuse
	int32_t ___kCmdCmdFriendStateRequestRefuse_71;
	// System.Int32 ClientConnectIdentity::kCmdCmdFriendStateRequestCancel
	int32_t ___kCmdCmdFriendStateRequestCancel_72;
	// System.Int32 ClientConnectIdentity::kCmdCmdFriendStateAcceptUnFriend
	int32_t ___kCmdCmdFriendStateAcceptUnFriend_73;
	// System.Int32 ClientConnectIdentity::kCmdCmdFriendStateBanUnBan
	int32_t ___kCmdCmdFriendStateBanUnBan_74;
	// System.Int32 ClientConnectIdentity::kCmdCmdChatRoomSendNormalMessage
	int32_t ___kCmdCmdChatRoomSendNormalMessage_75;
	// System.Int32 ClientConnectIdentity::kCmdCmdChatMessageChangeState
	int32_t ___kCmdCmdChatMessageChangeState_76;
	// System.Int32 ClientConnectIdentity::kCmdCmdChatNormalContentEdit
	int32_t ___kCmdCmdChatNormalContentEdit_77;
	// System.Int32 ClientConnectIdentity::kCmdCmdTypingSendTyping
	int32_t ___kCmdCmdTypingSendTyping_78;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultChessChangeChess960
	int32_t ___kCmdCmdDefaultChessChangeChess960_79;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultShatranjChangeChess960
	int32_t ___kCmdCmdDefaultShatranjChangeChess960_80;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultMakrukChangeChess960
	int32_t ___kCmdCmdDefaultMakrukChangeChess960_81;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultSeirawanChangeChess960
	int32_t ___kCmdCmdDefaultSeirawanChangeChess960_82;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultFairyChessChangeVariantType
	int32_t ___kCmdCmdDefaultFairyChessChangeVariantType_83;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultFairyChessChangeChess960
	int32_t ___kCmdCmdDefaultFairyChessChangeChess960_84;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultCoTuongUpChangeAllowViewCapture
	int32_t ___kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden
	int32_t ___kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip
	int32_t ___kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultGomokuChangeBoardSize
	int32_t ___kCmdCmdDefaultGomokuChangeBoardSize_88;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultEnglishDraughtChangeMaxPly
	int32_t ___kCmdCmdDefaultEnglishDraughtChangeMaxPly_89;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom
	int32_t ___kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultInternationalDraughtChangeVariant
	int32_t ___kCmdCmdDefaultInternationalDraughtChangeVariant_91;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultWeiqiChangeSize
	int32_t ___kCmdCmdDefaultWeiqiChangeSize_92;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultWeiqiChangeKomi
	int32_t ___kCmdCmdDefaultWeiqiChangeKomi_93;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultWeiqiChangeRule
	int32_t ___kCmdCmdDefaultWeiqiChangeRule_94;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultWeiqiChangeHandicap
	int32_t ___kCmdCmdDefaultWeiqiChangeHandicap_95;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultMineSweeperChangeN
	int32_t ___kCmdCmdDefaultMineSweeperChangeN_96;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultMineSweeperChangeM
	int32_t ___kCmdCmdDefaultMineSweeperChangeM_97;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultMineSweeperChangeMinK
	int32_t ___kCmdCmdDefaultMineSweeperChangeMinK_98;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultMineSweeperChangeMaxK
	int32_t ___kCmdCmdDefaultMineSweeperChangeMaxK_99;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultMineSweeperChangeAllowWatchBomb
	int32_t ___kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100;
	// System.Int32 ClientConnectIdentity::kCmdCmdDefaultHexChangeBoardSize
	int32_t ___kCmdCmdDefaultHexChangeBoardSize_101;
	// System.Int32 ClientConnectIdentity::kCmdCmdWaitAIMoveInputSendInput
	int32_t ___kCmdCmdWaitAIMoveInputSendInput_102;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeReportClientTime
	int32_t ___kCmdCmdTimeReportClientTime_103;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeControlChangeIsEnable
	int32_t ___kCmdCmdTimeControlChangeIsEnable_104;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeControlChangeAICanTimeOut
	int32_t ___kCmdCmdTimeControlChangeAICanTimeOut_105;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeControlChangeUse
	int32_t ___kCmdCmdTimeControlChangeUse_106;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeControlChangeSubType
	int32_t ___kCmdCmdTimeControlChangeSubType_107;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimePerTurnInfoLimitChangePerTurn
	int32_t ___kCmdCmdTimePerTurnInfoLimitChangePerTurn_108;
	// System.Int32 ClientConnectIdentity::kCmdCmdTotalTimeInfoLimitChangeTotalTime
	int32_t ___kCmdCmdTotalTimeInfoLimitChangeTotalTime_109;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeInfoChangeTimePerTurnType
	int32_t ___kCmdCmdTimeInfoChangeTimePerTurnType_110;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeInfoChangeTotalTimeType
	int32_t ___kCmdCmdTimeInfoChangeTotalTimeType_111;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeInfoChangeOverTimePerTurnType
	int32_t ___kCmdCmdTimeInfoChangeOverTimePerTurnType_112;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeInfoChangeLagCompensation
	int32_t ___kCmdCmdTimeInfoChangeLagCompensation_113;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeControlHourGlassChangeInitTime
	int32_t ___kCmdCmdTimeControlHourGlassChangeInitTime_114;
	// System.Int32 ClientConnectIdentity::kCmdCmdTimeControlHourGlassChangeLagCompensation
	int32_t ___kCmdCmdTimeControlHourGlassChangeLagCompensation_115;
	// System.Int32 ClientConnectIdentity::kCmdCmdChessAIChangeDepth
	int32_t ___kCmdCmdChessAIChangeDepth_116;
	// System.Int32 ClientConnectIdentity::kCmdCmdChessAIChangeSkillLevel
	int32_t ___kCmdCmdChessAIChangeSkillLevel_117;
	// System.Int32 ClientConnectIdentity::kCmdCmdChessAIChangeDuration
	int32_t ___kCmdCmdChessAIChangeDuration_118;
	// System.Int32 ClientConnectIdentity::kCmdCmdFairyChessAIChangeDepth
	int32_t ___kCmdCmdFairyChessAIChangeDepth_119;
	// System.Int32 ClientConnectIdentity::kCmdCmdFairyChessAIChangeSkillLevel
	int32_t ___kCmdCmdFairyChessAIChangeSkillLevel_120;
	// System.Int32 ClientConnectIdentity::kCmdCmdFairyChessAIChangeDuration
	int32_t ___kCmdCmdFairyChessAIChangeDuration_121;
	// System.Int32 ClientConnectIdentity::kCmdCmdGomokuAIChangeSearchDepth
	int32_t ___kCmdCmdGomokuAIChangeSearchDepth_122;
	// System.Int32 ClientConnectIdentity::kCmdCmdGomokuAIChangeTimeLimit
	int32_t ___kCmdCmdGomokuAIChangeTimeLimit_123;
	// System.Int32 ClientConnectIdentity::kCmdCmdGomokuAIChangeLevel
	int32_t ___kCmdCmdGomokuAIChangeLevel_124;
	// System.Int32 ClientConnectIdentity::kCmdCmdInternationalDraughtAIChangeBMove
	int32_t ___kCmdCmdInternationalDraughtAIChangeBMove_125;
	// System.Int32 ClientConnectIdentity::kCmdCmdInternationalDraughtAIChangeBook
	int32_t ___kCmdCmdInternationalDraughtAIChangeBook_126;
	// System.Int32 ClientConnectIdentity::kCmdCmdInternationalDraughtAIChangeDepth
	int32_t ___kCmdCmdInternationalDraughtAIChangeDepth_127;
	// System.Int32 ClientConnectIdentity::kCmdCmdInternationalDraughtAIChangeTime
	int32_t ___kCmdCmdInternationalDraughtAIChangeTime_128;
	// System.Int32 ClientConnectIdentity::kCmdCmdInternationalDraughtAIChangeInput
	int32_t ___kCmdCmdInternationalDraughtAIChangeInput_129;
	// System.Int32 ClientConnectIdentity::kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase
	int32_t ___kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130;
	// System.Int32 ClientConnectIdentity::kCmdCmdInternationalDraughtAIChangePickBestMove
	int32_t ___kCmdCmdInternationalDraughtAIChangePickBestMove_131;
	// System.Int32 ClientConnectIdentity::kCmdCmdEnglishDraughtAIChangeThreeMoveRandom
	int32_t ___kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132;
	// System.Int32 ClientConnectIdentity::kCmdCmdEnglishDraughtAIChangeFMaxSeconds
	int32_t ___kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133;
	// System.Int32 ClientConnectIdentity::kCmdCmdEnglishDraughtAIChangeGMaxDepth
	int32_t ___kCmdCmdEnglishDraughtAIChangeGMaxDepth_134;
	// System.Int32 ClientConnectIdentity::kCmdCmdEnglishDraughtAIChangePickBestMove
	int32_t ___kCmdCmdEnglishDraughtAIChangePickBestMove_135;
	// System.Int32 ClientConnectIdentity::kCmdCmdRussianDraughtAIChangeTimeLimit
	int32_t ___kCmdCmdRussianDraughtAIChangeTimeLimit_136;
	// System.Int32 ClientConnectIdentity::kCmdCmdRussianDraughtAIChangePickBestMove
	int32_t ___kCmdCmdRussianDraughtAIChangePickBestMove_137;
	// System.Int32 ClientConnectIdentity::kCmdCmdReversiAIChangeSort
	int32_t ___kCmdCmdReversiAIChangeSort_138;
	// System.Int32 ClientConnectIdentity::kCmdCmdReversiAIChangeMin
	int32_t ___kCmdCmdReversiAIChangeMin_139;
	// System.Int32 ClientConnectIdentity::kCmdCmdReversiAIChangeMax
	int32_t ___kCmdCmdReversiAIChangeMax_140;
	// System.Int32 ClientConnectIdentity::kCmdCmdReversiAIChangeEnd
	int32_t ___kCmdCmdReversiAIChangeEnd_141;
	// System.Int32 ClientConnectIdentity::kCmdCmdReversiAIChangeMsLeft
	int32_t ___kCmdCmdReversiAIChangeMsLeft_142;
	// System.Int32 ClientConnectIdentity::kCmdCmdReversiAIChangeUseBook
	int32_t ___kCmdCmdReversiAIChangeUseBook_143;
	// System.Int32 ClientConnectIdentity::kCmdCmdReversiAIChangePercent
	int32_t ___kCmdCmdReversiAIChangePercent_144;
	// System.Int32 ClientConnectIdentity::kCmdCmdShatranjAIChangeDepth
	int32_t ___kCmdCmdShatranjAIChangeDepth_145;
	// System.Int32 ClientConnectIdentity::kCmdCmdShatranjAIChangeSkillLevel
	int32_t ___kCmdCmdShatranjAIChangeSkillLevel_146;
	// System.Int32 ClientConnectIdentity::kCmdCmdShatranjAIChangeDuration
	int32_t ___kCmdCmdShatranjAIChangeDuration_147;
	// System.Int32 ClientConnectIdentity::kCmdCmdMakrukAIChangeDepth
	int32_t ___kCmdCmdMakrukAIChangeDepth_148;
	// System.Int32 ClientConnectIdentity::kCmdCmdMakrukAIChangeSkillLevel
	int32_t ___kCmdCmdMakrukAIChangeSkillLevel_149;
	// System.Int32 ClientConnectIdentity::kCmdCmdMakrukAIChangeDuration
	int32_t ___kCmdCmdMakrukAIChangeDuration_150;
	// System.Int32 ClientConnectIdentity::kCmdCmdSeirawanAIChangeDepth
	int32_t ___kCmdCmdSeirawanAIChangeDepth_151;
	// System.Int32 ClientConnectIdentity::kCmdCmdSeirawanAIChangeSkillLevel
	int32_t ___kCmdCmdSeirawanAIChangeSkillLevel_152;
	// System.Int32 ClientConnectIdentity::kCmdCmdSeirawanAIChangeDuration
	int32_t ___kCmdCmdSeirawanAIChangeDuration_153;
	// System.Int32 ClientConnectIdentity::kCmdCmdShogiAIChangeDepth
	int32_t ___kCmdCmdShogiAIChangeDepth_154;
	// System.Int32 ClientConnectIdentity::kCmdCmdShogiAIChangeSkillLevel
	int32_t ___kCmdCmdShogiAIChangeSkillLevel_155;
	// System.Int32 ClientConnectIdentity::kCmdCmdShogiAIChangeMr
	int32_t ___kCmdCmdShogiAIChangeMr_156;
	// System.Int32 ClientConnectIdentity::kCmdCmdShogiAIChangeDuration
	int32_t ___kCmdCmdShogiAIChangeDuration_157;
	// System.Int32 ClientConnectIdentity::kCmdCmdShogiAIChangeUseBook
	int32_t ___kCmdCmdShogiAIChangeUseBook_158;
	// System.Int32 ClientConnectIdentity::kCmdCmdWeiqiAIChangeCanResign
	int32_t ___kCmdCmdWeiqiAIChangeCanResign_159;
	// System.Int32 ClientConnectIdentity::kCmdCmdWeiqiAIChangeUseBook
	int32_t ___kCmdCmdWeiqiAIChangeUseBook_160;
	// System.Int32 ClientConnectIdentity::kCmdCmdWeiqiAIChangeTime
	int32_t ___kCmdCmdWeiqiAIChangeTime_161;
	// System.Int32 ClientConnectIdentity::kCmdCmdWeiqiAIChangeGames
	int32_t ___kCmdCmdWeiqiAIChangeGames_162;
	// System.Int32 ClientConnectIdentity::kCmdCmdWeiqiAIChangeEngine
	int32_t ___kCmdCmdWeiqiAIChangeEngine_163;
	// System.Int32 ClientConnectIdentity::kCmdCmdXiangqiAIChangeDepth
	int32_t ___kCmdCmdXiangqiAIChangeDepth_164;
	// System.Int32 ClientConnectIdentity::kCmdCmdXiangqiAIChangeThinkTime
	int32_t ___kCmdCmdXiangqiAIChangeThinkTime_165;
	// System.Int32 ClientConnectIdentity::kCmdCmdXiangqiAIChangeUseBook
	int32_t ___kCmdCmdXiangqiAIChangeUseBook_166;
	// System.Int32 ClientConnectIdentity::kCmdCmdXiangqiAIChangePickBestMove
	int32_t ___kCmdCmdXiangqiAIChangePickBestMove_167;
	// System.Int32 ClientConnectIdentity::kCmdCmdMineSweeperAIChangeFirstMoveType
	int32_t ___kCmdCmdMineSweeperAIChangeFirstMoveType_168;
	// System.Int32 ClientConnectIdentity::kCmdCmdHexAIChangeLimitTime
	int32_t ___kCmdCmdHexAIChangeLimitTime_169;
	// System.Int32 ClientConnectIdentity::kCmdCmdHexAIChangeFirstMoveCenter
	int32_t ___kCmdCmdHexAIChangeFirstMoveCenter_170;
	// System.Int32 ClientConnectIdentity::kCmdCmdComputerChangeName
	int32_t ___kCmdCmdComputerChangeName_171;
	// System.Int32 ClientConnectIdentity::kCmdCmdComputerChangeAvatarUrl
	int32_t ___kCmdCmdComputerChangeAvatarUrl_172;
	// System.Int32 ClientConnectIdentity::kCmdCmdRightsHaveLimitChangeLimit
	int32_t ___kCmdCmdRightsHaveLimitChangeLimit_173;
	// System.Int32 ClientConnectIdentity::kCmdCmdUndoRedoRightChangeNeedAccept
	int32_t ___kCmdCmdUndoRedoRightChangeNeedAccept_174;
	// System.Int32 ClientConnectIdentity::kCmdCmdUndoRedoRightChangeNeedAdmin
	int32_t ___kCmdCmdUndoRedoRightChangeNeedAdmin_175;
	// System.Int32 ClientConnectIdentity::kCmdCmdUndoRedoRightChangeLimitType
	int32_t ___kCmdCmdUndoRedoRightChangeLimitType_176;
	// System.Int32 ClientConnectIdentity::kCmdCmdChangeGamePlayerRightChangeCanChange
	int32_t ___kCmdCmdChangeGamePlayerRightChangeCanChange_177;
	// System.Int32 ClientConnectIdentity::kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft
	int32_t ___kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178;
	// System.Int32 ClientConnectIdentity::kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept
	int32_t ___kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179;
	// System.Int32 ClientConnectIdentity::kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed
	int32_t ___kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180;
	// System.Int32 ClientConnectIdentity::kCmdCmdSingleContestFactoryChangePlayerPerTeam
	int32_t ___kCmdCmdSingleContestFactoryChangePlayerPerTeam_181;
	// System.Int32 ClientConnectIdentity::kCmdCmdSingleContestFactoryChangeRoundFactoryType
	int32_t ___kCmdCmdSingleContestFactoryChangeRoundFactoryType_182;
	// System.Int32 ClientConnectIdentity::kCmdCmdSingleContestFactoryChangeNewRoundLimitType
	int32_t ___kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183;
	// System.Int32 ClientConnectIdentity::kCmdCmdSingleContestFactoryChangeCalculateScoreType
	int32_t ___kCmdCmdSingleContestFactoryChangeCalculateScoreType_184;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewRoundHaveLimitChangeMaxRound
	int32_t ___kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop
	int32_t ___kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound
	int32_t ___kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewRoundStateAskAccept
	int32_t ___kCmdCmdRequestNewRoundStateAskAccept_188;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewRoundStateAskCancel
	int32_t ___kCmdCmdRequestNewRoundStateAskCancel_189;
	// System.Int32 ClientConnectIdentity::kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound
	int32_t ___kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190;
	// System.Int32 ClientConnectIdentity::kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer
	int32_t ___kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191;
	// System.Int32 ClientConnectIdentity::kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam
	int32_t ___kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192;
	// System.Int32 ClientConnectIdentity::kCmdCmdNormalRoundFactoryChangeCalculateScoreType
	int32_t ___kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193;
	// System.Int32 ClientConnectIdentity::kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex
	int32_t ___kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194;
	// System.Int32 ClientConnectIdentity::kCmdCmdContestManagerStateLobbyChangeContentFactoryType
	int32_t ___kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195;
	// System.Int32 ClientConnectIdentity::kCmdCmdContestManagerStateLobbyStateNormalStart
	int32_t ___kCmdCmdContestManagerStateLobbyStateNormalStart_196;
	// System.Int32 ClientConnectIdentity::kCmdCmdLobbyPlayerSetReady
	int32_t ___kCmdCmdLobbyPlayerSetReady_197;
	// System.Int32 ClientConnectIdentity::kCmdCmdLobbyPlayerAdminChangeHuman
	int32_t ___kCmdCmdLobbyPlayerAdminChangeHuman_198;
	// System.Int32 ClientConnectIdentity::kCmdCmdLobbyPlayerAdminChangeEmpty
	int32_t ___kCmdCmdLobbyPlayerAdminChangeEmpty_199;
	// System.Int32 ClientConnectIdentity::kCmdCmdLobbyPlayerAdminChangeComputer
	int32_t ___kCmdCmdLobbyPlayerAdminChangeComputer_200;
	// System.Int32 ClientConnectIdentity::kCmdCmdLobbyPlayerNormalSet
	int32_t ___kCmdCmdLobbyPlayerNormalSet_201;
	// System.Int32 ClientConnectIdentity::kCmdCmdLobbyPlayerIdentityNormalEmpty
	int32_t ___kCmdCmdLobbyPlayerIdentityNormalEmpty_202;
	// System.Int32 ClientConnectIdentity::kCmdCmdContestManagerStatePlayChangeIsForceEnd
	int32_t ___kCmdCmdContestManagerStatePlayChangeIsForceEnd_203;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewContestManagerStateAskAccept
	int32_t ___kCmdCmdRequestNewContestManagerStateAskAccept_204;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewContestManagerStateAskCancel
	int32_t ___kCmdCmdRequestNewContestManagerStateAskCancel_205;
	// System.Int32 ClientConnectIdentity::kCmdCmdCalculateScoreWinLoseDrawChangeWinScore
	int32_t ___kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206;
	// System.Int32 ClientConnectIdentity::kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore
	int32_t ___kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207;
	// System.Int32 ClientConnectIdentity::kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore
	int32_t ___kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoundRobinFactoryChangeTeamCount
	int32_t ___kCmdCmdRoundRobinFactoryChangeTeamCount_209;
	// System.Int32 ClientConnectIdentity::kCmdCmdRoundRobinFactoryChangeNeedReturnRound
	int32_t ___kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewRoundRobinStateAskAccept
	int32_t ___kCmdCmdRequestNewRoundRobinStateAskAccept_211;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewRoundRobinStateAskCancel
	int32_t ___kCmdCmdRequestNewRoundRobinStateAskCancel_212;
	// System.Int32 ClientConnectIdentity::kCmdCmdEliminationFactoryChangeInitTeamCountLength
	int32_t ___kCmdCmdEliminationFactoryChangeInitTeamCountLength_213;
	// System.Int32 ClientConnectIdentity::kCmdCmdEliminationFactoryChangeInitTeamCount
	int32_t ___kCmdCmdEliminationFactoryChangeInitTeamCount_214;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewEliminationRoundStateAskAccept
	int32_t ___kCmdCmdRequestNewEliminationRoundStateAskAccept_215;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestNewEliminationRoundStateAskCancel
	int32_t ___kCmdCmdRequestNewEliminationRoundStateAskCancel_216;
	// System.Int32 ClientConnectIdentity::kCmdCmdSwapIdentityChangeHuman
	int32_t ___kCmdCmdSwapIdentityChangeHuman_217;
	// System.Int32 ClientConnectIdentity::kCmdCmdSwapIdentityChangeComputer
	int32_t ___kCmdCmdSwapIdentityChangeComputer_218;
	// System.Int32 ClientConnectIdentity::kCmdCmdSwapRequestStateAskAccept
	int32_t ___kCmdCmdSwapRequestStateAskAccept_219;
	// System.Int32 ClientConnectIdentity::kCmdCmdSwapRequestStateAskRefuse
	int32_t ___kCmdCmdSwapRequestStateAskRefuse_220;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestChangeUseRuleStateNoneChange
	int32_t ___kCmdCmdRequestChangeUseRuleStateNoneChange_221;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestChangeUseRuleStateAskAccept
	int32_t ___kCmdCmdRequestChangeUseRuleStateAskAccept_222;
	// System.Int32 ClientConnectIdentity::kCmdCmdRequestChangeUseRuleStateAskRefuse
	int32_t ___kCmdCmdRequestChangeUseRuleStateAskRefuse_223;
	// System.Int32 ClientConnectIdentity::kCmdCmdChangeUseRuleRightChangeOnlyAdmin
	int32_t ___kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224;
	// System.Int32 ClientConnectIdentity::kCmdCmdChangeUseRuleRightChangeNeedAdmin
	int32_t ___kCmdCmdChangeUseRuleRightChangeNeedAdmin_225;
	// System.Int32 ClientConnectIdentity::kCmdCmdChangeUseRuleRightChangeNeedAccept
	int32_t ___kCmdCmdChangeUseRuleRightChangeNeedAccept_226;

public:
	inline static int32_t get_offset_of_kCmdCmdLoginAccountDevice_9() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLoginAccountDevice_9)); }
	inline int32_t get_kCmdCmdLoginAccountDevice_9() const { return ___kCmdCmdLoginAccountDevice_9; }
	inline int32_t* get_address_of_kCmdCmdLoginAccountDevice_9() { return &___kCmdCmdLoginAccountDevice_9; }
	inline void set_kCmdCmdLoginAccountDevice_9(int32_t value)
	{
		___kCmdCmdLoginAccountDevice_9 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLoginAccountEmail_10() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLoginAccountEmail_10)); }
	inline int32_t get_kCmdCmdLoginAccountEmail_10() const { return ___kCmdCmdLoginAccountEmail_10; }
	inline int32_t* get_address_of_kCmdCmdLoginAccountEmail_10() { return &___kCmdCmdLoginAccountEmail_10; }
	inline void set_kCmdCmdLoginAccountEmail_10(int32_t value)
	{
		___kCmdCmdLoginAccountEmail_10 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLoginAccountFacebook_11() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLoginAccountFacebook_11)); }
	inline int32_t get_kCmdCmdLoginAccountFacebook_11() const { return ___kCmdCmdLoginAccountFacebook_11; }
	inline int32_t* get_address_of_kCmdCmdLoginAccountFacebook_11() { return &___kCmdCmdLoginAccountFacebook_11; }
	inline void set_kCmdCmdLoginAccountFacebook_11(int32_t value)
	{
		___kCmdCmdLoginAccountFacebook_11 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetLoginSuccess_12() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetLoginSuccess_12)); }
	inline int32_t get_kTargetRpcTargetLoginSuccess_12() const { return ___kTargetRpcTargetLoginSuccess_12; }
	inline int32_t* get_address_of_kTargetRpcTargetLoginSuccess_12() { return &___kTargetRpcTargetLoginSuccess_12; }
	inline void set_kTargetRpcTargetLoginSuccess_12(int32_t value)
	{
		___kTargetRpcTargetLoginSuccess_12 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetLoginEmailError_13() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetLoginEmailError_13)); }
	inline int32_t get_kTargetRpcTargetLoginEmailError_13() const { return ___kTargetRpcTargetLoginEmailError_13; }
	inline int32_t* get_address_of_kTargetRpcTargetLoginEmailError_13() { return &___kTargetRpcTargetLoginEmailError_13; }
	inline void set_kTargetRpcTargetLoginEmailError_13(int32_t value)
	{
		___kTargetRpcTargetLoginEmailError_13 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetLoginError_14() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetLoginError_14)); }
	inline int32_t get_kTargetRpcTargetLoginError_14() const { return ___kTargetRpcTargetLoginError_14; }
	inline int32_t* get_address_of_kTargetRpcTargetLoginError_14() { return &___kTargetRpcTargetLoginError_14; }
	inline void set_kTargetRpcTargetLoginError_14(int32_t value)
	{
		___kTargetRpcTargetLoginError_14 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRegisterEmailAccount_15() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRegisterEmailAccount_15)); }
	inline int32_t get_kCmdCmdRegisterEmailAccount_15() const { return ___kCmdCmdRegisterEmailAccount_15; }
	inline int32_t* get_address_of_kCmdCmdRegisterEmailAccount_15() { return &___kCmdCmdRegisterEmailAccount_15; }
	inline void set_kCmdCmdRegisterEmailAccount_15(int32_t value)
	{
		___kCmdCmdRegisterEmailAccount_15 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetRegisterError_16() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetRegisterError_16)); }
	inline int32_t get_kTargetRpcTargetRegisterError_16() const { return ___kTargetRpcTargetRegisterError_16; }
	inline int32_t* get_address_of_kTargetRpcTargetRegisterError_16() { return &___kTargetRpcTargetRegisterError_16; }
	inline void set_kTargetRpcTargetRegisterError_16(int32_t value)
	{
		___kTargetRpcTargetRegisterError_16 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetRegisterSuccess_17() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetRegisterSuccess_17)); }
	inline int32_t get_kTargetRpcTargetRegisterSuccess_17() const { return ___kTargetRpcTargetRegisterSuccess_17; }
	inline int32_t* get_address_of_kTargetRpcTargetRegisterSuccess_17() { return &___kTargetRpcTargetRegisterSuccess_17; }
	inline void set_kTargetRpcTargetRegisterSuccess_17(int32_t value)
	{
		___kTargetRpcTargetRegisterSuccess_17 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLogOut_18() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLogOut_18)); }
	inline int32_t get_kCmdCmdLogOut_18() const { return ___kCmdCmdLogOut_18; }
	inline int32_t* get_address_of_kCmdCmdLogOut_18() { return &___kCmdCmdLogOut_18; }
	inline void set_kCmdCmdLogOut_18(int32_t value)
	{
		___kCmdCmdLogOut_18 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetLogout_19() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetLogout_19)); }
	inline int32_t get_kTargetRpcTargetLogout_19() const { return ___kTargetRpcTargetLogout_19; }
	inline int32_t* get_address_of_kTargetRpcTargetLogout_19() { return &___kTargetRpcTargetLogout_19; }
	inline void set_kTargetRpcTargetLogout_19(int32_t value)
	{
		___kTargetRpcTargetLogout_19 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHumanChangeEmail_20() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHumanChangeEmail_20)); }
	inline int32_t get_kCmdCmdHumanChangeEmail_20() const { return ___kCmdCmdHumanChangeEmail_20; }
	inline int32_t* get_address_of_kCmdCmdHumanChangeEmail_20() { return &___kCmdCmdHumanChangeEmail_20; }
	inline void set_kCmdCmdHumanChangeEmail_20(int32_t value)
	{
		___kCmdCmdHumanChangeEmail_20 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHumanChangePhoneNumber_21() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHumanChangePhoneNumber_21)); }
	inline int32_t get_kCmdCmdHumanChangePhoneNumber_21() const { return ___kCmdCmdHumanChangePhoneNumber_21; }
	inline int32_t* get_address_of_kCmdCmdHumanChangePhoneNumber_21() { return &___kCmdCmdHumanChangePhoneNumber_21; }
	inline void set_kCmdCmdHumanChangePhoneNumber_21(int32_t value)
	{
		___kCmdCmdHumanChangePhoneNumber_21 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHumanChangeStatus_22() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHumanChangeStatus_22)); }
	inline int32_t get_kCmdCmdHumanChangeStatus_22() const { return ___kCmdCmdHumanChangeStatus_22; }
	inline int32_t* get_address_of_kCmdCmdHumanChangeStatus_22() { return &___kCmdCmdHumanChangeStatus_22; }
	inline void set_kCmdCmdHumanChangeStatus_22(int32_t value)
	{
		___kCmdCmdHumanChangeStatus_22 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHumanChangeBirthday_23() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHumanChangeBirthday_23)); }
	inline int32_t get_kCmdCmdHumanChangeBirthday_23() const { return ___kCmdCmdHumanChangeBirthday_23; }
	inline int32_t* get_address_of_kCmdCmdHumanChangeBirthday_23() { return &___kCmdCmdHumanChangeBirthday_23; }
	inline void set_kCmdCmdHumanChangeBirthday_23(int32_t value)
	{
		___kCmdCmdHumanChangeBirthday_23 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHumanChangeSex_24() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHumanChangeSex_24)); }
	inline int32_t get_kCmdCmdHumanChangeSex_24() const { return ___kCmdCmdHumanChangeSex_24; }
	inline int32_t* get_address_of_kCmdCmdHumanChangeSex_24() { return &___kCmdCmdHumanChangeSex_24; }
	inline void set_kCmdCmdHumanChangeSex_24(int32_t value)
	{
		___kCmdCmdHumanChangeSex_24 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdAccountAdminChangeCustomName_25() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdAccountAdminChangeCustomName_25)); }
	inline int32_t get_kCmdCmdAccountAdminChangeCustomName_25() const { return ___kCmdCmdAccountAdminChangeCustomName_25; }
	inline int32_t* get_address_of_kCmdCmdAccountAdminChangeCustomName_25() { return &___kCmdCmdAccountAdminChangeCustomName_25; }
	inline void set_kCmdCmdAccountAdminChangeCustomName_25(int32_t value)
	{
		___kCmdCmdAccountAdminChangeCustomName_25 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdAccountAdminChangeAvatarUrl_26() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdAccountAdminChangeAvatarUrl_26)); }
	inline int32_t get_kCmdCmdAccountAdminChangeAvatarUrl_26() const { return ___kCmdCmdAccountAdminChangeAvatarUrl_26; }
	inline int32_t* get_address_of_kCmdCmdAccountAdminChangeAvatarUrl_26() { return &___kCmdCmdAccountAdminChangeAvatarUrl_26; }
	inline void set_kCmdCmdAccountAdminChangeAvatarUrl_26(int32_t value)
	{
		___kCmdCmdAccountAdminChangeAvatarUrl_26 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdAccountDeviceChangeCustomName_27() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdAccountDeviceChangeCustomName_27)); }
	inline int32_t get_kCmdCmdAccountDeviceChangeCustomName_27() const { return ___kCmdCmdAccountDeviceChangeCustomName_27; }
	inline int32_t* get_address_of_kCmdCmdAccountDeviceChangeCustomName_27() { return &___kCmdCmdAccountDeviceChangeCustomName_27; }
	inline void set_kCmdCmdAccountDeviceChangeCustomName_27(int32_t value)
	{
		___kCmdCmdAccountDeviceChangeCustomName_27 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdAccountDeviceChangeAvatarUrl_28() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdAccountDeviceChangeAvatarUrl_28)); }
	inline int32_t get_kCmdCmdAccountDeviceChangeAvatarUrl_28() const { return ___kCmdCmdAccountDeviceChangeAvatarUrl_28; }
	inline int32_t* get_address_of_kCmdCmdAccountDeviceChangeAvatarUrl_28() { return &___kCmdCmdAccountDeviceChangeAvatarUrl_28; }
	inline void set_kCmdCmdAccountDeviceChangeAvatarUrl_28(int32_t value)
	{
		___kCmdCmdAccountDeviceChangeAvatarUrl_28 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdAccountEmailChangePassword_29() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdAccountEmailChangePassword_29)); }
	inline int32_t get_kCmdCmdAccountEmailChangePassword_29() const { return ___kCmdCmdAccountEmailChangePassword_29; }
	inline int32_t* get_address_of_kCmdCmdAccountEmailChangePassword_29() { return &___kCmdCmdAccountEmailChangePassword_29; }
	inline void set_kCmdCmdAccountEmailChangePassword_29(int32_t value)
	{
		___kCmdCmdAccountEmailChangePassword_29 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdAccountEmailChangeCustomName_30() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdAccountEmailChangeCustomName_30)); }
	inline int32_t get_kCmdCmdAccountEmailChangeCustomName_30() const { return ___kCmdCmdAccountEmailChangeCustomName_30; }
	inline int32_t* get_address_of_kCmdCmdAccountEmailChangeCustomName_30() { return &___kCmdCmdAccountEmailChangeCustomName_30; }
	inline void set_kCmdCmdAccountEmailChangeCustomName_30(int32_t value)
	{
		___kCmdCmdAccountEmailChangeCustomName_30 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdAccountEmailChangeAvatarUrl_31() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdAccountEmailChangeAvatarUrl_31)); }
	inline int32_t get_kCmdCmdAccountEmailChangeAvatarUrl_31() const { return ___kCmdCmdAccountEmailChangeAvatarUrl_31; }
	inline int32_t* get_address_of_kCmdCmdAccountEmailChangeAvatarUrl_31() { return &___kCmdCmdAccountEmailChangeAvatarUrl_31; }
	inline void set_kCmdCmdAccountEmailChangeAvatarUrl_31(int32_t value)
	{
		___kCmdCmdAccountEmailChangeAvatarUrl_31 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoomJoinRoom_32() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoomJoinRoom_32)); }
	inline int32_t get_kCmdCmdRoomJoinRoom_32() const { return ___kCmdCmdRoomJoinRoom_32; }
	inline int32_t* get_address_of_kCmdCmdRoomJoinRoom_32() { return &___kCmdCmdRoomJoinRoom_32; }
	inline void set_kCmdCmdRoomJoinRoom_32(int32_t value)
	{
		___kCmdCmdRoomJoinRoom_32 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetJoinRoomError_33() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetJoinRoomError_33)); }
	inline int32_t get_kTargetRpcTargetJoinRoomError_33() const { return ___kTargetRpcTargetJoinRoomError_33; }
	inline int32_t* get_address_of_kTargetRpcTargetJoinRoomError_33() { return &___kTargetRpcTargetJoinRoomError_33; }
	inline void set_kTargetRpcTargetJoinRoomError_33(int32_t value)
	{
		___kTargetRpcTargetJoinRoomError_33 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoomChangeName_34() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoomChangeName_34)); }
	inline int32_t get_kCmdCmdRoomChangeName_34() const { return ___kCmdCmdRoomChangeName_34; }
	inline int32_t* get_address_of_kCmdCmdRoomChangeName_34() { return &___kCmdCmdRoomChangeName_34; }
	inline void set_kCmdCmdRoomChangeName_34(int32_t value)
	{
		___kCmdCmdRoomChangeName_34 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoomChangeAllowHint_35() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoomChangeAllowHint_35)); }
	inline int32_t get_kCmdCmdRoomChangeAllowHint_35() const { return ___kCmdCmdRoomChangeAllowHint_35; }
	inline int32_t* get_address_of_kCmdCmdRoomChangeAllowHint_35() { return &___kCmdCmdRoomChangeAllowHint_35; }
	inline void set_kCmdCmdRoomChangeAllowHint_35(int32_t value)
	{
		___kCmdCmdRoomChangeAllowHint_35 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoomStateNormalNormalFreeze_36() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoomStateNormalNormalFreeze_36)); }
	inline int32_t get_kCmdCmdRoomStateNormalNormalFreeze_36() const { return ___kCmdCmdRoomStateNormalNormalFreeze_36; }
	inline int32_t* get_address_of_kCmdCmdRoomStateNormalNormalFreeze_36() { return &___kCmdCmdRoomStateNormalNormalFreeze_36; }
	inline void set_kCmdCmdRoomStateNormalNormalFreeze_36(int32_t value)
	{
		___kCmdCmdRoomStateNormalNormalFreeze_36 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoomStateNormalFreezeUnFreeze_37() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoomStateNormalFreezeUnFreeze_37)); }
	inline int32_t get_kCmdCmdRoomStateNormalFreezeUnFreeze_37() const { return ___kCmdCmdRoomStateNormalFreezeUnFreeze_37; }
	inline int32_t* get_address_of_kCmdCmdRoomStateNormalFreezeUnFreeze_37() { return &___kCmdCmdRoomStateNormalFreezeUnFreeze_37; }
	inline void set_kCmdCmdRoomStateNormalFreezeUnFreeze_37(int32_t value)
	{
		___kCmdCmdRoomStateNormalFreezeUnFreeze_37 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUserChangeRole_38() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUserChangeRole_38)); }
	inline int32_t get_kCmdCmdUserChangeRole_38() const { return ___kCmdCmdUserChangeRole_38; }
	inline int32_t* get_address_of_kCmdCmdUserChangeRole_38() { return &___kCmdCmdUserChangeRole_38; }
	inline void set_kCmdCmdUserChangeRole_38(int32_t value)
	{
		___kCmdCmdUserChangeRole_38 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUserMakeRoom_39() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUserMakeRoom_39)); }
	inline int32_t get_kCmdCmdUserMakeRoom_39() const { return ___kCmdCmdUserMakeRoom_39; }
	inline int32_t* get_address_of_kCmdCmdUserMakeRoom_39() { return &___kCmdCmdUserMakeRoom_39; }
	inline void set_kCmdCmdUserMakeRoom_39(int32_t value)
	{
		___kCmdCmdUserMakeRoom_39 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUserMakeFriendRequest_40() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUserMakeFriendRequest_40)); }
	inline int32_t get_kCmdCmdUserMakeFriendRequest_40() const { return ___kCmdCmdUserMakeFriendRequest_40; }
	inline int32_t* get_address_of_kCmdCmdUserMakeFriendRequest_40() { return &___kCmdCmdUserMakeFriendRequest_40; }
	inline void set_kCmdCmdUserMakeFriendRequest_40(int32_t value)
	{
		___kCmdCmdUserMakeFriendRequest_40 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdBanNormalBan_41() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdBanNormalBan_41)); }
	inline int32_t get_kCmdCmdBanNormalBan_41() const { return ___kCmdCmdBanNormalBan_41; }
	inline int32_t* get_address_of_kCmdCmdBanNormalBan_41() { return &___kCmdCmdBanNormalBan_41; }
	inline void set_kCmdCmdBanNormalBan_41(int32_t value)
	{
		___kCmdCmdBanNormalBan_41 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdBanBanUnBan_42() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdBanBanUnBan_42)); }
	inline int32_t get_kCmdCmdBanBanUnBan_42() const { return ___kCmdCmdBanBanUnBan_42; }
	inline int32_t* get_address_of_kCmdCmdBanBanUnBan_42() { return &___kCmdCmdBanBanUnBan_42; }
	inline void set_kCmdCmdBanBanUnBan_42(int32_t value)
	{
		___kCmdCmdBanBanUnBan_42 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetSendMessage_43() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetSendMessage_43)); }
	inline int32_t get_kTargetRpcTargetSendMessage_43() const { return ___kTargetRpcTargetSendMessage_43; }
	inline int32_t* get_address_of_kTargetRpcTargetSendMessage_43() { return &___kTargetRpcTargetSendMessage_43; }
	inline void set_kTargetRpcTargetSendMessage_43(int32_t value)
	{
		___kTargetRpcTargetSendMessage_43 = value;
	}

	inline static int32_t get_offset_of_kTargetRpcTargetSendDestroyIdentity_44() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kTargetRpcTargetSendDestroyIdentity_44)); }
	inline int32_t get_kTargetRpcTargetSendDestroyIdentity_44() const { return ___kTargetRpcTargetSendDestroyIdentity_44; }
	inline int32_t* get_address_of_kTargetRpcTargetSendDestroyIdentity_44() { return &___kTargetRpcTargetSendDestroyIdentity_44; }
	inline void set_kTargetRpcTargetSendDestroyIdentity_44(int32_t value)
	{
		___kTargetRpcTargetSendDestroyIdentity_44 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUndoRedoNoneAskLastTurn_45() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUndoRedoNoneAskLastTurn_45)); }
	inline int32_t get_kCmdCmdUndoRedoNoneAskLastTurn_45() const { return ___kCmdCmdUndoRedoNoneAskLastTurn_45; }
	inline int32_t* get_address_of_kCmdCmdUndoRedoNoneAskLastTurn_45() { return &___kCmdCmdUndoRedoNoneAskLastTurn_45; }
	inline void set_kCmdCmdUndoRedoNoneAskLastTurn_45(int32_t value)
	{
		___kCmdCmdUndoRedoNoneAskLastTurn_45 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUndoRedoNoneAskLastYourTurn_46() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUndoRedoNoneAskLastYourTurn_46)); }
	inline int32_t get_kCmdCmdUndoRedoNoneAskLastYourTurn_46() const { return ___kCmdCmdUndoRedoNoneAskLastYourTurn_46; }
	inline int32_t* get_address_of_kCmdCmdUndoRedoNoneAskLastYourTurn_46() { return &___kCmdCmdUndoRedoNoneAskLastYourTurn_46; }
	inline void set_kCmdCmdUndoRedoNoneAskLastYourTurn_46(int32_t value)
	{
		___kCmdCmdUndoRedoNoneAskLastYourTurn_46 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUndoRedoAskAnswer_47() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUndoRedoAskAnswer_47)); }
	inline int32_t get_kCmdCmdUndoRedoAskAnswer_47() const { return ___kCmdCmdUndoRedoAskAnswer_47; }
	inline int32_t* get_address_of_kCmdCmdUndoRedoAskAnswer_47() { return &___kCmdCmdUndoRedoAskAnswer_47; }
	inline void set_kCmdCmdUndoRedoAskAnswer_47(int32_t value)
	{
		___kCmdCmdUndoRedoAskAnswer_47 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdPlayerLeaveRoom_48() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdPlayerLeaveRoom_48)); }
	inline int32_t get_kCmdCmdPlayerLeaveRoom_48() const { return ___kCmdCmdPlayerLeaveRoom_48; }
	inline int32_t* get_address_of_kCmdCmdPlayerLeaveRoom_48() { return &___kCmdCmdPlayerLeaveRoom_48; }
	inline void set_kCmdCmdPlayerLeaveRoom_48(int32_t value)
	{
		___kCmdCmdPlayerLeaveRoom_48 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoomUserKick_49() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoomUserKick_49)); }
	inline int32_t get_kCmdCmdRoomUserKick_49() const { return ___kCmdCmdRoomUserKick_49; }
	inline int32_t* get_address_of_kCmdCmdRoomUserKick_49() { return &___kCmdCmdRoomUserKick_49; }
	inline void set_kCmdCmdRoomUserKick_49(int32_t value)
	{
		___kCmdCmdRoomUserKick_49 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoomUserUnKick_50() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoomUserUnKick_50)); }
	inline int32_t get_kCmdCmdRoomUserUnKick_50() const { return ___kCmdCmdRoomUserUnKick_50; }
	inline int32_t* get_address_of_kCmdCmdRoomUserUnKick_50() { return &___kCmdCmdRoomUserUnKick_50; }
	inline void set_kCmdCmdRoomUserUnKick_50(int32_t value)
	{
		___kCmdCmdRoomUserUnKick_50 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestDrawStateNoneMakeRequest_51() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestDrawStateNoneMakeRequest_51)); }
	inline int32_t get_kCmdCmdRequestDrawStateNoneMakeRequest_51() const { return ___kCmdCmdRequestDrawStateNoneMakeRequest_51; }
	inline int32_t* get_address_of_kCmdCmdRequestDrawStateNoneMakeRequest_51() { return &___kCmdCmdRequestDrawStateNoneMakeRequest_51; }
	inline void set_kCmdCmdRequestDrawStateNoneMakeRequest_51(int32_t value)
	{
		___kCmdCmdRequestDrawStateNoneMakeRequest_51 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestDrawStateAskAnswer_52() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestDrawStateAskAnswer_52)); }
	inline int32_t get_kCmdCmdRequestDrawStateAskAnswer_52() const { return ___kCmdCmdRequestDrawStateAskAnswer_52; }
	inline int32_t* get_address_of_kCmdCmdRequestDrawStateAskAnswer_52() { return &___kCmdCmdRequestDrawStateAskAnswer_52; }
	inline void set_kCmdCmdRequestDrawStateAskAnswer_52(int32_t value)
	{
		___kCmdCmdRequestDrawStateAskAnswer_52 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestDrawStateAcceptAnswer_53() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestDrawStateAcceptAnswer_53)); }
	inline int32_t get_kCmdCmdRequestDrawStateAcceptAnswer_53() const { return ___kCmdCmdRequestDrawStateAcceptAnswer_53; }
	inline int32_t* get_address_of_kCmdCmdRequestDrawStateAcceptAnswer_53() { return &___kCmdCmdRequestDrawStateAcceptAnswer_53; }
	inline void set_kCmdCmdRequestDrawStateAcceptAnswer_53(int32_t value)
	{
		___kCmdCmdRequestDrawStateAcceptAnswer_53 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGameFactoryChangeGameDataFactoryType_54() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGameFactoryChangeGameDataFactoryType_54)); }
	inline int32_t get_kCmdCmdGameFactoryChangeGameDataFactoryType_54() const { return ___kCmdCmdGameFactoryChangeGameDataFactoryType_54; }
	inline int32_t* get_address_of_kCmdCmdGameFactoryChangeGameDataFactoryType_54() { return &___kCmdCmdGameFactoryChangeGameDataFactoryType_54; }
	inline void set_kCmdCmdGameFactoryChangeGameDataFactoryType_54(int32_t value)
	{
		___kCmdCmdGameFactoryChangeGameDataFactoryType_54 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdPostureGameDataFactoryChangeGameData_55() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdPostureGameDataFactoryChangeGameData_55)); }
	inline int32_t get_kCmdCmdPostureGameDataFactoryChangeGameData_55() const { return ___kCmdCmdPostureGameDataFactoryChangeGameData_55; }
	inline int32_t* get_address_of_kCmdCmdPostureGameDataFactoryChangeGameData_55() { return &___kCmdCmdPostureGameDataFactoryChangeGameData_55; }
	inline void set_kCmdCmdPostureGameDataFactoryChangeGameData_55(int32_t value)
	{
		___kCmdCmdPostureGameDataFactoryChangeGameData_55 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdPostureGameDataFactoryChangeType_56() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdPostureGameDataFactoryChangeType_56)); }
	inline int32_t get_kCmdCmdPostureGameDataFactoryChangeType_56() const { return ___kCmdCmdPostureGameDataFactoryChangeType_56; }
	inline int32_t* get_address_of_kCmdCmdPostureGameDataFactoryChangeType_56() { return &___kCmdCmdPostureGameDataFactoryChangeType_56; }
	inline void set_kCmdCmdPostureGameDataFactoryChangeType_56(int32_t value)
	{
		___kCmdCmdPostureGameDataFactoryChangeType_56 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultGameDataFactoryChangeType_57() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultGameDataFactoryChangeType_57)); }
	inline int32_t get_kCmdCmdDefaultGameDataFactoryChangeType_57() const { return ___kCmdCmdDefaultGameDataFactoryChangeType_57; }
	inline int32_t* get_address_of_kCmdCmdDefaultGameDataFactoryChangeType_57() { return &___kCmdCmdDefaultGameDataFactoryChangeType_57; }
	inline void set_kCmdCmdDefaultGameDataFactoryChangeType_57(int32_t value)
	{
		___kCmdCmdDefaultGameDataFactoryChangeType_57 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultGameDataFactoryChangeUseRule_58() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultGameDataFactoryChangeUseRule_58)); }
	inline int32_t get_kCmdCmdDefaultGameDataFactoryChangeUseRule_58() const { return ___kCmdCmdDefaultGameDataFactoryChangeUseRule_58; }
	inline int32_t* get_address_of_kCmdCmdDefaultGameDataFactoryChangeUseRule_58() { return &___kCmdCmdDefaultGameDataFactoryChangeUseRule_58; }
	inline void set_kCmdCmdDefaultGameDataFactoryChangeUseRule_58(int32_t value)
	{
		___kCmdCmdDefaultGameDataFactoryChangeUseRule_58 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdPostureGameDataFactoryChangeUseRule_59() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdPostureGameDataFactoryChangeUseRule_59)); }
	inline int32_t get_kCmdCmdPostureGameDataFactoryChangeUseRule_59() const { return ___kCmdCmdPostureGameDataFactoryChangeUseRule_59; }
	inline int32_t* get_address_of_kCmdCmdPostureGameDataFactoryChangeUseRule_59() { return &___kCmdCmdPostureGameDataFactoryChangeUseRule_59; }
	inline void set_kCmdCmdPostureGameDataFactoryChangeUseRule_59(int32_t value)
	{
		___kCmdCmdPostureGameDataFactoryChangeUseRule_59 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGamePlayerSurrender_60() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGamePlayerSurrender_60)); }
	inline int32_t get_kCmdCmdGamePlayerSurrender_60() const { return ___kCmdCmdGamePlayerSurrender_60; }
	inline int32_t* get_address_of_kCmdCmdGamePlayerSurrender_60() { return &___kCmdCmdGamePlayerSurrender_60; }
	inline void set_kCmdCmdGamePlayerSurrender_60(int32_t value)
	{
		___kCmdCmdGamePlayerSurrender_60 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdPlayNormalPause_61() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdPlayNormalPause_61)); }
	inline int32_t get_kCmdCmdPlayNormalPause_61() const { return ___kCmdCmdPlayNormalPause_61; }
	inline int32_t* get_address_of_kCmdCmdPlayNormalPause_61() { return &___kCmdCmdPlayNormalPause_61; }
	inline void set_kCmdCmdPlayNormalPause_61(int32_t value)
	{
		___kCmdCmdPlayNormalPause_61 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdPlayPauseUnPause_62() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdPlayPauseUnPause_62)); }
	inline int32_t get_kCmdCmdPlayPauseUnPause_62() const { return ___kCmdCmdPlayPauseUnPause_62; }
	inline int32_t* get_address_of_kCmdCmdPlayPauseUnPause_62() { return &___kCmdCmdPlayPauseUnPause_62; }
	inline void set_kCmdCmdPlayPauseUnPause_62(int32_t value)
	{
		___kCmdCmdPlayPauseUnPause_62 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63)); }
	inline int32_t get_kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63() const { return ___kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63; }
	inline int32_t* get_address_of_kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63() { return &___kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63; }
	inline void set_kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63(int32_t value)
	{
		___kCmdCmdGamePlayerStateSurrenderMakeRequestCancel_63 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64)); }
	inline int32_t get_kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64() const { return ___kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64; }
	inline int32_t* get_address_of_kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64() { return &___kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64; }
	inline void set_kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64(int32_t value)
	{
		___kCmdCmdGamePlayerStateSurrenderCancelRequestCancel_64 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGamePlayerStateSurrenderAnswer_65() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGamePlayerStateSurrenderAnswer_65)); }
	inline int32_t get_kCmdCmdGamePlayerStateSurrenderAnswer_65() const { return ___kCmdCmdGamePlayerStateSurrenderAnswer_65; }
	inline int32_t* get_address_of_kCmdCmdGamePlayerStateSurrenderAnswer_65() { return &___kCmdCmdGamePlayerStateSurrenderAnswer_65; }
	inline void set_kCmdCmdGamePlayerStateSurrenderAnswer_65(int32_t value)
	{
		___kCmdCmdGamePlayerStateSurrenderAnswer_65 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHistoryAddHumanConnection_66() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHistoryAddHumanConnection_66)); }
	inline int32_t get_kCmdCmdHistoryAddHumanConnection_66() const { return ___kCmdCmdHistoryAddHumanConnection_66; }
	inline int32_t* get_address_of_kCmdCmdHistoryAddHumanConnection_66() { return &___kCmdCmdHistoryAddHumanConnection_66; }
	inline void set_kCmdCmdHistoryAddHumanConnection_66(int32_t value)
	{
		___kCmdCmdHistoryAddHumanConnection_66 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHistoryRemoveHumanConnection_67() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHistoryRemoveHumanConnection_67)); }
	inline int32_t get_kCmdCmdHistoryRemoveHumanConnection_67() const { return ___kCmdCmdHistoryRemoveHumanConnection_67; }
	inline int32_t* get_address_of_kCmdCmdHistoryRemoveHumanConnection_67() { return &___kCmdCmdHistoryRemoveHumanConnection_67; }
	inline void set_kCmdCmdHistoryRemoveHumanConnection_67(int32_t value)
	{
		___kCmdCmdHistoryRemoveHumanConnection_67 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFriendStateNoneMakeFriend_68() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFriendStateNoneMakeFriend_68)); }
	inline int32_t get_kCmdCmdFriendStateNoneMakeFriend_68() const { return ___kCmdCmdFriendStateNoneMakeFriend_68; }
	inline int32_t* get_address_of_kCmdCmdFriendStateNoneMakeFriend_68() { return &___kCmdCmdFriendStateNoneMakeFriend_68; }
	inline void set_kCmdCmdFriendStateNoneMakeFriend_68(int32_t value)
	{
		___kCmdCmdFriendStateNoneMakeFriend_68 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFriendStateNoneBan_69() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFriendStateNoneBan_69)); }
	inline int32_t get_kCmdCmdFriendStateNoneBan_69() const { return ___kCmdCmdFriendStateNoneBan_69; }
	inline int32_t* get_address_of_kCmdCmdFriendStateNoneBan_69() { return &___kCmdCmdFriendStateNoneBan_69; }
	inline void set_kCmdCmdFriendStateNoneBan_69(int32_t value)
	{
		___kCmdCmdFriendStateNoneBan_69 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFriendStateRequestAccept_70() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFriendStateRequestAccept_70)); }
	inline int32_t get_kCmdCmdFriendStateRequestAccept_70() const { return ___kCmdCmdFriendStateRequestAccept_70; }
	inline int32_t* get_address_of_kCmdCmdFriendStateRequestAccept_70() { return &___kCmdCmdFriendStateRequestAccept_70; }
	inline void set_kCmdCmdFriendStateRequestAccept_70(int32_t value)
	{
		___kCmdCmdFriendStateRequestAccept_70 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFriendStateRequestRefuse_71() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFriendStateRequestRefuse_71)); }
	inline int32_t get_kCmdCmdFriendStateRequestRefuse_71() const { return ___kCmdCmdFriendStateRequestRefuse_71; }
	inline int32_t* get_address_of_kCmdCmdFriendStateRequestRefuse_71() { return &___kCmdCmdFriendStateRequestRefuse_71; }
	inline void set_kCmdCmdFriendStateRequestRefuse_71(int32_t value)
	{
		___kCmdCmdFriendStateRequestRefuse_71 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFriendStateRequestCancel_72() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFriendStateRequestCancel_72)); }
	inline int32_t get_kCmdCmdFriendStateRequestCancel_72() const { return ___kCmdCmdFriendStateRequestCancel_72; }
	inline int32_t* get_address_of_kCmdCmdFriendStateRequestCancel_72() { return &___kCmdCmdFriendStateRequestCancel_72; }
	inline void set_kCmdCmdFriendStateRequestCancel_72(int32_t value)
	{
		___kCmdCmdFriendStateRequestCancel_72 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFriendStateAcceptUnFriend_73() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFriendStateAcceptUnFriend_73)); }
	inline int32_t get_kCmdCmdFriendStateAcceptUnFriend_73() const { return ___kCmdCmdFriendStateAcceptUnFriend_73; }
	inline int32_t* get_address_of_kCmdCmdFriendStateAcceptUnFriend_73() { return &___kCmdCmdFriendStateAcceptUnFriend_73; }
	inline void set_kCmdCmdFriendStateAcceptUnFriend_73(int32_t value)
	{
		___kCmdCmdFriendStateAcceptUnFriend_73 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFriendStateBanUnBan_74() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFriendStateBanUnBan_74)); }
	inline int32_t get_kCmdCmdFriendStateBanUnBan_74() const { return ___kCmdCmdFriendStateBanUnBan_74; }
	inline int32_t* get_address_of_kCmdCmdFriendStateBanUnBan_74() { return &___kCmdCmdFriendStateBanUnBan_74; }
	inline void set_kCmdCmdFriendStateBanUnBan_74(int32_t value)
	{
		___kCmdCmdFriendStateBanUnBan_74 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChatRoomSendNormalMessage_75() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChatRoomSendNormalMessage_75)); }
	inline int32_t get_kCmdCmdChatRoomSendNormalMessage_75() const { return ___kCmdCmdChatRoomSendNormalMessage_75; }
	inline int32_t* get_address_of_kCmdCmdChatRoomSendNormalMessage_75() { return &___kCmdCmdChatRoomSendNormalMessage_75; }
	inline void set_kCmdCmdChatRoomSendNormalMessage_75(int32_t value)
	{
		___kCmdCmdChatRoomSendNormalMessage_75 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChatMessageChangeState_76() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChatMessageChangeState_76)); }
	inline int32_t get_kCmdCmdChatMessageChangeState_76() const { return ___kCmdCmdChatMessageChangeState_76; }
	inline int32_t* get_address_of_kCmdCmdChatMessageChangeState_76() { return &___kCmdCmdChatMessageChangeState_76; }
	inline void set_kCmdCmdChatMessageChangeState_76(int32_t value)
	{
		___kCmdCmdChatMessageChangeState_76 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChatNormalContentEdit_77() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChatNormalContentEdit_77)); }
	inline int32_t get_kCmdCmdChatNormalContentEdit_77() const { return ___kCmdCmdChatNormalContentEdit_77; }
	inline int32_t* get_address_of_kCmdCmdChatNormalContentEdit_77() { return &___kCmdCmdChatNormalContentEdit_77; }
	inline void set_kCmdCmdChatNormalContentEdit_77(int32_t value)
	{
		___kCmdCmdChatNormalContentEdit_77 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTypingSendTyping_78() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTypingSendTyping_78)); }
	inline int32_t get_kCmdCmdTypingSendTyping_78() const { return ___kCmdCmdTypingSendTyping_78; }
	inline int32_t* get_address_of_kCmdCmdTypingSendTyping_78() { return &___kCmdCmdTypingSendTyping_78; }
	inline void set_kCmdCmdTypingSendTyping_78(int32_t value)
	{
		___kCmdCmdTypingSendTyping_78 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultChessChangeChess960_79() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultChessChangeChess960_79)); }
	inline int32_t get_kCmdCmdDefaultChessChangeChess960_79() const { return ___kCmdCmdDefaultChessChangeChess960_79; }
	inline int32_t* get_address_of_kCmdCmdDefaultChessChangeChess960_79() { return &___kCmdCmdDefaultChessChangeChess960_79; }
	inline void set_kCmdCmdDefaultChessChangeChess960_79(int32_t value)
	{
		___kCmdCmdDefaultChessChangeChess960_79 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultShatranjChangeChess960_80() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultShatranjChangeChess960_80)); }
	inline int32_t get_kCmdCmdDefaultShatranjChangeChess960_80() const { return ___kCmdCmdDefaultShatranjChangeChess960_80; }
	inline int32_t* get_address_of_kCmdCmdDefaultShatranjChangeChess960_80() { return &___kCmdCmdDefaultShatranjChangeChess960_80; }
	inline void set_kCmdCmdDefaultShatranjChangeChess960_80(int32_t value)
	{
		___kCmdCmdDefaultShatranjChangeChess960_80 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultMakrukChangeChess960_81() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultMakrukChangeChess960_81)); }
	inline int32_t get_kCmdCmdDefaultMakrukChangeChess960_81() const { return ___kCmdCmdDefaultMakrukChangeChess960_81; }
	inline int32_t* get_address_of_kCmdCmdDefaultMakrukChangeChess960_81() { return &___kCmdCmdDefaultMakrukChangeChess960_81; }
	inline void set_kCmdCmdDefaultMakrukChangeChess960_81(int32_t value)
	{
		___kCmdCmdDefaultMakrukChangeChess960_81 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultSeirawanChangeChess960_82() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultSeirawanChangeChess960_82)); }
	inline int32_t get_kCmdCmdDefaultSeirawanChangeChess960_82() const { return ___kCmdCmdDefaultSeirawanChangeChess960_82; }
	inline int32_t* get_address_of_kCmdCmdDefaultSeirawanChangeChess960_82() { return &___kCmdCmdDefaultSeirawanChangeChess960_82; }
	inline void set_kCmdCmdDefaultSeirawanChangeChess960_82(int32_t value)
	{
		___kCmdCmdDefaultSeirawanChangeChess960_82 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultFairyChessChangeVariantType_83() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultFairyChessChangeVariantType_83)); }
	inline int32_t get_kCmdCmdDefaultFairyChessChangeVariantType_83() const { return ___kCmdCmdDefaultFairyChessChangeVariantType_83; }
	inline int32_t* get_address_of_kCmdCmdDefaultFairyChessChangeVariantType_83() { return &___kCmdCmdDefaultFairyChessChangeVariantType_83; }
	inline void set_kCmdCmdDefaultFairyChessChangeVariantType_83(int32_t value)
	{
		___kCmdCmdDefaultFairyChessChangeVariantType_83 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultFairyChessChangeChess960_84() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultFairyChessChangeChess960_84)); }
	inline int32_t get_kCmdCmdDefaultFairyChessChangeChess960_84() const { return ___kCmdCmdDefaultFairyChessChangeChess960_84; }
	inline int32_t* get_address_of_kCmdCmdDefaultFairyChessChangeChess960_84() { return &___kCmdCmdDefaultFairyChessChangeChess960_84; }
	inline void set_kCmdCmdDefaultFairyChessChangeChess960_84(int32_t value)
	{
		___kCmdCmdDefaultFairyChessChangeChess960_84 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85)); }
	inline int32_t get_kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85() const { return ___kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85; }
	inline int32_t* get_address_of_kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85() { return &___kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85; }
	inline void set_kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85(int32_t value)
	{
		___kCmdCmdDefaultCoTuongUpChangeAllowViewCapture_85 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86)); }
	inline int32_t get_kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86() const { return ___kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86; }
	inline int32_t* get_address_of_kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86() { return &___kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86; }
	inline void set_kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86(int32_t value)
	{
		___kCmdCmdDefaultCoTuongUpChangeAllowWatcherViewHidden_86 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87)); }
	inline int32_t get_kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87() const { return ___kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87; }
	inline int32_t* get_address_of_kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87() { return &___kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87; }
	inline void set_kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87(int32_t value)
	{
		___kCmdCmdDefaultCoTuongUpChangeAllowOnlyFlip_87 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultGomokuChangeBoardSize_88() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultGomokuChangeBoardSize_88)); }
	inline int32_t get_kCmdCmdDefaultGomokuChangeBoardSize_88() const { return ___kCmdCmdDefaultGomokuChangeBoardSize_88; }
	inline int32_t* get_address_of_kCmdCmdDefaultGomokuChangeBoardSize_88() { return &___kCmdCmdDefaultGomokuChangeBoardSize_88; }
	inline void set_kCmdCmdDefaultGomokuChangeBoardSize_88(int32_t value)
	{
		___kCmdCmdDefaultGomokuChangeBoardSize_88 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultEnglishDraughtChangeMaxPly_89() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultEnglishDraughtChangeMaxPly_89)); }
	inline int32_t get_kCmdCmdDefaultEnglishDraughtChangeMaxPly_89() const { return ___kCmdCmdDefaultEnglishDraughtChangeMaxPly_89; }
	inline int32_t* get_address_of_kCmdCmdDefaultEnglishDraughtChangeMaxPly_89() { return &___kCmdCmdDefaultEnglishDraughtChangeMaxPly_89; }
	inline void set_kCmdCmdDefaultEnglishDraughtChangeMaxPly_89(int32_t value)
	{
		___kCmdCmdDefaultEnglishDraughtChangeMaxPly_89 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90)); }
	inline int32_t get_kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90() const { return ___kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90; }
	inline int32_t* get_address_of_kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90() { return &___kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90; }
	inline void set_kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90(int32_t value)
	{
		___kCmdCmdDefaultEnglishDraughtChangeThreeMoveRandom_90 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultInternationalDraughtChangeVariant_91() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultInternationalDraughtChangeVariant_91)); }
	inline int32_t get_kCmdCmdDefaultInternationalDraughtChangeVariant_91() const { return ___kCmdCmdDefaultInternationalDraughtChangeVariant_91; }
	inline int32_t* get_address_of_kCmdCmdDefaultInternationalDraughtChangeVariant_91() { return &___kCmdCmdDefaultInternationalDraughtChangeVariant_91; }
	inline void set_kCmdCmdDefaultInternationalDraughtChangeVariant_91(int32_t value)
	{
		___kCmdCmdDefaultInternationalDraughtChangeVariant_91 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultWeiqiChangeSize_92() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultWeiqiChangeSize_92)); }
	inline int32_t get_kCmdCmdDefaultWeiqiChangeSize_92() const { return ___kCmdCmdDefaultWeiqiChangeSize_92; }
	inline int32_t* get_address_of_kCmdCmdDefaultWeiqiChangeSize_92() { return &___kCmdCmdDefaultWeiqiChangeSize_92; }
	inline void set_kCmdCmdDefaultWeiqiChangeSize_92(int32_t value)
	{
		___kCmdCmdDefaultWeiqiChangeSize_92 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultWeiqiChangeKomi_93() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultWeiqiChangeKomi_93)); }
	inline int32_t get_kCmdCmdDefaultWeiqiChangeKomi_93() const { return ___kCmdCmdDefaultWeiqiChangeKomi_93; }
	inline int32_t* get_address_of_kCmdCmdDefaultWeiqiChangeKomi_93() { return &___kCmdCmdDefaultWeiqiChangeKomi_93; }
	inline void set_kCmdCmdDefaultWeiqiChangeKomi_93(int32_t value)
	{
		___kCmdCmdDefaultWeiqiChangeKomi_93 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultWeiqiChangeRule_94() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultWeiqiChangeRule_94)); }
	inline int32_t get_kCmdCmdDefaultWeiqiChangeRule_94() const { return ___kCmdCmdDefaultWeiqiChangeRule_94; }
	inline int32_t* get_address_of_kCmdCmdDefaultWeiqiChangeRule_94() { return &___kCmdCmdDefaultWeiqiChangeRule_94; }
	inline void set_kCmdCmdDefaultWeiqiChangeRule_94(int32_t value)
	{
		___kCmdCmdDefaultWeiqiChangeRule_94 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultWeiqiChangeHandicap_95() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultWeiqiChangeHandicap_95)); }
	inline int32_t get_kCmdCmdDefaultWeiqiChangeHandicap_95() const { return ___kCmdCmdDefaultWeiqiChangeHandicap_95; }
	inline int32_t* get_address_of_kCmdCmdDefaultWeiqiChangeHandicap_95() { return &___kCmdCmdDefaultWeiqiChangeHandicap_95; }
	inline void set_kCmdCmdDefaultWeiqiChangeHandicap_95(int32_t value)
	{
		___kCmdCmdDefaultWeiqiChangeHandicap_95 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultMineSweeperChangeN_96() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultMineSweeperChangeN_96)); }
	inline int32_t get_kCmdCmdDefaultMineSweeperChangeN_96() const { return ___kCmdCmdDefaultMineSweeperChangeN_96; }
	inline int32_t* get_address_of_kCmdCmdDefaultMineSweeperChangeN_96() { return &___kCmdCmdDefaultMineSweeperChangeN_96; }
	inline void set_kCmdCmdDefaultMineSweeperChangeN_96(int32_t value)
	{
		___kCmdCmdDefaultMineSweeperChangeN_96 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultMineSweeperChangeM_97() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultMineSweeperChangeM_97)); }
	inline int32_t get_kCmdCmdDefaultMineSweeperChangeM_97() const { return ___kCmdCmdDefaultMineSweeperChangeM_97; }
	inline int32_t* get_address_of_kCmdCmdDefaultMineSweeperChangeM_97() { return &___kCmdCmdDefaultMineSweeperChangeM_97; }
	inline void set_kCmdCmdDefaultMineSweeperChangeM_97(int32_t value)
	{
		___kCmdCmdDefaultMineSweeperChangeM_97 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultMineSweeperChangeMinK_98() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultMineSweeperChangeMinK_98)); }
	inline int32_t get_kCmdCmdDefaultMineSweeperChangeMinK_98() const { return ___kCmdCmdDefaultMineSweeperChangeMinK_98; }
	inline int32_t* get_address_of_kCmdCmdDefaultMineSweeperChangeMinK_98() { return &___kCmdCmdDefaultMineSweeperChangeMinK_98; }
	inline void set_kCmdCmdDefaultMineSweeperChangeMinK_98(int32_t value)
	{
		___kCmdCmdDefaultMineSweeperChangeMinK_98 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultMineSweeperChangeMaxK_99() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultMineSweeperChangeMaxK_99)); }
	inline int32_t get_kCmdCmdDefaultMineSweeperChangeMaxK_99() const { return ___kCmdCmdDefaultMineSweeperChangeMaxK_99; }
	inline int32_t* get_address_of_kCmdCmdDefaultMineSweeperChangeMaxK_99() { return &___kCmdCmdDefaultMineSweeperChangeMaxK_99; }
	inline void set_kCmdCmdDefaultMineSweeperChangeMaxK_99(int32_t value)
	{
		___kCmdCmdDefaultMineSweeperChangeMaxK_99 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100)); }
	inline int32_t get_kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100() const { return ___kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100; }
	inline int32_t* get_address_of_kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100() { return &___kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100; }
	inline void set_kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100(int32_t value)
	{
		___kCmdCmdDefaultMineSweeperChangeAllowWatchBomb_100 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdDefaultHexChangeBoardSize_101() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdDefaultHexChangeBoardSize_101)); }
	inline int32_t get_kCmdCmdDefaultHexChangeBoardSize_101() const { return ___kCmdCmdDefaultHexChangeBoardSize_101; }
	inline int32_t* get_address_of_kCmdCmdDefaultHexChangeBoardSize_101() { return &___kCmdCmdDefaultHexChangeBoardSize_101; }
	inline void set_kCmdCmdDefaultHexChangeBoardSize_101(int32_t value)
	{
		___kCmdCmdDefaultHexChangeBoardSize_101 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdWaitAIMoveInputSendInput_102() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdWaitAIMoveInputSendInput_102)); }
	inline int32_t get_kCmdCmdWaitAIMoveInputSendInput_102() const { return ___kCmdCmdWaitAIMoveInputSendInput_102; }
	inline int32_t* get_address_of_kCmdCmdWaitAIMoveInputSendInput_102() { return &___kCmdCmdWaitAIMoveInputSendInput_102; }
	inline void set_kCmdCmdWaitAIMoveInputSendInput_102(int32_t value)
	{
		___kCmdCmdWaitAIMoveInputSendInput_102 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeReportClientTime_103() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeReportClientTime_103)); }
	inline int32_t get_kCmdCmdTimeReportClientTime_103() const { return ___kCmdCmdTimeReportClientTime_103; }
	inline int32_t* get_address_of_kCmdCmdTimeReportClientTime_103() { return &___kCmdCmdTimeReportClientTime_103; }
	inline void set_kCmdCmdTimeReportClientTime_103(int32_t value)
	{
		___kCmdCmdTimeReportClientTime_103 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeControlChangeIsEnable_104() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeControlChangeIsEnable_104)); }
	inline int32_t get_kCmdCmdTimeControlChangeIsEnable_104() const { return ___kCmdCmdTimeControlChangeIsEnable_104; }
	inline int32_t* get_address_of_kCmdCmdTimeControlChangeIsEnable_104() { return &___kCmdCmdTimeControlChangeIsEnable_104; }
	inline void set_kCmdCmdTimeControlChangeIsEnable_104(int32_t value)
	{
		___kCmdCmdTimeControlChangeIsEnable_104 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeControlChangeAICanTimeOut_105() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeControlChangeAICanTimeOut_105)); }
	inline int32_t get_kCmdCmdTimeControlChangeAICanTimeOut_105() const { return ___kCmdCmdTimeControlChangeAICanTimeOut_105; }
	inline int32_t* get_address_of_kCmdCmdTimeControlChangeAICanTimeOut_105() { return &___kCmdCmdTimeControlChangeAICanTimeOut_105; }
	inline void set_kCmdCmdTimeControlChangeAICanTimeOut_105(int32_t value)
	{
		___kCmdCmdTimeControlChangeAICanTimeOut_105 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeControlChangeUse_106() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeControlChangeUse_106)); }
	inline int32_t get_kCmdCmdTimeControlChangeUse_106() const { return ___kCmdCmdTimeControlChangeUse_106; }
	inline int32_t* get_address_of_kCmdCmdTimeControlChangeUse_106() { return &___kCmdCmdTimeControlChangeUse_106; }
	inline void set_kCmdCmdTimeControlChangeUse_106(int32_t value)
	{
		___kCmdCmdTimeControlChangeUse_106 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeControlChangeSubType_107() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeControlChangeSubType_107)); }
	inline int32_t get_kCmdCmdTimeControlChangeSubType_107() const { return ___kCmdCmdTimeControlChangeSubType_107; }
	inline int32_t* get_address_of_kCmdCmdTimeControlChangeSubType_107() { return &___kCmdCmdTimeControlChangeSubType_107; }
	inline void set_kCmdCmdTimeControlChangeSubType_107(int32_t value)
	{
		___kCmdCmdTimeControlChangeSubType_107 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimePerTurnInfoLimitChangePerTurn_108() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimePerTurnInfoLimitChangePerTurn_108)); }
	inline int32_t get_kCmdCmdTimePerTurnInfoLimitChangePerTurn_108() const { return ___kCmdCmdTimePerTurnInfoLimitChangePerTurn_108; }
	inline int32_t* get_address_of_kCmdCmdTimePerTurnInfoLimitChangePerTurn_108() { return &___kCmdCmdTimePerTurnInfoLimitChangePerTurn_108; }
	inline void set_kCmdCmdTimePerTurnInfoLimitChangePerTurn_108(int32_t value)
	{
		___kCmdCmdTimePerTurnInfoLimitChangePerTurn_108 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTotalTimeInfoLimitChangeTotalTime_109() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTotalTimeInfoLimitChangeTotalTime_109)); }
	inline int32_t get_kCmdCmdTotalTimeInfoLimitChangeTotalTime_109() const { return ___kCmdCmdTotalTimeInfoLimitChangeTotalTime_109; }
	inline int32_t* get_address_of_kCmdCmdTotalTimeInfoLimitChangeTotalTime_109() { return &___kCmdCmdTotalTimeInfoLimitChangeTotalTime_109; }
	inline void set_kCmdCmdTotalTimeInfoLimitChangeTotalTime_109(int32_t value)
	{
		___kCmdCmdTotalTimeInfoLimitChangeTotalTime_109 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeInfoChangeTimePerTurnType_110() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeInfoChangeTimePerTurnType_110)); }
	inline int32_t get_kCmdCmdTimeInfoChangeTimePerTurnType_110() const { return ___kCmdCmdTimeInfoChangeTimePerTurnType_110; }
	inline int32_t* get_address_of_kCmdCmdTimeInfoChangeTimePerTurnType_110() { return &___kCmdCmdTimeInfoChangeTimePerTurnType_110; }
	inline void set_kCmdCmdTimeInfoChangeTimePerTurnType_110(int32_t value)
	{
		___kCmdCmdTimeInfoChangeTimePerTurnType_110 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeInfoChangeTotalTimeType_111() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeInfoChangeTotalTimeType_111)); }
	inline int32_t get_kCmdCmdTimeInfoChangeTotalTimeType_111() const { return ___kCmdCmdTimeInfoChangeTotalTimeType_111; }
	inline int32_t* get_address_of_kCmdCmdTimeInfoChangeTotalTimeType_111() { return &___kCmdCmdTimeInfoChangeTotalTimeType_111; }
	inline void set_kCmdCmdTimeInfoChangeTotalTimeType_111(int32_t value)
	{
		___kCmdCmdTimeInfoChangeTotalTimeType_111 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeInfoChangeOverTimePerTurnType_112() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeInfoChangeOverTimePerTurnType_112)); }
	inline int32_t get_kCmdCmdTimeInfoChangeOverTimePerTurnType_112() const { return ___kCmdCmdTimeInfoChangeOverTimePerTurnType_112; }
	inline int32_t* get_address_of_kCmdCmdTimeInfoChangeOverTimePerTurnType_112() { return &___kCmdCmdTimeInfoChangeOverTimePerTurnType_112; }
	inline void set_kCmdCmdTimeInfoChangeOverTimePerTurnType_112(int32_t value)
	{
		___kCmdCmdTimeInfoChangeOverTimePerTurnType_112 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeInfoChangeLagCompensation_113() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeInfoChangeLagCompensation_113)); }
	inline int32_t get_kCmdCmdTimeInfoChangeLagCompensation_113() const { return ___kCmdCmdTimeInfoChangeLagCompensation_113; }
	inline int32_t* get_address_of_kCmdCmdTimeInfoChangeLagCompensation_113() { return &___kCmdCmdTimeInfoChangeLagCompensation_113; }
	inline void set_kCmdCmdTimeInfoChangeLagCompensation_113(int32_t value)
	{
		___kCmdCmdTimeInfoChangeLagCompensation_113 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeControlHourGlassChangeInitTime_114() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeControlHourGlassChangeInitTime_114)); }
	inline int32_t get_kCmdCmdTimeControlHourGlassChangeInitTime_114() const { return ___kCmdCmdTimeControlHourGlassChangeInitTime_114; }
	inline int32_t* get_address_of_kCmdCmdTimeControlHourGlassChangeInitTime_114() { return &___kCmdCmdTimeControlHourGlassChangeInitTime_114; }
	inline void set_kCmdCmdTimeControlHourGlassChangeInitTime_114(int32_t value)
	{
		___kCmdCmdTimeControlHourGlassChangeInitTime_114 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdTimeControlHourGlassChangeLagCompensation_115() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdTimeControlHourGlassChangeLagCompensation_115)); }
	inline int32_t get_kCmdCmdTimeControlHourGlassChangeLagCompensation_115() const { return ___kCmdCmdTimeControlHourGlassChangeLagCompensation_115; }
	inline int32_t* get_address_of_kCmdCmdTimeControlHourGlassChangeLagCompensation_115() { return &___kCmdCmdTimeControlHourGlassChangeLagCompensation_115; }
	inline void set_kCmdCmdTimeControlHourGlassChangeLagCompensation_115(int32_t value)
	{
		___kCmdCmdTimeControlHourGlassChangeLagCompensation_115 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChessAIChangeDepth_116() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChessAIChangeDepth_116)); }
	inline int32_t get_kCmdCmdChessAIChangeDepth_116() const { return ___kCmdCmdChessAIChangeDepth_116; }
	inline int32_t* get_address_of_kCmdCmdChessAIChangeDepth_116() { return &___kCmdCmdChessAIChangeDepth_116; }
	inline void set_kCmdCmdChessAIChangeDepth_116(int32_t value)
	{
		___kCmdCmdChessAIChangeDepth_116 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChessAIChangeSkillLevel_117() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChessAIChangeSkillLevel_117)); }
	inline int32_t get_kCmdCmdChessAIChangeSkillLevel_117() const { return ___kCmdCmdChessAIChangeSkillLevel_117; }
	inline int32_t* get_address_of_kCmdCmdChessAIChangeSkillLevel_117() { return &___kCmdCmdChessAIChangeSkillLevel_117; }
	inline void set_kCmdCmdChessAIChangeSkillLevel_117(int32_t value)
	{
		___kCmdCmdChessAIChangeSkillLevel_117 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChessAIChangeDuration_118() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChessAIChangeDuration_118)); }
	inline int32_t get_kCmdCmdChessAIChangeDuration_118() const { return ___kCmdCmdChessAIChangeDuration_118; }
	inline int32_t* get_address_of_kCmdCmdChessAIChangeDuration_118() { return &___kCmdCmdChessAIChangeDuration_118; }
	inline void set_kCmdCmdChessAIChangeDuration_118(int32_t value)
	{
		___kCmdCmdChessAIChangeDuration_118 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFairyChessAIChangeDepth_119() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFairyChessAIChangeDepth_119)); }
	inline int32_t get_kCmdCmdFairyChessAIChangeDepth_119() const { return ___kCmdCmdFairyChessAIChangeDepth_119; }
	inline int32_t* get_address_of_kCmdCmdFairyChessAIChangeDepth_119() { return &___kCmdCmdFairyChessAIChangeDepth_119; }
	inline void set_kCmdCmdFairyChessAIChangeDepth_119(int32_t value)
	{
		___kCmdCmdFairyChessAIChangeDepth_119 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFairyChessAIChangeSkillLevel_120() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFairyChessAIChangeSkillLevel_120)); }
	inline int32_t get_kCmdCmdFairyChessAIChangeSkillLevel_120() const { return ___kCmdCmdFairyChessAIChangeSkillLevel_120; }
	inline int32_t* get_address_of_kCmdCmdFairyChessAIChangeSkillLevel_120() { return &___kCmdCmdFairyChessAIChangeSkillLevel_120; }
	inline void set_kCmdCmdFairyChessAIChangeSkillLevel_120(int32_t value)
	{
		___kCmdCmdFairyChessAIChangeSkillLevel_120 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdFairyChessAIChangeDuration_121() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdFairyChessAIChangeDuration_121)); }
	inline int32_t get_kCmdCmdFairyChessAIChangeDuration_121() const { return ___kCmdCmdFairyChessAIChangeDuration_121; }
	inline int32_t* get_address_of_kCmdCmdFairyChessAIChangeDuration_121() { return &___kCmdCmdFairyChessAIChangeDuration_121; }
	inline void set_kCmdCmdFairyChessAIChangeDuration_121(int32_t value)
	{
		___kCmdCmdFairyChessAIChangeDuration_121 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGomokuAIChangeSearchDepth_122() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGomokuAIChangeSearchDepth_122)); }
	inline int32_t get_kCmdCmdGomokuAIChangeSearchDepth_122() const { return ___kCmdCmdGomokuAIChangeSearchDepth_122; }
	inline int32_t* get_address_of_kCmdCmdGomokuAIChangeSearchDepth_122() { return &___kCmdCmdGomokuAIChangeSearchDepth_122; }
	inline void set_kCmdCmdGomokuAIChangeSearchDepth_122(int32_t value)
	{
		___kCmdCmdGomokuAIChangeSearchDepth_122 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGomokuAIChangeTimeLimit_123() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGomokuAIChangeTimeLimit_123)); }
	inline int32_t get_kCmdCmdGomokuAIChangeTimeLimit_123() const { return ___kCmdCmdGomokuAIChangeTimeLimit_123; }
	inline int32_t* get_address_of_kCmdCmdGomokuAIChangeTimeLimit_123() { return &___kCmdCmdGomokuAIChangeTimeLimit_123; }
	inline void set_kCmdCmdGomokuAIChangeTimeLimit_123(int32_t value)
	{
		___kCmdCmdGomokuAIChangeTimeLimit_123 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdGomokuAIChangeLevel_124() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdGomokuAIChangeLevel_124)); }
	inline int32_t get_kCmdCmdGomokuAIChangeLevel_124() const { return ___kCmdCmdGomokuAIChangeLevel_124; }
	inline int32_t* get_address_of_kCmdCmdGomokuAIChangeLevel_124() { return &___kCmdCmdGomokuAIChangeLevel_124; }
	inline void set_kCmdCmdGomokuAIChangeLevel_124(int32_t value)
	{
		___kCmdCmdGomokuAIChangeLevel_124 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdInternationalDraughtAIChangeBMove_125() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdInternationalDraughtAIChangeBMove_125)); }
	inline int32_t get_kCmdCmdInternationalDraughtAIChangeBMove_125() const { return ___kCmdCmdInternationalDraughtAIChangeBMove_125; }
	inline int32_t* get_address_of_kCmdCmdInternationalDraughtAIChangeBMove_125() { return &___kCmdCmdInternationalDraughtAIChangeBMove_125; }
	inline void set_kCmdCmdInternationalDraughtAIChangeBMove_125(int32_t value)
	{
		___kCmdCmdInternationalDraughtAIChangeBMove_125 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdInternationalDraughtAIChangeBook_126() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdInternationalDraughtAIChangeBook_126)); }
	inline int32_t get_kCmdCmdInternationalDraughtAIChangeBook_126() const { return ___kCmdCmdInternationalDraughtAIChangeBook_126; }
	inline int32_t* get_address_of_kCmdCmdInternationalDraughtAIChangeBook_126() { return &___kCmdCmdInternationalDraughtAIChangeBook_126; }
	inline void set_kCmdCmdInternationalDraughtAIChangeBook_126(int32_t value)
	{
		___kCmdCmdInternationalDraughtAIChangeBook_126 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdInternationalDraughtAIChangeDepth_127() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdInternationalDraughtAIChangeDepth_127)); }
	inline int32_t get_kCmdCmdInternationalDraughtAIChangeDepth_127() const { return ___kCmdCmdInternationalDraughtAIChangeDepth_127; }
	inline int32_t* get_address_of_kCmdCmdInternationalDraughtAIChangeDepth_127() { return &___kCmdCmdInternationalDraughtAIChangeDepth_127; }
	inline void set_kCmdCmdInternationalDraughtAIChangeDepth_127(int32_t value)
	{
		___kCmdCmdInternationalDraughtAIChangeDepth_127 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdInternationalDraughtAIChangeTime_128() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdInternationalDraughtAIChangeTime_128)); }
	inline int32_t get_kCmdCmdInternationalDraughtAIChangeTime_128() const { return ___kCmdCmdInternationalDraughtAIChangeTime_128; }
	inline int32_t* get_address_of_kCmdCmdInternationalDraughtAIChangeTime_128() { return &___kCmdCmdInternationalDraughtAIChangeTime_128; }
	inline void set_kCmdCmdInternationalDraughtAIChangeTime_128(int32_t value)
	{
		___kCmdCmdInternationalDraughtAIChangeTime_128 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdInternationalDraughtAIChangeInput_129() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdInternationalDraughtAIChangeInput_129)); }
	inline int32_t get_kCmdCmdInternationalDraughtAIChangeInput_129() const { return ___kCmdCmdInternationalDraughtAIChangeInput_129; }
	inline int32_t* get_address_of_kCmdCmdInternationalDraughtAIChangeInput_129() { return &___kCmdCmdInternationalDraughtAIChangeInput_129; }
	inline void set_kCmdCmdInternationalDraughtAIChangeInput_129(int32_t value)
	{
		___kCmdCmdInternationalDraughtAIChangeInput_129 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130)); }
	inline int32_t get_kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130() const { return ___kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130; }
	inline int32_t* get_address_of_kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130() { return &___kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130; }
	inline void set_kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130(int32_t value)
	{
		___kCmdCmdInternationalDraughtAIChangeUseEndGameDatabase_130 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdInternationalDraughtAIChangePickBestMove_131() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdInternationalDraughtAIChangePickBestMove_131)); }
	inline int32_t get_kCmdCmdInternationalDraughtAIChangePickBestMove_131() const { return ___kCmdCmdInternationalDraughtAIChangePickBestMove_131; }
	inline int32_t* get_address_of_kCmdCmdInternationalDraughtAIChangePickBestMove_131() { return &___kCmdCmdInternationalDraughtAIChangePickBestMove_131; }
	inline void set_kCmdCmdInternationalDraughtAIChangePickBestMove_131(int32_t value)
	{
		___kCmdCmdInternationalDraughtAIChangePickBestMove_131 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132)); }
	inline int32_t get_kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132() const { return ___kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132; }
	inline int32_t* get_address_of_kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132() { return &___kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132; }
	inline void set_kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132(int32_t value)
	{
		___kCmdCmdEnglishDraughtAIChangeThreeMoveRandom_132 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133)); }
	inline int32_t get_kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133() const { return ___kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133; }
	inline int32_t* get_address_of_kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133() { return &___kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133; }
	inline void set_kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133(int32_t value)
	{
		___kCmdCmdEnglishDraughtAIChangeFMaxSeconds_133 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdEnglishDraughtAIChangeGMaxDepth_134() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdEnglishDraughtAIChangeGMaxDepth_134)); }
	inline int32_t get_kCmdCmdEnglishDraughtAIChangeGMaxDepth_134() const { return ___kCmdCmdEnglishDraughtAIChangeGMaxDepth_134; }
	inline int32_t* get_address_of_kCmdCmdEnglishDraughtAIChangeGMaxDepth_134() { return &___kCmdCmdEnglishDraughtAIChangeGMaxDepth_134; }
	inline void set_kCmdCmdEnglishDraughtAIChangeGMaxDepth_134(int32_t value)
	{
		___kCmdCmdEnglishDraughtAIChangeGMaxDepth_134 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdEnglishDraughtAIChangePickBestMove_135() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdEnglishDraughtAIChangePickBestMove_135)); }
	inline int32_t get_kCmdCmdEnglishDraughtAIChangePickBestMove_135() const { return ___kCmdCmdEnglishDraughtAIChangePickBestMove_135; }
	inline int32_t* get_address_of_kCmdCmdEnglishDraughtAIChangePickBestMove_135() { return &___kCmdCmdEnglishDraughtAIChangePickBestMove_135; }
	inline void set_kCmdCmdEnglishDraughtAIChangePickBestMove_135(int32_t value)
	{
		___kCmdCmdEnglishDraughtAIChangePickBestMove_135 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRussianDraughtAIChangeTimeLimit_136() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRussianDraughtAIChangeTimeLimit_136)); }
	inline int32_t get_kCmdCmdRussianDraughtAIChangeTimeLimit_136() const { return ___kCmdCmdRussianDraughtAIChangeTimeLimit_136; }
	inline int32_t* get_address_of_kCmdCmdRussianDraughtAIChangeTimeLimit_136() { return &___kCmdCmdRussianDraughtAIChangeTimeLimit_136; }
	inline void set_kCmdCmdRussianDraughtAIChangeTimeLimit_136(int32_t value)
	{
		___kCmdCmdRussianDraughtAIChangeTimeLimit_136 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRussianDraughtAIChangePickBestMove_137() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRussianDraughtAIChangePickBestMove_137)); }
	inline int32_t get_kCmdCmdRussianDraughtAIChangePickBestMove_137() const { return ___kCmdCmdRussianDraughtAIChangePickBestMove_137; }
	inline int32_t* get_address_of_kCmdCmdRussianDraughtAIChangePickBestMove_137() { return &___kCmdCmdRussianDraughtAIChangePickBestMove_137; }
	inline void set_kCmdCmdRussianDraughtAIChangePickBestMove_137(int32_t value)
	{
		___kCmdCmdRussianDraughtAIChangePickBestMove_137 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdReversiAIChangeSort_138() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdReversiAIChangeSort_138)); }
	inline int32_t get_kCmdCmdReversiAIChangeSort_138() const { return ___kCmdCmdReversiAIChangeSort_138; }
	inline int32_t* get_address_of_kCmdCmdReversiAIChangeSort_138() { return &___kCmdCmdReversiAIChangeSort_138; }
	inline void set_kCmdCmdReversiAIChangeSort_138(int32_t value)
	{
		___kCmdCmdReversiAIChangeSort_138 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdReversiAIChangeMin_139() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdReversiAIChangeMin_139)); }
	inline int32_t get_kCmdCmdReversiAIChangeMin_139() const { return ___kCmdCmdReversiAIChangeMin_139; }
	inline int32_t* get_address_of_kCmdCmdReversiAIChangeMin_139() { return &___kCmdCmdReversiAIChangeMin_139; }
	inline void set_kCmdCmdReversiAIChangeMin_139(int32_t value)
	{
		___kCmdCmdReversiAIChangeMin_139 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdReversiAIChangeMax_140() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdReversiAIChangeMax_140)); }
	inline int32_t get_kCmdCmdReversiAIChangeMax_140() const { return ___kCmdCmdReversiAIChangeMax_140; }
	inline int32_t* get_address_of_kCmdCmdReversiAIChangeMax_140() { return &___kCmdCmdReversiAIChangeMax_140; }
	inline void set_kCmdCmdReversiAIChangeMax_140(int32_t value)
	{
		___kCmdCmdReversiAIChangeMax_140 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdReversiAIChangeEnd_141() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdReversiAIChangeEnd_141)); }
	inline int32_t get_kCmdCmdReversiAIChangeEnd_141() const { return ___kCmdCmdReversiAIChangeEnd_141; }
	inline int32_t* get_address_of_kCmdCmdReversiAIChangeEnd_141() { return &___kCmdCmdReversiAIChangeEnd_141; }
	inline void set_kCmdCmdReversiAIChangeEnd_141(int32_t value)
	{
		___kCmdCmdReversiAIChangeEnd_141 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdReversiAIChangeMsLeft_142() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdReversiAIChangeMsLeft_142)); }
	inline int32_t get_kCmdCmdReversiAIChangeMsLeft_142() const { return ___kCmdCmdReversiAIChangeMsLeft_142; }
	inline int32_t* get_address_of_kCmdCmdReversiAIChangeMsLeft_142() { return &___kCmdCmdReversiAIChangeMsLeft_142; }
	inline void set_kCmdCmdReversiAIChangeMsLeft_142(int32_t value)
	{
		___kCmdCmdReversiAIChangeMsLeft_142 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdReversiAIChangeUseBook_143() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdReversiAIChangeUseBook_143)); }
	inline int32_t get_kCmdCmdReversiAIChangeUseBook_143() const { return ___kCmdCmdReversiAIChangeUseBook_143; }
	inline int32_t* get_address_of_kCmdCmdReversiAIChangeUseBook_143() { return &___kCmdCmdReversiAIChangeUseBook_143; }
	inline void set_kCmdCmdReversiAIChangeUseBook_143(int32_t value)
	{
		___kCmdCmdReversiAIChangeUseBook_143 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdReversiAIChangePercent_144() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdReversiAIChangePercent_144)); }
	inline int32_t get_kCmdCmdReversiAIChangePercent_144() const { return ___kCmdCmdReversiAIChangePercent_144; }
	inline int32_t* get_address_of_kCmdCmdReversiAIChangePercent_144() { return &___kCmdCmdReversiAIChangePercent_144; }
	inline void set_kCmdCmdReversiAIChangePercent_144(int32_t value)
	{
		___kCmdCmdReversiAIChangePercent_144 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShatranjAIChangeDepth_145() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShatranjAIChangeDepth_145)); }
	inline int32_t get_kCmdCmdShatranjAIChangeDepth_145() const { return ___kCmdCmdShatranjAIChangeDepth_145; }
	inline int32_t* get_address_of_kCmdCmdShatranjAIChangeDepth_145() { return &___kCmdCmdShatranjAIChangeDepth_145; }
	inline void set_kCmdCmdShatranjAIChangeDepth_145(int32_t value)
	{
		___kCmdCmdShatranjAIChangeDepth_145 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShatranjAIChangeSkillLevel_146() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShatranjAIChangeSkillLevel_146)); }
	inline int32_t get_kCmdCmdShatranjAIChangeSkillLevel_146() const { return ___kCmdCmdShatranjAIChangeSkillLevel_146; }
	inline int32_t* get_address_of_kCmdCmdShatranjAIChangeSkillLevel_146() { return &___kCmdCmdShatranjAIChangeSkillLevel_146; }
	inline void set_kCmdCmdShatranjAIChangeSkillLevel_146(int32_t value)
	{
		___kCmdCmdShatranjAIChangeSkillLevel_146 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShatranjAIChangeDuration_147() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShatranjAIChangeDuration_147)); }
	inline int32_t get_kCmdCmdShatranjAIChangeDuration_147() const { return ___kCmdCmdShatranjAIChangeDuration_147; }
	inline int32_t* get_address_of_kCmdCmdShatranjAIChangeDuration_147() { return &___kCmdCmdShatranjAIChangeDuration_147; }
	inline void set_kCmdCmdShatranjAIChangeDuration_147(int32_t value)
	{
		___kCmdCmdShatranjAIChangeDuration_147 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdMakrukAIChangeDepth_148() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdMakrukAIChangeDepth_148)); }
	inline int32_t get_kCmdCmdMakrukAIChangeDepth_148() const { return ___kCmdCmdMakrukAIChangeDepth_148; }
	inline int32_t* get_address_of_kCmdCmdMakrukAIChangeDepth_148() { return &___kCmdCmdMakrukAIChangeDepth_148; }
	inline void set_kCmdCmdMakrukAIChangeDepth_148(int32_t value)
	{
		___kCmdCmdMakrukAIChangeDepth_148 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdMakrukAIChangeSkillLevel_149() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdMakrukAIChangeSkillLevel_149)); }
	inline int32_t get_kCmdCmdMakrukAIChangeSkillLevel_149() const { return ___kCmdCmdMakrukAIChangeSkillLevel_149; }
	inline int32_t* get_address_of_kCmdCmdMakrukAIChangeSkillLevel_149() { return &___kCmdCmdMakrukAIChangeSkillLevel_149; }
	inline void set_kCmdCmdMakrukAIChangeSkillLevel_149(int32_t value)
	{
		___kCmdCmdMakrukAIChangeSkillLevel_149 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdMakrukAIChangeDuration_150() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdMakrukAIChangeDuration_150)); }
	inline int32_t get_kCmdCmdMakrukAIChangeDuration_150() const { return ___kCmdCmdMakrukAIChangeDuration_150; }
	inline int32_t* get_address_of_kCmdCmdMakrukAIChangeDuration_150() { return &___kCmdCmdMakrukAIChangeDuration_150; }
	inline void set_kCmdCmdMakrukAIChangeDuration_150(int32_t value)
	{
		___kCmdCmdMakrukAIChangeDuration_150 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSeirawanAIChangeDepth_151() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSeirawanAIChangeDepth_151)); }
	inline int32_t get_kCmdCmdSeirawanAIChangeDepth_151() const { return ___kCmdCmdSeirawanAIChangeDepth_151; }
	inline int32_t* get_address_of_kCmdCmdSeirawanAIChangeDepth_151() { return &___kCmdCmdSeirawanAIChangeDepth_151; }
	inline void set_kCmdCmdSeirawanAIChangeDepth_151(int32_t value)
	{
		___kCmdCmdSeirawanAIChangeDepth_151 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSeirawanAIChangeSkillLevel_152() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSeirawanAIChangeSkillLevel_152)); }
	inline int32_t get_kCmdCmdSeirawanAIChangeSkillLevel_152() const { return ___kCmdCmdSeirawanAIChangeSkillLevel_152; }
	inline int32_t* get_address_of_kCmdCmdSeirawanAIChangeSkillLevel_152() { return &___kCmdCmdSeirawanAIChangeSkillLevel_152; }
	inline void set_kCmdCmdSeirawanAIChangeSkillLevel_152(int32_t value)
	{
		___kCmdCmdSeirawanAIChangeSkillLevel_152 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSeirawanAIChangeDuration_153() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSeirawanAIChangeDuration_153)); }
	inline int32_t get_kCmdCmdSeirawanAIChangeDuration_153() const { return ___kCmdCmdSeirawanAIChangeDuration_153; }
	inline int32_t* get_address_of_kCmdCmdSeirawanAIChangeDuration_153() { return &___kCmdCmdSeirawanAIChangeDuration_153; }
	inline void set_kCmdCmdSeirawanAIChangeDuration_153(int32_t value)
	{
		___kCmdCmdSeirawanAIChangeDuration_153 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShogiAIChangeDepth_154() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShogiAIChangeDepth_154)); }
	inline int32_t get_kCmdCmdShogiAIChangeDepth_154() const { return ___kCmdCmdShogiAIChangeDepth_154; }
	inline int32_t* get_address_of_kCmdCmdShogiAIChangeDepth_154() { return &___kCmdCmdShogiAIChangeDepth_154; }
	inline void set_kCmdCmdShogiAIChangeDepth_154(int32_t value)
	{
		___kCmdCmdShogiAIChangeDepth_154 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShogiAIChangeSkillLevel_155() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShogiAIChangeSkillLevel_155)); }
	inline int32_t get_kCmdCmdShogiAIChangeSkillLevel_155() const { return ___kCmdCmdShogiAIChangeSkillLevel_155; }
	inline int32_t* get_address_of_kCmdCmdShogiAIChangeSkillLevel_155() { return &___kCmdCmdShogiAIChangeSkillLevel_155; }
	inline void set_kCmdCmdShogiAIChangeSkillLevel_155(int32_t value)
	{
		___kCmdCmdShogiAIChangeSkillLevel_155 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShogiAIChangeMr_156() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShogiAIChangeMr_156)); }
	inline int32_t get_kCmdCmdShogiAIChangeMr_156() const { return ___kCmdCmdShogiAIChangeMr_156; }
	inline int32_t* get_address_of_kCmdCmdShogiAIChangeMr_156() { return &___kCmdCmdShogiAIChangeMr_156; }
	inline void set_kCmdCmdShogiAIChangeMr_156(int32_t value)
	{
		___kCmdCmdShogiAIChangeMr_156 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShogiAIChangeDuration_157() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShogiAIChangeDuration_157)); }
	inline int32_t get_kCmdCmdShogiAIChangeDuration_157() const { return ___kCmdCmdShogiAIChangeDuration_157; }
	inline int32_t* get_address_of_kCmdCmdShogiAIChangeDuration_157() { return &___kCmdCmdShogiAIChangeDuration_157; }
	inline void set_kCmdCmdShogiAIChangeDuration_157(int32_t value)
	{
		___kCmdCmdShogiAIChangeDuration_157 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdShogiAIChangeUseBook_158() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdShogiAIChangeUseBook_158)); }
	inline int32_t get_kCmdCmdShogiAIChangeUseBook_158() const { return ___kCmdCmdShogiAIChangeUseBook_158; }
	inline int32_t* get_address_of_kCmdCmdShogiAIChangeUseBook_158() { return &___kCmdCmdShogiAIChangeUseBook_158; }
	inline void set_kCmdCmdShogiAIChangeUseBook_158(int32_t value)
	{
		___kCmdCmdShogiAIChangeUseBook_158 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdWeiqiAIChangeCanResign_159() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdWeiqiAIChangeCanResign_159)); }
	inline int32_t get_kCmdCmdWeiqiAIChangeCanResign_159() const { return ___kCmdCmdWeiqiAIChangeCanResign_159; }
	inline int32_t* get_address_of_kCmdCmdWeiqiAIChangeCanResign_159() { return &___kCmdCmdWeiqiAIChangeCanResign_159; }
	inline void set_kCmdCmdWeiqiAIChangeCanResign_159(int32_t value)
	{
		___kCmdCmdWeiqiAIChangeCanResign_159 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdWeiqiAIChangeUseBook_160() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdWeiqiAIChangeUseBook_160)); }
	inline int32_t get_kCmdCmdWeiqiAIChangeUseBook_160() const { return ___kCmdCmdWeiqiAIChangeUseBook_160; }
	inline int32_t* get_address_of_kCmdCmdWeiqiAIChangeUseBook_160() { return &___kCmdCmdWeiqiAIChangeUseBook_160; }
	inline void set_kCmdCmdWeiqiAIChangeUseBook_160(int32_t value)
	{
		___kCmdCmdWeiqiAIChangeUseBook_160 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdWeiqiAIChangeTime_161() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdWeiqiAIChangeTime_161)); }
	inline int32_t get_kCmdCmdWeiqiAIChangeTime_161() const { return ___kCmdCmdWeiqiAIChangeTime_161; }
	inline int32_t* get_address_of_kCmdCmdWeiqiAIChangeTime_161() { return &___kCmdCmdWeiqiAIChangeTime_161; }
	inline void set_kCmdCmdWeiqiAIChangeTime_161(int32_t value)
	{
		___kCmdCmdWeiqiAIChangeTime_161 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdWeiqiAIChangeGames_162() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdWeiqiAIChangeGames_162)); }
	inline int32_t get_kCmdCmdWeiqiAIChangeGames_162() const { return ___kCmdCmdWeiqiAIChangeGames_162; }
	inline int32_t* get_address_of_kCmdCmdWeiqiAIChangeGames_162() { return &___kCmdCmdWeiqiAIChangeGames_162; }
	inline void set_kCmdCmdWeiqiAIChangeGames_162(int32_t value)
	{
		___kCmdCmdWeiqiAIChangeGames_162 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdWeiqiAIChangeEngine_163() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdWeiqiAIChangeEngine_163)); }
	inline int32_t get_kCmdCmdWeiqiAIChangeEngine_163() const { return ___kCmdCmdWeiqiAIChangeEngine_163; }
	inline int32_t* get_address_of_kCmdCmdWeiqiAIChangeEngine_163() { return &___kCmdCmdWeiqiAIChangeEngine_163; }
	inline void set_kCmdCmdWeiqiAIChangeEngine_163(int32_t value)
	{
		___kCmdCmdWeiqiAIChangeEngine_163 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdXiangqiAIChangeDepth_164() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdXiangqiAIChangeDepth_164)); }
	inline int32_t get_kCmdCmdXiangqiAIChangeDepth_164() const { return ___kCmdCmdXiangqiAIChangeDepth_164; }
	inline int32_t* get_address_of_kCmdCmdXiangqiAIChangeDepth_164() { return &___kCmdCmdXiangqiAIChangeDepth_164; }
	inline void set_kCmdCmdXiangqiAIChangeDepth_164(int32_t value)
	{
		___kCmdCmdXiangqiAIChangeDepth_164 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdXiangqiAIChangeThinkTime_165() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdXiangqiAIChangeThinkTime_165)); }
	inline int32_t get_kCmdCmdXiangqiAIChangeThinkTime_165() const { return ___kCmdCmdXiangqiAIChangeThinkTime_165; }
	inline int32_t* get_address_of_kCmdCmdXiangqiAIChangeThinkTime_165() { return &___kCmdCmdXiangqiAIChangeThinkTime_165; }
	inline void set_kCmdCmdXiangqiAIChangeThinkTime_165(int32_t value)
	{
		___kCmdCmdXiangqiAIChangeThinkTime_165 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdXiangqiAIChangeUseBook_166() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdXiangqiAIChangeUseBook_166)); }
	inline int32_t get_kCmdCmdXiangqiAIChangeUseBook_166() const { return ___kCmdCmdXiangqiAIChangeUseBook_166; }
	inline int32_t* get_address_of_kCmdCmdXiangqiAIChangeUseBook_166() { return &___kCmdCmdXiangqiAIChangeUseBook_166; }
	inline void set_kCmdCmdXiangqiAIChangeUseBook_166(int32_t value)
	{
		___kCmdCmdXiangqiAIChangeUseBook_166 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdXiangqiAIChangePickBestMove_167() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdXiangqiAIChangePickBestMove_167)); }
	inline int32_t get_kCmdCmdXiangqiAIChangePickBestMove_167() const { return ___kCmdCmdXiangqiAIChangePickBestMove_167; }
	inline int32_t* get_address_of_kCmdCmdXiangqiAIChangePickBestMove_167() { return &___kCmdCmdXiangqiAIChangePickBestMove_167; }
	inline void set_kCmdCmdXiangqiAIChangePickBestMove_167(int32_t value)
	{
		___kCmdCmdXiangqiAIChangePickBestMove_167 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdMineSweeperAIChangeFirstMoveType_168() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdMineSweeperAIChangeFirstMoveType_168)); }
	inline int32_t get_kCmdCmdMineSweeperAIChangeFirstMoveType_168() const { return ___kCmdCmdMineSweeperAIChangeFirstMoveType_168; }
	inline int32_t* get_address_of_kCmdCmdMineSweeperAIChangeFirstMoveType_168() { return &___kCmdCmdMineSweeperAIChangeFirstMoveType_168; }
	inline void set_kCmdCmdMineSweeperAIChangeFirstMoveType_168(int32_t value)
	{
		___kCmdCmdMineSweeperAIChangeFirstMoveType_168 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHexAIChangeLimitTime_169() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHexAIChangeLimitTime_169)); }
	inline int32_t get_kCmdCmdHexAIChangeLimitTime_169() const { return ___kCmdCmdHexAIChangeLimitTime_169; }
	inline int32_t* get_address_of_kCmdCmdHexAIChangeLimitTime_169() { return &___kCmdCmdHexAIChangeLimitTime_169; }
	inline void set_kCmdCmdHexAIChangeLimitTime_169(int32_t value)
	{
		___kCmdCmdHexAIChangeLimitTime_169 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdHexAIChangeFirstMoveCenter_170() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdHexAIChangeFirstMoveCenter_170)); }
	inline int32_t get_kCmdCmdHexAIChangeFirstMoveCenter_170() const { return ___kCmdCmdHexAIChangeFirstMoveCenter_170; }
	inline int32_t* get_address_of_kCmdCmdHexAIChangeFirstMoveCenter_170() { return &___kCmdCmdHexAIChangeFirstMoveCenter_170; }
	inline void set_kCmdCmdHexAIChangeFirstMoveCenter_170(int32_t value)
	{
		___kCmdCmdHexAIChangeFirstMoveCenter_170 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdComputerChangeName_171() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdComputerChangeName_171)); }
	inline int32_t get_kCmdCmdComputerChangeName_171() const { return ___kCmdCmdComputerChangeName_171; }
	inline int32_t* get_address_of_kCmdCmdComputerChangeName_171() { return &___kCmdCmdComputerChangeName_171; }
	inline void set_kCmdCmdComputerChangeName_171(int32_t value)
	{
		___kCmdCmdComputerChangeName_171 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdComputerChangeAvatarUrl_172() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdComputerChangeAvatarUrl_172)); }
	inline int32_t get_kCmdCmdComputerChangeAvatarUrl_172() const { return ___kCmdCmdComputerChangeAvatarUrl_172; }
	inline int32_t* get_address_of_kCmdCmdComputerChangeAvatarUrl_172() { return &___kCmdCmdComputerChangeAvatarUrl_172; }
	inline void set_kCmdCmdComputerChangeAvatarUrl_172(int32_t value)
	{
		___kCmdCmdComputerChangeAvatarUrl_172 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRightsHaveLimitChangeLimit_173() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRightsHaveLimitChangeLimit_173)); }
	inline int32_t get_kCmdCmdRightsHaveLimitChangeLimit_173() const { return ___kCmdCmdRightsHaveLimitChangeLimit_173; }
	inline int32_t* get_address_of_kCmdCmdRightsHaveLimitChangeLimit_173() { return &___kCmdCmdRightsHaveLimitChangeLimit_173; }
	inline void set_kCmdCmdRightsHaveLimitChangeLimit_173(int32_t value)
	{
		___kCmdCmdRightsHaveLimitChangeLimit_173 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUndoRedoRightChangeNeedAccept_174() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUndoRedoRightChangeNeedAccept_174)); }
	inline int32_t get_kCmdCmdUndoRedoRightChangeNeedAccept_174() const { return ___kCmdCmdUndoRedoRightChangeNeedAccept_174; }
	inline int32_t* get_address_of_kCmdCmdUndoRedoRightChangeNeedAccept_174() { return &___kCmdCmdUndoRedoRightChangeNeedAccept_174; }
	inline void set_kCmdCmdUndoRedoRightChangeNeedAccept_174(int32_t value)
	{
		___kCmdCmdUndoRedoRightChangeNeedAccept_174 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUndoRedoRightChangeNeedAdmin_175() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUndoRedoRightChangeNeedAdmin_175)); }
	inline int32_t get_kCmdCmdUndoRedoRightChangeNeedAdmin_175() const { return ___kCmdCmdUndoRedoRightChangeNeedAdmin_175; }
	inline int32_t* get_address_of_kCmdCmdUndoRedoRightChangeNeedAdmin_175() { return &___kCmdCmdUndoRedoRightChangeNeedAdmin_175; }
	inline void set_kCmdCmdUndoRedoRightChangeNeedAdmin_175(int32_t value)
	{
		___kCmdCmdUndoRedoRightChangeNeedAdmin_175 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdUndoRedoRightChangeLimitType_176() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdUndoRedoRightChangeLimitType_176)); }
	inline int32_t get_kCmdCmdUndoRedoRightChangeLimitType_176() const { return ___kCmdCmdUndoRedoRightChangeLimitType_176; }
	inline int32_t* get_address_of_kCmdCmdUndoRedoRightChangeLimitType_176() { return &___kCmdCmdUndoRedoRightChangeLimitType_176; }
	inline void set_kCmdCmdUndoRedoRightChangeLimitType_176(int32_t value)
	{
		___kCmdCmdUndoRedoRightChangeLimitType_176 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChangeGamePlayerRightChangeCanChange_177() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChangeGamePlayerRightChangeCanChange_177)); }
	inline int32_t get_kCmdCmdChangeGamePlayerRightChangeCanChange_177() const { return ___kCmdCmdChangeGamePlayerRightChangeCanChange_177; }
	inline int32_t* get_address_of_kCmdCmdChangeGamePlayerRightChangeCanChange_177() { return &___kCmdCmdChangeGamePlayerRightChangeCanChange_177; }
	inline void set_kCmdCmdChangeGamePlayerRightChangeCanChange_177(int32_t value)
	{
		___kCmdCmdChangeGamePlayerRightChangeCanChange_177 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178)); }
	inline int32_t get_kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178() const { return ___kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178; }
	inline int32_t* get_address_of_kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178() { return &___kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178; }
	inline void set_kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178(int32_t value)
	{
		___kCmdCmdChangeGamePlayerRightChangeCanChangePlayerLeft_178 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179)); }
	inline int32_t get_kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179() const { return ___kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179; }
	inline int32_t* get_address_of_kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179() { return &___kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179; }
	inline void set_kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179(int32_t value)
	{
		___kCmdCmdChangeGamePlayerRightChangeNeedAdminAccept_179 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180)); }
	inline int32_t get_kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180() const { return ___kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180; }
	inline int32_t* get_address_of_kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180() { return &___kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180; }
	inline void set_kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180(int32_t value)
	{
		___kCmdCmdChangeGamePlayerRightChangeOnlyAdminNeed_180 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSingleContestFactoryChangePlayerPerTeam_181() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSingleContestFactoryChangePlayerPerTeam_181)); }
	inline int32_t get_kCmdCmdSingleContestFactoryChangePlayerPerTeam_181() const { return ___kCmdCmdSingleContestFactoryChangePlayerPerTeam_181; }
	inline int32_t* get_address_of_kCmdCmdSingleContestFactoryChangePlayerPerTeam_181() { return &___kCmdCmdSingleContestFactoryChangePlayerPerTeam_181; }
	inline void set_kCmdCmdSingleContestFactoryChangePlayerPerTeam_181(int32_t value)
	{
		___kCmdCmdSingleContestFactoryChangePlayerPerTeam_181 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSingleContestFactoryChangeRoundFactoryType_182() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSingleContestFactoryChangeRoundFactoryType_182)); }
	inline int32_t get_kCmdCmdSingleContestFactoryChangeRoundFactoryType_182() const { return ___kCmdCmdSingleContestFactoryChangeRoundFactoryType_182; }
	inline int32_t* get_address_of_kCmdCmdSingleContestFactoryChangeRoundFactoryType_182() { return &___kCmdCmdSingleContestFactoryChangeRoundFactoryType_182; }
	inline void set_kCmdCmdSingleContestFactoryChangeRoundFactoryType_182(int32_t value)
	{
		___kCmdCmdSingleContestFactoryChangeRoundFactoryType_182 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183)); }
	inline int32_t get_kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183() const { return ___kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183; }
	inline int32_t* get_address_of_kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183() { return &___kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183; }
	inline void set_kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183(int32_t value)
	{
		___kCmdCmdSingleContestFactoryChangeNewRoundLimitType_183 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSingleContestFactoryChangeCalculateScoreType_184() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSingleContestFactoryChangeCalculateScoreType_184)); }
	inline int32_t get_kCmdCmdSingleContestFactoryChangeCalculateScoreType_184() const { return ___kCmdCmdSingleContestFactoryChangeCalculateScoreType_184; }
	inline int32_t* get_address_of_kCmdCmdSingleContestFactoryChangeCalculateScoreType_184() { return &___kCmdCmdSingleContestFactoryChangeCalculateScoreType_184; }
	inline void set_kCmdCmdSingleContestFactoryChangeCalculateScoreType_184(int32_t value)
	{
		___kCmdCmdSingleContestFactoryChangeCalculateScoreType_184 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185)); }
	inline int32_t get_kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185() const { return ___kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185; }
	inline int32_t* get_address_of_kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185() { return &___kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185; }
	inline void set_kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185(int32_t value)
	{
		___kCmdCmdRequestNewRoundHaveLimitChangeMaxRound_185 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186)); }
	inline int32_t get_kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186() const { return ___kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186; }
	inline int32_t* get_address_of_kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186() { return &___kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186; }
	inline void set_kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186(int32_t value)
	{
		___kCmdCmdRequestNewRoundHaveLimitChangeEnoughScoreStop_186 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187)); }
	inline int32_t get_kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187() const { return ___kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187; }
	inline int32_t* get_address_of_kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187() { return &___kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187; }
	inline void set_kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187(int32_t value)
	{
		___kCmdCmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound_187 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewRoundStateAskAccept_188() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewRoundStateAskAccept_188)); }
	inline int32_t get_kCmdCmdRequestNewRoundStateAskAccept_188() const { return ___kCmdCmdRequestNewRoundStateAskAccept_188; }
	inline int32_t* get_address_of_kCmdCmdRequestNewRoundStateAskAccept_188() { return &___kCmdCmdRequestNewRoundStateAskAccept_188; }
	inline void set_kCmdCmdRequestNewRoundStateAskAccept_188(int32_t value)
	{
		___kCmdCmdRequestNewRoundStateAskAccept_188 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewRoundStateAskCancel_189() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewRoundStateAskCancel_189)); }
	inline int32_t get_kCmdCmdRequestNewRoundStateAskCancel_189() const { return ___kCmdCmdRequestNewRoundStateAskCancel_189; }
	inline int32_t* get_address_of_kCmdCmdRequestNewRoundStateAskCancel_189() { return &___kCmdCmdRequestNewRoundStateAskCancel_189; }
	inline void set_kCmdCmdRequestNewRoundStateAskCancel_189(int32_t value)
	{
		___kCmdCmdRequestNewRoundStateAskCancel_189 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190)); }
	inline int32_t get_kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190() const { return ___kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190; }
	inline int32_t* get_address_of_kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190() { return &___kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190; }
	inline void set_kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190(int32_t value)
	{
		___kCmdCmdNormalRoundFactoryChangeIsChangeSideBetweenRound_190 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191)); }
	inline int32_t get_kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191() const { return ___kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191; }
	inline int32_t* get_address_of_kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191() { return &___kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191; }
	inline void set_kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191(int32_t value)
	{
		___kCmdCmdNormalRoundFactoryChangeIsSwitchPlayer_191 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192)); }
	inline int32_t get_kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192() const { return ___kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192; }
	inline int32_t* get_address_of_kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192() { return &___kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192; }
	inline void set_kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192(int32_t value)
	{
		___kCmdCmdNormalRoundFactoryChangeIsDifferentInTeam_192 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193)); }
	inline int32_t get_kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193() const { return ___kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193; }
	inline int32_t* get_address_of_kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193() { return &___kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193; }
	inline void set_kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193(int32_t value)
	{
		___kCmdCmdNormalRoundFactoryChangeCalculateScoreType_193 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194)); }
	inline int32_t get_kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194() const { return ___kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194; }
	inline int32_t* get_address_of_kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194() { return &___kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194; }
	inline void set_kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194(int32_t value)
	{
		___kCmdCmdContestManagerStateLobbyChangeRandomTeamIndex_194 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195)); }
	inline int32_t get_kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195() const { return ___kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195; }
	inline int32_t* get_address_of_kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195() { return &___kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195; }
	inline void set_kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195(int32_t value)
	{
		___kCmdCmdContestManagerStateLobbyChangeContentFactoryType_195 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdContestManagerStateLobbyStateNormalStart_196() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdContestManagerStateLobbyStateNormalStart_196)); }
	inline int32_t get_kCmdCmdContestManagerStateLobbyStateNormalStart_196() const { return ___kCmdCmdContestManagerStateLobbyStateNormalStart_196; }
	inline int32_t* get_address_of_kCmdCmdContestManagerStateLobbyStateNormalStart_196() { return &___kCmdCmdContestManagerStateLobbyStateNormalStart_196; }
	inline void set_kCmdCmdContestManagerStateLobbyStateNormalStart_196(int32_t value)
	{
		___kCmdCmdContestManagerStateLobbyStateNormalStart_196 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLobbyPlayerSetReady_197() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLobbyPlayerSetReady_197)); }
	inline int32_t get_kCmdCmdLobbyPlayerSetReady_197() const { return ___kCmdCmdLobbyPlayerSetReady_197; }
	inline int32_t* get_address_of_kCmdCmdLobbyPlayerSetReady_197() { return &___kCmdCmdLobbyPlayerSetReady_197; }
	inline void set_kCmdCmdLobbyPlayerSetReady_197(int32_t value)
	{
		___kCmdCmdLobbyPlayerSetReady_197 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLobbyPlayerAdminChangeHuman_198() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLobbyPlayerAdminChangeHuman_198)); }
	inline int32_t get_kCmdCmdLobbyPlayerAdminChangeHuman_198() const { return ___kCmdCmdLobbyPlayerAdminChangeHuman_198; }
	inline int32_t* get_address_of_kCmdCmdLobbyPlayerAdminChangeHuman_198() { return &___kCmdCmdLobbyPlayerAdminChangeHuman_198; }
	inline void set_kCmdCmdLobbyPlayerAdminChangeHuman_198(int32_t value)
	{
		___kCmdCmdLobbyPlayerAdminChangeHuman_198 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLobbyPlayerAdminChangeEmpty_199() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLobbyPlayerAdminChangeEmpty_199)); }
	inline int32_t get_kCmdCmdLobbyPlayerAdminChangeEmpty_199() const { return ___kCmdCmdLobbyPlayerAdminChangeEmpty_199; }
	inline int32_t* get_address_of_kCmdCmdLobbyPlayerAdminChangeEmpty_199() { return &___kCmdCmdLobbyPlayerAdminChangeEmpty_199; }
	inline void set_kCmdCmdLobbyPlayerAdminChangeEmpty_199(int32_t value)
	{
		___kCmdCmdLobbyPlayerAdminChangeEmpty_199 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLobbyPlayerAdminChangeComputer_200() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLobbyPlayerAdminChangeComputer_200)); }
	inline int32_t get_kCmdCmdLobbyPlayerAdminChangeComputer_200() const { return ___kCmdCmdLobbyPlayerAdminChangeComputer_200; }
	inline int32_t* get_address_of_kCmdCmdLobbyPlayerAdminChangeComputer_200() { return &___kCmdCmdLobbyPlayerAdminChangeComputer_200; }
	inline void set_kCmdCmdLobbyPlayerAdminChangeComputer_200(int32_t value)
	{
		___kCmdCmdLobbyPlayerAdminChangeComputer_200 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLobbyPlayerNormalSet_201() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLobbyPlayerNormalSet_201)); }
	inline int32_t get_kCmdCmdLobbyPlayerNormalSet_201() const { return ___kCmdCmdLobbyPlayerNormalSet_201; }
	inline int32_t* get_address_of_kCmdCmdLobbyPlayerNormalSet_201() { return &___kCmdCmdLobbyPlayerNormalSet_201; }
	inline void set_kCmdCmdLobbyPlayerNormalSet_201(int32_t value)
	{
		___kCmdCmdLobbyPlayerNormalSet_201 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdLobbyPlayerIdentityNormalEmpty_202() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdLobbyPlayerIdentityNormalEmpty_202)); }
	inline int32_t get_kCmdCmdLobbyPlayerIdentityNormalEmpty_202() const { return ___kCmdCmdLobbyPlayerIdentityNormalEmpty_202; }
	inline int32_t* get_address_of_kCmdCmdLobbyPlayerIdentityNormalEmpty_202() { return &___kCmdCmdLobbyPlayerIdentityNormalEmpty_202; }
	inline void set_kCmdCmdLobbyPlayerIdentityNormalEmpty_202(int32_t value)
	{
		___kCmdCmdLobbyPlayerIdentityNormalEmpty_202 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdContestManagerStatePlayChangeIsForceEnd_203() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdContestManagerStatePlayChangeIsForceEnd_203)); }
	inline int32_t get_kCmdCmdContestManagerStatePlayChangeIsForceEnd_203() const { return ___kCmdCmdContestManagerStatePlayChangeIsForceEnd_203; }
	inline int32_t* get_address_of_kCmdCmdContestManagerStatePlayChangeIsForceEnd_203() { return &___kCmdCmdContestManagerStatePlayChangeIsForceEnd_203; }
	inline void set_kCmdCmdContestManagerStatePlayChangeIsForceEnd_203(int32_t value)
	{
		___kCmdCmdContestManagerStatePlayChangeIsForceEnd_203 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewContestManagerStateAskAccept_204() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewContestManagerStateAskAccept_204)); }
	inline int32_t get_kCmdCmdRequestNewContestManagerStateAskAccept_204() const { return ___kCmdCmdRequestNewContestManagerStateAskAccept_204; }
	inline int32_t* get_address_of_kCmdCmdRequestNewContestManagerStateAskAccept_204() { return &___kCmdCmdRequestNewContestManagerStateAskAccept_204; }
	inline void set_kCmdCmdRequestNewContestManagerStateAskAccept_204(int32_t value)
	{
		___kCmdCmdRequestNewContestManagerStateAskAccept_204 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewContestManagerStateAskCancel_205() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewContestManagerStateAskCancel_205)); }
	inline int32_t get_kCmdCmdRequestNewContestManagerStateAskCancel_205() const { return ___kCmdCmdRequestNewContestManagerStateAskCancel_205; }
	inline int32_t* get_address_of_kCmdCmdRequestNewContestManagerStateAskCancel_205() { return &___kCmdCmdRequestNewContestManagerStateAskCancel_205; }
	inline void set_kCmdCmdRequestNewContestManagerStateAskCancel_205(int32_t value)
	{
		___kCmdCmdRequestNewContestManagerStateAskCancel_205 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206)); }
	inline int32_t get_kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206() const { return ___kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206; }
	inline int32_t* get_address_of_kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206() { return &___kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206; }
	inline void set_kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206(int32_t value)
	{
		___kCmdCmdCalculateScoreWinLoseDrawChangeWinScore_206 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207)); }
	inline int32_t get_kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207() const { return ___kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207; }
	inline int32_t* get_address_of_kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207() { return &___kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207; }
	inline void set_kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207(int32_t value)
	{
		___kCmdCmdCalculateScoreWinLoseDrawChangeLoseScore_207 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208)); }
	inline int32_t get_kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208() const { return ___kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208; }
	inline int32_t* get_address_of_kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208() { return &___kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208; }
	inline void set_kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208(int32_t value)
	{
		___kCmdCmdCalculateScoreWinLoseDrawChangeDrawScore_208 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoundRobinFactoryChangeTeamCount_209() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoundRobinFactoryChangeTeamCount_209)); }
	inline int32_t get_kCmdCmdRoundRobinFactoryChangeTeamCount_209() const { return ___kCmdCmdRoundRobinFactoryChangeTeamCount_209; }
	inline int32_t* get_address_of_kCmdCmdRoundRobinFactoryChangeTeamCount_209() { return &___kCmdCmdRoundRobinFactoryChangeTeamCount_209; }
	inline void set_kCmdCmdRoundRobinFactoryChangeTeamCount_209(int32_t value)
	{
		___kCmdCmdRoundRobinFactoryChangeTeamCount_209 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210)); }
	inline int32_t get_kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210() const { return ___kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210; }
	inline int32_t* get_address_of_kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210() { return &___kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210; }
	inline void set_kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210(int32_t value)
	{
		___kCmdCmdRoundRobinFactoryChangeNeedReturnRound_210 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewRoundRobinStateAskAccept_211() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewRoundRobinStateAskAccept_211)); }
	inline int32_t get_kCmdCmdRequestNewRoundRobinStateAskAccept_211() const { return ___kCmdCmdRequestNewRoundRobinStateAskAccept_211; }
	inline int32_t* get_address_of_kCmdCmdRequestNewRoundRobinStateAskAccept_211() { return &___kCmdCmdRequestNewRoundRobinStateAskAccept_211; }
	inline void set_kCmdCmdRequestNewRoundRobinStateAskAccept_211(int32_t value)
	{
		___kCmdCmdRequestNewRoundRobinStateAskAccept_211 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewRoundRobinStateAskCancel_212() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewRoundRobinStateAskCancel_212)); }
	inline int32_t get_kCmdCmdRequestNewRoundRobinStateAskCancel_212() const { return ___kCmdCmdRequestNewRoundRobinStateAskCancel_212; }
	inline int32_t* get_address_of_kCmdCmdRequestNewRoundRobinStateAskCancel_212() { return &___kCmdCmdRequestNewRoundRobinStateAskCancel_212; }
	inline void set_kCmdCmdRequestNewRoundRobinStateAskCancel_212(int32_t value)
	{
		___kCmdCmdRequestNewRoundRobinStateAskCancel_212 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdEliminationFactoryChangeInitTeamCountLength_213() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdEliminationFactoryChangeInitTeamCountLength_213)); }
	inline int32_t get_kCmdCmdEliminationFactoryChangeInitTeamCountLength_213() const { return ___kCmdCmdEliminationFactoryChangeInitTeamCountLength_213; }
	inline int32_t* get_address_of_kCmdCmdEliminationFactoryChangeInitTeamCountLength_213() { return &___kCmdCmdEliminationFactoryChangeInitTeamCountLength_213; }
	inline void set_kCmdCmdEliminationFactoryChangeInitTeamCountLength_213(int32_t value)
	{
		___kCmdCmdEliminationFactoryChangeInitTeamCountLength_213 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdEliminationFactoryChangeInitTeamCount_214() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdEliminationFactoryChangeInitTeamCount_214)); }
	inline int32_t get_kCmdCmdEliminationFactoryChangeInitTeamCount_214() const { return ___kCmdCmdEliminationFactoryChangeInitTeamCount_214; }
	inline int32_t* get_address_of_kCmdCmdEliminationFactoryChangeInitTeamCount_214() { return &___kCmdCmdEliminationFactoryChangeInitTeamCount_214; }
	inline void set_kCmdCmdEliminationFactoryChangeInitTeamCount_214(int32_t value)
	{
		___kCmdCmdEliminationFactoryChangeInitTeamCount_214 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewEliminationRoundStateAskAccept_215() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewEliminationRoundStateAskAccept_215)); }
	inline int32_t get_kCmdCmdRequestNewEliminationRoundStateAskAccept_215() const { return ___kCmdCmdRequestNewEliminationRoundStateAskAccept_215; }
	inline int32_t* get_address_of_kCmdCmdRequestNewEliminationRoundStateAskAccept_215() { return &___kCmdCmdRequestNewEliminationRoundStateAskAccept_215; }
	inline void set_kCmdCmdRequestNewEliminationRoundStateAskAccept_215(int32_t value)
	{
		___kCmdCmdRequestNewEliminationRoundStateAskAccept_215 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestNewEliminationRoundStateAskCancel_216() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestNewEliminationRoundStateAskCancel_216)); }
	inline int32_t get_kCmdCmdRequestNewEliminationRoundStateAskCancel_216() const { return ___kCmdCmdRequestNewEliminationRoundStateAskCancel_216; }
	inline int32_t* get_address_of_kCmdCmdRequestNewEliminationRoundStateAskCancel_216() { return &___kCmdCmdRequestNewEliminationRoundStateAskCancel_216; }
	inline void set_kCmdCmdRequestNewEliminationRoundStateAskCancel_216(int32_t value)
	{
		___kCmdCmdRequestNewEliminationRoundStateAskCancel_216 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSwapIdentityChangeHuman_217() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSwapIdentityChangeHuman_217)); }
	inline int32_t get_kCmdCmdSwapIdentityChangeHuman_217() const { return ___kCmdCmdSwapIdentityChangeHuman_217; }
	inline int32_t* get_address_of_kCmdCmdSwapIdentityChangeHuman_217() { return &___kCmdCmdSwapIdentityChangeHuman_217; }
	inline void set_kCmdCmdSwapIdentityChangeHuman_217(int32_t value)
	{
		___kCmdCmdSwapIdentityChangeHuman_217 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSwapIdentityChangeComputer_218() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSwapIdentityChangeComputer_218)); }
	inline int32_t get_kCmdCmdSwapIdentityChangeComputer_218() const { return ___kCmdCmdSwapIdentityChangeComputer_218; }
	inline int32_t* get_address_of_kCmdCmdSwapIdentityChangeComputer_218() { return &___kCmdCmdSwapIdentityChangeComputer_218; }
	inline void set_kCmdCmdSwapIdentityChangeComputer_218(int32_t value)
	{
		___kCmdCmdSwapIdentityChangeComputer_218 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSwapRequestStateAskAccept_219() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSwapRequestStateAskAccept_219)); }
	inline int32_t get_kCmdCmdSwapRequestStateAskAccept_219() const { return ___kCmdCmdSwapRequestStateAskAccept_219; }
	inline int32_t* get_address_of_kCmdCmdSwapRequestStateAskAccept_219() { return &___kCmdCmdSwapRequestStateAskAccept_219; }
	inline void set_kCmdCmdSwapRequestStateAskAccept_219(int32_t value)
	{
		___kCmdCmdSwapRequestStateAskAccept_219 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdSwapRequestStateAskRefuse_220() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdSwapRequestStateAskRefuse_220)); }
	inline int32_t get_kCmdCmdSwapRequestStateAskRefuse_220() const { return ___kCmdCmdSwapRequestStateAskRefuse_220; }
	inline int32_t* get_address_of_kCmdCmdSwapRequestStateAskRefuse_220() { return &___kCmdCmdSwapRequestStateAskRefuse_220; }
	inline void set_kCmdCmdSwapRequestStateAskRefuse_220(int32_t value)
	{
		___kCmdCmdSwapRequestStateAskRefuse_220 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestChangeUseRuleStateNoneChange_221() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestChangeUseRuleStateNoneChange_221)); }
	inline int32_t get_kCmdCmdRequestChangeUseRuleStateNoneChange_221() const { return ___kCmdCmdRequestChangeUseRuleStateNoneChange_221; }
	inline int32_t* get_address_of_kCmdCmdRequestChangeUseRuleStateNoneChange_221() { return &___kCmdCmdRequestChangeUseRuleStateNoneChange_221; }
	inline void set_kCmdCmdRequestChangeUseRuleStateNoneChange_221(int32_t value)
	{
		___kCmdCmdRequestChangeUseRuleStateNoneChange_221 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestChangeUseRuleStateAskAccept_222() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestChangeUseRuleStateAskAccept_222)); }
	inline int32_t get_kCmdCmdRequestChangeUseRuleStateAskAccept_222() const { return ___kCmdCmdRequestChangeUseRuleStateAskAccept_222; }
	inline int32_t* get_address_of_kCmdCmdRequestChangeUseRuleStateAskAccept_222() { return &___kCmdCmdRequestChangeUseRuleStateAskAccept_222; }
	inline void set_kCmdCmdRequestChangeUseRuleStateAskAccept_222(int32_t value)
	{
		___kCmdCmdRequestChangeUseRuleStateAskAccept_222 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdRequestChangeUseRuleStateAskRefuse_223() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdRequestChangeUseRuleStateAskRefuse_223)); }
	inline int32_t get_kCmdCmdRequestChangeUseRuleStateAskRefuse_223() const { return ___kCmdCmdRequestChangeUseRuleStateAskRefuse_223; }
	inline int32_t* get_address_of_kCmdCmdRequestChangeUseRuleStateAskRefuse_223() { return &___kCmdCmdRequestChangeUseRuleStateAskRefuse_223; }
	inline void set_kCmdCmdRequestChangeUseRuleStateAskRefuse_223(int32_t value)
	{
		___kCmdCmdRequestChangeUseRuleStateAskRefuse_223 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224)); }
	inline int32_t get_kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224() const { return ___kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224; }
	inline int32_t* get_address_of_kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224() { return &___kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224; }
	inline void set_kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224(int32_t value)
	{
		___kCmdCmdChangeUseRuleRightChangeOnlyAdmin_224 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChangeUseRuleRightChangeNeedAdmin_225() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChangeUseRuleRightChangeNeedAdmin_225)); }
	inline int32_t get_kCmdCmdChangeUseRuleRightChangeNeedAdmin_225() const { return ___kCmdCmdChangeUseRuleRightChangeNeedAdmin_225; }
	inline int32_t* get_address_of_kCmdCmdChangeUseRuleRightChangeNeedAdmin_225() { return &___kCmdCmdChangeUseRuleRightChangeNeedAdmin_225; }
	inline void set_kCmdCmdChangeUseRuleRightChangeNeedAdmin_225(int32_t value)
	{
		___kCmdCmdChangeUseRuleRightChangeNeedAdmin_225 = value;
	}

	inline static int32_t get_offset_of_kCmdCmdChangeUseRuleRightChangeNeedAccept_226() { return static_cast<int32_t>(offsetof(ClientConnectIdentity_t1888924351_StaticFields, ___kCmdCmdChangeUseRuleRightChangeNeedAccept_226)); }
	inline int32_t get_kCmdCmdChangeUseRuleRightChangeNeedAccept_226() const { return ___kCmdCmdChangeUseRuleRightChangeNeedAccept_226; }
	inline int32_t* get_address_of_kCmdCmdChangeUseRuleRightChangeNeedAccept_226() { return &___kCmdCmdChangeUseRuleRightChangeNeedAccept_226; }
	inline void set_kCmdCmdChangeUseRuleRightChangeNeedAccept_226(int32_t value)
	{
		___kCmdCmdChangeUseRuleRightChangeNeedAccept_226 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
