#ifndef __TEST_BASE_H__
#define __TEST_BASE_H__

#include <vector>
#include <string>

// Base class for test types.
class TestBase
{
public:
    virtual std::string TestFileName() const = 0;

    // Execute test based on the given tokens.
    virtual bool Run(const std::vector<std::string>&) = 0;
};

#endif // __TEST_BASE_H__

