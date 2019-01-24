#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"
#include "AssemblyU2DCSharp_FairyChess_Common_VariantType3570894812.h"

// NetData`1<FairyChess.DefaultFairyChess>
struct NetData_1_t2377280699;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FairyChess.DefaultFairyChessIdentity
struct  DefaultFairyChessIdentity_t4199589352  : public DataIdentity_t543951486
{
public:
	// FairyChess.Common/VariantType FairyChess.DefaultFairyChessIdentity::variantType
	int32_t ___variantType_17;
	// System.Boolean FairyChess.DefaultFairyChessIdentity::chess960
	bool ___chess960_18;
	// NetData`1<FairyChess.DefaultFairyChess> FairyChess.DefaultFairyChessIdentity::netData
	NetData_1_t2377280699 * ___netData_19;

public:
	inline static int32_t get_offset_of_variantType_17() { return static_cast<int32_t>(offsetof(DefaultFairyChessIdentity_t4199589352, ___variantType_17)); }
	inline int32_t get_variantType_17() const { return ___variantType_17; }
	inline int32_t* get_address_of_variantType_17() { return &___variantType_17; }
	inline void set_variantType_17(int32_t value)
	{
		___variantType_17 = value;
	}

	inline static int32_t get_offset_of_chess960_18() { return static_cast<int32_t>(offsetof(DefaultFairyChessIdentity_t4199589352, ___chess960_18)); }
	inline bool get_chess960_18() const { return ___chess960_18; }
	inline bool* get_address_of_chess960_18() { return &___chess960_18; }
	inline void set_chess960_18(bool value)
	{
		___chess960_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(DefaultFairyChessIdentity_t4199589352, ___netData_19)); }
	inline NetData_1_t2377280699 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t2377280699 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t2377280699 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
