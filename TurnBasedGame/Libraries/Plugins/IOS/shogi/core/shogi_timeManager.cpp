/*
  Apery, a USI shogi playing engine derived from Stockfish, a UCI chess playing engine.
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2016 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad
  Copyright (C) 2011-2017 Hiraoka Takuya

  Apery is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Apery is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#include "shogi_common.hpp"
#include "shogi_search.hpp"
#include "shogi_usi.hpp"
#include "shogi_timeManager.hpp"

#include <algorithm>
using namespace std;

namespace Shogi
{
    namespace {
        enum TimeType {
            OptimumTime, MaxTime
        };
        
        const int32_t MoveHorizon = 50;
        const double MaxRatio = 7.09;
        const double StealRatio = 0.35;
        
        double moveImportance(const Ply ply) {
            const double XScale = 7.64;
            const double XShift = 58.4;
            const double Skew   = 0.183;
            return pow((1 + exp((ply - XShift) / XScale)), -Skew) + std::numeric_limits<double>::min();
        }
        
        template <TimeType T> int32_t remaining(const int32_t myTime, const int32_t movesToGo, const Ply ply, const int32_t slowMover) {
            const float TMaxRatio   = (T == OptimumTime ? 1 : MaxRatio);
            const float TStealRatio = (T == OptimumTime ? 0 : StealRatio);
            
            const double moveImportanceSlowed = moveImportance(ply) * slowMover / 100;
            double otherMoveImportance = 0;
            
            for (int32_t i = 1; i < movesToGo; ++i)
                otherMoveImportance += moveImportance(ply + 2 * i);
            
            const double ratio1 = (TMaxRatio * moveImportanceSlowed) / (TMaxRatio * moveImportanceSlowed + otherMoveImportance);
            const double ratio2 = (moveImportanceSlowed + TStealRatio * otherMoveImportance) / (moveImportanceSlowed + otherMoveImportance);
            
            return static_cast<int>(myTime * min(ratio1, ratio2));
        }
    }
    
    void TimeManager::init(LimitsType& limits, const Color us, const Ply ply, const Position& pos, Searcher* s) {
        const int32_t minThinkingTime = 20;// s->options["Minimum_Thinking_Time"];
        const int32_t moveOverhead    = 30;// s->options["Move_Overhead"];
        /*const int32_t slowMover       = (pos.gamePly() < 10 ? s->options["Slow_Mover_10"] :
                                     pos.gamePly() < 16 ? s->options["Slow_Mover_16"] :
                                     pos.gamePly() < 20 ? s->options["Slow_Mover_20"] :
                                     pos.gamePly() < 30 ? s->options["Slow_Mover_30"] :
                                     pos.gamePly() < 40 ? s->options["Slow_Mover_40"] : s->options["Slow_Mover"]);*/
        const int32_t slowMover       = (pos.gamePly() < 10 ? 10 :
                                     pos.gamePly() < 16 ? 20 :
                                     pos.gamePly() < 20 ? 40 :
                                     pos.gamePly() < 30 ? 40 :
                                     pos.gamePly() < 40 ? 40 : 89);
        const Ply drawPly         = 256;// s->options["Draw_Ply"];
        // Draw_Ply までで引き分けになるから、そこまでで時間を使い切る。
        auto moveHorizon = [&](const Ply p) { return min(MoveHorizon, drawPly - p); };
        
        startTime_ = limits.startTime;
        optimumTime_ = maximumTime_ = max(limits.time[us], minThinkingTime);
        
        const int32_t MaxMTG = limits.movesToGo ? min(limits.movesToGo, moveHorizon(ply)) : moveHorizon(ply);
        
        for (int32_t hypMTG = 1; hypMTG <= MaxMTG; ++hypMTG) {
            int32_t hypMyTime = (limits.time[us]
                             + limits.inc[us] * (hypMTG - 1)
                             - moveOverhead * (2 + min(hypMTG, 40)));
            
            hypMyTime = max(hypMyTime, 0);
            
            const int32_t t1 = minThinkingTime + remaining<OptimumTime>(hypMyTime, hypMTG, ply, slowMover);
            const int32_t t2 = minThinkingTime + remaining<MaxTime    >(hypMyTime, hypMTG, ply, slowMover);
            
            optimumTime_ = min(t1, optimumTime_);
            maximumTime_ = min(t2, maximumTime_);
        }
        
        // TODO if (s->options["USI_Ponder"])
            optimumTime_ += optimumTime_ / 4;
        
#if 1
        // 秒読み対応
        
        // こちらも minThinkingTime 以上にする。
        optimumTime_ = max(optimumTime_, minThinkingTime);
        optimumTime_ = min(optimumTime_, maximumTime_);
        
        if (limits.moveTime != 0) {
            if (pos.gamePly() >= 20) {
                if (optimumTime_ < limits.moveTime)
                    optimumTime_ = min(limits.time[us], limits.moveTime);
                if (maximumTime_ < limits.moveTime)
                    maximumTime_ = min(limits.time[us], limits.moveTime);
                optimumTime_ += limits.moveTime;
                maximumTime_ += limits.moveTime;
            }
            if (limits.time[us] != 0)
                limits.moveTime = 0;
        }
#endif
        
        // SYNCCOUT << "info string optimum_time = " << optimumTime_ << SYNCENDL;
        // SYNCCOUT << "info string maximum_time = " << maximumTime_ << SYNCENDL;
    }
}
