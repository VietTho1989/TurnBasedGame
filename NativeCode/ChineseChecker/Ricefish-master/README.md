[![Build Status](https://travis-ci.org/bsamseth/ricefish.svg?branch=master)](https://travis-ci.org/bsamseth/ricefish)
[![Coverage Status](https://coveralls.io/repos/github/bsamseth/ricefish/badge.svg?branch=master)](https://coveralls.io/github/bsamseth/ricefish?branch=master)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/bsamseth/ricefish/blob/master/LICENCE)
[![Project Status: Active – The project has reached a stable, usable state and is being actively developed.](http://www.repostatus.org/badges/latest/active.svg)](http://www.repostatus.org/#active)

# Ricefish
###### Stockfish's distant Chinese cousin


This is a "UCI" Chinese checkers engine. UCI is normally the _Universal Chess Interface_. This interface is implemented 
exactly the same as for regular chess, with some notable exception(s):

- Moves are encoded as `AaBb`, with no spaces, indicating a move from row `A` column `a` to row `B` column `b`.


The current version is based heavily on
[bsamseth/goldfish](https://github.com/bsamseth/goldfish).   

This is meant as a project to work on just for the fun of it.
Contributions are welcome if you feel like it.

## Build

The project is built using CMake, which hopefully makes this as portable as
possible. Recommend building in a separate directory:

``` bash
$ mkdir build && cd build
$ cmake .. -DCMAKE_BUILD_TYPE=Release
$ make
```

After the compiling is done you should have two executables in the build
directory: `ricefish` and `unit_tests.x`. The former is the interface to the
engine it self.

## Run
A _simple_ playing script is available to make this easier, see/run [play-match.py](play-match.py).

```text
usage: play-match.py [-h] --engine ENGINE (--human | --self-play)

optional arguments:
  -h, --help       show this help message and exit
  --engine ENGINE  Path to engine executable, i.e. `build/ricefish.x`
  --human          Specify to play as a human against the computer.
  --self-play      Specify to play the computer against it self.
```

You can play using the UCI interface directly, although this is a bit tedious. 
Here's a short example of how to play with the engine (lines starting with `>` are the commands entered):

``` text
terminal $ build/ricefish.x
> uci
id name Ricefish v0.1
id author Bendik Samseth
uciok
> isready
readyok
> position startpos
> print
 A|
 B|                          x
 C|                        x x
 D|                      x x x
 E|                    x x x x
 F|          . . . . . . . . . . . . .
 G|          . . . . . . . . . . . .
 H|          . . . . . . . . . . .
 I|          . . . . . . . . . .
 J|          . . . . . . . . .
 K|        . . . . . . . . . .
 L|      . . . . . . . . . . .
 M|    . . . . . . . . . . . .
 N|  . . . . . . . . . . . . .
 O|          + + + +
 P|          + + +
 Q|          + +
 R|          +
 S|
   --------------------------------------
   a b c d e f g h i j k l m n o p q r s
> go movetime 100
info depth 1 seldepth 0 nodes 0 time 1539122989870 nps 0
info depth 1 seldepth 1 nodes 2 time 0 nps 0 score cp 2 pv DlFl
info depth 2 seldepth 2 nodes 31 time 1 nps 0 score cp 0 pv DlFl PfNf
info depth 3 seldepth 3 nodes 113 time 3 nps 0 score cp 4 pv DlFl PfNf BnFj
info depth 4 seldepth 4 nodes 898 time 10 nps 0 score cp 0 pv DlFl PfNf BnFj RfNh
info depth 5 seldepth 5 nodes 6305 time 76 nps 0 score cp 3 pv DlFl PfNf FlGl RfNh BnHl
info depth 5 seldepth 5 nodes 10541 time 101 nps 0 currmove DnFn currmovenumber 5
bestmove DlFl ponder PfNf
> position startpos moves DlFl PfNf
> print
 A|
 B|                          x
 C|                        x x
 D|                      . x x
 E|                    x x x x
 F|          . . . . . . x . . . . . .
 G|          . . . . . . . . . . . .
 H|          . . . . . . . . . . .
 I|          . . . . . . . . . .
 J|          . . . . . . . . .
 K|        . . . . . . . . . .
 L|      . . . . . . . . . . .
 M|    . . . . . . . . . . . .
 N|  . . . . + . . . . . . . .
 O|          + + + +
 P|          . + +
 Q|          + +
 R|          +
 S|
   --------------------------------------
   a b c d e f g h i j k l m n o p q r s
> string
1110111111000000100000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000002222022222 x
> position fen 1110111111000000100000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000002222022222 x
> print
 A|
 B|                          x
 C|                        x x
 D|                      . x x
 E|                    x x x x
 F|          . . . . . . x . . . . . .
 G|          . . . . . . . . . . . .
 H|          . . . . . . . . . . .
 I|          . . . . . . . . . .
 J|          . . . . . . . . .
 K|        . . . . . . . . . .
 L|      . . . . . . . . . . .
 M|    . . . . . . . . . . . .
 N|  . . . . + . . . . . . . .
 O|          + + + +
 P|          . + +
 Q|          + +
 R|          +
 S|
   --------------------------------------
   a b c d e f g h i j k l m n o p q r s
> go depth 5  # Depth limited search.
info depth 1 seldepth 0 nodes 0 time 25566 nps 0
info depth 1 seldepth 1 nodes 2 time 0 nps 0 score cp 4 pv BnFj
info depth 2 seldepth 2 nodes 58 time 0 nps 0 score cp 0 pv BnFj RfNh
info depth 3 seldepth 3 nodes 240 time 4 nps 0 score cp 2 pv BnFj RfNh DmFi
info depth 3 seldepth 3 nodes 1524 time 14 nps 0 score cp 3 pv FlGl RfNh BnHl
info depth 4 seldepth 4 nodes 2782 time 25 nps 0 score cp 0 pv FlGl NfMf BnHl RfLf
info depth 5 seldepth 5 nodes 13490 time 133 nps 0 score cp 4 pv FlGl NfMf BnHl RfLf DmHk
info depth 5 seldepth 5 nodes 84306 time 543 nps 0 currmove FlGk currmovenumber 27
bestmove FlGl ponder NfMf
> go infinite  # Search until stopped.
