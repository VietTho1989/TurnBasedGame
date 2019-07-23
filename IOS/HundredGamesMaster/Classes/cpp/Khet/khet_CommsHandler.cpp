#include "khet_CommsHandler.hpp"
#include "khet_MoveHelpers.hpp"
#include "khet_Utils.hpp"
#include "khet_Types.hpp"
#include <cassert>
#include <iostream>

namespace Khet
{
    CommsHandler::~CommsHandler()
    {
        _table.Clear();
        ClearBoard();
    }
    
    bool CommsHandler::Process(const std::string& message)
    {
        bool alive = true;
        
        auto tokens = Utils::GetInstance()->Split(message, ' ');
        std::string messageType = tokens[0];
        if (messageType == "newgame")
        {
            _calculator.Stop();
            _table.Clear();
            ClearBoard();
        }
        else if (messageType == "position")
        {
            ClearBoard();
            _board = CreatePosition(tokens);
        }
        else if (messageType == "go")
        {
            // assert(_board != nullptr);
            if(_board == nullptr){
                printf("error, assert(_board != nullptr)\n");
                return false;
            }
            SearchParams* params = CreateSearchParameters(tokens);
            _table.Age();
            _calculator.Start(_table, *params, *_board);
            delete params;
        }
        else if (messageType == "stop")
        {
            _calculator.Stop();
        }
        else if (messageType == "quit")
        {
            _calculator.Stop();
            alive = false;
        }
        else
        {
            std::cout << "info string " << "Unrecognised message type: " << message << std::endl;
        }
        
        return alive;
    }
    
    void CommsHandler::ClearBoard()
    {
        if (_board != nullptr)
        {
            delete _board;
            _board = nullptr;
        }
    }
    
    Board* CommsHandler::CreatePosition(const std::vector<std::string>& tokens) const
    {
        // assert(tokens.size() > 1);
        if(tokens.size() <= 1){
            printf("error, assert(tokens.size() > 1)\n");
            return nullptr;
        }
        Board* board = nullptr;
        size_t movesIndex = 2;
        if (tokens[1] == "standard")
            board = new Board(Standard);
        else if (tokens[1] == "dynasty")
            board = new Board(Dynasty);
        else if (tokens[1] == "imhotep")
            board = new Board(Imhotep);
        else
        {
            // It's a Khet string.
            std::string ks = tokens[1] + " " + tokens[2];
            board = new Board(ks);
            movesIndex = 3;
        }
        
        // Apply the moves that have been specified.
        Move move = NoMove;
        for (size_t i = movesIndex; i < tokens.size(); i++)
        {
            move = MakeMove(tokens[i]);
            board->MakeMove(move);
        }
        
        return board;
    }
    
    SearchParams* CommsHandler::CreateSearchParameters(const std::vector<std::string>& tokens) const
    {
        // assert(tokens.size() > 1);
        if(tokens.size() <= 1){
            printf("error, assert(tokens.size() > 1)\n");
            return nullptr;
        }
        SearchParams* params = new SearchParams();
        std::string paramType = tokens[1];
        if (paramType == "infinite")
        {
            params->Infinite(true);
        }
        else
        {
            // assert(tokens.size() == 3);
            if(tokens.size() != 3){
                printf("error, assert(tokens.size() == 3)\n");
                return params;
            }
            int32_t val = stoi(tokens[2]);
            if (paramType == "movetime")
            {
                params->MoveTime(val);
            }
            else if (paramType == "depth")
            {
                params->Depth(val);
            }
        }
        
        return params;
    }
}
