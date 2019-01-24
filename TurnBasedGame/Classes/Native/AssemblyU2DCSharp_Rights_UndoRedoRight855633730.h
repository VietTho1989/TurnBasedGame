#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<Rights.Limit>
struct VP_1_t2104224591;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.UndoRedoRight
struct  UndoRedoRight_t855633730  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> Rights.UndoRedoRight::needAccept
	VP_1_t4203851724 * ___needAccept_5;
	// VP`1<System.Boolean> Rights.UndoRedoRight::needAdmin
	VP_1_t4203851724 * ___needAdmin_6;
	// VP`1<Rights.Limit> Rights.UndoRedoRight::limit
	VP_1_t2104224591 * ___limit_7;

public:
	inline static int32_t get_offset_of_needAccept_5() { return static_cast<int32_t>(offsetof(UndoRedoRight_t855633730, ___needAccept_5)); }
	inline VP_1_t4203851724 * get_needAccept_5() const { return ___needAccept_5; }
	inline VP_1_t4203851724 ** get_address_of_needAccept_5() { return &___needAccept_5; }
	inline void set_needAccept_5(VP_1_t4203851724 * value)
	{
		___needAccept_5 = value;
		Il2CppCodeGenWriteBarrier(&___needAccept_5, value);
	}

	inline static int32_t get_offset_of_needAdmin_6() { return static_cast<int32_t>(offsetof(UndoRedoRight_t855633730, ___needAdmin_6)); }
	inline VP_1_t4203851724 * get_needAdmin_6() const { return ___needAdmin_6; }
	inline VP_1_t4203851724 ** get_address_of_needAdmin_6() { return &___needAdmin_6; }
	inline void set_needAdmin_6(VP_1_t4203851724 * value)
	{
		___needAdmin_6 = value;
		Il2CppCodeGenWriteBarrier(&___needAdmin_6, value);
	}

	inline static int32_t get_offset_of_limit_7() { return static_cast<int32_t>(offsetof(UndoRedoRight_t855633730, ___limit_7)); }
	inline VP_1_t2104224591 * get_limit_7() const { return ___limit_7; }
	inline VP_1_t2104224591 ** get_address_of_limit_7() { return &___limit_7; }
	inline void set_limit_7(VP_1_t2104224591 * value)
	{
		___limit_7 = value;
		Il2CppCodeGenWriteBarrier(&___limit_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
