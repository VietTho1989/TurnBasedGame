#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<SaveTask/TaskData>
struct VP_1_t3421027334;
// VP`1<ConfirmSaveDataUI/UIData>
struct VP_1_t2237614292;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BtnSaveDataUI/UIData
struct  UIData_t3536738430  : public Data_t3569509720
{
public:
	// VP`1<SaveTask/TaskData> BtnSaveDataUI/UIData::saveData
	VP_1_t3421027334 * ___saveData_5;
	// VP`1<ConfirmSaveDataUI/UIData> BtnSaveDataUI/UIData::confirmSave
	VP_1_t2237614292 * ___confirmSave_6;

public:
	inline static int32_t get_offset_of_saveData_5() { return static_cast<int32_t>(offsetof(UIData_t3536738430, ___saveData_5)); }
	inline VP_1_t3421027334 * get_saveData_5() const { return ___saveData_5; }
	inline VP_1_t3421027334 ** get_address_of_saveData_5() { return &___saveData_5; }
	inline void set_saveData_5(VP_1_t3421027334 * value)
	{
		___saveData_5 = value;
		Il2CppCodeGenWriteBarrier(&___saveData_5, value);
	}

	inline static int32_t get_offset_of_confirmSave_6() { return static_cast<int32_t>(offsetof(UIData_t3536738430, ___confirmSave_6)); }
	inline VP_1_t2237614292 * get_confirmSave_6() const { return ___confirmSave_6; }
	inline VP_1_t2237614292 ** get_address_of_confirmSave_6() { return &___confirmSave_6; }
	inline void set_confirmSave_6(VP_1_t2237614292 * value)
	{
		___confirmSave_6 = value;
		Il2CppCodeGenWriteBarrier(&___confirmSave_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
