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
// NetData`1<Makruk.MakrukMoveAnimation>
struct NetData_1_t4240212963;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Makruk.MakrukMoveAnimationIdentity
struct  MakrukMoveAnimationIdentity_t3968191264  : public DataIdentity_t543951486
{
public:
	// UnityEngine.Networking.SyncListInt Makruk.MakrukMoveAnimationIdentity::board
	SyncListInt_t3316705628 * ___board_17;
	// System.Int32 Makruk.MakrukMoveAnimationIdentity::move
	int32_t ___move_18;
	// System.Boolean Makruk.MakrukMoveAnimationIdentity::chess960
	bool ___chess960_19;
	// NetData`1<Makruk.MakrukMoveAnimation> Makruk.MakrukMoveAnimationIdentity::netData
	NetData_1_t4240212963 * ___netData_20;

public:
	inline static int32_t get_offset_of_board_17() { return static_cast<int32_t>(offsetof(MakrukMoveAnimationIdentity_t3968191264, ___board_17)); }
	inline SyncListInt_t3316705628 * get_board_17() const { return ___board_17; }
	inline SyncListInt_t3316705628 ** get_address_of_board_17() { return &___board_17; }
	inline void set_board_17(SyncListInt_t3316705628 * value)
	{
		___board_17 = value;
		Il2CppCodeGenWriteBarrier(&___board_17, value);
	}

	inline static int32_t get_offset_of_move_18() { return static_cast<int32_t>(offsetof(MakrukMoveAnimationIdentity_t3968191264, ___move_18)); }
	inline int32_t get_move_18() const { return ___move_18; }
	inline int32_t* get_address_of_move_18() { return &___move_18; }
	inline void set_move_18(int32_t value)
	{
		___move_18 = value;
	}

	inline static int32_t get_offset_of_chess960_19() { return static_cast<int32_t>(offsetof(MakrukMoveAnimationIdentity_t3968191264, ___chess960_19)); }
	inline bool get_chess960_19() const { return ___chess960_19; }
	inline bool* get_address_of_chess960_19() { return &___chess960_19; }
	inline void set_chess960_19(bool value)
	{
		___chess960_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(MakrukMoveAnimationIdentity_t3968191264, ___netData_20)); }
	inline NetData_1_t4240212963 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t4240212963 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t4240212963 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

struct MakrukMoveAnimationIdentity_t3968191264_StaticFields
{
public:
	// System.Int32 Makruk.MakrukMoveAnimationIdentity::kListboard
	int32_t ___kListboard_21;

public:
	inline static int32_t get_offset_of_kListboard_21() { return static_cast<int32_t>(offsetof(MakrukMoveAnimationIdentity_t3968191264_StaticFields, ___kListboard_21)); }
	inline int32_t get_kListboard_21() const { return ___kListboard_21; }
	inline int32_t* get_address_of_kListboard_21() { return &___kListboard_21; }
	inline void set_kListboard_21(int32_t value)
	{
		___kListboard_21 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
