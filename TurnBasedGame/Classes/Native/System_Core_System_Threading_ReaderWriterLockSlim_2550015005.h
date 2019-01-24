#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Threading.ReaderWriterLockSlim/LockDetails
struct  LockDetails_t2550015005  : public Il2CppObject
{
public:
	// System.Int32 System.Threading.ReaderWriterLockSlim/LockDetails::ThreadId
	int32_t ___ThreadId_0;
	// System.Int32 System.Threading.ReaderWriterLockSlim/LockDetails::ReadLocks
	int32_t ___ReadLocks_1;

public:
	inline static int32_t get_offset_of_ThreadId_0() { return static_cast<int32_t>(offsetof(LockDetails_t2550015005, ___ThreadId_0)); }
	inline int32_t get_ThreadId_0() const { return ___ThreadId_0; }
	inline int32_t* get_address_of_ThreadId_0() { return &___ThreadId_0; }
	inline void set_ThreadId_0(int32_t value)
	{
		___ThreadId_0 = value;
	}

	inline static int32_t get_offset_of_ReadLocks_1() { return static_cast<int32_t>(offsetof(LockDetails_t2550015005, ___ReadLocks_1)); }
	inline int32_t get_ReadLocks_1() const { return ___ReadLocks_1; }
	inline int32_t* get_address_of_ReadLocks_1() { return &___ReadLocks_1; }
	inline void set_ReadLocks_1(int32_t value)
	{
		___ReadLocks_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
