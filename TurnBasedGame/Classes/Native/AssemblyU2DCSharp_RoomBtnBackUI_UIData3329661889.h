#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Room>>
struct VP_1_t491458442;
// VP`1<RoomBtnBackUI/UIData/State>
struct VP_1_t380258819;
// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<RoomBtnBackConfirmUI/UIData>
struct VP_1_t284836193;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomBtnBackUI/UIData
struct  UIData_t3329661889  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Room>> RoomBtnBackUI/UIData::room
	VP_1_t491458442 * ___room_5;
	// VP`1<RoomBtnBackUI/UIData/State> RoomBtnBackUI/UIData::state
	VP_1_t380258819 * ___state_6;
	// VP`1<System.Boolean> RoomBtnBackUI/UIData::needConfirm
	VP_1_t4203851724 * ___needConfirm_7;
	// VP`1<RoomBtnBackConfirmUI/UIData> RoomBtnBackUI/UIData::confirm
	VP_1_t284836193 * ___confirm_8;

public:
	inline static int32_t get_offset_of_room_5() { return static_cast<int32_t>(offsetof(UIData_t3329661889, ___room_5)); }
	inline VP_1_t491458442 * get_room_5() const { return ___room_5; }
	inline VP_1_t491458442 ** get_address_of_room_5() { return &___room_5; }
	inline void set_room_5(VP_1_t491458442 * value)
	{
		___room_5 = value;
		Il2CppCodeGenWriteBarrier(&___room_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t3329661889, ___state_6)); }
	inline VP_1_t380258819 * get_state_6() const { return ___state_6; }
	inline VP_1_t380258819 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t380258819 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_needConfirm_7() { return static_cast<int32_t>(offsetof(UIData_t3329661889, ___needConfirm_7)); }
	inline VP_1_t4203851724 * get_needConfirm_7() const { return ___needConfirm_7; }
	inline VP_1_t4203851724 ** get_address_of_needConfirm_7() { return &___needConfirm_7; }
	inline void set_needConfirm_7(VP_1_t4203851724 * value)
	{
		___needConfirm_7 = value;
		Il2CppCodeGenWriteBarrier(&___needConfirm_7, value);
	}

	inline static int32_t get_offset_of_confirm_8() { return static_cast<int32_t>(offsetof(UIData_t3329661889, ___confirm_8)); }
	inline VP_1_t284836193 * get_confirm_8() const { return ___confirm_8; }
	inline VP_1_t284836193 ** get_address_of_confirm_8() { return &___confirm_8; }
	inline void set_confirm_8(VP_1_t284836193 * value)
	{
		___confirm_8 = value;
		Il2CppCodeGenWriteBarrier(&___confirm_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
