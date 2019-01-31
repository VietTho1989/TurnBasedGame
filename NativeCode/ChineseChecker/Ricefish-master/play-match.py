from __future__ import unicode_literals
import argparse
import pexpect
import os
import time
import sys
import tempfile
from itertools import count


class EngineMaster(object):
    def __init__(self, command, logfile=None):
        self.command = command
        if not logfile:
            self.logfile, _ = tempfile.mkstemp()
        elif isinstance(logfile, str):
            self.logfile = open(logfile, "w")
        else:
            self.logfile = logfile

        self._searching = False
        self._moves = ""

    def __enter__(self):
        self.engine = pexpect.spawnu(self.command, echo=True, logfile=self.logfile)
        self.engine.sendline("uci")
        self.engine.expect(
            "id name (?P<name>[^\r\n]+).*id author (?P<author>[^\n]+)(?P<options>.*)(uciok)"
        )
        self.name = self.engine.match.group("name")
        self.author = self.engine.match.group("author")
        self.options = self.engine.match.group("options")
        return self

    def __exit__(self, *args):
        self.logfile.close()

    def isready(self):
        self.engine.sendline("isready")
        self.engine.expect("readyok")

    def custom_command(self, command, expect=None):
        self.engine.sendline(command)
        if expect:
            self.engine.expect(expect)
            return self.engine.match

    def ucinewgame(self):
        self.engine.sendline("ucinewgame")
        self.isready()

    def position(self, fen=None, startpos=False, moves=None):
        self.stop()
        command = "position "
        if startpos:
            command += "startpos"
        else:
            assert fen, "Must specify fen or startpos."
            command += "fen " + fen

        if moves:
            command += " moves " + moves
        self.engine.sendline(command)

    def stop(self):
        move = None
        self.engine.sendline("stop")
        if self._searching:
            self._searching = False
            self.engine.expect("bestmove (?P<move>[^ ]+)\s")
            move = self.engine.match.group("move")
        self.isready()
        return move

    def go(self, movetime=None):
        assert not self._searching, "Already searching!"
        self._searching = True

        if movetime:
            arg = "movetime " + str(movetime)
            self.engine.sendline("go " + arg)
            self.engine.expect("bestmove (?P<move>[^ ]+)\s")
            self._searching = False
            return self.engine.match.group("move")
        else:
            arg = "infinite"
            self.engine.sendline("go " + arg)
            return None  # So user can call stop later.

    def make_move(self, move):
        self._moves += " " + move
        self.position(moves=self._moves)


class ChineseCheckersEngine(EngineMaster):
    @property
    def board(self):
        return (
            self.custom_command("print", "\sA\|.+ q r s").group()
            + "\n"
            + self.get_string()
        )

    def get_string(self):
        self._fen = self.custom_command("string", "[0-2]{121} .").group()
        return self._fen

    def make_move(self, move):
        self.position(fen=self.get_string(), moves=move)


def self_play(engine, movetime=500):
    engine.isready()
    engine.ucinewgame()
    engine.position(startpos=True)

    for i in count():
        move = engine.go(movetime=movetime)
        if "NO_MOVE" in move:
            print("Game over!")
            break
        engine.make_move(move)
        print(engine.board)


def human_play(engine, human_starts=True, movetime=500):
    engine.isready()
    engine.ucinewgame()
    engine.position(startpos=True)
    print(engine.board)

    for i in count(int(human_starts)):
        if i & 1:
            move = input("Enter move: ")
        else:
            move = engine.go(movetime=movetime)
            if "NO_MOVE" in move:
                print("Game over! You win!")
                break
        engine.make_move(move)
        print(engine.board)


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--engine', required=True,
            help='Path to engine executable, i.e. `build/ricefish.x`')
    play_mode = parser.add_mutually_exclusive_group(required=True)
    play_mode.add_argument('--human', action='store_true',
            help='Specify to play as a human against the computer.')
    play_mode.add_argument('--self-play', action='store_true',
            help='Specify to play the computer against it self.')
    args = parser.parse_args()

    with ChineseCheckersEngine(args.engine, "logfile.log") as engine:
        if args.human:
            human_play(engine)
        else:
            self_play(engine, movetime=500)

