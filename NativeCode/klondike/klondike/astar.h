//
//  astar.h
//  klondike
//
//  Created by Viet Tho on 12/1/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef ASTAR
#define ASTAR

#include <queue>
#include <vector>
#include <functional>
#include <unordered_set>
#include <chrono>

namespace astar {
    
    template <bool, class M>
    struct MoveTypeRef {
        M move;
        MoveTypeRef(const M* copy) : move(copy == nullptr ? M() : *copy) {}
        inline operator const M*() const { return &move; }
    };
    
    template <class M>
    struct MoveTypeRef<true, M> {
        const M* move;
        MoveTypeRef(const M* copy) : move(copy) {}
        inline operator const M*() const { return move; }
    };
    
    template <class T> class SearchNode {
        
    public:
        typedef decltype(((T*)nullptr)->getLastMove()) MoveType;
        
    private:
        typedef MoveTypeRef<(sizeof(MoveType) > sizeof(MoveType*)), MoveType> MoveTypeRefImpl;
        const T* state;
        unsigned pathCost;
        unsigned heuristic;
        mutable std::vector<T> cachedSuccessors;
        MoveTypeRefImpl initialMove;
        
    public:
        SearchNode() : state(nullptr), pathCost(0), heuristic(0), initialMove(nullptr) {}
        SearchNode(const T& state, unsigned pathCost, unsigned heuristic, const MoveType* initialMove = nullptr) : state(&state), pathCost(pathCost), heuristic(heuristic), initialMove(initialMove) {}
        SearchNode(const SearchNode<T>& copy) : state(copy.state), pathCost(copy.pathCost), heuristic(copy.heuristic), cachedSuccessors(copy.cachedSuccessors), initialMove(copy.initialMove) {}
        SearchNode(SearchNode<T>&& move) : state(move.state), pathCost(move.pathCost), heuristic(move.heuristic), cachedSuccessors(std::move(move.cachedSuccessors)), initialMove(std::move(move.initialMove)) {}
        ~SearchNode() {}
        
        SearchNode& operator=(const SearchNode<T>& copy) {
            state = copy.state;
            pathCost = copy.pathCost;
            heuristic = copy.heuristic;
            cachedSuccessors = copy.cachedSuccessors;
            initialMove = copy.initialMove;
            return *this;
        }
        
        SearchNode& operator=(SearchNode<T>&& move) {
            state = move.state;
            pathCost = move.pathCost;
            heuristic = move.heuristic;
            cachedSuccessors = std::move(move.cachedSuccessors);
            initialMove = std::move(move.initialMove);
            return *this;
        }
        
        inline operator bool() const { return state != nullptr; }
        
        inline const MoveType* getInitialMove() const {
            return initialMove;
        }
        
        inline const bool isInitialMoveDeal() const {
            return initialMove;
        }
        
        inline const T& getState() const { return *state; }
        inline unsigned getPathCost() const { return pathCost; }
        inline unsigned getHeuristic() const { return heuristic; }
        inline unsigned getFCost() const { return getPathCost() + getHeuristic(); }
        inline const std::vector<T>& getSuccessors() const {
            if(cachedSuccessors.empty()) {
                cachedSuccessors = getState().successors();
            }
            return cachedSuccessors;
        }
    };
    
    template <class T>
    inline bool nodeComparator(const SearchNode<T>& lhs, const SearchNode<T>& rhs) {
        return lhs.getFCost() < rhs.getFCost();
    }
    
    template <class T, class H>
    class AStar {
    private:
        typedef std::priority_queue<SearchNode<T>, std::vector<SearchNode<T>>, std::function<bool(const SearchNode<T>&,const SearchNode<T>&)>> QueueType;
        QueueType queue;
        H heuristic;
        std::unordered_set<T> history;
        size_t nodesExpanded;
        unsigned depthLimit;
    public:
        typedef decltype(((T*)nullptr)->getLastMove()) MoveType;
    private:
        std::vector<MoveType> initialMoves;
    public:
        AStar(const T& initialState, const H& heuristic, unsigned depthLimit = 0) : queue(&nodeComparator<T>), heuristic(heuristic), nodesExpanded(0), depthLimit(depthLimit) {
            const T& h = *history.insert(initialState).first;
            queue.emplace(h, 0, heuristic(initialState));
        }
        AStar(T&& initialState, const H& heuristic, unsigned depthLimit = 0) : queue(&nodeComparator<T>), heuristic(heuristic), nodesExpanded(0), depthLimit(depthLimit) {
            const T& h = *history.insert(initialState).first;
            queue.emplace(h, 0, heuristic(initialState));
        }
        void setHistory(const std::unordered_set<T>& existingHistory) {
            history = existingHistory;
        }
        const SearchNode<T>& top() const {
            return queue.top();
        }
        inline bool isDone() const {
            return queue.empty() || queue.top().getSuccessors().empty();
        }
        
        inline size_t getNodesExpanded() const { return nodesExpanded; }
        inline size_t getQueueSize() const { return queue.size(); }
        
