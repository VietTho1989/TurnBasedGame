#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"
#include "UnityEngine_UnityEngine_Color2020392075.h"

// System.String
struct String_t;
// Global
struct Global_t3177480217;
// VP`1<UnityEngine.NetworkReachability>
struct VP_1_t1471024151;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Global
struct  Global_t3177480217  : public Data_t3569509720
{
public:
	// VP`1<UnityEngine.NetworkReachability> Global::networkReachability
	VP_1_t1471024151 * ___networkReachability_10;

public:
	inline static int32_t get_offset_of_networkReachability_10() { return static_cast<int32_t>(offsetof(Global_t3177480217, ___networkReachability_10)); }
	inline VP_1_t1471024151 * get_networkReachability_10() const { return ___networkReachability_10; }
	inline VP_1_t1471024151 ** get_address_of_networkReachability_10() { return &___networkReachability_10; }
	inline void set_networkReachability_10(VP_1_t1471024151 * value)
	{
		___networkReachability_10 = value;
		Il2CppCodeGenWriteBarrier(&___networkReachability_10, value);
	}
};

struct Global_t3177480217_StaticFields
{
public:
	// System.String Global::DataPath
	String_t* ___DataPath_8;
	// Global Global::instance
	Global_t3177480217 * ___instance_9;
	// UnityEngine.Color Global::NormalColor
	Color_t2020392075  ___NormalColor_11;
	// UnityEngine.Color Global::HintColor
	Color_t2020392075  ___HintColor_12;
	// UnityEngine.Color Global::TransparentColor
	Color_t2020392075  ___TransparentColor_13;

public:
	inline static int32_t get_offset_of_DataPath_8() { return static_cast<int32_t>(offsetof(Global_t3177480217_StaticFields, ___DataPath_8)); }
	inline String_t* get_DataPath_8() const { return ___DataPath_8; }
	inline String_t** get_address_of_DataPath_8() { return &___DataPath_8; }
	inline void set_DataPath_8(String_t* value)
	{
		___DataPath_8 = value;
		Il2CppCodeGenWriteBarrier(&___DataPath_8, value);
	}

	inline static int32_t get_offset_of_instance_9() { return static_cast<int32_t>(offsetof(Global_t3177480217_StaticFields, ___instance_9)); }
	inline Global_t3177480217 * get_instance_9() const { return ___instance_9; }
	inline Global_t3177480217 ** get_address_of_instance_9() { return &___instance_9; }
	inline void set_instance_9(Global_t3177480217 * value)
	{
		___instance_9 = value;
		Il2CppCodeGenWriteBarrier(&___instance_9, value);
	}

	inline static int32_t get_offset_of_NormalColor_11() { return static_cast<int32_t>(offsetof(Global_t3177480217_StaticFields, ___NormalColor_11)); }
	inline Color_t2020392075  get_NormalColor_11() const { return ___NormalColor_11; }
	inline Color_t2020392075 * get_address_of_NormalColor_11() { return &___NormalColor_11; }
	inline void set_NormalColor_11(Color_t2020392075  value)
	{
		___NormalColor_11 = value;
	}

	inline static int32_t get_offset_of_HintColor_12() { return static_cast<int32_t>(offsetof(Global_t3177480217_StaticFields, ___HintColor_12)); }
	inline Color_t2020392075  get_HintColor_12() const { return ___HintColor_12; }
	inline Color_t2020392075 * get_address_of_HintColor_12() { return &___HintColor_12; }
	inline void set_HintColor_12(Color_t2020392075  value)
	{
		___HintColor_12 = value;
	}

	inline static int32_t get_offset_of_TransparentColor_13() { return static_cast<int32_t>(offsetof(Global_t3177480217_StaticFields, ___TransparentColor_13)); }
	inline Color_t2020392075  get_TransparentColor_13() const { return ___TransparentColor_13; }
	inline Color_t2020392075 * get_address_of_TransparentColor_13() { return &___TransparentColor_13; }
	inline void set_TransparentColor_13(Color_t2020392075  value)
	{
		___TransparentColor_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
