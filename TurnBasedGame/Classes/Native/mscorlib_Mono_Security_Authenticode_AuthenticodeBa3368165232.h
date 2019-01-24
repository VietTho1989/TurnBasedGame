#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.IO.FileStream
struct FileStream_t1695958676;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.Authenticode.AuthenticodeBase
struct  AuthenticodeBase_t3368165232  : public Il2CppObject
{
public:
	// System.Byte[] Mono.Security.Authenticode.AuthenticodeBase::fileblock
	ByteU5BU5D_t3397334013* ___fileblock_0;
	// System.IO.FileStream Mono.Security.Authenticode.AuthenticodeBase::fs
	FileStream_t1695958676 * ___fs_1;
	// System.Int32 Mono.Security.Authenticode.AuthenticodeBase::blockNo
	int32_t ___blockNo_2;
	// System.Int32 Mono.Security.Authenticode.AuthenticodeBase::blockLength
	int32_t ___blockLength_3;
	// System.Int32 Mono.Security.Authenticode.AuthenticodeBase::peOffset
	int32_t ___peOffset_4;
	// System.Int32 Mono.Security.Authenticode.AuthenticodeBase::dirSecurityOffset
	int32_t ___dirSecurityOffset_5;
	// System.Int32 Mono.Security.Authenticode.AuthenticodeBase::dirSecuritySize
	int32_t ___dirSecuritySize_6;
	// System.Int32 Mono.Security.Authenticode.AuthenticodeBase::coffSymbolTableOffset
	int32_t ___coffSymbolTableOffset_7;

public:
	inline static int32_t get_offset_of_fileblock_0() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___fileblock_0)); }
	inline ByteU5BU5D_t3397334013* get_fileblock_0() const { return ___fileblock_0; }
	inline ByteU5BU5D_t3397334013** get_address_of_fileblock_0() { return &___fileblock_0; }
	inline void set_fileblock_0(ByteU5BU5D_t3397334013* value)
	{
		___fileblock_0 = value;
		Il2CppCodeGenWriteBarrier(&___fileblock_0, value);
	}

	inline static int32_t get_offset_of_fs_1() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___fs_1)); }
	inline FileStream_t1695958676 * get_fs_1() const { return ___fs_1; }
	inline FileStream_t1695958676 ** get_address_of_fs_1() { return &___fs_1; }
	inline void set_fs_1(FileStream_t1695958676 * value)
	{
		___fs_1 = value;
		Il2CppCodeGenWriteBarrier(&___fs_1, value);
	}

	inline static int32_t get_offset_of_blockNo_2() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___blockNo_2)); }
	inline int32_t get_blockNo_2() const { return ___blockNo_2; }
	inline int32_t* get_address_of_blockNo_2() { return &___blockNo_2; }
	inline void set_blockNo_2(int32_t value)
	{
		___blockNo_2 = value;
	}

	inline static int32_t get_offset_of_blockLength_3() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___blockLength_3)); }
	inline int32_t get_blockLength_3() const { return ___blockLength_3; }
	inline int32_t* get_address_of_blockLength_3() { return &___blockLength_3; }
	inline void set_blockLength_3(int32_t value)
	{
		___blockLength_3 = value;
	}

	inline static int32_t get_offset_of_peOffset_4() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___peOffset_4)); }
	inline int32_t get_peOffset_4() const { return ___peOffset_4; }
	inline int32_t* get_address_of_peOffset_4() { return &___peOffset_4; }
	inline void set_peOffset_4(int32_t value)
	{
		___peOffset_4 = value;
	}

	inline static int32_t get_offset_of_dirSecurityOffset_5() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___dirSecurityOffset_5)); }
	inline int32_t get_dirSecurityOffset_5() const { return ___dirSecurityOffset_5; }
	inline int32_t* get_address_of_dirSecurityOffset_5() { return &___dirSecurityOffset_5; }
	inline void set_dirSecurityOffset_5(int32_t value)
	{
		___dirSecurityOffset_5 = value;
	}

	inline static int32_t get_offset_of_dirSecuritySize_6() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___dirSecuritySize_6)); }
	inline int32_t get_dirSecuritySize_6() const { return ___dirSecuritySize_6; }
	inline int32_t* get_address_of_dirSecuritySize_6() { return &___dirSecuritySize_6; }
	inline void set_dirSecuritySize_6(int32_t value)
	{
		___dirSecuritySize_6 = value;
	}

	inline static int32_t get_offset_of_coffSymbolTableOffset_7() { return static_cast<int32_t>(offsetof(AuthenticodeBase_t3368165232, ___coffSymbolTableOffset_7)); }
	inline int32_t get_coffSymbolTableOffset_7() const { return ___coffSymbolTableOffset_7; }
	inline int32_t* get_address_of_coffSymbolTableOffset_7() { return &___coffSymbolTableOffset_7; }
	inline void set_coffSymbolTableOffset_7(int32_t value)
	{
		___coffSymbolTableOffset_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
