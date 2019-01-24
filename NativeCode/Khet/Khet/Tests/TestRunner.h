#ifndef __TEST_RUNNER_H__
#define __TEST_RUNNER_H__

#include "../Utils.h"
#include <cctype>
#include <iostream>
#include <fstream>
#include <string>

// Runs the tests.
class TestRunner
{
public:
    // Execute the tests of the specified type.
    template<typename TestType>
    void RunTests() const
    {
        auto test = TestType();
        std::string testsPath = test.TestFileName();
        
        // Parse the tests file and process the test cases.
        // Need to adjust path as we will be executing from the directory above.
        std::ifstream file("Tests/" + testsPath);
        std::string line;
        bool pass = true;
        auto utils = Utils::GetInstance();
        while (std::getline(file, line) && pass)
        {
            std::cout << line << std::endl;
            if (IsTestCase(line))
            {
                pass = test.Run(utils->Split(line, ' '));
                std::cout << (pass ? "PASS" : "FAIL") << std::endl;
            }
        }
    }

private:
    // Ensure that the line isn't empty or a comment.
    bool IsTestCase(const std::string& line) const
    {
        return line[0] != '#' && !IsWhiteSpace(line);
    }

    // Check whether the line is entirely white space.
    bool IsWhiteSpace(const std::string& line) const
    {
        bool whiteSpace = true;
        for (size_t i = 0; i < line.size() && whiteSpace; i++)
            whiteSpace = isspace(line[i]);

        return whiteSpace;
    }
};

#endif // __TEST_RUNNER_H__

