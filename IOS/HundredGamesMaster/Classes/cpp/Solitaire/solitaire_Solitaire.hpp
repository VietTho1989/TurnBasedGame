#ifndef Solitaire_Solitaire_h
#define Solitaire_Solitaire_h
#include <string>
#include <stack>
#include <memory>
#include <mutex>
#include "solitaire_Move.hpp"
#include "solitaire_Card.hpp"
#include "solitaire_Pile.hpp"
#include "solitaire_HashMap.hpp"
using namespace std;


namespace Solitaire
{
    
    enum SolveResult
    {
        CouldNotComplete = -2,
        SolvedMayNotBeMinimal = -1,
        Impossible = 0,
        SolvedMinimal = 1
    };
    
    class Solitaire {
        
    public:
        Move movesMade[512];
        int32_t movesMadeCount;
        
        Pile piles[13];
        Card cards[52];
        
        int32_t movesAvailableCount;
        Move movesAvailable[32];
        
        int32_t drawCount;
        int32_t roundCount;
        int32_t foundationCount;
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t getByteSize();
        
        static int32_t convertToByteArray(Solitaire* solitaire, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Solitaire* solitaire, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
        int32_t FoundationMin();
        int32_t GetTalonCards(Card talon[], int talonMoves[]);
    public:
        void Initialize();
        int Shuffle1(int32_t dealNumber = -1);
        void Shuffle2(int32_t dealNumber);
        void ResetGame();
        void ResetGame(int32_t drawCount);
        void UpdateAvailableMoves();
        void MakeAutoMoves();
        void MakeMove(Move move);
        void MakeMove(int32_t index);
        void UndoMove();
        SolveResult SolveMinimalMultithreaded(int32_t numThreads, int32_t maxClosedCount);
        SolveResult SolveMinimal(int32_t maxClosedCount);
        SolveResult SolveFast(int32_t maxClosedCount, int32_t twoShift, int32_t threeShift);
        SolveResult SolveRandom(int32_t numberOfTimesToPlay, int32_t solutionsToFind);
        int32_t MovesAvailableCount();
        int32_t MovesMadeCount();
        int32_t MovesMadeNormalizedCount();
        int32_t FoundationCount();
        int32_t RoundCount();
        int32_t DrawCount();
        int32_t MovesAdded(Move const& move);
        int32_t MinimumMovesLeft();
        void SetDrawCount(int32_t drawCount);
        HashKey GameState();
        string GetMoveInfo(Move move);
        bool LoadSolitaire(string const& cardSet);
        string GetSolitaire();
        bool LoadPysol(string const& cardSet);
        string GetPysol();
        Move GetMoveAvailable(int32_t index);
        Move GetMoveMade(int32_t index);
        string GameDiagram();
        string GameDiagramPysol();
        string MovesMade();
        string MovesAvailable();
        Move operator[](int32_t index);
        
    };
    
    class SolitaireWorker {
    private:
        stack<shared_ptr<MoveNode>> open[512];
        Move bestSolution[512];
        Solitaire * solitaire;
        mutex mtx;
        int32_t openCount, maxFoundationCount, bestSolutionMoveCount, startMoves, maxClosedCount;
        
        void RunMinimalWorker(void * closed);
        void RunFastWorker();
    public:
        SolitaireWorker(Solitaire & solitaire, int32_t maxClosedCount);
        
        SolveResult Run(int32_t numThreads);
    };
    
}

#endif
