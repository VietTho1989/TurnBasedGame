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

// System.Net.Sockets.Socket
struct Socket_t3821512045;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.Sockets.NetworkStream
struct  NetworkStream_t581172200  : public Stream_t3255436806
{
public:
	// System.IO.FileAccess System.Net.Sockets.NetworkStream::access
	int32_t ___access_2;
	// System.Net.Sockets.Socket System.Net.Sockets.NetworkStream::socket
	Socket_t3821512045 * ___socket_3;
	// System.Boolean System.Net.Sockets.NetworkStream::owns_socket
	bool ___owns_socket_4;
	// System.Boolean System.Net.Sockets.NetworkStream::readable
	bool ___readable_5;
	// System.Boolean System.Net.Sockets.NetworkStream::writeable
	bool ___writeable_6;
	// System.Boolean System.Net.Sockets.NetworkStream::disposed
	bool ___disposed_7;

public:
	inline static int32_t get_offset_of_access_2() { return static_cast<int32_t>(offsetof(NetworkStream_t581172200, ___access_2)); }
	inline int32_t get_access_2() const { return ___access_2; }
	inline int32_t* get_address_of_access_2() { return &___access_2; }
	inline void set_access_2(int32_t value)
	{
		___access_2 = value;
	}

	inline static int32_t get_offset_of_socket_3() { return static_cast<int32_t>(offsetof(NetworkStream_t581172200, ___socket_3)); }
	inline Socket_t3821512045 * get_socket_3() const { return ___socket_3; }
	inline Socket_t3821512045 ** get_address_of_socket_3() { return &___socket_3; }
	inline void set_socket_3(Socket_t3821512045 * value)
	{
		___socket_3 = value;
		Il2CppCodeGenWriteBarrier(&___socket_3, value);
	}

	inline static int32_t get_offset_of_owns_socket_4() { return static_cast<int32_t>(offsetof(NetworkStream_t581172200, ___owns_socket_4)); }
	inline bool get_owns_socket_4() const { return ___owns_socket_4; }
	inline bool* get_address_of_owns_socket_4() { return &___owns_socket_4; }
	inline void set_owns_socket_4(bool value)
	{
		___owns_socket_4 = value;
	}

	inline static int32_t get_offset_of_readable_5() { return static_cast<int32_t>(offsetof(NetworkStream_t581172200, ___readable_5)); }
	inline bool get_readable_5() const { return ___readable_5; }
	inline bool* get_address_of_readable_5() { return &___readable_5; }
	inline void set_readable_5(bool value)
	{
		___readable_5 = value;
	}

	inline static int32_t get_offset_of_writeable_6() { return static_cast<int32_t>(offsetof(NetworkStream_t581172200, ___writeable_6)); }
	inline bool get_writeable_6() const { return ___writeable_6; }
	inline bool* get_address_of_writeable_6() { return &___writeable_6; }
	inline void set_writeable_6(bool value)
	{
		___writeable_6 = value;
	}

	inline static int32_t get_offset_of_disposed_7() { return static_cast<int32_t>(offsetof(NetworkStream_t581172200, ___disposed_7)); }
	inline bool get_disposed_7() const { return ___disposed_7; }
	inline bool* get_address_of_disposed_7() { return &___disposed_7; }
	inline void set_disposed_7(bool value)
	{
		___disposed_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
