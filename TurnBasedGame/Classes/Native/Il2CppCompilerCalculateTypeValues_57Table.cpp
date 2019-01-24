#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "AssemblyU2DCSharp_UndoRedo_Process183274441.h"
#include "AssemblyU2DCSharp_UndoRedo_Process_Property1808230495.h"
#include "AssemblyU2DCSharp_UndoRedo_ProcessUpdate3926037602.h"
#include "AssemblyU2DCSharp_UndoRedo_Resolved2083615786.h"
#include "AssemblyU2DCSharp_UndoRedo_Resolved_Property281474084.h"
#include "AssemblyU2DCSharp_UndoRedo_ResolvedUpdate1276059111.h"
#include "AssemblyU2DCSharp_UndoRedo_Start1473990218.h"
#include "AssemblyU2DCSharp_UndoRedo_Start_Property4077903380.h"
#include "AssemblyU2DCSharp_UndoRedo_StartUpdate700569459.h"
#include "AssemblyU2DCSharp_UndoRedoAction1759685716.h"
#include "AssemblyU2DCSharp_UndoRedoAction_State3431535314.h"
#include "AssemblyU2DCSharp_UndoRedoAction_State_Type902690219.h"
#include "AssemblyU2DCSharp_UndoRedoAction_Property1999593564.h"
#include "AssemblyU2DCSharp_UndoRedoActionIdentity1324976334.h"
#include "AssemblyU2DCSharp_UndoRedoActionUI240952390.h"
#include "AssemblyU2DCSharp_UndoRedoActionUI_UIData2410014227.h"
#include "AssemblyU2DCSharp_UndoRedoActionUI_UIData_Property3939883791.h"
#include "AssemblyU2DCSharp_UndoRedoActionUpdate3646419005.h"
#include "AssemblyU2DCSharp_ClientInput1093907013.h"
#include "AssemblyU2DCSharp_ClientInput_Sub2386272548.h"
#include "AssemblyU2DCSharp_ClientInput_Sub_Type2276582965.h"
#include "AssemblyU2DCSharp_ClientInput_Property1048088581.h"
#include "AssemblyU2DCSharp_ClientInputNone2494192063.h"
#include "AssemblyU2DCSharp_ClientInputNone_Property3616972427.h"
#include "AssemblyU2DCSharp_ClientInputNoneUI773335015.h"
#include "AssemblyU2DCSharp_ClientInputNoneUI_UIData901023716.h"
#include "AssemblyU2DCSharp_ClientInputNoneUI_UIData_Propert1962425484.h"
#include "AssemblyU2DCSharp_ClientInputSend3294112973.h"
#include "AssemblyU2DCSharp_ClientInputSend_State592895257.h"
#include "AssemblyU2DCSharp_ClientInputSend_Property3235860933.h"
#include "AssemblyU2DCSharp_ClientInputSendUI2019273637.h"
#include "AssemblyU2DCSharp_ClientInputSendUI_UIData2130425388.h"
#include "AssemblyU2DCSharp_ClientInputSendUI_UIData_Propert1860659072.h"
#include "AssemblyU2DCSharp_ClientInputSendUpdate1815609994.h"
#include "AssemblyU2DCSharp_ClientInputSendUpdate_U3CTaskWai2095418704.h"
#include "AssemblyU2DCSharp_ClientInputUI403850141.h"
#include "AssemblyU2DCSharp_ClientInputUI_UIData2832171482.h"
#include "AssemblyU2DCSharp_ClientInputUI_UIData_Sub1227094377.h"
#include "AssemblyU2DCSharp_ClientInputUI_UIData_Property3515767750.h"
#include "AssemblyU2DCSharp_ClientInputUpdate645562272.h"
#include "AssemblyU2DCSharp_WaitAIInputNone702155697.h"
#include "AssemblyU2DCSharp_WaitAIInputNone_Property2903209105.h"
#include "AssemblyU2DCSharp_WaitAIInputNoneUI3493126353.h"
#include "AssemblyU2DCSharp_WaitAIInputNoneUI_UIData2973877872.h"
#include "AssemblyU2DCSharp_WaitAIInputNoneUI_UIData_Property265192828.h"
#include "AssemblyU2DCSharp_WaitAIInputSearch846335217.h"
#include "AssemblyU2DCSharp_WaitAIInputSearch_State686077237.h"
#include "AssemblyU2DCSharp_WaitAIInputSearch_Property2386374521.h"
#include "AssemblyU2DCSharp_WaitAIInputSearchUI2248836777.h"
#include "AssemblyU2DCSharp_WaitAIInputSearchUI_UIData3901921326.h"
#include "AssemblyU2DCSharp_WaitAIInputSearchUI_UIData_Proper314296274.h"
#include "AssemblyU2DCSharp_WaitAIInputSearchUpdate3662023508.h"
#include "AssemblyU2DCSharp_WaitAIInputSearchUpdate_Work3291824404.h"
#include "AssemblyU2DCSharp_WaitAIInputSearchUpdate_U3CTaskF4242812829.h"
#include "AssemblyU2DCSharp_WaitAIInput471222699.h"
#include "AssemblyU2DCSharp_WaitAIInput_Sub998292136.h"
#include "AssemblyU2DCSharp_WaitAIInput_Sub_Type1031025443.h"
#include "AssemblyU2DCSharp_WaitAIInput_Property469199255.h"
#include "AssemblyU2DCSharp_WaitAIInputIdentity1151487549.h"
#include "AssemblyU2DCSharp_WaitAIInputUI1572023195.h"
#include "AssemblyU2DCSharp_WaitAIInputUI_UIData3790952954.h"
#include "AssemblyU2DCSharp_WaitAIInputUI_UIData_Sub824547211.h"
#include "AssemblyU2DCSharp_WaitAIInputUI_UIData_Property3907315266.h"
#include "AssemblyU2DCSharp_WaitAIInputUpdate30597872.h"
#include "AssemblyU2DCSharp_WaitHumanInput3668463842.h"
#include "AssemblyU2DCSharp_WaitHumanInput_Property3041586074.h"
#include "AssemblyU2DCSharp_WaitHumanInputIdentity711505776.h"
#include "AssemblyU2DCSharp_WaitHumanInputUI4263887976.h"
#include "AssemblyU2DCSharp_WaitHumanInputUI_UIData1360037275.h"
#include "AssemblyU2DCSharp_WaitHumanInputUI_UIData_Property3109205519.h"
#include "AssemblyU2DCSharp_WaitInputActionClientUpdate500789845.h"
#include "AssemblyU2DCSharp_WaitInputActionProcessInputUpdat1312608657.h"
#include "AssemblyU2DCSharp_WaitInputClientTimeUpdate2175278396.h"
#include "AssemblyU2DCSharp_WaitInputClientTimeUpdate_U3Cupd3630018419.h"
#include "AssemblyU2DCSharp_WaitInputMakeSubUpdate4001784596.h"
#include "AssemblyU2DCSharp_WaitInputServerTimeUpdate2279686776.h"
#include "AssemblyU2DCSharp_WaitInputServerTimeUpdate_U3Cupda943104627.h"
#include "AssemblyU2DCSharp_WaitInputAction1882979057.h"
#include "AssemblyU2DCSharp_WaitInputAction_Sub2792249764.h"
#include "AssemblyU2DCSharp_WaitInputAction_Sub_Type426605385.h"
#include "AssemblyU2DCSharp_WaitInputAction_Property2392346841.h"
#include "AssemblyU2DCSharp_WaitInputActionIdentity30036355.h"
#include "AssemblyU2DCSharp_WaitInputActionUI2098345273.h"
#include "AssemblyU2DCSharp_WaitInputActionUI_UIData1551346322.h"
#include "AssemblyU2DCSharp_WaitInputActionUI_UIData_Sub453374157.h"
#include "AssemblyU2DCSharp_WaitInputActionUI_UIData_Propert3180781790.h"
#include "AssemblyU2DCSharp_WaitInputActionUpdate2096549556.h"
#include "AssemblyU2DCSharp_GameData450274222.h"
#include "AssemblyU2DCSharp_GameData_State1609625640.h"
#include "AssemblyU2DCSharp_GameData_State_Type1593292199.h"
#include "AssemblyU2DCSharp_GameData_Property721752430.h"
#include "AssemblyU2DCSharp_GameDataIdentity1431647172.h"
#include "AssemblyU2DCSharp_AnimationManager2328214095.h"
#include "AssemblyU2DCSharp_AnimationManager_State2233942103.h"
#include "AssemblyU2DCSharp_AnimationManager_Property3119653963.h"
#include "AssemblyU2DCSharp_AnimationManagerUpdate3472656784.h"







