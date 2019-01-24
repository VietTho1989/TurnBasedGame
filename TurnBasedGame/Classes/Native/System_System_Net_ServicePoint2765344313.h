#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_DateTime693205669.h"

// System.Uri
struct Uri_t19570940;
// System.Version
struct Version_t1755874712;
// System.Security.Cryptography.X509Certificates.X509Certificate
struct X509Certificate_t283079845;
// System.Net.IPHostEntry
struct IPHostEntry_t994738509;
// System.Collections.Hashtable
struct Hashtable_t909839986;
// System.Object
struct Il2CppObject;
// System.Net.BindIPEndPoint
struct BindIPEndPoint_t635820671;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.ServicePoint
struct  ServicePoint_t2765344313  : public Il2CppObject
{
public:
	// System.Uri System.Net.ServicePoint::uri
	Uri_t19570940 * ___uri_0;
	// System.Int32 System.Net.ServicePoint::connectionLimit
	int32_t ___connectionLimit_1;
	// System.Int32 System.Net.ServicePoint::maxIdleTime
	int32_t ___maxIdleTime_2;
	// System.Int32 System.Net.ServicePoint::currentConnections
	int32_t ___currentConnections_3;
	// System.DateTime System.Net.ServicePoint::idleSince
	DateTime_t693205669  ___idleSince_4;
	// System.Version System.Net.ServicePoint::protocolVersion
	Version_t1755874712 * ___protocolVersion_5;
	// System.Security.Cryptography.X509Certificates.X509Certificate System.Net.ServicePoint::certificate
	X509Certificate_t283079845 * ___certificate_6;
	// System.Security.Cryptography.X509Certificates.X509Certificate System.Net.ServicePoint::clientCertificate
	X509Certificate_t283079845 * ___clientCertificate_7;
	// System.Net.IPHostEntry System.Net.ServicePoint::host
	IPHostEntry_t994738509 * ___host_8;
	// System.Boolean System.Net.ServicePoint::usesProxy
	bool ___usesProxy_9;
	// System.Collections.Hashtable System.Net.ServicePoint::groups
	Hashtable_t909839986 * ___groups_10;
	// System.Boolean System.Net.ServicePoint::sendContinue
	bool ___sendContinue_11;
	// System.Boolean System.Net.ServicePoint::useConnect
	bool ___useConnect_12;
	// System.Object System.Net.ServicePoint::locker
	Il2CppObject * ___locker_13;
	// System.Object System.Net.ServicePoint::hostE
	Il2CppObject * ___hostE_14;
	// System.Boolean System.Net.ServicePoint::useNagle
	bool ___useNagle_15;
	// System.Net.BindIPEndPoint System.Net.ServicePoint::endPointCallback
	BindIPEndPoint_t635820671 * ___endPointCallback_16;

public:
	inline static int32_t get_offset_of_uri_0() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___uri_0)); }
	inline Uri_t19570940 * get_uri_0() const { return ___uri_0; }
	inline Uri_t19570940 ** get_address_of_uri_0() { return &___uri_0; }
	inline void set_uri_0(Uri_t19570940 * value)
	{
		___uri_0 = value;
		Il2CppCodeGenWriteBarrier(&___uri_0, value);
	}

	inline static int32_t get_offset_of_connectionLimit_1() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___connectionLimit_1)); }
	inline int32_t get_connectionLimit_1() const { return ___connectionLimit_1; }
	inline int32_t* get_address_of_connectionLimit_1() { return &___connectionLimit_1; }
	inline void set_connectionLimit_1(int32_t value)
	{
		___connectionLimit_1 = value;
	}

	inline static int32_t get_offset_of_maxIdleTime_2() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___maxIdleTime_2)); }
	inline int32_t get_maxIdleTime_2() const { return ___maxIdleTime_2; }
	inline int32_t* get_address_of_maxIdleTime_2() { return &___maxIdleTime_2; }
	inline void set_maxIdleTime_2(int32_t value)
	{
		___maxIdleTime_2 = value;
	}

	inline static int32_t get_offset_of_currentConnections_3() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___currentConnections_3)); }
	inline int32_t get_currentConnections_3() const { return ___currentConnections_3; }
	inline int32_t* get_address_of_currentConnections_3() { return &___currentConnections_3; }
	inline void set_currentConnections_3(int32_t value)
	{
		___currentConnections_3 = value;
	}

	inline static int32_t get_offset_of_idleSince_4() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___idleSince_4)); }
	inline DateTime_t693205669  get_idleSince_4() const { return ___idleSince_4; }
	inline DateTime_t693205669 * get_address_of_idleSince_4() { return &___idleSince_4; }
	inline void set_idleSince_4(DateTime_t693205669  value)
	{
		___idleSince_4 = value;
	}

	inline static int32_t get_offset_of_protocolVersion_5() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___protocolVersion_5)); }
	inline Version_t1755874712 * get_protocolVersion_5() const { return ___protocolVersion_5; }
	inline Version_t1755874712 ** get_address_of_protocolVersion_5() { return &___protocolVersion_5; }
	inline void set_protocolVersion_5(Version_t1755874712 * value)
	{
		___protocolVersion_5 = value;
		Il2CppCodeGenWriteBarrier(&___protocolVersion_5, value);
	}

	inline static int32_t get_offset_of_certificate_6() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___certificate_6)); }
	inline X509Certificate_t283079845 * get_certificate_6() const { return ___certificate_6; }
	inline X509Certificate_t283079845 ** get_address_of_certificate_6() { return &___certificate_6; }
	inline void set_certificate_6(X509Certificate_t283079845 * value)
	{
		___certificate_6 = value;
		Il2CppCodeGenWriteBarrier(&___certificate_6, value);
	}

	inline static int32_t get_offset_of_clientCertificate_7() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___clientCertificate_7)); }
	inline X509Certificate_t283079845 * get_clientCertificate_7() const { return ___clientCertificate_7; }
	inline X509Certificate_t283079845 ** get_address_of_clientCertificate_7() { return &___clientCertificate_7; }
	inline void set_clientCertificate_7(X509Certificate_t283079845 * value)
	{
		___clientCertificate_7 = value;
		Il2CppCodeGenWriteBarrier(&___clientCertificate_7, value);
	}

	inline static int32_t get_offset_of_host_8() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___host_8)); }
	inline IPHostEntry_t994738509 * get_host_8() const { return ___host_8; }
	inline IPHostEntry_t994738509 ** get_address_of_host_8() { return &___host_8; }
	inline void set_host_8(IPHostEntry_t994738509 * value)
	{
		___host_8 = value;
		Il2CppCodeGenWriteBarrier(&___host_8, value);
	}

	inline static int32_t get_offset_of_usesProxy_9() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___usesProxy_9)); }
	inline bool get_usesProxy_9() const { return ___usesProxy_9; }
	inline bool* get_address_of_usesProxy_9() { return &___usesProxy_9; }
	inline void set_usesProxy_9(bool value)
	{
		___usesProxy_9 = value;
	}

	inline static int32_t get_offset_of_groups_10() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___groups_10)); }
	inline Hashtable_t909839986 * get_groups_10() const { return ___groups_10; }
	inline Hashtable_t909839986 ** get_address_of_groups_10() { return &___groups_10; }
	inline void set_groups_10(Hashtable_t909839986 * value)
	{
		___groups_10 = value;
		Il2CppCodeGenWriteBarrier(&___groups_10, value);
	}

	inline static int32_t get_offset_of_sendContinue_11() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___sendContinue_11)); }
	inline bool get_sendContinue_11() const { return ___sendContinue_11; }
	inline bool* get_address_of_sendContinue_11() { return &___sendContinue_11; }
	inline void set_sendContinue_11(bool value)
	{
		___sendContinue_11 = value;
	}

	inline static int32_t get_offset_of_useConnect_12() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___useConnect_12)); }
	inline bool get_useConnect_12() const { return ___useConnect_12; }
	inline bool* get_address_of_useConnect_12() { return &___useConnect_12; }
	inline void set_useConnect_12(bool value)
	{
		___useConnect_12 = value;
	}

	inline static int32_t get_offset_of_locker_13() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___locker_13)); }
	inline Il2CppObject * get_locker_13() const { return ___locker_13; }
	inline Il2CppObject ** get_address_of_locker_13() { return &___locker_13; }
	inline void set_locker_13(Il2CppObject * value)
	{
		___locker_13 = value;
		Il2CppCodeGenWriteBarrier(&___locker_13, value);
	}

	inline static int32_t get_offset_of_hostE_14() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___hostE_14)); }
	inline Il2CppObject * get_hostE_14() const { return ___hostE_14; }
	inline Il2CppObject ** get_address_of_hostE_14() { return &___hostE_14; }
	inline void set_hostE_14(Il2CppObject * value)
	{
		___hostE_14 = value;
		Il2CppCodeGenWriteBarrier(&___hostE_14, value);
	}

	inline static int32_t get_offset_of_useNagle_15() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___useNagle_15)); }
	inline bool get_useNagle_15() const { return ___useNagle_15; }
	inline bool* get_address_of_useNagle_15() { return &___useNagle_15; }
	inline void set_useNagle_15(bool value)
	{
		___useNagle_15 = value;
	}

	inline static int32_t get_offset_of_endPointCallback_16() { return static_cast<int32_t>(offsetof(ServicePoint_t2765344313, ___endPointCallback_16)); }
	inline BindIPEndPoint_t635820671 * get_endPointCallback_16() const { return ___endPointCallback_16; }
	inline BindIPEndPoint_t635820671 ** get_address_of_endPointCallback_16() { return &___endPointCallback_16; }
	inline void set_endPointCallback_16(BindIPEndPoint_t635820671 * value)
	{
		___endPointCallback_16 = value;
		Il2CppCodeGenWriteBarrier(&___endPointCallback_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
