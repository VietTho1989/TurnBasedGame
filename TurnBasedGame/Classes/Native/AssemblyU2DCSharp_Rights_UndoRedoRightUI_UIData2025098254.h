#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<EditData`1<Rights.UndoRedoRight>>
struct VP_1_t2989639796;
// VP`1<RequestChangeBoolUI/UIData>
struct VP_1_t3802102788;
// VP`1<RequestChangeEnumUI/UIData>
struct VP_1_t3850875635;
// VP`1<Rights.Limit/UIData>
struct VP_1_t3283153895;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.UndoRedoRightUI/UIData
struct  UIData_t2025098254  : public Data_t3569509720
{
public:
	// VP`1<EditData`1<Rights.UndoRedoRight>> Rights.UndoRedoRightUI/UIData::editUndoRedoRight
	VP_1_t2989639796 * ___editUndoRedoRight_5;
	// VP`1<RequestChangeBoolUI/UIData> Rights.UndoRedoRightUI/UIData::needAccept
	VP_1_t3802102788 * ___needAccept_6;
	// VP`1<RequestChangeBoolUI/UIData> Rights.UndoRedoRightUI/UIData::needAdmin
	VP_1_t3802102788 * ___needAdmin_7;
	// VP`1<RequestChangeEnumUI/UIData> Rights.UndoRedoRightUI/UIData::limitType
	VP_1_t3850875635 * ___limitType_8;
	// VP`1<Rights.Limit/UIData> Rights.UndoRedoRightUI/UIData::limitUIData
	VP_1_t3283153895 * ___limitUIData_9;

public:
	inline static int32_t get_offset_of_editUndoRedoRight_5() { return static_cast<int32_t>(offsetof(UIData_t2025098254, ___editUndoRedoRight_5)); }
	inline VP_1_t2989639796 * get_editUndoRedoRight_5() const { return ___editUndoRedoRight_5; }
	inline VP_1_t2989639796 ** get_address_of_editUndoRedoRight_5() { return &___editUndoRedoRight_5; }
	inline void set_editUndoRedoRight_5(VP_1_t2989639796 * value)
	{
		___editUndoRedoRight_5 = value;
		Il2CppCodeGenWriteBarrier(&___editUndoRedoRight_5, value);
	}

	inline static int32_t get_offset_of_needAccept_6() { return static_cast<int32_t>(offsetof(UIData_t2025098254, ___needAccept_6)); }
	inline VP_1_t3802102788 * get_needAccept_6() const { return ___needAccept_6; }
	inline VP_1_t3802102788 ** get_address_of_needAccept_6() { return &___needAccept_6; }
	inline void set_needAccept_6(VP_1_t3802102788 * value)
	{
		___needAccept_6 = value;
		Il2CppCodeGenWriteBarrier(&___needAccept_6, value);
	}

	inline static int32_t get_offset_of_needAdmin_7() { return static_cast<int32_t>(offsetof(UIData_t2025098254, ___needAdmin_7)); }
	inline VP_1_t3802102788 * get_needAdmin_7() const { return ___needAdmin_7; }
	inline VP_1_t3802102788 ** get_address_of_needAdmin_7() { return &___needAdmin_7; }
	inline void set_needAdmin_7(VP_1_t3802102788 * value)
	{
		___needAdmin_7 = value;
		Il2CppCodeGenWriteBarrier(&___needAdmin_7, value);
	}

	inline static int32_t get_offset_of_limitType_8() { return static_cast<int32_t>(offsetof(UIData_t2025098254, ___limitType_8)); }
	inline VP_1_t3850875635 * get_limitType_8() const { return ___limitType_8; }
	inline VP_1_t3850875635 ** get_address_of_limitType_8() { return &___limitType_8; }
	inline void set_limitType_8(VP_1_t3850875635 * value)
	{
		___limitType_8 = value;
		Il2CppCodeGenWriteBarrier(&___limitType_8, value);
	}

	inline static int32_t get_offset_of_limitUIData_9() { return static_cast<int32_t>(offsetof(UIData_t2025098254, ___limitUIData_9)); }
	inline VP_1_t3283153895 * get_limitUIData_9() const { return ___limitUIData_9; }
	inline VP_1_t3283153895 ** get_address_of_limitUIData_9() { return &___limitUIData_9; }
	inline void set_limitUIData_9(VP_1_t3283153895 * value)
	{
		___limitUIData_9 = value;
		Il2CppCodeGenWriteBarrier(&___limitUIData_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
