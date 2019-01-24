#include <fstream>
#include <string>
using namespace std;

namespace Reversi
{
#define DIVS 4
#define IOFFSET 10
#define TURNSPERDIV 9
    
    double **edgeTable1;
    double **p24Table;
    double **pE2XTable;
    double **p33Table;
    double **line3Table1;
    double **line4Table1;
    double **diag8Table1;
    double **edgeTableb;
    double **p24Tableb;
    double **pE2XTableb;
    double **p33Tableb;
    double **line3Tableb;
    double **line4Tableb;
    double **diag8Tableb;
    
    void readEdgeTable();
    void readPattern24Table();
    void readPatternE2XTable();
    void readPattern33Table();
    void readPatternLine3Table();
    void readPatternLine4Table();
    void readPatternDiag8Table();
    void freemem();
    
    void blur() {
        for(int32_t n = 0; n < DIVS; n++) {
            if(n == 0) {
                for(int32_t i = 0; i < 6561; i++) {
                    edgeTableb[n][i] = (2*edgeTable1[n][i] + edgeTable1[n+1][i])/3;
                    p24Tableb[n][i] = (2*p24Table[n][i] + p24Table[n+1][i])/3;
                    line3Tableb[n][i] = (2*line3Table1[n][i] + line3Table1[n+1][i])/3;
                    line4Tableb[n][i] = (2*line4Table1[n][i] + line4Table1[n+1][i])/3;
                    diag8Tableb[n][i] = (2*diag8Table1[n][i] + diag8Table1[n+1][i])/3;
                }
                for(int32_t i = 0; i < 59049; i++) {
                    pE2XTableb[n][i] = (2*pE2XTable[n][i] + pE2XTable[n+1][i])/3;
                }
                for(int32_t i = 0; i < 19683; i++) {
                    p33Tableb[n][i] = (2*p33Table[n][i] + p33Table[n+1][i])/3;
                }
            }
            else if(n == DIVS-1) {
                for(int32_t i = 0; i < 6561; i++) {
                    edgeTableb[n][i] = (2*edgeTable1[n][i] + edgeTable1[n-1][i])/3;
                    p24Tableb[n][i] = (2*p24Table[n][i] + p24Table[n-1][i])/3;
                    line3Tableb[n][i] = (2*line3Table1[n][i] + line3Table1[n-1][i])/3;
                    line4Tableb[n][i] = (2*line4Table1[n][i] + line4Table1[n-1][i])/3;
                    diag8Tableb[n][i] = (2*diag8Table1[n][i] + diag8Table1[n-1][i])/3;
                }
                for(int32_t i = 0; i < 59049; i++) {
                    pE2XTableb[n][i] = (2*pE2XTable[n][i] + pE2XTable[n-1][i])/3;
                }
                for(int32_t i = 0; i < 19683; i++) {
                    p33Tableb[n][i] = (2*p33Table[n][i] + p33Table[n-1][i])/3;
                }
            }
            else {
                for(int32_t i = 0; i < 6561; i++) {
                    edgeTableb[n][i] = (edgeTable1[n-1][i] + 2*edgeTable1[n][i] + edgeTable1[n+1][i])/4;
                    p24Tableb[n][i] = (p24Table[n-1][i] + 2*p24Table[n][i] + p24Table[n+1][i])/4;
                    line3Tableb[n][i] = (line3Table1[n-1][i] + 2*line3Table1[n][i] + line3Table1[n+1][i])/4;
                    line4Tableb[n][i] = (line4Table1[n-1][i] + 2*line4Table1[n][i] + line4Table1[n+1][i])/4;
                    diag8Tableb[n][i] = (line4Table1[n-1][i] + 2*diag8Table1[n][i] + diag8Table1[n+1][i])/3;
                }
                for(int32_t i = 0; i < 59049; i++) {
                    pE2XTableb[n][i] = (pE2XTable[n-1][i] + 2*pE2XTable[n][i] + pE2XTable[n+1][i])/4;
                }
                for(int32_t i = 0; i < 19683; i++) {
                    p33Tableb[n][i] = (p33Table[n-1][i] + 2*p33Table[n][i] + p33Table[n+1][i])/4;
                }
            }
        }
    }
    
