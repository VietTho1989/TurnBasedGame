#ifndef __UTILS_H__
#define __UTILS_H__

#include <vector>
#include <string>

// The Utils class implements the singleton pattern.
class Utils
{
public:
	static Utils* GetInstance()
	{
		if (_instance == NULL)
        {
			_instance = new Utils();
        }

		return _instance;
	}

    // Split by character.
	std::vector<std::string> Split(const std::string&, char) const;

    // Split by characters.
	std::vector<std::string> Split(const std::string&, const std::string& delims) const;

private:
	static Utils* _instance;

	Utils();
};

#endif // __UTILS_H__
