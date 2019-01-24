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
// TextSetting
struct TextSetting_t3054021281;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TextSettingCheckChange
struct  TextSettingCheckChange_t1980666161  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> TextSettingCheckChange::change
	VP_1_t2450154454 * ___change_5;
	// TextSetting TextSettingCheckChange::data
	TextSetting_t3054021281 * ___data_6;

public:
	inline static int32_t get_offset_of_change_5() { return static_cast<int32_t>(offsetof(TextSettingCheckChange_t1980666161, ___change_5)); }
	inline VP_1_t2450154454 * get_change_5() const { return ___change_5; }
	inline VP_1_t2450154454 ** get_address_of_change_5() { return &___change_5; }
	inline void set_change_5(VP_1_t2450154454 * value)
	{
		___change_5 = value;
		Il2CppCodeGenWriteBarrier(&___change_5, value);
	}

	inline static int32_t get_offset_of_data_6() { return static_cast<int32_t>(offsetof(TextSettingCheckChange_t1980666161, ___data_6)); }
	inline TextSetting_t3054021281 * get_data_6() const { return ___data_6; }
	inline TextSetting_t3054021281 ** get_address_of_data_6() { return &___data_6; }
	inline void set_data_6(TextSetting_t3054021281 * value)
	{
		___data_6 = value;
		Il2CppCodeGenWriteBarrier(&___data_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
