#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<EditData`1<Room>>
struct VP_1_t3176404439;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;
// VP`1<RequestChangeEnumUI/UIData>
struct VP_1_t3850875635;
// VP`1<Rights.ChangeRightsUI/UIData>
struct VP_1_t1781459343;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomSettingUI/UIData
struct  UIData_t2663628414  : public Data_t3569509720
{
public:
	// VP`1<EditData`1<Room>> RoomSettingUI/UIData::editRoom
	VP_1_t3176404439 * ___editRoom_5;
	// VP`1<RequestChangeStringUI/UIData> RoomSettingUI/UIData::name
	VP_1_t1525575381 * ___name_6;
	// VP`1<RequestChangeEnumUI/UIData> RoomSettingUI/UIData::allowHint
	VP_1_t3850875635 * ___allowHint_7;
	// VP`1<Rights.ChangeRightsUI/UIData> RoomSettingUI/UIData::changeRights
	VP_1_t1781459343 * ___changeRights_8;

public:
	inline static int32_t get_offset_of_editRoom_5() { return static_cast<int32_t>(offsetof(UIData_t2663628414, ___editRoom_5)); }
	inline VP_1_t3176404439 * get_editRoom_5() const { return ___editRoom_5; }
	inline VP_1_t3176404439 ** get_address_of_editRoom_5() { return &___editRoom_5; }
	inline void set_editRoom_5(VP_1_t3176404439 * value)
	{
		___editRoom_5 = value;
		Il2CppCodeGenWriteBarrier(&___editRoom_5, value);
	}

	inline static int32_t get_offset_of_name_6() { return static_cast<int32_t>(offsetof(UIData_t2663628414, ___name_6)); }
	inline VP_1_t1525575381 * get_name_6() const { return ___name_6; }
	inline VP_1_t1525575381 ** get_address_of_name_6() { return &___name_6; }
	inline void set_name_6(VP_1_t1525575381 * value)
	{
		___name_6 = value;
		Il2CppCodeGenWriteBarrier(&___name_6, value);
	}

	inline static int32_t get_offset_of_allowHint_7() { return static_cast<int32_t>(offsetof(UIData_t2663628414, ___allowHint_7)); }
	inline VP_1_t3850875635 * get_allowHint_7() const { return ___allowHint_7; }
	inline VP_1_t3850875635 ** get_address_of_allowHint_7() { return &___allowHint_7; }
	inline void set_allowHint_7(VP_1_t3850875635 * value)
	{
		___allowHint_7 = value;
		Il2CppCodeGenWriteBarrier(&___allowHint_7, value);
	}

	inline static int32_t get_offset_of_changeRights_8() { return static_cast<int32_t>(offsetof(UIData_t2663628414, ___changeRights_8)); }
	inline VP_1_t1781459343 * get_changeRights_8() const { return ___changeRights_8; }
	inline VP_1_t1781459343 ** get_address_of_changeRights_8() { return &___changeRights_8; }
	inline void set_changeRights_8(VP_1_t1781459343 * value)
	{
		___changeRights_8 = value;
		Il2CppCodeGenWriteBarrier(&___changeRights_8, value);
	}
};

struct UIData_t2663628414_StaticFields
{
public:
	// System.Collections.Generic.List`1<System.Byte> RoomSettingUI/UIData::AllowNames
	List_1_t3052225568 * ___AllowNames_9;

public:
	inline static int32_t get_offset_of_AllowNames_9() { return static_cast<int32_t>(offsetof(UIData_t2663628414_StaticFields, ___AllowNames_9)); }
	inline List_1_t3052225568 * get_AllowNames_9() const { return ___AllowNames_9; }
	inline List_1_t3052225568 ** get_address_of_AllowNames_9() { return &___AllowNames_9; }
	inline void set_AllowNames_9(List_1_t3052225568 * value)
	{
		___AllowNames_9 = value;
		Il2CppCodeGenWriteBarrier(&___AllowNames_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
