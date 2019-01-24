#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<Rights.UndoRedoRight>
struct NetData_1_t1101982255;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.UndoRedoRightIdentity
struct  UndoRedoRightIdentity_t1284460624  : public DataIdentity_t543951486
{
public:
	// System.Boolean Rights.UndoRedoRightIdentity::needAccept
	bool ___needAccept_17;
	// System.Boolean Rights.UndoRedoRightIdentity::needAdmin
	bool ___needAdmin_18;
	// NetData`1<Rights.UndoRedoRight> Rights.UndoRedoRightIdentity::netData
	NetData_1_t1101982255 * ___netData_19;

public:
	inline static int32_t get_offset_of_needAccept_17() { return static_cast<int32_t>(offsetof(UndoRedoRightIdentity_t1284460624, ___needAccept_17)); }
	inline bool get_needAccept_17() const { return ___needAccept_17; }
	inline bool* get_address_of_needAccept_17() { return &___needAccept_17; }
	inline void set_needAccept_17(bool value)
	{
		___needAccept_17 = value;
	}

	inline static int32_t get_offset_of_needAdmin_18() { return static_cast<int32_t>(offsetof(UndoRedoRightIdentity_t1284460624, ___needAdmin_18)); }
	inline bool get_needAdmin_18() const { return ___needAdmin_18; }
	inline bool* get_address_of_needAdmin_18() { return &___needAdmin_18; }
	inline void set_needAdmin_18(bool value)
	{
		___needAdmin_18 = value;
	}

	inline static int32_t get_offset_of_netData_19() { return static_cast<int32_t>(offsetof(UndoRedoRightIdentity_t1284460624, ___netData_19)); }
	inline NetData_1_t1101982255 * get_netData_19() const { return ___netData_19; }
	inline NetData_1_t1101982255 ** get_address_of_netData_19() { return &___netData_19; }
	inline void set_netData_19(NetData_1_t1101982255 * value)
	{
		___netData_19 = value;
		Il2CppCodeGenWriteBarrier(&___netData_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
