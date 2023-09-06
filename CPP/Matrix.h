#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <cstdlib>
#include <iostream>


class Matrix {
private:
	int matrixOrder_;
	double* row_;
public:
	Matrix(int);
	Matrix();
	Matrix(int, double*);
	Matrix(const Matrix&);
	~Matrix();
	Matrix& operator=(const Matrix&);
	void Solve(double*, double*);
};
