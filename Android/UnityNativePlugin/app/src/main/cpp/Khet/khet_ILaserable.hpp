#ifndef __KHET_ILASERABLE_H__
#define __KHET_ILASERABLE_H__

namespace Khet
{
    // This class is an interface for objects which can be lasered.
    class ILaserable
    {
    public:
        virtual ~ILaserable() {}
        virtual Square Get(int32_t) const = 0;
    };
}

#endif // __ILASERABLE_H__
