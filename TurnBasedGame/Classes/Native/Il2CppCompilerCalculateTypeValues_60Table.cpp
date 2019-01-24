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
#include "AssemblyU2DCSharp_FairyChess_Common1575605761.h"
#include "AssemblyU2DCSharp_FairyChess_Common_ColorAndPiece1015650909.h"
#include "AssemblyU2DCSharp_FairyChess_Common_VariantType3570894812.h"
#include "AssemblyU2DCSharp_FairyChess_Common_PieceType2850651519.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Piece501795431.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Square1888632224.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Value112071580.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Color1267941922.h"
#include "AssemblyU2DCSharp_FairyChess_Common_CastlingRight3756942710.h"
#include "AssemblyU2DCSharp_FairyChess_Common_File3472531759.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Rank1469664291.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Score3365193833.h"
#include "AssemblyU2DCSharp_FairyChess_Common_MoveType30930086.h"
#include "AssemblyU2DCSharp_FairyChess_Common_Move4238694782.h"
#include "AssemblyU2DCSharp_FairyChess_Core1592578867.h"
#include "AssemblyU2DCSharp_FairyChess_DefaultFairyChess2130932174.h"
#include "AssemblyU2DCSharp_FairyChess_DefaultFairyChess_Pro2083279319.h"
#include "AssemblyU2DCSharp_FairyChess_DefaultFairyChessIden4199589352.h"
#include "AssemblyU2DCSharp_FairyChess_DefaultFairyChessUI4103913230.h"
#include "AssemblyU2DCSharp_FairyChess_DefaultFairyChessUI_U3891274668.h"
#include "AssemblyU2DCSharp_FairyChess_DefaultFairyChessUI_U3483611364.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChess3892797331.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChess_Property3262549728.h"
#include "AssemblyU2DCSharp_FairyChess_Chess9602719772865.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessIdentity1607898065.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMoveAnimation69044422.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMoveAnimati1568137095.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMoveAnimati3257862896.h"
#include "AssemblyU2DCSharp_FairyChess_AnimationSetDirtyUpda1223205005.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMove3420079360.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMove_Move1133248107.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMove_Proper1864985517.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMoveIdentit1929764730.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMoveUI2553501072.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMoveUI_UIDa2469374350.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessMoveUI_UIDat979204786.h"
#include "AssemblyU2DCSharp_FairyChess_StateInfo3161066623.h"
#include "AssemblyU2DCSharp_FairyChess_StateInfo_Property2758205408.h"
#include "AssemblyU2DCSharp_FairyChess_StateInfoIdentity3667173629.h"
#include "AssemblyU2DCSharp_FairyChess_TestFairyChess2391463083.h"
#include "AssemblyU2DCSharp_FairyChess_TestFairyChess_Work3158957512.h"
#include "AssemblyU2DCSharp_FairyChess_BoardUI2451992604.h"
#include "AssemblyU2DCSharp_FairyChess_BoardUI_UIData2805356858.h"
#include "AssemblyU2DCSharp_FairyChess_BoardUI_UIData_Proper2266697718.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessFenUI2389940904.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessFenUI_UIDat2879865490.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessFenUI_UIDat1691085438.h"
#include "AssemblyU2DCSharp_FairyChess_HandPieceUI904353653.h"
#include "AssemblyU2DCSharp_FairyChess_HandPieceUI_UIData743039105.h"
#include "AssemblyU2DCSharp_FairyChess_HandPieceUI_UIData_Pr1450346649.h"
#include "AssemblyU2DCSharp_FairyChess_SpriteContainer1587746296.h"
#include "AssemblyU2DCSharp_FairyChess_PieceUI3028444168.h"
#include "AssemblyU2DCSharp_FairyChess_PieceUI_UIData2287802308.h"
#include "AssemblyU2DCSharp_FairyChess_PieceUI_UIData_Proper1672666520.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessGameDataUI1215648031.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessGameDataUI_3976046997.h"
#include "AssemblyU2DCSharp_FairyChess_FairyChessGameDataUI_3430878405.h"
#include "AssemblyU2DCSharp_FairyChess_InputUI2893746872.h"
#include "AssemblyU2DCSharp_FairyChess_InputUI_UIData1474262306.h"
#include "AssemblyU2DCSharp_FairyChess_InputUI_UIData_Sub2386736321.h"
#include "AssemblyU2DCSharp_FairyChess_InputUI_UIData_Sub_Typ744141436.h"
#include "AssemblyU2DCSharp_FairyChess_InputUI_UIData_Propert182366462.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickMoveUI1312361047.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickMoveUI_4257096937.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickMoveUI_2275703689.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu1339138931.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu3035747054.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu3668310309.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu3002134561.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu2716078571.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu1142469455.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickNoneUI21695562.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickNoneUI_1390728048.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickNoneUI_3796120748.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickPosUI1482736564.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickPosUI_UI531432842.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ClickPosUI_UI545572962.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRuleInputUI4261330204.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRuleInputUI_UIDat1139753962.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRuleInputUI_UIData_20091405.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRuleInputUI_UIData_37971860.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRuleInputUI_UIDat1266111622.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandAdapt3379902588.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandAdapt2889539922.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandAdapte462586522.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandHolde2816521467.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandHolde3522919935.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandHolde2374726187.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu1103868243.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu2233486674.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCus487438273.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu1973079333.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu3976694933.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_FairyChessCu2778082957.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandUI1499879215.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandUI_UI1254411083.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_SetHandUI_UI1655062751.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ChoosePieceA2445772018.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ChoosePieceA4225497702.h"
#include "AssemblyU2DCSharp_FairyChess_NoneRule_ChoosePieceA3951887338.h"







