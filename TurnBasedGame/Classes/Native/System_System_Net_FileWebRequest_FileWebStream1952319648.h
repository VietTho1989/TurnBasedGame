#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_FileStream1695958676.h"

// System.Net.FileWebRequest
struct FileWebRequest_t1571840111;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.FileWebRequest/FileWebStream
struct  FileWebStream_t1952319648  : public FileStream_t1695958676
{
public:
	// System.Net.FileWebRequest System.Net.FileWebRequest/FileWebStream::webRequest
	FileWebRequest_t1571840111 * ___webRequest_16;

public:
	inline static int32_t get_offset_of_webRequest_16() { return static_cast<int32_t>(offsetof(FileWebStream_t1952319648, ___webRequest_16)); }
	inline FileWebRequest_t1571840111 * get_webRequest_16() const { return ___webRequest_16; }
	inline FileWebRequest_t1571840111 ** get_address_of_webRequest_16() { return &___webRequest_16; }
	inline void set_webRequest_16(FileWebRequest_t1571840111 * value)
	{
		___webRequest_16 = value;
		Il2CppCodeGenWriteBarrier(&___webRequest_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
