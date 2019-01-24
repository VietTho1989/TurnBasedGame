#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<AccountAdmin>>
struct VP_1_t2796748083;
// VP`1<ReferenceData`1<Data>>
struct VP_1_t3018569789;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<Data/EditType>
struct VP_1_t1172595727;
// System.Collections.Generic.List`1<System.Byte>
struct List_1_t3052225568;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EditData`1<AccountAdmin>
struct  EditData_1_t808449778  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<K>> EditData`1::origin
	VP_1_t2796748083 * ___origin_5;
	// VP`1<ReferenceData`1<K>> EditData`1::show
	VP_1_t2796748083 * ___show_6;
	// VP`1<ReferenceData`1<K>> EditData`1::compare
	VP_1_t2796748083 * ___compare_7;
	// VP`1<ReferenceData`1<Data>> EditData`1::compareOtherType
	VP_1_t3018569789 * ___compareOtherType_8;
	// VP`1<System.Boolean> EditData`1::canEdit
	VP_1_t4203851724 * ___canEdit_9;
	// VP`1<Data/EditType> EditData`1::editType
	VP_1_t1172595727 * ___editType_10;
	// System.Boolean EditData`1::dirty
	bool ___dirty_11;
	// System.Boolean EditData`1::haveOriginChange
	bool ___haveOriginChange_12;
	// System.Collections.Generic.List`1<System.Byte> EditData`1::allowNames
	List_1_t3052225568 * ___allowNames_13;

public:
	inline static int32_t get_offset_of_origin_5() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___origin_5)); }
	inline VP_1_t2796748083 * get_origin_5() const { return ___origin_5; }
	inline VP_1_t2796748083 ** get_address_of_origin_5() { return &___origin_5; }
	inline void set_origin_5(VP_1_t2796748083 * value)
	{
		___origin_5 = value;
		Il2CppCodeGenWriteBarrier(&___origin_5, value);
	}

	inline static int32_t get_offset_of_show_6() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___show_6)); }
	inline VP_1_t2796748083 * get_show_6() const { return ___show_6; }
	inline VP_1_t2796748083 ** get_address_of_show_6() { return &___show_6; }
	inline void set_show_6(VP_1_t2796748083 * value)
	{
		___show_6 = value;
		Il2CppCodeGenWriteBarrier(&___show_6, value);
	}

	inline static int32_t get_offset_of_compare_7() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___compare_7)); }
	inline VP_1_t2796748083 * get_compare_7() const { return ___compare_7; }
	inline VP_1_t2796748083 ** get_address_of_compare_7() { return &___compare_7; }
	inline void set_compare_7(VP_1_t2796748083 * value)
	{
		___compare_7 = value;
		Il2CppCodeGenWriteBarrier(&___compare_7, value);
	}

	inline static int32_t get_offset_of_compareOtherType_8() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___compareOtherType_8)); }
	inline VP_1_t3018569789 * get_compareOtherType_8() const { return ___compareOtherType_8; }
	inline VP_1_t3018569789 ** get_address_of_compareOtherType_8() { return &___compareOtherType_8; }
	inline void set_compareOtherType_8(VP_1_t3018569789 * value)
	{
		___compareOtherType_8 = value;
		Il2CppCodeGenWriteBarrier(&___compareOtherType_8, value);
	}

	inline static int32_t get_offset_of_canEdit_9() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___canEdit_9)); }
	inline VP_1_t4203851724 * get_canEdit_9() const { return ___canEdit_9; }
	inline VP_1_t4203851724 ** get_address_of_canEdit_9() { return &___canEdit_9; }
	inline void set_canEdit_9(VP_1_t4203851724 * value)
	{
		___canEdit_9 = value;
		Il2CppCodeGenWriteBarrier(&___canEdit_9, value);
	}

	inline static int32_t get_offset_of_editType_10() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___editType_10)); }
	inline VP_1_t1172595727 * get_editType_10() const { return ___editType_10; }
	inline VP_1_t1172595727 ** get_address_of_editType_10() { return &___editType_10; }
	inline void set_editType_10(VP_1_t1172595727 * value)
	{
		___editType_10 = value;
		Il2CppCodeGenWriteBarrier(&___editType_10, value);
	}

	inline static int32_t get_offset_of_dirty_11() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___dirty_11)); }
	inline bool get_dirty_11() const { return ___dirty_11; }
	inline bool* get_address_of_dirty_11() { return &___dirty_11; }
	inline void set_dirty_11(bool value)
	{
		___dirty_11 = value;
	}

	inline static int32_t get_offset_of_haveOriginChange_12() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___haveOriginChange_12)); }
	inline bool get_haveOriginChange_12() const { return ___haveOriginChange_12; }
	inline bool* get_address_of_haveOriginChange_12() { return &___haveOriginChange_12; }
	inline void set_haveOriginChange_12(bool value)
	{
		___haveOriginChange_12 = value;
	}

	inline static int32_t get_offset_of_allowNames_13() { return static_cast<int32_t>(offsetof(EditData_1_t808449778, ___allowNames_13)); }
	inline List_1_t3052225568 * get_allowNames_13() const { return ___allowNames_13; }
	inline List_1_t3052225568 ** get_address_of_allowNames_13() { return &___allowNames_13; }
	inline void set_allowNames_13(List_1_t3052225568 * value)
	{
		___allowNames_13 = value;
		Il2CppCodeGenWriteBarrier(&___allowNames_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
