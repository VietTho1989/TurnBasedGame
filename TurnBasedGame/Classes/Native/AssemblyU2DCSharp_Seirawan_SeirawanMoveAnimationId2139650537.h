#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// UnityEngine.Networking.SyncListBool
struct SyncListBool_t375623471;
// NetData`1<Seirawan.SeirawanMoveAnimation>
struct NetData_1_t1001358400;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Seirawan.SeirawanMoveAnimationIdentity
struct  SeirawanMoveAnimationIdentity_t2139650537  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Seirawan.SeirawanMoveAnimationIdentity::board
	SyncListInt_t3316705628 * ___board_17;
	// UnityEngine.Networking.SyncListBool Seirawan.SeirawanMoveAnimationIdentity::inHand
	SyncListBool_t375623471 * ___inHand_18;
	// System.Int32 Seirawan.SeirawanMoveAnimationIdentity::move
	int32_t ___move_19;
	// System.Boolean Seirawan.SeirawanMoveAnimationIdentity::chess960
	bool ___chess960_20;
	// NetData`1<Seirawan.SeirawanMoveAnimation> Seirawan.SeirawanMoveAnimationIdentity::netData
	NetData_1_t1001358400 * ___netData_21;

public:
	inline static int32_t get_offset_of_board_17() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimationIdentity_t2139650537, ___board_17)); }
	inline SyncListInt_t3316705628 * get_board_17() const { return ___board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_board_17() { return &___board_17; }
	inline void set_board_17(SyncListInt_t3316705628 * value)
	{
		___board_17 = value;
		Il2CppCodeGenWriteBarrier(&___board_17, value);
	}

	inline static int32_t get_offset_of_inHand_18() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimationIdentity_t2139650537, ___inHand_18)); }
	inline SyncListBool_t375623471 * get_inHand_18() const { return ___inHand_18; }
	inline SyncListBool_t375623471 ** get_address_of_inHand_18() { return &___inHand_18; }
	inline void set_inHand_18(SyncListBool_t375623471 * value)
	{
		___inHand_18 = value;
		Il2CppCodeGenWriteBarrier(&___inHand_18, value);
	}

	inline static int32_t get_offset_of_move_19() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimationIdentity_t2139650537, ___move_19)); }
	inline int32_t get_move_19() const { return ___move_19; }
	inline int32_t* get_address_of_move_19() { return &___move_19; }
	inline void set_move_19(int32_t value)
	{
		___move_19 = value;
	}

	inline static int32_t get_offset_of_chess960_20() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimationIdentity_t2139650537, ___chess960_20)); }
	inline bool get_chess960_20() const { return ___chess960_20; }
	inline bool* get_address_of_chess960_20() { return &___chess960_20; }
	inline void set_chess960_20(bool value)
	{
		___chess960_20 = value;
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimationIdentity_t2139650537, ___netData_21)); }
	inline NetData_1_t1001358400 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t1001358400 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t1001358400 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

struct SeirawanMoveAnimationIdentity_t2139650537_StaticFields
{
public:
	// System.Int32 Seirawan.SeirawanMoveAnimationIdentity::kListboard
	int32_t ___kListboard_22;
	// System.Int32 Seirawan.SeirawanMoveAnimationIdentity::kListinHand
	int32_t ___kListinHand_23;

public:
	inline static int32_t get_offset_of_kListboard_22() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimationIdentity_t2139650537_StaticFields, ___kListboard_22)); }
	inline int32_t get_kListboard_22() const { return ___kListboard_22; }
	inline int32_t* get_address_of_kListboard_22() { return &___kListboard_22; }
	inline void set_kListboard_22(int32_t value)
	{
		___kListboard_22 = value;
	}

	inline static int32_t get_offset_of_kListinHand_23() { return static_cast<int32_t>(offsetof(SeirawanMoveAnimationIdentity_t2139650537_StaticFields, ___kListinHand_23)); }
	inline int32_t get_kListinHand_23() const { return ___kListinHand_23; }
	inline int32_t* get_address_of_kListinHand_23() { return &___kListinHand_23; }
	inline void set_kListinHand_23(int32_t value)
	{
		___kListinHand_23 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
