#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"
#include "mscorlib_System_IO_FileAccess4282042064.h"
#include "mscorlib_System_IntPtr2504060609.h"

// System.EventHandler
struct EventHandler_t277755526;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IO.UnmanagedMemoryStream
struct  UnmanagedMemoryStream_t822875729  : public Stream_t3255436806
{
public:
	// System.Int64 System.IO.UnmanagedMemoryStream::length
	int64_t ___length_2;
	// System.Boolean System.IO.UnmanagedMemoryStream::closed
	bool ___closed_3;
	// System.Int64 System.IO.UnmanagedMemoryStream::capacity
	int64_t ___capacity_4;
	// System.IO.FileAccess System.IO.UnmanagedMemoryStream::fileaccess
	int32_t ___fileaccess_5;
	// System.IntPtr System.IO.UnmanagedMemoryStream::initial_pointer
	IntPtr_t ___initial_pointer_6;
	// System.Int64 System.IO.UnmanagedMemoryStream::initial_position
	int64_t ___initial_position_7;
	// System.Int64 System.IO.UnmanagedMemoryStream::current_position
	int64_t ___current_position_8;
	// System.EventHandler System.IO.UnmanagedMemoryStream::Closed
	EventHandler_t277755526 * ___Closed_9;

public:
	inline static int32_t get_offset_of_length_2() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___length_2)); }
	inline int64_t get_length_2() const { return ___length_2; }
	inline int64_t* get_address_of_length_2() { return &___length_2; }
	inline void set_length_2(int64_t value)
	{
		___length_2 = value;
	}

	inline static int32_t get_offset_of_closed_3() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___closed_3)); }
	inline bool get_closed_3() const { return ___closed_3; }
	inline bool* get_address_of_closed_3() { return &___closed_3; }
	inline void set_closed_3(bool value)
	{
		___closed_3 = value;
	}

	inline static int32_t get_offset_of_capacity_4() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___capacity_4)); }
	inline int64_t get_capacity_4() const { return ___capacity_4; }
	inline int64_t* get_address_of_capacity_4() { return &___capacity_4; }
	inline void set_capacity_4(int64_t value)
	{
		___capacity_4 = value;
	}

	inline static int32_t get_offset_of_fileaccess_5() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___fileaccess_5)); }
	inline int32_t get_fileaccess_5() const { return ___fileaccess_5; }
	inline int32_t* get_address_of_fileaccess_5() { return &___fileaccess_5; }
	inline void set_fileaccess_5(int32_t value)
	{
		___fileaccess_5 = value;
	}

	inline static int32_t get_offset_of_initial_pointer_6() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___initial_pointer_6)); }
	inline IntPtr_t get_initial_pointer_6() const { return ___initial_pointer_6; }
	inline IntPtr_t* get_address_of_initial_pointer_6() { return &___initial_pointer_6; }
	inline void set_initial_pointer_6(IntPtr_t value)
	{
		___initial_pointer_6 = value;
	}

	inline static int32_t get_offset_of_initial_position_7() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___initial_position_7)); }
	inline int64_t get_initial_position_7() const { return ___initial_position_7; }
	inline int64_t* get_address_of_initial_position_7() { return &___initial_position_7; }
	inline void set_initial_position_7(int64_t value)
	{
		___initial_position_7 = value;
	}

	inline static int32_t get_offset_of_current_position_8() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___current_position_8)); }
	inline int64_t get_current_position_8() const { return ___current_position_8; }
	inline int64_t* get_address_of_current_position_8() { return &___current_position_8; }
	inline void set_current_position_8(int64_t value)
	{
		___current_position_8 = value;
	}

	inline static int32_t get_offset_of_Closed_9() { return static_cast<int32_t>(offsetof(UnmanagedMemoryStream_t822875729, ___Closed_9)); }
	inline EventHandler_t277755526 * get_Closed_9() const { return ___Closed_9; }
	inline EventHandler_t277755526 ** get_address_of_Closed_9() { return &___Closed_9; }
	inline void set_Closed_9(EventHandler_t277755526 * value)
	{
		___Closed_9 = value;
		Il2CppCodeGenWriteBarrier(&___Closed_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