#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5700 = { sizeof (Process_t183274441), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5700[1] = 
{
	Process_t183274441::get_offset_of_index_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5701 = { sizeof (Property_t1808230495)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5701[2] = 
{
	Property_t1808230495::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5702 = { sizeof (ProcessUpdate_t3926037602), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5702[1] = 
{
	ProcessUpdate_t3926037602::get_offset_of_game_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5703 = { sizeof (Resolved_t2083615786), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5704 = { sizeof (Property_t281474084)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5704[1] = 
{
	Property_t281474084::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5705 = { sizeof (ResolvedUpdate_t1276059111), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5706 = { sizeof (Start_t1473990218), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5707 = { sizeof (Property_t4077903380)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5707[1] = 
{
	Property_t4077903380::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5708 = { sizeof (StartUpdate_t700569459), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5709 = { sizeof (UndoRedoAction_t1759685716), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5709[2] = 
{
	UndoRedoAction_t1759685716::get_offset_of_state_5(),
	UndoRedoAction_t1759685716::get_offset_of_requestInform_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5710 = { sizeof (State_t3431535314), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5711 = { sizeof (Type_t902690219)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5711[4] = 
{
	Type_t902690219::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5712 = { sizeof (Property_t1999593564)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5712[3] = 
{
	Property_t1999593564::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5713 = { sizeof (UndoRedoActionIdentity_t1324976334), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5713[1] = 
{
	UndoRedoActionIdentity_t1324976334::get_offset_of_netData_17(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5714 = { sizeof (UndoRedoActionUI_t240952390), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5715 = { sizeof (UIData_t2410014227), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5715[1] = 
{
	UIData_t2410014227::get_offset_of_undoRedoAction_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5716 = { sizeof (Property_t3939883791)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5716[2] = 
{
	Property_t3939883791::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5717 = { sizeof (UndoRedoActionUpdate_t3646419005), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5718 = { sizeof (ClientInput_t1093907013), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5718[1] = 
{
	ClientInput_t1093907013::get_offset_of_sub_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5719 = { sizeof (Sub_t2386272548), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5720 = { sizeof (Type_t2276582965)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5720[3] = 
{
	Type_t2276582965::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5721 = { sizeof (Property_t1048088581)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5721[2] = 
{
	Property_t1048088581::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5722 = { sizeof (ClientInputNone_t2494192063), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5723 = { sizeof (Property_t3616972427)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5723[1] = 
{
	Property_t3616972427::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5724 = { sizeof (ClientInputNoneUI_t773335015), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5725 = { sizeof (UIData_t901023716), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5725[1] = 
{
	UIData_t901023716::get_offset_of_clientInputNone_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5726 = { sizeof (Property_t1962425484)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5726[2] = 
{
	Property_t1962425484::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5727 = { sizeof (ClientInputSend_t3294112973), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5727[3] = 
{
	ClientInputSend_t3294112973::get_offset_of_state_5(),
	ClientInputSend_t3294112973::get_offset_of_gameMove_6(),
	ClientInputSend_t3294112973::get_offset_of_clientTimeSend_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5728 = { sizeof (State_t592895257)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5728[3] = 
{
	State_t592895257::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5729 = { sizeof (Property_t3235860933)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5729[4] = 
{
	Property_t3235860933::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5730 = { sizeof (ClientInputSendUI_t2019273637), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5731 = { sizeof (UIData_t2130425388), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5731[1] = 
{
	UIData_t2130425388::get_offset_of_clientInputSend_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5732 = { sizeof (Property_t1860659072)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5732[2] = 
{
	Property_t1860659072::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5733 = { sizeof (ClientInputSendUpdate_t1815609994), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5733[4] = 
{
	ClientInputSendUpdate_t1815609994::get_offset_of_waitToResend_4(),
	ClientInputSendUpdate_t1815609994::get_offset_of_server_5(),
	ClientInputSendUpdate_t1815609994::get_offset_of_haveChange_6(),
	ClientInputSendUpdate_t1815609994::get_offset_of_waitInputAction_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5734 = { sizeof (U3CTaskWaitToResendU3Ec__Iterator0_t2095418704), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5734[4] = 
{
	U3CTaskWaitToResendU3Ec__Iterator0_t2095418704::get_offset_of_U24this_0(),
	U3CTaskWaitToResendU3Ec__Iterator0_t2095418704::get_offset_of_U24current_1(),
	U3CTaskWaitToResendU3Ec__Iterator0_t2095418704::get_offset_of_U24disposing_2(),
	U3CTaskWaitToResendU3Ec__Iterator0_t2095418704::get_offset_of_U24PC_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5735 = { sizeof (ClientInputUI_t403850141), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5735[3] = 
{
	ClientInputUI_t403850141::get_offset_of_subContainer_6(),
	ClientInputUI_t403850141::get_offset_of_nonePrefab_7(),
	ClientInputUI_t403850141::get_offset_of_sendPrefab_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5736 = { sizeof (UIData_t2832171482), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5736[2] = 
{
	UIData_t2832171482::get_offset_of_clientInput_5(),
	UIData_t2832171482::get_offset_of_sub_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5737 = { sizeof (Sub_t1227094377), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5738 = { sizeof (Property_t3515767750)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5738[3] = 
{
	Property_t3515767750::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5739 = { sizeof (ClientInputUpdate_t645562272), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5740 = { sizeof (WaitAIInputNone_t702155697), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5741 = { sizeof (Property_t2903209105)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5741[1] = 
{
	Property_t2903209105::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5742 = { sizeof (WaitAIInputNoneUI_t3493126353), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5743 = { sizeof (UIData_t2973877872), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5743[1] = 
{
	UIData_t2973877872::get_offset_of_waitAIInputNone_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5744 = { sizeof (Property_t265192828)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5744[2] = 
{
	Property_t265192828::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5745 = { sizeof (WaitAIInputSearch_t846335217), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5745[1] = 
{
	WaitAIInputSearch_t846335217::get_offset_of_state_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5746 = { sizeof (State_t686077237)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5746[3] = 
{
	State_t686077237::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5747 = { sizeof (Property_t2386374521)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5747[2] = 
{
	Property_t2386374521::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5748 = { sizeof (WaitAIInputSearchUI_t2248836777), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5749 = { sizeof (UIData_t3901921326), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5749[1] = 
{
	UIData_t3901921326::get_offset_of_waitAIInputSearch_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5750 = { sizeof (Property_t314296274)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5750[2] = 
{
	Property_t314296274::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5751 = { sizeof (WaitAIInputSearchUpdate_t3662023508), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5751[4] = 
{
	WaitAIInputSearchUpdate_t3662023508::get_offset_of_findAIRoutine_4(),
	WaitAIInputSearchUpdate_t3662023508::get_offset_of_haveChange_5(),
	WaitAIInputSearchUpdate_t3662023508::get_offset_of_waitAIInput_6(),
	WaitAIInputSearchUpdate_t3662023508::get_offset_of_game_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5752 = { sizeof (Work_t3291824404), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5752[3] = 
{
	Work_t3291824404::get_offset_of_data_0(),
	Work_t3291824404::get_offset_of_aiMove_1(),
	Work_t3291824404::get_offset_of_isDone_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5753 = { sizeof (U3CTaskFindAIMoveU3Ec__Iterator0_t4242812829), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5753[5] = 
{
	U3CTaskFindAIMoveU3Ec__Iterator0_t4242812829::get_offset_of_U3CwU3E__0_0(),
	U3CTaskFindAIMoveU3Ec__Iterator0_t4242812829::get_offset_of_U24this_1(),
	U3CTaskFindAIMoveU3Ec__Iterator0_t4242812829::get_offset_of_U24current_2(),
	U3CTaskFindAIMoveU3Ec__Iterator0_t4242812829::get_offset_of_U24disposing_3(),
	U3CTaskFindAIMoveU3Ec__Iterator0_t4242812829::get_offset_of_U24PC_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5754 = { sizeof (WaitAIInput_t471222699), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5754[3] = 
{
	WaitAIInput_t471222699::get_offset_of_userThink_5(),
	WaitAIInput_t471222699::get_offset_of_rethink_6(),
	WaitAIInput_t471222699::get_offset_of_sub_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5755 = { sizeof (Sub_t998292136), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5756 = { sizeof (Type_t1031025443)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5756[3] = 
{
	Type_t1031025443::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5757 = { sizeof (Property_t469199255)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5757[4] = 
{
	Property_t469199255::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5758 = { sizeof (WaitAIInputIdentity_t1151487549), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5758[3] = 
{
	WaitAIInputIdentity_t1151487549::get_offset_of_userThink_17(),
	WaitAIInputIdentity_t1151487549::get_offset_of_rethink_18(),
	WaitAIInputIdentity_t1151487549::get_offset_of_netData_19(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5759 = { sizeof (WaitAIInputUI_t1572023195), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5759[4] = 
{
	WaitAIInputUI_t1572023195::get_offset_of_tvUserThink_6(),
	WaitAIInputUI_t1572023195::get_offset_of_subContainer_7(),
	WaitAIInputUI_t1572023195::get_offset_of_nonePrefab_8(),
	WaitAIInputUI_t1572023195::get_offset_of_searchPrefab_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5760 = { sizeof (UIData_t3790952954), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5760[2] = 
{
	UIData_t3790952954::get_offset_of_waitAIInput_5(),
	UIData_t3790952954::get_offset_of_sub_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5761 = { sizeof (Sub_t824547211), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5762 = { sizeof (Property_t3907315266)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5762[3] = 
{
	Property_t3907315266::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5763 = { sizeof (WaitAIInputUpdate_t30597872), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5763[1] = 
{
	WaitAIInputUpdate_t30597872::get_offset_of_waitInputAction_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5764 = { sizeof (WaitHumanInput_t3668463842), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5764[1] = 
{
	WaitHumanInput_t3668463842::get_offset_of_userId_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5765 = { sizeof (Property_t3041586074)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5765[2] = 
{
	Property_t3041586074::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5766 = { sizeof (WaitHumanInputIdentity_t711505776), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5766[2] = 
{
	WaitHumanInputIdentity_t711505776::get_offset_of_userId_17(),
	WaitHumanInputIdentity_t711505776::get_offset_of_netData_18(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5767 = { sizeof (WaitHumanInputUI_t4263887976), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5767[1] = 
{
	WaitHumanInputUI_t4263887976::get_offset_of_tvHuman_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5768 = { sizeof (UIData_t1360037275), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5768[1] = 
{
	UIData_t1360037275::get_offset_of_waitHumanInput_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5769 = { sizeof (Property_t3109205519)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5769[2] = 
{
	Property_t3109205519::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5770 = { sizeof (WaitInputActionClientUpdate_t500789845), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5771 = { sizeof (WaitInputActionProcessInputUpdate_t1312608657), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5771[2] = 
{
	WaitInputActionProcessInputUpdate_t1312608657::get_offset_of_gameIsPlayingChange_4(),
	WaitInputActionProcessInputUpdate_t1312608657::get_offset_of_game_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5772 = { sizeof (WaitInputClientTimeUpdate_t2175278396), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5772[1] = 
{
	WaitInputClientTimeUpdate_t2175278396::get_offset_of_clientTimeRoutine_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5773 = { sizeof (U3CupdateClientTimeU3Ec__Iterator0_t3630018419), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5773[4] = 
{
	U3CupdateClientTimeU3Ec__Iterator0_t3630018419::get_offset_of_U24this_0(),
	U3CupdateClientTimeU3Ec__Iterator0_t3630018419::get_offset_of_U24current_1(),
	U3CupdateClientTimeU3Ec__Iterator0_t3630018419::get_offset_of_U24disposing_2(),
	U3CupdateClientTimeU3Ec__Iterator0_t3630018419::get_offset_of_U24PC_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5774 = { sizeof (WaitInputMakeSubUpdate_t4001784596), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5774[3] = 
{
	WaitInputMakeSubUpdate_t4001784596::get_offset_of_gameCheckPlayerChange_4(),
	WaitInputMakeSubUpdate_t4001784596::get_offset_of_roomCheckAdminChange_5(),
	WaitInputMakeSubUpdate_t4001784596::get_offset_of_game_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5775 = { sizeof (WaitInputServerTimeUpdate_t2279686776), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5775[1] = 
{
	WaitInputServerTimeUpdate_t2279686776::get_offset_of_serverTimeRoutine_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5776 = { sizeof (U3CupdateServerTimeU3Ec__Iterator0_t943104627), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5776[4] = 
{
	U3CupdateServerTimeU3Ec__Iterator0_t943104627::get_offset_of_U24this_0(),
	U3CupdateServerTimeU3Ec__Iterator0_t943104627::get_offset_of_U24current_1(),
	U3CupdateServerTimeU3Ec__Iterator0_t943104627::get_offset_of_U24disposing_2(),
	U3CupdateServerTimeU3Ec__Iterator0_t943104627::get_offset_of_U24PC_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5777 = { sizeof (WaitInputAction_t1882979057), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5777[5] = 
{
	WaitInputAction_t1882979057::get_offset_of_serverTime_5(),
	WaitInputAction_t1882979057::get_offset_of_clientTime_6(),
	WaitInputAction_t1882979057::get_offset_of_sub_7(),
	WaitInputAction_t1882979057::get_offset_of_inputs_8(),
	WaitInputAction_t1882979057::get_offset_of_clientInput_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5778 = { sizeof (Sub_t2792249764), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5779 = { sizeof (Type_t426605385)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5779[3] = 
{
	Type_t426605385::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5780 = { sizeof (Property_t2392346841)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5780[6] = 
{
	Property_t2392346841::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5781 = { sizeof (WaitInputActionIdentity_t30036355), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5781[2] = 
{
	WaitInputActionIdentity_t30036355::get_offset_of_serverTime_17(),
	WaitInputActionIdentity_t30036355::get_offset_of_netData_18(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5782 = { sizeof (WaitInputActionUI_t2098345273), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5782[8] = 
{
	WaitInputActionUI_t2098345273::get_offset_of_tvServerTime_6(),
	WaitInputActionUI_t2098345273::get_offset_of_tvClientTime_7(),
	WaitInputActionUI_t2098345273::get_offset_of_tvCheckLegalMove_8(),
	WaitInputActionUI_t2098345273::get_offset_of_subContainer_9(),
	WaitInputActionUI_t2098345273::get_offset_of_waitHumanInputUIPrefab_10(),
	WaitInputActionUI_t2098345273::get_offset_of_waitAIInputUIPrefab_11(),
	WaitInputActionUI_t2098345273::get_offset_of_clientInputUIContainer_12(),
	WaitInputActionUI_t2098345273::get_offset_of_clientInputUIPrefab_13(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5783 = { sizeof (UIData_t1551346322), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5783[3] = 
{
	UIData_t1551346322::get_offset_of_waitInputAction_5(),
	UIData_t1551346322::get_offset_of_sub_6(),
	UIData_t1551346322::get_offset_of_clientInputUIData_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5784 = { sizeof (Sub_t453374157), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5785 = { sizeof (Property_t3180781790)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5785[4] = 
{
	Property_t3180781790::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5786 = { sizeof (WaitInputActionUpdate_t2096549556), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5787 = { 0, 0, 0, 0 };
extern const int32_t g_FieldOffsetTable5787[3] = 
{
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5788 = { 0, 0, 0, 0 };
extern const int32_t g_FieldOffsetTable5788[2] = 
{
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5789 = { sizeof (GameData_t450274222), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5789[7] = 
{
	GameData_t450274222::get_offset_of_gameType_5(),
	GameData_t450274222::get_offset_of_useRule_6(),
	GameData_t450274222::get_offset_of_requestChangeUseRule_7(),
	GameData_t450274222::get_offset_of_turn_8(),
	GameData_t450274222::get_offset_of_timeControl_9(),
	GameData_t450274222::get_offset_of_lastMove_10(),
	GameData_t450274222::get_offset_of_state_11(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5790 = { sizeof (State_t1609625640), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5791 = { sizeof (Type_t1593292199)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5791[3] = 
{
	Type_t1593292199::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5792 = { sizeof (Property_t721752430)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5792[8] = 
{
	Property_t721752430::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5793 = { sizeof (GameDataIdentity_t1431647172), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5793[2] = 
{
	GameDataIdentity_t1431647172::get_offset_of_useRule_17(),
	GameDataIdentity_t1431647172::get_offset_of_netData_18(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5794 = { sizeof (AnimationManager_t2328214095), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5794[5] = 
{
	0,
	AnimationManager_t2328214095::get_offset_of_waitToAddMoveAnimations_6(),
	AnimationManager_t2328214095::get_offset_of_animationProgresses_7(),
	AnimationManager_t2328214095::get_offset_of_lastMove_8(),
	AnimationManager_t2328214095::get_offset_of_state_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5795 = { sizeof (State_t2233942103)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5795[4] = 
{
	State_t2233942103::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5796 = { sizeof (Property_t3119653963)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable5796[4] = 
{
	Property_t3119653963::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5797 = { 0, 0, 0, 0 };
extern const int32_t g_FieldOffsetTable5797[4] = 
{
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5798 = { 0, 0, 0, 0 };
extern const int32_t g_FieldOffsetTable5798[2] = 
{
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize5799 = { sizeof (AnimationManagerUpdate_t3472656784), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable5799[5] = 
{
	AnimationManagerUpdate_t3472656784::get_offset_of_delayTime_4(),
	0,
	AnimationManagerUpdate_t3472656784::get_offset_of_gameDataBoardUIData_6(),
	AnimationManagerUpdate_t3472656784::get_offset_of_game_7(),
	AnimationManagerUpdate_t3472656784::get_offset_of_viewRecordUIData_8(),
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
