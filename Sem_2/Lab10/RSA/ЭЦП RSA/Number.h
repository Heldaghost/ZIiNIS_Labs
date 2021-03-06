#ifndef NUMBER_H
#define NUMBER_H
#include <string>

#define DEC 10
#define MAX_BIT_LENGTH 3000
#define MAX_DIGIT_LENGTH MAX_BIT_LENGTH/4

class Number   // encapsulate the operator
{
public:
// length of number of radix 2    
    unsigned length;
// record the value of digit
    unsigned long num[MAX_DIGIT_LENGTH];

    Number();
    Number(unsigned long n);
    Number(const Number &);
    ~Number();

/*****************************************************************
 *  basic calculation
*****************************************************************/
    void operator = (unsigned long A);
    void operator = (const Number& A);

    friend bool operator <(const Number& A,const Number& B);
    friend bool operator <(unsigned long A,const Number& B);
    friend bool operator <(const Number& A,unsigned long B);

    friend bool operator >(const Number& A,const Number& B);
    friend bool operator >(unsigned long A,const Number& B);
    friend bool operator >(const Number& A,unsigned long B);

    friend bool operator ==(const Number& A,const Number& B);
    friend bool operator ==(unsigned long A,const Number& B);
    friend bool operator ==(const Number& A,unsigned long B);

    friend bool operator <=(const Number& A,const Number& B);
    friend bool operator <=(unsigned long A,const Number& B);
    friend bool operator <=(const Number& A,unsigned long B);

    friend bool operator >=(const Number& A,const Number& B);
    friend bool operator >=(unsigned long A,const Number& B);
    friend bool operator >=(const Number& A,unsigned long B);

    friend bool operator !=(const Number& A,const Number& B);
    friend bool operator !=(unsigned long A,const Number& B);
    friend bool operator !=(const Number& A,unsigned long B);

    friend Number operator +(const Number& A,const Number& B);
    friend Number operator +(unsigned long A,const Number& B);
    friend Number operator +(const Number& A,unsigned long B);

    friend Number operator -(const Number& A,const Number& B);
    friend Number operator -(unsigned long A,const Number& B);
    friend Number operator -(const Number& A,unsigned long B);

    friend Number operator *(const Number& A,const Number& B);
    friend Number operator *(unsigned long A,const Number& B);
    friend Number operator *(const Number& A,unsigned long B);

    friend Number operator /(const Number& A,const Number& B);
    friend Number operator /(unsigned long A,const Number& B);
    friend Number operator /(const Number& A,unsigned long B);

    friend Number operator %(const Number& A,const Number& B);
    friend unsigned long operator %(unsigned long A,const Number& B);
    friend unsigned long operator %(const Number& A,unsigned long B);

/*****************************************************************
????????
Get????????????10??????16??????????????????
Put??????????10??????16????????????????????
*****************************************************************/
	void Get(std::string &str, unsigned int system=DEC);//??????????????????
    void Put(std::string &str, unsigned int system=DEC);

	void CodeStr(std::string &str);
	void UncodeStr(std::string &str);
/*****************************************************************
RSA????????
Rab??????????????????????????
Euc??????????????????
Trans??????????????????????????
GetPrime??????????????????????????
*****************************************************************/
    int Rab();
    Number Euc(Number& A);
    Number Trans(Number& P, Number& M);
    void GetPrime(int bits);
	void GetNum(int bits);
};


#endif
