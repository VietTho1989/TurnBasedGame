#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Net.WebConnection
struct WebConnection_t324679648;
// System.Net.HttpWebRequest
struct HttpWebRequest_t1951404513;
// System.Threading.ManualResetEvent
struct ManualResetEvent_t926074657;
// System.IO.MemoryStream
struct MemoryStream_t743994179;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.WebConnectionStream
struct  WebConnectionStream_t1922483508  : public Stream_t3255436806
{
public:
	// System.Boolean System.Net.WebConnectionStream::isRead
	bool ___isRead_3;
	// System.Net.WebConnection System.Net.WebConnectionStream::cnc
	WebConnection_t324679648 * ___cnc_4;
	// System.Net.HttpWebRequest System.Net.WebConnectionStream::request
	HttpWebRequest_t1951404513 * ___request_5;
	// System.Byte[] System.Net.WebConnectionStream::readBuffer
	ByteU5BU5D_t3397334013* ___readBuffer_6;
	// System.Int32 System.Net.WebConnectionStream::readBufferOffset
	int32_t ___readBufferOffset_7;
	// System.Int32 System.Net.WebConnectionStream::readBufferSize
	int32_t ___readBufferSize_8;
	// System.Int32 System.Net.WebConnectionStream::contentLength
	int32_t ___contentLength_9;
	// System.Int32 System.Net.WebConnectionStream::totalRead
	int32_t ___totalRead_10;
	// System.Int64 System.Net.WebConnectionStream::totalWritten
	int64_t ___totalWritten_11;
	// System.Boolean System.Net.WebConnectionStream::nextReadCalled
	bool ___nextReadCalled_12;
	// System.Int32 System.Net.WebConnectionStream::pendingReads
	int32_t ___pendingReads_13;
	// System.Int32 System.Net.WebConnectionStream::pendingWrites
	int32_t ___pendingWrites_14;
	// System.Threading.ManualResetEvent System.Net.WebConnectionStream::pending
	ManualResetEvent_t926074657 * ___pending_15;
	// System.Boolean System.Net.WebConnectionStream::allowBuffering
	bool ___allowBuffering_16;
	// System.Boolean System.Net.WebConnectionStream::sendChunked
	bool ___sendChunked_17;
	// System.IO.MemoryStream System.Net.WebConnectionStream::writeBuffer
	MemoryStream_t743994179 * ___writeBuffer_18;
	// System.Boolean System.Net.WebConnectionStream::requestWritten
	bool ___requestWritten_19;
	// System.Byte[] System.Net.WebConnectionStream::headers
	ByteU5BU5D_t3397334013* ___headers_20;
	// System.Boolean System.Net.WebConnectionStream::disposed
	bool ___disposed_21;
	// System.Boolean System.Net.WebConnectionStream::headersSent
	bool ___headersSent_22;
	// System.Object System.Net.WebConnectionStream::locker
	Il2CppObject * ___locker_23;
	// System.Boolean System.Net.WebConnectionStream::initRead
	bool ___initRead_24;
	// System.Boolean System.Net.WebConnectionStream::read_eof
	bool ___read_eof_25;
	// System.Boolean System.Net.WebConnectionStream::complete_request_written
	bool ___complete_request_written_26;
	// System.Int32 System.Net.WebConnectionStream::read_timeout
	int32_t ___read_timeout_27;
	// System.Int32 System.Net.WebConnectionStream::write_timeout
	int32_t ___write_timeout_28;

public:
	inline static int32_t get_offset_of_isRead_3() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___isRead_3)); }
	inline bool get_isRead_3() const { return ___isRead_3; }
	inline bool* get_address_of_isRead_3() { return &___isRead_3; }
	inline void set_isRead_3(bool value)
	{
		___isRead_3 = value;
	}

	inline static int32_t get_offset_of_cnc_4() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___cnc_4)); }
	inline WebConnection_t324679648 * get_cnc_4() const { return ___cnc_4; }
	inline WebConnection_t324679648 ** get_address_of_cnc_4() { return &___cnc_4; }
	inline void set_cnc_4(WebConnection_t324679648 * value)
	{
		___cnc_4 = value;
		Il2CppCodeGenWriteBarrier(&___cnc_4, value);
	}

	inline static int32_t get_offset_of_request_5() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___request_5)); }
	inline HttpWebRequest_t1951404513 * get_request_5() const { return ___request_5; }
	inline HttpWebRequest_t1951404513 ** get_address_of_request_5() { return &___request_5; }
	inline void set_request_5(HttpWebRequest_t1951404513 * value)
	{
		___request_5 = value;
		Il2CppCodeGenWriteBarrier(&___request_5, value);
	}

	inline static int32_t get_offset_of_readBuffer_6() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___readBuffer_6)); }
	inline ByteU5BU5D_t3397334013* get_readBuffer_6() const { return ___readBuffer_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_readBuffer_6() { return &___readBuffer_6; }
	inline void set_readBuffer_6(ByteU5BU5D_t3397334013* value)
	{
		___readBuffer_6 = value;
		Il2CppCodeGenWriteBarrier(&___readBuffer_6, value);
	}

	inline static int32_t get_offset_of_readBufferOffset_7() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___readBufferOffset_7)); }
	inline int32_t get_readBufferOffset_7() const { return ___readBufferOffset_7; }
	inline int32_t* get_address_of_readBufferOffset_7() { return &___readBufferOffset_7; }
	inline void set_readBufferOffset_7(int32_t value)
	{
		___readBufferOffset_7 = value;
	}

	inline static int32_t get_offset_of_readBufferSize_8() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___readBufferSize_8)); }
	inline int32_t get_readBufferSize_8() const { return ___readBufferSize_8; }
	inline int32_t* get_address_of_readBufferSize_8() { return &___readBufferSize_8; }
	inline void set_readBufferSize_8(int32_t value)
	{
		___readBufferSize_8 = value;
	}

	inline static int32_t get_offset_of_contentLength_9() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___contentLength_9)); }
	inline int32_t get_contentLength_9() const { return ___contentLength_9; }
	inline int32_t* get_address_of_contentLength_9() { return &___contentLength_9; }
	inline void set_contentLength_9(int32_t value)
	{
		___contentLength_9 = value;
	}

	inline static int32_t get_offset_of_totalRead_10() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___totalRead_10)); }
	inline int32_t get_totalRead_10() const { return ___totalRead_10; }
	inline int32_t* get_address_of_totalRead_10() { return &___totalRead_10; }
	inline void set_totalRead_10(int32_t value)
	{
		___totalRead_10 = value;
	}

	inline static int32_t get_offset_of_totalWritten_11() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___totalWritten_11)); }
	inline int64_t get_totalWritten_11() const { return ___totalWritten_11; }
	inline int64_t* get_address_of_totalWritten_11() { return &___totalWritten_11; }
	inline void set_totalWritten_11(int64_t value)
	{
		___totalWritten_11 = value;
	}

	inline static int32_t get_offset_of_nextReadCalled_12() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___nextReadCalled_12)); }
	inline bool get_nextReadCalled_12() const { return ___nextReadCalled_12; }
	inline bool* get_address_of_nextReadCalled_12() { return &___nextReadCalled_12; }
	inline void set_nextReadCalled_12(bool value)
	{
		___nextReadCalled_12 = value;
	}

	inline static int32_t get_offset_of_pendingReads_13() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___pendingReads_13)); }
	inline int32_t get_pendingReads_13() const { return ___pendingReads_13; }
	inline int32_t* get_address_of_pendingReads_13() { return &___pendingReads_13; }
	inline void set_pendingReads_13(int32_t value)
	{
		___pendingReads_13 = value;
	}

	inline static int32_t get_offset_of_pendingWrites_14() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___pendingWrites_14)); }
	inline int32_t get_pendingWrites_14() const { return ___pendingWrites_14; }
	inline int32_t* get_address_of_pendingWrites_14() { return &___pendingWrites_14; }
	inline void set_pendingWrites_14(int32_t value)
	{
		___pendingWrites_14 = value;
	}

	inline static int32_t get_offset_of_pending_15() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___pending_15)); }
	inline ManualResetEvent_t926074657 * get_pending_15() const { return ___pending_15; }
	inline ManualResetEvent_t926074657 ** get_address_of_pending_15() { return &___pending_15; }
	inline void set_pending_15(ManualResetEvent_t926074657 * value)
	{
		___pending_15 = value;
		Il2CppCodeGenWriteBarrier(&___pending_15, value);
	}

	inline static int32_t get_offset_of_allowBuffering_16() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___allowBuffering_16)); }
	inline bool get_allowBuffering_16() const { return ___allowBuffering_16; }
	inline bool* get_address_of_allowBuffering_16() { return &___allowBuffering_16; }
	inline void set_allowBuffering_16(bool value)
	{
		___allowBuffering_16 = value;
	}

	inline static int32_t get_offset_of_sendChunked_17() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___sendChunked_17)); }
	inline bool get_sendChunked_17() const { return ___sendChunked_17; }
	inline bool* get_address_of_sendChunked_17() { return &___sendChunked_17; }
	inline void set_sendChunked_17(bool value)
	{
		___sendChunked_17 = value;
	}

	inline static int32_t get_offset_of_writeBuffer_18() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___writeBuffer_18)); }
	inline MemoryStream_t743994179 * get_writeBuffer_18() const { return ___writeBuffer_18; }
	inline MemoryStream_t743994179 ** get_address_of_writeBuffer_18() { return &___writeBuffer_18; }
	inline void set_writeBuffer_18(MemoryStream_t743994179 * value)
	{
		___writeBuffer_18 = value;
		Il2CppCodeGenWriteBarrier(&___writeBuffer_18, value);
	}

	inline static int32_t get_offset_of_requestWritten_19() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___requestWritten_19)); }
	inline bool get_requestWritten_19() const { return ___requestWritten_19; }
	inline bool* get_address_of_requestWritten_19() { return &___requestWritten_19; }
	inline void set_requestWritten_19(bool value)
	{
		___requestWritten_19 = value;
	}

	inline static int32_t get_offset_of_headers_20() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___headers_20)); }
	inline ByteU5BU5D_t3397334013* get_headers_20() const { return ___headers_20; }
	inline ByteU5BU5D_t3397334013** get_address_of_headers_20() { return &___headers_20; }
	inline void set_headers_20(ByteU5BU5D_t3397334013* value)
	{
		___headers_20 = value;
		Il2CppCodeGenWriteBarrier(&___headers_20, value);
	}

	inline static int32_t get_offset_of_disposed_21() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___disposed_21)); }
	inline bool get_disposed_21() const { return ___disposed_21; }
	inline bool* get_address_of_disposed_21() { return &___disposed_21; }
	inline void set_disposed_21(bool value)
	{
		___disposed_21 = value;
	}

	inline static int32_t get_offset_of_headersSent_22() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___headersSent_22)); }
	inline bool get_headersSent_22() const { return ___headersSent_22; }
	inline bool* get_address_of_headersSent_22() { return &___headersSent_22; }
	inline void set_headersSent_22(bool value)
	{
		___headersSent_22 = value;
	}

	inline static int32_t get_offset_of_locker_23() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___locker_23)); }
	inline Il2CppObject * get_locker_23() const { return ___locker_23; }
	inline Il2CppObject ** get_address_of_locker_23() { return &___locker_23; }
	inline void set_locker_23(Il2CppObject * value)
	{
		___locker_23 = value;
		Il2CppCodeGenWriteBarrier(&___locker_23, value);
	}

	inline static int32_t get_offset_of_initRead_24() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___initRead_24)); }
	inline bool get_initRead_24() const { return ___initRead_24; }
	inline bool* get_address_of_initRead_24() { return &___initRead_24; }
	inline void set_initRead_24(bool value)
	{
		___initRead_24 = value;
	}

	inline static int32_t get_offset_of_read_eof_25() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___read_eof_25)); }
	inline bool get_read_eof_25() const { return ___read_eof_25; }
	inline bool* get_address_of_read_eof_25() { return &___read_eof_25; }
	inline void set_read_eof_25(bool value)
	{
		___read_eof_25 = value;
	}

	inline static int32_t get_offset_of_complete_request_written_26() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___complete_request_written_26)); }
	inline bool get_complete_request_written_26() const { return ___complete_request_written_26; }
	inline bool* get_address_of_complete_request_written_26() { return &___complete_request_written_26; }
	inline void set_complete_request_written_26(bool value)
	{
		___complete_request_written_26 = value;
	}

	inline static int32_t get_offset_of_read_timeout_27() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___read_timeout_27)); }
	inline int32_t get_read_timeout_27() const { return ___read_timeout_27; }
	inline int32_t* get_address_of_read_timeout_27() { return &___read_timeout_27; }
	inline void set_read_timeout_27(int32_t value)
	{
		___read_timeout_27 = value;
	}

	inline static int32_t get_offset_of_write_timeout_28() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508, ___write_timeout_28)); }
	inline int32_t get_write_timeout_28() const { return ___write_timeout_28; }
	inline int32_t* get_address_of_write_timeout_28() { return &___write_timeout_28; }
	inline void set_write_timeout_28(int32_t value)
	{
		___write_timeout_28 = value;
	}
};

struct WebConnectionStream_t1922483508_StaticFields
{
public:
	// System.Byte[] System.Net.WebConnectionStream::crlf
	ByteU5BU5D_t3397334013* ___crlf_2;

public:
	inline static int32_t get_offset_of_crlf_2() { return static_cast<int32_t>(offsetof(WebConnectionStream_t1922483508_StaticFields, ___crlf_2)); }
	inline ByteU5BU5D_t3397334013* get_crlf_2() const { return ___crlf_2; }
	inline ByteU5BU5D_t3397334013** get_address_of_crlf_2() { return &___crlf_2; }
	inline void set_crlf_2(ByteU5BU5D_t3397334013* value)
	{
		___crlf_2 = value;
		Il2CppCodeGenWriteBarrier(&___crlf_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
