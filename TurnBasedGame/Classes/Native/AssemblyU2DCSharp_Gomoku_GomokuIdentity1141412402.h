#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// DataIdentity/SyncListByte
struct SyncListByte_t230810734;
// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<Gomoku.Gomoku>
struct NetData_1_t2895338333;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuIdentity
struct  GomokuIdentity_t1141412402  : public DataIdentity_t543951486
{
public:
	// System.Int32 Gomoku.GomokuIdentity::boardSize
	int32_t ___boardSize_17;
	// DataIdentity/SyncListByte Gomoku.GomokuIdentity::gs
	SyncListByte_t230810734 * ___gs_18;
	// System.Int32 Gomoku.GomokuIdentity::player
	int32_t ___player_19;
	// System.Int32 Gomoku.GomokuIdentity::winningPlayer
	int32_t ___winningPlayer_20;
	// UnityEngine.Networking.SyncListInt Gomoku.GomokuIdentity::lastMove
	SyncListInt_t3316705628 * ___lastMove_21;
	// System.Int32 Gomoku.GomokuIdentity::winSize
	int32_t ___winSize_22;
	// UnityEngine.Networking.SyncListInt Gomoku.GomokuIdentity::winCoord
	SyncListInt_t3316705628 * ___winCoord_23;
	// System.Boolean Gomoku.GomokuIdentity::isCustom
	bool ___isCustom_24;
	// NetData`1<Gomoku.Gomoku> Gomoku.GomokuIdentity::netData
	NetData_1_t2895338333 * ___netData_25;

public:
	inline static int32_t get_offset_of_boardSize_17() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___boardSize_17)); }
	inline int32_t get_boardSize_17() const { return ___boardSize_17; }
	inline int32_t* get_address_of_boardSize_17() { return &___boardSize_17; }
	inline void set_boardSize_17(int32_t value)
	{
		___boardSize_17 = value;
	}

	inline static int32_t get_offset_of_gs_18() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___gs_18)); }
	inline SyncListByte_t230810734 * get_gs_18() const { return ___gs_18; }
	inline SyncListByte_t230810734 ** get_address_of_gs_18() { return &___gs_18; }
	inline void set_gs_18(SyncListByte_t230810734 * value)
	{
		___gs_18 = value;
		Il2CppCodeGenWriteBarrier(&___gs_18, value);
	}

	inline static int32_t get_offset_of_player_19() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___player_19)); }
	inline int32_t get_player_19() const { return ___player_19; }
	inline int32_t* get_address_of_player_19() { return &___player_19; }
	inline void set_player_19(int32_t value)
	{
		___player_19 = value;
	}

	inline static int32_t get_offset_of_winningPlayer_20() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___winningPlayer_20)); }
	inline int32_t get_winningPlayer_20() const { return ___winningPlayer_20; }
	inline int32_t* get_address_of_winningPlayer_20() { return &___winningPlayer_20; }
	inline void set_winningPlayer_20(int32_t value)
	{
		___winningPlayer_20 = value;
	}

	inline static int32_t get_offset_of_lastMove_21() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___lastMove_21)); }
	inline SyncListInt_t3316705628 * get_lastMove_21() const { return ___lastMove_21; }
	inline SyncListInt_t3316705628 ** get_address_of_lastMove_21() { return &___lastMove_21; }
	inline void set_lastMove_21(SyncListInt_t3316705628 * value)
	{
		___lastMove_21 = value;
		Il2CppCodeGenWriteBarrier(&___lastMove_21, value);
	}

	inline static int32_t get_offset_of_winSize_22() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___winSize_22)); }
	inline int32_t get_winSize_22() const { return ___winSize_22; }
	inline int32_t* get_address_of_winSize_22() { return &___winSize_22; }
	inline void set_winSize_22(int32_t value)
	{
		___winSize_22 = value;
	}

	inline static int32_t get_offset_of_winCoord_23() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___winCoord_23)); }
	inline SyncListInt_t3316705628 * get_winCoord_23() const { return ___winCoord_23; }
	inline SyncListInt_t3316705628 ** get_address_of_winCoord_23() { return &___winCoord_23; }
	inline void set_winCoord_23(SyncListInt_t3316705628 * value)
	{
		___winCoord_23 = value;
		Il2CppCodeGenWriteBarrier(&___winCoord_23, value);
	}

	inline static int32_t get_offset_of_isCustom_24() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___isCustom_24)); }
	inline bool get_isCustom_24() const { return ___isCustom_24; }
	inline bool* get_address_of_isCustom_24() { return &___isCustom_24; }
	inline void set_isCustom_24(bool value)
	{
		___isCustom_24 = value;
	}

	inline static int32_t get_offset_of_netData_25() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402, ___netData_25)); }
	inline NetData_1_t2895338333 * get_netData_25() const { return ___netData_25; }
	inline NetData_1_t2895338333 ** get_address_of_netData_25() { return &___netData_25; }
	inline void set_netData_25(NetData_1_t2895338333 * value)
	{
		___netData_25 = value;
		Il2CppCodeGenWriteBarrier(&___netData_25, value);
	}
};

struct GomokuIdentity_t1141412402_StaticFields
{
public:
	// System.Int32 Gomoku.GomokuIdentity::kListgs
	int32_t ___kListgs_26;
	// System.Int32 Gomoku.GomokuIdentity::kListlastMove
	int32_t ___kListlastMove_27;
	// System.Int32 Gomoku.GomokuIdentity::kListwinCoord
	int32_t ___kListwinCoord_28;

public:
	inline static int32_t get_offset_of_kListgs_26() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402_StaticFields, ___kListgs_26)); }
	inline int32_t get_kListgs_26() const { return ___kListgs_26; }
	inline int32_t* get_address_of_kListgs_26() { return &___kListgs_26; }
	inline void set_kListgs_26(int32_t value)
	{
		___kListgs_26 = value;
	}

	inline static int32_t get_offset_of_kListlastMove_27() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402_StaticFields, ___kListlastMove_27)); }
	inline int32_t get_kListlastMove_27() const { return ___kListlastMove_27; }
	inline int32_t* get_address_of_kListlastMove_27() { return &___kListlastMove_27; }
	inline void set_kListlastMove_27(int32_t value)
	{
		___kListlastMove_27 = value;
	}

	inline static int32_t get_offset_of_kListwinCoord_28() { return static_cast<int32_t>(offsetof(GomokuIdentity_t1141412402_StaticFields, ___kListwinCoord_28)); }
	inline int32_t get_kListwinCoord_28() const { return ___kListwinCoord_28; }
	inline int32_t* get_address_of_kListwinCoord_28() { return &___kListwinCoord_28; }
	inline void set_kListwinCoord_28(int32_t value)
	{
		___kListwinCoord_28 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