#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6000 = { sizeof (Common_t1575605761), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6000[11] = 
{
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6001 = { sizeof (ColorAndPiece_t1015650909), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6001[2] = 
{
	ColorAndPiece_t1015650909::get_offset_of_color_0(),
	ColorAndPiece_t1015650909::get_offset_of_pieceType_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6002 = { sizeof (VariantType_t3570894812)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6002[29] = 
{
	VariantType_t3570894812::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6003 = { sizeof (PieceType_t2850651519)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6003[29] = 
{
	PieceType_t2850651519::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6004 = { sizeof (Piece_t501795431)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6004[3] = 
{
	Piece_t501795431::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6005 = { sizeof (Square_t1888632224)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6005[67] = 
{
	Square_t1888632224::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6006 = { sizeof (Value_t112071580)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6006[53] = 
{
	Value_t112071580::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6007 = { sizeof (Color_t1267941922)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6007[4] = 
{
	Color_t1267941922::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6008 = { sizeof (CastlingRight_t3756942710)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6008[8] = 
{
	CastlingRight_t3756942710::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6009 = { sizeof (File_t3472531759)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6009[10] = 
{
	File_t3472531759::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6010 = { sizeof (Rank_t1469664291)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6010[10] = 
{
	Rank_t1469664291::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6011 = { sizeof (Score_t3365193833)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6011[2] = 
{
	Score_t3365193833::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6012 = { sizeof (MoveType_t30930086)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6012[10] = 
{
	MoveType_t30930086::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6013 = { sizeof (Move_t4238694782)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6013[3] = 
{
	Move_t4238694782::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6014 = { sizeof (Core_t1592578867), -1, sizeof(Core_t1592578867_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable6014[3] = 
{
	0,
	Core_t1592578867_StaticFields::get_offset_of_isAlreadyInit_1(),
	Core_t1592578867_StaticFields::get_offset_of_lockFairyChessInit_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6015 = { sizeof (DefaultFairyChess_t2130932174), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6015[2] = 
{
	DefaultFairyChess_t2130932174::get_offset_of_variantType_5(),
	DefaultFairyChess_t2130932174::get_offset_of_chess960_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6016 = { sizeof (Property_t2083279319)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6016[3] = 
{
	Property_t2083279319::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6017 = { sizeof (DefaultFairyChessIdentity_t4199589352), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6017[3] = 
{
	DefaultFairyChessIdentity_t4199589352::get_offset_of_variantType_17(),
	DefaultFairyChessIdentity_t4199589352::get_offset_of_chess960_18(),
	DefaultFairyChessIdentity_t4199589352::get_offset_of_netData_19(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6018 = { sizeof (DefaultFairyChessUI_t4103913230), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6018[10] = 
{
	DefaultFairyChessUI_t4103913230::get_offset_of_needReset_6(),
	DefaultFairyChessUI_t4103913230::get_offset_of_miniGameDataDirty_7(),
	DefaultFairyChessUI_t4103913230::get_offset_of_differentIndicator_8(),
	DefaultFairyChessUI_t4103913230::get_offset_of_miniGameDataUIPrefab_9(),
	DefaultFairyChessUI_t4103913230::get_offset_of_miniGameDataUIContainer_10(),
	DefaultFairyChessUI_t4103913230::get_offset_of_requestEnumPrefab_11(),
	DefaultFairyChessUI_t4103913230::get_offset_of_variantTypeContainer_12(),
	DefaultFairyChessUI_t4103913230::get_offset_of_requestBoolPrefab_13(),
	DefaultFairyChessUI_t4103913230::get_offset_of_chess960Container_14(),
	DefaultFairyChessUI_t4103913230::get_offset_of_server_15(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6019 = { sizeof (UIData_t3891274668), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6019[4] = 
{
	UIData_t3891274668::get_offset_of_editDefaultFairyChess_5(),
	UIData_t3891274668::get_offset_of_variantType_6(),
	UIData_t3891274668::get_offset_of_chess960_7(),
	UIData_t3891274668::get_offset_of_miniGameDataUIData_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6020 = { sizeof (Property_t3483611364)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6020[5] = 
{
	Property_t3483611364::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6021 = { sizeof (FairyChess_t3892797331), -1, sizeof(FairyChess_t3892797331_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable6021[19] = 
{
	FairyChess_t3892797331::get_offset_of_board_9(),
	FairyChess_t3892797331::get_offset_of_unpromotedBoard_10(),
	FairyChess_t3892797331::get_offset_of_byTypeBB_11(),
	FairyChess_t3892797331::get_offset_of_byColorBB_12(),
	FairyChess_t3892797331::get_offset_of_pieceCount_13(),
	FairyChess_t3892797331::get_offset_of_pieceList_14(),
	FairyChess_t3892797331::get_offset_of_index_15(),
	FairyChess_t3892797331::get_offset_of_castlingRightsMask_16(),
	FairyChess_t3892797331::get_offset_of_castlingRookSquare_17(),
	FairyChess_t3892797331::get_offset_of_castlingPath_18(),
	FairyChess_t3892797331::get_offset_of_gamePly_19(),
	FairyChess_t3892797331::get_offset_of_sideToMove_20(),
	FairyChess_t3892797331::get_offset_of_variantType_21(),
	FairyChess_t3892797331::get_offset_of_st_22(),
	FairyChess_t3892797331::get_offset_of_chess960_23(),
	FairyChess_t3892797331::get_offset_of_pieceCountInHand_24(),
	FairyChess_t3892797331::get_offset_of_promotedPieces_25(),
	FairyChess_t3892797331::get_offset_of_isCustom_26(),
	FairyChess_t3892797331_StaticFields::get_offset_of_AllowNames_27(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6022 = { sizeof (Property_t3262549728)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6022[19] = 
{
	Property_t3262549728::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6023 = { sizeof (Chess960_t2719772865), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6024 = { sizeof (FairyChessIdentity_t1607898065), -1, sizeof(FairyChessIdentity_t1607898065_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable6024[29] = 
{
	FairyChessIdentity_t1607898065::get_offset_of_board_17(),
	FairyChessIdentity_t1607898065::get_offset_of_unpromotedBoard_18(),
	FairyChessIdentity_t1607898065::get_offset_of_byTypeBB_19(),
	FairyChessIdentity_t1607898065::get_offset_of_byColorBB_20(),
	FairyChessIdentity_t1607898065::get_offset_of_pieceCount_21(),
	FairyChessIdentity_t1607898065::get_offset_of_pieceList_22(),
	FairyChessIdentity_t1607898065::get_offset_of_index_23(),
	FairyChessIdentity_t1607898065::get_offset_of_castlingRightsMask_24(),
	FairyChessIdentity_t1607898065::get_offset_of_castlingRookSquare_25(),
	FairyChessIdentity_t1607898065::get_offset_of_castlingPath_26(),
	FairyChessIdentity_t1607898065::get_offset_of_gamePly_27(),
	FairyChessIdentity_t1607898065::get_offset_of_sideToMove_28(),
	FairyChessIdentity_t1607898065::get_offset_of_variantType_29(),
	FairyChessIdentity_t1607898065::get_offset_of_chess960_30(),
	FairyChessIdentity_t1607898065::get_offset_of_pieceCountInHand_31(),
	FairyChessIdentity_t1607898065::get_offset_of_promotedPieces_32(),
	FairyChessIdentity_t1607898065::get_offset_of_isCustom_33(),
	FairyChessIdentity_t1607898065::get_offset_of_netData_34(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListboard_35(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListunpromotedBoard_36(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListbyTypeBB_37(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListbyColorBB_38(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListpieceCount_39(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListpieceList_40(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListindex_41(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListcastlingRightsMask_42(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListcastlingRookSquare_43(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListcastlingPath_44(),
	FairyChessIdentity_t1607898065_StaticFields::get_offset_of_kListpieceCountInHand_45(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6025 = { sizeof (FairyChessMoveAnimation_t69044422), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6025[6] = 
{
	FairyChessMoveAnimation_t69044422::get_offset_of_board_5(),
	FairyChessMoveAnimation_t69044422::get_offset_of_pieceCountInHand_6(),
	FairyChessMoveAnimation_t69044422::get_offset_of_promoteOrDropPiece_7(),
	FairyChessMoveAnimation_t69044422::get_offset_of_move_8(),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6026 = { sizeof (Property_t1568137095)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6026[5] = 
{
	Property_t1568137095::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6027 = { sizeof (FairyChessMoveAnimationIdentity_t3257862896), -1, sizeof(FairyChessMoveAnimationIdentity_t3257862896_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable6027[7] = 
{
	FairyChessMoveAnimationIdentity_t3257862896::get_offset_of_board_17(),
	FairyChessMoveAnimationIdentity_t3257862896::get_offset_of_pieceCountInHand_18(),
	FairyChessMoveAnimationIdentity_t3257862896::get_offset_of_promoteOrDropPiece_19(),
	FairyChessMoveAnimationIdentity_t3257862896::get_offset_of_move_20(),
	FairyChessMoveAnimationIdentity_t3257862896::get_offset_of_netData_21(),
	FairyChessMoveAnimationIdentity_t3257862896_StaticFields::get_offset_of_kListboard_22(),
	FairyChessMoveAnimationIdentity_t3257862896_StaticFields::get_offset_of_kListpieceCountInHand_23(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6028 = { sizeof (AnimationSetDirtyUpdate_t1223205005), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6028[1] = 
{
	AnimationSetDirtyUpdate_t1223205005::get_offset_of_animationManagerCheckChange_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6029 = { sizeof (FairyChessMove_t3420079360), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6029[2] = 
{
	FairyChessMove_t3420079360::get_offset_of_move_5(),
	FairyChessMove_t3420079360::get_offset_of_strMove_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6030 = { sizeof (Move_t1133248107)+ sizeof (Il2CppObject), sizeof(Move_t1133248107 ), 0, 0 };
extern const int32_t g_FieldOffsetTable6030[4] = 
{
	Move_t1133248107::get_offset_of_ori_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	Move_t1133248107::get_offset_of_dest_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	Move_t1133248107::get_offset_of_promotion_2() + static_cast<int32_t>(sizeof(Il2CppObject)),
	Move_t1133248107::get_offset_of_type_3() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6031 = { sizeof (Property_t1864985517)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6031[3] = 
{
	Property_t1864985517::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6032 = { sizeof (FairyChessMoveIdentity_t1929764730), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6032[3] = 
{
	FairyChessMoveIdentity_t1929764730::get_offset_of_move_17(),
	FairyChessMoveIdentity_t1929764730::get_offset_of_strMove_18(),
	FairyChessMoveIdentity_t1929764730::get_offset_of_netData_19(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6033 = { sizeof (FairyChessMoveUI_t2553501072), -1, sizeof(FairyChessMoveUI_t2553501072_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable6033[11] = 
{
	0,
	0,
	FairyChessMoveUI_t2553501072_StaticFields::get_offset_of_NormalColor_8(),
	FairyChessMoveUI_t2553501072_StaticFields::get_offset_of_PromotionColor_9(),
	FairyChessMoveUI_t2553501072_StaticFields::get_offset_of_DropColor_10(),
	FairyChessMoveUI_t2553501072_StaticFields::get_offset_of_hintNormalColor_11(),
	FairyChessMoveUI_t2553501072_StaticFields::get_offset_of_hintPromotionColor_12(),
	FairyChessMoveUI_t2553501072_StaticFields::get_offset_of_hintDropColor_13(),
	FairyChessMoveUI_t2553501072::get_offset_of_lineRenderer_14(),
	FairyChessMoveUI_t2553501072::get_offset_of_imgHint_15(),
	FairyChessMoveUI_t2553501072::get_offset_of_fairyChessGameDataUIData_16(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6034 = { sizeof (UIData_t2469374350), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6034[2] = 
{
	UIData_t2469374350::get_offset_of_fairyChessMove_5(),
	UIData_t2469374350::get_offset_of_isHint_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6035 = { sizeof (Property_t979204786)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6035[3] = 
{
	Property_t979204786::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6036 = { sizeof (StateInfo_t3161066623), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6036[17] = 
{
	StateInfo_t3161066623::get_offset_of_pawnKey_5(),
	StateInfo_t3161066623::get_offset_of_materialKey_6(),
	StateInfo_t3161066623::get_offset_of_nonPawnMaterial_7(),
	StateInfo_t3161066623::get_offset_of_castlingRights_8(),
	StateInfo_t3161066623::get_offset_of_rule50_9(),
	StateInfo_t3161066623::get_offset_of_pliesFromNull_10(),
	StateInfo_t3161066623::get_offset_of_checksGiven_11(),
	StateInfo_t3161066623::get_offset_of_psq_12(),
	StateInfo_t3161066623::get_offset_of_epSquare_13(),
	StateInfo_t3161066623::get_offset_of_key_14(),
	StateInfo_t3161066623::get_offset_of_checkersBB_15(),
	StateInfo_t3161066623::get_offset_of_capturedPiece_16(),
	StateInfo_t3161066623::get_offset_of_unpromotedCapturedPiece_17(),
	StateInfo_t3161066623::get_offset_of_blockersForKing_18(),
	StateInfo_t3161066623::get_offset_of_pinners_19(),
	StateInfo_t3161066623::get_offset_of_checkSquares_20(),
	StateInfo_t3161066623::get_offset_of_capturedpromoted_21(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6037 = { sizeof (Property_t2758205408)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6037[18] = 
{
	Property_t2758205408::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6038 = { sizeof (StateInfoIdentity_t3667173629), -1, sizeof(StateInfoIdentity_t3667173629_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable6038[23] = 
{
	StateInfoIdentity_t3667173629::get_offset_of_pawnKey_17(),
	StateInfoIdentity_t3667173629::get_offset_of_materialKey_18(),
	StateInfoIdentity_t3667173629::get_offset_of_nonPawnMaterial_19(),
	StateInfoIdentity_t3667173629::get_offset_of_castlingRights_20(),
	StateInfoIdentity_t3667173629::get_offset_of_rule50_21(),
	StateInfoIdentity_t3667173629::get_offset_of_pliesFromNull_22(),
	StateInfoIdentity_t3667173629::get_offset_of_checksGiven_23(),
	StateInfoIdentity_t3667173629::get_offset_of_psq_24(),
	StateInfoIdentity_t3667173629::get_offset_of_epSquare_25(),
	StateInfoIdentity_t3667173629::get_offset_of_key_26(),
	StateInfoIdentity_t3667173629::get_offset_of_checkersBB_27(),
	StateInfoIdentity_t3667173629::get_offset_of_capturedPiece_28(),
	StateInfoIdentity_t3667173629::get_offset_of_unpromotedCapturedPiece_29(),
	StateInfoIdentity_t3667173629::get_offset_of_blockersForKing_30(),
	StateInfoIdentity_t3667173629::get_offset_of_pinners_31(),
	StateInfoIdentity_t3667173629::get_offset_of_checkSquares_32(),
	StateInfoIdentity_t3667173629::get_offset_of_capturedpromoted_33(),
	StateInfoIdentity_t3667173629::get_offset_of_netData_34(),
	StateInfoIdentity_t3667173629_StaticFields::get_offset_of_kListnonPawnMaterial_35(),
	StateInfoIdentity_t3667173629_StaticFields::get_offset_of_kListchecksGiven_36(),
	StateInfoIdentity_t3667173629_StaticFields::get_offset_of_kListblockersForKing_37(),
	StateInfoIdentity_t3667173629_StaticFields::get_offset_of_kListpinners_38(),
	StateInfoIdentity_t3667173629_StaticFields::get_offset_of_kListcheckSquares_39(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6039 = { sizeof (TestFairyChess_t2391463083), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6040 = { sizeof (Work_t3158957512), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6040[1] = 
{
	Work_t3158957512::get_offset_of_rnd_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6041 = { sizeof (BoardUI_t2451992604), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6041[8] = 
{
	BoardUI_t2451992604::get_offset_of_fairyChessFenPrefab_6(),
	BoardUI_t2451992604::get_offset_of_fairyChessFenContainer_7(),
	BoardUI_t2451992604::get_offset_of_piecePrefab_8(),
	BoardUI_t2451992604::get_offset_of_animationManagerCheckChange_9(),
	BoardUI_t2451992604::get_offset_of_handPiecePrefab_10(),
	BoardUI_t2451992604::get_offset_of_whiteHandContainer_11(),
	BoardUI_t2451992604::get_offset_of_blackHandContainer_12(),
	BoardUI_t2451992604::get_offset_of_handContainer_13(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6042 = { sizeof (UIData_t2805356858), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6042[5] = 
{
	UIData_t2805356858::get_offset_of_fairyChess_5(),
	UIData_t2805356858::get_offset_of_fairyChessFen_6(),
	UIData_t2805356858::get_offset_of_pieces_7(),
	UIData_t2805356858::get_offset_of_whiteHand_8(),
	UIData_t2805356858::get_offset_of_blackHand_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6043 = { sizeof (Property_t2266697718)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6043[6] = 
{
	Property_t2266697718::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6044 = { sizeof (FairyChessFenUI_t2389940904), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6044[1] = 
{
	FairyChessFenUI_t2389940904::get_offset_of_tvFen_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6045 = { sizeof (UIData_t2879865490), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6045[1] = 
{
	UIData_t2879865490::get_offset_of_fairyChess_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6046 = { sizeof (Property_t1691085438)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6046[2] = 
{
	Property_t1691085438::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6047 = { sizeof (HandPieceUI_t904353653), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6047[4] = 
{
	HandPieceUI_t904353653::get_offset_of_imgPiece_6(),
	HandPieceUI_t904353653::get_offset_of_txtCount_7(),
	HandPieceUI_t904353653::get_offset_of_handMoveContainer_8(),
	HandPieceUI_t904353653::get_offset_of_perspectiveChange_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6048 = { sizeof (UIData_t743039105), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6048[3] = 
{
	UIData_t743039105::get_offset_of_variantType_5(),
	UIData_t743039105::get_offset_of_piece_6(),
	UIData_t743039105::get_offset_of_count_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6049 = { sizeof (Property_t1450346649)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6049[4] = 
{
	Property_t1450346649::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6050 = { sizeof (SpriteContainer_t1587746296), -1, sizeof(SpriteContainer_t1587746296_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable6050[52] = 
{
	SpriteContainer_t1587746296_StaticFields::get_offset_of_instance_2(),
	SpriteContainer_t1587746296::get_offset_of_Transparent_3(),
	SpriteContainer_t1587746296::get_offset_of_WhitePawn_4(),
	SpriteContainer_t1587746296::get_offset_of_WhiteKnight_5(),
	SpriteContainer_t1587746296::get_offset_of_WhiteBishop_6(),
	SpriteContainer_t1587746296::get_offset_of_WhiteRook_7(),
	SpriteContainer_t1587746296::get_offset_of_WhiteQueen_8(),
	SpriteContainer_t1587746296::get_offset_of_WhiteFers_9(),
	SpriteContainer_t1587746296::get_offset_of_WhiteMet_10(),
	SpriteContainer_t1587746296::get_offset_of_WhiteAlfil_11(),
	SpriteContainer_t1587746296::get_offset_of_WhiteSilver_12(),
	SpriteContainer_t1587746296::get_offset_of_WhiteKhon_13(),
	SpriteContainer_t1587746296::get_offset_of_WhiteAiwok_14(),
	SpriteContainer_t1587746296::get_offset_of_WhiteBers_15(),
	SpriteContainer_t1587746296::get_offset_of_WhiteDragon_16(),
	SpriteContainer_t1587746296::get_offset_of_WhiteChancellor_17(),
	SpriteContainer_t1587746296::get_offset_of_WhiteAmazon_18(),
	SpriteContainer_t1587746296::get_offset_of_WhiteKnibis_19(),
	SpriteContainer_t1587746296::get_offset_of_WhiteBiskni_20(),
	SpriteContainer_t1587746296::get_offset_of_WhiteShogiPawn_21(),
	SpriteContainer_t1587746296::get_offset_of_WhiteLance_22(),
	SpriteContainer_t1587746296::get_offset_of_WhiteShogiKnight_23(),
	SpriteContainer_t1587746296::get_offset_of_WhiteEuroShogiKnight_24(),
	SpriteContainer_t1587746296::get_offset_of_WhiteGold_25(),
	SpriteContainer_t1587746296::get_offset_of_WhiteHorse_26(),
	SpriteContainer_t1587746296::get_offset_of_WhiteCommoner_27(),
	SpriteContainer_t1587746296::get_offset_of_WhiteKing_28(),
	SpriteContainer_t1587746296::get_offset_of_BlackPawn_29(),
	SpriteContainer_t1587746296::get_offset_of_BlackKnight_30(),
	SpriteContainer_t1587746296::get_offset_of_BlackBishop_31(),
	SpriteContainer_t1587746296::get_offset_of_BlackRook_32(),
	SpriteContainer_t1587746296::get_offset_of_BlackQueen_33(),
	SpriteContainer_t1587746296::get_offset_of_BlackFers_34(),
	SpriteContainer_t1587746296::get_offset_of_BlackMet_35(),
	SpriteContainer_t1587746296::get_offset_of_BlackAlfil_36(),
	SpriteContainer_t1587746296::get_offset_of_BlackSilver_37(),
	SpriteContainer_t1587746296::get_offset_of_BlackKhon_38(),
	SpriteContainer_t1587746296::get_offset_of_BlackAiwok_39(),
	SpriteContainer_t1587746296::get_offset_of_BlackBers_40(),
	SpriteContainer_t1587746296::get_offset_of_BlackDragon_41(),
	SpriteContainer_t1587746296::get_offset_of_BlackChancellor_42(),
	SpriteContainer_t1587746296::get_offset_of_BlackAmazon_43(),
	SpriteContainer_t1587746296::get_offset_of_BlackKnibis_44(),
	SpriteContainer_t1587746296::get_offset_of_BlackBiskni_45(),
	SpriteContainer_t1587746296::get_offset_of_BlackShogiPawn_46(),
	SpriteContainer_t1587746296::get_offset_of_BlackLance_47(),
	SpriteContainer_t1587746296::get_offset_of_BlackShogiKnight_48(),
	SpriteContainer_t1587746296::get_offset_of_BlackEuroShogiKnight_49(),
	SpriteContainer_t1587746296::get_offset_of_BlackGold_50(),
	SpriteContainer_t1587746296::get_offset_of_BlackHorse_51(),
	SpriteContainer_t1587746296::get_offset_of_BlackCommoner_52(),
	SpriteContainer_t1587746296::get_offset_of_BlackKing_53(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6051 = { sizeof (PieceUI_t3028444168), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6051[4] = 
{
	PieceUI_t3028444168::get_offset_of_contentContainer_6(),
	PieceUI_t3028444168::get_offset_of_image_7(),
	PieceUI_t3028444168::get_offset_of_EnPassantColor_8(),
	PieceUI_t3028444168::get_offset_of_perspectiveChange_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6052 = { sizeof (UIData_t2287802308), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6052[3] = 
{
	UIData_t2287802308::get_offset_of_variantType_5(),
	UIData_t2287802308::get_offset_of_piece_6(),
	UIData_t2287802308::get_offset_of_position_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6053 = { sizeof (Property_t1672666520)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6053[4] = 
{
	Property_t1672666520::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6054 = { sizeof (FairyChessGameDataUI_t1215648031), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6054[5] = 
{
	FairyChessGameDataUI_t1215648031::get_offset_of_boardPrefab_6(),
	FairyChessGameDataUI_t1215648031::get_offset_of_lastMovePrefab_7(),
	FairyChessGameDataUI_t1215648031::get_offset_of_showHintPrefab_8(),
	FairyChessGameDataUI_t1215648031::get_offset_of_inputPrefab_9(),
	FairyChessGameDataUI_t1215648031::get_offset_of_checkHaveAnimation_10(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6055 = { sizeof (UIData_t3976046997), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6055[8] = 
{
	UIData_t3976046997::get_offset_of_gameData_5(),
	UIData_t3976046997::get_offset_of_updateTransform_6(),
	UIData_t3976046997::get_offset_of_transformOrganizer_7(),
	UIData_t3976046997::get_offset_of_isOnAnimation_8(),
	UIData_t3976046997::get_offset_of_board_9(),
	UIData_t3976046997::get_offset_of_lastMove_10(),
	UIData_t3976046997::get_offset_of_showHint_11(),
	UIData_t3976046997::get_offset_of_inputUI_12(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6056 = { sizeof (Property_t3430878405)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6056[9] = 
{
	Property_t3430878405::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6057 = { sizeof (InputUI_t2893746872), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6057[4] = 
{
	InputUI_t2893746872::get_offset_of_useRulePrefab_6(),
	InputUI_t2893746872::get_offset_of_noneRulePrefab_7(),
	InputUI_t2893746872::get_offset_of_gameDataUICheckAllowInputChange_8(),
	InputUI_t2893746872::get_offset_of_gameDataCheckChangeRule_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6058 = { sizeof (UIData_t1474262306), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6058[2] = 
{
	UIData_t1474262306::get_offset_of_fairyChess_5(),
	UIData_t1474262306::get_offset_of_sub_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6059 = { sizeof (Sub_t2386736321), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6060 = { sizeof (Type_t744141436)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6060[3] = 
{
	Type_t744141436::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6061 = { sizeof (Property_t182366462)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6061[3] = 
{
	Property_t182366462::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6062 = { sizeof (ClickMoveUI_t1312361047), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6062[3] = 
{
	ClickMoveUI_t1312361047::get_offset_of_imgSelect_6(),
	ClickMoveUI_t1312361047::get_offset_of_perspectiveChange_7(),
	ClickMoveUI_t1312361047::get_offset_of_noneRuleInputUIData_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6063 = { sizeof (UIData_t4257096937), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6063[2] = 
{
	UIData_t4257096937::get_offset_of_x_5(),
	UIData_t4257096937::get_offset_of_y_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6064 = { sizeof (Property_t2275703689)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6064[3] = 
{
	Property_t2275703689::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6065 = { sizeof (FairyChessCustomMove_t1339138931), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6065[4] = 
{
	FairyChessCustomMove_t1339138931::get_offset_of_fromX_5(),
	FairyChessCustomMove_t1339138931::get_offset_of_fromY_6(),
	FairyChessCustomMove_t1339138931::get_offset_of_destX_7(),
	FairyChessCustomMove_t1339138931::get_offset_of_destY_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6066 = { sizeof (Property_t3035747054)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6066[5] = 
{
	Property_t3035747054::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6067 = { sizeof (FairyChessCustomMoveIdentity_t3668310309), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6067[5] = 
{
	FairyChessCustomMoveIdentity_t3668310309::get_offset_of_fromX_17(),
	FairyChessCustomMoveIdentity_t3668310309::get_offset_of_fromY_18(),
	FairyChessCustomMoveIdentity_t3668310309::get_offset_of_destX_19(),
	FairyChessCustomMoveIdentity_t3668310309::get_offset_of_destY_20(),
	FairyChessCustomMoveIdentity_t3668310309::get_offset_of_netData_21(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6068 = { sizeof (FairyChessCustomMoveUI_t3002134561), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6068[2] = 
{
	FairyChessCustomMoveUI_t3002134561::get_offset_of_lineRendererFrom_6(),
	FairyChessCustomMoveUI_t3002134561::get_offset_of_lineRendererDest_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6069 = { sizeof (UIData_t2716078571), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6069[2] = 
{
	UIData_t2716078571::get_offset_of_fairyChessCustomMove_5(),
	UIData_t2716078571::get_offset_of_isHint_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6070 = { sizeof (Property_t1142469455)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6070[3] = 
{
	Property_t1142469455::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6071 = { sizeof (ClickNoneUI_t21695562), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6072 = { sizeof (UIData_t1390728048), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6073 = { sizeof (Property_t3796120748)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6073[1] = 
{
	Property_t3796120748::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6074 = { sizeof (ClickPosUI_t1482736564), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6074[5] = 
{
	ClickPosUI_t1482736564::get_offset_of_imgSelect_6(),
	ClickPosUI_t1482736564::get_offset_of_contentContainer_7(),
	ClickPosUI_t1482736564::get_offset_of_btnMove_8(),
	ClickPosUI_t1482736564::get_offset_of_perspectiveChange_9(),
	ClickPosUI_t1482736564::get_offset_of_noneRuleInputUIData_10(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6075 = { sizeof (UIData_t531432842), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6075[2] = 
{
	UIData_t531432842::get_offset_of_x_5(),
	UIData_t531432842::get_offset_of_y_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6076 = { sizeof (Property_t545572962)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6076[3] = 
{
	Property_t545572962::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6077 = { sizeof (NoneRuleInputUI_t4261330204), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6077[6] = 
{
	NoneRuleInputUI_t4261330204::get_offset_of_nonePrefab_6(),
	NoneRuleInputUI_t4261330204::get_offset_of_posPrefab_7(),
	NoneRuleInputUI_t4261330204::get_offset_of_setPiecePrefab_8(),
	NoneRuleInputUI_t4261330204::get_offset_of_clickMovePrefab_9(),
	NoneRuleInputUI_t4261330204::get_offset_of_setHandPrefab_10(),
	NoneRuleInputUI_t4261330204::get_offset_of_subContainer_11(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6078 = { sizeof (UIData_t1139753962), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6078[2] = 
{
	UIData_t1139753962::get_offset_of_fairyChess_5(),
	UIData_t1139753962::get_offset_of_sub_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6079 = { sizeof (Sub_t20091405), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6080 = { sizeof (Type_t37971860)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6080[6] = 
{
	Type_t37971860::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6081 = { sizeof (Property_t1266111622)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6081[3] = 
{
	Property_t1266111622::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6082 = { sizeof (SetHandAdapter_t3379902588), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6082[3] = 
{
	SetHandAdapter_t3379902588::get_offset_of_holderPrefab_24(),
	SetHandAdapter_t3379902588::get_offset_of_noPieces_25(),
	SetHandAdapter_t3379902588::get_offset_of_noneRuleInputUIData_26(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6083 = { sizeof (UIData_t2889539922), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6083[3] = 
{
	UIData_t2889539922::get_offset_of_holders_20(),
	UIData_t2889539922::get_offset_of_chosen_21(),
	UIData_t2889539922::get_offset_of_pieces_22(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6084 = { sizeof (Property_t462586522)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6084[3] = 
{
	Property_t462586522::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6085 = { sizeof (SetHandHolder_t2816521467), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6085[5] = 
{
	SetHandHolder_t2816521467::get_offset_of_imgPiece_16(),
	SetHandHolder_t2816521467::get_offset_of_tvPieceCount_17(),
	SetHandHolder_t2816521467::get_offset_of_chosenIndicator_18(),
	SetHandHolder_t2816521467::get_offset_of_noneRuleInputUIData_19(),
	SetHandHolder_t2816521467::get_offset_of_setHandAdapterUIData_20(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6086 = { sizeof (UIData_t3522919935), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6086[1] = 
{
	UIData_t3522919935::get_offset_of_piece_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6087 = { sizeof (Property_t2374726187)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6087[2] = 
{
	Property_t2374726187::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6088 = { sizeof (FairyChessCustomHand_t1103868243), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6088[3] = 
{
	FairyChessCustomHand_t1103868243::get_offset_of_color_5(),
	FairyChessCustomHand_t1103868243::get_offset_of_pieceType_6(),
	FairyChessCustomHand_t1103868243::get_offset_of_pieceCount_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6089 = { sizeof (Property_t2233486674)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6089[4] = 
{
	Property_t2233486674::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6090 = { sizeof (FairyChessCustomHandIdentity_t487438273), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6090[4] = 
{
	FairyChessCustomHandIdentity_t487438273::get_offset_of_color_17(),
	FairyChessCustomHandIdentity_t487438273::get_offset_of_pieceType_18(),
	FairyChessCustomHandIdentity_t487438273::get_offset_of_pieceCount_19(),
	FairyChessCustomHandIdentity_t487438273::get_offset_of_netData_20(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6091 = { sizeof (FairyChessCustomHandUI_t1973079333), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6091[3] = 
{
	FairyChessCustomHandUI_t1973079333::get_offset_of_imgHint_6(),
	FairyChessCustomHandUI_t1973079333::get_offset_of_contentContainer_7(),
	FairyChessCustomHandUI_t1973079333::get_offset_of_fairyChessGameDataUIData_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6092 = { sizeof (UIData_t3976694933), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6092[2] = 
{
	UIData_t3976694933::get_offset_of_fairyChessCustomHand_5(),
	UIData_t3976694933::get_offset_of_isHint_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6093 = { sizeof (Property_t2778082957)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6093[3] = 
{
	Property_t2778082957::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6094 = { sizeof (SetHandUI_t1499879215), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6094[5] = 
{
	SetHandUI_t1499879215::get_offset_of_contentContainer_6(),
	SetHandUI_t1499879215::get_offset_of_edtPieceCount_7(),
	SetHandUI_t1499879215::get_offset_of_checkPerspectiveChange_8(),
	SetHandUI_t1499879215::get_offset_of_setHandAdapterPrefab_9(),
	SetHandUI_t1499879215::get_offset_of_setHandAdapterContainer_10(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6095 = { sizeof (UIData_t1254411083), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6095[1] = 
{
	UIData_t1254411083::get_offset_of_setHandAdapter_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6096 = { sizeof (Property_t1655062751)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6096[2] = 
{
	Property_t1655062751::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6097 = { sizeof (ChoosePieceAdapter_t2445772018), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6097[4] = 
{
	ChoosePieceAdapter_t2445772018::get_offset_of_holderPrefab_24(),
	ChoosePieceAdapter_t2445772018::get_offset_of_noPieces_25(),
	ChoosePieceAdapter_t2445772018::get_offset_of_noneRuleInputUIData_26(),
	ChoosePieceAdapter_t2445772018::get_offset_of_setPieceUIData_27(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6098 = { sizeof (UIData_t4225497702), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable6098[2] = 
{
	UIData_t4225497702::get_offset_of_holders_20(),
	UIData_t4225497702::get_offset_of_pieces_21(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize6099 = { sizeof (Property_t3951887338)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable6099[2] = 
{
	Property_t3951887338::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
