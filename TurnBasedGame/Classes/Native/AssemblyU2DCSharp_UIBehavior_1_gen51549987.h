#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameBehavior_1_gen2398688557.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UIBehavior`1<CoTuongUp.PieceUI/UIData>
struct  UIBehavior_1_t51549987  : public GameBehavior_1_t2398688557
{
public:
	// System.Boolean UIBehavior`1::Dirty
	bool ___Dirty_3;
	// System.Boolean UIBehavior`1::alreadyDestroy
	bool ___alreadyDestroy_4;
	// System.Int32 UIBehavior`1::trashInstanceId
	int32_t ___trashInstanceId_5;

public:
	inline static int32_t get_offset_of_Dirty_3() { return static_cast<int32_t>(offsetof(UIBehavior_1_t51549987, ___Dirty_3)); }
	inline bool get_Dirty_3() const { return ___Dirty_3; }
	inline bool* get_address_of_Dirty_3() { return &___Dirty_3; }
	inline void set_Dirty_3(bool value)
	{
		___Dirty_3 = value;
	}

	inline static int32_t get_offset_of_alreadyDestroy_4() { return static_cast<int32_t>(offsetof(UIBehavior_1_t51549987, ___alreadyDestroy_4)); }
	inline bool get_alreadyDestroy_4() const { return ___alreadyDestroy_4; }
	inline bool* get_address_of_alreadyDestroy_4() { return &___alreadyDestroy_4; }
	inline void set_alreadyDestroy_4(bool value)
	{
		___alreadyDestroy_4 = value;
	}

	inline static int32_t get_offset_of_trashInstanceId_5() { return static_cast<int32_t>(offsetof(UIBehavior_1_t51549987, ___trashInstanceId_5)); }
	inline int32_t get_trashInstanceId_5() const { return ___trashInstanceId_5; }
	inline int32_t* get_address_of_trashInstanceId_5() { return &___trashInstanceId_5; }
	inline void set_trashInstanceId_5(int32_t value)
	{
		___trashInstanceId_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