    void write() {
        ofstream out;
        out.open("Flippy_Resources/new/p24table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                out << (int) (p24Tableb[n][i] * 100.0) << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/edgetable.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                out << (int32_t) (edgeTableb[n][i] * 100.0) << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/pE2Xtable.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 59049; i++) {
                out << (int32_t) (pE2XTableb[n][i] * 100.0) << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/p33table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 19683; i++) {
                out << (int32_t) (p33Tableb[n][i] * 100.0) << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/line3table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                out << (int32_t) (line3Tableb[n][i] * 100.0) << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/line4table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                out << (int32_t) (line4Tableb[n][i] * 100.0) << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/diag8table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                out << (int32_t) (diag8Tableb[n][i] * 100.0) << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
    }

    int32_t main7(int32_t argc, char **argv) {
        edgeTable1 = new double *[DIVS];
        p24Table = new double *[DIVS];
        pE2XTable = new double *[DIVS];
        p33Table = new double *[DIVS];
        line3Table1 = new double *[DIVS];
        line4Table1 = new double *[DIVS];
        diag8Table1 = new double *[DIVS];
        
        for(int32_t i = 0; i < DIVS; i++) {
            edgeTable1[i] = new double[6561];
            p24Table[i] = new double[6561];
            pE2XTable[i] = new double[59049];
            p33Table[i] = new double[19683];
            line3Table1[i] = new double[6561];
            line4Table1[i] = new double[6561];
            diag8Table1[i] = new double[6561];
        }
        
        edgeTableb = new double *[DIVS];
        p24Tableb = new double *[DIVS];
        pE2XTableb = new double *[DIVS];
        p33Tableb = new double *[DIVS];
        line3Tableb = new double *[DIVS];
        line4Tableb = new double *[DIVS];
        diag8Tableb = new double *[DIVS];
        
        for(int32_t i = 0; i < DIVS; i++) {
            edgeTableb[i] = new double[6561];
            p24Tableb[i] = new double[6561];
            pE2XTableb[i] = new double[59049];
            p33Tableb[i] = new double[19683];
            line3Tableb[i] = new double[6561];
            line4Tableb[i] = new double[6561];
            diag8Tableb[i] = new double[6561];
        }
        
        readEdgeTable();
        readPattern24Table();
        readPatternE2XTable();
        readPattern33Table();
        readPatternLine3Table();
        readPatternLine4Table();
        readPatternDiag8Table();
        
        blur();
        write();
        
        freemem();
        
        return 0;
    }
    
    void freemem2() {
        for(int32_t i = 0; i < DIVS; i++) {
            delete[] edgeTable1[i];
            delete[] p24Table[i];
            delete[] pE2XTable[i];
        }
        delete[] edgeTable1;
        delete[] p24Table;
        delete[] pE2XTable;
        
        for(int32_t i = 0; i < DIVS; i++) {
            delete[] edgeTableb[i];
            delete[] p24Tableb[i];
            delete[] pE2XTableb[i];
        }
        delete[] edgeTableb;
        delete[] p24Tableb;
        delete[] pE2XTableb;
    }
    
    void readEdgeTable() {
        std::string line;
        std::string file;
        file = "Flippy_Resources/new/edgetable.txt";
        std::ifstream edgetable(file);
        
        if(edgetable.is_open()) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t i = 0; i < 729; i++) {
                    getline(edgetable, line);
                    for(int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        edgeTable1[n][9*i+j] = std::stod(line, &sz);
                        line = line.substr(sz);
                    }
                }
            }
            
            edgetable.close();
        }
    }
    
    void readPattern24Table() {
        std::string line;
        std::string file;
        file = "Flippy_Resources/new/p24table.txt";
        std::ifstream p24table(file);
        
        if(p24table.is_open()) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t i = 0; i < 6561; i++) {
                    getline(p24table, line);
                    std::string::size_type sz = 0;
                    p24Table[n][i] = std::stod(line, &sz);
                }
            }
            p24table.close();
        }
    }
    
    void readPatternE2XTable() {
        std::string line;
        std::string file;
        file = "Flippy_Resources/new/pE2Xtable.txt";
        std::ifstream pE2Xtable(file);
        
        if(pE2Xtable.is_open()) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t i = 0; i < 6561; i++) {
                    getline(pE2Xtable, line);
                    for(int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        pE2XTable[n][9*i+j] = std::stod(line, &sz);
                        line = line.substr(sz);
                    }
                }
            }
            pE2Xtable.close();
        }
    }
    
    void readPattern33Table() {
        std::string line;
        std::string file;
        file = "Flippy_Resources/new/p33table.txt";
        std::ifstream p33table(file);
        
        if(p33table.is_open()) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t i = 0; i < 2187; i++) {
                    getline(p33table, line);
                    for(int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        p33Table[n][9*i+j] = std::stod(line, &sz);
                        line = line.substr(sz);
                    }
                }
            }
            p33table.close();
        }
    }
    
    void readPatternLine3Table() {
        std::string line;
        std::string file;
        file = "Flippy_Resources/new/line3table.txt";
        std::ifstream line3table(file);
        
        if(line3table.is_open()) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t i = 0; i < 729; i++) {
                    getline(line3table, line);
                    for(int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        line3Table1[n][9*i+j] = std::stod(line, &sz);
                        line = line.substr(sz);
                    }
                }
            }
            
            line3table.close();
        }
    }
    
    void readPatternLine4Table() {
        std::string line;
        std::string file;
        file = "Flippy_Resources/new/line4table.txt";
        std::ifstream line4table(file);
        
        if(line4table.is_open()) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t i = 0; i < 729; i++) {
                    getline(line4table, line);
                    for(int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        line4Table1[n][9*i+j] = std::stod(line, &sz);
                        line = line.substr(sz);
                    }
                }
            }
            
            line4table.close();
        }
    }
    
    void readPatternDiag8Table() {
        std::string line;
        std::string file;
        file = "Flippy_Resources/new/diag8table.txt";
        std::ifstream diag8table(file);
        
        if(diag8table.is_open()) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t i = 0; i < 729; i++) {
                    getline(diag8table, line);
                    for(int32_t j = 0; j < 9; j++) {
                        std::string::size_type sz = 0;
                        diag8Table1[n][9*i+j] = std::stod(line, &sz);
                        line = line.substr(sz);
                    }
                }
            }
            
            diag8table.close();
        }
    }
}
