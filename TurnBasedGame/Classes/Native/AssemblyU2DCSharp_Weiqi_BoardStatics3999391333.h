#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.Int32>
struct LP_1_t809621404;
// LP`1<System.UInt64>
struct LP_1_t1646940870;
// LP`1<System.Byte>
struct LP_1_t2420848392;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.BoardStatics
struct  BoardStatics_t3999391333  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> Weiqi.BoardStatics::size
	VP_1_t2450154454 * ___size_6;
	// LP`1<System.Int32> Weiqi.BoardStatics::nei8
	LP_1_t809621404 * ___nei8_7;
	// LP`1<System.Int32> Weiqi.BoardStatics::dnei
	LP_1_t809621404 * ___dnei_8;
	// LP`1<System.UInt64> Weiqi.BoardStatics::h
	LP_1_t1646940870 * ___h_9;
	// LP`1<System.Byte> Weiqi.BoardStatics::coord
	LP_1_t2420848392 * ___coord_10;

public:
	inline static int32_t get_offset_of_size_6() { return static_cast<int32_t>(offsetof(BoardStatics_t3999391333, ___size_6)); }
	inline VP_1_t2450154454 * get_size_6() const { return ___size_6; }
	inline VP_1_t2450154454 ** get_address_of_size_6() { return &___size_6; }
	inline void set_size_6(VP_1_t2450154454 * value)
	{
		___size_6 = value;
		Il2CppCodeGenWriteBarrier(&___size_6, value);
	}

	inline static int32_t get_offset_of_nei8_7() { return static_cast<int32_t>(offsetof(BoardStatics_t3999391333, ___nei8_7)); }
	inline LP_1_t809621404 * get_nei8_7() const { return ___nei8_7; }
	inline LP_1_t809621404 ** get_address_of_nei8_7() { return &___nei8_7; }
	inline void set_nei8_7(LP_1_t809621404 * value)
	{
		___nei8_7 = value;
		Il2CppCodeGenWriteBarrier(&___nei8_7, value);
	}

	inline static int32_t get_offset_of_dnei_8() { return static_cast<int32_t>(offsetof(BoardStatics_t3999391333, ___dnei_8)); }
	inline LP_1_t809621404 * get_dnei_8() const { return ___dnei_8; }
	inline LP_1_t809621404 ** get_address_of_dnei_8() { return &___dnei_8; }
	inline void set_dnei_8(LP_1_t809621404 * value)
	{
		___dnei_8 = value;
		Il2CppCodeGenWriteBarrier(&___dnei_8, value);
	}

	inline static int32_t get_offset_of_h_9() { return static_cast<int32_t>(offsetof(BoardStatics_t3999391333, ___h_9)); }
	inline LP_1_t1646940870 * get_h_9() const { return ___h_9; }
	inline LP_1_t1646940870 ** get_address_of_h_9() { return &___h_9; }
	inline void set_h_9(LP_1_t1646940870 * value)
	{
		___h_9 = value;
		Il2CppCodeGenWriteBarrier(&___h_9, value);
	}

	inline static int32_t get_offset_of_coord_10() { return static_cast<int32_t>(offsetof(BoardStatics_t3999391333, ___coord_10)); }
	inline LP_1_t2420848392 * get_coord_10() const { return ___coord_10; }
	inline LP_1_t2420848392 ** get_address_of_coord_10() { return &___coord_10; }
	inline void set_coord_10(LP_1_t2420848392 * value)
	{
		___coord_10 = value;
		Il2CppCodeGenWriteBarrier(&___coord_10, value);
	}
};

struct BoardStatics_t3999391333_StaticFields
{
public:
	// System.Boolean Weiqi.BoardStatics::log
	bool ___log_5;

public:
	inline static int32_t get_offset_of_log_5() { return static_cast<int32_t>(offsetof(BoardStatics_t3999391333_StaticFields, ___log_5)); }
	inline bool get_log_5() const { return ___log_5; }
	inline bool* get_address_of_log_5() { return &___log_5; }
	inline void set_log_5(bool value)
	{
		___log_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