        SearchNode<T> step() {
            if(queue.empty()) {
                throw std::runtime_error("There are no more states to search!");
            }
            SearchNode<T> next = queue.top();
            bool isFirstExpansion = nodesExpanded++ == 0;
            queue.pop();
            if(isFirstExpansion || depthLimit == 0 || next.getPathCost() < depthLimit) {
                for(const T& successor : next.getSuccessors()) {
                    if(history.find(successor) == history.end()) {
                        const T& h = *history.insert(successor).first;
                        if(isFirstExpansion) {
                            initialMoves.push_back(h.getLastMove());
                        }
                        queue.emplace(h, next.getPathCost() + 1, heuristic(successor), isFirstExpansion ? &initialMoves.back() : next.getInitialMove());
                    }
                }
            }
            return next;
        }
        
        SearchNode<T> solve(const std::function<bool(const SearchNode<T>&)>& callback = [](const SearchNode<T>&) { return true; }) {
            SearchNode<T> best;
            bool bestSet = false;
            bool first = true;
            for(;;) {
                SearchNode<T> next = step();
                // printf("next\n");
                if(!callback(next)) {
                    // printf("error, why return next here\n");
                    return SearchNode<T>();
                }
                if(next.getState().isWin()) {
                    // printf("correct, return win\n");
                    return next;
                } else if(!first && (next.getPathCost() >= depthLimit || !bestSet || next.getFCost() < best.getFCost())) {
                    // printf("best is next\n");
                    best = next;
                    bestSet = true;
                }
                if(queue.empty()) {
                    // printf("queue empty\n");
                    return first ? next : best;
                }else{
                    // TODO Test
                    /*if(first && !bestSet){
                        printf("queue not empty\n");
                        best = next;
                    }*/
                }
                first = false;
            }
            // TODO Test
            if(!bestSet){
                printf("error, why not best set\n");
            }
        }
    };
    
    template <class T, class H> class IDAStar {
        
        const T& initialState;
        H heuristic;
        const std::unordered_set<T>& history;
        
    public:
        IDAStar(const T& initialState, H heuristic, const std::unordered_set<T>& history) : initialState(initialState), heuristic(heuristic), history(history) {}
        
        bool isDone() const {
            return AStar<T,H>(initialState, heuristic, 0).isDone();
        }
        
        SearchNode<T> solve(std::chrono::milliseconds timeLimit, unsigned initialDepth = 1, const std::function<bool(const SearchNode<T>&, const AStar<T,H>&, unsigned)>& callback = [](const SearchNode<T>&) { return true; }) {
            auto startTime = std::chrono::system_clock::now().time_since_epoch();
            SearchNode<T> bestResult;
            if(initialDepth < 1) {
                initialDepth = 1;
            }
            for(unsigned depth=initialDepth;; ++depth) {
                AStar<T,H> as(initialState, heuristic, depth);
                if(as.isDone()) {
                    break;
                }
                as.setHistory(history);
                if(SearchNode<T> newBest = as.solve([&callback,startTime,timeLimit,&as,depth](const SearchNode<T>& node)->bool{
                    auto timeElapsed = std::chrono::system_clock::now().time_since_epoch() - startTime;
                    if(timeElapsed >= timeLimit) {
                        return false;
                    } else {
                        return callback(node, as, depth);
                    }
                })) {
                    // printf("set new best\n");
                    Move initialMove = *newBest.getInitialMove();
                    if (initialMove.type == MoveType::DEAL) {
                        printf("error, assert(initialMove.type != MoveType::DEAL)\n");
                    } else{
                         bestResult = newBest;
                    }
                } else {
                    break;
                }
            }
            // printf("return bestResult\n");
            if(!bestResult){
                printf("Cannot find any solution\n");
            }
            // printf("isGameFinish: %d\n", isGameFinish(callback));
            return bestResult;
        }
        
        inline SearchNode<T> solve(unsigned timeLimit, unsigned initialDepth = 1, const std::function<bool(const SearchNode<T>&, const AStar<T,H>&, unsigned)>& callback = [](const SearchNode<T>&) { return true; }) {
            return solve(std::chrono::milliseconds(timeLimit), initialDepth, callback);
        }
        
        // TODO Check cannot find solution
        int isGameFinish(const std::function<bool(const SearchNode<T>&, const AStar<T,H>&, unsigned)>& callback = [](const SearchNode<T>&) { return true; }) {
            // std::chrono::milliseconds timeLimit = 1000;
            auto startTime = std::chrono::system_clock::now().time_since_epoch();
            SearchNode<T> bestResult;
            uint depth = 1;
            std::chrono::milliseconds timeLimit = std::chrono::milliseconds(1000);
            {
                AStar<T,H> as(initialState, heuristic, depth);
                if(as.isDone()) {
                    // game finish
                    return 1;
                }
                as.setHistory(history);
                if(SearchNode<T> newBest = as.solve([&callback,startTime, timeLimit, &as, depth](const SearchNode<T>& node)->bool{
                   return callback(node, as, depth);
                })) {
                    // printf("set new best\n");
                    Move initialMove = *newBest.getInitialMove();
                    if (initialMove.type == MoveType::DEAL) {
                        printf("error, assert(initialMove.type != MoveType::DEAL)\n");
                    } else{
                        bestResult = newBest;
                    }
                } else {
                    // break;
                }
            }
            // printf("return bestResult\n");
            if(!bestResult){
                printf("Cannot find any solution\n");
                return 2;
            }
            return 0;
        }
        
    };
    
}

#endif /* #ifndef ASTAR */
