#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// UnityEngine.Networking.SyncListInt
struct SyncListInt_t3316705628;
// NetData`1<InternationalDraught.InternationalDraught>
struct NetData_1_t592895260;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// InternationalDraught.InternationalDraughtIdentity
struct  InternationalDraughtIdentity_t1853172845  : public DataIdentity_t543951486
{
public:
	// System.UInt64 InternationalDraught.InternationalDraughtIdentity::lastMove
	uint64_t ___lastMove_17;
	// System.Int32 InternationalDraught.InternationalDraughtIdentity::ply
	int32_t ___ply_18;
	// System.Int32 InternationalDraught.InternationalDraughtIdentity::captureSize
	int32_t ___captureSize_19;
	// UnityEngine.Networking.SyncListInt InternationalDraught.InternationalDraughtIdentity::captureSquares
	SyncListInt_t3316705628 * ___captureSquares_20;
	// NetData`1<InternationalDraught.InternationalDraught> InternationalDraught.InternationalDraughtIdentity::netData
	NetData_1_t592895260 * ___netData_21;

public:
	inline static int32_t get_offset_of_lastMove_17() { return static_cast<int32_t>(offsetof(InternationalDraughtIdentity_t1853172845, ___lastMove_17)); }
	inline uint64_t get_lastMove_17() const { return ___lastMove_17; }
	inline uint64_t* get_address_of_lastMove_17() { return &___lastMove_17; }
	inline void set_lastMove_17(uint64_t value)
	{
		___lastMove_17 = value;
	}

	inline static int32_t get_offset_of_ply_18() { return static_cast<int32_t>(offsetof(InternationalDraughtIdentity_t1853172845, ___ply_18)); }
	inline int32_t get_ply_18() const { return ___ply_18; }
	inline int32_t* get_address_of_ply_18() { return &___ply_18; }
	inline void set_ply_18(int32_t value)
	{
		___ply_18 = value;
	}

	inline static int32_t get_offset_of_captureSize_19() { return static_cast<int32_t>(offsetof(InternationalDraughtIdentity_t1853172845, ___captureSize_19)); }
	inline int32_t get_captureSize_19() const { return ___captureSize_19; }
	inline int32_t* get_address_of_captureSize_19() { return &___captureSize_19; }
	inline void set_captureSize_19(int32_t value)
	{
		___captureSize_19 = value;
	}

	inline static int32_t get_offset_of_captureSquares_20() { return static_cast<int32_t>(offsetof(InternationalDraughtIdentity_t1853172845, ___captureSquares_20)); }
	inline SyncListInt_t3316705628 * get_captureSquares_20() const { return ___captureSquares_20; }
	inline SyncListInt_t3316705628 ** get_address_of_captureSquares_20() { return &___captureSquares_20; }
	inline void set_captureSquares_20(SyncListInt_t3316705628 * value)
	{
		___captureSquares_20 = value;
		Il2CppCodeGenWriteBarrier(&___captureSquares_20, value);
	}

	inline static int32_t get_offset_of_netData_21() { return static_cast<int32_t>(offsetof(InternationalDraughtIdentity_t1853172845, ___netData_21)); }
	inline NetData_1_t592895260 * get_netData_21() const { return ___netData_21; }
	inline NetData_1_t592895260 ** get_address_of_netData_21() { return &___netData_21; }
	inline void set_netData_21(NetData_1_t592895260 * value)
	{
		___netData_21 = value;
		Il2CppCodeGenWriteBarrier(&___netData_21, value);
	}
};

struct InternationalDraughtIdentity_t1853172845_StaticFields
{
public:
	// System.Int32 InternationalDraught.InternationalDraughtIdentity::kListcaptureSquares
	int32_t ___kListcaptureSquares_22;

public:
	inline static int32_t get_offset_of_kListcaptureSquares_22() { return static_cast<int32_t>(offsetof(InternationalDraughtIdentity_t1853172845_StaticFields, ___kListcaptureSquares_22)); }
	inline int32_t get_kListcaptureSquares_22() const { return ___kListcaptureSquares_22; }
	inline int32_t* get_address_of_kListcaptureSquares_22() { return &___kListcaptureSquares_22; }
	inline void set_kListcaptureSquares_22(int32_t value)
	{
		___kListcaptureSquares_22 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
